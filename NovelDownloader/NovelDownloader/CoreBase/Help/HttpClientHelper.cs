using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NovelDownloader.Library;

namespace NovelDownloader.CoreBase.Help
{

    
    /// <summary>
    /// HttpClient Helper  OLDMETHOD
    /// </summary>
    public class HttpClientHelper
    {
        #region Parameter

        /// <summary>
        /// 鎖定物件
        /// </summary>
        private static readonly object LockObj = new object();
        /// <summary>
        /// HttpClient Instatnce
        /// </summary>
        private static HttpClient _httpClient = null;
        /// <summary>
        /// HttpClient Instance
        /// </summary>
        public HttpClient HttpClientInstance = _httpClient;
        /// <summary>
        /// httpClientHandler
        /// </summary>
        private static HttpClientHandler httpClientHandler = null;

        /// <summary>
        /// 預設HttpClient逾時時間 預設100秒
        /// </summary>
        private TimeSpan _DefaultTimeOut = new TimeSpan(0, 0, 0, 100);
        /// <summary>
        /// 是否啟用 EnsureSuccessStatusCode,當失敗時候擲出錯誤
        /// </summary>
        public bool EnabledEnsureSuccessStatusCode = false;
        #endregion

        #region Instance
        /// <summary>
        /// Init初始化
        /// 如果 使用 CancellationTokenSource(Timeout)來設定HttpClient Timeout且 > 100 秒時, 建議初始化時將傳入Timeout.InfiniteTimeSpan
        /// 因為HttpClient預設Timeout為100秒，HttpClient是以HttpClient.Timeout 或是 CancellationTokenSource(Timeout) 兩者先碰到時回傳逾時Exception
        /// </summary>
        /// <param name="SetMaxTimeout">若傳入參數需大於 10ms，預設為100秒</param>
        public HttpClientHelper(TimeSpan? SetMaxTimeout = null)
        {
            GetInstance(SetMaxTimeout);
        }
        /// <summary>
        /// Static Instance 
        /// </summary>
        /// <param name="SetMaxTimeout"></param>
        /// <returns></returns>
        public static HttpClient GetInstance(TimeSpan? SetMaxTimeout)
        {
            if (_httpClient == null)
            {
                lock (LockObj)
                {
                    if (_httpClient == null)
                    {
                        httpClientHandler = new HttpClientHandler()
                        {
                            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true,
                        };
                        httpClientHandler.SslProtocols |= SslProtocols.Tls12;
                        _httpClient = new HttpClient(httpClientHandler);
                        //if (SetMaxTimeout.HasValue)
                        //{
                        //    if (SetMaxTimeout.Value > TimeSpan.FromMilliseconds(10))
                        //    {
                        //        _httpClient.Timeout = SetMaxTimeout.Value;
                        //    }
                        //}
                        //https://blog.yowko.com/httpclient-issue/
                        //共用的 HttpClient 可能會無法即時反應 DNS 的異動
                        //將 HttpClient 的 DefaultRequestHeaders.ConnectionClose 屬性設定為 true，
                        //(也就是將 HTTP 的 keep-alive header 設為 false，讓 socket 在每次處理完 request 即關閉)
                        //這樣增加大約 35 ms 的時間耗損，也失去了重複使用 socket 的好處，比較適用於每次 request 損耗 35 ms 不會造成影響的情境
                        //_httpClient.DefaultRequestHeaders.ConnectionClose = true;

                        //修改 ConnectionLeaseTimeout 時間 : 用來管理 TCP socket 保持開啟的時間，預設為 -1 永遠開啟
                        //ServicePointManager.FindServicePoint(baseUri).ConnectionLeaseTimeout = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;

                        //修改 DnsRefreshTimeout 時間: 用來管理 DNS 更新間隔，預設為 120000 (兩分鐘)
                        //ServicePointManager.DnsRefreshTimeout = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;
                        //兩者皆應視實際使用情境調整
                    }
                }
            }
            return _httpClient;
        }
        /// <summary>
        /// 設定特定網站，於多久後強迫關閉連線來重新解析DNS
        /// </summary>
        /// <param name="DNS_Server_Uri">特定網站 URI網址</param>
        /// <param name="KeepTCPTime">於多久後逾時，並自動關閉連線</param>
        /// <returns></returns>
        public bool SetHttpClientDefalutRequesterHeaders(string DNS_Server_Uri, TimeSpan? KeepTCPTime)
        {
            var sp = ServicePointManager.FindServicePoint(new Uri(DNS_Server_Uri));
            if (KeepTCPTime.HasValue)
            {
                var timeoutSeconds = KeepTCPTime.Value.TotalMilliseconds.ToInt();
                if (timeoutSeconds > 0)
                {
                    sp.ConnectionLeaseTimeout = timeoutSeconds;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 設定  DNS 更新間隔，預設為 120,000ms (兩分鐘)
        /// </summary>
        /// <param name="RefreshDnsTime">參數需大於 0 ，如未給予則會設定預設數值2分鐘</param>
        /// <returns></returns>
        public bool SetHttpClientDNSRefreshTimeout(TimeSpan? RefreshDnsTime)
        {
            if (RefreshDnsTime.HasValue)
            {
                var timeoutSeconds = RefreshDnsTime.Value.TotalMilliseconds.ToInt();
                if (timeoutSeconds > 0)
                {
                    ServicePointManager.DnsRefreshTimeout = timeoutSeconds;
                    return true;
                }
            }
            else
            {
                ServicePointManager.DnsRefreshTimeout = TimeSpan.FromMinutes(2).TotalMilliseconds.ToInt();
                return true;
            }
            return false;
        }
        #endregion


        #region Get Methods

        /// <summary>
        /// GetAsync 
        /// </summary>
        /// <typeparam name="T">回傳之Model</typeparam>
        /// <param name="requestUrl">URL網址</param>
        /// <param name="timeout">逾時秒數，不得小於 10 milliseconds</param>
        /// <returns></returns>
        public async Task<ServiceResult<T>> GetAsync<T>(string requestUrl, TimeSpan? timeout = null)
        {
            if (timeout.HasValue is false)
            {
                timeout = _DefaultTimeOut;
            }
            if (timeout < TimeSpan.FromMilliseconds(10))
            {
                timeout = TimeSpan.FromMilliseconds(10);
            }
            using (var cts = new CancellationTokenSource(timeout.Value))
            {
                ServiceResult<T> returnResult = new ServiceResult<T>(false, string.Empty, default);
                var sourceJson = string.Empty;
                try
                {
                    //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    //ServicePointManager.SecurityProtocol =
                    //    ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                    //cts.CancelAfter(timeout.Value);
                    //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                    using (var response = _httpClient.GetAsync(requestUrl, cts.Token).Result)
                    {
                        if (EnabledEnsureSuccessStatusCode)
                            response.EnsureSuccessStatusCode();
                        sourceJson = await response.Content.ReadAsStringAsync() ?? string.Empty;
                        returnResult.IsOk = response?.StatusCode == HttpStatusCode.OK;
                        returnResult.Message += $"API資料呼叫成功，回傳狀態[{response?.StatusCode.ToString()}]";
                        returnResult.Code = response.StatusCode.ToNumberValue();
                        returnResult.Content = sourceJson;
                        returnResult.Data = JsonConvert.DeserializeObject<T>(sourceJson);

                    }
                    //HttpResponseMessage response = await _httpClient.SendAsync(request, cts.Token);
                    //response.EnsureSuccessStatusCode();
                    //var json = await response?.Content?.ReadAsStringAsync() ?? string.Empty;
                    //retunrResult.Data = JsonConvert.DeserializeObject<T>(json);
                    //retunrResult.IsOk = true;
                    //retunrResult.Message += $"API資料呼叫成功，回傳狀態[{response?.StatusCode.ToString()}]";
                    //retunrResult.Code = response.StatusCode.ToNumberValue();
                }
                catch (Exception ex)
                {
                    returnResult.IsOk = false;
                    returnResult.Exception = ex;
                    if (cts.IsCancellationRequested is true)
                    {
                        returnResult.Message += $"連線作業逾時，" + ex.GetOriginalException().Message;
                    }
                    else
                    {
                        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage + ", SourceJson=" + sourceJson;
                    }
                }
                return returnResult;
            }
        }

        /// <summary>
        /// GetAsync 
        /// </summary>
        /// <typeparam name="T">回傳之Model</typeparam>
        /// <param name="requestUrl">URL網址</param>
        /// <param name="timeout">逾時秒數，不得小於 10 milliseconds</param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetAsync(string requestUrl, TimeSpan? timeout = null)
        {
            if (timeout.HasValue is false)
            {
                timeout = _DefaultTimeOut;
            }
            if (timeout < TimeSpan.FromMilliseconds(10))
            {
                timeout = TimeSpan.FromMilliseconds(10);
            }
            using (var cts = new CancellationTokenSource(timeout.Value))
            {
                ServiceResult<string> returnResult = new ServiceResult<string>(false, string.Empty, string.Empty);
                var sourceJson = string.Empty;
                try
                {
                    //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    //ServicePointManager.SecurityProtocol =
                    //    ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                    //cts.CancelAfter(timeout.Value);
                    //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                    
                    
                    using (var response = _httpClient.GetAsync(requestUrl, cts.Token).Result)
                    {
                        
                        if (EnabledEnsureSuccessStatusCode)
                            response.EnsureSuccessStatusCode();
                        sourceJson = await response.Content.ReadAsStringAsync() ?? string.Empty;
                        returnResult.IsOk = response?.StatusCode == HttpStatusCode.OK;
                        returnResult.Message += $"API資料呼叫成功，回傳狀態[{response?.StatusCode.ToString()}]";
                        returnResult.Code = response.StatusCode.ToNumberValue();
                        returnResult.Content = sourceJson;
                        returnResult.Data = sourceJson;
                    }
                    //HttpResponseMessage response = await _httpClient.SendAsync(request, cts.Token);
                    //response.EnsureSuccessStatusCode();
                    //var json = await response?.Content?.ReadAsStringAsync() ?? string.Empty;
                    //retunrResult.Data = JsonConvert.DeserializeObject<T>(json);
                    //retunrResult.IsOk = true;
                    //retunrResult.Message += $"API資料呼叫成功，回傳狀態[{response?.StatusCode.ToString()}]";
                    //retunrResult.Code = response.StatusCode.ToNumberValue();
                }
                catch (Exception ex)
                {
                    returnResult.IsOk = false;
                    returnResult.Exception = ex;
                    if (cts.IsCancellationRequested is true)
                    {
                        returnResult.Message += $"連線作業逾時，" + ex.GetOriginalException().Message;
                    }
                    else
                    {
                        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage + ", SourceJson=" + sourceJson;
                    }
                }
                return returnResult;
            }
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Get(string url)
        {
            try
            {
                var response = _httpClient.GetStringAsync(url);
                return response.Result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        #endregion

        #region POST Methods
        /// <summary>
        /// Post 非同步方法
        /// </summary>
        /// <param name="url">網址</param>
        /// <param name="contentJson">Post Data</param>
        /// <returns>JSON string, 失敗或是Exception時候回傳Null</returns>
        public async Task<ServiceResult<string>> PostAsync(string url, string contentJson, TimeSpan? timeout = null)
        {
            if (timeout.HasValue is false)
            {
                timeout = _DefaultTimeOut;
            }
            if (timeout < TimeSpan.FromMilliseconds(100))
            {
                timeout = TimeSpan.FromMilliseconds(100);
            }
            ServiceResult<string> returnResult = new ServiceResult<string>(false, string.Empty, null);
            using (var cts = new CancellationTokenSource(timeout.Value))
            {
                var sourceJson = string.Empty;
                try
                {
                    //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    //ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                    //cts.CancelAfter(timeout.Value);
                    HttpContent content = new StringContent(contentJson);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage response = _httpClient.PostAsync(url, content, cts.Token).Result;
                    if (EnabledEnsureSuccessStatusCode)
                        response.EnsureSuccessStatusCode();
                    sourceJson = await response?.Content?.ReadAsStringAsync();
                    returnResult.Message = $"API資料呼叫成功，回傳狀態[{response?.StatusCode.ToString()}]";
                    returnResult.Code = response.StatusCode.ToNumberValue();
                    returnResult.IsOk = response?.StatusCode == HttpStatusCode.OK;
                    if (response?.StatusCode != HttpStatusCode.OK)
                    {
                        returnResult.Message += Environment.NewLine + "錯誤訊息:" + sourceJson;
                    }
                    returnResult.Content = sourceJson;
                    returnResult.Data = sourceJson;
                    return returnResult;
                }
                catch (Exception ex)
                {
                    returnResult.IsOk = false;
                    returnResult.Exception = ex;
                    if (cts.IsCancellationRequested is true)
                    {
                        returnResult.Message += $"連線作業逾時，" + ex.GetOriginalException().Message;
                    }
                    else
                    {
                        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage + ", SourceJson=" + sourceJson;
                    }
                }
            }
            return returnResult;
        }
        /// <summary>
        /// Post 非同步方法
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="url">網址</param>
        /// <param name="contentJson">Post Data</param>
        /// <returns>Model , 失敗或是Exception 回傳 default</returns>
        public async Task<ServiceResult<T>> PostAsync<T>(string url, string contentJson, TimeSpan? timeout = null)
        {
            if (timeout.HasValue is false)
            {
                timeout = _DefaultTimeOut;
            }
            if (timeout < TimeSpan.FromMilliseconds(100))
            {
                timeout = TimeSpan.FromMilliseconds(100);
            }
            ServiceResult<T> returnResult = new ServiceResult<T>(false, string.Empty, default);
            using (var cts = new CancellationTokenSource(timeout.Value))
            {
                var sourceJson = string.Empty;
                try
                {
                    //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    //ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                    //cts.CancelAfter(timeout.Value);
                    HttpContent content = new StringContent(contentJson ?? string.Empty);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = _httpClient.PostAsync(url, content, cts.Token).Result;
                    if (EnabledEnsureSuccessStatusCode)
                        response.EnsureSuccessStatusCode();
                    sourceJson = await response?.Content?.ReadAsStringAsync();
                    returnResult.Message = $"API資料呼叫成功，回傳狀態[{response?.StatusCode.ToString()}]";
                    returnResult.Code = response.StatusCode.ToNumberValue();
                    returnResult.IsOk = response?.StatusCode == HttpStatusCode.OK;
                    returnResult.Content = sourceJson;
                    returnResult.Data = JsonConvert.DeserializeObject<T>(sourceJson);
                }
                catch (Exception ex)
                {
                    returnResult.IsOk = false;
                    returnResult.Exception = ex;
                    if (cts.IsCancellationRequested is true)
                    {
                        returnResult.Message += $"連線作業逾時，" + ex.GetOriginalException().Message;
                    }
                    else
                    {
                        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage + ", SourceJson=" + sourceJson;
                    }
                }
            }
            return returnResult;
        }
        /// <summary>
        /// Post 同步方法
        /// </summary>
        /// <param name="url">網址</param>
        /// <param name="contentJson">Post Data</param>
        /// <returns>Json string , 失敗或是Exception 回傳 null</returns>
        public ServiceResult<string> Post(string url, string contentJson, TimeSpan? timeout = null)
        {
            if (timeout.HasValue is false)
            {
                timeout = _DefaultTimeOut;
            }
            if (timeout < TimeSpan.FromMilliseconds(100))
            {
                timeout = TimeSpan.FromMilliseconds(100);
            }
            ServiceResult<string> returnResult = new ServiceResult<string>(false, string.Empty, null);
            using (var cts = new CancellationTokenSource(timeout.Value))
            {
                var sourceJson = string.Empty;
                try
                {
                    //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    //ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                    //cts.CancelAfter(timeout.Value);
                    HttpContent content = new StringContent(contentJson);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    Task<HttpResponseMessage> response = _httpClient.PostAsync(url, content);
                    sourceJson = response.Result?.Content?.ReadAsStringAsync()?.Result;
                    returnResult.Message = $"API資料呼叫成功，回傳狀態[{response.Result.StatusCode.ToString()}]";
                    returnResult.IsOk = response.Result?.StatusCode == HttpStatusCode.OK;
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        //retunrResult.IsOk = true;
                    }
                    else
                    {
                        returnResult.Message += Environment.NewLine + "錯誤訊息:" + sourceJson;
                    }
                    returnResult.Code = response.Result.StatusCode.ToNumberValue();
                    returnResult.Content = sourceJson;
                    returnResult.Data = sourceJson;
                    return returnResult;
                }
                catch (Exception ex)
                {
                    returnResult.IsOk = false;
                    returnResult.Exception = ex;
                    if (cts.IsCancellationRequested is true)
                    {
                        returnResult.Message += $"連線作業逾時，" + ex.GetOriginalException().Message;
                    }
                    else
                    {
                        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage + ", SourceJson=" + sourceJson;
                    }
                }
            }
            return returnResult;
        }
        /// <summary>
        /// Post 同步方法
        /// </summary>
        /// <typeparam name="T">Mdoel</typeparam>
        /// <param name="url">網址</param>
        /// <param name="contentJson">Post Data</param>
        /// <returns>Model , 失敗或是Exception 回傳 default</returns>
        public ServiceResult<T> Post<T>(string url, string contentJson, TimeSpan? timeout = null)
        {
            if (timeout.HasValue is false)
            {
                timeout = _DefaultTimeOut;
            }
            if (timeout < TimeSpan.FromMilliseconds(100))
            {
                timeout = TimeSpan.FromMilliseconds(100);
            }
            ServiceResult<T> returnResult = new ServiceResult<T>(false, string.Empty, default);
            using (var cts = new CancellationTokenSource(timeout.Value))
            {
                var sourceJson = string.Empty;
                try
                {
                    //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    //ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                    //cts.CancelAfter(timeout.Value);
                    HttpContent content = new StringContent(contentJson);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    Task<HttpResponseMessage> response = _httpClient.PostAsync(url, content);
                    sourceJson = response.Result?.Content?.ReadAsStringAsync()?.Result;
                    returnResult.Message = $"API資料呼叫成功，回傳狀態[{response.Result.StatusCode.ToString()}]";
                    returnResult.IsOk = response?.Result?.StatusCode == HttpStatusCode.OK;
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        //retunrResult.IsOk = true;
                    }
                    else
                    {
                        returnResult.Message += Environment.NewLine + "錯誤訊息:" + sourceJson;
                    }
                    returnResult.Code = response.Result.StatusCode.ToNumberValue();
                    returnResult.Content = sourceJson;
                    returnResult.Data = JsonConvert.DeserializeObject<T>(sourceJson);
                    return returnResult;
                }
                catch (Exception ex)
                {
                    returnResult.IsOk = false;
                    returnResult.Exception = ex;
                    if (cts.IsCancellationRequested is true)
                    {
                        returnResult.Message += $"連線作業逾時，" + ex.GetOriginalException().Message;
                    }
                    else
                    {
                        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage + ", SourceJson=" + sourceJson;
                    }
                }
            }
            return returnResult;
        }

        #endregion

        #region DELETE Methods

        /// <summary>
        /// Delete 非同步方法
        /// </summary>
        /// <param name="url">網址</param>
        /// <returns>JSON string, 失敗或是Exception時候回傳Null</returns>
        public async Task<ServiceResult<T>> DeletAsync<T>(string url, TimeSpan? timeout = null)
        {
            if (timeout.HasValue is false)
            {
                timeout = _DefaultTimeOut;
            }
            if (timeout < TimeSpan.FromMilliseconds(100))
            {
                timeout = TimeSpan.FromMilliseconds(100);
            }
            ServiceResult<T> returnResult = new ServiceResult<T>(false, string.Empty, default);
            using (var cts = new CancellationTokenSource(timeout.Value))
            {
                var sourceJson = string.Empty;
                try
                {
                    //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    //ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                    //cts.CancelAfter(timeout.Value);
                    using (HttpResponseMessage response =_httpClient.DeleteAsync(url, cts.Token).Result)
                    {
                        if (EnabledEnsureSuccessStatusCode)
                            response.EnsureSuccessStatusCode();
                        sourceJson = await response.Content.ReadAsStringAsync();
                        returnResult.Message = $"API資料呼叫成功，回傳狀態[{response?.StatusCode.ToString()}]";
                        returnResult.Code = response.StatusCode.ToNumberValue();
                        returnResult.IsOk = response?.StatusCode == HttpStatusCode.OK;
                        if (response?.StatusCode != HttpStatusCode.OK)
                        {
                            returnResult.Message += Environment.NewLine + "錯誤訊息:" + sourceJson;
                        }
                        returnResult.Content = sourceJson;
                        returnResult.Data = JsonConvert.DeserializeObject<T>(sourceJson);
                        return returnResult;
                    }
                }
                catch (Exception ex)
                {
                    returnResult.IsOk = false;
                    returnResult.Exception = ex;
                    if (cts.IsCancellationRequested is true)
                    {
                        returnResult.Message += $"連線作業逾時，" + ex.GetOriginalException().Message;
                    }
                    else
                    {
                        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage + ", SourceJson=" + sourceJson;
                    }
                }
            }
            return returnResult;
        }

        #endregion

        #region PUT Methods

        /// <summary>
        /// Put 非同步方法
        /// </summary>
        /// <param name="url">網址</param>
        /// <param name="contentJson">Put Data</param>
        /// <returns>JSON string, 失敗或是Exception時候回傳Null</returns>
        public async Task<ServiceResult<T>> PutAsync<T>(string url, string contentJson, TimeSpan? timeout = null)
        {
            if (timeout.HasValue is false)
            {
                timeout = _DefaultTimeOut;
            }
            if (timeout < TimeSpan.FromMilliseconds(100))
            {
                timeout = TimeSpan.FromMilliseconds(100);
            }
            ServiceResult<T> returnResult = new ServiceResult<T>(false, string.Empty, default);
            using (var cts = new CancellationTokenSource(timeout.Value))
            {
                var sourceJson = string.Empty;
                try
                {
                    //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    //ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                    //cts.CancelAfter(timeout.Value);
                    var content = new StringContent(contentJson ?? string.Empty, Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = _httpClient.PutAsync(url, content, cts.Token).Result)
                    {
                        if (EnabledEnsureSuccessStatusCode)
                            response.EnsureSuccessStatusCode();
                        sourceJson = await response.Content.ReadAsStringAsync();
                        returnResult.Message = $"API資料呼叫成功，回傳狀態[{response?.StatusCode.ToString()}]";
                        returnResult.Code = response.StatusCode.ToNumberValue();
                        returnResult.IsOk = response?.StatusCode == HttpStatusCode.OK;
                        if (response?.StatusCode != HttpStatusCode.OK)
                        {
                            returnResult.Message += Environment.NewLine + "錯誤訊息:" + sourceJson;
                        }
                        returnResult.Content = sourceJson;
                        returnResult.Data = JsonConvert.DeserializeObject<T>(sourceJson);
                        return returnResult;
                    }
                }
                catch (Exception ex)
                {
                    returnResult.IsOk = false;
                    returnResult.Exception = ex;
                    if (cts.IsCancellationRequested is true)
                    {
                        returnResult.Message += $"連線作業逾時，" + ex.GetOriginalException().Message;
                    }
                    else
                    {
                        returnResult.Message += "THROW:" + ex.GetInnerException().ErrorMessage + ", SourceJson=" + sourceJson;
                    }
                }
            }
            return returnResult;
        }

        #endregion




    }



    //public static class HttpClientHelper
    //{
    //    public static async Task<HttpResponseMessage> SendAsyncWithTimeout(this HttpClient httpClient,
    //        HttpRequestMessage request, int timeoutIntMs)
    //    {
    //        return await httpClient.SendAsyncWithTimeout(request, TimeSpan.FromMilliseconds(timeoutIntMs));
    //    }

    //    public static async Task<HttpResponseMessage> SendAsyncWithTimeout(this HttpClient httpClient,
    //        HttpRequestMessage request, TimeSpan timeout)
    //    {
    //        using var cls = new CancellationTokenSource(timeout);
    //        try
    //        {
    //            return await httpClient.SendAsync(request, cls.Token);
    //        }
    //        catch (OperationCanceledException) when (!cls.Token.IsCancellationRequested)
    //        {
    //            throw new TimeoutException();
    //        }
    //    }
    //}


    #region Better timeout handling with HttpClient
    //Title: Better timeout handling with HttpClient
    //https://thomaslevesque.com/2018/02/25/better-timeout-handling-with-httpclient/
    //GitHub Source
    //https://gist.github.com/thomaslevesque/b4fd8c3aa332c9582a57935d6ed3406f

    #region HttpRequestExtensions

    /// <summary>
    /// Timeout Handle
    /// </summary>
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// HttpRequestMessage.Properties["RequestTimeout"] 文字參數
        /// </summary>
        private const string TimeoutPropertKey = "RequestTimeout";
        /// <summary>
        /// 設定Timeout
        /// </summary>
        /// <param name="request">HttpRequestMessage</param>
        /// <param name="timeOut">SetValue</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetTimeout(this HttpRequestMessage request, TimeSpan? timeOut)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            request.Properties[TimeoutPropertKey] = timeOut;
        }
        /// <summary>
        /// 取得Timeout 
        /// </summary>
        /// <param name="request">HttpRequestMessage</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TimeSpan? GetTimeout(this HttpRequestMessage request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (request.Properties.TryGetValue(TimeoutPropertKey, out var value) && value is TimeSpan timeout)
                return timeout;
            return null;
        }
    }

    #endregion

    #region TimeoutHandler
    /// <summary>
    /// HttpResponseMessage Timeout Handler
    /// When Create HttpClient, it's possible to specify the first handler of the pipline.
    /// 當建立HttpClient時候，需 new Timeouthandler(){ InnerHandler = new HttpClientHandler() } 並把 Timeouthandler 當作參數傳入HttpClient建構子中
    /// </summary>
    public class TimeoutHandler : DelegatingHandler
    {
        /*
         *
         */


        /// <summary>
        /// 逾時時間 (預設100秒)
        /// </summary>
        public TimeSpan DefaultTimeout { get; set; } = TimeSpan.FromSeconds(100);
        /// <summary>
        /// Override method to throwing the correct Exception! 
        /// If the request’s timeout is infinite, we don’t create a CancellationTokenSource; it would never be canceled, so we save a useless allocation.
        /// If not, we create a CancellationTokenSource that will be canceled after the timeout is elapsed (CancelAfter).
        /// Note that this CTS is linked to the CancellationToken we receive as a parameter in SendAsync: this way,
        /// it will be canceled either when the timeout expires, or when the CancellationToken parameter will itself be canceled.
        /// You can get more details on linked cancellation tokens in this article.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="TimeoutException"></exception>
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            using (var cts = GetCancellationTokenSource(request, cancellationToken))
            {
                try
                {
                    return await base.SendAsync(request, cts?.Token ?? cancellationToken);
                }
                catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
                {
                    throw new TimeoutException();
                }
                catch
                {
                    throw;
                }
            }
        }

        

        /// <summary>
        /// 抓取 Timeout CancellationTokenSource
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private CancellationTokenSource GetCancellationTokenSource(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var timeout = request.GetTimeout() ?? DefaultTimeout;
            if (timeout == Timeout.InfiniteTimeSpan)
            {
                // No need to create a CTS if there' no timeout
                return null;
            }
            else
            {
                var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                cts.CancelAfter(timeout);
                return cts;
            }
        }
    }

    #endregion

    #endregion

}
