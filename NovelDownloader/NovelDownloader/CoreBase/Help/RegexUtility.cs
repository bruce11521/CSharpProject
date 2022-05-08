using System.Text.RegularExpressions;

namespace NovelDownloader.CoreBase.Help
{
    /// <summary>
    /// Regex 相關列舉
    /// </summary>
    public class RegexUtility
    {
        /*
         Tip：
            使用 Regex 時，建議IsMatch，要考慮文字為Null會出錯
            使用建議範例 RegexUtility.CaseType01INSRCode.IsMatch(vaildString ?? string.Empty)
         */

        #region 案件分類醫令列表
        /// <summary>
        /// 01西醫一般案件
        /// 醫令為15017C
        /// </summary>
        public static Regex CaseType01INSRCode = new Regex("^15017[a-z|A-Z]$");

        /// <summary>
        /// 03西醫門診手術、13牙醫門診手術案件特有醫令
        /// 手術醫令範圍判斷 健保碼開頭是 62 - 88 (非二碼的) 或 健保碼開頭是 922 (非三碼的)
        /// </summary>
        public static Regex CaseType0313INSRCode = new Regex("(^(6[2-9]|7[0-9]|8[0-8])([0-9]|[a-z]|[A-Z]))|(^922([0-9]|[a-z]|[A-Z]))");

        /// <summary>
        /// 05洗腎案件特有醫令
        ///  健保碼為 『58001C、58011C、58017C、58019C、58020C、58021C、58022C、58023C、58024C、58025C、58027C、58028C、58029C』
        /// </summary>
        //public static Regex CaseType05INSRCode = new Regex("^(580[0-1]1|58017|58019|5802[0-5]|5802[7-9])([a-z|A-Z])$");
        public static string patternCaseType05INSRCode = "^(58001|58017|58019|5802[0-5]|5802[7|9])([a-z|A-Z])$";
        public static Regex CaseType05INSRCode = new Regex(patternCaseType05INSRCode);
        
        /// <summary>
        /// 05洗腎案件特有醫令(技術費)
        /// </summary>
        public static string patternCaseType05INSRCodeTherapy = "^(58011|58017)([a-z|A-Z])$";
        public static Regex CaseType05INSRCodeTherapy = new Regex(patternCaseType05INSRCodeTherapy);
        
        /// <summary>
        /// 05洗腎案件特有醫令(機器費)
        /// </summary>
        public static string patternCaseType05INSRCodeAPDDailyFee = "^(58028)([a-z|A-Z])$";
        public static Regex CaseType05INSRCodeAPDDailyFee = new Regex(patternCaseType05INSRCodeAPDDailyFee);

        /// <summary>
        /// A1居家照護、A6護理之家、A7安養養護機構院民案件類別特有醫令
        /// </summary>
        //List<string> CaseTypeA1A6A7CureID = new List<string>
        //{
        //    "05301C", "05302C", "05303C", "05304C", "05305C", "05306C", "05307C", "05308C", "05309C", "05310C"
        //    , "05321C", "05322C", "05328C", "05330C", "05332C", "05334C", "05342C", "05344C", "05346C", "05348C"
        //    , "05350C", "05352C", "05354C", "05356C", "05358C", "05360C", "P5407C", "P5401C", "P5402C", "P5403C"
        //    , "P5404C", "P5406C", "P5408C", "P5409C", "P5411C", "P5412C", "P5413C"
        //};
        public static Regex CaseTypeA1A6A7INSRCode = new Regex("^(0530[1-9]|05310|0532[1|2|8]|0533[0|2|4]|053[4-5][2|4|6|8]|053[5-6]0|[p|P]540[1-4|6-9]|[p|P]541[1-3])([a-z|A-Z])$");

        /// <summary>
        /// A2精神疾病社區復健案件類別特有醫令
        /// </summary>
        //List<string> CaseTypeA2CureID = new List<string>
        //{
        //    "05401C", "05402C", "05403C", "05404C", "05405C", "05406C"
        //};
        public static Regex CaseTypeA2INSRCode = new Regex("^(0540[1-6])([a-z|A-Z])$");

        /// <summary>
        /// A3預防保健案件類別特有醫令
        /// </summary>
        //List<string> CaseTypeA3CureID = new List<string>
        //{
        //    "00", "11", "12", "13", "14", "15", "16", "17", "18", "19"
        //    , "20", "21", "22", "23", "24", "25", "26", "27", "28", "31"
        //    , "33", "35", "41", "42", "43", "44", "45", "46", "47", "48"
        //    , "49", "50", "61", "63", "64", "66", "68", "71", "72", "73"
        //    , "75", "76", "77", "79", "81", "85", "91", "93", "95", "21+L1001C"
        //};
        public static Regex CaseTypeA3INSRCode = new Regex("^(00|1[1-9]|2[0-8]|3[1|3|5]|4[1-9]|50|6[1|3-4|8]|7[1-3|5-7|9]|8[1|5]|9[1|3|5]|21\\+L1001C)$");

        /// <summary>
        /// A5安寧照護案件類別特有醫令
        /// </summary>
        //List<string> CaseTypeA5CureID = new List<string>
        //{
        //      "05311C", "05312C", "05313C", "05314C", "05315C", "05316C", "05323C", "05324C", "05325C", "05326C"
        //        , "05327C", "05336C", "05337C", "05338C", "05339C", "05340C", "05341C", "05362C", "05364C", "05366C"
        //        , "05368C", "05370C", "05372C", "05374C", "P5405C"
        //};
        public static Regex CaseTypeA5INSRCode = new Regex("^(0531[1-6]|0532[3-7]|0533[6-9]|0534[0-1]|(0536[2|4|6|8])|(0537[0|2|4])|[p|P]5405)([a-z|A-Z])$");

        /// <summary>
        /// C1論病歷計酬案件DRG：3A
        /// </summary>
        public static Regex CaseTypeC13AINSRCode = new Regex("^86008[a-z|A-Z]$");

        /// <summary>
        /// C1論病歷計酬案件DRG：1A
        /// </summary>
        public static Regex CaseTypeC11AINSRCode = new Regex("^(75606|75607|75613|75614|75615)([a-z|A-Z])$");

        /// <summary>
        /// C1論病歷計酬案件DRG：2A、2B、2C、2D
        /// </summary>
        public static Regex CaseTypeC123INSRCode = new Regex("^50023[a-z|A-Z]$");

        /// <summary>
        /// C1論病歷計酬案件DRG：2A、2B、2C、2D
        /// </summary>
        public static Regex CaseTypeC124INSRCode = new Regex("^50024[a-z|A-Z]$");

        /// <summary>
        /// C1論病歷計酬案件DRG：4A
        /// </summary>
        public static Regex CaseTypeC14AINSRCode = new Regex("^(66002|66032)([a-z|A-Z])$");

        /// <summary>
        /// C4代辦無健保結核病患案件
        /// 醫令E40開頭
        /// </summary>
        public static Regex CaseTypeC4INSRCode = new Regex("^E40");

        /// <summary>
        /// D2代辦COVID-19 檢驗費
        /// </summary>
        //var CaseDivideD2CovidINSRCode = new List<string>
        //{
        //    "E5002C","E5003C","E5004C","E5005C"
        //};
        public static string patternCovidINSRCode = "^(E500[2-5])([a-z|A-Z])$";
        public static Regex CaseTypeD2CovidINSRCode = new Regex(patternCovidINSRCode);
        
        /// <summary>
        /// D2老人及6個月至6歲兒童流感疫苗注射案件
        /// var CaseDivideD2OtharINSRCode = new List<string>
        /// {
        ///     "J000113265", "J000113277", "K000901206", "X000092206", "K000523206", "K000889206", "K000453265", "K000453277", "A2001C", "A3001C"
        ///     , "K000492206", "J000138206", "K001036206", "K001126206", "X000209206"
        /// };
        /// </summary>
        public static Regex CaseTypeD2OtharINSRCode = new Regex("^((A[2-3]001)([a-z|A-Z])|(J000113265|J000113277|J000138206|K000453265|K000453277|K000492206|K000523206|K000889206|K000901206|K001036206|X000209206|K001126206|X000092206))$");

        /// <summary>
        /// D2老人及6個月至6歲兒童流感疫苗注射案件
        /// var CaseDivideD2PediatricsINSRCode = new List<string>
        /// {
        ///      "A2001C", "A2051C", "A2052C", "J000082209", "J000085216", "J000113265", "J000113277", "J000138206", "K000301206", "K000301209"
        ///     , "K000351206", "K000351209", "K000364206", "K000440206", "K000450206", "K000453265", "K000453277", "K000456206", "K000456209", "K000480206"
        ///     , "K000501206", "K000501209", "K000510206", "K000523206", "K000821206", "K000829206", "K000889206", "K000901206", "K000906206", "K000912206"
        ///     , "K000967206", "K000981206", "K001036206", "K001126206", "KC00452206", "KC00452209", "KC00452221", "X000092206", "X000153206", "X000154206"
        ///     , "X000155229", "X000156206", "X000157206", "X000158206", "X000159209", "X000160206", "X000164206", "X000165206", "X000209206"
        /// };
        /// </summary>
        public static Regex CaseTypeD2PediatricsINSRCode = new Regex("^((A2001|A205[1-2])([a-z|A-Z])|(J000082209|J000085216|J000113265|J000113277|J000138206|K000301206|K000301209|K000351206|K000351209|K000364206|K000440206|K000450206|K000453265|K000453277|K000456206|K000456209|K000480206|K000501206|K000501209|K000510206|K000523206|K000821206|K000829206|K000889206|K000901206|K000906206|K000912206|K000967206|K000981206|K001036206|K001126206|KC00452206|KC00452209|KC00452221|X000092206|X000153206|X000154206|X000155229|X000156206|X000157206|X000158206|X000159209|X000160206|X000164206|X000165206|X000209206))$");

        /// <summary>
        /// 登革熱案件
        /// </summary>
        public static Regex CaseTypeDFINSRCode = new Regex("^E5001[a-z|A-Z]$");

        /// <summary>
        /// E1健保試辦計劃案件
        /// 醫令有 P1407C, P1408C, P1409C, P1410C, P1411C 轉E1案件
        /// </summary>
        public static Regex CaseTypeE1INSRCode = new Regex("^(P140[7-9]|P141[0-1])([a-z|A-Z])$");

        /// <summary>
        /// E1健保試辦計劃案件、特定治療代碼EB
        /// 醫令有 P4301C 到 P4303C
        /// </summary>
        public static Regex CaseTypeE1EBINSRCode = new Regex("^P430[1-3]([a-z|A-Z])$");

        /// <summary>
        /// E1健保試辦計劃案件、特定治療代碼K1
        /// 醫令有 P3402C 到 P3409C
        /// </summary>
        public static Regex CaseTypeE1K1INSRCode = new Regex("^P340[2-9]([a-z|A-Z])$");

        /// <summary>
        /// E1健保試辦計劃案件、特定治療代碼H7
        /// 醫令有 P4201C 到 P4205C
        /// </summary>
        public static Regex CaseTypeE1H7INSRCode = new Regex("^P420[1-5]([a-z|A-Z])$");

        /// <summary>
        /// E1健保試辦計劃案件、特定治療代碼E6
        /// 醫令有 P1612C 到 P1614B
        /// </summary>
        public static Regex CaseTypeE1E6INSRCode = new Regex("^P161[2-4]([a-z|A-Z])$");

        /// <summary>
        /// E1健保試辦計劃案件、特定治療代碼HE
        /// 醫令有 HCVDAA0001 到 HCVDAA0016
        /// </summary>
        public static Regex CaseTypeE1HEINSRCode = new Regex("^HCVDAA00((0[1-9])|(1[0-6]))$");

        /// <summary>
        /// E1健保試辦計劃案件、特定治療代碼HF
        /// 醫令有P6011C, P6012C, P6013C, P6015C
        /// </summary>
        public static Regex CaseTypeE1HFINSRCode = new Regex("^(P601[1-3]|P6015)([a-z|A-Z])$");

        /// <summary>
        /// E1健保試辦計劃案件、心臟衰竭PAC個案評估費及獎勵費
        /// 醫令有P5114B, P5115B, P5117B, P5135B
        /// 且D13 要為 '5'
        /// </summary>
        public static Regex CaseTypeE1HeartFailure = new Regex("^([p|P])(511[4|5|7]|5135)([a-z|A-Z])$");

        /// <summary>
        /// 後新冠整合照護
        /// 醫令有E5102B, E5103B, E5104B, E5105B, E5106B, E5107B, E5108B, E5109B, E5110B, E5111B, E5112B
        /// 且D13 要為 'C'
        /// </summary>
        public static Regex CaseTypeE1CovidCare = new Regex("^([e|E])(510[2-9]|511[0-2])([a-z|A-Z])$");

        /// <summary>
        /// 牙科醫令
        /// </summary>
        //var CaseDivideDentalINSRCode = new List<string>
        //{
        //    "92004C", "92007B", "92008B", "92010B", "92011B", "92014C", "92015C", "92016C", "92020B", "92025B"
        //    , "92026B", "92037B", "92038B", "92039B", "92040B", "92044B", "92059C", "92064C", "92065B", "92093B"
        //    , "92096C"
        //};
        public static Regex CaseDivideDentalINSRCode = new Regex("^(9200[4|7-8]|9201[0-1|4-6]|9202[0|5-6]|9203[7-9]|9204[0|4]|92059|9206[4|5]|9209[3|6])([a-z|A-Z])$");
        #endregion 案件分類醫令列表

        #region 特定治療代碼
        /// <summary>
        /// A1 特定治療代碼(超音波檢查)
        /// (前五碼健保碼 >= '19001') AND (前五碼健保碼 <= '19007')) OR
        /// (健保碼 = '18005B') OR 
        /// (健保碼 = '18006B') OR 
        /// (健保碼 = '18007B')
        /// </summary>
        public static Regex CureItemA1 = new Regex("(^(1900[1-7])([a-z|A-Z|0-9]))|(^(1800[5-7][a-z|A-Z])$)");

        /// <summary>
        /// A2 特定治療代碼(耳鼻喉科檢查)
        /// (前五碼健保碼 >= '22001') AND (前五碼健保碼 <= '22023')
        /// </summary>
        public static Regex CureItemA2 = new Regex("^(2200[1-9]|2201[0-9]|2202[0-3])([a-z|A-Z|0-9])");

        /// <summary>
        /// A3 特定治療代碼(內視鏡檢查)
        /// (前五碼健保碼 >= '28001') AND (前五碼健保碼 <= '28028')
        /// </summary>
        public static Regex CureItemA3 = new Regex("^(2800[1-9]|2801[0-9]|2802[0-8])([a-z|A-Z|0-9])");

        /// <summary>
        /// A4 特定治療代碼(病理組織檢查)
        /// (前五碼健保碼 >= '25001') AND (前五碼健保碼 <= '25010')
        /// </summary>
        public static Regex CureItemA4 = new Regex("^(2500[1-9]|25010)([a-z|A-Z|0-9])");

        /// <summary>
        /// A5 特定治療代碼(核子醫學檢查)
        /// ((前五碼健保碼 >= '26001') AND (前五碼健保碼 <= '26068')) OR
        /// ((前五碼健保碼 >= '27001') AND (前五碼健保碼 <= '27076'))
        /// </summary>
        public static Regex CureItemA5 = new Regex("(^(2600[1-9]|260[2-5][0-9]|2606[0-8])([a-z|A-Z|0-9]))|(^(2700[1-9]|270[2-6][0-9]|2707[0-6])([a-z|A-Z|0-9]))");

        /// <summary>
        /// A6 特定治療代碼(X光檢查)
        /// (前五碼健保碼 >= '32001') AND (前五碼健保碼 <= '32025')
        /// </summary>
        public static Regex CureItemA6 = new Regex("^(3200[1-9]|3201[0-9]|3202[0-5])([a-z|A-Z|0-9])");

        /// <summary>
        /// A7 特定治療代碼(特殊造影檢查)
        /// (前五碼健保碼 >= '33001') AND (前五碼健保碼 <= '33085')
        /// </summary>
        public static Regex CureItemA7 = new Regex("^(3300[1-9]|330[2-7][0-9]|3308[0-5])([a-z|A-Z|0-9])");

        /// <summary>
        /// A8 特定治療代碼(神經科檢查)
        /// (前五碼健保碼 >= '20001') AND (前五碼健保碼 <= '20030')
        /// </summary>
        public static Regex CureItemA8 = new Regex("^(2000[1-9]|200[1-2][0-9]|20030)([a-z|A-Z|0-9])");

        /// <summary>
        /// D0 特定治療代碼(物理治療簡單、中度治療)
        /// (前五碼健保碼 >= '42001') AND (前五碼健保碼 <= '42009')
        /// </summary>
        public static Regex CureItemD0 = new Regex("^(4200[1-9])([a-z|A-Z|0-9])");

        /// <summary>
        /// D1 特定治療代碼(癌症放射線治療)
        /// ((前五碼健保碼 >= '36001') AND (前五碼健保碼 <= '36013')) OR  ((前五碼健保碼 >= '37001') AND (前五碼健保碼 <= '37017'))
        /// </summary>
        public static Regex CureItemD1 = new Regex("(^(3600[1-9]|3600[1-3])([a-z|A-Z|0-9]))|(^(3700[1-9]|3701[0-7])([a-z|A-Z|0-9]))");

        /// <summary>
        /// D2 特定治療代碼(癌症化學治療)
        /// 前五碼健保碼 = '37005'
        /// </summary>
        public static Regex CureItemD2 = new Regex("^(37005)([a-z|A-Z|0-9])");

        /// <summary>
        /// D3 特定治療代碼(復健治療（物理治療簡單、中度治療除外）)
        /// ((前五碼健保碼 >= '41002') AND (前五碼健保碼 <= '41006')) OR
        /// ((前五碼健保碼 >= '42010') AND (前五碼健保碼 <= '42019')) OR
        /// ((前五碼健保碼 >= '43001') AND (前五碼健保碼 <= '43026')) OR
        /// ((前五碼健保碼 >= '44001') AND (前五碼健保碼 <= '44010'))
        /// </summary>
        public static Regex CureItemD3 = new Regex("(^(4100[2-6])([a-z|A-Z|0-9]))|(^(4201[0-9])([a-z|A-Z|0-9]))|(^(4300[1-9]|4301[0-9]|4302[0-6])([a-z|A-Z|0-9]))|(^(4400[1-9]|44010)([a-z|A-Z|0-9]))");

        /// <summary>
        /// D4 特定治療代碼(精神科治療)
        /// (前五碼健保碼 >= '45001') AND (前五碼健保碼 <= '45083')
        /// </summary>
        public static Regex CureItemD4 = new Regex("^(4500[1-9]|450[1-7][0-9]|4508[0-3])([a-z|A-Z|0-9])");

        /// <summary>
        /// D5 特定治療代碼(高壓氧治療)
        /// (前五碼健保碼 >= '59001') AND (前五碼健保碼 <= '59012')
        /// </summary>
        public static Regex CureItemD5 = new Regex("^(5900[1-9]|5901[0-2])([a-z|A-Z|0-9])");

        /// <summary>
        /// D6 特定治療代碼(眼科鐳射治療)
        /// (前五碼健保碼 >= '60001') AND (前五碼健保碼 <= '60013')
        /// </summary>
        public static Regex CureItemD6 = new Regex("^(6000[1-9]|6001[0-3])([a-z|A-Z|0-9])");

        /// <summary>
        /// D9 特定治療代碼(腹膜透析)
        /// 健保碼 in ('58011C','58017C','58026C','58002C')
        /// </summary>
        public static Regex CureItemD9 = new Regex("(^(58011|58017|58026|58002)([a-z|A-Z]))$");

        /// <summary>
        /// E6 特定治療代碼(氣喘)
        /// (健保碼 >= 'P1612C') AND (健保碼 <= 'P1614B')
        /// </summary>
        public static Regex CureItemE6 = CaseTypeE1E6INSRCode;

        /// <summary>
        /// EB 特定治療代碼(初期慢性腎臟病醫療給付改善方案)
        /// (健保碼 >= 'P4301C') AND (健保碼 <= 'P4303C')
        /// </summary>
        public static Regex CureItemEB = CaseTypeE1EBINSRCode;

        /// <summary>
        /// FP 特定治療代碼(牙周病統合照護第一階段)
        /// (前五碼健保碼 = 'P4001')
        /// </summary>
        public static Regex CureItemFP = new Regex("^(P4001)([a-z|A-Z|0-9])");

        /// <summary>
        /// FQ 特定治療代碼(牙周病統合照護第二階段)
        /// (前五碼健保碼 = 'P4002')
        /// </summary>
        public static Regex CureItemFQ = new Regex("^(P4002)([a-z|A-Z|0-9])");

        /// <summary>
        /// FR 特定治療代碼(牙周病統合照護第三階段)
        /// (前五碼健保碼 = 'P4003')
        /// </summary>
        public static Regex CureItemFR = new Regex("^(P4003)([a-z|A-Z|0-9])");

        /// <summary>
        /// H1 特定治療代碼(肝炎試辦計畫)
        /// (健保碼 in(BA24469100','BA24468100','BC23920100','K000696266','KC00589237','B022491221','B022491229','K000752221','B022490216','B022490237','K000753216','B016536209','B016536216','B016536221','B016536299','K000754209','KC00589237','K000591243','A048152100','KC00788277','KC00789277','KC00789277','K000765209','K000766209','KC00667255','K000667255','KC00675257','K000669248','KC00674253','K000816255','K000817257','K000815248','K000818253','BC23208100','BC23208100','AB48027100','AC44650100','K000700220','AB48027100','K000700223','K000700227','K000700216','BC24662100','AC44650100','K000700220','K000700223','K000700227','K000700216','BC24662100','BC24690100','AC43302100','BC27086100'))
        /// </summary>
        public static Regex CureItemH1 = new Regex("^(BA24469100|BA24468100|BC23920100|K000696266|KC00589237|B022491221|B022491229|K000752221|B022490216|B022490237|K000753216|B016536209|B016536216|B016536221|B016536299|K000754209|KC00589237|K000591243|A048152100|KC00788277|KC00789277|KC00789277|K000765209|K000766209|KC00667255|K000667255|KC00675257|K000669248|KC00674253|K000816255|K000817257|K000815248|K000818253|BC23208100|BC23208100|AB48027100|AC44650100|K000700220|AB48027100|K000700223|K000700227|K000700216|BC24662100|AC44650100|K000700220|K000700223|K000700227|K000700216|BC24662100|BC24690100|AC43302100|BC27086100)$");

        /// <summary>
        /// H7 特定治療代碼(全民健康保險B型肝炎帶原者及C型肝炎感染者醫療給付改善方案)
        /// (健保碼 >= 'P4201C') AND (健保碼 <= 'P4205C')
        /// </summary>
        public static Regex CureItemH7 = CaseTypeE1H7INSRCode;

        /// <summary>
        /// HE 特定治療代碼(C型肝炎全口服治療)
        /// (健保碼 >= 'HCVDAA0001') AND (健保碼 <= 'HCVDAA0016')
        /// </summary>
        public static Regex CureItemHE = CaseTypeE1HEINSRCode;

        /// <summary>
        /// HF 特定治療代碼(慢性阻塞性肺病醫療給付改善方案
        ///  (健保碼 = 'P6011C') OR (健保碼 = 'P6012C')OR (健保碼 = 'P6013C')OR (健保碼 = 'P6015C')
        /// </summary>
        public static Regex CureItemHF = CaseTypeE1HFINSRCode;

        /// <summary>
        /// K1 特定治療代碼(Pre-ESRD預防性計畫及病人衛教計畫)
        /// (健保碼 >= 'P3402C') AND (健保碼 <= 'P3409C')
        /// </summary>
        public static Regex CureItemK1 = CaseTypeE1K1INSRCode;

        /// <summary>
        /// P1 特定治療代碼(根管治療)
        /// ((前五碼健保碼 >= '90001') AND (前五碼健保碼 <= '90004')) OR
        /// ((前五碼健保碼 >= '90006') AND (前五碼健保碼 <= '90010')) OR
        /// ((前五碼健保碼 >= '90012') AND (前五碼健保碼 <= '90015'))
        /// </summary>
        public static Regex CureItemP1 = new Regex("(^(9000[1-4])([a-z|A-Z|0-9]))|(^(9000[6-9]|90010)([a-z|A-Z|0-9]))|(^(9001[2-5])([a-z|A-Z|0-9]))");

        /// <summary>
        /// P2 特定治療代碼(銀粉充填)
        /// ((前五碼健保碼 >= '89001') AND (前五碼健保碼 <= '89003')) OR(前五碼健保碼 = '89003')
        /// </summary>
        public static Regex CureItemP2 = new Regex("^(8900[1-3])([a-z|A-Z|0-9])");

        /// <summary>
        /// P3 特定治療代碼(複合樹脂[玻璃璃子]充填)
        /// ((前五碼健保碼 >= '89004') AND (前五碼健保碼 <= '89005')) OR 
        /// ((前五碼健保碼 >= '89008') AND (前五碼健保碼 <= '89011'))
        /// </summary>
        public static Regex CureItemP3 = new Regex("(^(8900[4-5])([a-z|A-Z|0-9]))|(^(8900[8-9]|8901[0-1])([a-z|A-Z|0-9]))");

        /// <summary>
        /// P4 特定治療代碼(牙周病手術[含齒齦下刮除術])
        /// ((前五碼健保碼 >= '91001') AND (前五碼健保碼 <= '91002')) OR
        /// ((前五碼健保碼 >= '91006') AND (前五碼健保碼 <= '91012'))
        /// </summary>
        public static Regex CureItemP4 = new Regex("(^(9100[1-2])([a-z|A-Z|0-9]))|(^(9100[6-9]|9101[0-2])([a-z|A-Z|0-9]))");

        /// <summary>
        /// P5 特定治療代碼(兒童斷髓處理)
        /// (前五碼健保碼 = '89006') OR (前五碼健保碼 = '90005') OR(前五碼健保碼 = '90016')
        /// </summary>
        public static Regex CureItemP5 = new Regex("^(89006|90005|90016)([a-z|A-Z|0-9])");

        /// <summary>
        /// P7 特定治療代碼(口腔外科門診手術[包括拔牙])
        /// (前五碼健保碼 = '90011') OR
        /// ((前五碼健保碼 >= '92001') AND (前五碼健保碼 <= '92050')) OR
        /// (前五碼健保碼 = '92055') OR 
        /// ((前五碼健保碼 >= '92221') AND (前五碼健保碼 = '92225'))
        /// </summary>
        public static Regex CureItemP7 = new Regex("(^(90011)([a-z|A-Z|0-9]))|(^(9200[1-9]|920[1-4][0-9]|92050)([a-z|A-Z|0-9]))|(^(92055)([a-z|A-Z|0-9]))|(^(9222[1-5])([a-z|A-Z|0-9]))");

        /// <summary>
        /// P8 特定治療代碼(治療性牙結石清除)
        /// </summary>
        public static Regex CureItemP8 = new Regex("^(9100[3-4])([a-z|A-Z|0-9])");
        #endregion 特定治療代碼

        #region DRG醫令
        /// <summary>
        /// DRG:1A
        /// </summary>
        public static Regex DRG1A = CaseTypeC11AINSRCode;

        /// <summary>
        /// DRG:2A、2B、2C、2D
        /// </summary>
        public static Regex DRG23 = CaseTypeC123INSRCode;

        /// <summary>
        /// DRG:2A、2B、2C、2D
        /// </summary>
        public static Regex DRG24 = CaseTypeC124INSRCode;

        /// <summary>
        /// DRG:3A
        /// </summary>
        public static Regex DRG3A = CaseTypeC13AINSRCode;

        /// <summary>
        /// DRG:4A
        /// </summary>
        public static Regex DRG4A = CaseTypeC14AINSRCode;
        #endregion DRG醫令

        #region 資源共享
        /// <summary>
        /// CTMRI 資源共享
        /// </summary>
        public static Regex CTMRIShareINSRCode = new Regex("^[p|P]210[3|4][a-z|A-Z]$");

        /// <summary>
        /// PET 資源共享
        /// </summary>
        public static Regex PETShareINSRCode = new Regex("^[p|P]210[7|8][a-z|A-Z]$");
        #endregion 資源共享

        #region ICD10 診斷
        /// <summary>
        /// AIDS診斷碼
        /// </summary>
        public static Regex ICD10AIDS = new Regex("^(042|V08|Z21|B20)");

        /// <summary>
        /// 結核病診斷碼
        /// 前五診斷之前3碼為A15~A19 ，或前五診斷為V011、R7611、R7612、Z201)
        /// </summary>
        public static Regex ICD10TB = new Regex("(^A1[5-9])|(^(R7611|R7612|Z201)$)");
        #endregion ICD10 診斷

        #region 包裹計價
        /// <summary>
        /// 乳癌術後低分次全乳照射 包裏頭
        /// </summary>
        public static Regex HypofractionatedWholeBreast = new Regex("^(36022B|36023B)$");

        /// <summary>
        /// 乳癌術後低分次全乳照射 包裏身
        /// </summary>
        public static Regex HypofractionatedWholeBreastDetail = new Regex("^(33090B|36001B|36002B|36004B|36005B|36011B|36012B|36013B|36015B|36018B|36019B|36020B|36021C|37006B|37013B|37014B|37015B|37016B|37030B|37046B)$");
        //public static Regex HypofractionatedWholeBreastDetail = new Regex("^((33090|3600[1|2|4|5]|3601[1-3|5|8|9]|3602[0|1]|37006|3701[3-6]|37030|37046)[a-z|A-Z])$");

        #endregion 包裹計價

        #region 醫令分類
        //^(0[6-9][0-9][0-9][1-9]|0[7-9][0-9][0-9]0|10[0-7][0-9][0-9]|108[0-1][0-9])([a-z|A-Z])$
        // '06001C' and '10819C'
        /// <summary>
        /// 檢驗醫令
        /// </summary>
        public static Regex Inspect = new Regex("^(0[6-9][0-9][0-9][1-9]|0[7-9][0-9][0-9]0|10[0-7][0-9][0-9]|108[0-1][0-9])([a-z|A-Z])$");

        #endregion 醫令分類


        #region 申報 不計價醫令
        /// <summary>
        /// 居家照護案件 A1,A2,A6,A7,A5
        /// 不改為不計價的醫令，其餘皆改不計價
        /// 健保碼為 CKF03S2100WN, CRT02C0060PX, CRT02U0030PX, CFD02ST000EF, CKF0300142R4, CRT02C0080MA, CFD022020NFM, NAN020031NBD, CKF030513NCL, CRT02C0060UW, CRT02U0025WN,  CRT02U0062UW 醫令類別屬於3
        /// </summary>
        public static string patternNoPriceHomeCarePublic = "^(CKF03S2100WN|CRT02C0060PX|CRT02U0030PX|CFD02ST000EF|CKF0300142R4|CRT02C0080MA|CFD022020NFM|NAN020031NBD|CKF030513NCL|CRT02C0060UW|CRT02U0025WN|CRT02U0062UW)$";

        /// <summary>
        /// 居家照護案件 A1,A6,A7
        /// 不改為不計價的醫令，其餘皆改不計價
        /// 健保碼為'05301C', '05302C', '05303C', '05304C', '05305C', '05306C', '05307C', '05308C', '05309C', '05310C', '05321C', '05322C','05328C','05330C','05332C','05334C','05342C','05344C','05346C,'05348C','05350C','05352C','05354C','05356C','05358C','05360C','P5407C'醫令類別屬於2
        /// </summary>
        public static string patternNoPriceHomeCareA1A6A7 = "^(0530[1-9]|0532[1|2|8]|0533[0|2|4]|053[4|5][2|4|6|8]|053[1|5|6]0|P5407)([a-z|A-Z])$";

        /// <summary>
        /// 居家照護案件 A2
        /// 不改為不計價的醫令，其餘皆改不計價
        /// 健保碼為'05401C', '05402C', '05403C', '05404C', '05405C', '05406C'醫令類別屬於2
        /// </summary>
        public static string patternNoPriceHomeCareA2 = "^(0540[1-6])([a-z|A-Z])$";

        /// <summary>
        /// 居家照護案件 A5
        /// 不改為不計價的醫令，其餘皆改不計價
        /// 健保碼為'05311C', '05312C', '05313C', '05314C', '05315C', '05316C','05323C','05324C','05325C', '05326C','05327C', '05336C','05337C','05338C','05339C','05340C','05341C','05362C','05364C','05366C','05368C','05370C','05372C','05374C','P5405C'醫令類別屬於2
        /// </summary>
        public static string patternNoPriceHomeCareA5 = "^(0531[1-6]|0532[3-7]|0533[6-9]|0534[0|1]|0536[2|46|8]|0537[0|2|4]|P5405)([a-z|A-Z])$";

        /// <summary>
        /// 論病歷計酬案件 C1
        /// 健保碼不為97開頭，醫令類別屬於1、2、3，全改為不計價，其餘類別不變
        /// </summary>
        public static Regex NoPriceC1 = new Regex("^97");

        /// <summary>
        /// 行政協助流感疫苗及兒童常規疫苗接種案件 D2
        /// 健保碼為''A2051C','A2052C','A2001C','A3001C',' E5003C',' E5004C ',' E5002C',' E5005C'，醫令類別屬於2，
        /// 健保碼為' NCS01A2003ZZ，醫令類別屬於3，
        /// 其餘醫令皆為不計價，醫令類別屬於4
        /// </summary>
        public static Regex NoPriceD2 = new Regex(patternCovidINSRCode + "|" + "^(A205[1|2]|A[2|3]001)([a-z|A-Z])$|^(NCS01A2003ZZ)$");
        #endregion 申報 不計價醫令

    }
}
