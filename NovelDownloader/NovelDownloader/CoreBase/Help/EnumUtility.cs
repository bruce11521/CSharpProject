using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NovelDownloader.CoreBase.Help
{
    /// <summary>
    /// 全系統共用列舉
    /// </summary>
    public class EnumUtility
    {
        /// <summary>
        /// 檔案類型
        /// </summary>
        public enum FileType
        {
            PDF = 1,
            Excel = 2,
            Word = 3,
            PNG = 4,
            JPG = 5,
            JPEG = 6,
            EMF = 7,
        }

        /// <summary>
        /// 醫院代碼
        /// </summary>
        [Display(Name = "醫院代碼")]
        public const string HospitalID = "0501110514";

        /// <summary>
        /// 醫院名稱
        /// </summary>
        [Display(Name = "醫院名稱")]
        public const string Hospital = "三軍總醫院附設民眾診療服務處";

        /// <summary>
        /// 居家照護醫院代碼
        /// </summary>
        [Display(Name = "居家照護醫院代碼")]
        public const string HospitalHomeCareID = "7501110511";

        /// <summary>
        /// 居家照護醫院名稱
        /// </summary>
        [Display(Name = "居家照護醫院名稱")]
        public const string HospitalHomeCare = "三軍總醫院附設民眾診療服務處附設居家護理所";

        /// <summary>
        /// 取號代碼
        /// </summary>
        public enum SequenceName
        {
            [Display(Name = "急診收據取號")]
            ER_IONO = 0,

            [Display(Name = "門診收據取號")]
            OPD_IONO = 1,

            [Display(Name = "住院收據取號")]
            IPD_IONO = 2,
        }

        /// <summary>
        /// 取號重置類型
        /// </summary>
        public enum SequenceType
        {
            [Display(Name = "不循環")]
            [Description("D")]
            None = 0,

            [Display(Name = "日循環")]
            [Description("A")]
            Day = 1,

            [Display(Name = "月循環")]
            [Description("B")]
            Month = 2,

            [Display(Name = "年循環")]
            [Description("C")]
            Year = 3,
        }

        #region CODE_SRC 相關
        /// <summary>
        /// CODE_SRC 代碼表
        /// </summary>
        public enum CodeSrc
        {
            /// <summary>
            /// 就醫來源
            /// </summary>
            VISITKIND = 0,

            /// <summary>
            /// 給付類別
            /// </summary>
            GIVETYPE = 1,

            /// <summary>
            /// 保險類別
            /// </summary>
            INSUTYPE = 2,

            /// <summary>
            /// 醫療院所
            /// </summary>
            HOSPITAL = 3,

            /// <summary>
            /// 診室
            /// </summary>
            ROOM = 4,

            /// <summary>
            /// 國家類別
            /// </summary>
            NATION = 5,

            /// <summary>
            /// 洲名與國家
            /// </summary>
            COUNTRY = 6,

            /// <summary>
            /// 付費方式(即將移除)
            /// </summary>
            FEETYPE = 7,

            /// <summary>
            /// 收費品項分類
            /// </summary>
            PLANA = 8,

            /// <summary>
            /// 性別
            /// </summary>
            SexCode = 9,

            /// <summary>
            /// 病人狀態
            /// </summary>
            PatientStatus = 10,

            /// <summary>
            /// 軍警消(眷)歸屬註記
            /// </summary>
            BELONGCODE = 11,

            /// <summary>
            /// 民診處主任
            /// </summary>
            TSGNAME = 12,

            /// <summary>
            /// 診別(時段) SegTime
            /// </summary>
            TIME = 13,

            /// <summary>
            /// 身份確認
            /// </summary>
            IDENTITYCHECK = 14,

            /// <summary>
            /// 就醫類別
            /// </summary>
            DELFA05 = 15,

            /// <summary>
            /// 其他免部分負擔選項
            /// </summary>
            OTHPAY = 16,

            /// <summary>
            /// 保健服務品項註記
            /// </summary>
            ITEM = 17,

            /// <summary>
            /// 手術申請單_地點(2021/12/2.Bruce.已棄用，改用OPROOM)
            /// </summary>
            INPLACE = 18,

            /// <summary>
            /// 手術申請單_麻醉方法
            /// </summary>
            ANESTHESIA = 19,

            /// <summary>
            /// 關懷藥物清單
            /// </summary>
            NHILIST = 20,

            /// <summary>
            /// 不列印手術通知單_清單
            /// </summary>
            NOTPRINT = 21,

            /// <summary>
            /// 列印手術通知單_清單
            /// </summary>
            CHKTOSUG = 22,

            /// <summary>
            /// 申報拆案註記
            /// </summary>
            CASEDIVIDEDREMARK = 23,

            /// <summary>
            /// 手術申請單_地點
            /// </summary>
            OPROOM = 24,

            /// <summary>
            /// 健保IC卡_醫令類別對照
            /// </summary>
            ORDERKIND_MAP = 25,

            /// <summary>
            /// 申報醫令分類
            /// </summary>
            ORDERKIND = 26,

            /// <summary>
            /// ICDETAIL建檔人員清單對照
            /// </summary>
            ICDETAIL_INSERT_UID = 27,

            /// <summary>
            /// 採檢日報告子類別
            /// </summary>
            COLLECTIONDATE_CLASS = 28,

            /// <summary>
            /// 交付處方註記
            /// </summary>
            ISRXOUT = 29,

            /// <summary>
            /// 身分確認&重大傷病LOG檔
            /// </summary>
            IDENTITY_LOG = 30,

            /// <summary>
            /// 申報用檢核類別
            /// </summary>
            CLAIMCHECKKIND = 31,

            /// <summary>
            /// 院區別
            /// </summary>
            HISLOCATION = 32,

            /// <summary>
            /// 手術
            /// </summary>
            SUGRATIO = 33,

            /// <summary>
            /// 癌症副作用與治療病情變化
            /// </summary>
            SIDEEFFECT = 34,

            /// <summary>
            /// 罕見疾病清單
            /// </summary>
            RareSick = 35,

            /// <summary>
            /// 申報總額類別
            /// </summary>
            HOSPTYPE = 36,

            /// <summary>
            /// 檢驗檢查加計部分負擔清單
            /// </summary>
            CHKPAY = 37,

            /// <summary>
            /// 健保IC卡異常代碼
            /// </summary>
            ERRCODE = 38,

            /// <summary>
            /// JobSource 代碼
            /// </summary>
            JobSource = 39,

            /// <summary>
            /// 牙醫總額特殊照護計畫醫令
            /// </summary>
            DENBudgetSpecial = 40,

            /// <summary>
            /// 牙科就診掛號費優免項目
            /// </summary>
            DENVIP56 = 41,

            /// <summary>
            /// 整合式照護計畫
            /// </summary>
            IntegratedCarePlan = 42,

            /// <summary>
            /// 申報處方調劑方式
            /// </summary>
            PrescriptionNote = 43,

            /// <summary>
            /// 執行醫令是否需要證照
            /// </summary>
            Code2License = 44,

            /// <summary>
            /// 牙科總額特殊照護計畫醫師
            /// </summary>
            DENBudgetSpecDoctor = 45,
            /// <summary>
            /// 列印手術處置單
            /// </summary>
            ORDER_SCH_PRINT = 46,
            /// <summary>
            /// CDC職業別
            /// </summary>
            OCCUPATION = 47,
            /// <summary>
            /// 門診特定藥品重複用藥群組
            /// </summary>
            DUPMED = 48,
        }

        /// <summary>
        /// 性別
        /// CodeGroup = SexCode
        /// </summary>
        public enum Sex
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "不明")]
            NoSetting = -9999,

            /// <summary>
            /// 男
            /// </summary>
            [Display(Name = "男")]
            Male = 1,

            /// <summary>
            /// 女
            /// </summary>
            [Display(Name = "女")]
            Female = 2,

            /// <summary>
            /// 不明
            /// </summary>
            [Display(Name = "不明")]
            NonBinary = 3,
        }

        /// <summary>
        /// 就醫來源[Display.Name為中文, Display.Description為3字英文縮寫(3 Word), Descrption為英文首字(1 Word)]
        /// CodeGroup = VISITKIND
        /// </summary>
        public enum VISITKIND
        {
            /// <summary>
            /// 共用
            /// </summary>
            [Display(Name = "共用", Description = "PUB")]
            [Description("P")]
            Public = 0,

            /// <summary>
            /// 住院
            /// </summary>
            [Display(Name = "住院", Description = "IPD")]
            [Description("I")]
            Inpatient = 1,

            /// <summary>
            /// 門診
            /// </summary>
            [Display(Name = "門診", Description = "OPD")]
            [Description("O")]
            Outpatient = 2,

            /// <summary>
            /// 急診
            /// </summary>
            [Display(Name = "急診", Description = "ER")]
            [Description("E")]
            Emergency = 3,
        }

        /// <summary>
        /// 院區別
        /// CodeGroup = HISLOCATION
        /// </summary>
        public enum HISLOCATION
        {
            [Display(Name = "內湖")]
            [Description("1.內湖院區")]
            NeiHu = 1,

            [Display(Name = "汀州")]
            [Description("2.汀州院區")]
            TingJhou = 2,
        }

        /// <summary>
        /// 病人狀態(因為有英文字母，建議取Descrption()來使用)
        /// </summary>
        public enum PatientStatus
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("0")]
            Null = 0,
            /// <summary>
            /// 未掛號(掛號)
            /// </summary>
            [Display(Name = "未掛號")]
            [Description("1")]
            NonRegister = 1,

            /// <summary>
            /// 已掛號(掛號)
            /// </summary>
            [Display(Name = "已掛號")]
            [Description("2")]
            Register = 2,

            /// <summary>
            /// 退掛號(掛號)
            /// </summary>
            [Display(Name = "退掛號")]
            [Description("3")]
            RegiserWithdraw = 3,

            /// <summary>
            /// 報到(掛號)
            /// </summary>
            [Display(Name = "報到未看")]
            [Description("4")]
            CheckIn = 4,

            /// <summary>
            /// 待診(診間)
            /// </summary>
            [Display(Name = "待診")]
            [Description("5")]
            WaitClinic = 5,

            /// <summary>
            /// 保留(診間)
            /// </summary>
            [Display(Name = "保留")]
            [Description("6")]
            ClinicRetention = 6,

            /// <summary>
            /// 醫囑結束(診間)
            /// </summary>
            [Display(Name = "醫囑結束")]
            [Description("7")]
            DoctorOrderFinish = 7,

            /// <summary>
            /// 留觀(診間)
            /// </summary>
            [Display(Name = "留觀")]
            [Description("8")]
            Observation = 8,

            /// <summary>
            /// 待床(診間)
            /// </summary>
            [Display(Name = "待床")]
            [Description("9")]
            WaitingForBed = 9,

            /// <summary>
            /// 未結案(護理)
            /// </summary>
            [Display(Name = "未結案")]
            [Description("10")]
            NotFinish = 10,

            /// <summary>
            /// 記錄中(護理)
            /// </summary>
            [Display(Name = "記錄中")]
            [Description("11")]
            NurseRecording = 11,

            /// <summary>
            /// 已結案(護理)
            /// </summary>
            [Display(Name = "已結案")]
            [Description("12")]
            NurseFinished = 12,

            /// <summary>
            /// 未批價(批價)
            /// </summary>
            [Display(Name = "未批價")]
            [Description("13")]
            UnPayment = 13,

            /// <summary>
            /// 已批價(批價)
            /// </summary>
            [Display(Name = "已批價")]
            [Description("14")]
            Paid = 14,

            /// <summary>
            /// 欠款待收/修帳待還(批價)
            /// </summary>
            [Display(Name = "欠款待收/修帳待還")]
            [Description("15")]
            Owe = 15,

            /// <summary>
            /// 呆帳(批價)
            /// </summary>
            [Display(Name = "呆帳")]
            [Description("16")]
            BadDebt = 16,

            /// <summary>
            /// 轉科(診間)
            /// </summary>
            [Display(Name = "轉科")]
            [Description("17")]
            DeptTransfer = 17,

            /// <summary>
            /// 診療中(診間)
            /// </summary>
            [Display(Name = "診療中")]
            [Description("18")]
            SeeingADoctor = 18,

            /// <summary>
            /// 預約掛號(掛號)
            /// </summary>
            [Display(Name = "預約掛號")]
            [Description("19")]
            RegiserRetention = 19,

            /// <summary>
            /// 過號
            /// </summary>
            [Display(Name = "過號")]
            [Description("23")]
            RegiserOverNumber = 23,

            /// <summary>
            /// 牙科特殊治療追蹤
            /// </summary>
            [Display(Name = "牙科特殊治療追蹤")]
            [Description("28")]
            DENVIP56 = 28,

            /// <summary>
            /// 補批價
            /// </summary>
            [Display(Name = "補批價")]
            [Description("29")]
            ComplementPay = 29,

            /// <summary>
            /// 已合併帳務
            /// </summary>
            [Display(Name = "已合併帳務")]
            [Description("30")]
            CombinedPay = 30,

            /// <summary>
            /// 診間退掛
            /// </summary>
            [Display(Name = "診間退掛")]
            [Description("32")]
            ReturnRegister = 32,

            /// <summary>
            /// NOCHARGE 回診看報告
            /// </summary>
            [Display(Name = "回診看報告")]
            [Description("33")]
            NoChargeFollowupReport = 33,

            /// <summary>
            /// NOCHARGE 零元帳單
            /// </summary>
            [Display(Name = "零元帳單")]
            [Description("34")]
            NoChargeZeroPay = 34,

            /// <summary>
            /// 補批價(無金額異動)
            /// </summary>
            [Display(Name = "諮詢門診(不產掛號、診察費)")]
            [Description("38")]
            NoChargeConsultation = 38,

            /// <summary>
            /// 護眼護照
            /// </summary>
            [Display(Name = "護眼護照")]
            [Description("39")]
            NoChargeOPH = 39,


            /// <summary>
            /// 補批價(有金額異動)
            /// </summary>
            [Display(Name = "補批價(有金額異動)")]
            [Description("35")]
            ComplementPay_CashReModify = 35,

            /// <summary>
            /// 補批價(無金額異動)
            /// </summary>
            [Display(Name = "補批價(無金額異動)")]
            [Description("36")]
            ComplementPay_CashNoModify = 36,

            /// <summary>
            /// 同療掛號 C
            /// </summary>
            [Display(Name = "同療掛號")]
            [Description("C")]
            TherapyRegister = 67,

            /// <summary>
            /// 回診看報告 E
            /// </summary>
            [Display(Name = "回診看報告")]
            [Description("E")]
            FollowupReport = 69,

            /// <summary>
            /// 慢箋櫃檯掛號 F
            /// </summary>
            [Display(Name = "慢箋櫃檯掛號")]
            [Description("F")]
            SlowSickRegister = 70,

            /// <summary>
            /// 慢箋調劑完成 G
            /// </summary>
            [Display(Name = "慢箋調劑完成")]
            [Description("G")]
            SlowSickMedFinish = 71,

            /// <summary>
            /// 慢箋預約掛號 S
            /// </summary>
            [Display(Name = "慢箋預約掛號")]
            [Description("S")]
            SlowSickPreRegister = 83,
        }
        #endregion CODE_SRC 相關

        #region PUBCode
        /// <summary>
        /// PubCodeType
        /// </summary>
        public enum PubCodeType
        {
            /// <summary>
            /// 預設初始數值
            /// </summary>
            [Display(Name = "預設初始數值")]
            [Description("")]
            _NULL_,
            /// <summary>
            /// 檢核警示代碼
            /// </summary>
            [Display(Name = "檢核警示代碼")]
            [Description("")]
            BOD_SysLockType,
        }

        #endregion

        #region System_Param 相關
        /// <summary>
        /// 系統參數
        /// </summary>
        public enum SystemParam
        {
            [Display(Name = "掛號限制")]
            RegisterLimit = 1,

            [Display(Name = "部門管理者")]
            PERSONNEL_MANAGER = 2,

            [Display(Name = "診察費代碼")]
            DiagnoseFee = 3,

            [Display(Name = "付費方式")]
            FEETYPE = 4,

            [Display(Name = "ICD10處置診斷類別")]
            ICD10_DIAGKIND = 5,
            /// <summary>
            /// 套餐狀態
            /// </summary>
            [Display(Name = "套餐狀態")]
            PackageOrder = 6,

            [Display(Name = "申報復健治療項目")]
            ClaimRehReport = 7,

            /// <summary>
            /// 程式版號檢核
            /// </summary>
            [Display(Name = "程式版號檢核")]
            [Description("程式版號檢核")]
            VersionCheck = 8,

            /// <summary>
            /// 除錯模式檢核
            /// </summary>
            [Display(Name = "除錯模式檢核")]
            [Description("除錯模式檢核")]
            DebugModeCheck = 9,

            /// <summary>
            /// 測試方法啟用狀態
            /// </summary>
            [Display(Name = "測試方法啟用狀態")]
            [Description("測試方法啟用狀態")]
            TestFunctionStatus = 10,

            /// <summary>
            /// 程式讀取相關資料庫啟用狀態
            /// </summary>
            [Display(Name = "程式讀取相關資料庫啟用狀態")]
            [Description("程式讀取相關資料庫啟用狀態")]
            DBConnectStatus = 11,

            /// <summary>
            /// 線上版本號檢核
            /// </summary>
            [Display(Name = "線上版本號檢核")]
            [Description("線上版本號檢核")]
            AssemblyVersion = 12,

            /// <summary>
            /// 驗證密碼
            /// </summary>
            [Display(Name = "驗證密碼")]
            [Description("驗證密碼")]
            Access_Password = 13,

            /// <summary>
            /// 程序檢核_線上鎖控
            /// </summary>
            [Display(Name = "程序檢核_線上鎖控")]
            [Description("程序檢核_線上鎖控")]
            Program_Check = 14,
            /// <summary>
            /// 申報系統
            /// </summary>
            [Display(Name = "申報系統")]
            ClaimSystem = 15,
            /// <summary>
            /// 批價系統
            /// </summary>
            [Display(Name = "批價系統")]
            CashierSystem = 16,
            /// <summary>
            /// 身分別判斷服務
            /// </summary>
            [Display(Name = "身分別判斷服務")]
            IdentityTypeService = 17,
            /// <summary>
            /// 健保署VPN亂數簽章
            /// </summary>
            [Display(Name = "健保署VPN亂數簽章")] 
            NHIVPN_SignX = 18,

            [Display(Name = "軍階呈現GRANK")]
            ShowDifferent = 19,


            [Display(Name = "掛特殊號碼之權限")]
            CanRegSpOrderno = 20,


            [Display(Name = "醫師排班系統")]
            DSCSystem = 21,


            [Display(Name = "門診診間除錯模式")]
            OPD_DEBUG_MODE = 22,


            [Display(Name = "急診診間除錯模式")]
            ER_DEBUG_MODE = 23,


            [Display(Name = "門診版號檢核")]
            OPDVersion = 24,

            [Display(Name = "急診版號檢核")]
            ERVersion = 25,

            [Display(Name = "健保署讀卡機軟體版本號")]
            CsfsimVersion = 26,

            [Display(Name = "門診全處方退費角色限制科別")]
            OPD_Refund_RoleDeptOnly = 27,

            [Display(Name = "手術材料加成浮動比率")]
            SUGRATIO = 28,
            /// <summary>
            /// 健保署健保卡資料上傳
            /// </summary>
            [Display(Name = "健保署健保卡資料上傳")] 
            NHIICCardDataUpload = 29,
            /// <summary>
            /// 診間科套餐顯示設定
            /// </summary>
            [Display(Name = "診間科套餐顯示設定")]
            PackageOrderDisplayDept = 30,
        }

        /// <summary>
        /// 系統參數 ID
        /// </summary>
        public enum SystemParam_Paramid
        {
            /// <summary>
            /// 全部撈取
            /// </summary>
            [Display(Name = "全部撈取")]
            [Description("全部撈取")]
            _ALL_ = 0,
            /// <summary>
            /// 健保卡1.0上傳
            /// </summary>
            [Display(Name = "健保卡1.0上傳")]
            [Description("健保卡1.0上傳")]
            NHI10_XML_UPLOAD,
            /// <summary>
            /// 健保卡2.0上傳
            /// </summary>
            [Display(Name = "健保卡2.0上傳")]
            [Description("健保卡2.0上傳")]
            NHI20_XML_UPLOAD,
            /// <summary>
            /// 線上版本號檢核
            /// </summary>
            [Display(Name = "線上版本號檢核")]
            [Description("線上版本號檢核")]
            ASSEMBLY_FILE_VERSION,
            /// <summary>
            /// 健保署讀卡機軟體版本號
            /// </summary>
            [Display(Name = "健保署讀卡機軟體版本號")]
            [Description("健保署讀卡機軟體版本號")]
            CsfsimVersion,
            /// <summary>
            /// 健保卡上傳程式
            /// </summary>
            [Display(Name = "健保卡上傳程式")]
            [Description("健保卡上傳程式")]
            NHIICardUploadForm,
            /// <summary>
            /// OPD診間登入Master
            /// </summary>
            [Display(Name = "OPD診間登入Master")]
            [Description("OPD診間登入Master")]
            OPD_Dashboard_Master,

            #region Program_Check

            /// <summary>
            /// 門診身分確認IDNO
            /// </summary>
            [Display(Name = "門診身分確認IDNO")]
            [Description("門診身分確認IDNO")]
            OPD_IdentityVerificationForm_IDNO,
            /// <summary>
            /// 門診身分確認存檔並寫卡
            /// </summary>
            [Display(Name = "門診身分確認存檔並寫卡")]
            [Description("門診身分確認存檔並寫卡")]
            OPD_IdentityVerificationForm_SaveDataWithICCard,
            /// <summary>
            /// 門診身分確認存檔不寫卡
            /// </summary>
            [Display(Name = "門診身分確認存檔不寫卡")]
            [Description("門診身分確認存檔不寫卡")]
            OPD_IdentityVerificationForm_SaveDataWithoutICCard,
            /// <summary>
            /// 門診身分確認轉診病人回覆轉診單
            /// </summary>
            [Display(Name = "門診身分確認轉診病人回覆轉診單")]
            [Description("門診身分確認轉診病人回覆轉診單")]
            OPD_IdentityVerificationForm_ReferralRecordFirstFeedBackReplay,
            /// <summary>
            /// 門診病人基本資料菸酒檳榔史
            /// </summary>
            [Display(Name = "門診病人基本資料菸酒檳榔史")]
            [Description("門診病人基本資料菸酒檳榔史")]
            OPD_PatientInfoForm_CigaretteLiquorBetelNutHistory,
            /// <summary>
            /// 門診儀錶板詢問是否要讀取健保卡
            /// </summary>
            [Display(Name = "門診儀錶板詢問是否要讀取健保卡")]
            [Description("門診儀錶板詢問是否要讀取健保卡")]
            OPD_Dashboard_IsCheckNHIHcCard,
            /// <summary>
            /// 門診身分確認健保身分別下拉清單
            /// </summary>
            [Display(Name = "門診身分確認健保身分別下拉清單")]
            [Description("門診身分確認健保身分別下拉清單")]
            OPD_IdentityVerificationForm_NHIIdentityDropDownListCheck,
            /// <summary>
            /// 門診診間開立專用限制
            /// </summary>
            [Display(Name = "門診診間開立專用限制")]
            [Description("門診診間開立專用限制")]
            OPD_ClinicRoom_AddBatchRestrictedOrder,
            /// <summary>
            /// 門診診間是否使用新的事審判斷邏輯
            /// </summary>
            [Display(Name = "門診診間是否使用新的事審判斷邏輯")]
            [Description("門診診間是否使用新的事審判斷邏輯")]
            OPD_ClinicRoom_AddBatch_NewProjectItem,
            /// <summary>
            /// 門診儀錶板病患診療中登入診間檢核
            /// </summary>
            [Display(Name = "門診儀錶板病患診療中登入診間檢核")]
            [Description("門診儀錶板病患診療中登入診間檢核")]
            OPD_Dashboard_CheckInWhenPatientDiagnosis,
            /// <summary>
            /// 門診儀錶板檢核醫師是否出國支援證照
            /// </summary>
            [Display(Name = "門診儀錶板檢核醫師是否出國支援證照")]
            [Description("門診儀錶板檢核醫師是否出國支援證照")]
            OPD_Dashboard_CheckInDoctorGoingAbordSupportLicense,
            /// <summary>
            /// 門診儀錶板是否呼叫醫師是否出國支援證照API
            /// </summary>
            [Display(Name = "門診儀錶板是否呼叫醫師是否出國支援證照API")]
            [Description("門診儀錶板是否呼叫醫師是否出國支援證照API")]
            OPD_Dashboard_CheckInDoctorGoingAbordSupportLicense_EnabledAPICallFunc,
            /// <summary>
            /// 門診身分確認是否啟用已批價狀態鎖定身分別選單
            /// </summary>
            [Display(Name = "門診身分確認是否啟用已批價狀態鎖定身分別選單")]
            [Description("門診身分確認是否啟用已批價狀態鎖定身分別選單")]
            OPD_IdentityVerificationForm_IsCashierFinishDisableList,
            /// <summary>
            /// 門診結案病理檢體標籤列印
            /// </summary>
            [Display(Name = "門診結案病理檢體標籤列印")]
            [Description("門診結案病理檢體標籤列印")]
            OPD_ClinicRoom_Finish_PrintPathology,
            /// <summary>
            /// 門診檢核該次看診是否可在HIS2編輯
            /// </summary>
            [Display(Name = "門診檢核該次看診是否可在HIS2編輯")]
            [Description("門診檢核該次看診是否可在HIS2編輯")]
            OPD_ALL_CheckPatientIsAllowEditOnHIS2,
            /// <summary>
            /// 門診身分確認存檔_健保身份時檢核健保卡是否存在
            /// </summary>
            [Display(Name = "門診身分確認存檔_健保身份時檢核健保卡是否存在")]
            [Description("門診身分確認存檔_健保身份時檢核健保卡是否存在")]
            OPD_IdentityVerificationForm_SaveDataNHITypeCode_IsNHIICCardExist,
            /// <summary>
            /// 門診結案FINAL 如果AfterDRStatus為Null啟動補救措施
            /// </summary>
            [Display(Name = "門診結案FINAL 如果AfterDRStatus為Null啟動補救措施")]
            [Description("門診結案FINAL 如果AfterDRStatus為Null啟動補救措施")]
            OPD_ClinicRoom_Finish_FinalAfterDrstatusFailureSafe,
            /// <summary>
            /// 門診診間醫令寫入啟用批次模式
            /// </summary>
            [Display(Name = "門診診間醫令寫入啟用批次模式")]
            [Description("門診診間醫令寫入啟用批次模式")]
            OPD_ClinicRoom_AddBatchOrderEnabled,
            /// <summary>
            /// 門診診間結案是否紀錄健保卡取256N1狀態_統計用
            /// </summary>
            [Display(Name = "門診診間結案是否紀錄健保卡取256N1狀態_統計用")]
            [Description("門診診間結案是否紀錄健保卡取256N1狀態_統計用")]
            OPD_ClinicRoom_Finish_RecordNHICardReaderState,
            /// <summary>
            /// 門診診間身分確認_自動檢核程序依照EID跳過檢核(PARAMVARCHAR)
            /// </summary>
            [Display(Name = "門診診間身分確認_自動檢核程序依照EID跳過檢核(PARAMVARCHAR)")]
            [Description("門診診間身分確認_自動檢核程序依照EID跳過檢核(PARAMVARCHAR)")]
            OPD_IdentityVerificationForm_AutoCorrectedOverrideByEID,
            /// <summary>
            /// 門診生命徵象-IOT
            /// </summary>
            [Display(Name = "門診生命徵象-IOT")]
            [Description("門診生命徵象-IOT")]
            OPD_PatientInfoForm_IOTVitalsign,
            /// <summary>
            /// 門診儀錶板醫師報到檢核當下時間是位於班別時間內(或提前一小時)
            /// </summary>
            [Display(Name = "醫師報到檢核時間")]
            [Description("門診儀錶板醫師報到檢核當下時間是位於班別時間內(或提前一小時)")]
            OPD_Dashboard_DoctorProcessCheckInValidDateTime,
            /// <summary>
            /// 身分確認_NHI檢核鎖控
            /// </summary>
            [Display(Name = "NHI檢核鎖控")]
            [Description("身分確認_檢核鎖控")]
            OPD_IdentityVerificationForm_NHICheckIsEnabled,
            /// <summary>
            /// 藥物重複檢核是否開啟檢核
            /// </summary>
            [Display(Name = "慢箋、藥物重複檢核是否開啟檢核")]
            [Description("慢箋、藥物重複檢核是否開啟檢核")]
            OPD_EnabledSlowSickDuplicateDragChargeCheckForm,
            /// <summary>
            /// 藥物重複檢核是否啟用健保署API
            /// </summary>
            [Display(Name = "藥物重複檢核是否啟用健保署API")]
            [Description("藥物重複檢核是否啟用健保署API")]
            OPD_DuplicateDragEnabledNHIWebAPI,
            /// <summary>
            /// 身分確認 20230701 新制部分負擔邏輯
            /// </summary>
            [Display(Name = "身分確認 20230701 新制部分負擔邏輯")]
            [Description("身分確認 20230701 新制部分負擔邏輯")]
            OPD_IdentityVerificationForm_20230701NewPayTypeLogical,
            /// <summary>
            /// 身分確認 紙本開立重大傷病清單使用精神科以外之重大傷病ICD
            /// </summary>
            [Display(Name = "身分確認 紙本開立重大傷病清單使用精神科以外之重大傷病ICD")]
            [Description("身分確認 紙本開立重大傷病清單使用精神科以外之重大傷病ICD")]
            OPD_IdentityVerificationForm_HeavysickPaperOnlyUseStartWith_F_ICD,
            /// <summary>
            /// 健保VPN ICCard_DllLibrary底層是否關閉健保主控台讀寫卡功能 
            /// </summary>
            [Display(Name = "健保VPN ICCard_DllLibrary底層是否關閉健保主控台讀寫卡功能 ")]
            [Description("健保VPN ICCard_DllLibrary底層是否關閉健保主控台讀寫卡功能 ")]
            NHIVPN_IsDisabledNHI_Csfsim,

            /// <summary>
            /// 身分確認 檢核是否正在住院中
            /// </summary>
            [Display(Name = "身分確認 檢核是否正在住院中")]
            [Description("身分確認 檢核是否正在住院中")]
            OPD_IdentityVerificationForm_EnabledNHIICCardIPDRecordCheck,

            /// <summary>
            /// 身分確認 進入時若讀取到重大傷病是否顯示提示視窗
            /// </summary>
            [Display(Name = "身分確認 進入時若讀取到重大傷病是否顯示提示視窗")]
            [Description("身分確認 進入時若讀取到重大傷病是否顯示提示視窗")]
            OPD_IdentityVerificationForm_WhenReadICHeavysickAlertForm,

            /// <summary>
            /// 身分確認 檢核卡片與福保部分負擔與優免身分是否相同
            /// </summary>
            [Display(Name = "身分確認 檢核卡片與福保部分負擔與優免身分是否相同")]
            [Description("身分確認 檢核卡片與福保部分負擔與優免身分是否相同")]
            OPD_IdentityVerificationForm_VerifyNHICardAndLowIncomeOrRongminOrRong,

            /// <summary>
            /// 慢箋重複藥物藥費核扣天數設定
            /// </summary>
            [Display(Name = "慢箋重複藥物藥費核扣天數設定")]
            [Description("慢箋重複藥物藥費核扣天數設定")]
            OPD_ClinicRoom_SlowSickDuplicateDragChargeCheckResult,

            /// <summary>
            /// 門診儀錶板_剔退程式
            /// </summary>
            [Display(Name = "門診儀錶板_剔退程式")]
            [Description("門診儀錶板_剔退程式")]
            OPD_Dashboard_HISEDITFORM,

            /// <summary>
            /// 門診診間_時間檢核
            /// </summary>
            [Display(Name = "門診診間_時間檢核")]
            [Description("門診診間_時間檢核")]
            OPD_ClinicRoom_TaskTimeCheck,

            /// <summary>
            /// 身分確認 IPD CVA 資料抓取開關
            /// </summary>
            [Display(Name = "身分確認 IPD CVA 資料抓取開關")]
            [Description("身分確認 IPD CVA 資料抓取開關")]
            OPD_IdentityVerificationForm_CVA_IPDData,

            /// <summary>
            /// 身分確認關閉時候 檢核是否有填寫轉診單
            /// </summary>
            [Display(Name = "身分確認關閉時 檢核是否有填寫轉診單")]
            [Description("身分確認關閉時 檢核是否有填寫轉診單")]
            OPD_IdentityVerificationForm_FormClosing_ReferralRecordReplayCheck,
            
            /// <summary>
            /// 門診診間結案時，是否全部醫令都掃過
            /// </summary>
            [Display(Name = "門診診間結案時，是否全部醫令都掃過")]
            [Description("門診診間結案時，是否全部醫令都掃過")]
            OPD_ClinicRoom_Finish_AlwaysScan,
            
            /// <summary>
            /// 門診診間藥品是否可作為慢籤服用
            /// </summary>
            [Display(Name = "門診診間藥品是否可作為慢籤服用")]
            [Description("門診診間藥品是否可作為慢籤服用")]
            OPD_ClinicRoom_SlowSickMed,

            /// <summary>
            /// 身分確認 執行時間LOG
            /// </summary>
            [Display(Name = "身分確認 執行時間LOG")]
            [Description("身分確認 執行時間LOG")]
            OPD_IdentityVerificationForm_ExecuteLog,

            /// <summary>
            /// 門診診間 除錯模式 授權者清單
            /// </summary>
            [Display(Name = "門診診間 除錯模式 授權者清單")]
            [Description("門診診間 除錯模式 授權者清單")]
            OPD_Dashboard_AuthUserList,

            /// <summary>
            /// 門診診間 身分確認 不扣卡就醫序號檢核
            /// </summary>
            [Display(Name = "門診診間 身分確認 不扣卡就醫序號檢核")]
            [Description("門診診間 身分確認 不扣卡就醫序號檢核")]
            OPD_IdentityVerificationForm_CheckUncCountTreatItem,
            /// <summary>
            /// 健保卡資料上傳授權者AD清單
            /// </summary>
            [Display(Name = "健保卡資料上傳授權者AD清單")]
            [Description("健保卡資料上傳授權者AD清單")]
            NHIIC_Xml_Upload_AuthorizeUserList,
            /// <summary>
            /// 門診診間醫師報到查詢使用新版本
            /// </summary>
            [Display(Name = "門診診間醫師報到查詢使用新版本")]
            [Description("門診診間醫師報到查詢使用新版本")]
            OPD_DoctorProcessReportDutyNewVersion,

            #endregion Program_Check

            #region Access_Password
            /// <summary>
            /// 公用診間_開啟剔退程式密碼檢核
            /// </summary>
            [Display(Name = "公用診間_開啟剔退程式密碼檢核")]
            [Description("公用診間_開啟剔退程式密碼檢核")]
            PublicClinicRoom_HISEDITFORM,
            /// <summary>
            /// 公用診間_剔退程式_全部剔退密碼檢核
            /// </summary>
            [Display(Name = "公用診間_剔退程式_全部剔退密碼檢核")]
            [Description("公用診間_剔退程式_全部剔退密碼檢核")]
            PublicClinicRoom_HISEDITFORM_AllCheckOut,

            /// <summary>
            /// 公用診間_SystemParam公用程式
            /// </summary>
            [Display(Name = "公用診間_SystemParam公用程式")]
            [Description("公用診間_SystemParam公用程式")]
            PublicClinicRoom_SystemParamUtilityForm,

            /// <summary>
            /// 健保卡資料上傳 MEMO異動密碼
            /// </summary>
            [Display(Name = "健保卡資料上傳 MEMO異動密碼")]
            [Description("健保卡資料上傳 MEMO異動密碼")]
            NHIUploadForm_MemoUpdate,

            /// <summary>
            /// 居家照護 設定特定拋轉日期
            /// </summary>
            [Display(Name = "居家照護 設定特定拋轉日期")]
            [Description("居家照護 設定特定拋轉日期")] 
            HomeCareMainForm_SetTransferDate,
            /// <summary>
            /// 門診結案 資訊視窗 顯示CloseButton Password,需搭配USERID
            /// </summary>
            [Display(Name = "門診結案 資訊視窗 顯示CloseButton Password")]
            [Description("門診結案 資訊視窗 顯示CloseButton Password")]
            AccessPassword_OPDFinishInfoFormShowCloseButtonPassword,
            #endregion Access_Password

            #region HomeCare
            /// <summary>
            /// 居家照護 下載 執行SQL
            /// </summary>
            [Display(Name = "居家照護 下載 執行SQL")]
            [Description("居家照護 下載 執行SQL")]
            HomeCare_Download_ExecuteSQL,
            /// <summary>
            /// 居家照護 上傳 執行SQL
            /// </summary>
            [Display(Name = "居家照護 上傳 執行SQL")]
            [Description("居家照護 上傳 執行SQL")]
            HomeCare_Upload_ExecuteSQL,

            #endregion

            /// <summary>
            /// 管理者功能
            /// </summary>
            [Display(Name = "管理者功能")]
            ManagerFunction,

            /// <summary>
            /// 編輯者功能
            /// </summary>
            [Display(Name = "編輯者功能")]
            EditFunction,

            /// <summary>
            /// 使用者功能
            /// </summary>
            [Display(Name = "使用者功能")]

            UserFunction,

            #region 批價使用
            /// <summary>
            /// 門診_身分別必須為非健保身分之科別代碼
            /// </summary>
            [Display(Name = "門診_身分別必須為非健保身分之科別代碼")]
            OPD_SelfPayDept,

            /// <summary>
            /// 部分負擔順序清單
            /// </summary>
            [Display(Name = "部分負擔順序清單")]
            PayTypePriorityList,
            /// <summary>
            /// 部分負擔不異動清單(REGEX)
            /// </summary>
            [Display(Name = "部分負擔不異動清單(REGEX)")]
            NoChangePayTypeList,
            /// <summary>
            /// 免收費部分負擔（判斷是否轉換榮民、福保使用）
            /// </summary>
            [Display(Name = "免收費部分負擔（判斷是否轉換榮民、福保使用）")]
            NoChargePayType,

            #endregion 批價使用

            #region NHIVPN_SignX 健保署VPN亂數簽章
            /// <summary>
            /// 取得就醫識別碼(類似 API 1.56 hisGetTreatNumICCard ) [簽章有效期8小時] 15 (搭配 3.安全模組卡 簽章)
            /// </summary>
            [Display(Name = "取得就醫識別碼(類似 API 1.56 hisGetTreatNumICCard ) [簽章有效期8小時] 15 (搭配 3.安全模組卡 簽章)")]
            Get_hisGetTreatNumNoICCard,
            /// <summary>
            /// 取得就醫識別碼(類似 API 1.54 hisGetTreatNumNoICCard ) [簽章有效期8小時] 17 (搭配 3.安全模組卡 簽章)
            /// </summary>
            [Display(Name = "取得就醫識別碼(類似 API 1.54 hisGetTreatNumNoICCard ) [簽章有效期8小時] 17 (搭配 3.安全模組卡 簽章)")]
            Get_hisGetTreatNumNoICCard2,
            /// <summary>
            /// 取得就醫識別碼 (Web API) 11 (搭配 3.安全模組卡 卡別簽章)
            /// </summary>
            [Display(Name = "取得就醫識別碼 (Web API) 11 (搭配 3.安全模組卡 卡別簽章)")]
            Get_MEDIDENTIFIER_WebAPI,
            /// <summary>
            /// 取得就醫識別碼 (Web API)之 健保測試卡使用 12 (搭配 3.安全模組卡 卡別簽章)
            /// </summary>
            [Display(Name = "取得就醫識別碼 (Web API)之 健保測試卡使用 12 (搭配 3.安全模組卡 卡別簽章)")]
            Get_TestMEDIDENTIFIER_WebAPI,
            #endregion

            #region NHIICCardDataUpload 健保署健保卡資料上傳
            /// <summary>
            /// 健保卡資料上傳健保署1.0 通知者
            /// </summary>
            [Display(Name = "健保卡資料上傳健保署1.0 通知者")]
            NHI10_Notifier,
            #endregion

            #region PackageOrderDisplayDept 診間科套餐顯示設定
            /// <summary>
            /// 門診診間科套餐顯示設定
            /// </summary>
            [Display(Name = "門診診間科套餐顯示設定 ")]
            PackageOrderDept_OPD,

            #endregion
        }
        #endregion System_Param 相關
        /// <summary>
        /// ICD.DIAGKIND 診斷碼類別
        /// </summary>
        public enum DIAGKIND
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            NULL = 0,
            /// <summary>
            /// 診斷碼 1
            /// </summary>
            [Display(Name = "診斷碼")]
            DIAG = 1,
            /// <summary>
            /// 手術碼 2
            /// </summary>
            [Display(Name = "手術碼")]
            SUG = 2,
            /// <summary>
            /// 處置碼 3
            /// </summary>
            [Display(Name = "處置碼")]
            PRO = 3,
        }

        /// <summary>
        /// 時段
        /// </summary>
        public enum SegTime
        {
            /// <summary>
            /// 上午診
            /// </summary>
            [Display(Name = "上午診")]
            [Description("2")]
            morning = 2,

            /// <summary>
            /// 下午診
            /// </summary>
            [Display(Name = "下午診")]
            [Description("3")]
            afternoon = 3,

            /// <summary>
            /// 晚診
            /// </summary>
            [Display(Name = "晚診")]
            [Description("4")]
            night = 4,

            ///// <summary>
            ///// 中午診
            ///// </summary>
            //[Display(Name = "中午診")]
            //[Description("5")]
            //noon = 5,

            ///// <summary>
            ///// 黃昏診
            ///// </summary>
            //[Display(Name = "黃昏診")]
            //[Description("6")]
            //dusk = 6,

            /// <summary>
            /// A班
            /// </summary>
            [Display(Name = "A班")]
            [Description("A")]
            A = 999,

            /// <summary>
            /// B班
            /// </summary>
            [Display(Name = "B班")]
            [Description("B")]
            B = 998,

            /// <summary>
            /// C班
            /// </summary>
            [Display(Name = "C班")]
            [Description("C")]
            C = 997,
        }

        /// <summary>
        /// 是否作廢
        /// </summary>
        public enum CancelFlag
        {
            /// <summary>
            /// 未作廢
            /// </summary>
            N = 0,

            /// <summary>
            /// 作廢
            /// </summary>
            [Display(Name = "作廢")]
            Y = 1,
        }

        /// <summary>
        /// 是否註記
        /// </summary>
        public enum YesNoFlag
        {
            /// <summary>
            /// 否
            /// </summary>
            [Display(Name = "No", Description = "否")]
            N = 0,

            /// <summary>
            /// 是
            /// </summary>
            [Display(Name = "Yes", Description = "是")]
            Y = 1,
        }

        /// <summary>
        /// 醫令類別 適用於(MAINGroup 及 HOSPCHARGEID1)
        /// 目前MainGroup以.Tostring()取得對應，HOSPCHARGEID1以.ToNumberStringOrderCode()取得對應
        /// </summary>
        public enum OrderCodeType
        {
            /// <summary>
            /// 診察費
            /// </summary>
            [Display(Name = "診察費")]
            [Description("Diagnose Fee")]
            DIA = 01,

            /// <summary>
            /// 病房費
            /// </summary>
            [Display(Name = "病房費")]
            [Description("Ward Fee")]
            ROM = 02,

            /// <summary>
            /// 伙食費
            /// </summary>
            [Display(Name = "伙食費")]
            [Description("Diet Fee")]
            FOD = 03,

            /// <summary>
            /// 檢查費
            /// </summary>
            [Display(Name = "檢查費")]
            [Description("Examination Fee")]
            CHK = 04,

            /// <summary>
            /// 放射線診療費
            /// </summary>
            [Display(Name = "放射線診療費")]
            [Description("X-Ray Fee")]
            RAD = 05,

            /// <summary>
            /// 治療處置費
            /// </summary>
            [Display(Name = "治療處置費")]
            [Description("Therapeutic Treatment Fee")]
            PRO = 06,

            /// <summary>
            /// 手術費
            /// </summary>
            [Display(Name = "手術費")]
            [Description("Surgery Fee")]
            SUG = 07,

            /// <summary>
            /// 復健治療費
            /// </summary>
            [Display(Name = "復健治療費")]
            [Description("Rehabilitation Therapy Fee")]
            REH = 08,

            /// <summary>
            /// 血液血漿費
            /// </summary>
            [Display(Name = "血液血漿費")]
            [Description("Blood/Plasma Fee")]
            BLD = 09,

            /// <summary>
            /// 血液透析費
            /// </summary>
            [Display(Name = "血液透析費")]
            [Description("Hemodialysis Fee")]
            THE = 10,

            /// <summary>
            /// 麻醉費
            /// </summary>
            [Display(Name = "麻醉費")]
            [Description("Anesthesia Fee")]
            ANE = 11,

            /// <summary>
            /// 特殊材料費
            /// </summary>
            [Display(Name = "特殊材料費")]
            [Description("Special Medical Supplies Fee")]
            MAT = 12,

            /// <summary>
            /// 藥費
            /// </summary>
            [Display(Name = "藥費")]
            [Description("Medicine Fee")]
            MED = 13,

            /// <summary>
            /// 藥事服務費
            /// </summary>
            [Display(Name = "藥事服務費")]
            [Description("Pharmacy Service Fee")]
            SER = 14,

            /// <summary>
            /// 精神科治療費
            /// </summary>
            [Display(Name = "精神科治療費")]
            [Description("Psychiatric Treatment Fee")]
            PSY = 15,

            /// <summary>
            /// 注射技術費
            /// </summary>
            [Display(Name = "注射技術費")]
            [Description("Injection Fee")]
            INT = 16,

            /// <summary>
            /// 嬰兒費
            /// </summary>
            [Display(Name = "嬰兒費")]
            [Description("Infant Fee")]
            BAB = 17,

            /// <summary>
            /// 特定健保費
            /// </summary>
            [Display(Name = "特定健保費")]
            [Description("Special N.H.I. Fee")]
            INS = 18,

            /// <summary>
            /// 保留
            /// </summary>
            [Display(Name = "保留")]
            [Description("")]
            RES1 = 19,

            /// <summary>
            /// 電話費
            /// </summary>
            [Display(Name = "電話費")]
            [Description("Telephone Fee")]
            RES2 = 20,

            /// <summary>
            /// 掛號費
            /// </summary>
            [Display(Name = "掛號費")]
            [Description("Registration Fee")]
            REG = 21,

            /// <summary>
            /// 證明費
            /// </summary>
            [Display(Name = "證明費")]
            [Description("Certification Fee")]
            IDT = 22,

            /// <summary>
            /// 車費
            /// </summary>
            [Display(Name = "車費")]
            [Description("Ambulance Fee")]
            CAR = 23,

            /// <summary>
            /// 特定醫療費
            /// </summary>
            [Display(Name = "特定醫療費")]
            [Description("Special Medical Treatment Fee")]
            SPC = 24,

            /// <summary>
            /// 部份負擔費
            /// </summary>
            [Display(Name = "部份負擔費")]
            [Description("Copayment Fee")]
            PAR = 25,
        }

        #region 掛號相關

        /// <summary>
        /// 掛號方式
        /// </summary>
        public enum AppointmentMethod
        {
            [Display(Name = "櫃台掛號")]
            CounterAppointmentNow = 10,

            [Display(Name = "醫師現場約診")]
            DoctorAppointmentNow = 11,

            [Display(Name = "櫃台預約")]
            CounterAppointment = 14,

            [Display(Name = "櫃台初診預約掛號")]
            CounterFirsstAppointment = 15,

            [Display(Name = "住院31日回診")]
            InHospital = 16,

            [Display(Name = "住院31日預約回診")]
            InHospitalAppointment = 17,

            [Display(Name = "醫師現場特約診")]
            DoctorSpecialAppointmentNow = 21,

            [Display(Name = "語音掛號")]
            VoiceAppointmentNow = 20,

            [Display(Name = "語音預約")]
            VoiceAppointment = 24,

            [Display(Name = "語音初診掛號")]
            VoiceFirstAppointment = 25,

            [Display(Name = "自動櫃台")]
            AutoCounter = 30,

            [Display(Name = "自動櫃台預約")]
            AutoCounterAppointment = 34,

            [Display(Name = "IOS 掛號")]
            IOSAppointment = 35,

            [Display(Name = "Win8 掛號")]
            Win8Appointment = 36,

            [Display(Name = "Android 掛號")]
            AndroidAppointment = 37,

            [Display(Name = "LINE 掛號")]
            LINEAppointment = 38,

            [Display(Name = "急診櫃台")]
            EmergencyCounter = 40,

            [Display(Name = "BC肝篩檢特約診")]
            HepatitisCSpecial = 41,

            [Display(Name = "醫師預約")]
            DoctorAppointment = 44,

            [Display(Name = "無掛號批價")]
            Nothing = 50,

            [Display(Name = "新陳代謝科CKD")]
            Metabolism = 52,

            [Display(Name = "醫師預約特約診")]
            DoctorSpecialAppointment = 54,

            [Display(Name = "急診轉區")]
            EmergencyShift = 61,

            [Display(Name = "網路預約掛號")]
            WebAppointment = 64,

            [Display(Name = "網路預約掛號(新版)")]
            WebAppointmentNew = 65,

            [Display(Name = "同一療程")]
            SameTreat = 70,

            [Display(Name = "網路初診掛號")]
            WebFirstAppointment = 74,

            [Display(Name = "網路現場掛號")]
            WebAppointmentNow = 75,

            [Display(Name = "連續處方")]
            ContinuousPrescription = 80,

            [Display(Name = "委託代檢")]
            EntrustInspection = 90
        }

        #endregion

        #region 批價相關
        /// <summary>
        /// 折扣比
        /// </summary>
        public enum DiscountType
        {
            [Display(Name = "現金")]
            Amount = 1,

            [Display(Name = "% 百分比")]
            Percent = 2,
        }

        /// <summary>
        /// 醫令狀態
        /// </summary>
        public enum CureRecState
        {
            /// <summary>
            /// 正常
            /// </summary>
            [Display(Name = "正常")]
            [Description("A")]
            Normal = 1,
            /// <summary>
            /// 作廢
            /// </summary>
            [Display(Name = "作廢")]
            [Description("")]
            Invalid = 2,
            /// <summary>
            /// 沖銷
            /// </summary>
            [Display(Name = "沖銷")]
            [Description("D")]
            WriteOff = 3,
        }

        /// <summary>
        /// 部分負擔類別
        /// </summary>
        public enum CopaymentKind
        {
            /// <summary>
            /// 基本部分負擔
            /// </summary>
            [Display(Name = "基本部分負擔")]
            [Description("Basic Copayment")]
            BASE = 1,

            /// <summary>
            /// 藥品部分負擔
            /// </summary>
            [Display(Name = "藥品部分負擔")]
            [Description("Medicine Copayment")]
            MED = 2,

            /// <summary>
            /// 復健部分負擔
            /// </summary>
            [Display(Name = "復健部分負擔")]
            [Description("Treatment Copayment")]
            REH = 3,

            /// <summary>
            /// 檢驗/查部分負擔
            /// </summary>
            [Display(Name = "檢驗/查部分負擔")]
            [Description("Exeamination Copayment")]
            CHK = 4,
        }

        /// <summary>
        /// 作廢種類
        /// </summary>
        public enum VoidType
        {
            /// <summary>
            /// 一般轉身分作廢
            /// </summary>
            [Display(Name = "一般作廢(轉身分)")]
            [Description("Normal Void")]
            Normal = 1,

            /// <summary>
            /// 全退作廢（全處方退費）
            /// </summary>
            [Display(Name = "全退費作廢")]
            [Description("All Void")]
            All = 2,

        }
        #endregion 批價相關

        #region 申報相關
        /// <summary>
        /// 申報類別
        /// </summary>
        public enum ClaimType
        {
            /// <summary>
            /// 送核
            /// </summary>
            [Display(Name = "送核")]
            Apply = 1,

            /// <summary>
            /// 補報
            /// </summary>
            [Display(Name = "補報")]
            Reapply = 2,
        }

        /// <summary>
        /// 申報月份註記
        /// </summary>
        public enum ClaimMonthFlag
        {
            /// <summary>
            /// 不分(申復使用)
            /// </summary>
            [Display(Name = "不分")]
            NoFalg = 0,

            /// <summary>
            /// 上半月
            /// </summary>
            [Display(Name = "上半月")]
            FirstHalf = 1,

            /// <summary>
            /// 下半月
            /// </summary>
            [Display(Name = "下半月")]
            SecondHalf = 2,

            /// <summary>
            /// 全月
            /// </summary>
            [Display(Name = "全月")]
            Month = 3,

        }

        /// <summary>
        /// 補報原因註記
        /// </summary>
        public enum ReapplyFlag
        {
            /// <summary>
            /// 補報整筆案件
            /// </summary>
            [Display(Name = "整案", Description = "補報整筆案件")]
            All = 1,

            /// <summary>
            /// 補報部分醫令或醫令差額
            /// </summary>
            [Display(Name = "部分", Description = "補報部分醫令或醫令差額")]
            Part = 2,
        }

        /// <summary>
        /// 申報拆案註記
        /// </summary>
        public enum CaseDividedRemark
        {
            /// <summary>
            /// 牙科
            /// </summary>
            [Display(Name = "牙科")]
            Dental = 1,

            /// <summary>
            /// 結核
            /// </summary>
            [Display(Name = "結核")]
            TB = 2,

            /// <summary>
            /// 疫苗
            /// </summary>
            [Display(Name = "疫苗")]
            Vaccine = 3,

            /// <summary>
            /// 兒童疫苗
            /// </summary>
            [Display(Name = "兒童疫苗")]
            ChildVaccine = 4,

            /// <summary>
            /// 新冠肺炎
            /// </summary>
            [Display(Name = "新冠肺炎")]
            COVID19 = 5,

            /// <summary>
            /// 登革熱
            /// </summary>
            [Display(Name = "登革熱")]
            Dengue = 6,

            /// <summary>
            /// 洗腎
            /// </summary>
            [Display(Name = "洗腎")]
            Dialysis = 7,

            /// <summary>
            /// 愛滋
            /// </summary>
            [Display(Name = "愛滋")]
            AIDS = 8,

            /// <summary>
            /// 預防保健
            /// </summary>
            [Display(Name = "預防保健")]
            PreventiveHealthCare = 9,

            /// <summary>
            /// 大腸癌
            /// </summary>
            [Display(Name = "大腸癌")]
            ColonCa = 10,

            /// <summary>
            /// 口腔癌
            /// </summary>
            [Display(Name = "口腔癌")]
            OralCa = 11,

            /// <summary>
            /// 子宮頸癌
            /// </summary>
            [Display(Name = "子宮頸癌")]
            CervixCa = 12,

            /// <summary>
            /// 乳癌
            /// </summary>
            [Display(Name = "乳癌")]
            BreastCa = 13,

            /// <summary>
            /// 肺癌
            /// </summary>
            [Display(Name = "肺癌")]
            LungCa = 14,

            /// <summary>
            /// 長照機構加強型結核病防治計畫
            /// </summary>
            [Display(Name = "長照機構結核病")]
            LongTermCareTB = 15,

            /// <summary>
            /// 自定義
            /// </summary>
            [Display(Name = "自定義")]
            Customize = 99,
        }

        /// <summary>
        /// 轉診、處方調劑或資源共享
        /// </summary>
        public enum SharedCase
        {
            /// <summary>
            /// 轉診
            /// </summary>
            [Display(Name = "轉診", Description = "保險對象本次就醫係由他院轉診而來")]
            ReferFromHospital = 1,

            /// <summary>
            /// 慢箋
            /// </summary>
            [Display(Name = "慢箋", Description = "慢性病連續處方調劑")]
            Chronic = 2,

            /// <summary>
            /// 原檢查醫院
            /// </summary>
            [Display(Name = "原檢查醫院", Description = "全民健康保險特殊造影檢查影像及報告申請-原檢查醫院提供")]
            FirstHospital = 7,

            /// <summary>
            /// 第2次處方醫院
            /// </summary>
            [Display(Name = "第2次處方醫院", Description = "全民健康保險特殊造影檢查影像及報告申請-第2次處方醫院")]
            SecondHospital = 8,

            //C6:中醫醫療資源不足地區巡迴醫療計畫（原名：無中醫鄉巡迴醫療）之轉診(106.10增訂)
            //G5:西醫基層(醫院支援)醫療資源不足地區改善方案-巡迴醫療之轉診(106.10增訂)
            //G9:全民健康保險山地離島地區醫療給付效益提昇計畫之轉診(106.10增訂)
            //F3:牙醫師至牙醫醫療資源不足地區巡迴醫療服務-巡迴醫療團（原名:牙醫師無牙醫鄉巡迴醫療服務）之轉診(106.10增訂)
            //FT:牙醫師至牙醫醫療資源不足地區巡迴服務計畫-社區醫療站之轉診(106.10增訂)
            //JA:收容對象醫療服務計畫-矯正機關內門診之轉診(106.10增訂)
            //T:無特約診所之鄉(鎮、市、區)逕赴該鄉(鎮、市、區)特約醫院就醫之視同轉診案件(1071106(107AD07265))
        }

        /// <summary>
        /// 申報方式
        /// </summary>
        public enum NHIClaimType
        {
            /// <summary>
            /// 書面
            /// </summary>
            [Display(Name = "書面")]
            Paper = 1,

            /// <summary>
            /// 媒體
            /// </summary>
            [Display(Name = "媒體")]
            Media = 2,

            /// <summary>
            /// 連線
            /// </summary>
            [Display(Name = "連線")]
            Connect = 3,
        }

        /// <summary>
        /// 總額類別
        /// CodeGroup=HOSPTYPE
        /// </summary>
        public enum HospType
        {
            /// <summary>
            /// 牙醫門診
            /// </summary>
            [Display(Name = "牙醫門診", Description = "牙醫", ShortName = "13")]
            [Description("T")]
            Dentist = 13,

            /// <summary>
            /// 居家照護
            /// </summary>
            [Display(Name = "居家照護", Description = "居護", ShortName = "19")]
            [Description("H")]
            HomeCare = 19,

            /// <summary>
            /// 門診洗腎
            /// </summary>
            [Display(Name = "門診洗腎", Description = "洗腎", ShortName = "15")]
            [Description("E")]
            Dialysis = 15,

            /// <summary>
            /// 西醫門診
            /// </summary>
            [Display(Name = "西醫門診", Description = "西醫", ShortName = "12")]
            [Description("N")]
            Outpatient = 12,

            /// <summary>
            /// 中醫
            /// </summary>
            [Display(Name = "中醫", Description = "中醫", ShortName = "14")]
            [Description("C")]
            Chinese = 14,

            /// <summary>
            /// 西醫住院
            /// </summary>
            [Display(Name = "西醫住院", Description = "住院", ShortName = "22")]
            [Description("")]
            Inpatient = 22,
        }

        /// <summary>
        /// 轉申報註記
        /// </summary>
        public enum IsDEC
        {
            /// <summary>
            /// 前線資料
            /// </summary>
            [Display(Name = "預設值", ShortName = "No")]
            N = 0,

            /// <summary>
            /// 已轉申報
            /// </summary>
            [Display(Name = "已轉申報", ShortName = "Yes")]
            Y = 1,

            /// <summary>
            /// 前線資料異動
            /// </summary>
            [Display(Name = "前線資料異動", ShortName = "Edit")]
            E = 2,

            /// <summary>
            /// 依健保規則不申報
            /// </summary>
            [Display(Name = "健保不申報", ShortName = "Delete", Description = "依健保規則不申報")]
            D = 3,

            /// <summary>
            /// 合併醫令
            /// </summary>
            [Display(Name = "合併醫令", ShortName = "Combined", Description = "醫令併至別筆")]
            C = 4,

            /// <summary>
            /// 申報調整
            /// </summary>
            [Display(Name = "申報調整", ShortName = "Modify")]
            M = 5,
        }

        /// <summary>
        /// 申報狀態
        /// </summary>
        public enum ClaimState
        {
            /// <summary>
            /// 不申報
            /// </summary>
            [Display(Name = "不申報")]
            NoClaim = 0,

            /// <summary>
            /// 申報
            /// </summary>
            [Display(Name = "申報")]
            Claim = 1,

            /// <summary>
            /// 住院申報
            /// </summary>
            [Display(Name = "住院申報")]
            InpClaim = 2,

            ///// <summary>
            ///// 因應合理量
            ///// </summary>
            //[Display(Name = "因應合理量")]
            //NoClaim = 3,

            /// <summary>
            /// 沒醫令
            /// </summary>
            [Display(Name = "沒醫令")]
            NoOrdfa = 4,

            /// <summary>
            /// 撤案
            /// </summary>
            [Display(Name = "撤案")]
            Withdraw = 5,
        }

        /// <summary>
        /// 申報案件分類
        /// </summary>
        public enum ClaimStageTable
        {
            /// <summary>
            /// 一般案件
            /// </summary>
            [Display(Name = "一般案件", ShortName = "一")]
            STAGE_REG = 0,

            /// <summary>
            /// 同療案件
            /// </summary>
            [Display(Name = "同療案件", ShortName = "同")]
            STAGE_SAME = 1,

            /// <summary>
            /// 排檢案件
            /// </summary>
            [Display(Name = "排檢案件", ShortName = "排")]
            STAGE_SCHEDULE = 2,
        }

        /// <summary>
        /// 申報部分負擔計算模式
        /// </summary>
        public enum ClaimCalcMode
        {
            /// <summary>
            /// 系統計算
            /// </summary>
            [Display(Name = "系統計算")]
            Default = 0,

            /// <summary>
            /// 基本部份負擔不計算
            /// </summary>
            [Display(Name = "基本部份負擔不計算")]
            NoBase = 1,

            /// <summary>
            /// 基本部份負擔不計算
            /// </summary>
            [Display(Name = "藥品部分負擔不計算")]
            NoMed = 2,

            ///// <summary>
            ///// 檢驗檢查部分負擔不計算
            ///// </summary>
            //[Display(Name = "檢驗檢查部分負擔不計算")]
            //NoChk = 3,

            /// <summary>
            /// 全部部分負擔不計算
            /// </summary>
            [Display(Name = "全部部分負擔不計算")]
            Customized = 99,
        }

        /// <summary>
        /// 特殊案件狀態
        /// </summary>
        public enum SPECIALCASE
        {
            /// <summary>
            /// 包裹給付
            /// </summary>
            [Display(Name = "包裹給付")]
            PackagePayment = 1,

            /// <summary>
            /// 人工調整保留
            /// </summary>
            [Display(Name = "人工調整保留")]
            CustomKeep = 2,

            /// <summary>
            /// 上月保留下來
            /// </summary>
            [Display(Name = "上月保留下來")]
            LastMonthKeep = 3,
        }
        #endregion 申報相關

        #region IC卡 定義
        /// <summary>
        /// 保險對象身分註記
        /// reg.INSUMARK
        /// </summary>
        public enum ICNoteInsuredIdentity
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            NULL = 0,

            /// <summary>
            /// 低收入戶
            /// </summary>
            [Display(Name = "低收入戶")]
            LowIncome = 1,

            /// <summary>
            /// 無職業的榮民
            /// </summary>
            [Display(Name = "無職業榮民")]
            RongminOrRong = 2,

            /// <summary>
            /// 一般身分
            /// </summary>
            [Display(Name = "一般身分")]
            Normal = 3,

            /// <summary>
            /// 中低收入戶
            /// </summary>
            [Display(Name = "中低收入戶")]
            MiddleLowIncome = 4,

            /// <summary>
            /// 災民
            /// </summary>
            [Display(Name = "災民")]
            Victims = 8,
        }

        /// <summary>
        /// 健保就醫類別
        /// </summary>
        public enum MedicalCategoryType
        {
            /// <summary>
            /// 無設定
            /// </summary>
            [Display(Name = "-9999")]
            無設定 = 0,

            /// <summary>
            /// 01西醫門診
            /// </summary>
            [Display(Name = "01")]
            西醫門診 = 1,

            /// <summary>
            /// 02牙醫門診
            /// </summary>
            [Display(Name = "02")]
            牙醫門診 = 2,

            /// <summary>
            /// 03中醫門診
            /// </summary>
            [Display(Name = "03")]
            中醫門診 = 3,

            /// <summary>
            /// 04急診
            /// </summary>
            [Display(Name = "04")]
            急診 = 4,

            /// <summary>
            /// 05住院
            /// </summary>
            [Display(Name = "05")]
            住院 = 5,

            /// <summary>
            /// 06門診轉診就醫
            /// </summary>
            [Display(Name = "06")]
            門診轉診就醫 = 6,

            /// <summary>
            /// 07門診手術後之回診
            /// </summary>
            [Display(Name = "07")]
            門診手術後之回診 = 7,

            /// <summary>
            /// 08住院患者出院之回診
            /// </summary>
            [Display(Name = "08")]
            住院患者出院之回診 = 8,

            /// <summary>
            /// AA同一療程項目以6次以內治療為限者
            /// </summary>
            [Display(Name = "AA")]
            同一療程項目以6次以內治療為限者 = 9,

            /// <summary>
            /// AB同一療程項目屬非6次以內治療為限者
            /// </summary>
            [Display(Name = "AB")]
            同一療程項目屬非6次以內治療為限者 = 10,

            /// <summary>
            /// AC預防保健
            /// </summary>
            [Display(Name = "AC")]
            預防保健 = 11,

            /// <summary>
            /// AD職業傷害或職業病門急診
            /// </summary>
            [Display(Name = "AD")]
            職業傷害或職業病門急診 = 12,

            /// <summary>
            /// AE慢性病連續處方箋領藥
            /// </summary>
            [Display(Name = "AE")]
            慢性病連續處方箋領藥 = 13,

            /// <summary>
            /// AF藥局調劑
            /// </summary>
            [Display(Name = "AF")]
            藥局調劑 = 14,

            /// <summary>
            /// AG排程檢查
            /// </summary>
            [Display(Name = "AG")]
            排程檢查 = 15,

            /// <summary>
            /// AH居家照護第二次以後
            /// </summary>
            [Display(Name = "AH")]
            居家照護第二次以後 = 16,

            /// <summary>
            /// AI同日同醫師看診第二次以後
            /// </summary>
            [Display(Name = "AI")]
            同日同醫師看診第二次以後 = 17,

            /// <summary>
            /// BA門急診當次轉住院之入院
            /// </summary>
            [Display(Name = "BA")]
            門急診當次轉住院之入院 = 18,

            /// <summary>
            /// BB出院
            /// </summary>
            [Display(Name = "BB")]
            出院 = 19,

            /// <summary>
            /// BC急診中住院中執行項目
            /// </summary>
            [Display(Name = "BC")]
            急診中住院中執行項目 = 20,

            /// <summary>
            /// BD急診第二日含以後之離院
            /// </summary>
            [Display(Name = "BD")]
            急診第二日含以後之離院 = 21,

            /// <summary>
            /// BE職業傷害或職業病之住院
            /// </summary>
            [Display(Name = "BE")]
            職業傷害或職業病之住院 = 22,

            /// <summary>
            /// BF繼續住院依規定分段結清者
            /// </summary>
            [Display(Name = "BF")]
            繼續住院依規定分段結清者 = 23,

            /// <summary>
            /// CA其他規定不須累計就醫序號即不扣除就醫次數者
            /// </summary>
            [Display(Name = "CA")]
            其他規定不須累計就醫序號即不扣除就醫次數者 = 24,

            /// <summary>
            /// DA門診轉出
            /// </summary>
            [Display(Name = "DA")]
            門診轉出 = 25,

            /// <summary>
            /// DB門診手術後需於7日內之1次回診
            /// </summary>
            [Display(Name = "DB")]
            門診手術後需於7日內之1次回診 = 26,

            /// <summary>
            /// DC住院患者出院後需於7日內之1次回診
            /// </summary>
            [Display(Name = "DC")]
            住院患者出院後需於7日內之1次回診 = 27,

            /// <summary>
            /// XA取消孕婦產前檢查
            /// </summary>
            [Display(Name = "XA")]
            取消孕婦產前檢查 = 28,

            /// <summary>
            /// YA兒童預防保健
            /// </summary>
            [Display(Name = "YA")]
            兒童預防保健 = 29,

            /// <summary>
            /// YB成人預防保健
            /// </summary>
            [Display(Name = "YB")]
            成人預防保健 = 30,

            /// <summary>
            /// YC婦女子宮頸抹片檢查
            /// </summary>
            [Display(Name = "YC")]
            婦女子宮頸抹片檢查 = 31,

            /// <summary>
            /// YD兒童牙齒預防保健
            /// </summary>
            [Display(Name = "YD")]
            兒童牙齒預防保健 = 32,

            /// <summary>
            /// YE婦女乳房檢查
            /// </summary>
            [Display(Name = "YE")]
            婦女乳房檢查 = 33,

            /// <summary>
            /// YF六十五歲老人流行性感冒疫苗
            /// </summary>
            [Display(Name = "YF")]
            六十五歲老人流行性感冒疫苗 = 34,

            /// <summary>
            /// YG定量免疫法糞便潛血檢查
            /// </summary>
            [Display(Name = "YG")]
            定量免疫法糞便潛血檢查 = 35,

            /// <summary>
            /// YH口腔黏膜檢查
            /// </summary>
            [Display(Name = "YH")]
            口腔黏膜檢查 = 36,

            /// <summary>
            /// ZA取消24小時內所有就醫類別
            /// </summary>
            [Display(Name = "ZA")]
            取消24小時內所有就醫類別 = 37,

            /// <summary>
            /// ZB取消24小時內部分就醫類別
            /// </summary>
            [Display(Name = "ZB")]
            取消24小時內部分就醫類別 = 38,

            /// <summary>
            /// 09透析門診 (111年1月1日起新增) 
            /// </summary>
            [Display(Name = "09")]
            透析門診 = 39,

            /// <summary>
            /// AJ透析門診療程第二次(含)以後 (111年1月1日起新增) 
            /// </summary>
            [Display(Name = "AJ")]
            透析門診療程第二次含以後 = 40,

            /// <summary>
            /// BG門診當次轉住院之入院  (110年12月20日起新增) 
            /// </summary>
            [Display(Name = "BG")]
            門診當次轉住院之入院 = 41,

            /// <summary>
            /// EA床號變更或轉床 (110年7月1日起新增) 
            /// </summary>
            [Display(Name = "EA")]
            床號變更或轉床 = 42,

            /// <summary>
            /// AK床號變更或轉床 (110年7月1日起新增) 
            /// </summary>
            [Display(Name = "AK")]
            急診留觀 = 43,
        }

        #region 健保IC卡-卡片別
        /// <summary>
        /// 健保IC卡-卡片別
        /// </summary>
        public enum ICCardType
        {
            /// <summary>
            /// 安全模組(SAM)
            /// </summary>
            [Display(Name = "雲端安全模組")]
            [Description("SAM")]
            SAM = 1,
            /// <summary>
            /// 健保IC卡
            /// </summary>
            [Display(Name = "健保IC卡")]
            [Description("HC")]
            HC = 2,
            /// <summary>
            /// 醫事人員卡
            /// </summary>
            [Display(Name = "醫事人員卡")]
            [Description("HCP")]
            HCP = 3
        }
        #endregion

        #region NHIICCard_門診處方籤_醫令類別
        /// <summary>
        /// IC1.0 NHIICCard_門診處方籤_醫令類別 A72
        /// </summary>
        public enum OPDPrescription_OrderType
        {
            /// <summary>
            /// 非長期藥品處方箋
            /// </summary>
            [Display(Name = "非長期藥品處方箋")]
            [Description("1")]
            NoneLongPrescription = 1,
            /// <summary>
            /// 長期藥品處方箋
            /// </summary>
            [Display(Name = "長期藥品處方箋")]
            [Description("2")]
            LongPrescription = 2,
            /// <summary>
            /// 診療
            /// </summary>
            [Display(Name = "診療")]
            [Description("3")]
            Diagnosis = 3,
            /// <summary>
            /// 特殊材料
            /// </summary>
            [Display(Name = "特殊材料")]
            [Description("4")]
            SpecialMaterial = 4,
            /// <summary>
            /// 重要醫令(含門住診)
            /// </summary>
            [Display(Name = "重要醫令(含門住診)")]
            [Description("5")]
            ImportationOrderIncludeOPDIPD = 5,
            /// <summary>
            /// 刪除非長期藥品處方箋
            /// </summary>
            [Display(Name = "刪除非長期藥品處方箋")]
            [Description("A")]
            DeleteNoneLongPrescription = 6,
            /// <summary>
            /// 刪除長期藥品處方箋
            /// </summary>
            [Display(Name = "刪除長期藥品處方箋")]
            [Description("B")]
            DeleteLongPrescription = 7,
            /// <summary>
            /// 刪除診療
            /// </summary>
            [Display(Name = "刪除診療")]
            [Description("C")]
            DeleteDiagnosis = 8,
            /// <summary>
            /// 刪除特殊材料
            /// </summary>
            [Display(Name = "刪除特殊材料")]
            [Description("D")]
            DeleteSpecialMaterial = 9,
            /// <summary>
            /// 刪除重要醫令(含門住診)
            /// </summary>
            [Display(Name = "刪除重要醫令(含門住診)")]
            [Description("E")]
            DeleteImportationOrderIncludeOPDIPD = 10,
            /// <summary>
            /// 矯正機關代號
            /// </summary>
            [Display(Name = "矯正機關代號")]
            [Description("J")]
            CorrectionAgencyCode = 11,
            /// <summary>
            /// 刪除矯正機關代號
            /// </summary>
            [Display(Name = "刪除矯正機關代號")]
            [Description("K")]
            DeleteCorrectionAgencyCode = 12,
            /// <summary>
            /// 虛擬醫令[R001~R004]
            /// </summary>
            [Display(Name = "虛擬醫令")]
            [Description("G")]
            VirtualMedicalOrder = 13,
            /// <summary>
            /// 刪除虛擬醫令
            /// </summary>
            [Display(Name = "刪除虛擬醫令")]
            [Description("H")]
            DeleteVirtualMedicalOrder = 14,
        }
        /// <summary>
        /// IC1.0 交付處方註記A78
        /// </summary>
        public enum ISRXOUT_KIND
        {
            /// <summary>
            /// 自行調劑
            /// </summary>
            [Display(Name = "自行調劑")]
            [Description("01")]
            SelfAdjustmentPrescription = 1,
            /// <summary>
            /// 交付調劑
            /// </summary>
            [Display(Name = "交付調劑")]
            [Description("02")]
            DeliveryAdjustmentPresecriptiop = 2,
            /// <summary>
            /// 自行執行
            /// </summary>
            [Display(Name = "自行執行")]
            [Description("03")]
            SelefExecuteOrder = 3,
            /// <summary>
            /// 交付執行
            /// </summary>
            [Display(Name = "交付執行")]
            [Description("04")]
            DeliveryExecuteOrder = 4,
            /// <summary>
            /// 自行調劑之慢性病連續處方箋
            /// </summary>
            [Display(Name = "自行調劑之慢性病連續處方箋")]
            [Description("05")]
            SelfAdjustmentSlowPrescription = 5,
            /// <summary>
            /// 交付調劑之慢性病連續處方箋
            /// </summary>
            [Display(Name = "交付調劑之慢性病連續處方箋")]
            [Description("06")]
            DeliveryAdjustmentSlowPresecriptiop = 6,
        }

        #endregion

        #region NHIICCard_
        /// <summary>
        /// 處方調劑方式 IC20
        /// </summary>
        public enum ISRXOUT_IC20
        {
            /// <summary>
            /// 自行調劑 0
            /// </summary>
            [Display(Name = "自行調劑")]
            [Description("0")]
            SelfAdjustmentPrescription = 1,
            /// <summary>
            /// 交付調劑 1
            /// </summary>
            [Display(Name = "交付調劑")]
            [Description("1")]
            DeliveryAdjustmentPresecription = 2,
            /// <summary>
            /// 未開(藥品)處方 2
            /// </summary>
            [Display(Name = "未開(藥品)處方")]
            [Description("2")]
            NoneMedPresecription = 3,
            /// <summary>
            /// 符合藥事法第102 條規定無藥事人員執業之偏遠地區或緊急急迫情形之自⾏調劑 6
            /// </summary>
            [Display(Name = "符合藥事法第102 條規定無藥事人員執業之偏遠地區或緊急急迫情形之自行調劑")]
            [Description("6")]
            EmergencySelfAdjustmentPrescription = 4,
            /// <summary>
            /// 藥品自⾏調劑,物理（或職能）治療自⾏執⾏ A
            /// </summary>
            [Display(Name = "藥品自⾏調劑,物理（或職能）治療自⾏執⾏")]
            [Description("A")]
            AdjustmentPresecriptionMEDSelfREHSelf,
            /// <summary>
            /// 藥品自⾏調劑,物理（或職能）治療交付執⾏ B
            /// </summary>
            [Display(Name = "藥品自⾏調劑,物理（或職能）治療交付執⾏")]
            [Description("B")]
            AdjustmentPresecriptionMEDSelfREHDelivery,
            /// <summary>
            /// 藥品交付調劑,物理（或職能）治療自⾏執⾏ C
            /// </summary>
            [Display(Name = "藥品交付調劑,物理（或職能）治療自⾏執⾏")]
            [Description("C")]
            AdjustmentPresecriptionMEDDeliveryREHSelf,
            /// <summary>
            /// 藥品交付調劑,物理（或職能）治療交付執⾏ D
            /// </summary>
            [Display(Name = "藥品交付調劑,物理（或職能）治療交付執⾏")]
            [Description("D")]
            AdjustmentPresecriptionMEDDeliveryREHDelivery,
            /// <summary>
            /// 未開處方調劑,物理（或職能）治療自⾏執⾏ E
            /// </summary>
            [Display(Name = "未開處方調劑,物理（或職能）治療自⾏執⾏")]
            [Description("E")]
            AdjustmentPresecriptionMEDNoneREHSelf,
            /// <summary>
            /// 未開處方調劑,物理（或職能）治療交付執⾏ F
            /// </summary>
            [Display(Name = "未開處方調劑,物理（或職能）治療交付執⾏")]
            [Description("F")]
            AdjustmentPresecriptionMEDNoneREHDelivery,
        }

        #endregion
        #endregion IC卡 定義

        #region 身分類別 20210415 Created 林伯翰
        /// <summary>
        /// 身分別 ALL List
        /// </summary>
        public enum IdentityAllType
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = nameof(EnumUtility.IdentityAllType.Null))]
            [Description("初始值")]
            Null,
            /// <summary>
            /// 身分類別.PatientGroup
            /// </summary>
            [Display(Name = nameof(EnumUtility.TypeCode))]
            [Description("身分類別")]
            TYPECODE,
            /// <summary>
            /// 保險類別.CODE_SRC.INSUTYPE
            /// </summary>
            [Display(Name = nameof(EnumUtility.InsType))]
            [Description("保險類別")]
            INSTYPE,
            /// <summary>
            /// PAYTYPE 負擔類別.BASPART.VISITKIND=2.PARTNO!=null
            /// </summary>
            [Display(Name = nameof(EnumUtility.CopaymentType))]
            [Description("負擔類別")]
            PAYTYPE,
            /// <summary>
            /// 優待類別
            /// </summary>
            [Display(Name = nameof(EnumUtility.VipType))]
            [Description("優待類別")]
            VIPTYPE,
            /// <summary>
            /// 就醫類別.CODE_SRC.DELFA05
            /// </summary>
            [Display(Name = nameof(EnumUtility.TreatItem))]
            [Description("就醫類別")]
            TREATITEM,
            /// <summary>
            /// 案件類別
            /// </summary>
            [Display(Name = nameof(EnumUtility.CaseType))]
            [Description("案件類別")]
            CASETYPE,
            /// <summary>
            /// 其他免部分負擔選項
            /// </summary>
            [Display(Name = nameof(EnumUtility.OthPay))]
            [Description("其他免部分負擔選項")]
            OTHPAY,
            /// <summary>
            /// 保健服務項目註記
            /// </summary>
            [Display(Name = nameof(EnumUtility.Item))]
            [Description("保健服務項目註記")]
            ITEM,
            /// <summary>
            /// 給付類別
            /// </summary>
            [Display(Name = nameof(EnumUtility.GiveType))]
            [Description("給付類別")]
            GIVETYPE,
            /// <summary>
            /// 檢查代碼
            /// </summary>
            [Display(Name = nameof(EnumUtility.ItemCode))]
            [Description("檢查代碼")]
            ITEMCODE
        }
        /// <summary>
        /// 身分類別.PatientGroup
        /// 取EnumValue
        /// </summary>
        public enum TypeCode
        {
            /// <summary>
            /// 未選取狀態[不在DB中，程式判斷使用]
            /// </summary>
            [Display(Name = null)]
            None = 0,

            /// <summary>
            /// 軍人(非健保)
            /// </summary>
            [Display(Name = "軍人(非健保)")]
            Military_NonNHI = 10,

            /// <summary>
            /// 民眾
            /// </summary>
            [Display(Name = "民眾")]
            People = 20,

            /// <summary>
            /// 兵役複檢(非健保)
            /// </summary>
            [Display(Name = "兵役複檢(非健保)")]
            MilitaryReview_NonNHI = 22,

            /// <summary>
            /// 健保
            /// </summary>
            [Display(Name = "健保")]
            NHI = 40,

            /// <summary>
            /// 軍人/軍眷(健保)
            /// </summary>
            [Display(Name = "軍人/軍眷(健保)")]
            MilitaryAndMilitaryFamily_NHI = 50,
        }

        /// <summary>
        /// 保險類別.CODE_SRC.INSUTYPE
        /// 取Description當Value
        /// </summary>
        public enum InsType
        {
            /// <summary>
            /// 一般民眾(無任何保險給付)
            /// </summary>
            [Display(Name = "一般民眾(無任何保險給付)")]
            [Description("00")]
            People,

            /// <summary>
            /// 縣巿政府兵役
            /// </summary>
            [Display(Name = "縣巿政府兵役")]
            [Description("AA")]
            CityMilitary,

            /// <summary>
            /// 自費兵役 AB
            /// </summary>
            [Display(Name = "自費兵役")]
            [Description("AB")]
            SelfPayMilitary,

            /// <summary>
            /// 無給付兵役 AC
            /// </summary>
            [Display(Name = "無給付兵役")]
            [Description("AC")]
            NonPayMilitary,

            /// <summary>
            /// 老人健康檢查 B1
            /// </summary>
            [Display(Name = "老人健康檢查")]
            [Description("B1")]
            ELderlyHealthCheck,

            /// <summary>
            /// 成人健康檢查 B2
            /// </summary> 
            [Display(Name = "成人健康檢查")]
            [Description("B2")]
            AdultHealthCheck,

            /// <summary>
            /// 新進員工體檢 B3
            /// </summary>
            [Display(Name = "新進員工體檢")]
            [Description("B3")]
            NewStaffHealthCheck,

            /// <summary>
            /// HIV B7
            /// </summary>
            [Display(Name = "HIV")]
            [Description("B7")]
            HIV,

            /// <summary>
            /// 台北市兒童輔助費用
            /// </summary>
            [Display(Name = "台北市兒童輔助費用")]
            [Description("C3")]
            ChildrenSubsidiesTaipei,

            /// <summary>
            /// 健保局
            /// </summary>
            [Display(Name = "健保局")]
            [Description("CD")]
            HIBureau,

            /// <summary>
            /// 精神科強制入院
            /// </summary>
            [Display(Name = "精神科強制入院")]
            [Description("NB")]
            MandatoryPsychiatricAdmission,

            /// <summary>
            /// 門診研究病房GCRC(W75)
            /// </summary>
            [Display(Name = "門診研究病房GCRC(W75)")]
            [Description("WW")]
            OutpatientResearchWard_GCRC,
        }

        /// <summary>
        /// 負擔類別.BASPART.VISITKIND=2.PARTNO!=null
        /// 取Description當Value
        /// </summary>
        public enum CopaymentType
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("-1")]
            None,

            /// <summary>
            /// 重大傷病
            /// 001
            /// </summary>
            [Display(Name = "重大傷病")]
            [Description("001")]
            MajorInjury,

            /// <summary>
            /// 分娩
            /// 002
            /// </summary>
            [Display(Name = "分娩")]
            [Description("002")]
            ChildBirth,

            /// <summary>
            /// 低收入戶
            /// 003
            /// </summary>
            [Display(Name = "低收入戶")]
            [Description("003")]
            LowIncomeHouseHolds,

            /// <summary>
            /// 榮民、榮民遺眷
            /// 004
            /// </summary>
            [Display(Name = "榮民、榮民遺眷")]
            [Description("004")]
            VenteransAndFamily,

            /// <summary>
            /// 結核病患
            /// 005
            /// </summary>
            [Display(Name = "結核病患")]
            [Description("005")]
            TuberculosisPatients,

            /// <summary>
            /// 勞工職業傷害或職業病
            /// 006
            /// </summary>
            [Display(Name = "勞工職業傷害或職業病")]
            [Description("006")]
            EmploymentInjuryOrOccupationalDisease,

            /// <summary>
            /// 山地離島地區之醫院門急診
            /// 007
            /// </summary>
            [Display(Name = "山地離島地區之醫院門急診")]
            [Description("007")]
            MountainousIslandsOPDAndER,

            /// <summary>
            /// 離島醫院轉診至台灣門急診就醫
            /// 008
            /// </summary>
            [Display(Name = "離島醫院轉診至台灣門急診就醫")]
            [Description("008")]
            OutlyingIslandReferralToTWOPDAndER,

            /// <summary>
            /// 其他
            /// 009
            /// </summary>
            [Display(Name = "其他")]
            [Description("009")]
            Other,

            /// <summary>
            /// HMO
            /// 801
            /// </summary>
            [Display(Name = "HMO巡迴醫療")]
            [Description("801")]
            HMO,

            /// <summary>
            /// 多氯聯苯中毒
            /// 901
            /// </summary>
            [Display(Name = "多氯聯苯中毒")]
            [Description("901")]
            PCBPoisoning,

            /// <summary>
            /// 未滿3足歲兒童
            /// 902
            /// </summary>
            [Display(Name = "未滿3足歲兒童")]
            [Description("902")]
            ChildrenUnder3YearsOld,

            /// <summary>
            /// 新生兒就醫(出生六十日)
            /// 903
            /// </summary>
            [Display(Name = "新生兒就醫(出生六十日)")]
            [Description("903")]
            NewbornsSeekMedicalAttention_60DaysAfterBirth,

            /// <summary>
            /// 愛滋病患
            /// 904
            /// </summary>
            [Display(Name = "愛滋病患")]
            [Description("904")]
            AIDS,

            /// <summary>
            /// 替代役役男
            /// 906
            /// </summary>
            [Display(Name = "替代役役男")]
            [Description("906")]
            AlternativeServiceman,

            /// <summary>
            /// 代辦海巡署輔助部份負擔
            /// 908
            /// </summary>
            [Display(Name = "代辦海巡署輔助部份負擔")]
            [Description("908")]
            CoastGuardPartTypeAgent,

            /// <summary>
            /// 代辦中央警察大學輔助部份負擔
            /// 909
            /// </summary>
            [Display(Name = "代辦中央警察大學輔助部份負擔")]
            [Description("909")]
            CenterPoliceUniversityPartTypeAgent,

            /// <summary>
            /// 代辦內政部消防署輔助部份負擔
            /// 910
            /// </summary>
            [Display(Name = "代辦內政部消防署輔助部份負擔")]
            [Description("910")]
            MinistryOfTheInteriorFireDepartmentPartTypeAgent,

            /// <summary>
            /// 代辦內政部空勤總隊輔助部份負擔
            /// 911
            /// </summary>
            [Display(Name = "代辦內政部空勤總隊輔助部份負擔")]
            [Description("911")]
            MinistryOfTheInteriorAireCrewCorpsPartTypeAgent,

            /// <summary>
            /// 代辦內政部警政署輔助部份負擔
            /// 912
            /// </summary>
            [Display(Name = "代辦內政部警政署輔助部份負擔")]
            [Description("912")]
            MinistryOfTheInteriorPoliceDepartmentPartTypeAgent,

            /// <summary>
            /// 代辦國防部輔助部份負擔
            /// 913
            /// </summary>
            [Display(Name = "代辦國防部輔助部份負擔")]
            [Description("913")]
            MinistryOfNationalDefensePartTypeAgent,

            /// <summary>
            /// 代辦疾管署輔助部份負擔
            /// 914
            /// </summary>
            [Display(Name = "代辦疾管署輔助部份負擔")]
            [Description("914")]
            CDCPartTypeAgent,

            /// <summary>
            /// 代辦移民署輔助部份負擔
            /// 915
            /// </summary>
            [Display(Name = "代辦移民署輔助部份負擔")]
            [Description("915")]
            MinistryOfTheInteriorImmigrationPartTypeAgent,

            /// <summary>
            /// 長照機構結核病防治
            /// 916
            /// </summary>
            [Display(Name = "長照機構結核病防治")]
            [Description("916")]
            LongTermCareTBPrevention,

            /// <summary>
            /// 醫學中心急診
            /// A00
            /// </summary>
            [Display(Name = "醫學中心急診")]
            [Description("A00")]
            MedicalCenter_EmergencyRoom,

            /// <summary>
            /// 醫學中心一般門診
            /// A12
            /// </summary>
            [Display(Name = "醫學中心一般門診")]
            [Description("A12")]
            MedicalCenter_OutpatientClinic,

            /// <summary>
            /// 醫學中心一般門診；持殘障手冊
            /// A13
            /// </summary>
            [Display(Name = "醫學中心一般門診；持殘障手冊")]
            [Description("A13")]
            MedicalCenter_OutpatientClinic_WithHandicapHandbook,

            /// <summary>
            /// 醫學中心;藥品.復健
            /// A20
            /// </summary>
            [Display(Name = "醫學中心;藥品.復健")]
            [Description("A20")]
            MedicalCenter_Rehabilitation,

            /// <summary>
            /// 醫學中心;藥品.復健;持殘障手冊
            /// A23
            /// </summary>
            [Display(Name = "醫學中心;藥品.復健;持殘障手冊")]
            [Description("A23")]
            MedicalCenter_RehabilitationWithHandicapHandbook,

            /// <summary>
            /// 醫學中心轉診
            /// A30
            /// </summary>
            [Display(Name = "醫學中心轉診")]
            [Description("A30")]
            MedicalCenter_Referral,

            /// <summary>
            /// 醫學中心第二至五次轉診
            /// A31
            /// </summary>
            [Display(Name = "醫學中心第二至五次轉診")]
            [Description("A31")]
            MedicalCenter_SecondToFifthReferrals,

            /// <summary>
            /// 醫學中心回診
            /// A40
            /// </summary>
            [Display(Name = "醫學中心回診")]
            [Description("A40")]
            MedicalCenter_Visit,

            /// <summary>
            /// 醫學中心牙醫急診
            /// E00
            /// </summary>
            [Display(Name = "醫學中心牙醫急診")]
            [Description("E00")]
            MedicalCenter_DEN_ER,

            /// <summary>
            /// 醫學中心牙醫一般門診
            /// E10
            /// </summary>
            [Display(Name = "醫學中心牙醫一般門診")]
            [Description("E10")]
            MedicalCenter_OutpatientClinicOf_DEN,

            /// <summary>
            /// 醫學中心牙醫一般門診；持殘障手冊
            /// E13
            /// </summary>
            [Display(Name = "醫學中心牙醫一般門診；持殘障手冊")]
            [Description("E13")]
            MedicalCenter_OutpatientClinicOf_DEN_WithHandicapHandbook,

            /// <summary>
            /// 醫學中心;高利用率者(93年1月後停用)
            /// E20
            /// </summary>
            [Display(Name = "醫學中心;高利用率者(93年1月後停用)")]
            [Description("E20")]
            MedicalCenter_HighUtilizationRate_StoppedAfterJan1993,

            /// <summary>
            /// 醫學中心;高利用率者;持殘障手冊(93年1月後停用)
            /// E23
            /// </summary>
            [Display(Name = "醫學中心;高利用率者;持殘障手冊(93年1月後停用)")]
            [Description("E23")]
            MedicalCenter_HighUtilizationRateWithHandicapHandbook_StoppedAfterJan1993,

            /// <summary>
            /// 居家照護(沒有開藥)
            /// K00
            /// </summary>
            [Display(Name = "居家照護(沒有開藥)")]
            [Description("K00")]
            HomeCare_NonMedicationIsPrescribed,

            /// <summary>
            /// 居家照護(有開藥)
            /// K20
            /// </summary>
            [Display(Name = "居家照護(有開藥)")]
            [Description("K20")]
            HomeCare_WithMedication,

            /// <summary>
            /// 戒菸門診
            /// Z00
            /// </summary>
            [Display(Name = "戒菸門診")]
            [Description("Z00")]
            SmokingCessationClinic,

            /// <summary>
            /// 醫學中心急診;持身心障礙證明
            /// A03
            /// </summary>
            [Display(Name = "醫學中心急診;持身心障礙證明")]
            [Description("A03")]
            MedicalCenter_EmergencyRoom_WithHandicapHandbook,

            /// <summary>
            /// 醫學中心急診;中低收入戶
            /// A0F
            /// </summary>
            [Display(Name = "醫學中心急診;中低收入戶")]
            [Description("A0F")]
            MedicalCenter_EmergencyRoom_MiddleLowIncomeHouseHolds,

            /// <summary>
            /// 醫學中心;一般門診僅開立藥品;中低收入註記(112.3 新增)
            /// A1P
            /// </summary>
            [Display(Name = "醫學中心;一般門診僅開立藥品;中低收入註記(112.3 新增)")]
            [Description("A1P")]
            MedicalCenter_Outpatient_OnlyMedicines_MiddleLowIncome,

            /// <summary>
            /// 醫學中心;一般門診加藥品或復健;中低收入註記(112.3 新增)
            /// A2P
            /// </summary>
            [Display(Name = "醫學中心;一般門診加藥品或復健;中低收入註記(112.3 新增)")]
            [Description("A2P")]
            MedicalCenter_Outpatient_MedicinesOrRehabilitation_MiddleLowIncome,

            /// <summary>
            /// 醫學中心;轉診(轉入之院所適用);中低收入註記(112.3 新增)
            /// A3P
            /// </summary>
            [Display(Name = "醫學中心;轉診(轉入之院所適用);中低收入註記(112.3 新增)")]
            [Description("A3P")]
            MedicalCenter_Referrals_MiddleLowIncome,

            /// <summary>
            /// 醫學中心;住院出院或門、急診手術後首次之回診加藥品或復健;中低收入註記(112.3 新增)
            /// A4P
            /// </summary>
            [Display(Name = "醫學中心;住院出院或門、急診手術後首次之回診加藥品或復健;中低收入註記(112.3 新增)")]
            [Description("A4P")]
            MedicalCenter_FirstFollowUp_MedicinesOrRehabilitation_MiddleLowIncome,

            /// <summary>
            /// 醫學中心;藥品
            /// A14
            /// </summary>
            [Display(Name = "醫學中心;藥品")]
            [Description("A14")]
            MedicalCenter_Medicines,

            /// <summary>
            /// 醫學中心;藥品;持殘障手冊
            /// A17
            /// </summary>
            [Display(Name = "醫學中心;藥品;持殘障手冊")]
            [Description("A17")]
            MedicalCenter_Medicines_WithHandicapHandbook,

            /// <summary>
            /// 醫學中心;藥品.復健
            /// A24
            /// </summary>
            [Display(Name = "醫學中心;藥品.復健")]
            [Description("A24")]
            MedicalCenter_Medicines_Rehabilitation,

            /// <summary>
            /// 醫學中心;藥品.復健;持殘障手冊
            /// A27
            /// </summary>
            [Display(Name = "醫學中心;藥品.復健;持殘障手冊")]
            [Description("A27")]
            MedicalCenter_Medicines_RehabilitationWithHandicapHandbook,

            /// <summary>
            /// 醫學中心轉診;復健;持殘障手冊
            /// A33
            /// </summary>
            [Display(Name = "醫學中心轉診;復健;持殘障手冊")]
            [Description("A33")]
            MedicalCenter_Transfer_RehabilitationWithHandicapHandbook,

            /// <summary>
            /// 醫學中心轉診;藥品.復健
            /// A34
            /// </summary>
            [Display(Name = "醫學中心轉診;藥品.復健")]
            [Description("A34")]
            MedicalCenter_Transfer_Medicines_Rehabilitation,

            /// <summary>
            /// 醫學中心轉診;藥品.復健;持殘障手冊
            /// A37
            /// </summary>
            [Display(Name = "醫學中心轉診;藥品.復健;持殘障手冊")]
            [Description("A37")]
            MedicalCenter_Transfer_Medicines_RehabilitationWithHandicapHandbook,

            /// <summary>
            /// 醫學中心回診;復健;持殘障手冊
            /// A43
            /// </summary>
            [Display(Name = "醫學中心回診;復健;持殘障手冊")]
            [Description("A43")]
            MedicalCenter_Return_RehabilitationWithHandicapHandbook,

            /// <summary>
            /// 醫學中心回診;藥品.復健
            /// A44
            /// </summary>
            [Display(Name = "醫學中心回診;藥品.復健")]
            [Description("A44")]
            MedicalCenter_Return_Medicines_Rehabilitation,

            /// <summary>
            /// 醫學中心回診;藥品.復健;持殘障手冊
            /// A47
            /// </summary>
            [Display(Name = "醫學中心回診;藥品.復健;持殘障手冊")]
            [Description("A47")]
            MedicalCenter_Return_Medicines_RehabilitationWithHandicapHandbook
        }

        /// <summary>
        /// 身分別-優待類別
        /// </summary>
        public enum VipType
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("")]
            None,
            /// <summary>
            /// 門診低收入戶及志工掛號費10元、診察費優免
            /// </summary>
            [Display(Name = "門診低收入戶及志工掛號費10元、診察費優免")]
            [Description("002")]
            _002,

            /// <summary>
            /// 門診低收入戶掛號費優免
            /// </summary>
            [Display(Name = "門診低收入戶掛號費優免")]
            [Description("003")]
            _003,

            /// <summary>
            /// 門診軍眷(一般)
            /// </summary>
            [Display(Name = "門診軍眷(一般)")]
            [Description("01")]
            _01,

            /// <summary>
            /// 門診撫卹令（眷屬）
            /// </summary>
            [Display(Name = "門診撫卹令（眷屬）")]
            [Description("01A")]
            _01A,

            /// <summary>
            /// 軍眷減量
            /// </summary>
            [Display(Name = "軍眷減量")]
            [Description("01D")]
            _01D,

            /// <summary>
            /// 門診軍眷台北市兒童
            /// </summary>
            [Display(Name = "門診軍眷台北市兒童")]
            [Description("02")]
            _02,

            /// <summary>
            /// 臺北巿軍眷兒童第二類輪狀病毒疫苗及常規苗(優免2070元、掛號費0元)
            /// </summary>
            [Display(Name = "臺北巿軍眷兒童第二類輪狀病毒疫苗及常規苗(優免2070元、掛號費0元)")]
            [Description("02B")]
            _02B,

            /// <summary>
            /// 臺北巿軍眷兒童第一、三類輪狀病毒疫苗及常規苗(優免1050元、掛號費0元)
            /// </summary>
            [Display(Name = "臺北巿軍眷兒童第一、三類輪狀病毒疫苗及常規苗(優免1050元、掛號費0元)")]
            [Description("02R")]
            _02R,

            /// <summary>
            /// 門診一般台北市兒童
            /// </summary>
            [Display(Name = "門診一般台北市兒童")]
            [Description("03")]
            _03,

            /// <summary>
            /// 北巿未滿12歲(重症/罕病)兒童
            /// </summary>
            [Display(Name = "北巿未滿12歲(重症/罕病)兒童")]
            [Description("03A")]
            _03A,

            /// <summary>
            /// 臺北巿一般兒童兒補第二類輪狀病毒疫苗(優免2070元、掛號費50元)
            /// </summary>
            [Display(Name = "臺北巿一般兒童兒補第二類輪狀病毒疫苗(優免2070元、掛號費50元)")]
            [Description("03B")]
            _03B,

            /// <summary>
            /// 北市未滿2歲(極低體重)兒童
            /// </summary>
            [Display(Name = "北市未滿2歲(極低體重)兒童")]
            [Description("03C")]
            _03C,

            /// <summary>
            /// 臺北巿一般兒童第一類輪狀病毒疫苗及常規苗(優免1050元、掛號費50元)
            /// </summary>
            [Display(Name = "臺北巿一般兒童第一類輪狀病毒疫苗及常規苗(優免1050元、掛號費50元)")]
            [Description("03R")]
            _03R,

            /// <summary>
            /// 門急診一般僑保
            /// </summary>
            [Display(Name = "門急診一般僑保")]
            [Description("04")]
            _04,

            /// <summary>
            /// 門急診國防醫學院僑保
            /// </summary>
            [Display(Name = "門急診國防醫學院僑保")]
            [Description("05")]
            _05,

            /// <summary>
            /// 軍眷藥品、衛材自費，其他費用優免
            /// </summary>
            [Display(Name = "軍眷藥品、衛材自費，其他費用優免")]
            [Description("09")]
            _09,

            /// <summary>
            /// 現役將級
            /// </summary>
            [Display(Name = "現役將級")]
            [Description("10")]
            _10,

            /// <summary>
            /// 疾管局藥癮記帳
            /// </summary>
            [Display(Name = "疾管局藥癮記帳")]
            [Description("100")]
            _100,

            /// <summary>
            /// 台北地檢署緩起訴藥癮記帳
            /// </summary>
            [Display(Name = "台北地檢署緩起訴藥癮記帳")]
            [Description("101")]
            _101,

            /// <summary>
            /// 士林地檢署緩起訴藥癮記帳
            /// </summary>
            [Display(Name = "士林地檢署緩起訴藥癮記帳")]
            [Description("102")]
            _102,

            /// <summary>
            /// 大陸來台觀光受傷人士(無優免)
            /// </summary>
            [Display(Name = "大陸來台觀光受傷人士(無優免)")]
            [Description("103")]
            _103,

            /// <summary>
            /// 台北巿禽畜業者發燒優免掛號費、部份負擔費用
            /// </summary>
            [Display(Name = "台北巿禽畜業者發燒優免掛號費、部份負擔費用")]
            [Description("104")]
            _104,

            /// <summary>
            /// 疾管局美沙冬特殊篩檢記帳
            /// </summary>
            [Display(Name = "疾管局美沙冬特殊篩檢記帳")]
            [Description("105")]
            _105,

            /// <summary>
            /// 台北巿孕婦唐氏症篩檢(軍人)
            /// </summary>
            [Display(Name = "台北巿孕婦唐氏症篩檢(軍人)")]
            [Description("106")]
            _106,

            /// <summary>
            /// 台北巿孕婦唐氏症篩檢(軍眷、員工--紅)
            /// </summary>
            [Display(Name = "台北巿孕婦唐氏症篩檢(軍眷、員工--紅)")]
            [Description("107")]
            _107,

            /// <summary>
            /// 台北巿孕婦唐氏症篩檢(福保、員工(綠、藍)、國軍聘雇)
            /// </summary>
            [Display(Name = "台北巿孕婦唐氏症篩檢(福保、員工(綠、藍)、國軍聘雇)")]
            [Description("108")]
            _108,

            /// <summary>
            /// 台北巿孕婦唐氏症篩檢(民眾)
            /// </summary>
            [Display(Name = "台北巿孕婦唐氏症篩檢(民眾)")]
            [Description("109")]
            _109,

            /// <summary>
            /// 現役將級眷屬
            /// </summary>
            [Display(Name = "現役將級眷屬")]
            [Description("11")]
            _11,

            /// <summary>
            /// 門診綠色通行證優免
            /// </summary>
            [Display(Name = "門診綠色通行證優免")]
            [Description("110")]
            _110,

            /// <summary>
            /// 孕婦唐氏症篩檢(里民)
            /// </summary>
            [Display(Name = "孕婦唐氏症篩檢(里民)")]
            [Description("112")]
            _112,

            /// <summary>
            /// 孕婦唐氏症篩檢(榮民、備役眷)
            /// </summary>
            [Display(Name = "孕婦唐氏症篩檢(榮民、備役眷)")]
            [Description("113")]
            _113,

            /// <summary>
            /// 內湖區湖興里、寶湖里、石潭里民優免
            /// </summary>
            [Display(Name = "內湖區湖興里、寶湖里、石潭里民優免")]
            [Description("114")]
            _114,

            /// <summary>
            /// 中正區富水里、文盛里、水源里、林興里民優免
            /// </summary>
            [Display(Name = "中正區富水里、文盛里、水源里、林興里民優免")]
            [Description("115")]
            _115,

            /// <summary>
            /// 里民診察費優免
            /// </summary>
            [Display(Name = "里民診察費優免")]
            [Description("116")]
            _116,

            /// <summary>
            /// 孕婦唐氏症篩檢(國軍聘雇)
            /// </summary>
            [Display(Name = "孕婦唐氏症篩檢(國軍聘雇)")]
            [Description("117")]
            _117,

            /// <summary>
            /// 國健局羊膜穿刺補助
            /// </summary>
            [Display(Name = "國健局羊膜穿刺補助")]
            [Description("118")]
            _118,

            /// <summary>
            /// 門診藍色通行證優免
            /// </summary>
            [Display(Name = "門診藍色通行證優免")]
            [Description("119")]
            _119,

            /// <summary>
            /// -10元(福保、國防校友、志工)國健局羊膜穿刺補助
            /// </summary>
            [Display(Name = "-10元(福保、國防校友、志工)國健局羊膜穿刺補助")]
            [Description("11A")]
            _11A,

            /// <summary>
            /// -20元(備役、中研院員工)國健局羊膜穿刺補助
            /// </summary>
            [Display(Name = "-20元(備役、中研院員工)國健局羊膜穿刺補助")]
            [Description("11B")]
            _11B,

            /// <summary>
            /// -50元(里民)國健局羊膜穿刺補助
            /// </summary>
            [Display(Name = "-50元(里民)國健局羊膜穿刺補助")]
            [Description("11C")]
            _11C,

            /// <summary>
            /// 合作學校優免門診掛號費50元(14所)
            /// </summary>
            [Display(Name = "合作學校優免門診掛號費50元(14所)")]
            [Description("11S")]
            _11S,

            /// <summary>
            /// 駐外使節(具退將)
            /// </summary>
            [Display(Name = "駐外使節(具退將)")]
            [Description("12")]
            _12,

            /// <summary>
            /// 外籍人士
            /// </summary>
            [Display(Name = "外籍人士")]
            [Description("121")]
            _121,

            /// <summary>
            /// 外籍勞工
            /// </summary>
            [Display(Name = "外籍勞工")]
            [Description("122")]
            _122,

            /// <summary>
            /// 員工B肝疫苗全額記帳
            /// </summary>
            [Display(Name = "員工B肝疫苗全額記帳")]
            [Description("123")]
            _123,

            /// <summary>
            /// 學生B肝疫苗全額記帳
            /// </summary>
            [Display(Name = "學生B肝疫苗全額記帳")]
            [Description("124")]
            _124,

            /// <summary>
            /// 國健局羊膜穿刺補助(軍眷、本院員工、榮民)
            /// </summary>
            [Display(Name = "國健局羊膜穿刺補助(軍眷、本院員工、榮民)")]
            [Description("125")]
            _125,

            /// <summary>
            /// 居家長照低收入戶優免
            /// </summary>
            [Display(Name = "居家長照低收入戶優免")]
            [Description("126")]
            _126,

            /// <summary>
            /// 居家長照中低收入戶優免
            /// </summary>
            [Display(Name = "居家長照中低收入戶優免")]
            [Description("127")]
            _127,

            /// <summary>
            /// 居家長照一般戶優免
            /// </summary>
            [Display(Name = "居家長照一般戶優免")]
            [Description("128")]
            _128,

            /// <summary>
            /// 員榮醫院國際病人
            /// </summary>
            [Display(Name = "員榮醫院國際病人")]
            [Description("12A")]
            _12A,

            /// <summary>
            /// 自行就醫無健保國際病人
            /// </summary>
            [Display(Name = "自行就醫無健保國際病人")]
            [Description("12B")]
            _12B,

            /// <summary>
            /// 員榮醫院國際病人(第二意見諮詢費)
            /// </summary>
            [Display(Name = "員榮醫院國際病人(第二意見諮詢費)")]
            [Description("12C")]
            _12C,

            /// <summary>
            /// 駐外使節眷屬
            /// </summary>
            [Display(Name = "駐外使節眷屬")]
            [Description("13")]
            _13,

            /// <summary>
            /// 藥癮補助計畫對象
            /// </summary>
            [Display(Name = "藥癮補助計畫對象")]
            [Description("132")]
            _132,

            /// <summary>
            /// 酒癮補助計畫對象
            /// </summary>
            [Display(Name = "酒癮補助計畫對象")]
            [Description("133")]
            _133,

            /// <summary>
            /// 萬華篩檢專案
            /// </summary>
            [Display(Name = "萬華篩檢專案")]
            [Description("135")]
            _135,

            /// <summary>
            /// 外國使節
            /// </summary>
            [Display(Name = "外國使節")]
            [Description("14")]
            _14,

            /// <summary>
            /// 外國使節眷屬
            /// </summary>
            [Display(Name = "外國使節眷屬")]
            [Description("15")]
            _15,

            /// <summary>
            /// 一級上將
            /// </summary>
            [Display(Name = "一級上將")]
            [Description("16")]
            _16,

            /// <summary>
            /// 退將夫人
            /// </summary>
            [Display(Name = "退將夫人")]
            [Description("17")]
            _17,

            /// <summary>
            /// 院內員工(門診優免)
            /// </summary>
            [Display(Name = "院內員工(門診優免)")]
            [Description("18")]
            _18,

            /// <summary>
            /// 員工眷屬門急診掛號費優免
            /// </summary>
            [Display(Name = "員工眷屬門急診掛號費優免")]
            [Description("181")]
            _181,

            /// <summary>
            /// 門診員工員眷義齒治療
            /// </summary>
            [Display(Name = "門診員工員眷義齒治療")]
            [Description("182")]
            _182,

            /// <summary>
            /// 三總之友證門急診掛號費優免
            /// </summary>
            [Display(Name = "三總之友證門急診掛號費優免")]
            [Description("183")]
            _183,

            /// <summary>
            /// 員工減量
            /// </summary>
            [Display(Name = "員工減量")]
            [Description("18D")]
            _18D,

            /// <summary>
            /// 民眾減量
            /// </summary>
            [Display(Name = "民眾減量")]
            [Description("20D")]
            _20D,

            /// <summary>
            /// 門診牙科軍眷費用優免
            /// </summary>
            [Display(Name = "門診牙科軍眷費用優免")]
            [Description("23")]
            _23,

            /// <summary>
            /// 永和區:竹林里、福林里、永福里、河濱里民優免
            /// </summary>
            [Display(Name = "永和區:竹林里、福林里、永福里、河濱里民優免")]
            [Description("234")]
            _234,

            /// <summary>
            /// 門診百歲人瑞
            /// </summary>
            [Display(Name = "門診百歲人瑞")]
            [Description("25")]
            _25,

            /// <summary>
            /// 門診台北市老人健康檢查
            /// </summary>
            [Display(Name = "門診台北市老人健康檢查")]
            [Description("26")]
            _26,

            /// <summary>
            /// 門診研究病房GCRC(W75)
            /// </summary>
            [Display(Name = "門診研究病房GCRC(W75)")]
            [Description("27")]
            _27,

            /// <summary>
            /// 門診民眾營養諮詢(含小兒)
            /// </summary>
            [Display(Name = "門診民眾營養諮詢(含小兒)")]
            [Description("28")]
            _28,

            /// <summary>
            /// 門診軍眷營養諮詢(含小兒)
            /// </summary>
            [Display(Name = "門診軍眷營養諮詢(含小兒)")]
            [Description("29")]
            _29,

            /// <summary>
            /// 軍眷-牙科自費治療
            /// </summary>
            [Display(Name = "軍眷-牙科自費治療")]
            [Description("30")]
            _30,

            /// <summary>
            /// 民眾-牙科自費治療
            /// </summary>
            [Display(Name = "民眾-牙科自費治療")]
            [Description("31")]
            _31,

            /// <summary>
            /// 門診健保產檢加掛婦科
            /// </summary>
            [Display(Name = "門診健保產檢加掛婦科")]
            [Description("32")]
            _32,

            /// <summary>
            /// 門診民眾兒童預防保健
            /// </summary>
            [Display(Name = "門診民眾兒童預防保健")]
            [Description("33")]
            _33,

            /// <summary>
            /// 門診軍眷預防保健(20D)
            /// </summary>
            [Display(Name = "門診軍眷預防保健(20D)")]
            [Description("34")]
            _34,

            /// <summary>
            /// 臺北巿軍眷兒童第二類輪狀病毒疫苗及常規苗(優免2070元、掛號費0元)
            /// </summary>
            [Display(Name = "臺北巿軍眷兒童第二類輪狀病毒疫苗及常規苗(優免2070元、掛號費0元)")]
            [Description("34B")]
            _34B,

            /// <summary>
            /// 臺北巿軍眷兒童第一、三類輪狀病毒疫苗及常規苗(優免1050元、掛號費0元)
            /// </summary>
            [Display(Name = "臺北巿軍眷兒童第一、三類輪狀病毒疫苗及常規苗(優免1050元、掛號費0元)")]
            [Description("34R")]
            _34R,

            /// <summary>
            /// 北巿/新北巿性侵害加害人(採血液檢體)
            /// </summary>
            [Display(Name = "北巿/新北巿性侵害加害人(採血液檢體)")]
            [Description("37")]
            _37,

            /// <summary>
            /// 門診榮民掛號費0元
            /// </summary>
            [Display(Name = "門診榮民掛號費0元")]
            [Description("38")]
            _38,

            /// <summary>
            /// 榮民掛號費0元/診察費0元
            /// </summary>
            [Display(Name = "榮民掛號費0元/診察費0元")]
            [Description("381")]
            _381,

            /// <summary>
            /// 備眷配偶掛號費0元/診察費0元
            /// </summary>
            [Display(Name = "備眷配偶掛號費0元/診察費0元")]
            [Description("382")]
            _382,

            /// <summary>
            /// 備眷父母、子女掛號費10元/診察費0元
            /// </summary>
            [Display(Name = "備眷父母、子女掛號費10元/診察費0元")]
            [Description("383")]
            _383,

            /// <summary>
            /// 門診撫卹令本人掛號費0元
            /// </summary>
            [Display(Name = "門診撫卹令本人掛號費0元")]
            [Description("38C")]
            _38C,

            /// <summary>
            /// 門診後備軍人輔導幹部本人
            /// </summary>
            [Display(Name = "門診後備軍人輔導幹部本人")]
            [Description("38F")]
            _38F,

            /// <summary>
            /// 新進員工體檢
            /// </summary>
            [Display(Name = "新進員工體檢")]
            [Description("39")]
            _39,

            /// <summary>
            /// 將檢病患
            /// </summary>
            [Display(Name = "將檢病患")]
            [Description("40")]
            _40,

            /// <summary>
            /// 汐止防疫門診掛號費優免20元
            /// </summary>
            [Display(Name = "汐止防疫門診掛號費優免20元")]
            [Description("403")]
            _403,

            /// <summary>
            /// 松山防疫門診收費500元
            /// </summary>
            [Display(Name = "松山防疫門診收費500元")]
            [Description("405")]
            _405,

            /// <summary>
            /// 掛號費、部份負擔優免
            /// </summary>
            [Display(Name = "掛號費、部份負擔優免")]
            [Description("41")]
            _41,

            /// <summary>
            /// 北市老人(糖)眼科檢查優免
            /// </summary>
            [Display(Name = "北市老人(糖)眼科檢查優免")]
            [Description("411")]
            _411,

            /// <summary>
            /// 北巿學童高度近視防治計畫補助
            /// </summary>
            [Display(Name = "北巿學童高度近視防治計畫補助")]
            [Description("412")]
            _412,

            /// <summary>
            /// 北市一年級、二年級學童窩溝封填防齲計畫補助
            /// </summary>
            [Display(Name = "北市一年級、二年級學童窩溝封填防齲計畫補助")]
            [Description("413")]
            _413,

            /// <summary>
            /// 北巿二年級學童窩溝封填防齲計畫_掛號費記帳
            /// </summary>
            [Display(Name = "北巿二年級學童窩溝封填防齲計畫_掛號費記帳")]
            [Description("414")]
            _414,

            /// <summary>
            /// 部份負擔優免
            /// </summary>
            [Display(Name = "部份負擔優免")]
            [Description("42")]
            _42,

            /// <summary>
            /// 預防保健及水痘優免
            /// </summary>
            [Display(Name = "預防保健及水痘優免")]
            [Description("43")]
            _43,

            /// <summary>
            /// 軍眷預防保健及水痘優免
            /// </summary>
            [Display(Name = "軍眷預防保健及水痘優免")]
            [Description("44")]
            _44,

            /// <summary>
            /// 北巿民眾兒童水痘優免
            /// </summary>
            [Display(Name = "北巿民眾兒童水痘優免")]
            [Description("45")]
            _45,

            /// <summary>
            /// 軍眷北巿民眾兒童水痘優免
            /// </summary>
            [Display(Name = "軍眷北巿民眾兒童水痘優免")]
            [Description("46")]
            _46,

            /// <summary>
            /// 診察費優免
            /// </summary>
            [Display(Name = "診察費優免")]
            [Description("47")]
            _47,

            /// <summary>
            /// 軍眷、本院眷,1歲以下兒童常規疫苗(掛號費0元、診察費優免)
            /// </summary>
            [Display(Name = "軍眷、本院眷,1歲以下兒童常規疫苗(掛號費0元、診察費優免)")]
            [Description("470")]
            _470,

            /// <summary>
            /// 一般民眾,1歲以下兒童常規疫苗(掛號費100元、診察費優免)
            /// </summary>
            [Display(Name = "一般民眾,1歲以下兒童常規疫苗(掛號費100元、診察費優免)")]
            [Description("471")]
            _471,

            /// <summary>
            /// 備役,1歲以下兒童常規疫苗(掛號費10元、診察費優免)
            /// </summary>
            [Display(Name = "備役,1歲以下兒童常規疫苗(掛號費10元、診察費優免)")]
            [Description("472")]
            _472,

            /// <summary>
            /// 里民,1歲以下兒童常規疫苗(掛號費50元、診察費優免)
            /// </summary>
            [Display(Name = "里民,1歲以下兒童常規疫苗(掛號費50元、診察費優免)")]
            [Description("473")]
            _473,

            /// <summary>
            /// 低收入,1歲以下兒童常規疫苗(掛號費10元，診察費優免)
            /// </summary>
            [Display(Name = "低收入,1歲以下兒童常規疫苗(掛號費10元，診察費優免)")]
            [Description("474")]
            _474,

            /// <summary>
            /// 軍眷、本院眷, 臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費0元)
            /// </summary>
            [Display(Name = "軍眷、本院眷, 臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費0元)")]
            [Description("480")]
            _480,

            /// <summary>
            /// 一般民眾、臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費100元)
            /// </summary>
            [Display(Name = "一般民眾、臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費100元)")]
            [Description("481")]
            _481,

            /// <summary>
            /// 備役、臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費10元)
            /// </summary>
            [Display(Name = "備役、臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費10元)")]
            [Description("482")]
            _482,

            /// <summary>
            /// 里民、臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費50元)
            /// </summary>
            [Display(Name = "里民、臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費50元)")]
            [Description("483")]
            _483,

            /// <summary>
            /// 低收入、臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費10元)
            /// </summary>
            [Display(Name = "低收入、臺北巿兒補第一、三類輪狀病毒疫苗(優免1050元、掛號費10元)")]
            [Description("484")]
            _484,

            /// <summary>
            /// 軍眷、本院眷, 臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費0元)
            /// </summary>
            [Display(Name = "軍眷、本院眷, 臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費0元)")]
            [Description("490")]
            _490,

            /// <summary>
            /// 一般民眾、臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費100元)
            /// </summary>
            [Display(Name = "一般民眾、臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費100元)")]
            [Description("491")]
            _491,

            /// <summary>
            /// 備役、臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費10元)
            /// </summary>
            [Display(Name = "備役、臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費10元)")]
            [Description("492")]
            _492,

            /// <summary>
            /// 里民、臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費50元)
            /// </summary>
            [Display(Name = "里民、臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費50元)")]
            [Description("493")]
            _493,

            /// <summary>
            /// 低收入、臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費10元)
            /// </summary>
            [Display(Name = "低收入、臺北巿兒補第二類輪狀病毒疫苗(優免2070元、掛號費10元)")]
            [Description("494")]
            _494,

            /// <summary>
            /// 門診國軍編制內聘雇人員(軍聘雇)優免
            /// </summary>
            [Display(Name = "門診國軍編制內聘雇人員(軍聘雇)優免")]
            [Description("50")]
            _50,

            /// <summary>
            /// 門診國軍單位內員工(民聘雇)優免
            /// </summary>
            [Display(Name = "門診國軍單位內員工(民聘雇)優免")]
            [Description("50A")]
            _50A,

            /// <summary>
            /// 門診國防部文職人員
            /// </summary>
            [Display(Name = "門診國防部文職人員")]
            [Description("50B")]
            _50B,

            /// <summary>
            /// 門診國防部文職人員（眷屬）
            /// </summary>
            [Display(Name = "門診國防部文職人員（眷屬）")]
            [Description("50C")]
            _50C,

            /// <summary>
            /// 門診國防醫學院碩博士班非軍費研究生優免
            /// </summary>
            [Display(Name = "門診國防醫學院碩博士班非軍費研究生優免")]
            [Description("50D")]
            _50D,

            /// <summary>
            /// 門診持現役軍人眷屬特准證掛號費優免
            /// </summary>
            [Display(Name = "門診持現役軍人眷屬特准證掛號費優免")]
            [Description("50E")]
            _50E,

            /// <summary>
            /// 門診警察局內湖分局員警本人優免
            /// </summary>
            [Display(Name = "門診警察局內湖分局員警本人優免")]
            [Description("50F")]
            _50F,

            /// <summary>
            /// 門診持榮譽證本人掛號費優免
            /// </summary>
            [Display(Name = "門診持榮譽證本人掛號費優免")]
            [Description("50G")]
            _50G,

            /// <summary>
            /// 非在營後備戰士本人-門急診掛號費優免
            /// </summary>
            [Display(Name = "非在營後備戰士本人-門急診掛號費優免")]
            [Description("50H")]
            _50H,

            /// <summary>
            /// 14天召集訓練後一年內之後備軍人-門急診掛號費優免
            /// </summary>
            [Display(Name = "14天召集訓練後一年內之後備軍人-門急診掛號費優免")]
            [Description("50I")]
            _50I,

            /// <summary>
            /// 門診警察局中正二分局員警本人優免
            /// </summary>
            [Display(Name = "門診警察局中正二分局員警本人優免")]
            [Description("51")]
            _51,

            /// <summary>
            /// 門診消防局中正二分局隊員本人優免(古亭泉州忠孝城中華山分隊)
            /// </summary>
            [Display(Name = "門診消防局中正二分局隊員本人優免(古亭泉州忠孝城中華山分隊)")]
            [Description("51A")]
            _51A,

            /// <summary>
            /// 門診消防局內湖分局隊員本人優免(大湖內湖東湖民權分隊）
            /// </summary>
            [Display(Name = "門診消防局內湖分局隊員本人優免(大湖內湖東湖民權分隊")]
            [Description("51B")]
            _51B,

            /// <summary>
            /// 門診北巿替代役中 心職員及替代役男
            /// </summary>
            [Display(Name = "門診北巿替代役中 心職員及替代役男")]
            [Description("51C")]
            _51C,

            /// <summary>
            /// 門診軍眷(居家)優免
            /// </summary>
            [Display(Name = "門診軍眷(居家)優免")]
            [Description("55")]
            _55,

            /// <summary>
            /// 掛號費優免
            /// </summary>
            [Display(Name = "掛號費優免")]
            [Description("56")]
            _56,

            /// <summary>
            /// 新陳代謝科洗牙轉介單-優免100元(掛號費)
            /// </summary>
            [Display(Name = "新陳代謝科洗牙轉介單-優免100元(掛號費)")]
            [Description("561")]
            _561,

            /// <summary>
            /// 婦產科洗牙轉介單-優免100元(掛號費)
            /// </summary>
            [Display(Name = "婦產科洗牙轉介單-優免100元(掛號費)")]
            [Description("562")]
            _562,

            /// <summary>
            /// 社區保健轉診病人掛號費優免
            /// </summary>
            [Display(Name = "社區保健轉診病人掛號費優免")]
            [Description("566")]
            _566,

            /// <summary>
            /// 全額優免
            /// </summary>
            [Display(Name = "全額優免")]
            [Description("57")]
            _57,

            /// <summary>
            /// 全額計帳，暫不付費
            /// </summary>
            [Display(Name = "全額計帳，暫不付費")]
            [Description("577")]
            _577,

            /// <summary>
            /// 北巿計程車體檢優免
            /// </summary>
            [Display(Name = "北巿計程車體檢優免")]
            [Description("58")]
            _58,

            /// <summary>
            /// 原委會核能體檢
            /// </summary>
            [Display(Name = "原委會核能體檢")]
            [Description("59")]
            _59,

            /// <summary>
            /// 健檢優免
            /// </summary>
            [Display(Name = "健檢優免")]
            [Description("62")]
            _62,

            /// <summary>
            /// 替代役男優免
            /// </summary>
            [Display(Name = "替代役男優免")]
            [Description("63")]
            _63,

            /// <summary>
            /// 研發替代男優免
            /// </summary>
            [Display(Name = "研發替代男優免")]
            [Description("633")]
            _633,

            /// <summary>
            /// 門診志工優免
            /// </summary>
            [Display(Name = "門診志工優免")]
            [Description("64")]
            _64,

            /// <summary>
            /// 志工義齒優免
            /// </summary>
            [Display(Name = "志工義齒優免")]
            [Description("641")]
            _641,

            /// <summary>
            /// 法務部體檢
            /// </summary>
            [Display(Name = "法務部體檢")]
            [Description("65")]
            _65,

            /// <summary>
            /// 兵役複檢
            /// </summary>
            [Display(Name = "兵役複檢")]
            [Description("66")]
            _66,

            /// <summary>
            /// 汀州院區兵役複檢
            /// </summary>
            [Display(Name = "汀州院區兵役複檢")]
            [Description("66A")]
            _66A,

            /// <summary>
            /// 新兵驗退
            /// </summary>
            [Display(Name = "新兵驗退")]
            [Description("67")]
            _67,

            /// <summary>
            /// 後備軍人停役
            /// </summary>
            [Display(Name = "後備軍人停役")]
            [Description("68")]
            _68,

            /// <summary>
            /// 軍人優免
            /// </summary>
            [Display(Name = "軍人優免")]
            [Description("69")]
            _69,

            /// <summary>
            /// 癌症專用優免
            /// </summary>
            [Display(Name = "癌症專用優免")]
            [Description("70")]
            _70,

            /// <summary>
            /// 軍人-牙科自費治療或營養諮詢(掛號費+診察費優免)
            /// </summary>
            [Display(Name = "軍人-牙科自費治療或營養諮詢(掛號費+診察費優免)")]
            [Description("700")]
            _700,

            /// <summary>
            /// 肺癌學會計劃-低劑量電腦斷層肺癌篩檢記帳
            /// </summary>
            [Display(Name = "肺癌學會計劃-低劑量電腦斷層肺癌篩檢記帳")]
            [Description("701")]
            _701,

            /// <summary>
            /// 肺癌學會計劃-...肺癌篩檢記帳(軍眷/本院員工/榮民不收費)
            /// </summary>
            [Display(Name = "肺癌學會計劃-...肺癌篩檢記帳(軍眷/本院員工/榮民不收費)")]
            [Description("702")]
            _702,

            /// <summary>
            /// 肺癌學會計劃-...肺癌篩檢記帳(福保/國軍聘雇收10元)
            /// </summary>
            [Display(Name = "肺癌學會計劃-...肺癌篩檢記帳(福保/國軍聘雇收10元)")]
            [Description("703")]
            _703,

            /// <summary>
            /// 肺癌學會計劃-...肺癌篩檢記帳(備眷收20元)
            /// </summary>
            [Display(Name = "肺癌學會計劃-...肺癌篩檢記帳(備眷收20元)")]
            [Description("704")]
            _704,

            /// <summary>
            /// 肺癌學會計劃-...肺癌篩檢記帳(里民收50元)
            /// </summary>
            [Display(Name = "肺癌學會計劃-...肺癌篩檢記帳(里民收50元)")]
            [Description("705")]
            _705,

            /// <summary>
            /// 肺癌學會計劃-...肺癌篩檢記帳(員工眷屬、榮譽證→收部份負擔費用)
            /// </summary>
            [Display(Name = "肺癌學會計劃-...肺癌篩檢記帳(員工眷屬、榮譽證→收部份負擔費用)")]
            [Description("706")]
            _706,

            /// <summary>
            /// 肺癌學會計劃-...肺癌篩檢記帳(檢查結果無異常個案部份負擔費用不收費)
            /// </summary>
            [Display(Name = "肺癌學會計劃-...肺癌篩檢記帳(檢查結果無異常個案部份負擔費用不收費)")]
            [Description("707")]
            _707,

            /// <summary>
            /// HER2-FISH檢測贊助計劃記帳
            /// </summary>
            [Display(Name = "HER2-FISH檢測贊助計劃記帳")]
            [Description("708")]
            _708,

            /// <summary>
            /// 國健署肺癌早期偵測計畫-計帳優免
            /// </summary>
            [Display(Name = "國健署肺癌早期偵測計畫-計帳優免")]
            [Description("709")]
            _709,

            /// <summary>
            /// 掛號費、診察費優免
            /// </summary>
            [Display(Name = "掛號費、診察費優免")]
            [Description("71")]
            _71,

            /// <summary>
            /// 幼稚園健檢優免
            /// </summary>
            [Display(Name = "幼稚園健檢優免")]
            [Description("72")]
            _72,

            /// <summary>
            /// 護理之家病患，掛號費優免
            /// </summary>
            [Display(Name = "護理之家病患，掛號費優免")]
            [Description("73")]
            _73,

            /// <summary>
            /// 軍人藥品、衛材自費、其他費用優免
            /// </summary>
            [Display(Name = "軍人藥品、衛材自費、其他費用優免")]
            [Description("74")]
            _74,

            /// <summary>
            /// 撫卹令（本人）掛號費0元
            /// </summary>
            [Display(Name = "撫卹令（本人）掛號費0元")]
            [Description("74A")]
            _74A,

            /// <summary>
            /// 軍事院校非軍費生優免
            /// </summary>
            [Display(Name = "軍事院校非軍費生優免")]
            [Description("74B")]
            _74B,

            /// <summary>
            /// 軍事訓練役
            /// </summary>
            [Display(Name = "軍事訓練役")]
            [Description("74C")]
            _74C,

            /// <summary>
            /// 軍人減量
            /// </summary>
            [Display(Name = "軍人減量")]
            [Description("74D")]
            _74D,

            /// <summary>
            /// 在營後備戰士本人
            /// </summary>
            [Display(Name = "在營後備戰士本人")]
            [Description("74E")]
            _74E,

            /// <summary>
            /// 現役軍人-角膜屈光雷射手術費用計帳
            /// </summary>
            [Display(Name = "現役軍人-角膜屈光雷射手術費用計帳")]
            [Description("74F")]
            _74F,

            /// <summary>
            /// 牙科軍人專案(限112.10.31前使用)
            /// </summary>
            [Display(Name = "牙科軍人專案(限112.10.31前使用)")]
            [Description("74G")]
            _74G,

            /// <summary>
            /// 設籍北巿流感-一般民眾(掛100元/診優100元)
            /// </summary>
            [Display(Name = "設籍北巿流感-一般民眾(掛100元/診優100元)")]
            [Description("75")]
            _75,

            /// <summary>
            /// 設籍北巿流感-員眷/榮民(掛0元/診優100元)
            /// </summary>
            [Display(Name = "設籍北巿流感-員眷/榮民(掛0元/診優100元)")]
            [Description("751")]
            _751,

            /// <summary>
            /// 設籍北巿流感-福保/國軍聘雇/警察/校友(掛10元/診優100元)
            /// </summary>
            [Display(Name = "設籍北巿流感-福保/國軍聘雇/警察/校友(掛10元/診優100元)")]
            [Description("752")]
            _752,

            /// <summary>
            /// 設籍北巿流感-備眷/中研院/台科大(掛20元/診優100元)
            /// </summary>
            [Display(Name = "設籍北巿流感-備眷/中研院/台科大(掛20元/診優100元)")]
            [Description("753")]
            _753,

            /// <summary>
            /// 設籍北巿流感-里民(掛50元/診優100元)
            /// </summary>
            [Display(Name = "設籍北巿流感-里民(掛50元/診優100元)")]
            [Description("754")]
            _754,

            /// <summary>
            /// 設籍北巿流感-軍人/軍眷(掛0元/診察費0元)
            /// </summary>
            [Display(Name = "設籍北巿流感-軍人/軍眷(掛0元/診察費0元)")]
            [Description("755")]
            _755,

            /// <summary>
            /// 卓越軍眷
            /// </summary>
            [Display(Name = "卓越軍眷")]
            [Description("77")]
            _77,

            /// <summary>
            /// 卓越員工
            /// </summary>
            [Display(Name = "卓越員工")]
            [Description("78")]
            _78,

            /// <summary>
            /// 卓越榮字號榮民
            /// </summary>
            [Display(Name = "卓越榮字號榮民")]
            [Description("80")]
            _80,

            /// <summary>
            /// 國軍官兵因公傷退伍、停役就醫
            /// </summary>
            [Display(Name = "國軍官兵因公傷退伍、停役就醫")]
            [Description("81")]
            _81,

            /// <summary>
            /// 施打疫苗只收藥劑費
            /// </summary>
            [Display(Name = "施打疫苗只收藥劑費")]
            [Description("82")]
            _82,

            /// <summary>
            /// 新移民配偶產前檢查
            /// </summary>
            [Display(Name = "新移民配偶產前檢查")]
            [Description("83")]
            _83,

            /// <summary>
            /// 新移民配偶產前檢查--優免特定健保費
            /// </summary>
            [Display(Name = "新移民配偶產前檢查--優免特定健保費")]
            [Description("833")]
            _833,

            /// <summary>
            /// 北巿新移民配偶產前檢查加唐氏症篩檢
            /// </summary>
            [Display(Name = "北巿新移民配偶產前檢查加唐氏症篩檢")]
            [Description("835")]
            _835,

            /// <summary>
            /// 新移民配偶避孕器裝置
            /// </summary>
            [Display(Name = "新移民配偶避孕器裝置")]
            [Description("84")]
            _84,

            /// <summary>
            /// 新移民配偶輸精管結紮
            /// </summary>
            [Display(Name = "新移民配偶輸精管結紮")]
            [Description("85")]
            _85,

            /// <summary>
            /// 門診國防校友優免掛號費
            /// </summary>
            [Display(Name = "門診國防校友優免掛號費")]
            [Description("86")]
            _86,

            /// <summary>
            /// 門診中研院員工優免掛號費
            /// </summary>
            [Display(Name = "門診中研院員工優免掛號費")]
            [Description("86B")]
            _86B,

            /// <summary>
            /// 門診台科大教職員
            /// </summary>
            [Display(Name = "門診台科大教職員")]
            [Description("86F")]
            _86F,

            /// <summary>
            /// 門診海洋大學教職員掛號費優免80元
            /// </summary>
            [Display(Name = "門診海洋大學教職員掛號費優免80元")]
            [Description("86H")]
            _86H,

            /// <summary>
            /// 本國籍無健保愛滋病(免檢查費及藥費)
            /// </summary>
            [Display(Name = "本國籍無健保愛滋病(免檢查費及藥費)")]
            [Description("87")]
            _87,

            /// <summary>
            /// 取消八仙樂園案件全額記帳
            /// </summary>
            [Display(Name = "取消八仙樂園案件全額記帳")]
            [Description("877")]
            _877,

            /// <summary>
            /// 他院代檢記帳
            /// </summary>
            [Display(Name = "他院代檢記帳")]
            [Description("88")]
            _88,

            /// <summary>
            /// 自費民眾身份藥品費用優免
            /// </summary>
            [Display(Name = "自費民眾身份藥品費用優免")]
            [Description("89")]
            _89,

            /// <summary>
            /// 自費軍眷身份藥品費用優免
            /// </summary>
            [Display(Name = "自費軍眷身份藥品費用優免")]
            [Description("90")]
            _90,

            /// <summary>
            /// 感染肝炎科優免
            /// </summary>
            [Display(Name = "感染肝炎科優免")]
            [Description("91")]
            _91,

            /// <summary>
            /// 公費PrEP計畫HIV檢驗費用減免
            /// </summary>
            [Display(Name = "公費PrEP計畫HIV檢驗費用減免")]
            [Description("91A")]
            _91A,

            /// <summary>
            /// 公費PrEP計畫Truvada20顆費用減免
            /// </summary>
            [Display(Name = "公費PrEP計畫Truvada20顆費用減免")]
            [Description("91B")]
            _91B,

            /// <summary>
            /// 公費PrEP計畫Truvada30顆費用減免
            /// </summary>
            [Display(Name = "公費PrEP計畫Truvada30顆費用減免")]
            [Description("91C")]
            _91C,

            /// <summary>
            /// 公費PrEP計畫(優免7910元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免7910元)")]
            [Description("91D")]
            _91D,

            /// <summary>
            /// 公費PrEP計畫(優免11705元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免11705元)")]
            [Description("91E")]
            _91E,

            /// <summary>
            /// 公費PrEP計畫(優免1436元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免1436元)")]
            [Description("91F")]
            _91F,

            /// <summary>
            /// 公費PrEP計畫(優免7996元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免7996元)")]
            [Description("91G")]
            _91G,

            /// <summary>
            /// 公費PrEP計畫(優免726元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免726元)")]
            [Description("91H")]
            _91H,

            /// <summary>
            /// 公費PrEP計畫(優免8316元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免8316元)")]
            [Description("91I")]
            _91I,

            /// <summary>
            /// 公費PrEP計畫(優免8566元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免8566元)")]
            [Description("91J")]
            _91J,

            /// <summary>
            /// 公費PrEP計畫(優免12111元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免12111元)")]
            [Description("91K")]
            _91K,

            /// <summary>
            /// 公費PrEP計畫(優免9026元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免9026元)")]
            [Description("91L")]
            _91L,

            /// <summary>
            /// 公費PrEP計畫(優免1536元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免1536元)")]
            [Description("91M")]
            _91M,

            /// <summary>
            /// 公費PrEP計畫(優免11791元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免11791元)")]
            [Description("91N")]
            _91N,

            /// <summary>
            /// 公費PrEP計畫(優免12361元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免12361元)")]
            [Description("91O")]
            _91O,

            /// <summary>
            /// 公費PrEP計畫(優免12921元)
            /// </summary>
            [Display(Name = "公費PrEP計畫(優免12921元)")]
            [Description("91P")]
            _91P,

            /// <summary>
            /// 門診設籍北巿第3胎以上兒童證明卡
            /// </summary>
            [Display(Name = "門診設籍北巿第3胎以上兒童證明卡")]
            [Description("92")]
            _92,

            /// <summary>
            /// 門診北市第三胎以上兒童暨社區轉診優免
            /// </summary>
            [Display(Name = "門診北市第三胎以上兒童暨社區轉診優免")]
            [Description("92A")]
            _92A,

            /// <summary>
            /// 臺北巿一般兒童兒補第二類輪狀病毒疫苗(優免2070元、掛號費50元)
            /// </summary>
            [Display(Name = "臺北巿一般兒童兒補第二類輪狀病毒疫苗(優免2070元、掛號費50元)")]
            [Description("92B")]
            _92B,

            /// <summary>
            /// 臺北巿一般兒童第三類輪狀病毒疫苗及常規苗(優免1050元、掛號費50元)
            /// </summary>
            [Display(Name = "臺北巿一般兒童第三類輪狀病毒疫苗及常規苗(優免1050元、掛號費50元)")]
            [Description("92R")]
            _92R,

            /// <summary>
            /// 門診備役軍人眷屬優免(配偶)
            /// </summary>
            [Display(Name = "門診備役軍人眷屬優免(配偶)")]
            [Description("94")]
            _94,

            /// <summary>
            /// 門診備役軍人眷屬優免(父母、子女)
            /// </summary>
            [Display(Name = "門診備役軍人眷屬優免(父母、子女)")]
            [Description("94A")]
            _94A,

            /// <summary>
            /// 急診備役軍人眷屬優免(父母、子女)
            /// </summary>
            [Display(Name = "急診備役軍人眷屬優免(父母、子女)")]
            [Description("95A")]
            _95A,

            /// <summary>
            /// 門診新北巿兒童醫療補助-低收入戶
            /// </summary>
            [Display(Name = "門診新北巿兒童醫療補助-低收入戶")]
            [Description("96A")]
            _96A,

            /// <summary>
            /// 門診新北巿兒童醫療補助-重大傷病
            /// </summary>
            [Display(Name = "門診新北巿兒童醫療補助-重大傷病")]
            [Description("96B")]
            _96B,

            /// <summary>
            /// 門診新北巿兒童醫療補助-罕見病病
            /// </summary>
            [Display(Name = "門診新北巿兒童醫療補助-罕見病病")]
            [Description("96C")]
            _96C,

            /// <summary>
            /// 門診新北巿兒童醫療補助-中低收入戶
            /// </summary>
            [Display(Name = "門診新北巿兒童醫療補助-中低收入戶")]
            [Description("96F")]
            _96F,

            /// <summary>
            /// 門診新北巿老人醫療補助-低收入戶
            /// </summary>
            [Display(Name = "門診新北巿老人醫療補助-低收入戶")]
            [Description("96G")]
            _96G,

            /// <summary>
            /// 門診新北巿55-65歲原住民醫療補助-低收入戶
            /// </summary>
            [Display(Name = "門診新北巿55-65歲原住民醫療補助-低收入戶")]
            [Description("96H")]
            _96H,

            /// <summary>
            /// 門診新北巿新希望關懷醫療補助
            /// </summary>
            [Display(Name = "門診新北巿新希望關懷醫療補助")]
            [Description("98")]
            _98,

            /// <summary>
            /// 新店監獄病人看診記帳
            /// </summary>
            [Display(Name = "新店監獄病人看診記帳")]
            [Description("99")]
            _99,

            /// <summary>
            /// 掛號費0元急診器捐費用五折優待
            /// </summary>
            [Display(Name = "掛號費0元急診器捐費用五折優待")]
            [Description("992")]
            _992,

            /// <summary>
            /// 臺北巿、一般民眾、兒補第二類輪狀病毒疫苗((需收診療費、優免2070元、掛號費100元)
            /// </summary>
            [Display(Name = "臺北巿、一般民眾、兒補第二類輪狀病毒疫苗((需收診療費、優免2070元、掛號費100元)")]
            [Description("B")]
            _B,

            /// <summary>
            /// 院部核定醫療費用八折(05、12)
            /// </summary>
            [Display(Name = "院部核定醫療費用八折(05、12)")]
            [Description("C00")]
            _C00,

            /// <summary>
            /// 院部核定醫療費用八折(05、12)及九折(24)
            /// </summary>
            [Display(Name = "院部核定醫療費用八折(05、12)及九折(24)")]
            [Description("C01")]
            _C01,

            /// <summary>
            /// 院部核定醫療費用七五折(04、05、12、13)及優免(21、25)
            /// </summary>
            [Display(Name = "院部核定醫療費用七五折(04、05、12、13)及優免(21、25)")]
            [Description("C02")]
            _C02,

            /// <summary>
            /// 院部核定醫療費用七折(05、12)及優免(21、25)
            /// </summary>
            [Display(Name = "院部核定醫療費用七折(05、12)及優免(21、25)")]
            [Description("C03")]
            _C03,

            /// <summary>
            /// 院部核定醫療費用五折(12)及優免(01、07、21)
            /// </summary>
            [Display(Name = "院部核定醫療費用五折(12)及優免(01、07、21)")]
            [Description("C04")]
            _C04,

            /// <summary>
            /// 院部核定醫療費用折扣29880(12)
            /// </summary>
            [Display(Name = "院部核定醫療費用折扣29880(12)")]
            [Description("C05")]
            _C05,

            /// <summary>
            /// 院部核定醫療費用折扣31078(12)
            /// </summary>
            [Display(Name = "院部核定醫療費用折扣31078(12)")]
            [Description("C06")]
            _C06,

            /// <summary>
            /// 院部核定醫療費用折扣27686(12)
            /// </summary>
            [Display(Name = "院部核定醫療費用折扣27686(12)")]
            [Description("C07")]
            _C07,

            /// <summary>
            /// 院部核定醫療費用九折(07、12)
            /// </summary>
            [Display(Name = "院部核定醫療費用九折(07、12)")]
            [Description("C09")]
            _C09,

            /// <summary>
            /// 普通取件5000元－自費篩檢COVID19
            /// </summary>
            [Display(Name = "普通取件5000元－自費篩檢COVID19")]
            [Description("C10")]
            _C10,

            /// <summary>
            /// 防疫政策4500元－自費篩檢COVID19
            /// </summary>
            [Display(Name = "防疫政策4500元－自費篩檢COVID19")]
            [Description("C11")]
            _C11,

            /// <summary>
            /// 防疫政策3500元－自費篩檢COVID19
            /// </summary>
            [Display(Name = "防疫政策3500元－自費篩檢COVID19")]
            [Description("C12")]
            _C12,

            /// <summary>
            /// 自費篩檢COVID19掛號費及診察費0元
            /// </summary>
            [Display(Name = "自費篩檢COVID19掛號費及診察費0元")]
            [Description("C19")]
            _C19,

            /// <summary>
            /// 團體10人自費篩檢COVID19優惠方案
            /// </summary>
            [Display(Name = "團體10人自費篩檢COVID19優惠方案")]
            [Description("C20")]
            _C20,

            /// <summary>
            /// 團體20人自費篩檢COVID19優惠方案
            /// </summary>
            [Display(Name = "團體20人自費篩檢COVID19優惠方案")]
            [Description("C21")]
            _C21,

            /// <summary>
            /// COVID19因公專案軍人優免
            /// </summary>
            [Display(Name = "COVID19因公專案軍人優免")]
            [Description("C22")]
            _C22,

            /// <summary>
            /// COVID19因公專案軍、民聘雇人員優免
            /// </summary>
            [Display(Name = "COVID19因公專案軍、民聘雇人員優免")]
            [Description("C23")]
            _C23,

            /// <summary>
            /// COVID19因公專案文職人員優免
            /// </summary>
            [Display(Name = "COVID19因公專案文職人員優免")]
            [Description("C24")]
            _C24,

            /// <summary>
            /// COVID19國外受訓學生全額優免
            /// </summary>
            [Display(Name = "COVID19國外受訓學生全額優免")]
            [Description("C25")]
            _C25,

            /// <summary>
            /// COVID19國內受訓學生優免3500元
            /// </summary>
            [Display(Name = "COVID19國內受訓學生優免3500元")]
            [Description("C26")]
            _C26,

            /// <summary>
            /// 預劃門診住院(含手術)之病人，入院前採檢
            /// </summary>
            [Display(Name = "預劃門診住院(含手術)之病人，入院前採檢")]
            [Description("C27")]
            _C27,

            /// <summary>
            /// 門診收住院病人之陪病者(第1位公費)
            /// </summary>
            [Display(Name = "門診收住院病人之陪病者(第1位公費)")]
            [Description("C28")]
            _C28,

            /// <summary>
            /// 急診住院病人陪病者(第1位公費)
            /// </summary>
            [Display(Name = "急診住院病人陪病者(第1位公費)")]
            [Description("C29")]
            _C29,

            /// <summary>
            /// 員工專案-列管員工採檢
            /// </summary>
            [Display(Name = "員工專案-列管員工採檢")]
            [Description("C30")]
            _C30,

            /// <summary>
            /// 員工專案-高風險單位加強採檢
            /// </summary>
            [Display(Name = "員工專案-高風險單位加強採檢")]
            [Description("C31")]
            _C31,

            /// <summary>
            /// 門診透析病人公費採檢
            /// </summary>
            [Display(Name = "門診透析病人公費採檢")]
            [Description("C32")]
            _C32,

            /// <summary>
            /// 企業快篩公費採檢
            /// </summary>
            [Display(Name = "企業快篩公費採檢")]
            [Description("C33")]
            _C33,

            /// <summary>
            /// 非急診之居家隔離/檢疫民眾採檢
            /// </summary>
            [Display(Name = "非急診之居家隔離/檢疫民眾採檢")]
            [Description("C34")]
            _C34,

            /// <summary>
            /// 新進外包廠商員工(自費優免)，收1000元
            /// </summary>
            [Display(Name = "新進外包廠商員工(自費優免)，收1000元")]
            [Description("C35")]
            _C35,

            /// <summary>
            /// 協助臨床作業廠商(自費優免)，收3150元
            /// </summary>
            [Display(Name = "協助臨床作業廠商(自費優免)，收3150元")]
            [Description("C36")]
            _C36,

            /// <summary>
            /// 團體10人自費篩檢，收3300元
            /// </summary>
            [Display(Name = "團體10人自費篩檢，收3300元")]
            [Description("C37")]
            _C37,

            /// <summary>
            /// 新進外包廠商員工(自費優免)，收1000元
            /// </summary>
            [Display(Name = "新進外包廠商員工(自費優免)，收1000元")]
            [Description("C38")]
            _C38,

            /// <summary>
            /// 協助臨床作業廠商(自費優免)，收3150元
            /// </summary>
            [Display(Name = "協助臨床作業廠商(自費優免)，收3150元")]
            [Description("C39")]
            _C39,

            /// <summary>
            /// 高社區傳播風險地區人員採檢(長照機構工作人員)
            /// </summary>
            [Display(Name = "高社區傳播風險地區人員採檢(長照機構工作人員)")]
            [Description("C40")]
            _C40,

            /// <summary>
            /// 陪病者每7日定期篩檢
            /// </summary>
            [Display(Name = "陪病者每7日定期篩檢")]
            [Description("C41")]
            _C41,

            /// <summary>
            /// 國軍入營前公費採檢
            /// </summary>
            [Display(Name = "國軍入營前公費採檢")]
            [Description("C42")]
            _C42,

            /// <summary>
            /// 探病者完成疫苗基礎劑接種14天(含)以上者公費篩檢
            /// </summary>
            [Display(Name = "探病者完成疫苗基礎劑接種14天(含)以上者公費篩檢")]
            [Description("C43")]
            _C43,

            /// <summary>
            /// 藥物研究
            /// </summary>
            [Display(Name = "藥物研究")]
            [Description("C44")]
            _C44,

            /// <summary>
            /// 移民署
            /// </summary>
            [Display(Name = "移民署")]
            [Description("P0")]
            _P0,

            /// <summary>
            /// 門診警消海巡義齒+營養諮詢(掛號費+診察費優免)
            /// </summary>
            [Display(Name = "門診警消海巡義齒+營養諮詢(掛號費+診察費優免)")]
            [Description("P00")]
            _P00,

            /// <summary>
            /// 警察
            /// </summary>
            [Display(Name = "警察")]
            [Description("P4")]
            _P4,

            /// <summary>
            /// 警察中央警察大學
            /// </summary>
            [Display(Name = "警察中央警察大學")]
            [Description("P5")]
            _P5,

            /// <summary>
            /// 消防署
            /// </summary>
            [Display(Name = "消防署")]
            [Description("P6")]
            _P6,

            /// <summary>
            /// 海巡署
            /// </summary>
            [Display(Name = "海巡署")]
            [Description("P7")]
            _P7,

            /// <summary>
            /// 空勤總隊
            /// </summary>
            [Display(Name = "空勤總隊")]
            [Description("P8")]
            _P8,

            /// <summary>
            /// 聘雇飛行教官
            /// </summary>
            [Display(Name = "聘雇飛行教官")]
            [Description("P9")]
            _P9,

            /// <summary>
            /// 臺北巿、一般民眾兒補第一、三類輪狀病毒疫苗((需收診療費、優免1050元、掛號費100元)
            /// </summary>
            [Display(Name = "臺北巿、一般民眾兒補第一、三類輪狀病毒疫苗((需收診療費、優免1050元、掛號費100元)")]
            [Description("R")]
            _R,

            /// <summary>
            /// 111/11/1急診軍人還款使用
            /// </summary>
            [Display(Name = "111/11/1急診軍人還款使用")]
            [Description("Z74")]
            _Z74,

        }

        /// <summary>
        /// 就醫類別.CODE_SRC.DELFA05
        /// 取Description當Value
        /// </summary>
        public enum TreatItem
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("-1")]
            None,

            /// <summary>
            /// 門診指定就醫病人 00
            /// </summary>
            [Display(Name = "門診指定就醫病人")]
            [Description("00")]
            CLinicAppointmentPatient,

            /// <summary>
            /// 西醫門診 01
            /// </summary>
            [Display(Name = "西醫門診")]
            [Description("01")]
            WesternMedicineClinic,

            /// <summary>
            /// 牙醫門診 02
            /// </summary>
            [Display(Name = "牙醫門診")]
            [Description("02")]
            DentistClinic,

            /// <summary>
            /// 中醫門診 03
            /// </summary>
            [Display(Name = "中醫門診")]
            [Description("03")]
            ChineseMedicineClinic,

            /// <summary>
            /// 急診 04
            /// </summary>
            [Display(Name = "急診")]
            [Description("04")]
            EmergencyRoom,

            /// <summary>
            /// 住院 05
            /// </summary>
            [Display(Name = "住院")]
            [Description("05")]
            BeHospitalized,

            /// <summary>
            /// 門診轉診就醫 06
            /// </summary>
            [Display(Name = "門診轉診就醫")]
            [Description("06")]
            OPDReferral,

            /// <summary>
            /// 門診手術後之回診 07
            /// </summary>
            [Display(Name = "門診手術後之回診")]
            [Description("07")]
            FollowUpAfterOPDSurgery,

            /// <summary>
            /// 住院患者出院之回診 08
            /// </summary>
            [Display(Name = "住院患者出院之回診")]
            [Description("08")]
            InpatientFollowUpAfterDischarge,

            /// <summary>
            /// 透析總額門診 09
            /// </summary>
            [Display(Name = "透析總額門診")]
            [Description("09")]
            TotalDialysisClinic,

            /// <summary>
            /// 同一療程(六次內) AA
            /// </summary>
            [Display(Name = "同一療程(六次內)")]
            [Description("AA")]
            SameTreatmentWithinSixTimes,

            /// <summary>
            /// 同一療程(一個月內) AB
            /// </summary>
            [Display(Name = "同一療程(一個月內)")]
            [Description("AB")]
            SameTreatmentWithinOneMonth,

            /// <summary>
            /// 預防保健 AC
            /// </summary>
            [Display(Name = "預防保健")]
            [Description("AC")]
            PreventiveHealthCare,

            /// <summary>
            /// 職業傷害或職業病 AD
            /// </summary>
            [Display(Name = "職業傷害或職業病")]
            [Description("AD")]
            OccupationalInjuryOrDisease,

            /// <summary>
            /// 慢性病連續處方箋領藥 AE
            /// </summary>
            [Display(Name = "慢性病連續處方箋領藥")]
            [Description("AE")]
            ContinuousPrescriptionForChronicDisease,

            /// <summary>
            /// 藥局調劑 AF
            /// </summary>
            [Display(Name = "藥局調劑")]
            [Description("AF")]
            PharmacyRegulation,

            /// <summary>
            /// 排程檢查 AG
            /// </summary>
            [Display(Name = "排程檢查")]
            [Description("AG")]
            ScheduledCheck,

            /// <summary>
            /// 居家照護(第二次以後) AH
            /// </summary>
            [Display(Name = "居家照護(第二次以後)")]
            [Description("AH")]
            HomeCareAfterSecondTime,

            /// <summary>
            /// 同日同醫師看診(第二次以後) AI
            /// </summary>
            [Display(Name = "同日同醫師看診(第二次以後)")]
            [Description("AI")]
            SameDaysSameDoctorAfterSecondTime,

            /// <summary>
            /// 透析門診療程第二次(含) AJ
            /// </summary>
            [Display(Name = "透析門診療程第二次(含)")]
            [Description("AJ")]
            DialysisClinicAfterSecondTime,

            /// <summary>
            /// 急診當次轉住院之入院 BA
            /// </summary>
            [Display(Name = "急診當次轉住院之入院")]
            [Description("BA")]
            ERAdmissionInTheCurrent,

            /// <summary>
            /// 出院 BB
            /// </summary>
            [Display(Name = "出院")]
            [Description("BB")]
            Discharged,

            /// <summary>
            /// 急診中,住院中執行項目 BC
            /// </summary>
            [Display(Name = "急診中,住院中執行項目")]
            [Description("BC")]
            ExecuteProjectInERAndHospital,

            /// <summary>
            /// 急診第二日以後 BD
            /// </summary>
            [Display(Name = "急診第二日以後")]
            [Description("BD")]
            ERAfterSecondDay,

            /// <summary>
            /// 職業傷害或職業病之入院 BE
            /// </summary>
            [Display(Name = "職業傷害或職業病之入院")]
            [Description("BE")]
            AdmissionToHospitalForOccupationalInjuryOrDisease,

            /// <summary>
            /// 繼續住院依規定分段結清者,切帳申報 BF
            /// </summary>
            [Display(Name = "繼續住院依規定分段結清者,切帳申報")]
            [Description("BF")]
            ContinueToBeHospitalized_AccountWillBeCutOff,

            /// <summary>
            /// 門診當次轉住院之入院 BG
            /// </summary>
            [Display(Name = "門診當次轉住院之入院")]
            [Description("BG")]
            OPDAdmissionInTheCurrent,
            /// <summary>
            /// 其他(不扣卡) CA
            /// </summary>
            [Display(Name = "其他(不扣卡)")]
            [Description("CA")]
            Others_NotDeducted,

            /// <summary>
            /// 門診轉出 DA
            /// </summary>
            [Display(Name = "門診轉出")]
            [Description("DA")]
            OPDTransfer,

            /// <summary>
            /// 門診手術需回診 DB
            /// </summary>
            [Display(Name = "門診手術需回診")]
            [Description("DB")]
            OPDSurgeryRequiresReturnVisit,

            /// <summary>
            /// 出院患者需回診 DC
            /// </summary>
            [Display(Name = "出院患者需回診")]
            [Description("DC")]
            DischargedPatientsComeBack,
        }
        /// <summary>
        /// 身分別-案件類別
        /// </summary>
        public enum CaseType
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("")] 
            None,
            /// <summary>
            /// 西醫一般案件
            /// </summary>
            [Display(Name = "西醫一般案件")]
            [Description("01")]
            _01,

            /// <summary>
            /// 西醫門診手術
            /// </summary>
            [Display(Name = "西醫門診手術")]
            [Description("03")]
            _03,

            /// <summary>
            /// 西醫慢性病
            /// </summary>
            [Display(Name = "西醫慢性病")]
            [Description("04")]
            _04,

            /// <summary>
            /// 洗腎
            /// </summary>
            [Display(Name = "洗腎")]
            [Description("05")]
            _05,

            /// <summary>
            /// 結核病
            /// </summary>
            [Display(Name = "結核病")]
            [Description("06")]
            _06,

            /// <summary>
            /// 遠距醫療
            /// </summary>
            [Display(Name = "遠距醫療")]
            [Description("07")]
            _07,

            /// <summary>
            /// 慢性病連續處方調劑
            /// </summary>
            [Display(Name = "慢性病連續處方調劑")]
            [Description("08")]
            _08,

            /// <summary>
            /// 西醫其他專案
            /// </summary>
            [Display(Name = "西醫其他專案")]
            [Description("09")]
            _09,

            /// <summary>
            /// 牙醫一般案件
            /// </summary>
            [Display(Name = "牙醫一般案件")]
            [Description("11")]
            _11,

            /// <summary>
            /// 牙醫門診手術
            /// </summary>
            [Display(Name = "牙醫門診手術")]
            [Description("13")]
            _13,

            /// <summary>
            /// 特定身心障礙者牙醫醫療服務
            /// </summary>
            [Display(Name = "特定身心障礙者牙醫醫療服務")]
            [Description("16")]
            _16,

            /// <summary>
            /// 牙醫其他專案
            /// </summary>
            [Display(Name = "牙醫其他專案")]
            [Description("19")]
            _19,

            /// <summary>
            /// 中醫其他專案
            /// </summary>
            [Display(Name = "中醫其他專案")]
            [Description("22")]
            _22,

            /// <summary>
            /// 中醫慢性病
            /// </summary>
            [Display(Name = "中醫慢性病")]
            [Description("24")]
            _24,

            /// <summary>
            /// 中醫針灸、傷科及脫臼整復
            /// </summary>
            [Display(Name = "中醫針灸、傷科及脫臼整復")]
            [Description("29")]
            _29,

            /// <summary>
            /// 居家照護
            /// </summary>
            [Display(Name = "居家照護")]
            [Description("A1")]
            _A1,

            /// <summary>
            /// 精神疾病社區復健
            /// </summary>
            [Display(Name = "精神疾病社區復健")]
            [Description("A2")]
            _A2,

            /// <summary>
            /// 預防保健
            /// </summary>
            [Display(Name = "預防保健")]
            [Description("A3")]
            _A3,

            /// <summary>
            /// 安寧照護
            /// </summary>
            [Display(Name = "安寧照護")]
            [Description("A5")]
            _A5,

            /// <summary>
            /// 護理之家
            /// </summary>
            [Display(Name = "護理之家")]
            [Description("A6")]
            _A6,

            /// <summary>
            /// 安養養護機構院民
            /// </summary>
            [Display(Name = "安養養護機構院民")]
            [Description("A7")]
            _A7,

            /// <summary>
            /// 代辦性病患者全面篩檢愛滋病毒計畫
            /// </summary>
            [Display(Name = "代辦性病患者全面篩檢愛滋病毒計畫")]
            [Description("B1")]
            _B1,

            /// <summary>
            /// 職業災害
            /// </summary>
            [Display(Name = "職業災害")]
            [Description("B6")]
            _B6,

            /// <summary>
            /// 戒菸門診
            /// </summary>
            [Display(Name = "戒菸門診")]
            [Description("B7")]
            _B7,

            /// <summary>
            /// 孕婦篩檢愛滋計劃
            /// </summary>
            [Display(Name = "孕婦篩檢愛滋計劃")]
            [Description("B9")]
            _B9,

            /// <summary>
            /// 愛滋防治替代治療計劃
            /// </summary>
            [Display(Name = "愛滋防治替代治療計劃")]
            [Description("BA")]
            _BA,

            /// <summary>
            /// 論病例計酬
            /// </summary>
            [Display(Name = "論病例計酬")]
            [Description("C1")]
            _C1,

            /// <summary>
            /// 結核病含無健保、接觸者及潛伏結核
            /// </summary>
            [Display(Name = "結核病含無健保、接觸者及潛伏結核")]
            [Description("C4")]
            _C4,

            /// <summary>
            /// 嚴重特殊傳染性肺炎通報且隔離案件
            /// </summary>
            [Display(Name = "嚴重特殊傳染性肺炎通報且隔離案件")]
            [Description("C5")]
            _C5,

            /// <summary>
            /// 愛滋病
            /// </summary>
            [Display(Name = "愛滋病")]
            [Description("D1")]
            _D1,

            /// <summary>
            /// 老人及6個月至6歲兒童流感疫苗注射
            /// </summary>
            [Display(Name = "老人及6個月至6歲兒童流感疫苗注射")]
            [Description("D2")]
            _D2,

            /// <summary>
            /// 登革熱
            /// </summary>
            [Display(Name = "登革熱")]
            [Description("DF")]
            _DF,

            /// <summary>
            /// 健保試辦計劃
            /// </summary>
            [Display(Name = "健保試辦計劃")]
            [Description("E1")]
            _E1,

            /// <summary>
            /// 愛滋病確診服藥滿2年後
            /// </summary>
            [Display(Name = "愛滋病確診服藥滿2年後")]
            [Description("E2")]
            _E2,

            /// <summary>
            /// 愛滋病確診服藥滿2年後之慢性病連續處方再調劑
            /// </summary>
            [Display(Name = "愛滋病確診服藥滿2年後之慢性病連續處方再調劑")]
            [Description("E3")]
            _E3,

            /// <summary>
            /// 流感H1N1病毒抗原快速篩檢
            /// </summary>
            [Display(Name = "流感H1N1病毒抗原快速篩檢")]
            [Description("HN")]
            _HN,

        }
        /// <summary>
        /// 身分別-其他免部分負擔選項
        /// </summary>
        public enum OthPay
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("0")]
            None,
            /// <summary>
            /// 慢性病連續處方
            /// </summary>
            [Display(Name = "慢性病連續處方")]
            [Description("1")]
            SlowSick = 1,
            /// <summary>
            /// 產檢
            /// </summary>
            [Display(Name = "產檢")]
            [Description("2")]
            Predelivery = 2 ,
            /// <summary>
            /// 預防保健
            /// </summary>
            [Display(Name = "預防保健")]
            [Description("3")]
            PreventHealthCare = 3,
        }
        /// <summary>
        /// 身分別-保健服務項目註記
        /// 使用Description 取得數值
        /// </summary>
        public enum Item
        {
            /// <summary>
            /// 兒童預防保健
            /// </summary>
            [Display(Name = "預設值")]
            [Description("0")]
            None,

            /// <summary>
            /// 兒童預防保健
            /// </summary>
            [Display(Name = "兒童預防保健")]
            [Description("01")]
            _01,

            /// <summary>
            /// 成人預防保健
            /// </summary>
            [Display(Name = "成人預防保健")]
            [Description("02")]
            _02,

            /// <summary>
            /// 婦女抹片檢查
            /// </summary>
            [Display(Name = "婦女抹片檢查")]
            [Description("03")]
            _03,

            /// <summary>
            /// 老人流感
            /// </summary>
            [Display(Name = "老人流感")]
            [Description("04")]
            _04,

            /// <summary>
            /// 兒童牙齒預防保健
            /// </summary>
            [Display(Name = "兒童牙齒預防保健")]
            [Description("05")]
            _05,

            /// <summary>
            /// 婦女乳房檢查服務
            /// </summary>
            [Display(Name = "婦女乳房檢查服務")]
            [Description("06")]
            _06,

            /// <summary>
            /// 定量免疫法大腸糞便潛血檢查
            /// </summary>
            [Display(Name = "定量免疫法大腸糞便潛血檢查")]
            [Description("07")]
            _07,

            /// <summary>
            /// 口腔黏膜檢查
            /// </summary>
            [Display(Name = "口腔黏膜檢查")]
            [Description("08")]
            _08,

            /// <summary>
            /// 兒童常規疫苗
            /// </summary>
            [Display(Name = "兒童常規疫苗")]
            [Description("09")]
            _09,

            /// <summary>
            /// 75歲以上長者肺炎鏈球菌疫苗接種
            /// </summary>
            [Display(Name = "75歲以上長者肺炎鏈球菌疫苗接種")]
            [Description("10")]
            _10,

            /// <summary>
            /// 婦女人類乳突病毒檢測服務
            /// </summary>
            [Display(Name = "婦女人類乳突病毒檢測服務")]
            [Description("13")]
            _13,

            /// <summary>
            /// 胸部低劑量電腦斷層檢查
            /// </summary>
            [Display(Name = "胸部低劑量電腦斷層檢查")]
            [Description("14")]
            _14,
        }
        /// <summary>
        /// 身分別-給付類別
        /// </summary>
        public enum GiveType
        {
            None,
        }
        /// <summary>
        /// 身分別-檢查代碼
        /// </summary>
        public enum ItemCode
        {
            None,
            /// <summary>
            /// 第一次產檢(第八週)
            /// </summary>
            [Display(Name = "第一次產檢(第八週)", Description = "Predelivery")]
            [Description("40")]
            IC40,
            /// <summary>
            /// 第二次產檢(第十二週)
            /// </summary>
            [Display(Name = "第二次產檢(第十二週)", Description = "Predelivery")]
            [Description("41")]
            IC41,
            /// <summary>
            /// 第三次產檢(第十六週)
            /// </summary>
            [Display(Name = "第三次產檢(第十六週)", Description = "Predelivery")]
            [Description("42")]
            IC42,
            /// <summary>
            /// 第四次產檢(第二十週)
            /// </summary>
            [Display(Name = "第四次產檢(第二十週)", Description = "Predelivery")]
            [Description("43")]
            IC43,
            /// <summary>
            /// 第五次產檢(第二十四週)
            /// </summary>
            [Display(Name = "第五次產檢(第二十四週)", Description = "Predelivery")]
            [Description("44")]
            IC44,
            /// <summary>
            /// 第六次產檢(第二十八週)
            /// </summary>
            [Display(Name = "第六次產檢(第二十八週)", Description = "Predelivery")]
            [Description("45")]
            IC45,
            /// <summary>
            /// 第七次產檢(第三十週)
            /// </summary>
            [Display(Name = "第七次產檢(第三十週)", Description = "Predelivery")]
            [Description("46")]
            IC46,
            /// <summary>
            /// 第八次產檢(第三十二週)
            /// </summary>
            [Display(Name = "第八次產檢(第三十二週)", Description = "Predelivery")]
            [Description("47")]
            IC47,
            /// <summary>
            /// 第九次產檢(第三十四週)
            /// </summary>
            [Display(Name = "第九次產檢(第三十四週)", Description = "Predelivery")]
            [Description("48")]
            IC48,
            /// <summary>
            /// 第十次產檢(第三十六週)
            /// </summary>
            [Display(Name = "第十次產檢(第三十六週)", Description = "Predelivery")]
            [Description("49")]
            IC49,
            /// <summary>
            /// 第十一次產檢(第三七週)
            /// </summary>
            [Display(Name = "第十一次產檢(第三七週)", Description = "Predelivery")]
            [Description("50")]
            IC50,
            /// <summary>
            /// 第十二次產檢(第三八週)
            /// </summary>
            [Display(Name = "第十二次產檢(第三八週)", Description = "Predelivery")]
            [Description("51")]
            IC51,
            /// <summary>
            /// 第十三次產檢(第三九週)
            /// </summary>
            [Display(Name = "第十三次產檢(第三九週)", Description = "Predelivery")]
            [Description("52")]
            IC52,
            /// <summary>
            /// 第十四次產檢(第四十週)
            /// </summary>
            [Display(Name = "第十四次產檢(第四十週)", Description = "Predelivery")]
            [Description("53")]
            IC53,
            /// <summary>
            /// 第十五次(含)以上產檢[不符合健保給付]
            /// </summary>
            [Display(Name = "第十五次(含)以上產檢[不符合健保給付]", Description = "Predelivery")]
            [Description("54")]
            IC54,

        }
        #endregion

        #region 檢核類別 20210701 林威志
        /// <summary>
        /// 申報鎖控檢核類別
        /// </summary>
        public enum CHKFunctionName
        {
            /// <summary>
            /// 權限檢核
            /// </summary>
            AUTHORITY_LIMIT,
            /// <summary>
            /// 機敏性病歷限制
            /// </summary> 
            ALERTNESS_CHART,
            /// <summary>
            /// 住院資訊檢核
            /// </summary> 
            ADMITTED_INF,
            /// <summary>
            /// 病人基本資料
            /// </summary> 
            BASIC_INFO,
            /// <summary>
            /// 收費權限
            /// </summary> 
            CHARGE_AUTHORITY,
            /// <summary>
            /// 案件檢核
            /// </summary> 
            CASETYPE_LIMIT,
            /// <summary>
            /// 醫師
            /// </summary> 
            DOCTOR,
            /// <summary>
            /// 結案檢核
            /// </summary> 
            CASE_FINISHED,
            /// <summary>
            /// 收費型態
            /// </summary> 
            CHARE_TYPE,
            /// <summary>
            /// 診斷檢核
            /// </summary> 
            DIAG_CHECK,
            /// <summary>
            /// 優待類別
            /// </summary> 
            DISCOUNT_TYPE,
            /// <summary>
            /// 欄位檢核
            /// </summary> 
            FIELD_CHECK,
            /// <summary>
            /// 安寧紀錄提示
            /// </summary> 
            HOSPICE_CARE,
            /// <summary>
            /// 申報
            /// </summary> 
            HEALTH_INSURANCE,
            /// <summary>
            /// 傳染病通報
            /// </summary> 
            INF_DISEASE,
            /// <summary>
            /// 藥品檢核
            /// </summary> 
            MED_CHECK,
            /// <summary>
            /// 重大傷病碼註記
            /// </summary> 
            MAJOR_INJURY_DIAG,
            /// <summary>
            /// 藥品限制
            /// </summary> 
            MED_LIMIT,
            /// <summary>
            /// 醫令檢核
            /// </summary> 
            ORDER_CHECK,
            /// <summary>
            /// 醫令限制
            /// </summary> 
            ORDER_LIMIT,
            /// <summary>
            /// 部份負擔
            /// </summary> 
            PARTIAL_PAY,
            /// <summary>
            /// PPF提成
            /// </summary>
            PPF,
            /// <summary>
            /// 病人身分資格
            /// </summary> 
            QUALIFICATION_CHECK,
            /// <summary>
            /// 預防保健
            /// </summary> 
            PREVENTIVE_CARE,
            /// <summary>
            /// 轉診檢核
            /// </summary> 
            REFER_TO,
            /// <summary>
            /// 病人狀態
            /// </summary> 
            STATUS_CHECK,
            /// <summary>
            /// 特殊身分提示
            /// </summary> 
            SPECIAL_ID,
            /// <summary>
            /// 科別限制
            /// </summary>
            DEPT_LIMIT
        }

        /// <summary>
        /// 檢核方法代碼
        /// </summary>
        public enum CHKFunctionCode
        {
            /// <summary>
            /// 掛號
            /// </summary>
            _01,
            /// <summary>
            /// 身分確認
            /// </summary> 
            _02,
            /// <summary>
            /// 檢傷
            /// </summary> 
            _03,
            /// <summary>
            /// 問診作業
            /// </summary> 
            _04,
            /// <summary>
            /// 診間
            /// </summary> 
            _05,
            /// <summary>
            /// 結案
            /// </summary> 
            _06,
            /// <summary>
            /// 批價
            /// </summary> 
            _07,
            /// <summary>
            /// 收費
            /// </summary> 
            _08,
            /// <summary>
            /// 收退費
            /// </summary> 
            _09,
            /// <summary>
            /// 同療
            /// </summary> 
            _10,
            /// <summary>
            /// 報到
            /// </summary> 
            _11,
            /// <summary>
            /// 品修
            /// </summary> 
            _12,
        }

        /// <summary>
        /// 檢核系統代碼
        /// </summary>
        public enum CHKSystemCode
        {
            /// <summary>
            /// 門診系統
            /// </summary> 
            O,
            /// <summary>
            /// 急診系統
            /// </summary> 
            E,
            /// <summary>
            /// 牙科診間系統
            /// </summary> 
            D,
        }
        /// <summary>
        /// NHICheck 警示類別
        /// </summary>
        public enum CHKAlertType
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            Null,
            /// <summary>
            /// 強制
            /// </summary>
            [Display(Name = "強制")]
            A,
            /// <summary>
            /// 警示
            /// </summary>
            [Display(Name = "警示")]
            B,
        }
        #endregion

        #region 就醫診療註記 20210708 林伯翰
        /// <summary>
        /// 就醫診療註記
        /// </summary>
        public enum MedlogKindList
        {
            /// <summary>
            /// 自殺防治
            /// </summary>
            [Display(Name = "自殺防治")]
            [Description("B")]
            SuicidePrevention,
            /// <summary>
            /// 高危險跌倒防治
            /// </summary>
            [Display(Name = "高危險跌倒防治")]
            [Description("S")]
            HighRiskFallPrevention,
            /// <summary>
            /// 戒菸
            /// </summary>
            [Display(Name = "戒菸")]
            [Description("Q")]
            QuickSmoking,
            /// <summary>
            /// 關懷人員藥物清單
            /// </summary>
            [Display(Name = "關懷人員藥物清單")]
            [Description("PSY")]
            CareWorkerMedList,
            /// <summary>
            /// 遺失慢籤
            /// </summary>
            [Display(Name = "遺失慢籤")]
            [Description("L")]
            LostSlowVisa,
            /// <summary>
            /// 持機票
            /// </summary>
            [Display(Name = "持機票")]
            [Description("K")]
            HoldAirTicket,
            /// <summary>
            /// 離島病人已留存證明文件
            /// </summary>
            [Display(Name = "離島病人已留存證明文件")]
            [Description("3")]
            OutlyingIslandPatientsSupportingDocuments,
        }

        #endregion

        #region 門診 身分確認資料下載使用 
        /// <summary>
        /// 身分確認資料下載 ENUM
        /// </summary>
        public enum IdentityDataLoadingType
        {
            /// <summary>
            /// 身分類別基本
            /// </summary>
            [Description("身分類別基本")]
            PatientGroup,
            /// <summary>
            /// 保險類別基本
            /// </summary>
            [Description("保險類別基本")]
            INSUType,
            /// <summary>
            /// 案件分類基本
            /// </summary>
            [Description("案件分類基本")]
            BasCase,
            /// <summary>
            /// 部分負擔基本
            /// </summary>
            [Description("部分負擔基本")]
            BasPart,
            /// <summary>
            /// 優待類別基本
            /// </summary>
            [Description("優待類別基本")]
            VIPDef,
            /// <summary>
            /// 給付類別基本
            /// </summary>
            [Description("給付類別基本")]
            GiveType,
            /// <summary>
            /// 就醫類別
            /// </summary>
            [Description("就醫類別")]
            TreatItem,
            /// <summary>
            /// 其他免部分負擔選項
            /// </summary>
            [Description("其他免部分負擔選項")]
            OthPay,
            /// <summary>
            /// 保健服務品項註記
            /// </summary>
            [Description("保健服務品項註記")]
            Item,
            /// <summary>
            /// 身份確認CheckBoxData List
            /// </summary>
            [Description("身份確認")]
            IdentityCheck,
            /// <summary>
            /// 醫療院所List
            /// </summary>
            [Description("醫療院所")]
            ReferralHospitalList,
            /// <summary>
            /// 代領藥和掛號身分別Data
            /// </summary>
            [Description("代領藥和掛號身分別資料")]
            AlternativeReceiveMedicineData,
            /// <summary>
            /// 藥袋資訊
            /// </summary>
            [Description("藥袋資訊")]
            MedicineBagInfo,
            [Description("異常拋出")]
            ErrorException
        }
        #endregion

        #region AFTERMAKE 最終動向
        /// <summary>
        /// 最終動向
        /// </summary>
        public enum AFTERMAKE //後續處理List
        {
            /// <summary>
            /// 未勾選
            /// </summary>
            [Display(Name = "Null")]
            [Description("未勾選")]
            Null = 9999,
            /// <summary>
            /// 住院
            /// </summary>
            [Display(Name = "IPD")]
            [Description("住院")]
            IPD = 0,
            /// <summary>
            /// 轉ICU
            /// </summary>
            [Display(Name = "ICU")]
            [Description("加護病房")]
            ICU = 1,
            /// <summary>
            /// 門診複查
            /// </summary>
            [Display(Name = "OPDReview")]
            [Description("門診複查")]
            OPDReview = 2,
            /// <summary>
            /// 觀察（超過一小時)
            /// </summary>
            [Display(Name = "ObserveOverOneHours")]
            [Description("觀察（超過一小時)")]
            ObserveOverOneHours = 3,
            /// <summary>
            /// 未完成治療離院
            /// </summary>
            [Display(Name = "LeaveWithoutTreatment")]
            [Description("未完成治療離院")]
            LeaveWithoutTreatment = 4,
            /// <summary>
            /// 死亡
            /// </summary>
            [Display(Name = "Death")]
            [Description("死亡")]
            Death = 5,
            /// <summary>
            /// 轉至他院
            /// </summary>
            [Display(Name = "ReferringToOtherHospital")]
            [Description("轉至他院")]
            ReferringToOtherHospital = 6,
            /// <summary>
            /// 未完成治療轉院
            /// </summary>
            [Display(Name = "LeaveWithoutTransferHospital")]
            [Description("未完成治療轉院")]
            LeaveWithoutTransferHospital = 7,
            /// <summary>
            /// 逃院
            /// </summary>
            [Display(Name = "Escape")]
            [Description("逃院")]
            Escape = 8,
            /// <summary>
            /// 病人要求轉往他院治療
            /// </summary>
            [Display(Name = "ToOtherHospitalPatient")]
            [Description("病人要求轉往他院治療")]
            ToOtherHospitalPatient = 9,
            /// <summary>
            /// 病危返家
            /// </summary>
            [Display(Name = "GoHomeDeath")]
            [Description("病危返家")]
            GoHomeDeath = 10
        }
        #endregion

        #region ER Observation Bed 急診留觀床位狀態
        /// <summary>
        /// 佔床碼
        /// </summary>
        public enum BedOccupy
        {
            /// <summary>
            /// 特殊佔床
            /// </summary>
            [Description("特殊佔床")]
            D,
            /// <summary>
            /// 佔床
            /// </summary>
            [Description("佔床")]
            G,
            /// <summary>
            /// 隔離佔床
            /// </summary>
            [Description("隔離佔床")]
            I,
            /// <summary>
            /// 空床
            /// </summary>
            [Description("空床")]
            N,
            /// <summary>
            /// 預約床
            /// </summary>
            [Description("預約床")]
            P,
            /// <summary>
            /// 包房佔床
            /// </summary>
            [Description("包房佔床")]
            S
        }
        /// <summary>
        /// 病床狀態
        /// </summary>
        public enum BedStatus
        {
            /// <summary>
            /// 病人已結清帳款,但尚未出院
            /// </summary>
            [Description("病人已結清帳款,但尚未出院")]
            B,
            /// <summary>
            /// 空床
            /// </summary>
            [Description("空床")]
            C,
            /// <summary>
            /// 佔床
            /// </summary>
            [Description("佔床")]
            O,
            /// <summary>
            /// 床位即將空出(結帳中)
            /// </summary>
            [Description("床位即將空出(結帳中)")]
            P,
            /// <summary>
            /// 已預約(床位未報到)
            /// </summary>
            [Description("已預約(床位未報到)")]
            T
        }
        #endregion

        #region OPD Dashboard Enum
        /// <summary>
        /// 上方MenuItem Title Name, Display(Name = "中文名", Description = "階層深度", GroupName = "父階層名稱", Order="階層排序")
        /// </summary>
        public enum OPDDashboard_MenuItemTitle
        {
            /// <summary>
            /// 系統設定
            /// </summary>
            [Display(Name = "系統設定", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            SystemPerformance,
            /// <summary>
            /// 查詢作業
            /// </summary>
            [Display(Name = "查詢作業", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            QueryOperation,
            /// <summary>
            /// 健兒門診
            /// </summary>
            [Display(Name = "健兒門診", AutoGenerateField = false, Description = "1", GroupName = nameof(OPDDashboard_MenuItemTitle.QueryOperation))]
            [Description(nameof(OPDDashboard_MenuItemTitle.QueryOperation))]
            HealthCareChildrenClinic,
            /// <summary>
            /// 統計報表
            /// </summary>
            [Display(Name = "統計報表", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            StatisticalReport,
            /// <summary>
            /// 醫師報到
            /// </summary>
            [Display(Name = "醫師報到", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            DoctorReportDuty,
            /// <summary>
            /// 健保卡設定
            /// </summary>
            [Display(Name = "健保卡設定", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            NHIICcardSettings,
            /// <summary>
            /// 病患清單重新整理秒數
            /// </summary>
            [Display(Name = "病患清單重新整理秒數", AutoGenerateField = true, Description = "1", GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance))]
            //[Description(nameof(OPDDashboard_MenuItemTitle.SystemPerformance))]
            DashboardPatientListReferesh,
            /// <summary>
            /// 病患清單病患姓名字體大小設定
            /// </summary>
            [Display(Name = "病患清單病患姓名字體大小設定", AutoGenerateField = true, Description = "2", GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance))]
            //[Description(nameof(OPDDashboard_MenuItemTitle.SystemPerformance))]
            DashboardPatientListPatientNameFontSize,
            ///// <summary>
            ///// 健保雲端主控台重啟
            ///// </summary>
            //[Display(Name = "健保雲端主控台重啟", AutoGenerateField = true, Description = "0", GroupName = "ROOT")]
            ////[Description(nameof(OPDDashboard_MenuItemTitle.SystemPerformance))]
            //NHIResetCsfsimExe,
        }
        /// <summary>
        /// Display(Name = "中文名", Description = "階層深度", GroupName = "父階層名稱", Order="階層排序"), 
        /// AutoGenerateField = false(UI上已經有，故程式碼不自動產生項目) 
        /// </summary>
        public enum OPDDashboard_MenuItem
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            [Description("ROOT")]
            NULL,
            /// <summary>
            /// 讀寫健保卡是否使用Com Server
            /// </summary>
            [Display(Name = "讀寫健保卡是否使用Com Server(64位元程式專用)"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 1
                , AutoGenerateField = true)]
            [Description("點擊來重新啟動健保卡ComServer元件")]
            SystemPerformance_IsNHIIcCardUseComServerMode,
            /// <summary>
            /// 健保署控制軟體啟動區域:
            /// </summary>
            [Display(Name = "健保署控制軟體啟動區域:"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 2
                , AutoGenerateField = true)]
            [Description("[預設使用本機版],遠端版:院外電腦使用微軟遠端桌面並勾選本機資源->其他->\"智慧卡\"與\"連接埠\"來使用")]
            SystemPerformance_IsNHIIcCardUseLocalType,

            /// <summary>
            /// 套餐
            /// </summary>
            [Display(Name = "套餐維護功能"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 3
                , AutoGenerateField = true)]
            [Description("")]
            SystemPerformance_PackageOrder,
            /// <summary>
            /// 片語
            /// </summary>
            [Display(Name = "片語維護功能"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 4
                , AutoGenerateField = true)]
            [Description("")]
            SystemPerformance_CommonPhrases,
            /// <summary>
            /// 設定健保讀卡機設定檔
            /// </summary>
            [Display(Name = "設定健保(舊)讀卡機設定檔"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 5
                , AutoGenerateField = false)]
            [Description("複製設定檔並關閉健保讀卡主控台")]
            SystemPerformance_NHISettingsNonPCSC,
            /// <summary>
            /// 設定晶片讀卡機設定檔
            /// </summary>
            [Display(Name = "設定晶片(新)讀卡機設定檔"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 6
                , AutoGenerateField = false)]
            [Description("複製設定檔並運行健保讀卡主控台")]
            SystemPerformance_NHISettingsPCSC,
            /// <summary>
            /// 設定N/A讀卡機設定檔
            /// </summary>
            [Display(Name = "設定N/A讀卡機設定檔"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 7
                , AutoGenerateField = false)]
            [Description("複製設定檔並運行健保讀卡程式")]
            SystemPerformance_NHISettingsNA,
            /// <summary>
            /// 安裝健保署雲端讀卡機主控台
            /// </summary>
            [Display(Name = "安裝/修復健保署雲端讀卡機主控台"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 8
                , AutoGenerateField = true)]
            [Description("111/09/25發佈, Ver:5.1.5.7")]
            SystemPerformance_InstalNHIPCSC,
            /// <summary>
            /// 啟動雲端健保署讀卡機主控台
            /// </summary>
            [Display(Name = "啟動(重啟)雲端健保署讀卡機主控台"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 9
                , AutoGenerateField = true)]
            [Description("關閉主控台程式並重新啟動主控台程式")]
            SystemPerformance_ExecuteNHICSFSIM,

            /// <summary>
            /// 啟動雲端健保署讀卡機主控台
            /// </summary>
            [Display(Name = "軟體重啟 健保署讀卡機主控台"
                , Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 10
                , AutoGenerateField = true)]
            [Description("軟體重置健保卡主控台API(需重新認證醫師PIN碼)")]
            SystemPerformance_SoftwareResetNHICSFSIM,

            /// <summary>
            /// 相關醫令資料讀取來源:線上
            /// </summary>
            [Display(Name = "相關醫令資料讀取來源:線上", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 11
                , AutoGenerateField = true)]
            [Description("讀取HIS2資料庫，並重新下載資源檔")]
            SystemPerformance_DataDictionarySource_Online,
            /// <summary>
            /// 相關醫令資料讀取來源:離線
            /// </summary>
            [Display(Name = "相關醫令資料讀取來源:離線", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 12
                , AutoGenerateField = false)]
            [Description("讀取離線檔案")]
            SystemPerformance_DataDictionarySource_Offline,
            /// <summary>
            /// 相關醫令資料_離線下載
            /// </summary>
            [Display(Name = "相關醫令資料_離線下載", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 13
                , AutoGenerateField = false)]
            [Description("離線下載相關醫令基本資料")]
            SystemPerformance_DataDictionarySource_Downloader,
            /// <summary>
            /// 切換門診診間位元執行環境
            /// </summary>
            [Display(Name = "切換門診診間位元執行環境", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 14
                , AutoGenerateField = true)]
            [Description("須關閉診間來切換32或64位元執行環境[預設32位元]")]
            SystemPerformance_ManualChangeExecuteBitVersion,

            /// <summary>
            /// 讀取資料庫健保VPN相關讀卡功能狀態註記
            /// </summary>
            [Display(Name = "健保VPN相關讀卡功能狀態[有\u221a為啟用讀寫卡功能]", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 15
                , AutoGenerateField = true)]
            [Description("點擊為重新讀取資料庫健保VPN相關讀卡功能狀態註記")]
            SystemPerformance_ReloadNHIVPN_API_State,

            /// <summary>
            /// 開啟讀卡控制軟體 6.0 主控台公用程式
            /// </summary>
            [Display(Name = "開啟讀卡控制軟體 6.0 主控台公用程式", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.SystemPerformance)
                , Order = 16
                , AutoGenerateField = true)]
            [Description("僅限於有安裝讀卡控制軟體6.0才能呼叫，否則會出現相關錯誤訊息")]
            SystemPerformance_CSHIS60_Panel,



            /// <summary>
            /// 醫師報到
            /// </summary>
            [Display(Name = "醫師報到", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DoctorReportDuty)
                , Order = 1
                , AutoGenerateField = false)]
            [Description("")]
            DoctorReportDuty_DoctorReportDutyCheckIn,
            /// <summary>
            /// 醫師查詢報到時間
            /// </summary>
            [Display(Name = "查詢報到時間", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DoctorReportDuty)
                , Order = 2
                , AutoGenerateField = false)]
            [Description("")]
            DoctorReportDuty_DoctorReportDutyQueryDateTime,
            /// <summary>
            /// 醫事人員卡PIN碼驗證
            /// </summary>
            [Display(Name = "醫事人員卡PIN碼驗證", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DoctorReportDuty)
                , Order = 3
                , AutoGenerateField = true)]
            [Description("")]
            DoctorReportDuty_HPCPinVerify,


            #region 健保卡設定
            /// <summary>
            /// 總是讀取健保卡
            /// </summary>
            [Display(Name = "總是讀取健保卡", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.NHIICcardSettings)
                , Order = 1
                , AutoGenerateField = false)]
            [Description("不詢問直接讀取健保卡")]
            NHIICcardSettings_EnabledReadNHIIcCard,
            /// <summary>
            /// 總是讀取健保卡
            /// </summary>
            [Display(Name = "詢問是否讀取健保卡", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.NHIICcardSettings)
                , Order = 2
                , AutoGenerateField = false)]
            [Description("詢問是否讀取健保卡")]
            NHIICcardSettings_ReqiureReadNHIIcCard,
            /// <summary>
            /// 總是讀取健保卡
            /// </summary>
            [Display(Name = "不讀取健保卡", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.NHIICcardSettings)
                , Order = 3
                , AutoGenerateField = false)]
            [Description("不讀取健保卡相關資料，易造成健保申報資料缺失")]
            NHIICcardSettings_DisableReadNHIIcCard,

            #endregion 健保卡設定

            #region 查詢作業
            /// <summary>
            /// 查詢病患掛號資料
            /// </summary>
            [Display(Name = "查詢病患掛號資料", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.QueryOperation)
                , Order = 1
                , AutoGenerateField = true)]
            [Description("")]
            QueryOperation_DoctorQueryPatientRegData,
            /// <summary>
            /// 糖尿病＆CKD照護統計
            /// </summary>
            [Display(Name = "糖尿病＆CKD照護統計", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.QueryOperation)
                , Order = 2
                , AutoGenerateField = false)]
            [Description("")]
            QueryOperation_DiabetesAndCKDCareStatistics,
            /// <summary>
            /// 病人名條列印
            /// </summary>
            [Display(Name = "病人名條列印", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.QueryOperation)
                , Order = 3
                , AutoGenerateField = true)]
            [Description("")]
            QueryOperation_PrintPatientLabelView,
            /// <summary>
            /// 胎兒健康評估報告系統
            /// </summary>
            [Display(Name = "胎兒健康評估報告系統", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.QueryOperation)
                , Order = 4
                , AutoGenerateField = true)]
            [Description("")]
            QueryOperation_FetalHealthAssessmentReportingSystem,

            #endregion 查詢作業

            #region 健兒門診 HealthCareChildrenClinic
            /// <summary>
            /// 健兒門診年齡列印
            /// </summary>
            [Display(Name = "健兒門診年齡列印", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.HealthCareChildrenClinic)
                , Order = 1
                , AutoGenerateField = false)]
            [Description("")]
            HealthCareChildrenClinic_WBCAgePrint,
            /// <summary>
            /// 健兒門診年齡統計
            /// </summary>
            [Display(Name = "健兒門診年齡統計", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.HealthCareChildrenClinic)
                , Order = 2
                , AutoGenerateField = false)]
            [Description("")]
            HealthCareChildrenClinic_WBCAgeStat,
            /// <summary>
            /// 兒童預防保健衛教統計表
            /// </summary>
            [Display(Name = "兒童預防保健衛教統計表", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.HealthCareChildrenClinic)
                , Order = 3
                , AutoGenerateField = false)]
            [Description("")]
            HealthCareChildrenClinic_ChildPrevenHealthStat,
            /// <summary>
            /// 台北市兒童諮詢申請總表轉檔
            /// </summary>
            [Display(Name = "台北市兒童諮詢申請總表轉檔", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.HealthCareChildrenClinic)
                , Order = 4
                , AutoGenerateField = false)]
            [Description("")]
            HealthCareChildrenClinic_TPCChildCA,
            //20231226 林江說不使用此表單
            ///// <summary> 
            ///// 健兒門診預防接種
            ///// </summary>
            //[Display(Name = "健兒門診預防接種", Description = "1"
            //    , GroupName = nameof(OPDDashboard_MenuItemTitle.HealthCareChildrenClinic)
            //    , Order = 5
            //    , AutoGenerateField = false)]
            //[Description("")]
            //HealthCareChildrenClinic_WBCPrevenInject,
            /// <summary>
            /// 健兒門診病人施打疫苗查詢
            /// </summary>
            [Display(Name = "健兒門診病人施打疫苗查詢", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.HealthCareChildrenClinic)
                , Order = 6
                , AutoGenerateField = false)]
            [Description("")]
            HealthCareChildrenClinic_WBCVaccination,

            #endregion 健兒門診 HealthCareChildrenClinic

            #region 重新整理秒數
            /// <summary>
            /// 重新整理秒數 60秒
            /// </summary>
            [Display(Name = "一分鐘(60秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 1
                , AutoGenerateField = true)]
            [Description("60")]
            DashboardPatientListReferesh_Refresh60Seconds,
            /// <summary>
            /// 重新整理秒數 90秒
            /// </summary>
            [Display(Name = "一分半鐘(90秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 2
                , AutoGenerateField = true)]
            [Description("90")]
            DashboardPatientListReferesh_Refresh90Seconds,
            /// <summary>
            /// 重新整理秒數 120秒
            /// </summary>
            [Display(Name = "兩分鐘(120秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 3
                , AutoGenerateField = true)]
            [Description("120")]
            DashboardPatientListReferesh_Refresh120Seconds,
            /// <summary>
            /// 重新整理秒數 150秒
            /// </summary>
            [Display(Name = "兩分半鐘(150秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 4
                , AutoGenerateField = true)]
            [Description("150")]
            DashboardPatientListReferesh_Refresh150Seconds,
            /// <summary>
            /// 重新整理秒數 180秒
            /// </summary>
            [Display(Name = "三分鐘(180秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 5
                , AutoGenerateField = true)]
            [Description("180")]
            DashboardPatientListReferesh_Refresh180Seconds,
            /// <summary>
            /// 重新整理秒數 240秒
            /// </summary>
            [Display(Name = "四分鐘(240秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 6
                , AutoGenerateField = true)]
            [Description("240")]
            DashboardPatientListReferesh_Refresh240Seconds,
            /// <summary>
            /// 重新整理秒數 300秒
            /// </summary>
            [Display(Name = "五分鐘(300秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 7
                , AutoGenerateField = true)]
            [Description("300")]
            DashboardPatientListReferesh_Refresh300Seconds,
            /// <summary>
            /// 重新整理秒數 300秒
            /// </summary>
            [Display(Name = "七分鐘(420秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 8
                , AutoGenerateField = true)]
            [Description("420")]
            DashboardPatientListReferesh_Refresh420Seconds,
            /// <summary>
            /// 重新整理秒數 300秒
            /// </summary>
            [Display(Name = "十分鐘(600秒)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListReferesh)
                , Order = 9
                , AutoGenerateField = true)]
            [Description("600")]
            DashboardPatientListReferesh_Refresh600Seconds,

            #endregion

            #region DashboardPatientListPatientNameFontSize

            /// <summary>
            /// 預設字體大小(12f)
            /// </summary>
            [Display(Name = "預設字體大小(12f)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListPatientNameFontSize)
                , Order = 1
                , AutoGenerateField = true)]
            [Description("12")]
            DashboardPatientListPatientNameFontSize_FontSize12,
            /// <summary>
            /// 稍大字體大小(13f)
            /// </summary>
            [Display(Name = "稍大字體大小(13f)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListPatientNameFontSize)
                , Order = 2
                , AutoGenerateField = true)]
            [Description("13")]
            DashboardPatientListPatientNameFontSize_FontSize13,
            /// <summary>
            /// 加大字體大小(14f)
            /// </summary>
            [Display(Name = "加大字體大小(14f)", Description = "1"
                , GroupName = nameof(OPDDashboard_MenuItemTitle.DashboardPatientListPatientNameFontSize)
                , Order = 3
                , AutoGenerateField = true)]
            [Description("14")]
            DashboardPatientListPatientNameFontSize_FontSize14,

            #endregion
        }
        /// <summary>
        /// 門診診間儀錶板 右鍵選單 MenuItem
        /// </summary>
        public enum OPDDashboard_ContextMenu_Title
        {
            /// <summary>
            /// 表單列印
            /// </summary>
            [Display(Name = "表單列印")]
            [Description("ROOT")]
            PrintDocument
        }
        /// <summary>
        /// 門診診間儀錶板 右鍵選單 Item
        /// </summary>
        public enum OPDDashboard_ContextMenu_Item
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            Null = 0,
            /// <summary>
            /// 批價單
            /// </summary>
            [Display(Name = "批價單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument01,
            /// <summary>
            /// 一般藥品處方箋
            /// </summary>
            [Display(Name = "一般藥品處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument02,
            /// <summary>
            /// 公藥
            /// </summary>
            [Display(Name = "公藥處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument03,
            /// <summary>
            /// 試驗用藥
            /// </summary>
            [Display(Name = "試驗用藥處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument04,
            /// <summary>
            /// 管制藥
            /// </summary>
            [Display(Name = "管制藥處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument05,
            /// <summary>
            /// 化療
            /// </summary>
            [Display(Name = "化療處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument06,
            /// <summary>
            /// TPN
            /// </summary>
            [Display(Name = "TPN")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument07,
            /// <summary>
            /// 慢箋
            /// </summary>
            [Display(Name = "慢箋處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument08,
            /// <summary>
            /// 慢箋管制藥
            /// </summary>
            [Display(Name = "慢箋管制藥處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument09,
            /// <summary>
            /// 美沙東
            /// </summary>
            [Display(Name = "美沙東處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument10,
            /// <summary>
            /// 檢驗檢查單
            /// </summary>
            [Display(Name = "檢驗、檢查單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument11,
            /// <summary>
            /// 手術、處理、檢查申請單
            /// </summary>
            [Display(Name = "手術、處理、檢查申請單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_SugProPsyDocumentApply,
            /// <summary>
            /// 一次領藥切結書
            /// </summary>
            [Display(Name = "一次領藥切結書")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument12,
            /// <summary>
            /// 代領藥切結書
            /// </summary>
            [Display(Name = "代領藥切結書")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument13,
            /// <summary>
            /// 代領藥切結書(滯留大陸)
            /// </summary>
            [Display(Name = "代領藥切結書(滯留大陸)")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument14,

            /// <summary>
            /// 自費同意書
            /// </summary>
            [Display(Name = "自費同意書")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument15,
            /// <summary>
            /// 轉診摘要
            /// </summary>
            [Display(Name = "轉診摘要")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_ReferralSummary,
            /// <summary>
            /// 門診藥物注射暨觀察紀錄單
            /// </summary>
            [Display(Name = "門診藥物注射暨觀察紀錄單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_OMedInjectObserveRPT,
            /// <summary>
            /// 口腔黏膜檢查表
            /// </summary>
            [Display(Name = "口腔黏膜檢查表")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_OralMucosaExam,
            /// <summary>
            /// 定量免疫法糞便潛血檢查表
            /// </summary>
            [Display(Name = "定量免疫法糞便潛血檢查表")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_FecalOccultBloodTest,
            /// <summary>
            /// 門診交付調劑處方箋
            /// </summary>
            [Display(Name = "門診交付調劑處方箋")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_DEPRPT,
            /// <summary>
            /// 手術通知單-空白單
            /// </summary>
            [Display(Name = "手術通知單-空白單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_SurgeryNoticeForm,
            /// <summary>
            /// 麻醉藥品居家治療用藥紀錄表
            /// </summary>
            [Display(Name = "麻醉藥品居家治療用藥紀錄表")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_AnestheticHomeUserec,

            /// <summary>
            /// 吩坦尼穿皮貼片劑使用紀錄表
            /// </summary>
            [Display(Name = "吩坦尼穿皮貼片劑使用紀錄表")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_FentanylTDPUserec,

            /// <summary>
            /// 化療醫囑單
            /// </summary>
            [Display(Name = "化療醫囑單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_OCHEMOSheet,

            /// <summary>
            /// 復健治療明細表
            /// </summary>
            [Display(Name = "復健治療明細表")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_REHTreatDetail,

            /// <summary>
            /// 六分鐘步行測試前須知暨同意書
            /// </summary>
            [Display(Name = "六分鐘步行測試前須知暨同意書")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_SMWTConsent,
            /// <summary>
            /// 入院許可證
            /// </summary>
            [Display(Name = "入院許可證")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_AdmissionPermit,
            /// <summary>
            /// 公費流感抗病毒藥劑申請單
            /// </summary>
            [Display(Name = "公費流感抗病毒藥劑申請單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_PFIADApplication,
            /// <summary>
            /// 公費COVID-19複合式單株抗體Evusheld個案用藥同意書
            /// </summary>
            [Display(Name = "公費COVID-19複合式單株抗體Evusheld個案用藥同意書")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_COVID19ECUDConsent,
            /// <summary>
            /// COVID-19口服抗病毒藥物使用評估表
            /// </summary>
            [Display(Name = "COVID-19口服抗病毒藥物使用評估表")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_COVID19OADUEForm,
            /// <summary>
            /// 病人治療同意書(Paxlovid、Molnupiravir)
            /// </summary>
            [Display(Name = "病人治療同意書(Paxlovid、Molnupiravir)")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_COVID19PTConsent,
            /// <summary>
            /// 教學門診同意書
            /// </summary>
            [Display(Name = "教學門診同意書")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_TCConsentform,
            /// <summary>
            /// 潛伏結核LTBI治療衛教單
            /// </summary>
            [Display(Name = "潛伏結核LTBI治療衛教單")]
            [Description(nameof(OPDDashboard_ContextMenu_Title.PrintDocument))]
            PrintDocument_LTBI_Edu,
        }

        #endregion

        #region DataDictionarySourceJsonFileName
        /// <summary>
        /// 離線基本醫令資料JSON檔案名稱,DisplayName = DataDictionary中的屬性名稱 , Description = Model名稱
        /// </summary>
        public enum OPDClinicRoom_DataDictionarySourceJsonFileName
        {
            [Display(Name = "NULL")]
            [Description("NULL")]
            None,

            //ICDData
            [Display(Name = "lDiaglistICD10")]
            [Description("BASDIAG_ICD10_SIMPLIFY")]
            lDiaglistICD10,
            [Display(Name = "lDiaglistICD9")]
            [Description("BASDIAG_ICD10_SIMPLIFY")]
            lDiaglistICD9,

            //ORDERCODEData
            [Display(Name = "RawOrderCodeMasterList")]
            [Description("ORDERCODEMASTER_SIMPLIFY")]
            RawOrderCodeMasterList,

            //BasicData
            [Display(Name = "DeptList")]
            [Description("BASSECH")]
            DeptList,
            [Display(Name = "lSysUserList")]
            [Description("SYSUSER_SIMPLIFY")]
            lSysUserList,
            [Display(Name = "lBASOROPList")]
            [Description("BASOROP_ER")]
            lBASOROPList,

            //Code_SRC
            /// <summary>
            /// CODE_SRC.CODEGROUP in (NHILIST,OPROOM,ANESTHESIA,NOTPRINT,CHKTOSUG,PLANA)
            /// </summary>
            [Display(Name = "AllResultList")]
            [Description("CODE_SRC")]
            AllResultList,

            //身分確認
            [Display(Name = "typeCodeList")]
            [Description("PATIENTGROUP")]
            typeCodeList,
            [Display(Name = "insTypeList")]
            [Description("CODE_SRC")]
            insTypeList,
            [Display(Name = "caseTypeList")]
            [Description("BASCASE")]
            caseTypeList,
            [Display(Name = "partTypeList")]
            [Description("BASPART")]
            partTypeList,
            [Display(Name = "vipdefList")]
            [Description("VIP_DEF")]
            vipdefList,
            [Display(Name = "giveTypeList")]
            [Description("CODE_SRC")]
            giveTypeList,
            [Display(Name = "treatItemList")]
            [Description("CODE_SRC")]
            treatItemList,
            [Display(Name = "identityCheckList")]
            [Description("IDENTITYCHECK")]
            identityCheckList,
            [Display(Name = "othPayList")]
            [Description("CODE_SRC")]
            othPayList,
            [Display(Name = "itemList")]
            [Description("CODE_SRC")]
            itemList,
            [Display(Name = "referralList")]
            [Description("REFERRALRECORD")]
            referralList
        }
        #endregion

        #region OPD ClinicRoom RadMenuItem Enum
        /// <summary>
        /// 上方MenuItem Title Name, Display(Name = "中文名", Description = "階層深度", GroupName = "父階層名稱", Order="階層排序")
        /// </summary>
        public enum OPDClinicRoom_MenuItemTitle
        {
            /// <summary>
            /// 醫師報到
            /// </summary>
            [Display(Name = "醫師報到", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            DoctorCheckIn,
            /// <summary>
            /// 護理功能
            /// </summary>
            [Display(Name = "護理功能", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            NurseFunction,
            /// <summary>
            /// 病患特診
            /// </summary>
            [Display(Name = "病患特診", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            PatientConsultation,
            /// <summary>
            /// 病患特診-牙科
            /// </summary>
            [Display(Name = "牙科", Description = "1", GroupName = nameof(PatientConsultation))]
            [Description(nameof(PatientConsultation))]
            PatientConsultationDentistry,
            /// <summary>
            /// 藥衛材特檢
            /// </summary>
            [Display(Name = "藥衛材特檢", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            MedicineEisaiSpecialInspection,
            /// <summary>
            /// 特殊病歷通報
            /// </summary>
            [Display(Name = "特殊病歷通報", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            SpecialMedicalRecordNotification,
            /// <summary>
            /// 通報篩檢
            /// </summary>
            [Display(Name = "通報篩檢", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            NotificationScreening,
            /// <summary>
            /// 專科功能
            /// </summary>
            [Display(Name = "專科(１)", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            MedicalSpecialtyFunction1,
            /// <summary>
            /// 專科功能
            /// </summary>
            [Display(Name = "專科(２)", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            MedicalSpecialtyFunction2,
            /// <summary>
            /// 健兒門診表單
            /// </summary>
            [Display(Name = "健兒門診表單", AutoGenerateField = false, Description = "1", GroupName = nameof(MedicalSpecialtyFunction2))]
            [Description(nameof(MedicalSpecialtyFunction2))]
            PediatricsForm,
            /// <summary>
            /// 腎臟科表單
            /// </summary>
            [Display(Name = "腎臟科表單", AutoGenerateField = false, Description = "1", GroupName = nameof(MedicalSpecialtyFunction2))]
            [Description(nameof(MedicalSpecialtyFunction2))]
            NephrologyForm,
            /// <summary>
            /// 糖尿病表單
            /// </summary>
            [Display(Name = "糖尿病表單", AutoGenerateField = false, Description = "1", GroupName = nameof(MedicalSpecialtyFunction2))]
            [Description(nameof(MedicalSpecialtyFunction2))]
            DiabetesForm,
            /// <summary>
            /// 精神科表單
            /// </summary>
            [Display(Name = "精神科表單", AutoGenerateField = false, Description = "1", GroupName = nameof(MedicalSpecialtyFunction2))]
            [Description(nameof(MedicalSpecialtyFunction2))]
            PsychiatricForm,
            /// <summary>
            /// 轉介單
            /// </summary>
            [Display(Name = "轉介單", AutoGenerateField = false, Description = "1", GroupName = nameof(MedicalSpecialtyFunction2))]
            [Description(nameof(MedicalSpecialtyFunction2))]
            ReferralForm,
            /// <summary>
            /// 復健科表單
            /// </summary>
            [Display(Name = "復健科表單", AutoGenerateField = false, Description = "1", GroupName = nameof(MedicalSpecialtyFunction2))]
            [Description(nameof(MedicalSpecialtyFunction2))]
            RehabilitationForm,
            /// <summary>
            /// 其他表單
            /// </summary>
            [Display(Name = "其他表單", AutoGenerateField = false, Description = "1", GroupName = nameof(MedicalSpecialtyFunction2))]
            [Description(nameof(MedicalSpecialtyFunction2))]
            OtherForm,
            /// <summary>
            /// 電子病歷
            /// </summary>
            [Display(Name = "電子病歷", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            ElectronicMedicalRecord,
            /// <summary>
            /// 資源共享
            /// </summary>
            [Display(Name = "資源共享", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            ResourceSharing,

            /// <summary>
            /// 設定說明
            /// </summary>
            [Display(Name = "設定說明", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            SettingAssistant,
            /// <summary>
            /// 表單列印-牙科表單
            /// </summary>
            [Display(Name = "牙科表單", Description = "1", GroupName = nameof(MedicalSpecialtyFunction2))]
            [Description(nameof(MedicalSpecialtyFunction2))]
            MedicalSpecialtyFunction2Dentistry
        }
        /// <summary>
        /// 門診診間 項目 Display(Name = "中文名", Description = "階層深度", GroupName = "父階層名稱", Order="階層排序"), 
        /// AutoGenerateField = false(UI上已經有，故程式碼不自動產生項目) 
        /// ShortName = "IDENTITYCHECK.KIND 子群組編碼(SPECDOCREG特殊掛號使用)"
        /// </summary>
        [Description("")]
        public enum OPDClinicRoom_MenuItem
        {
            /// <summary>
            /// NULL
            /// </summary>
            [Display(Name = "初始值", AutoGenerateField = false, Description = "0", GroupName = "ROOT")]
            [Description("ROOT")]
            NULL = 0,

            #region MedicalSpecialtyFunction2Dentistry 表單列印-牙科表單

            /// <summary>
            /// 表單下載
            /// </summary>
            [Display(Name = "表單下載", AutoGenerateField = true, Description = "2", GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 1)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_DocumentDownload,

            /// <summary>
            /// 門診教學同意書
            /// </summary>
            [Display(Name = "門診教學同意書", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 2)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_OPDTeachingConsentForm,

            /// <summary>
            /// 院外影像影像同意書
            /// </summary>
            [Display(Name = "院外影像影像同意書", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 3)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_OutOfHospitalRISConsentForm,

            /// <summary>
            /// 院外影像回覆單
            /// </summary>
            [Display(Name = "院外影像回覆單", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 4)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_OutOfHospitalRISReplySheet,

            /// <summary>
            /// 健保住院自費門診同意書
            /// </summary>
            [Display(Name = "健保住院自費門診同意書", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 5)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_HealthInsuranceIPDSelfPayOPDConsentForm,

            /// <summary>
            /// 自負住院健保門診同意書
            /// </summary>
            [Display(Name = "自負住院健保門診同意書", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 6)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_SelfPayIPDHealthInsuranceOPDConsentForm,

            /// <summary>
            /// 技工單
            /// </summary>
            [Display(Name = "技工單", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 7)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_MechanicSheet,

            /// <summary>
            /// 自費衛材同意書系統
            /// </summary>
            [Display(Name = "自費衛材同意書系統", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 8)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_SelfPayEisaiConsentFormSystem,

            /// <summary>
            /// 牙科就診病人清單
            /// </summary>
            [Display(Name = "牙科就診病人清單", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 9)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_DentalVisitPatientCheckList,

            /// <summary>
            /// 牙科申報紀錄
            /// </summary>
            [Display(Name = "牙科申報紀錄", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 10)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_DentalDeclarationRecord,

            /// <summary>
            /// 牙科申報紀錄
            /// </summary>
            [Display(Name = "牙周病檢查紀錄表", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 10)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_PeriodontalChart,

            /// <summary>
            /// 牙科申報紀錄
            /// </summary>
            [Display(Name = "牙菌斑控制紀錄表", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry), Order = 10)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2Dentistry))]
            MedicalSpecialtyFunction2_Dentistry_PlaqueControlRecord,

            #endregion MedicalSpecialtyFunction2Dentistry 表單列印-牙科表單

            /// <summary>
            /// 門診已掃描病歷
            /// </summary>
            [Display(Name = "門診已掃描病歷", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.ElectronicMedicalRecord))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.ElectronicMedicalRecord))]
            ElectronicMedicalRecord_OPDMedicalRecordsScanned,

            #region PatientConsultation 病患特診
            /// <summary>
            /// 麻醉諮詢約診
            /// </summary>
            [Display(Name = "麻醉諮詢約診", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_AnesthesiaConsultationAppointments,
            /// <summary>
            /// COVID-19 TOCC
            /// </summary>
            [Display(Name = "COVID-19 TOCC", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_COVID19_TOCC,
            /// <summary>
            /// 兒童聽力篩檢掛號
            /// </summary>
            [Display(Name = "兒童聽力篩檢掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_ChildrensHearingScreeningRegistration,
            /// <summary>
            /// 婦女子宮頸抹片掛號
            /// </summary>
            [Display(Name = "婦女子宮頸抹片掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "9")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_WomensPapSmearRegistration,

            /// <summary>
            /// 口腔篩檢特別門診
            /// </summary>
            [Display(Name = "口腔篩檢特別門診", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "1")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_Dentistry_OralScreeningSpecialClinic,
            /// <summary>
            /// 大腸直腸篩檢
            /// </summary>
            [Display(Name = "大腸直腸篩檢", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "11")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_ColorectalScreening,
            /// <summary>
            /// ESRD掛號
            /// </summary>
            [Display(Name = "Pre-ESRD掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_PreESRDRegistration,
            /// <summary>
            /// AKD掛號
            /// </summary>
            [Display(Name = "AKD掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "4")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_AKDRegistration,
            /// <summary>
            /// AKD健保藥事照護掛號
            /// </summary>
            [Display(Name = "AKD健保藥事照護掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "10")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_AKDHealthCarePharmacyCareRegistration,
            /// <summary>
            /// CKD掛號
            /// </summary>
            [Display(Name = "CKD掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_CKDRegistration,
            /// <summary>
            /// CKD健保藥事照護掛號
            /// </summary>
            [Display(Name = "CKD健保藥事照護掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "5")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_PreESRDPharmacyCareRegistration,
            /// <summary>
            /// 弱勢兒童預防保健
            /// </summary>
            [Display(Name = "弱勢兒童預防保健", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultationDentistry)
                , ShortName = "2")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultationDentistry))]
            PatientConsultation_Dentistry_PreventiveCareForVulnerableChildren,
            /// <summary>
            /// 國小兒童窩溝封填掛號
            /// </summary>
            [Display(Name = "國小兒童窩溝封填掛號", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultationDentistry))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultationDentistry))]
            PatientConsultation_Dentistry_PitAndFissureSealingRegistrationForElementarySchoolChildren,
            /// <summary>
            /// 兒童塗氟掛號
            /// </summary>
            [Display(Name = "兒童塗氟掛號", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultationDentistry))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultationDentistry))]
            PatientConsultation_Dentistry_ChildrenFluorideCoatingRegistration,
            /// <summary>
            /// 戒菸門診特殊掛號
            /// </summary>
            [Display(Name = "戒菸門診特殊掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "3")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_Dentistry_SmokingCessationClinicSpecialRegistration,
            /// <summary>
            /// 藥酒癮特約診掛號
            /// </summary>
            [Display(Name = "藥酒癮特約診掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "7")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_DrugAlcoholAddictionSpecialConsultation,

            /// <summary>
            /// 兵役用診斷證明書
            /// </summary>
            [Display(Name = "兵役用診斷證明書", AutoGenerateField = true, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation)
                , ShortName = "")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PatientConsultation))]
            PatientConsultation_MedicalCertificateForMilitaryService,

            #endregion PatientConsultation 病患特診

            #region NotificationScreening 通報篩檢
            /// <summary>
            /// 傳染病通報
            /// </summary>
            [Display(Name = "傳染病通報", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening))]
            NotificationScreening_InfectiousDiseaseNotification,

            /// <summary>
            /// 性病愛滋篩檢
            /// </summary>
            [Display(Name = "性病愛滋篩檢", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening)
                , ShortName = "8")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening))]
            NotificationScreening_STDHIVScreening,

            /// <summary>
            /// 孕婦愛滋篩檢
            /// </summary>
            [Display(Name = "孕婦愛滋篩檢", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening))]
            NotificationScreening_HIVScreeningPregnantWomen,

            /// <summary>
            /// 感染肝炎科掛號
            /// </summary>
            [Display(Name = "感染肝炎科掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening)
                , ShortName = "12")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening))]
            NotificationScreening_InfectionHepatitisDepartmentRegistration,

            /// <summary>
            /// 登革熱快篩特約掛號
            /// </summary>
            [Display(Name = "登革熱快篩特約掛號", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening)
                , ShortName = "6")]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NotificationScreening))]
            NotificationScreening_DengueFeverScreening,
            #endregion NotificationScreening 通報篩檢

            #region MedicalSpecialtyFunction2 專科掛號2
            /// <summary>
            /// 列印BioBank保存申請書*1 + 參與者同意書*2
            /// </summary>
            [Display(Name = "列印BioBank保存申請書*1 + 參與者同意書*2", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2))]
            MedicalSpecialtyFunction2_BioBankParticipantAndParticipantConsentForm,

            #region PediatricsClinicForm 健兒門診表單
            /// <summary>
            /// 健兒門診預防保健
            /// </summary>
            [Display(Name = "健兒門診預防保健", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PediatricsForm), Order = 1)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PediatricsForm))]
            PediatricsForm_Vaccination,
            /// <summary>
            /// 健兒門診病人施打疫苗查詢與列印報表
            /// </summary>
            [Display(Name = "健兒門診病人施打疫苗查詢與列印報表", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PediatricsForm), Order = 3)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PediatricsForm))]
            PediatricsForm_VaccinationInquiryAndPrintReport,
            /// <summary>
            /// 健兒門診年齡統計
            /// </summary>
            [Display(Name = "健兒門診年齡統計", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PediatricsForm), Order = 3)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PediatricsForm))]
            PediatricsForm_AgeStatistics,
            /// <summary>
            /// 台北市兒童諮詢申請總表
            /// </summary>
            [Display(Name = "台北市兒童諮詢申請總表", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PediatricsForm), Order = 3)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PediatricsForm))]
            PediatricsForm_TaipeiCityChildrenConsultationApplicationForm,
            #endregion PediatricsClinicForm 健兒門診表單

            #region NephrologyForm 腎臟科表單
            /// <summary>
            /// 列印慢性腎臟病CKD個案照護營養紀錄單
            /// </summary>
            [Display(Name = "列印慢性腎臟病CKD個案照護營養紀錄單", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NephrologyForm), Order = 1)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NephrologyForm))]
            NephrologyForm_PrintChronicKidneyDiseaseIndividualCareNutritionRecordSheet,
            /// <summary>
            /// 列印腎臟科CKD個案管理紀錄表
            /// </summary>
            [Display(Name = "列印腎臟科CKD個案管理紀錄表", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NephrologyForm), Order = 2)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NephrologyForm))]
            NephrologyForm_PrintTheNephrologyCKDCaseManagementRecordForm,
            /// <summary>
            /// 腎臟科照護檢核
            /// </summary>
            [Display(Name = "腎臟科照護檢核", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NephrologyForm), Order = 3)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NephrologyForm))]
            NephrologyForm_NephrologyCareCheck,
            /// <summary>
            /// CKD個案追蹤照護病歷表
            /// </summary>
            [Display(Name = "CKD個案追蹤照護病歷表", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NephrologyForm), Order = 4)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NephrologyForm))]
            NephrologyForm_CKDCaseTraceMedRecord,
            #endregion NephrologyForm 腎臟科表單

            #region DiabetesForm 糖尿病表單
            /// <summary>
            /// 糖尿病病人檢核
            /// </summary>
            [Display(Name = "糖尿病病人檢核", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.DiabetesForm), Order = 1)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.DiabetesForm))]
            DiabetesForm_DiabetesPatientCheck,
            /// <summary>
            /// 糖尿病病患衛教紀錄檔
            /// </summary>
            [Display(Name = "糖尿病病患衛教紀錄檔", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.DiabetesForm), Order = 2)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.DiabetesForm))]
            DiabetesForm_DMPHERecord,
            /// <summary>
            /// 糖尿病照護碼與糖尿病收案碼配對檢查
            /// </summary>
            [Display(Name = "糖尿病照護碼與糖尿病收案碼配對檢查", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.DiabetesForm), Order = 3)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.DiabetesForm))]
            DiabetesForm_DiabetesCareCodeAndAcceptCaseCodePairingCheck,
            /// <summary>
            /// 列印糖尿病衛教紀錄首頁
            /// </summary>
            [Display(Name = "列印糖尿病衛教紀錄首頁", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.DiabetesForm), Order = 4)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.DiabetesForm))]
            DiabetesForm_PrintFirstPageOfDiabeteshealthEducationRecord,
            #endregion  DiabetesForm 糖尿病表單

            #region PsychiatricForm 精神科表單
            /// <summary>
            /// 列印精神科檢查治療轉介單
            /// </summary>
            [Display(Name = "列印精神科檢查治療轉介單", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PsychiatricForm), Order = 1)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PsychiatricForm))]
            PsychiatricForm_PrintReferralFormForPsychiatricExaminationAndTreatment,
            /// <summary>
            /// 列印精神科RTMS療轉介單
            /// </summary>
            [Display(Name = "列印精神科RTMS治療轉介單", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PsychiatricForm), Order = 2)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PsychiatricForm))]
            PsychiatricForm_PrintReferralFormForPsychiatricRTMSTreatment,
            /// <summary>
            /// 列印精神科檢查治療轉介單(Brain Mapping)
            /// </summary>
            [Display(Name = "列印精神科檢查治療轉介單(Brain Mapping)", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.PsychiatricForm), Order = 3)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.PsychiatricForm))]
            PsychiatricForm_PrintReferralFormForPsychiatricBrainMappingExaminationAndTreatment,

            #endregion PsychiatricForm 精神科表單

            #region OtherForm 其他表單
            /// <summary>
            /// 禽畜業者發燒通報單
            /// </summary>
            [Display(Name = "禽畜業者發燒通報單", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.OtherForm), Order = 1)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.OtherForm))]
            OtherForm_LivestockerFeverNotice,

            /// <summary>
            /// 自費藥品退藥條件表
            /// </summary>
            [Display(Name = "自費藥品退藥條件表", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.OtherForm), Order = 2)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.OtherForm))]
            OtherForm_PayselfMedReturnCondition,
            #endregion OtherForm 其他表單
            /// <summary>
            /// 小兒部生長曲線
            /// </summary>
            [Display(Name = "小兒部生長曲線", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2))]
            MedicalSpecialtyFunction2_PediatricGrowthCurve,
            /// <summary>
            /// 列印LDC表單
            /// </summary>
            [Display(Name = "列印LDC表單", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2))]
            MedicalSpecialtyFunction2_PrintLDCForm,

            /// <summary>
            /// 列印BSRS表單
            /// </summary>
            [Display(Name = "列印BSRS表單", AutoGenerateField = true, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.MedicalSpecialtyFunction2))]
            MedicalSpecialtyFunction2_PrintBSRSData,

            #region ReferralForm 轉介單
            /// <summary>
            /// 心率睡眠儀檢查轉介單
            /// </summary>
            [Display(Name = "心率睡眠儀檢查轉介單", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.ReferralForm), Order = 1)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.ReferralForm))]
            ReferralForm_HeartRateSleepMeterExaminationReferralForm,
            /// <summary>
            /// 新陳代謝科洗牙轉介單
            /// </summary>
            [Display(Name = "新陳代謝科洗牙轉介單", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.ReferralForm), Order = 2)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.ReferralForm))]
            ReferralForm_MetabolismDepartmentTeethCleaningReferralForm,
            /// <summary>
            /// 婦產科洗牙轉介單
            /// </summary>
            [Display(Name = "婦產科洗牙轉介單:", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.ReferralForm), Order = 3)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.ReferralForm))]
            ReferralForm_ObstetricsAndGynecologyTeethCleaningReferralForm,
            #endregion ReferralForm 轉介單

            #region 復健科表單
            /// <summary>
            /// 復健治療明細表
            /// </summary>
            [Display(Name = "復健治療明細表", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.RehabilitationForm), Order = 1)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.RehabilitationForm))]
            RehabilitationForm_REHTreatDetail,
            /// <summary>
            /// 復健醫學部治療紀錄表
            /// </summary>
            [Display(Name = "復健醫學部治療紀錄表", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.RehabilitationForm), Order = 2)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.RehabilitationForm))]
            RehabilitationForm_REHTreatRecord,
            /// <summary>
            /// 治療紀錄表診斷及處置
            /// </summary>
            [Display(Name = "治療紀錄表診斷及處置", AutoGenerateField = true, Description = "2"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.RehabilitationForm), Order = 2)]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.RehabilitationForm))]
            RehabilitationForm_REHTerapyRec,

            #endregion

            #endregion MedicalSpecialtyFunction2 專科掛號2

            #region ResourceSharing 資源共享
            /// <summary>
            /// 醫病共享決策執行紀錄表
            /// </summary>
            [Display(Name = "醫病共享決策執行紀錄表", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.ResourceSharing))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.ResourceSharing))]
            ResourceSharing_MedicalShareExecuteRecordForm,
            #endregion ResourceSharing 資源共享

            #region ElectronicMedicalRecord 電子病歷
            /// <summary>
            /// 機敏性病歷
            /// </summary>
            [Display(Name = "機敏性病歷", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.ElectronicMedicalRecord))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.ElectronicMedicalRecord))]
            ElectronicMedicalRecord_ConfidentialMedicalRecord,
            /// <summary>
            /// 列印報告黏貼單
            /// </summary>
            [Display(Name = "列印報告黏貼單", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.ElectronicMedicalRecord))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.ElectronicMedicalRecord))]
            ElectronicMedicalRecord_RPTPasteForm,
            #endregion ElectronicMedicalRecord 電子病歷

            #region NurseFunction 護理功能
            /// <summary>
            /// 預防保健暨戒菸服務
            /// </summary>
            [Display(Name = "預防保健暨戒菸服務", AutoGenerateField = false, Description = "1"
                , GroupName = nameof(OPDClinicRoom_MenuItemTitle.NurseFunction))]
            [Description(nameof(OPDClinicRoom_MenuItemTitle.NurseFunction))]
            NurseFunction_PreventiveHealthCareAndSmokingCessationService,

            #endregion NurseFunction 護理功能

        }
        #endregion OPD ClinicRoom RadMenuItem Enum

        #region OPD ClinicRoom AddBatchOrders Enum 門診診間 統一醫令接口
        /// <summary>
        /// OPD ClinicRoom AddBatchOrders Enum 門診診間 統一醫令接口
        /// </summary>
        public enum OPD_ClinicRoom_AddBatchOrders_Enum
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "Null")]
            [Description("OPD.Null")]
            NULL,
            /// <summary>
            /// AddBatchOrder[由程式新增，跳過手開某些限制規則]
            /// </summary>
            [Display(Name = "新增")]
            [Description("OPD._Order")]
            AddBatchOrder,
            /// <summary>
            /// UserAddingRow[使用者輸入]
            /// </summary>
            [Display(Name = "手動新增")]
            [Description("OPD.Order")]
            UserAddingRow,
            /// <summary>
            /// UserAddedRow[使用者輸入]
            /// </summary>
            [Display(Name = "手動新增")]
            [Description("OPD.Order")]
            UserAddedRow,
            /// <summary>
            /// UserDeletingRow
            /// </summary>
            [Display(Name = "手動刪除")]
            [Description("OPD.Deleting")]
            UserDeletingRow,
            /// <summary>
            /// UserDeletedRow
            /// </summary>
            [Display(Name = "手動刪除")]
            [Description("OPD.Deleted")]
            UserDeletedRow,
            /// <summary>
            /// 進入診間時複查
            /// </summary>
            [Display(Name = "進入診間時複查")]
            [Description("OPD.OpenCheck")]
            OpenAndCheck,
            /// <summary>
            /// 套餐
            /// </summary>
            [Display(Name = "套餐")]
            [Description("OPD.SetMenu")]
            PackageOrder,
            /// <summary>
            /// 一帶多
            /// </summary>
            [Display(Name = "一帶多")]
            [Description("OPD.Pack")]
            PackOrder,
            /// <summary>
            /// LIS檢驗
            /// </summary>
            [Display(Name = "LIS檢驗")]
            [Description("OPD.Lab&Rad")]
            LIS,
            /// <summary>
            /// PACS放射檢查
            /// </summary>
            [Display(Name = "PACS放射檢查")]
            [Description("OPD.Lab&Rad")]
            PACS,
            /// <summary>
            /// 歷次就醫
            /// </summary>
            [Display(Name = "歷次就醫")]
            [Description("OPD.History")]
            TriHistoryMedicalForm,
            /// <summary>
            /// 復健
            /// </summary>
            [Display(Name = "復健")]
            [Description("OPD.Reh")]
            RehabilitationForm,
            /// <summary>
            /// 輸液視窗
            /// </summary>
            [Display(Name = "輸液")]
            [Description("OPD.Infusion")]
            InfusionForm,
            /// <summary>
            /// 常用品項
            /// </summary>
            [Display(Name = "常用品項")]
            [Description("OPD.CommonOrder")]
            CommonOrder,
            /// <summary>
            /// 四癌篩檢
            /// </summary>
            [Display(Name = "四癌篩檢")]
            [Description("OPD.Cancer")]
            Cancer,
            /// <summary>
            /// 出院帶藥帶入
            /// </summary>
            [Display(Name = "出院帶藥帶入")]
            [Description("OPD.OutHospDrug")]
            OutHospDrugOrder,
            /// <summary>
            /// 資源共享
            /// </summary>
            [Display(Name = "資源共享")]
            [Description("OPD.Resource")]
            ResourceShare
        }
        #endregion OPD ClinicRoom AddBatchOrders Enum 門診診間 統一醫令接口

        #region OPD ClinicRoom SpiltOrder

        /// <summary>
        /// OPD.ClinicRoom SplitOrder 使用之 Dictionary Enum
        /// </summary>
        public enum OpdClinicRoomSplitOrder
        {
            /// <summary>
            /// 新增
            /// </summary>
            [Description("A")]
            Add,
            /// <summary>
            /// 刪除
            /// </summary>
            [Description("D")]
            Delete,
            /// <summary>
            /// 先刪除後新增
            /// </summary>
            [Description("U")]
            Update,
            /// <summary>
            /// 未更動之醫令
            /// </summary>
            [Description("S")]
            Source,
        }

        /// <summary>
        /// 一次領慢籤事由
        /// </summary>
        public enum TakeAllReason
        {
            /// <summary>
            /// 預定出國
            /// </summary>
            [Display(Name = "VMCH80002")]
            [Description("預定出國")]
            H8,
            /// <summary>
            /// 返回離島地區
            /// </summary>
            [Display(Name = "VMCHA0002")]
            [Description("返回離島地區")]
            HA,
            /// <summary>
            /// 已出海為遠洋漁船作業船員
            /// </summary>
            [Display(Name = "VMCHB0002")]
            [Description("已出海為遠洋漁船作業船員")]
            HB,
            /// <summary>
            /// 已出海為國際航線船舶作業船員
            /// </summary>
            [Display(Name = "VMCHC0002")]
            [Description("已出海為國際航線船舶作業船員")]
            HC,
            /// <summary>
            /// 罕見疾病病人
            /// </summary>
            [Display(Name = "VMCHD0002")]
            [Description("罕見疾病病人")]
            HD
        }
        /// <summary>
        /// 特殊治療代碼
        /// </summary>
        public enum SID_TYPE
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "")]
            [Description("Null")] 
            Null,
            #region A

            /// <summary>
            /// A1 特定治療代碼(超音波檢查)
            /// </summary>
            [Display(Name = "超音波檢查")]
            [Description("A1")]
            A1,
            /// <summary>
            /// A2 特定治療代碼(耳鼻喉科檢查)
            /// </summary>
            [Display(Name = "超音波檢查")]
            [Description("A2")]
            A2,
            /// <summary>
            /// A3 特定治療代碼(內視鏡檢查)
            /// </summary>
            [Display(Name = "內視鏡檢查")]
            [Description("A3")]
            A3,
            /// <summary>
            /// A4 特定治療代碼(病理組織檢查)
            /// </summary>
            [Display(Name = "病理組織檢查")]
            [Description("A4")]
            A4,
            /// <summary>
            /// A5 特定治療代碼(核子醫學檢查)
            /// </summary>
            [Display(Name = "核子醫學檢查")]
            [Description("A5")]
            A5,
            /// <summary>
            /// A6 特定治療代碼(X光檢查)
            /// </summary>
            [Display(Name = "X光檢查")]
            [Description("A6")]
            A6,
            /// <summary>
            /// A7 特定治療代碼(特殊造影檢查)
            /// </summary>
            [Display(Name = "特殊造影檢查")]
            [Description("A7")]
            A7,
            /// <summary>
            /// A8 特定治療代碼(神經科檢查)
            /// </summary>
            [Display(Name = "神經科檢查")]
            [Description("A8")]
            A8,
            #endregion

            #region D

            /// <summary>
            /// D0 特定治療代碼(物理治療簡單、中度治療)
            /// </summary>
            [Display(Name = "物理治療簡單、中度治療")]
            [Description("D0")]
            D0,
            /// <summary>
            /// D1 特定治療代碼(癌症放射線治療)
            /// </summary>
            [Display(Name = "癌症放射線治療")]
            [Description("D1")]
            D1,
            /// <summary>
            /// D2 特定治療代碼(癌症化學治療)
            /// </summary>
            [Display(Name = "癌症化學治療")]
            [Description("D2")]
            D2,
            /// <summary>
            /// D3 特定治療代碼(復健治療（物理治療簡單、中度治療除外）)
            /// </summary>
            [Display(Name = "復健治療（物理治療簡單、中度治療除外）")]
            [Description("D3")]
            D3,
            /// <summary>
            /// D4 特定治療代碼(精神科治療)
            /// </summary>
            [Display(Name = "精神科治療")]
            [Description("D4")]
            D4,
            /// <summary>
            /// D5 特定治療代碼(高壓氧治療)
            /// </summary>
            [Display(Name = "高壓氧治療")]
            [Description("D5")]
            D5,
            /// <summary>
            /// D6 特定治療代碼(眼科鐳射治療)
            /// </summary>
            [Display(Name = "眼科鐳射治療")]
            [Description("D6")]
            D6,
            /// <summary>
            /// D8 特定治療代碼 (血液透析治療)
            /// </summary>
            [Display(Name = "血液透析治療")]
            [Description("D8")]
            D8,
            /// <summary>
            /// D9 特定治療代碼(腹膜透析)
            /// </summary>
            [Display(Name = "腹膜透析")]
            [Description("D9")]
            D9,

            #endregion

            #region E

            /// <summary>
            /// E1 特定治療代碼(腸病毒)
            /// </summary>
            [Display(Name = "腸病毒")]
            [Description("E1")]
            E1,
            /// <summary>
            /// E2 支援長期照護機構提供一般門診案件
            /// </summary>
            [Display(Name = "支援長期照護機構提供一般門診案件")]
            [Description("E2")]
            E2,
            /// <summary>
            /// E4 特定治療代碼(DM糖尿病照護費)
            /// </summary>
            [Display(Name = "DM糖尿病照護費")]
            [Description("E4")]
            E4,
            /// <summary>
            /// E5 週產期論人支付制度試辦計畫
            /// </summary>
            [Display(Name = "週產期論人支付制度試辦計畫")]
            [Description("E5")]
            E5,
            /// <summary>
            /// E6 特定治療代碼(氣喘)
            /// </summary>
            [Display(Name = "氣喘")]
            [Description("E6")]
            E6,
            /// <summary>
            /// E8 特定治療代碼(高血壓)
            /// </summary>
            [Display(Name = "高血壓")]
            [Description("E8")]
            E8,
            /// <summary>
            ///EB 特定治療代碼(初期慢性腎臟病醫療給付改善方案)
            /// </summary>
            [Display(Name = "初期慢性腎臟病醫療給付改善方案")]
            [Description("EB")]
            EB,
            /// <summary>
            /// EC 全民健康保險居家醫療照護整合計畫
            /// </summary>
            [Display(Name = "全民健康保險居家醫療照護整合計畫")]
            [Description("EC")] 
            EC,
            /// <summary>
            ///EG 潛伏結核感染治療品質支付服務計畫
            /// </summary>
            [Display(Name = "潛伏結核感染治療品質支付服務計畫")]
            [Description("EG")]
            EG,
            /// <summary>
            ///EH 愛滋照護管理品質計畫
            /// </summary>
            [Display(Name = "愛滋照護管理品質計畫")]
            [Description("EH")]
            EH,
            /// <summary>
            ///EJ 長照機構加強型結核病防治計畫
            /// </summary>
            [Display(Name = "長照機構加強型結核病防治計畫")]
            [Description("EJ")]
            EJ,
            /// <summary>
            ///EK 特定治療代碼(糖尿病合併初期腎臟病照護)
            /// </summary>
            [Display(Name = "糖尿病合併初期腎臟病照護")]
            [Description("EK")]
            EK,
            #endregion

            #region F

            /// <summary>
            /// FP 特定治療代碼(牙周病統合照護第一階段)
            /// </summary>
            [Display(Name = "牙周病統合照護第一階段")]
            [Description("FP")]
            FP,
            /// <summary>
            /// FQ 特定治療代碼(牙周病統合照護第二階段)
            /// </summary>
            [Display(Name = "牙周病統合照護第二階段")]
            [Description("FQ")]
            FQ,
            /// <summary>
            /// FR 特定治療代碼(牙周病統合照護第三階段)
            /// </summary>
            [Display(Name = "牙周病統合照護第三階段")]
            [Description("FR")]
            FR,

            #endregion

            #region H

            /// <summary>
            /// H1 特定治療代碼(肝炎試辦計畫)
            /// </summary>
            [Display(Name = "肝炎試辦計畫")]
            [Description("H1")]
            H1,
            /// <summary>
            /// H2 西醫-行動不便者，經醫師認定或經受託人提供切結文件，慢性病代領藥案件(96.7增訂；101.11修訂文字)
            /// </summary>
            [Display(Name = "慢性病代領藥案件-行動不便者")]
            [Description("H2")]
            H2,
            /// <summary>
            /// H3 西醫-已出海為遠洋漁船作業船員，提供切結文件，慢性病代領藥案件(96.7增訂：101.11修訂文字)
            /// </summary>
            [Display(Name = "慢性病代領藥案件-已出海為遠洋漁船作業船員")]
            [Description("H3")]
            H3,
            /// <summary>
            /// H6 西醫-已出海為國際航線船舶作業船員，提供切結文件，慢性病代領藥案件(97.10增訂；101.11修訂文字)
            /// </summary>
            [Display(Name = "慢性病代領藥案件-已出海為國際航線船舶作業船員")]
            [Description("H6")]
            H6,
            /// <summary>
            /// H7 特定治療代碼(全民健康保險B型肝炎帶原者及C型肝炎感染者醫療給付改善方案)
            /// </summary>
            [Display(Name = "全民健康保險B型肝炎帶原者及C型肝炎感染者醫療給付改善方案")]
            [Description("H7")]
            H7,
            /// <summary>
            /// H8 西醫-持慢性病連續處方箋領藥，預定出國，提供切結文件，一次領取2個月或3個月用藥量案件
            /// </summary>
            [Display(Name = "預定出國")]
            [Description("H8")]
            H8,
            /// <summary>
            /// H9 經保險人認定之特殊情形，慢性病代領藥案件（101.11新增）。
            /// </summary>
            [Display(Name = "慢性病代領藥案件-經保險人認定之特殊情形")]
            [Description("H9")]
            H9,
            /// <summary>
            /// HA 西醫-持慢性病連續處方箋領藥，返回離島地區，提供切結文件，一次領取2個月或3個月用藥量案件（101.11新增）。
            /// </summary>
            [Display(Name = "返回離島地區")]
            [Description("HA")]
            HA,
            /// <summary>
            /// HB 西醫-持慢性病連續處方箋領藥，已出海為遠洋漁船作業船員，提供切結文件，一次領取2個月或3個月用藥量案件（101.11新增）。
            /// </summary>
            [Display(Name = "已出海為遠洋漁船作業船員")]
            [Description("HB")]
            HB,
            /// <summary>
            /// HC 西醫-持慢性病連續處方箋領藥，已出海為國際航線船舶作業船員，提供切結文件，一次領取2個月或3個月用藥案件
            /// </summary>
            [Display(Name = "已出海為國際航線船舶作業船員")]
            [Description("HC")]
            HC,
            /// <summary>
            /// HD 西醫-持慢性病連續處方箋領藥，罕見疾病病人，提供切結文件，一次領取2個月或3個月用藥案件
            /// </summary>
            [Display(Name = "罕見疾病病人")]
            [Description("HD")]
            HD,
            /// <summary>
            /// HE 特定治療代碼(C型肝炎全口服治療)
            /// </summary>
            [Display(Name = "C型肝炎全口服治療")]
            [Description("HE")]
            HE,
            /// <summary>
            /// HF 特定治療代碼(慢性阻塞性肺病醫療給付改善方案)
            /// </summary>
            [Display(Name = "慢性阻塞性肺病醫療給付改善方案")]
            [Description("HF")]
            HF,
            /// <summary>
            /// HM 特定治療代碼(大腸癌追蹤管理)
            /// </summary>
            [Display(Name = "大腸癌追蹤管理")]
            [Description("HM")]
            HM,
            /// <summary>
            /// HN 特定治療代碼(大腸癌診斷品質管理)
            /// </summary>
            [Display(Name = "大腸癌診斷品質管理")]
            [Description("HN")]
            HN,
            /// <summary>
            /// HP 特定治療代碼(口腔癌追蹤管理)
            /// </summary>
            [Display(Name = "口腔癌追蹤管理")]
            [Description("HP")]
            HP,
            /// <summary>
            /// HQ 特定治療代碼(口腔癌診斷品質管理)
            /// </summary>
            [Display(Name = "口腔癌診斷品質管理")]
            [Description("HQ")]
            HQ,
            /// <summary>
            /// HR 特定治療代碼(子宮頸癌追蹤管理)
            /// </summary>
            [Display(Name = "子宮頸癌追蹤管理")]
            [Description("HR")]
            HR,
            /// <summary>
            /// HS 特定治療代碼(子宮頸癌診斷品質管理)
            /// </summary>
            [Display(Name = "子宮頸癌診斷品質管理")]
            [Description("HS")]
            HS,
            /// <summary>
            /// HT 特定治療代碼(乳癌追蹤管理)
            /// </summary>
            [Display(Name = "乳癌追蹤管理")]
            [Description("HT")]
            HT,
            /// <summary>
            /// HW 特定治療代碼(乳癌診斷品質管理)
            /// </summary>
            [Display(Name = "乳癌診斷品質管理")]
            [Description("HW")]
            HW,
            /// <summary>
            /// HX 特定治療代碼(肺癌追蹤管理)
            /// </summary>
            [Display(Name = "肺癌追蹤管理")]
            [Description("HX")]
            HX,
            /// <summary>
            /// HY 特定治療代碼(肺癌診斷品質管理)
            /// </summary>
            [Display(Name = "肺癌診斷品質管理")]
            [Description("HY")]
            HY,

            #endregion

            #region K

            /// <summary>
            /// K1 特定治療代碼(Pre-ESRD預防性計畫及病人衛教計畫)
            /// </summary>
            [Display(Name = "Pre-ESRD預防性計畫及病人衛教計畫")]
            [Description("K1")]
            K1,
            /// <summary>
            /// K3 特定治療代碼(洗腎相關)
            /// </summary>
            [Display(Name = "洗腎相關")]
            [Description("K3")]
            K3,

            #endregion

            #region P

            /// <summary>
            /// P1 特定治療代碼(根管治療)
            /// </summary>
            [Display(Name = "根管治療")]
            [Description("P1")]
            P1,
            /// <summary>
            /// P2 特定治療代碼(銀粉充填)
            /// </summary>
            [Display(Name = "銀粉充填")]
            [Description("P2")]
            P2,
            /// <summary>
            /// P3 特定治療代碼(複合樹脂[玻璃璃子]充填)
            /// </summary>
            [Display(Name = "複合樹脂[玻璃璃子]充填")]
            [Description("P3")]
            P3,
            /// <summary>
            /// P4 特定治療代碼(牙周病手術[含齒齦下刮除術])
            /// </summary>
            [Display(Name = "牙周病手術[含齒齦下刮除術]")]
            [Description("P4")]
            P4,
            /// <summary>
            /// P5 特定治療代碼(兒童斷髓處理)
            /// </summary>
            [Display(Name = "兒童斷髓處理")]
            [Description("P5")]
            P5,
            /// <summary>
            /// P7 特定治療代碼(口腔外科門診手術[包括拔牙])
            /// </summary>
            [Display(Name = "腔外科門診手術[包括拔牙]")]
            [Description("P7")]
            P7,
            /// <summary>
            /// P8 特定治療代碼(治療性牙結石清除)
            /// </summary>
            [Display(Name = "治療性牙結石清除")]
            [Description("P8")]
            P8,
            
            #endregion
            
        }

        

        /// <summary>
        /// 可作為慢籤的事審品項
        /// </summary>
        public enum CanSlowProject
        {
            [Description("005AGR01")]
            VC00007100,

            [Description("005AUB01")]
            VC00038100,

            [Description("005TEC03")]
            VC00039100,

            [Description("005TEC04")]
            VC00040100,

            [Description("005DAC03")]
            BC26354248,

            [Description("005DEM07")]
            BC27930248,

            [Description("005ANA05")] //20241226秀文姊來信新增
            VC00062100
        }

        #endregion OPD ClinicRoom SpiltOrder
        
        /// <summary>
        /// 商之器上傳類別
        /// </summary>
        public enum EBMRequestType
        {
            Radiation,
            ReportExam,
            DentalRadiation
        }

        #region IDENTITYCHECK DROPDOWN CHANGED USE METHOD NAME 身分別下拉選單使用相關規則名稱
        /// <summary>
        /// 身分別下拉選單使用相關規則名稱[命名規則(類別_區域_描述):(VISITKIND)_(SECTIONNAME)_(DESCRIPTION)]
        /// </summary>
        public enum IdentityCheckChanged_UseMethodName
        {
            /// <summary>
            /// 初始值
            /// </summary>
            NULL = 0,
            /// <summary>
            /// 門診 科別清單 身分別 醫令對照就醫序號ICXX
            /// </summary>
            OPD_DEPT_IdentityCheck_OrderCode_CardNum,
            /// <summary>
            /// 門診 牙科 CaseType 預防保健
            /// </summary>
            OPD_DENTAL_CaseType_PreventiveHealthCare,
            /// <summary>
            /// 門診 牙科 CaseType 其他專案
            /// </summary>
            OPD_DENTAL_CaseType_OtherProject,
            /// <summary>
            /// 急診 批價 身分別讀卡
            /// </summary>
            ER_CASHIER_SetIdentityByICCard,
            /// <summary>
            /// 急診 批價 身分別讀卡
            /// </summary>
            OPD_CASHIER_SetIdentityByICCard,
            /// <summary>
            /// 共用 身分別判斷 全部
            /// </summary>
            ALL_IdentityCheck_ReadALLMethod,
            /// <summary>
            /// 共用 身分別判斷 健保卡讀卡
            /// </summary>
            ALL_IdentityCheck_NHIICCard,
            /// <summary>
            /// 共用 身分別判斷 軍警消員工
            /// </summary>
            ALL_IdentityCheck_MilitaryPoliceFireManStuff,
            /// <summary>
            /// 共用 身分別判斷 掛號檔紀錄
            /// </summary>
            ALL_IdentityCheck_REG,
            /// <summary>
            /// 共用 身分別判斷 罕病兒童
            /// </summary>
            ALL_IdentityCheck_RareSickChildren,
            /// <summary>
            /// 共用 身分別判斷 下拉選單判斷
            /// </summary>
            ALL_IdentityCheck_DropDownListChanged,
            /// <summary>
            /// 共用 身分別判斷 下拉選單 身分類別屬於非健保(10,20,22)
            /// </summary>
            ALL_IdentityCheck_DropDownListChanged_TypeCodeNoneNHI,
            /// <summary>
            /// 牙醫總額特殊照護計畫醫令
            /// </summary>
            OPD_DENTAL_CaseType_DENBudgetSpecial,
            /// <summary>
            /// 牙科 特殊醫令 91023C
            /// </summary>
            OPD_DENTAL_PayType_91023C,
            /// <summary>
            /// 流感疫苗處置接種費
            /// </summary>
            OPD_FluVaccine_ORDERCODE,
            /// <summary>
            /// 西醫手術醫令
            /// </summary>
            OPD_ClinicSurgery_ORDERCODE,
            /// <summary>
            /// 2023/7/1 部分負擔新制規則
            /// </summary>
            OPD_20230701NewPayType,
            /// <summary>
            /// 刪除轉診單時候強制覆蓋Paytype 
            /// </summary>
            OPD_ReferralDeleteOverridePayType,
            /// <summary>
            /// 建立轉診單時,PayType進行優先權檢核
            /// </summary>
            OPD_ReferralRecordGenerate,
            /// <summary>
            /// LTBI篩檢
            /// </summary>
            OPD_LTBIScreening,
            /// <summary>
            /// LTBI治療
            /// </summary>
            OPD_LTBITreatment,
            /// <summary>
            /// 結核病 ICD10
            /// </summary>
            OPD_TBDiagCodeAndOrderCode,
        }
        #endregion IDENTITYCHECK DROPDOWN CHANGED USE METHOD NAME 身分別下拉選單使用相關規則名稱

        #region 回傳狀態訊息
        /// <summary>
        /// 回傳狀態訊息[Display(Name="中文訊息")]
        /// </summary>
        public enum ReturnMessage
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            NULL = 9999,
            /// <summary>
            /// 成功
            /// </summary>
            [Display(Name = "成功")]
            SUCCESS = 0,
            /// <summary>
            /// 執行
            /// </summary>
            [Display(Name = "執行")]
            EXECUTE = 1,
            /// <summary>
            /// 執行中
            /// </summary>
            [Display(Name = "執行中")]
            EXECUTING = 2,
            /// <summary>
            /// 啟動
            /// </summary>
            [Display(Name = "啟動")]
            ACTIVATE = 3,
            /// <summary>
            /// 取消啟動
            /// </summary>
            [Display(Name = "取消啟動")]
            DEACTIVATE = 4,
            /// <summary>
            /// 警告
            /// </summary>
            [Display(Name = "警告")]
            WARNING = 7,
            /// <summary>
            /// 故障
            /// </summary>
            [Display(Name = "故障")]
            FAULT = 8,
            /// <summary>
            /// 失敗
            /// </summary>
            [Display(Name = "失敗")]
            FAILURE = 9,
            /// <summary>
            /// 失效
            /// </summary>
            [Display(Name = "失效")]
            FAIL = 99,
            /// <summary>
            /// 錯誤
            /// </summary>
            [Display(Name = "錯誤")]
            ERROR = 10,
            /// <summary>
            /// 致命錯誤
            /// </summary>
            [Display(Name = "致命錯誤")]
            FATAL_ERROR = 11,
            /// <summary>
            /// 崩潰
            /// </summary>
            [Display(Name = "崩潰")]
            CRASH = 12,
            /// <summary>
            /// 錯誤擲出
            /// </summary>
            [Display(Name = "錯誤擲出")]
            EXCEPTION = 13,
            /// <summary>
            /// 未執行
            /// </summary>
            [Display(Name = "未執行")]
            NO_PERFORMED = 14,
            /// <summary>
            /// 資料
            /// </summary>
            [Display(Name = "資料")]
            DATA = 15,
            /// <summary>
            /// 需求
            /// </summary>
            [Display(Name = "需求")]
            REQUIRE = 16,
            /// <summary>
            /// 需要
            /// </summary>
            [Display(Name = "詢問")]
            REQUEST = 17,
            /// <summary>
            /// 缺失
            /// </summary>
            [Display(Name = "缺失")]
            MISSING = 18,
            /// <summary>
            /// 初始化
            /// </summary>
            [Display(Name = "初始化")]
            INITIAL = 19,
            /// <summary>
            /// 初始階段
            /// </summary>
            [Display(Name = "初始階段")]
            PHASE0 = 20,
            /// <summary>
            /// 第一階段
            /// </summary>
            [Display(Name = "第一階段")]
            PHASE1 = 21,
            /// <summary>
            /// 第二階段
            /// </summary>
            [Display(Name = "第二階段")]
            PHASE2 = 22,
            /// <summary>
            /// 第三階段
            /// </summary>
            [Display(Name = "第三階段")]
            PHASE3 = 23,
            /// <summary>
            /// 第四階段
            /// </summary>
            [Display(Name = "第四階段")]
            PHASE4 = 24,
            /// <summary>
            /// 第五階段
            /// </summary>
            [Display(Name = "第五階段")]
            PHASE5 = 25,


        }
        #endregion

        #region 健保卡資料上傳版本代碼
        /// <summary>
        /// 健保卡資料上傳版本代碼
        /// </summary>
        public enum NHI_UPLOAD_VERSION
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            [Description("00")]
            NULL,
            /// <summary>
            /// 健保卡1.0
            /// </summary>
            [Display(Name = "1.0")]
            [Description("10")]
            NHI10,
            /// <summary>
            /// 健保卡1.0 重新上傳
            /// </summary>
            [Display(Name = "1.0 重新上傳")]
            [Description("10_XX")]
            NHI10_ReUpload,
            /// <summary>
            /// 健保卡1.0 測試
            /// </summary>
            [Display(Name = "1.0 測試")]
            [Description("10_ZZ")]
            NHI10_ZZ,
            /// <summary>
            /// 健保卡2.0 只在搜尋清單時候使用
            /// </summary>
            [Display(Name = "2.0")]
            [Description("20")]
            NHI20_QueryOnly,
            /// <summary>
            /// 健保卡2.0 正式
            /// </summary>
            [Display(Name = "2.0 正式")]
            [Description("20_A1")]
            NHI20_A1,
            /// <summary>
            /// 健保卡2.0 預檢
            /// </summary>
            [Display(Name = "2.0 預檢")]
            [Description("20_A2")]
            NHI20_A2,
            /// <summary>
            /// 健保卡2.0 介接測試
            /// </summary>
            [Display(Name = "2.0 介接測試")]
            [Description("20_ZZ")]
            NHI20_ZZ,
        }
        #endregion 健保卡資料上傳版本代碼

        #region 健保卡資料上傳旗標
        /// <summary>
        /// 健保卡資料上傳狀態旗標 NHIUPLOAD_REC.UPLOADFLAG
        /// </summary>
        public enum NHI_UPLOADFLAG
        {
            /// <summary>
            /// 未上傳
            /// </summary>
            [Display(Name = "未上傳")]
            N,
            /// <summary>
            /// 已上傳
            /// </summary>
            [Display(Name = "已上傳")]
            Y,
            /// <summary>
            /// 無資料 不須上傳
            /// </summary>
            [Display(Name = "不須上傳")]
            C,
        }

        #endregion

        #region NHIICBase CSHIS x86 DLL Com Server Function Enum
        /*重要設定備註:
          此Enum之 Description 為存放，傳入DLL之相對應 ref Length, 且相同數字之OUTD與LEN，應為相同長度，並使用','來區隔
          此Enum之 Display.Name 為存放讀取DLL之相對應函式名稱，Display.Description 為存放該ref傳入或回傳之相關參數型態，並使用','來區隔
            EX: OUTD為DLL輸出之Buffer, 相對應於CSHIS文件中之 [ [out]pBuffer,為HIS準備之buffer]
                LEN0為DLL輸入及輸出之Buffer的長度, 相對應於CSHIS文件中之 [ [in/out]iBufferLen,為HIS所準備buffer之長度]
                IND為DLL輸入之參數 , 相對應於CSHIS文件中之 [ [in]傳入....]
                INT為DLL輸入或輸出之參數 , 相對應於CSHIS文件中之 [ [in/out]傳入欲讀取之位置 或回傳讀取之....等]
         */
        /// <summary>
        /// 健保卡CSHIS DLL Enum[存放欲取出之DLL函式名稱(Display.Name)與Ref物件長度(Description)及型態(Display.Description),使用','來區分順序]
        /// </summary>
        public enum NHIICBase_CSHIS_Enum
        {
            /// <summary>
            /// 初始數值
            /// </summary>
            NULL = 0,
            /// <summary>
            /// 1.1 讀取不需個人 PIN 碼資料
            /// </summary>
            [Display(Name = nameof(hisGetBasicData), Description = "OUTD0,LEN0")]
            [Description("72,72")]
            hisGetBasicData,
            /// <summary>
            /// 1.2 掛號或報到時讀取基本資料
            /// </summary>
            [Display(Name = nameof(hisGetRegisterBasic), Description = "OUTD0,LEN0")]
            [Description("78,78")]
            hisGetRegisterBasic,
            /// <summary>
            /// 1.3 預防保健掛號作業
            /// </summary>
            [Display(Name = nameof(hisGetRegisterPrevent), Description = "OUTD0,LEN0")]
            [Description("126,126")]
            hisGetRegisterPrevent,
            /// <summary>
            /// 1.4 孕婦產前檢查掛號作業
            /// </summary>
            [Display(Name = nameof(hisGetRegisterPregnant), Description = "OUTD0,LEN0")]
            [Description("209,209")]
            hisGetRegisterPregnant,
            /// <summary>
            /// 1.5 讀取就醫資料不需 HPC 卡的部分
            /// </summary>
            [Display(Name = nameof(hisGetTreatmentNoNeedHPC), Description = "OUTD0,LEN0")]
            [Description("498,498")]
            hisGetTreatmentNoNeedHPC,
            /// <summary>
            /// 1.6 讀取就醫累計資料
            /// </summary>
            [Display(Name = nameof(hisGetCumulativeData), Description = "OUTD0,LEN0")]
            [Description("134,134")]
            hisGetCumulativeData,
            /// <summary>
            /// 1.7 讀取醫療費用總累計
            /// </summary>
            [Display(Name = nameof(hisGetCumulativeFee), Description = "OUTD0,LEN0")]
            [Description("20,20")]
            hisGetCumulativeFee,
            /// <summary>
            /// 1.8 讀取就醫資料需要 HPC 卡的部份[由COM SERVER內部函式使用ParameterOne來區別回傳之ICD種類,故於此不採用BufferLen]
            /// </summary>
            [Display(Name = nameof(hisGetTreatmentNeedHPC), Description = "OUTD0,LEN0")]
            [Description("540,540")]
            hisGetTreatmentNeedHPC,
            /// <summary>
            /// 1.9 取得就醫序號
            /// </summary>
            [Display(Name = nameof(hisGetSeqNumber), Description = "IND0,IND1,OUTD0,LEN0")]
            [Description("0,0,167,167")]
            hisGetSeqNumber,
            /// <summary>
            /// 1.10 讀取處方箋作業
            /// </summary>
            [Display(Name = nameof(hisReadPrescription), Description = "OUTD0,LEN0,OUTD1,LEN1,OUTD2,LEN2,OUTD3,LEN3")]
            [Description("3660,3660,1320,1320,360,360,120,120")]
            hisReadPrescription,
            /// <summary>
            /// 1.11 讀取預防接種資料
            /// </summary>
            [Display(Name = nameof(hisGetInoculateData), Description = "OUTD0,LEN0")]
            [Description("1400,1400")]
            hisGetInoculateData,
            /// <summary>
            /// 1.12 讀取同意器官捐贈及安寧緩和醫療註記
            /// </summary>
            [Display(Name = nameof(hisGetOrganDonate), Description = "OUTD0,LEN0")]
            [Description("1,1")]
            hisGetOrganDonate,
            /// <summary>
            /// 1.13 讀取緊急聯絡電話資料
            /// </summary>
            [Display(Name = nameof(hisGetEmergentTel), Description = "OUTD0,LEN0")]
            [Description("14,14")]
            hisGetEmergentTel,
            /// <summary>
            /// 1.14 讀取最近一次就醫序號
            /// </summary>
            [Display(Name = nameof(hisGetLastSeqNum), Description = "OUTD0,LEN0")]
            [Description("7,7")]
            hisGetLastSeqNum,
            /// <summary>
            /// 1.15 讀取卡片狀態
            /// </summary>
            [Display(Name = nameof(hisGetCardStatus), Description = "INT0")]
            [Description("1")]
            hisGetCardStatus,
            /// <summary>
            /// 1.16 就醫診療資料寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteTreatmentCode), Description = "IND0,IND1,IND2,IND3,OUTD0")]
            [Description("14,11,8,54,11")]
            hisWriteTreatmentCode,
            /// <summary>
            /// 1.17 就醫費用資料寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteTreatmentFee), Description = "IND0,IND1,IND2,IND3")]
            [Description("14,11,8,38")]
            hisWriteTreatmentFee,
            /// <summary>
            /// 1.18 處方箋寫入作業
            /// </summary>
            [Display(Name = nameof(hisWritePrescription), Description = "IND0,IND1,IND2,IND3")]
            [Description("14,11,8,61")]
            hisWritePrescription,
            /// <summary>
            /// 1.19 新生兒註記寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteNewBorn), Description = "IND0,IND1,IND2,IND3")]
            [Description("11,8,8,2")]
            hisWriteNewBorn,
            /// <summary>
            /// 1.20 過敏藥物寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteAllergicMedicines), Description = "IND0,IND1,IND2,OUTD0")]
            [Description("11,8,120,11")]
            hisWriteAllergicMedicines,
            /// <summary>
            /// 1.21 同意器官捐贈及安寧緩和醫療註記寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteOrganDonate), Description = "IND0,IND1,IND2")]
            [Description("11,8,2")]
            hisWriteOrganDonate,
            /// <summary>
            /// 1.22 預防保健資料寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteHealthInsurance), Description = "IND0,IND1,IND2,IND3")]
            [Description("11,8,3,3")]
            hisWriteHealthInsurance,
            /// <summary>
            /// 1.23 緊急聯絡電話資料寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteEmergentTel), Description = "IND0,IND1,IND2")]
            [Description("11,8,15")]
            hisWriteEmergentTel,
            /// <summary>
            /// 1.24 寫入產前檢查資料
            /// </summary>
            [Display(Name = nameof(hisWritePredeliveryCheckup), Description = "IND0,IND1,IND2")]
            [Description("11,8,3")]
            hisWritePredeliveryCheckup,
            /// <summary>
            /// 1.25 清除產前檢查資料
            /// </summary>
            [Display(Name = nameof(hisWritePredeliveryCheckup), Description = "IND0,IND1")]
            [Description("11,8")]
            hisDeletePredeliveryData,
            /// <summary>
            /// 1.26 預防接種資料寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteInoculateData), Description = "IND0,IND1,IND2,IND3")]
            [Description("11,8,7,13")]
            hisWriteInoculateData,
            /// <summary>
            /// 1.27 驗證健保 IC 卡之 PIN 值
            /// </summary>
            [Display(Name = nameof(csVerifyHCPIN), Description = "")]
            [Description("")]
            csVerifyHCPIN,
            /// <summary>
            /// 1.28 輸入新的健保 IC 卡 PIN 值
            /// </summary>
            [Display(Name = nameof(csInputHCPIN), Description = "")]
            [Description("")]
            csInputHCPIN,
            /// <summary>
            /// 1.29 停用健保 IC 卡之 PIN 碼輸入功能
            /// </summary>
            [Display(Name = nameof(csDisableHCPIN), Description = "")]
            [Description("")]
            csDisableHCPIN,
            /// <summary>
            /// 1.30 健保 IC 卡卡片內容更新作業
            /// </summary>
            [Display(Name = nameof(csUpdateHCContents), Description = "")]
            [Description("")]
            csUpdateHCContents,
            /// <summary>
            /// 1.31 開啟讀卡機連結埠
            /// </summary>
            [Display(Name = nameof(csOpenCom), Description = "INT0")]
            [Description("0")]
            csOpenCom,
            /// <summary>
            /// 1.32 關閉讀卡機連結埠
            /// </summary>
            [Display(Name = nameof(csCloseCom), Description = "")]
            [Description("")]
            csCloseCom,
            /// <summary>
            /// 1.33 讀取重大傷病註記資料[ICD9:114, ICD:138]
            /// </summary>
            [Display(Name = nameof(hisGetCriticalIllness), Description = "OUTD0,LEN0")]
            [Description("138,138")]
            hisGetCriticalIllness,
            /// <summary>
            /// 1.34 讀取讀卡機日期時間
            /// </summary>
            [Display(Name = nameof(csGetDateTime), Description = "OUTD0,LEN0")]
            [Description("13,13")]
            csGetDateTime,
            /// <summary>
            /// 1.35 讀取卡片號碼
            /// </summary>
            [Display(Name = nameof(csGetCardNo), Description = "INT0,OUTD0,LEN0")]
            [Description("0,12,12")]
            csGetCardNo,
            /// <summary>
            /// 1.36 檢查健保 IC 卡是否設定密碼
            /// </summary>
            [Display(Name = nameof(csISSetPIN), Description = "")]
            [Description("")]
            csISSetPIN,
            /// <summary>
            /// 1.37 取得就醫序號新版
            /// </summary>
            [Display(Name = nameof(hisGetSeqNumber256), Description = "IND0,IND1,IND2,OUTD0,LEN0")]
            [Description("3,2,1,296,296")]
            hisGetSeqNumber256,
            /// <summary>
            /// 1.38 掛號或報到時讀取基本資料
            /// </summary>
            [Display(Name = nameof(hisGetRegisterBasic2), Description = "OUTD0,LEN0")]
            [Description("9,9")]
            hisGetRegisterBasic2,
            /// <summary>
            /// 1.39 回復就醫資料累計值（退掛）
            /// </summary>
            [Display(Name = nameof(csUnGetSeqNumber), Description = "IND0")]
            [Description("14")]
            csUnGetSeqNumber,
            /// <summary>
            /// 1.40 健保 IC 卡卡片內容更新作業
            /// </summary>
            [Display(Name = nameof(csUpdateHCNoReset), Description = "")]
            [Description("")]
            csUpdateHCNoReset,
            /// <summary>
            /// 1.41 指定就醫資料只讀取門診處方箋
            /// </summary>
            [Display(Name = nameof(hisReadPrescriptMain), Description = "OUTD0,LEN0,INT0,INT1,INT2")]
            [Description("3660,3660,1,60,60")]
            hisReadPrescriptMain,
            /// <summary>
            /// 1.42 指定就醫資料只讀取長期處方箋
            /// </summary>
            [Display(Name = nameof(hisReadPrescriptLongTerm), Description = "OUTD0,LEN0,INT0,INT1,INT2")]
            [Description("1320,1320,1,30,30")]
            hisReadPrescriptLongTerm,
            /// <summary>
            /// 1.43 指定就醫資料只讀取重要醫令
            /// </summary>
            [Display(Name = nameof(hisReadPrescriptHVE), Description = "OUTD0,LEN0,INT0,INT1,INT2")]
            [Description("360,360,1,10,10")]
            hisReadPrescriptHVE,
            /// <summary>
            /// 1.44 指定就醫資料只讀取過敏藥物
            /// </summary>
            [Display(Name = nameof(hisReadPrescriptAllergic), Description = "OUTD0,LEN0,INT0,INT1,INT2")]
            [Description("120,120,1,3,3")]
            hisReadPrescriptAllergic,
            /// <summary>
            /// 1.45 多筆處方箋寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteMultiPrescript), Description = "IND0,IND1,IND2,IND3,INT0")]
            [Description("14,11,8,3660,60")]
            hisWriteMultiPrescript,
            /// <summary>
            /// 1.46 過敏藥物寫入指定欄位作業
            /// </summary>
            [Display(Name = nameof(hisWriteAllergicNum), Description = "IND0,IND1,IND2,OUTD0,INT0")]
            [Description("11,8,40,11,1")]
            hisWriteAllergicNum,
            /// <summary>
            /// 1.47 就醫診療資料及費用寫入作業
            /// </summary>
            [Display(Name = nameof(hisWriteTreatmentData), Description = "IND0,IND1,IND2,IND3,OUTD0")]
            [Description("14,11,8,93,11")]
            hisWriteTreatmentData,
            /// <summary>
            /// 1.48 處方箋寫入作業並取得回傳之簽章
            /// </summary>
            [Display(Name = nameof(hisWritePrescriptionSign), Description = "IND0,IND1,IND2,IND3,OUTD0,LEN0")]
            [Description("14,11,8,61,40,40")]
            hisWritePrescriptionSign,
            /// <summary>
            /// 1.49 多筆處方箋寫入作業並取得回傳之簽章
            /// </summary>
            [Display(Name = nameof(hisWriteMultiPrescriptSign), Description = "IND0,IND1,IND2,IND3,INT0,OUTD0,LEN0")]
            [Description("14,11,8,3660,60,3660,3660")]
            hisWriteMultiPrescriptSign,
            /// <summary>
            /// 1.50 讀取重大傷病註記資料身分比對
            /// </summary>
            [Display(Name = nameof(hisGetCriticalIllnessID), Description = "IND0,IND1,OUTD0,LEN0")]
            [Description("11,8,138,138")]
            hisGetCriticalIllnessID,
            /// <summary>
            /// 1.51 取得控制軟體版本
            /// </summary>
            [Display(Name = nameof(csGetVersionEx), Description = "OUTD0")]
            [Description("9999")]
            csGetVersionEx,
            /// <summary>
            /// 1.52 提供 His 重置讀卡機或卡片的 API
            /// </summary>
            [Display(Name = nameof(csSoftwareReset), Description = "INT0")]
            [Description("0")]
            csSoftwareReset,
            /// <summary>
            /// 1.53 取得就醫序號新版-就醫識別碼
            /// </summary>
            [Display(Name = nameof(hisGetSeqNumber256N1), Description = "IND0,IND1,IND2,OUTD0,LEN0")]
            [Description("3,2,1,316,316")]
            hisGetSeqNumber256N1,
            /// <summary>
            /// 1.54 異常時取得就醫識別碼
            /// </summary>
            [Display(Name = nameof(hisGetTreatNumNoICCard), Description = "IND0,IND1,OUTD0,LEN0")]
            [Description("11,11,43,43")]
            hisGetTreatNumNoICCard,
            /// <summary>
            /// 1.55 在保狀態查核
            /// </summary>
            [Display(Name = nameof(hisQuickInsurence), Description = "IND0")]
            [Description("3")]
            hisQuickInsurence,
            /// <summary>
            /// 1.56 單獨取得就醫識別碼
            /// </summary>
            [Display(Name = nameof(hisGetTreatNumICCard), Description = "IND0,OUTD0,LEN0")]
            [Description("14,20,20")]
            hisGetTreatNumICCard,
            /// <summary>
            /// 2.1 安全模組（SAM）認證
            /// </summary>
            [Display(Name = nameof(csVerifySAMDC), Description = "")]
            [Description("")]
            csVerifySAMDC,
            /// <summary>
            /// 2.2 讀取 SAM 院所代碼
            /// </summary>
            [Display(Name = nameof(csGetHospID), Description = "OUTD0,LEN0")]
            [Description("10,10")]
            csGetHospID,
            /// <summary>
            /// 2.3 讀取 SAM 院所名稱
            /// </summary>
            [Display(Name = nameof(csGetHospName), Description = "OUTD0,LEN0")]
            [Description("24,24")]
            csGetHospName,
            /// <summary>
            /// 2.4 讀取 SAM 院所簡稱
            /// </summary>
            [Display(Name = nameof(csGetHospAbbName), Description = "OUTD0,LEN0")]
            [Description("128,128")]
            csGetHospAbbName,
            /// <summary>
            /// 3.1 資料上傳
            /// </summary>
            [Display(Name = nameof(csUploadData), Description = "IND0,IND0,INT0,OUTD0,LEN0")]
            [Description("65536,1073741824,0,50,50")] //1G = 1073741824 bytes
            csUploadData,
            /// <summary>
            /// 4.1 取得醫事人員卡狀態
            /// </summary>
            [Display(Name = nameof(hpcGetHPCStatus), Description = "INT0,INT1")]
            [Description("1,0")]
            hpcGetHPCStatus,
            /// <summary>
            /// 4.2 檢查醫事人員卡之 PIN 值
            /// </summary>
            [Display(Name = nameof(hpcVerifyHPCPIN), Description = "")]
            [Description("")]
            hpcVerifyHPCPIN,
            /// <summary>
            /// 4.3 輸入新的醫事人員卡之 PIN 值
            /// </summary>
            [Display(Name = nameof(hpcInputHPCPIN), Description = "")]
            [Description("")]
            hpcInputHPCPIN,
            /// <summary>
            /// 4.4 解開鎖住的醫事人員卡
            /// </summary>
            [Display(Name = nameof(hpcUnlockHPC), Description = "")]
            [Description("")]
            hpcUnlockHPC,
            /// <summary>
            /// 4.5 取得醫事人員卡序號
            /// </summary>
            [Display(Name = nameof(hpcGetHPCSN), Description = "OUTD0,LEN0")]
            [Description("50,50")]
            hpcGetHPCSN,
            /// <summary>
            /// 4.6 取得醫事人員卡身分證字號
            /// </summary>
            [Display(Name = nameof(hpcGetHPCSSN), Description = "OUTD0,LEN0")]
            [Description("20,20")]
            hpcGetHPCSSN,
            /// <summary>
            /// 4.7 取得醫事人員卡中文姓名
            /// </summary>
            [Display(Name = nameof(hpcGetHPCCNAME), Description = "OUTD0,LEN0")]
            [Description("999,999")]
            hpcGetHPCCNAME,
            /// <summary>
            /// 4.8 取得醫事人員卡英文姓名
            /// </summary>
            [Display(Name = nameof(hpcGetHPCENAME), Description = "OUTD0,LEN0")]
            [Description("999,999")]
            hpcGetHPCENAME,
            /// <summary>
            /// 4.9 虛擬醫師卡登出
            /// </summary>
            [Display(Name = nameof(hpcVHPCLogout), Description = "")]
            [Description("")]
            hpcVHPCLogout,
            /// <summary>
            /// 5.1 進行疾病診斷碼押碼
            /// </summary>
            [Display(Name = nameof(hisGetICD10EnC), Description = "IND0,OUTD")]
            [Description("8,8")]
            hisGetICD10EnC,
            /// <summary>
            /// 5.2 進行疾病診斷碼解押碼
            /// </summary>
            [Display(Name = nameof(hisGetICD10DeC), Description = "IND0,OUTD")]
            [Description("8,8")]
            hisGetICD10DeC,
        }
        #endregion NHIICBase CSHIS x86 DLL Com Server Function Enum  

        #region 健保卡 系統呼叫來源
        /// <summary>
        /// NHI 系統呼叫來源
        /// </summary>
        public enum QUERYNHI_SYSTEM_NAME
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "未知來源")]
            NULL = 0,
            /// <summary>
            /// 急診檢傷
            /// </summary>
            [Display(Name = "急診檢傷")]
            ER_TRIAGE,
            /// <summary>
            /// 急診掛號
            /// </summary>
            [Display(Name = "急診掛號")]
            ER_REGISTER,
            /// <summary>
            /// 急診批價
            /// </summary>
            [Display(Name = "急診批價")]
            ER_CASHIER,
            /// <summary>
            /// 門診結案
            /// </summary>
            [Display(Name = "門診結案")]
            OPD_ClinicRoom_Finish,
            /// <summary>
            /// 門診結案慢箋一次領(依照SLOWSICK.SSCOUNT取相對應次數)
            /// </summary>
            [Display(Name = "門診結案慢箋一次領")]
            OPD_ClinicRoom_FinishSlowSickTakeAll,
            /// <summary>
            /// 門診儀錶板
            /// </summary>
            [Display(Name = "門診儀錶板")]
            OPD_ClinicRoom_Dashboard,
            /// <summary>
            /// 門診掛號
            /// </summary>
            [Display(Name = "門診掛號")]
            OPD_REGISTER,
            /// <summary>
            /// 門診批價
            /// </summary>
            [Display(Name = "門診批價")]
            OPD_CASHIER,
            /// <summary>
            /// 門診批價慢箋
            /// </summary>
            [Display(Name = "門診批價慢箋")]
            OPD_CASHIER_SlowSick,
            /// <summary>
            /// 檢驗檢查報到寫處方籤
            /// </summary>
            [Display(Name = "檢驗檢查報到寫處方籤")]
            LISPACS_WEB_WritePrescription,
            /// <summary>
            /// 網頁API於Windows時呼叫Winform程式進行讀卡 取256N1用
            /// </summary>
            [Display(Name = "網頁API使用本地端讀卡程式")]
            HostService_Get256N1,
            /// <summary>
            /// 網頁API於Windows時呼叫Winform程式進行讀卡 取256N1用
            /// </summary>
            [Display(Name = "網頁API使用本地端讀卡程式")]
            OPD_Cashier_Get256N1,
            /// <summary>
            /// 門診品修
            /// </summary>
            [Display(Name = "門診品修")]
            OPD_CureEditorQuery,
            /// <summary>
            /// 門診品修 補健保上傳醫令資料
            /// </summary>
            [Display(Name = "門診品修 補健保上傳醫令資料")]
            OPD_CureEditorQuery_SupplyOrder,
            /// <summary>
            /// 急診品修
            /// </summary>
            [Display(Name = "急診品修")]
            ER_CureEditorQuery,

        }
        #endregion 健保卡 系統呼叫來源

        #region 呼叫來源
        /// <summary>
        /// 呼叫來源
        /// </summary>
        public enum CALL_SYSTEM
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            NULL,
            /// <summary>
            /// 門診儀錶板
            /// </summary>
            [Display(Name = "門診儀錶板")]
            OPD_Dashboard,
            /// <summary>
            /// 門診診間
            /// </summary>
            [Display(Name = "門診診間")]
            OPD_ClinicRoom,
            /// <summary>
            /// 門診診間套餐
            /// </summary>
            [Display(Name = "門診診間套餐")]
            OPD_ClinicRoom_PackageOrder,
            /// <summary>
            /// 門診診間結案
            /// </summary>
            [Display(Name = "門診診間結案")]
            OPD_ClinicRoom_Finish,
            /// <summary>
            /// 門診診間結案身分確認視窗
            /// </summary>
            [Display(Name = "門診診間結案身分確認視窗")]
            OPD_ClinicRoom_Finish_IdentityVerification,
            /// <summary>
            /// 門診診間非結案身分確認視窗
            /// </summary>
            [Display(Name = "門診診間非結案身分確認視窗")]
            OPD_ClinicRoom_IdentityVerification,
            /// <summary>
            /// 套餐維護程式
            /// </summary>
            [Display(Name = "套餐維護程式")]
            Maintain_PackageOrder,
            /// <summary>
            /// 門診批價品項修正
            /// </summary>
            [Display(Name = "門診批價品項修正")]
            OPD_Cashier_CureEditor,
            /// <summary>
            /// 急診批價品項修正
            /// </summary>
            [Display(Name = "急診批價品項修正")]
            ER_Cashier_CureEditor,
            /// <summary>
            /// 門診化療
            /// </summary>
            [Display(Name = "門診化療")]
            OPD_Chem,
            /// <summary>
            /// 批價底層
            /// </summary>
            [Display(Name = "批價底層")]
            Cashier_Logical,
            /// <summary>
            /// 急診診間
            /// </summary>
            [Display(Name = "急診診間")]
            ER_SOAPClinicRoom,

        }
        #endregion 呼叫來源

        #region REG_CHANGERECORD
        /// <summary>
        /// REG_CHANGERECORD.SYSTEM 
        /// </summary>
        public enum Reg_ChangeRecordSystem
        {
            /// <summary>
            /// 門診診間結案身分確認視窗
            /// </summary>
            [Display(Name = "門診診間結案身分確認視窗")]
            OPD_ClinicRoom_Finish_IdentityVerification,
            /// <summary>
            /// 門診診間結案身分確認視窗 未儲存離開
            /// </summary>
            [Display(Name = "門診診間結案身分確認視窗 未儲存離開")]
            OPD_ClinicRoom_Finish_CancelIdentityVerification,
            /// <summary>
            /// 門診診間健保卡讀取紀錄
            /// </summary>
            [Display(Name = "門診診間健保卡讀取紀錄")]
            OPD_ClinicRoom_Finish_NHIRecordReport,
            /// <summary>
            /// 門診診間HISEDIT未異動紀錄(因IP或MachineName或ProcessID不一致)
            /// </summary>
            [Display(Name = "門診診間HISEDIT未異動紀錄")]
            OPD_ClinicRoom_HISEDITUnchange,
            /// <summary>
            /// 門診批價
            /// </summary>
            [Display(Name = "門診批價")]
            OpdCashier,
            /// <summary>
            /// 門診品修
            /// </summary>
            [Display(Name = "門診品修")]
            OpdCureRec,
            /// <summary>
            /// 急診批價
            /// </summary>
            [Display(Name = "急診批價")]
            ErCashier,
            /// <summary>
            /// 門診居家照護於正式區確認病患報到
            /// </summary>
            [Display(Name = "門診居家照護於正式區確認病患報到")]
            OPD_Dashboard_HomeCareConfirmPatientCheckIn,
            /// <summary>
            /// 門診身分確認讀取就醫序號失敗
            /// </summary>
            [Display(Name = "門診身分確認讀取就醫序號失敗")]
            OPD_CR_IdentityVerification_CardNumFailure,
            /// <summary>
            /// 門診身分確認讀取就醫序號成功
            /// </summary>
            [Display(Name = "門診身分確認讀取就醫序號成功")]
            OPD_CR_IdentityVerification_CardNumSuccess,
            /// <summary>
            /// 門診身分確認讀取就醫序號逾時
            /// </summary>
            [Display(Name = "門診身分確認讀取就醫序號逾時")]
            OPD_CR_IdentityVerification_CardNumTimeOut,
            /// <summary>
            /// 共用診間更新ICLOAD相關資料
            /// </summary>
            [Display(Name = "共用診間更新ICLOAD相關資料")]
            PublicClinicRoom_UpdateIcloadData,
            /// <summary>
            /// 門診身分確認執行時間Log
            /// </summary>
            [Display(Name = "門診身分確認執行時間Log")]
            OPD_CR_IdentityVerification_ExecuteLog,
            /// <summary>
            /// 門診診間進入住院檢核時異動身分別為民眾
            /// </summary>
            [Display(Name = "門診診間進入住院檢核時異動身分別為民眾")]
            OPD_CR_REC_INPAT_Change,
        }
        #endregion REG_CHANGERECORD

        #region MyRegion
        /// <summary>
        /// 掛號方式 (尚未補完)
        /// </summary>
        public enum REGMETHOD
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            [Description("00")]
            NULL = 0,
            /// <summary>
            /// 國際醫療門診(國內)
            /// </summary>
            [Display(Name = "國際醫療門診(國內)")]
            [Description("01")]
            InternationalMedicalClinic_Domestic,

            /// <summary>
            /// 高階長官門診
            /// </summary>
            [Display(Name = "高階長官門診")]
            [Description("02")]
            SeniorOfficersClinic,

            /// <summary>
            /// 國際醫療門診(國外)
            /// </summary>
            [Display(Name = "國際醫療門診(國外)")]
            [Description("03")]
            InternationalMedicalClinic_Overseas,

            /// <summary>
            /// 國際醫療門診(員榮)
            /// </summary>
            [Display(Name = "國際醫療門診(員榮)")]
            [Description("05")]
            InternationalMedicalClinic_StaffVeterans,

            /// <summary>
            /// 櫃台掛號
            /// </summary>
            [Display(Name = "櫃台掛號")]
            [Description("10")]
            CounterRegistration,

            /// <summary>
            /// 醫師現場約診
            /// </summary>
            [Display(Name = "醫師現場約診")]
            [Description("11")]
            DoctorOnSiteAppointment,

            /// <summary>
            /// 櫃台預約
            /// </summary>
            [Display(Name = "櫃台預約")]
            [Description("14")]
            CounterAppointment,

            /// <summary>
            /// 櫃台初診預約掛號
            /// </summary>
            [Display(Name = "櫃台初診預約掛號")]
            [Description("15")]
            CounterFirstAppointmentRegistration,

            /// <summary>
            /// 住院31日回診
            /// </summary>
            [Display(Name = "住院31日回診")]
            [Description("16")]
            IPDReturnVisitOn31Days,

            /// <summary>
            /// 住院31日預約回診
            /// </summary>
            [Display(Name = "住院31日預約回診")]
            [Description("17")]
            IPDAppointmentVisitOn31Days,

            /// <summary>
            /// 語音掛號
            /// </summary>
            [Display(Name = "語音掛號")]
            [Description("20")]
            VoiceRegistration,

            /// <summary>
            /// 醫師現場特約診
            /// </summary>
            [Display(Name = "醫師現場特約診")]
            [Description("21")]
            DoctorOnSiteSpecialAppointment,

            /// <summary>
            /// 語音預約
            /// </summary>
            [Display(Name = "語音預約")]
            [Description("24")]
            VoiceAppointment,

            /// <summary>
            /// 語音初診掛號
            /// </summary>
            [Display(Name = "語音初診掛號")]
            [Description("25")]
            VoiceFirstAppointmentRegistration,

            /// <summary>
            /// 自動櫃台
            /// </summary>
            [Display(Name = "自動櫃台")]
            [Description("30")]
            AutomaticCounter,

            /// <summary>
            /// 自動櫃台預約
            /// </summary>
            [Display(Name = "自動櫃台預約")]
            [Description("34")]
            AutomaticCounterAppointment,

            /// <summary>
            /// IOS 掛號
            /// </summary>
            [Display(Name = "IOS 掛號")]
            [Description("35")]
            IosRegistration,

            /// <summary>
            /// Win8 掛號
            /// </summary>
            [Display(Name = "Win8 掛號")]
            [Description("36")]
            Win8Registration,

            /// <summary>
            /// Android 掛號
            /// </summary>
            [Display(Name = "Android 掛號")]
            [Description("37")]
            AndroidRegistration,

            /// <summary>
            /// LINE 掛號
            /// </summary>
            [Display(Name = "LINE 掛號")]
            [Description("38")]
            lineRegistration,

            /// <summary>
            /// 急診櫃台
            /// </summary>
            [Display(Name = "急診櫃台")]
            [Description("40")]
            EmergencyCounter,

            /// <summary>
            /// C肝特約診
            /// </summary>
            [Display(Name = "C肝特約診")]
            [Description("41")]
            SpecialAppointmentHepatitisC,

            /// <summary>
            /// COVID19醫師特約診
            /// </summary>
            [Display(Name = "COVID19醫師特約診")]
            [Description("42")]
            COVID19DoctorSpecialAppointment,

            /// <summary>
            /// 醫師預約
            /// </summary>
            [Display(Name = "醫師預約")]
            [Description("44")]
            DoctorAppointment,

            /// <summary>
            /// 無掛號批價
            /// </summary>
            [Display(Name = "無掛號批價")]
            [Description("50")]
            NoRegisteredPricing,

            /// <summary>
            /// 新陳代謝科CKD
            /// </summary>
            [Display(Name = "新陳代謝科CKD")]
            [Description("52")]
            CKD,

            /// <summary>
            /// 腎臟科AKD
            /// </summary>
            [Display(Name = "腎臟科AKD")]
            [Description("53")]
            AKD,

            /// <summary>
            /// 醫師預約特約診
            /// </summary>
            [Display(Name = "醫師預約特約診")]
            [Description("54")]
            DoctorAppointmentSpecialAppointment,

            /// <summary>
            /// 腎臟科Pre_ESRD
            /// </summary>
            [Display(Name = "腎臟科Pre_ESRD")]
            [Description("55")]
            Pre_ESRD,

            /// <summary>
            /// 健保藥事照護科CKD/AKD
            /// </summary>
            [Display(Name = "健保藥事照護科CKD/AKD")]
            [Description("56")]
            NHIPharmaceuticalCareDivisionCKDAKD,

            /// <summary>
            /// 急診轉科
            /// </summary>
            [Display(Name = "急診轉科")]
            [Description("60")]
            EmergencyTransfer,

            /// <summary>
            /// 急診轉區
            /// </summary>
            [Display(Name = "急診轉區")]
            [Description("61")]
            EmergencyTransferArea,

            /// <summary>
            /// HIS2急診掛號紀錄
            /// </summary>
            [Display(Name = "HIS2急診掛號紀錄")]
            [Description("62")]
            HIS2EmergencyRegistrationRecord,

            /// <summary>
            /// 網路預約掛號(舊版)
            /// </summary>
            [Display(Name = "網路預約掛號(舊版)")]
            [Description("64")]
            OldOnlineAppointmentRegistration,

            /// <summary>
            /// 網路預約掛號(新版)
            /// </summary>
            [Display(Name = "網路預約掛號(新版)")]
            [Description("65")]
            OnlineAppointmentRegistration,

            /// <summary>
            /// 同一療程
            /// </summary>
            [Display(Name = "同一療程")]
            [Description("70")]
            SameCourseTreatment,

            /// <summary>
            /// 網路初診掛號
            /// </summary>
            [Display(Name = "網路初診掛號")]
            [Description("74")]
            OnlineFirstRegistration,

            /// <summary>
            /// 網路現場掛號
            /// </summary>
            [Display(Name = "網路現場掛號")]
            [Description("75")]
            OnlineOnSiteRegistration,

            /// <summary>
            /// AIOTCenter
            /// </summary>
            [Display(Name = "AIOTCenter")]
            [Description("76")]
            AIOTCenter,

            /// <summary>
            /// 遠距醫療會診
            /// </summary>
            [Display(Name = "遠距醫療會診")]
            [Description("77")]
            TelemedicineConsultation,

            /// <summary>
            /// 共病LTBI篩檢
            /// </summary>
            [Display(Name = "共病LTBI篩檢")]
            [Description("78")]
            Comorbid_LTBI_Screening,

            /// <summary>
            /// 共病LTBI治療
            /// </summary>
            [Display(Name = "共病LTBI治療")]
            [Description("79")]
            Comorbid_LTBI_Treatment,

            /// <summary>
            /// 連續處方
            /// </summary>
            [Display(Name = "連續處方")]
            [Description("80")]
            ContinuousPrescription,

            /// <summary>
            /// 委託代檢
            /// </summary>
            [Display(Name = "委託代檢")]
            [Description("90")]
            EntrustInspectionAgency,

            /// <summary>
            /// 批次掛號
            /// </summary>
            [Display(Name = "批次掛號")]
            [Description("AA")]
            BatchRegistration,

            /// <summary>
            /// 子宮頸抹片篩檢掛號
            /// </summary>
            [Display(Name = "子宮頸抹片篩檢掛號")]
            [Description("AB")]
            PapSmearScreeningRegistration,

            /// <summary>
            /// 乳癌篩檢掛號
            /// </summary>
            [Display(Name = "乳癌篩檢掛號")]
            [Description("AC")]
            BreastCancerScreeningRegistration,

            /// <summary>
            /// 大腸直腸癌篩檢掛號
            /// </summary>
            [Display(Name = "大腸直腸癌篩檢掛號")]
            [Description("AD")]
            ColorectalCancerScreeningRegistration,

            /// <summary>
            /// 口腔癌篩檢掛號
            /// </summary>
            [Display(Name = "口腔癌篩檢掛號")]
            [Description("AE")]
            OralCancerScreeningRegistration,

            /// <summary>
            /// 病人特別門診
            /// </summary>
            [Display(Name = "病人特別門診")]
            [Description("SP")]
            SpecialPatientClinic,

        }

        #endregion

        #region OsVersion
        /// <summary>
        /// 作業系統代碼(Windows 非伺服器版本)
        /// </summary>
        public enum OsVersion
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "初始值")]
            Null = 0,
            /// <summary>
            /// 無法識別之作業系統版本
            /// </summary>
            [Display(Name = "無法識別之作業系統版本")]
            UnknownOsVersion = 1,
            /// <summary>
            /// 版本低於Win2000(Win98, WinNT...等
            /// </summary>
            [Display(Name = "低於 Windows 2000")]
            LessThanWin2000 = 2,
            /// <summary>
            /// Win2000
            /// </summary>
            [Display(Name = "Windows 2000")]
            Win2000 = 3,
            /// <summary>
            /// Windows XP 64位元
            /// </summary>
            [Display(Name = "Windows XP 64位元")]
            WinXPx64 = 4,
            /// <summary>
            /// Windows XP 32位元
            /// </summary>
            [Display(Name = "Windows XP 32位元")]
            WinXPx86 = 5,
            /// <summary>
            /// Windows Vista
            /// </summary>
            [Display(Name = "Windows Vista")]
            WinVista = 6,
            /// <summary>
            /// Windows 7
            /// </summary>
            [Display(Name = "Windows 7")]
            Win7 = 7,
            /// <summary>
            /// Windows 8
            /// </summary>
            [Display(Name = "Windows 8")]
            Win8 = 8,
            /// <summary>
            /// Windows 8.1
            /// </summary>
            [Display(Name = "Windows 8.1")]
            Win8_1 = 9,
            /// <summary>
            /// Windows 10
            /// </summary>
            [Display(Name = "Windows 10")]
            Win10 = 10,
            /// <summary>
            /// Windows 11
            /// </summary>
            [Display(Name = "Windows 11")]
            Win11 = 11,
            /// <summary>
            /// Windows 12
            /// </summary>
            [Display(Name = "Windows 12")]
            Win12 = 12,

        }
        #endregion OsVersion

        #region HeavySickSystem_ID
        /// <summary>
        /// 重大傷病 寫入系統別(字元上限20)
        /// </summary>
        public enum HeavySickSystem_ID
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            Null,
            /// <summary>
            /// 轉檔系統
            /// </summary>
            [Display(Name = "轉檔系統")]
            Data_Transfer,
            /// <summary>
            /// 門診診間系統_身分確認_紙本
            /// </summary>
            [Display(Name = "診間紙本")]
            OPD_CR_Paper,
            /// <summary>
            /// 門診診間系統_身分確認_IC卡讀出
            /// </summary>
            [Display(Name = "診間IC卡")]
            OPD_CR_ICCard,
            /// <summary>
            /// 急診_批價_IC卡讀出
            /// </summary>
            [Display(Name = "急診批價IC卡")]
            ER_Cashier,
            /// <summary>
            /// 門診_批價_IC卡讀出
            /// </summary>
            [Display(Name = "門診批價IC卡")]
            OPD_Cashier,
            /// <summary>
            /// 急診_批價_紙本
            /// </summary>
            [Display(Name = "急診批價紙本")]
            ER_Cashier_Paper,
            /// <summary>
            /// 門診_批價_紙本
            /// </summary>
            [Display(Name = "門診批價紙本")]
            OPD_Cashier_Paper,
            /// <summary>
            /// 門診健保署雲端匯入
            /// </summary>
            [Display(Name = "門診雲端匯入")]
            OPD_CR_NHICloud,
        }
        #endregion HeavySickSystem_ID

        #region PPFTYPE
        /// <summary>
        /// 提成類別
        /// ORDERCODEMASTER.PPFTYPE
        /// </summary>
        public enum PPFTYPE
        {
            /// <summary>
            /// 預設數值
            /// </summary>
            [Display(Name = "預設數值")]
            Null = 99,
            /// <summary>
            /// 醫院提成
            /// </summary>
            [Display(Name = "醫院提成")]
            Hospital = 0,
            /// <summary>
            /// 主治醫生提成
            /// </summary>
            [Display(Name = "主治醫生提成")]
            VsDoctor = 1,
            /// <summary>
            /// 主治醫生或科室提成
            /// </summary>
            [Display(Name = "主治醫生或科室提成")]
            VsDoctorOrDept = 2,
            /// <summary>
            /// 科室提成
            /// </summary>
            [Display(Name = "科室提成")]
            Dept = 3,

        }
        #endregion PPFTYPE

        #region 診間 特殊掛號身分
        /// <summary>
        /// 診間 特殊掛號身分
        /// </summary>
        public enum OPD_ClinicRoom_SpecialRegister
        {
            /// <summary>
            /// 預設值
            /// </summary>
            NULL,
            /// <summary>
            /// 子宮頸篩檢 IC31
            /// </summary>
            [Display(Name = "使用子宮頸篩檢IC31身分別")]
            IC31,
            /// <summary>
            /// 大腸篩檢 IC85
            /// </summary>
            [Display(Name = "使用大腸篩檢IC85身分別")]
            IC85,
            /// <summary>
            /// 乳房篩檢 IC91
            /// </summary>
            [Display(Name = "使用乳房篩檢IC91身分別")]
            IC91,
            /// <summary>
            /// 大腸篩檢-糞便潛血 IC94
            /// </summary>
            [Display(Name = "使用大腸篩檢IC94身分別")]
            IC94,
            /// <summary>
            /// 口腔篩檢 IC95
            /// </summary>
            [Display(Name = "使用口腔篩檢IC95身分別")]
            IC95,
            /// <summary>
            /// 使用LBTI篩檢 78
            /// </summary>
            [Display(Name = "使用LBTI篩檢")] 
            LBTIScreening,
            /// <summary>
            /// 使用LBTI治療 79
            /// </summary>
            [Display(Name = "使用LBTI治療")] 
            LBTITreatment,
        }
        /// <summary>
        /// 門診身分確認 特殊規則 不計算身分別(直接載入掛號身分別)
        /// Enum命名規則(_科別_身分別NAME+VALUE_備註):_[DEPT]_[KIND][KIND_VALUE]_[NOTE]
        /// </summary>
        public enum OPD_IdentityVerifitation_SpecialMethodWhitoutCalcID
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name = "")]
            [Description("")]
            Null,
            /// <summary>
            /// 產科 307 VIPID 107
            /// </summary>
            [Display(Name = "產科特殊優待類別")]
            [Description("")]
            _307_VIPID107,
            /// <summary>
            /// 流感疫苗門診 117,118
            /// </summary>
            [Display(Name = "流感疫苗門診")]
            [Description("")]
            _117118_Flu,
            /// <summary>
            /// 916長照結核計畫身分
            /// </summary>
            [Display(Name = "916長照結核計畫身分")]
            [Description("")]
            _TB_PAYTYPE916,
        }
        #endregion 診間 特殊掛號身分

        #region 住院 IPD

        #region INACARM.GOVERBUDGETCODE
        /// <summary>
        /// 住院IPD主表 INACARM.GOVERBUDGETCODE 身分別
        /// </summary>
        public enum INACARM_GOVERBUDGETCODE
        {
            /// <summary>
            /// 預設數值
            /// </summary>
            NULL,
            /// <summary>
            /// 公務預算病患, (預留)
            /// </summary>
            Y,
            /// <summary>
            /// 自費護理之家病患
            /// </summary>
            C,
            /// <summary>
            /// 一般病患(健保、自費)
            /// </summary>
            N,
        }

        #endregion

        #endregion

        #region HOMECARE_LOG KIND
        /// <summary>
        /// HomeCare_LOG.KIND (Enum.Description為對應之TableName)
        /// </summary>
        public enum HOMECARE_LOG_KIND
        {
            /// <summary>
            /// 初始化
            /// </summary>
            NULL,
            /// <summary>
            /// LOG_APPLICATION_INFO
            /// </summary>
            [Description("LOG_APPLICATION_INFO")] 
            INFO,
            /// <summary>
            /// LOG_APPLICATION_DEBUG
            /// </summary>
            [Description("LOG_APPLICATION_DEBUG")] 
            DEBUG,
            /// <summary>
            /// LOG_APPLICATION_ERROR
            /// </summary>
            [Description("LOG_APPLICATION_ERROR")]
            ERROR
        }


        #endregion

        #region R00
        /// <summary>
        /// 虛擬醫令代碼 20240701建立 (R00X)
        /// </summary>
        public enum VirtualMedicalOrderCode
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("")]
            Null,
            /// <summary>
            /// 慢箋, 重複藥物, 藥費核扣檢核結果(按Ctrl可多選)
            /// </summary>
            [Display(Name = "慢箋, 重複藥物, 藥費核扣檢核結果(按Ctrl可多選)")]
            [Description("")]
            Source,
            /// <summary>
            /// R001:因處方箋遺失或損毀，提供切結文件，提前回診，且經院所查詢健保雲端藥歷系統，確認病人未領取所稱遺失或毀損處方之藥品
            /// </summary>
            [Display(Name = "因處方箋遺失或損毀，提供切結文件，提前回診，且經院所查詢健保雲端藥歷系統，確認病人未領取所稱遺失或毀損處方之藥品")]
            [Description("")]
            R001,
            /// <summary>
            /// R002:因醫師請假因素，提前回診，醫事服務暨購留存醫師請假證明資料備查
            /// </summary>
            [Display(Name = "因醫師請假因素，提前回診，醫事服務暨購留存醫師請假證明資料備查")]
            [Description("")]
            R002,
            /// <summary>
            /// R003:經醫師專業認定需要改藥或調整藥品劑量或換藥者
            /// </summary>
            [Display(Name = "經醫師專業認定需要改藥或調整藥品劑量或換藥者")]
            [Description("")]
            R003,
            /// <summary>
            /// R004:其他非屬R001~R003之提前回診或慢性病連續處方箋提前領取藥品或其他等病人因素，提供切結文件或於病歷中詳細記載原因備查
            /// </summary>
            [Display(Name = "其他非屬R001~R003之提前回診或慢性病連續處方箋提前領取藥品或其他等病人因素，提供切結文件或於病歷中詳細記載原因備查")]
            [Description("")]
            R004,
            /// <summary>
            /// R005:民眾健保卡加密或其他健保卡問題致無法查詢健保雲端資訊，並於病歷中記載原因備查
            /// </summary>
            [Display(Name = "民眾健保卡加密或其他健保卡問題致無法查詢健保雲端資訊，並於病歷中記載原因備查")]
            [Description("")]
            R005,
            /// <summary>
            /// R006:醫院轉出(或回轉)病人至診所第1次就醫且符合轉診申報規定，經查詢雲端藥歷系統有餘藥，已向病人衛教並於病歷中詳細記載原因備查後處方
            /// </summary>
            [Display(Name = "醫院轉出(或回轉)病人至診所第1次就醫且符合轉診申報規定，經查詢雲端藥歷系統有餘藥，已向病人衛教並於病歷中詳細記載原因備查後處方")]
            [Description("")]
            R006,
            /// <summary>
            /// R007:配合衛福部食品藥物管理署公告藥品回收，重新開立處方給病人，並於病歷中記載原因備查
            /// </summary>
            [Display(Name = "配合衛福部食品藥物管理署公告藥品回收，重新開立處方給病人，並於病歷中記載原因備查")]
            [Description("")]
            R007,
            /// <summary>
            /// R008:醫師查詢雲端或API系統提示病人有重複用藥情事，經向病人確認後排除未領藥紀錄，其餘藥天數小於(含)10天開立處方，並於病歷中詳細記載原因備查
            /// </summary>
            [Display(Name = "醫師查詢雲端或API系統提示病人有重複用藥情事，經向病人確認後排除未領藥紀錄，其餘藥天數小於(含)10天開立處方，並於病歷中詳細記載原因備查")]
            [Description("")]
            R008,
        }


        #endregion

        #region ICCARD DNR

        /// <summary>
        /// IC Card DNR 
        /// </summary>
        public enum IcDnrCode
        {
            /// <summary>
            /// 查無資料 0
            /// </summary>
            [Display(Name = "查無資料")]
            [Description("0")]
            Null = 0,
            /// <summary>
            /// 同意器官捐贈 1
            /// </summary>
            [Display(Name = "同意器官捐贈。")]
            [Description("1")]
            ConsentToOrganDonation = 1,
            /// <summary>
            /// 同意安寧緩和醫療 2
            /// </summary>
            [Display(Name = "同意安寧緩和醫療。")]
            [Description("2")]
            AgreeToPeaceAndEaseMedicalCare = 2,
            /// <summary>
            /// 同意不施行心肺復甦術 3
            /// </summary>
            [Display(Name = "同意不施行心肺復甦術。")]
            [Description("3")]
            AgreeNotToImplementCPR = 3,
            /// <summary>
            /// 同意器官捐贈、
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療。(舊)。 4
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療、\r\n同意不施行心肺復甦術、\r\n同意不施行維生醫療。(舊)。")]
            [Description("4")]
            AgreeOrganDonationAndPeaceEaseMedicalCareAndLifeSavingNotCPR = 4,
            /// <summary>
            /// 同意器官捐贈、
            /// 同意安寧緩和醫療。 5
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療。")]
            [Description("5")]
            AgreeOrganDonationAndPeaceEaseMedicalCare = 5,
            /// <summary>
            /// 同意器官捐贈、
            /// 同意不施行心肺復甦術 6
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意不施行心肺復甦術。")]
            [Description("6")]
            AgreeOrganDonationNotCPR = 6,
            /// <summary>
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療。(舊) 7
            /// </summary>
            [Display(Name = "同意安寧緩和醫療、\r\n同意不施行心肺復甦術、\r\n同意不施行維生醫療。(舊)。")]
            [Description("7")]
            AgreeOrganDonationAndPeaceEaseMedicalCareNotLifeSavingNotCPR = 7,
            /// <summary>
            /// 同意不施行維生醫療 A
            /// </summary>
            [Display(Name = "同意不施行維生醫療。")]
            [Description("A")]
            AgreeNotLifeSaving = 65,        //ASCII A
            /// <summary>
            /// 同意器官捐贈、
            /// 同意不施行維生醫療 B
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意不施行維生醫療。")]
            [Description("B")]
            AgreeOrganDonationNotLifeSaving = 66,        //ASCII B
            /// <summary>
            /// 同意安寧緩和醫療 C
            /// </summary>
            [Display(Name = "同意安寧緩和醫療\r\n同意不施行維生醫療。")]
            [Description("C")]
            AgreePeaceEaseMedicalCareNotLifeSaving = 67,        //ASCII C
            /// <summary>
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療 D
            /// </summary>
            [Display(Name = "同意不施行心肺復甦術、\r\n同意不施行維生醫療。")]
            [Description("D")]
            AgreeNotCPRNotLifeSaving = 68,        //ASCII D
            /// <summary>
            /// 同意器官捐贈、
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療 E
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療、\r\n同意不施行心肺復甦術、\r\n同意不施行維生醫療。")]
            [Description("E")]
            AgreeOragonDonationPeaceEaseMedicalCareNotCPRNotLifeSaving = 69,        //ASCII E
            /// <summary>
            /// 同意器官卷贈、
            /// 同意安寧緩和醫療、
            /// 同意不施行維生醫療 F
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療、\r\n同意不施行維生醫療。")]
            [Description("F")]
            AgreeOragonDonationPeaceEaseMedicalCareNotLifeSaving = 70,        //ASCII F
            /// <summary>
            /// 同意器官捐贈、
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療 G
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意不施行心肺復甦術、\r\n同意不施行維生醫療。")]
            [Description("G")]
            AgreeOragonDonationNotCPRNotLifeSaving = 71,        //ASCII G
            /// <summary>
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療 H
            /// </summary>
            [Display(Name = "同意安寧緩和醫療、\r\n同意不施行心肺復甦術、\r\n同意不施行維生醫療。")]
            [Description("H")]
            AgreePeaceEaseMedicalCareNotCPRNotLifeSaving = 72,        //ASCII H
            /// <summary>
            /// 同意器官捐贈、
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術。 I
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療、\r\n同意不施行心肺復甦術。")]
            [Description("I")]
            AgreeOragonDonationPeaceEaseMedicalCareNotCPR = 73,        //ASCII I
            /// <summary>
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術。 J
            /// </summary>
            [Display(Name = "同意安寧緩和醫療、\r\n同意不施行心肺復甦術。")]
            [Description("J")]
            AgreePeaceEaseMedicalCareNotCPR = 74,        //ASCII J
            /// <summary>
            /// 同意預立醫療決定 K
            /// </summary>
            [Display(Name = "同意預立醫療決定。")]
            [Description("K")]
            AgreeK = 75,        //ASCII K
            /// <summary>
            /// 同意器官捐贈、
            /// 同意預立醫療決定 L
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意預立醫療決定。")]
            [Description("L")]
            AgreeL = 76,        //ASCII L
            /// <summary>
            /// 同意安寧緩和醫療、
            /// 同意預立醫療決定 M
            /// </summary>
            [Display(Name = "同意安寧緩和醫療、\r\n同意預立醫療決定。")]
            [Description("M")]
            AgreeM = 77,        //ASCII M
            /// <summary>
            /// 同意不施行心肺復甦術、
            /// 同意預立醫療決定 N
            /// </summary>
            [Display(Name = "同意不施行心肺復甦術、\r\n同意預立醫療決定。")]
            [Description("N")]
            AgreeN = 78,        //ASCII N
            /// <summary>
            /// 同意器官捐贈、
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術、
            /// 同意預立醫療決定 O
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療、\r\n同意不施行心肺復甦術、\r\n同意預立醫療決定。")]
            [Description("O")]
            AgreeO = 79,        //ASCII O
            /// <summary>
            /// 同意器官捐贈、
            /// 同意安寧緩和醫療、
            /// 同意預立醫療決定 P
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療、\r\n同意預立醫療決定。")]
            [Description("P")]
            AgreeP = 80,        //ASCII P
            /// <summary>
            /// 同意器官捐贈、
            /// 同意不施行心肺復甦術、
            /// 同意預立醫療決定 Q 
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意不施行心肺復甦術、\r\n同意預立醫療決定。")]
            [Description("Q")]
            AgreeQ = 81,        //ASCII Q
            /// <summary>
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術、
            /// 同意預立醫療決定 R
            /// </summary>
            [Display(Name = "同意安寧緩和醫療、\r\n同意不施行心肺復甦術、\r\n同意預立醫療決定。")]
            [Description("R")]
            AgreeR = 82,        //ASCII R
            /// <summary>
            /// 同意不施行維生醫療、
            /// 同意預立醫療決定 S
            /// </summary>
            [Display(Name = "同意不施行維生醫療、\r\n同意預立醫療決定。")]
            [Description("S")]
            AgreeS = 83,        //ASCII S
            /// <summary>
            /// 同意器官捐贈、
            /// 同意不施行維生醫療、
            /// 同意預立醫療決定 T
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意不施行維生醫療、\r\n同意預立醫療決定。")]
            [Description("T")]
            AgreeT = 84,        //ASCII T
            /// <summary>
            /// 同意安寧緩和醫療、
            /// 同意不施行維生醫療、
            /// 同意預立醫療決定 U
            /// </summary>
            [Display(Name = "同意安寧緩和醫療、\r\n同意不施行維生醫療、\r\n同意預立醫療決定。")]
            [Description("U")]
            AgreeU = 85,        //ASCII U
            /// <summary>
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療、
            /// 同意預立醫療決定 V
            /// </summary>
            [Display(Name = "同意不施行心肺復甦術、\r\n同意不施行維生醫療、\r\n同意預立醫療決定。")]
            [Description("V")]
            AgreeV = 86,        //ASCII V
            /// <summary>
            /// 同意器官捐贈、
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療、
            /// 同意預立醫療決定 W 
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療、\r\n同意不施行心肺復甦術、\r\n同意不施行維生醫療、\r\n同意預立醫療決定。")]
            [Description("W")]
            AgreeW = 87,        //ASCII W
            /// <summary>
            /// 同意器官捐贈、
            /// 同意安寧緩和醫療、
            /// 同意不施行維生醫療、
            /// 同意預立醫療決定。 X
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意安寧緩和醫療、\r\n同意不施行維生醫療、\r\n同意預立醫療決定。")]
            [Description("X")]
            AgreeX = 88,        //ASCII X
            /// <summary>
            /// 同意器官捐贈、
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療、
            /// 同意預立醫療決定。 Y
            /// </summary>
            [Display(Name = "同意器官捐贈、\r\n同意不施行心肺復甦術、\r\n同意不施行維生醫療、\r\n同意預立醫療決定。")]
            [Description("Y")]
            AgreeY = 89,        //ASCII Y
            /// <summary>
            /// 同意安寧緩和醫療、
            /// 同意不施行心肺復甦術、
            /// 同意不施行維生醫療、
            /// 同意預立醫療決定。 Z
            /// </summary>
            [Display(Name = "同意安寧緩和醫療、\r\n同意不施行心肺復甦術、\r\n同意不施行維生醫療、\r\n同意預立醫療決定。")]
            [Description("Z")]
            AgreeZ = 90,        //ASCII Z
        }

        #endregion

        #region ISBU 補卡註記
        /// <summary>
        /// 健保卡 補卡註記(可使用ToNumberString(),GetEnumDescription())
        /// </summary>
        public enum IsBu
        {
            /// <summary>
            /// 正常
            /// </summary>
            [Display(Name = "正常")]
            [Description("1")]
            Normal=1,
            /// <summary>
            /// 補卡
            /// </summary>
            [Display(Name = "補卡")]
            [Description("2")]
            ReIssueCard = 2,
            /// <summary>
            /// 新生兒無身分證號補卡:限出生日期&gt;60日且&lt;=92日
            /// </summary>
            [Display(Name = "新生兒無身分證號補卡:限出生日期>60日且<=92日")]
            [Description("3")]
            NewBornWithoutCard = 3,
            /// <summary>
            /// 無實際就醫識別碼補卡(需登錄及報備):路倒或其他於就醫時無法取得身分字號時使用
            /// </summary>
            [Display(Name = "無實際就醫識別碼補卡(需登錄及報備):路倒或其他於就醫時無法取得身分字號時使用")]
            [Description("4")]
            UnkonwnMedidentificationCode = 4,
        }


        #endregion

        #region MEDCLOUD Name
        /// <summary>
        /// 雲端藥歷名稱
        /// </summary>
        public enum MedCloudName
        {
            [Display(Name = "")]
            NULL,
            [Display(Name = "雲端藥歷")]
            MEDCLOUD01,
            [Display(Name = "檢驗檢查")]
            MEDCLOUD02,
            [Display(Name = "手術紀錄")]
            MEDCLOUD03,
            [Display(Name = "牙科處置")]
            MEDCLOUD04,
            [Display(Name = "過敏藥")]
            MEDCLOUD05,
            [Display(Name = "檢驗檢查結果")]
            MEDCLOUD06,
            [Display(Name = "出院病摘")]
            MEDCLOUD07,
            [Display(Name = "復健醫療")]
            MEDCLOUD08,
            [Display(Name = "中藥用藥")]
            MEDCLOUD09,
            [Display(Name = "旅遊接觸")]
            MEDCLOUD10,
            [Display(Name = "新冠肺炎檢驗結果")]
            MEDCLOUD11,
        }


        #endregion

        #region BELONGCODE
        /// <summary>
        /// 軍眷警消海空身分代碼 20240719 建立
        /// </summary>
        public enum BelongCode
        {
            /// <summary>
            /// 初始值
            /// </summary>
            [Display(Name="初始值")]
            [Description("")]
            Null,
            /// <summary>
            /// 軍眷
            /// </summary>
            [Display(Name = "軍眷")]
            [Description("E")]
            E,
            /// <summary>
            /// 海巡署
            /// </summary>
            [Display(Name = "海巡署")]
            [Description("J")]
            J,
            /// <summary>
            /// 警察大學
            /// </summary>
            [Display(Name = "警察大學")]
            [Description("K")]
            K,
            /// <summary>
            /// 消防
            /// </summary>
            [Display(Name = "消防")]
            [Description("L")]
            L,
            /// <summary>
            /// 空勤總隊
            /// </summary>
            [Display(Name = "空勤總隊")]
            [Description("M")]
            M,
            /// <summary>
            /// 警察
            /// </summary>
            [Display(Name = "警察")]
            [Description("N")]
            N,
            /// <summary>
            /// 移民署
            /// </summary>
            [Display(Name = "移民署")]
            [Description("P")]
            P,
        }


        #endregion

        #region FIDRELA
        /// <summary>
        /// HISMEDD.FIDRELA 員工眷屬關係代碼
        /// </summary>
        public enum Fidrela
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("0")]
            Null = 0,
            /// <summary>
            /// 子女 1
            /// </summary>
            [Display(Name = "子女")]
            [Description("1")]
            Children = 1,
            /// <summary>
            /// 父母 2
            /// </summary>
            [Display(Name = "父母")]
            [Description("2")]
            Parents = 2,
            /// <summary>
            /// 本人 3
            /// </summary>
            [Display(Name = "本人")]
            [Description("3")]
            Self = 3,
            /// <summary>
            /// 祖父母 4
            /// </summary>
            [Display(Name = "祖父母")]
            [Description("4")]
            Grandparents = 4,
            /// <summary>
            /// 配偶 5
            /// </summary>
            [Display(Name = "配偶")]
            [Description("5")]
            Spouse = 5
        }
        #endregion FIDRELA
        
        #region NHI ICCard hisGetCardStatus
        /// <summary>
        /// hisGetCardStatus (讀取卡片狀態)
        /// [Display.Name = 狀態文字, Display.Order=(int)CardType, Dislay.AutoGenerateField=[True:卡片驗證完成, False:], Description=健保函式回傳數字]
        /// CardType:1安全模組檔,2:健保IC卡3:醫事人員卡
        /// </summary>
        public enum hisGetCardStatus_CardStatus
        {
            /// <summary>
            /// 預設數值
            /// </summary>
            [Display(Name = "預設數值", AutoGenerateField = false, Order = 0)]
            [Description("-1")]
            NULL,
            #region SAM
            /// <summary>
            /// 安全模組檔 4000
            /// </summary>
            [Display(Name = "讀卡機TimeOut", AutoGenerateField = false, Order = 1)]
            [Description("4000")]
            SAM_4000,
            /// <summary>
            /// 安全模組檔 0 卡片未置入
            /// </summary>
            [Display(Name = "卡片未置入", AutoGenerateField = false, Order = 1)]
            [Description("0")]
            SAM_0,
            /// <summary>
            /// 安全模組檔 1 安全模組尚未與健保局IDC認證
            /// </summary>
            [Display(Name = "安全模組尚未與健保局IDC認證", AutoGenerateField = false, Order = 1)]
            [Description("1")]
            SAM_1,
            /// <summary>
            /// 安全模組檔 2 安全模組與健保局IDC認證成功
            /// </summary>
            [Display(Name = "安全模組與健保局IDC認證成功", AutoGenerateField = true, Order = 1)]
            [Description("2")]
            SAM_2,
            /// <summary>
            /// 安全模組檔 9 所置入非安全模組檔
            /// </summary>
            [Display(Name = "所置入非安全模組檔", AutoGenerateField = false, Order = 1)]
            [Description("9")]
            SAM_9,

            #endregion

            #region HC

            /// <summary>
            /// 健保IC卡 4000
            /// </summary>
            [Display(Name = "讀卡機TimeOut", AutoGenerateField = false, Order = 2)]
            [Description("4000")]
            HC_4000,
            /// <summary>
            /// 健保IC卡 0 卡片未置入
            /// </summary>
            [Display(Name = "卡片未置入", AutoGenerateField = false, Order = 2)]
            [Description("0")]
            HC_0,
            /// <summary>
            /// 健保IC卡 1 健保IC卡尚未與安全模組認證
            /// </summary>
            [Display(Name = "健保IC卡尚未與安全模組認證", AutoGenerateField = false, Order = 2)]
            [Description("1")]
            HC_1,
            /// <summary>
            /// 健保IC卡 2 健保IC卡與安全模組認證成功
            /// </summary>
            [Display(Name = "健保IC卡與安全模組認證成功", AutoGenerateField = true, Order = 2)]
            [Description("2")]
            HC_2,
            /// <summary>
            /// 健保IC卡 3 健保IC卡與醫事人員卡認證成功
            /// </summary>
            [Display(Name = "健保IC卡與醫事人員卡認證成功", AutoGenerateField = true, Order = 2)]
            [Description("3")]
            HC_3,
            /// <summary>
            /// 健保IC卡 4 健保IC卡PIN認證成功
            /// </summary>
            [Display(Name = "健保IC卡PIN認證成功", AutoGenerateField = true, Order = 2)]
            [Description("4")]
            HC_4,
            /// <summary>
            /// 健保IC卡 5 健保IC卡與健保局IDC認證成功
            /// </summary>
            [Display(Name = "健保IC卡與健保局IDC認證成功", AutoGenerateField = true, Order = 2)]
            [Description("5")]
            HC_5,
            /// <summary>
            /// 健保IC卡 9 所置入非健保IC卡
            /// </summary>
            [Display(Name = "所置入非健保IC卡", AutoGenerateField = false, Order = 2)]
            [Description("9")]
            HC_9,
            #endregion

            #region HCP

            /// <summary>
            /// 醫事人員卡 4000
            /// </summary>
            [Display(Name = "讀卡機TimeOut", AutoGenerateField = false, Order = 3)]
            [Description("4000")]
            HCP_4000,
            /// <summary>
            /// 醫事人員卡 0 卡片未置入
            /// </summary>
            [Display(Name = "卡片未置入", AutoGenerateField = false, Order = 3)]
            [Description("0")]
            HCP_0,
            /// <summary>
            /// 醫事人員卡 1 醫事人員卡尚未與安全模組認證
            /// </summary>
            [Display(Name = "醫事人員卡尚未與安全模組認證", AutoGenerateField = false, Order = 3)]
            [Description("1")]
            HCP_1,
            /// <summary>
            /// 醫事人員卡 2 醫事人員卡與安全模組認證成功(PIN尚未認證)
            /// </summary>
            [Display(Name = "醫事人員卡與安全模組認證成功(PIN尚未認證)", AutoGenerateField = false, Order = 3)]
            [Description("2")]
            HCP_2,
            /// <summary>
            /// 醫事人員卡 3 醫事人員卡PIN認證成功
            /// </summary>
            [Display(Name = "醫事人員卡PIN認證成功", AutoGenerateField = true, Order = 3)]
            [Description("3")]
            HCP_3,
            /// <summary>
            /// 醫事人員卡 9 所置入非醫事人員卡
            /// </summary>
            [Display(Name = "所置入非醫事人員卡", AutoGenerateField = false, Order = 3)]
            [Description("9")]
            HCP_9,
            #endregion
        }

        #endregion

        #region AppConnectionConfigName
        /// <summary>
        /// 三總行動通訊APP 健保卡資料上傳 MonitorSchedule UUID, AppConfig 中 ConnectionName = EunmName,
        /// Description=UUID
        /// </summary>
        public enum TriAppConfigConnnectionName
        {
            /// <summary>
            /// 健保卡1.0 門診西醫
            /// </summary>
            [Display(Name = "健保卡1.0 門診西醫")]
            [Description("153933f3-09e3-4da1-8dbe-f97e8e417455")]
            NHI10_OPD_WesternMedicine,
            /// <summary>
            /// 健保卡1.0 門診牙科
            /// </summary>
            [Display(Name = "健保卡1.0 門診牙科")]
            [Description("fdf1a5a4-1201-4603-a208-d4ba873dec03")]
            NHI10_OPD_Dentist,
            /// <summary>
            /// 健保卡1.0 急診
            /// </summary>
            [Display(Name = "健保卡1.0 急診")]
            [Description("e44b5d15-3d0b-4f9c-b249-07d8eb21778b")]
            NHI10_ER,
            /// <summary>
            /// 健保卡1.0 門診居家照護
            /// </summary>
            [Display(Name = "健保卡1.0 門診居家照護")]
            [Description("dd86e34c-d270-4bf3-8b6b-a8d8ccdff9f3")]
            NHI10_OPD_HomeCare,
            /// <summary>
            /// 門診申報轉檔
            /// </summary>
            [Display(Name = "門診申報轉檔")]
            [Description("dbc2dc2a-5f80-44c8-bd54-311470decc1e")]
            Claim_OPD,
        }


        #endregion

        #region 最底層相關，請勿輕易異動

        /// <summary>
        /// 環境類別
        /// 請取用description
        /// </summary>
        public enum EnvironmentType
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值")]
            [Description("6n19gojE6CZR+TBfaQ6n+M6tG5SiYmoPMQIZBt1SkpPKShn2oxSyn25PRSXtyxp/gm2t8JApYvSVEQUsg+Gqs2C9tLTKtQj7/awdV61hlXl2lLtpOQ6kcZ5wwrPzi8fJ/wGtw3+zgMI=")]
            Default = 0,

            /// <summary>
            /// 正式區
            /// </summary>
            [Display(Name = "正式區")]
            [Description("a6SuGHjglN4rcvXvzS1QYp8r6P6n6V1DFOHEk2qvtdZ587tu7+/0OPuQ10hs1QY7eeJzjhzgEiLTBTF4NOdfL22EWJDAJDO8PPo+Ckn6NmkLucJDt+hlXiKFDqrd1rWtxHoFnQ1oQ5Y=")]
            Online = 1,

            /// <summary>
            /// 平測區
            /// </summary>
            [Display(Name = "平測區")]
            [Description("VdYYC5nPO5wdmWHTbe9hH0YM3UeRDGpPNP38radvemeZ5WRDBFKCUDSt+eERAVjivzfSqQAmpU4WWO/+qFBH6tRuD5bcUHJ8n4m7FffpZwQD0ryQoAmzWNEIT1shJe6CHJv5SLnyFPo=")]
            Formal = 2,

            /// <summary>
            /// 開發區
            /// </summary>
            [Display(Name = "開發區")]
            [Description("6n19gojE6CZR+TBfaQ6n+M6tG5SiYmoPMQIZBt1SkpPKShn2oxSyn25PRSXtyxp/gm2t8JApYvSVEQUsg+Gqs2C9tLTKtQj7/awdV61hlXl2lLtpOQ6kcZ5wwrPzi8fJ/wGtw3+zgMI=")]
            HIS2USER2 = 3,

            /// <summary>
            /// 本機
            /// </summary>
            [Display(Name = "離線區")]
            //1522
            //[Description("hNUPKomY5Mn8DJArfaiw5OG1Kft0HuTGvbyY7Uup4s1PWEnziATvX/LUbKRMCGWL8xTTJkt3bqYA7vr3LzLFt2hXTdcU1gidmO3xXLDJqVymL3JTbkqOkGpFyiwpNtv5jdrJWAmkfNw=")]
            //1521
            [Description("FS+5zl/kkbSmXOyzodJ8Hyzb7g0wOyFQ1dR6xczepRWxAmuKPETOxMtOpf8x9PyB4gtVpXVgu0hwqgrKtA/HlmTGrCJKn32dbMyFsrpBFUG7wnDcOlVzeoWCrk0WlS3PE773g9gUWG0=")]
            Offline = 4,

            /// <summary>
            /// 北門正式區
            /// </summary>
            [Display(Name = "北門正式區")]
            [Description("eZmZDHj1rfpAx11+44I241jCV4teYfKEPK+uX5vqMID1mZPV/Hh/+ou6hSv5RhUd34BLjyqCwE5Tmjj386arfVu+4i4ZUUx4XsDLw4JhpUen7BuHEYeekPHoSPyzKvn7OuihEt47Im4=")]
            TPH_Online = 5,
        }

        /// <summary>
        /// Web 相關 domain
        /// 請取用Description:[Ex:https://google.com/]
        /// Display.Description:[Ex:google.com]
        /// </summary>
        public enum EnvironmentUrlType
        {
            /// <summary>
            /// 預設值
            /// </summary>
            [Display(Name = "預設值", Description = "his2web.tsgh.ndmctsgh.edu.tw")]
            [Description("http://his2web.tsgh.ndmctsgh.edu.tw/")]
            Web_Default = 0,

            /// <summary>
            /// Web 正式區
            /// </summary>
            [Display(Name = "Web 正式區", Description = "his2apf5.ndmctsgh.edu.tw")]
            [Description("https://his2apf5.ndmctsgh.edu.tw/")]
            Web_Online = 1,

            /// <summary>
            /// Web 平測區
            /// </summary>
            [Display(Name = "Web 平測區", Description = "this2f5.ndmctsgh.edu.tw")]
            [Description("https://this2f5.ndmctsgh.edu.tw/")]
            Web_Formal = 2,

            /// <summary>
            /// Web 開發區
            /// </summary>
            [Display(Name = "Web 開發區", Description = "his2web.tsgh.ndmctsgh.edu.tw")]
            [Description("http://his2web.tsgh.ndmctsgh.edu.tw/")]
            Web_Developed = 3,

            /// <summary>
            /// Web 正式區（門診）
            /// </summary>
            [Display(Name = "Web 正式區（門診）", Description = "his2webf5.ndmctsgh.edu.tw")]
            [Description("http://his2webf5.ndmctsgh.edu.tw/")]
            Web_Online_LoadBalance = 4,

            /// <summary>
            /// API 正式區（門診）
            /// </summary>
            [Display(Name = "API 正式區（門診）", Description = "his2apif5.ndmctsgh.edu.tw")]
            [Description("http://his2apif5.ndmctsgh.edu.tw/")]
            API_Online_LoadBalance = 5,

            /// <summary>
            /// Web 平測區（門診）
            /// </summary>
            [Display(Name = "Web 平測區（門診）", Description = "DEVHIS2WEBF5.ndmctsgh.edu.tw")]
            [Description("https://DEVHIS2WEBF5.ndmctsgh.edu.tw/")]
            Web_Formal_LoadBalance = 6,

            /// <summary>
            /// API 平測區（門診）
            /// </summary>
            [Display(Name = "API 平測區（門診）", Description = "DEVHIS2OPDAPI.ndmctsgh.edu.tw")]
            [Description("https://DEVHIS2OPDAPI.ndmctsgh.edu.tw/")]
            API_Formal_LoadBalance = 7,

            #region 北門
            /// <summary>
            /// 北門 WEB 測試主機
            /// </summary>
            [Display(Name = "北門 WEB 測試主機", Description = "OUTPATIENTWEB1.ndmctsgh.edu.tw")]
            [Description("https://OUTPATIENTWEB1.ndmctsgh.edu.tw/")]
            TPH_WEB_Formal_LoadBalance = 8,
            /// <summary>
            /// 北門 API 測試主機
            /// </summary>
            [Display(Name = "北門 API 測試主機", Description = "OUTPATIENTAPI1.ndmctsgh.edu.tw")]
            [Description("https://OUTPATIENTAPI1.ndmctsgh.edu.tw/")]
            TPH_API_Formal_LoadBalance = 9,
            #endregion
        }
        #endregion 最底層相關，請勿輕易異動
    }
}
