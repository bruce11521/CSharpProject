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
            /// 診別(時段)
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
        /// 就醫來源
        /// CodeGroup = VISITKIND
        /// </summary>
        public enum VISITKIND
        {
            /// <summary>
            /// 共用
            /// </summary>
            [Display(Name = "共用")]
            Public = 0,

            /// <summary>
            /// 住院
            /// </summary>
            [Display(Name = "住院")]
            [Description("I")]
            Inpatient = 1,

            /// <summary>
            /// 門診
            /// </summary>
            [Display(Name = "門診")]
            [Description("O")]
            Outpatient = 2,

            /// <summary>
            /// 急診
            /// </summary>
            [Display(Name = "急診")]
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
            NeiHu = 1,

            [Display(Name = "汀洲")]
            TingJhou = 2,
        }

        /// <summary>
        /// 病人狀態
        /// </summary>
        public enum PatientStatus
        {
            /// <summary>
            /// 未掛號(掛號)
            /// </summary>
            [Display(Name = "未掛號")]
            NonRegister = 1,

            /// <summary>
            /// 已掛號(掛號)
            /// </summary>
            [Display(Name = "已掛號")]
            Register = 2,

            /// <summary>
            /// 退掛號(掛號)
            /// </summary>
            [Display(Name = "退掛號")]
            RegiserWithdraw = 3,

            /// <summary>
            /// 報到(掛號)
            /// </summary>
            [Display(Name = "報到未看")]
            CheckIn = 4,

            /// <summary>
            /// 預約掛號(掛號)
            /// </summary>
            [Display(Name = "預約掛號")]
            RegiserRetention = 19,

            /// <summary>
            /// 待診(診間)
            /// </summary>
            [Display(Name = "待診")]
            WaitClinic = 5,

            /// <summary>
            /// 保留(診間)
            /// </summary>
            [Display(Name = "保留")]
            ClinicRetention = 6,

            /// <summary>
            /// 醫囑結束(診間)
            /// </summary>
            [Display(Name = "醫囑結束")]
            DoctorOrderFinish = 7,

            /// <summary>
            /// 留觀(診間)
            /// </summary>
            [Display(Name = "留觀")]
            Observation = 8,

            /// <summary>
            /// 待床(診間)
            /// </summary>
            [Display(Name = "待床")]
            WaitingForBed = 9,

            /// <summary>
            /// 轉科(診間)
            /// </summary>
            [Display(Name = "轉科")]
            DeptTransfer = 17,

            /// <summary>
            /// 診療中(診間)
            /// </summary>
            [Display(Name = "診療中")]
            SeeingADoctor = 18,

            /// <summary>
            /// 記錄中(護理)
            /// </summary>
            [Display(Name = "記錄中")]
            NurseRecording = 11,

            /// <summary>
            /// 已結案(護理)
            /// </summary>
            [Display(Name = "已結案")]
            NurseFinished = 12,

            /// <summary>
            /// 未批價(批價)
            /// </summary>
            [Display(Name = "未批價")]
            UnPayment = 13,

            /// <summary>
            /// 已批價(批價)
            /// </summary>
            [Display(Name = "已批價")]
            Paid = 14,

            /// <summary>
            /// 欠費(批價)
            /// </summary>
            [Display(Name = "欠費")]
            Owe = 15,

            /// <summary>
            /// 呆帳(批價)
            /// </summary>
            [Display(Name = "呆帳")]
            BadDebt = 16
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
        }
        #endregion CODE_SRC 相關

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

            [Display(Name = "察費費代碼")]
            DiagnoseFee = 3,

            [Display(Name = "付費方式")]
            FEETYPE = 4,

            [Display(Name = "ICD10處置診斷類別")]
            ICD10_DIAGKIND = 5,

            [Display(Name = "套餐狀態")]
            PackageOrder = 6,
        }

        #endregion System_Param 相關

        /// <summary>
        /// 時段
        /// </summary>
        public enum SegTime
        {
            /// <summary>
            /// 上午診
            /// </summary>
            [Display(Name = "上午診")]
            morning = 2,

            /// <summary>
            /// 下午診
            /// </summary>
            [Display(Name = "下午診")]
            afternoon = 3,

            /// <summary>
            /// 晚診
            /// </summary>
            [Display(Name = "晚診")]
            night = 4,
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
            [Display(Name = "No")]
            N = 0,

            /// <summary>
            /// 是
            /// </summary>
            [Display(Name = "Yes")]
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

            [Display(Name = "C肝特約診")]
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
            [Display(Name = "正常")]
            [Description("A")]
            Normal = 1,

            [Display(Name = "作廢")]
            [Description("")]
            Invalid = 2,

            [Display(Name = "沖銷")]
            [Description("D")]
            WriteOff = 3,
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
            Approval = 1,

            /// <summary>
            /// 補報
            /// </summary>
            [Display(Name = "補報")]
            ReApproval = 2,
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
            [Display(Name = "牙醫門診")]
            [Description("T")]
            Dentist = 1,

            /// <summary>
            /// 居家照護
            /// </summary>
            [Display(Name = "居家照護")]
            [Description("H")]
            HomeCare = 2,

            /// <summary>
            /// 門診洗腎
            /// </summary>
            [Display(Name = "門診洗腎")]
            [Description("E")]
            Dialysis = 4,

            /// <summary>
            /// 西醫門診
            /// </summary>
            [Display(Name = "西醫門診")]
            [Description("N")]
            Outpatient = 5,

            /// <summary>
            /// 中醫
            /// </summary>
            [Display(Name = "中醫")]
            [Description("C")]
            Chinese = 6,

            /// <summary>
            /// 西醫住院
            /// </summary>
            [Display(Name = "西醫住院")]
            [Description("")]
            Inpatient = 7,
        }
        #endregion 申報相關

        #region IC卡 定義
        /// <summary>
        /// 保險對象身分註記
        /// </summary>
        public enum ICNoteInsuredIdentity
        {
            /// <summary>
            /// 低收入戶
            /// </summary>
            LowIncome = 1,

            /// <summary>
            /// 無職業的榮民
            /// </summary>
            RongminOrRong = 2,

            /// <summary>
            /// 一般身分
            /// </summary>
            Normal = 3,

            /// <summary>
            /// 災民
            /// </summary>
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
            /// 西醫門診
            /// </summary>
            [Display(Name = "01")]
            西醫門診 = 1,

            /// <summary>
            /// 牙醫門診
            /// </summary>
            [Display(Name = "02")]
            牙醫門診 = 2,

            /// <summary>
            /// 中醫門診
            /// </summary>
            [Display(Name = "03")]
            中醫門診 = 3,

            /// <summary>
            /// 急診
            /// </summary>
            [Display(Name = "04")]
            急診 = 4,

            /// <summary>
            /// 住院
            /// </summary>
            [Display(Name = "05")]
            住院 = 5,

            /// <summary>
            /// 門診轉診就醫
            /// </summary>
            [Display(Name = "06")]
            門診轉診就醫 = 6,

            /// <summary>
            /// 門診手術後之回診
            /// </summary>
            [Display(Name = "07")]
            門診手術後之回診 = 7,

            /// <summary>
            /// 住院患者出院之回診
            /// </summary>
            [Display(Name = "08")]
            住院患者出院之回診 = 8,

            /// <summary>
            /// 同一療程項目以6次以內治療為限者
            /// </summary>
            [Display(Name = "AA")]
            同一療程項目以6次以內治療為限者 = 9,

            /// <summary>
            /// 同一療程項目屬非6次以內治療為限者
            /// </summary>
            [Display(Name = "AB")]
            同一療程項目屬非6次以內治療為限者 = 10,

            /// <summary>
            /// 預防保健
            /// </summary>
            [Display(Name = "AC")]
            預防保健 = 11,

            /// <summary>
            /// 職業傷害或職業病門急診
            /// </summary>
            [Display(Name = "AD")]
            職業傷害或職業病門急診 = 12,

            /// <summary>
            /// 慢性病連續處方箋領藥
            /// </summary>
            [Display(Name = "AE")]
            慢性病連續處方箋領藥 = 13,

            /// <summary>
            /// 藥局調劑
            /// </summary>
            [Display(Name = "AF")]
            藥局調劑 = 14,

            /// <summary>
            /// 排程檢查
            /// </summary>
            [Display(Name = "AG")]
            排程檢查 = 15,

            /// <summary>
            /// 居家照護第二次以後
            /// </summary>
            [Display(Name = "AH")]
            居家照護第二次以後 = 16,

            /// <summary>
            /// 同日同醫師看診第二次以後
            /// </summary>
            [Display(Name = "AI")]
            同日同醫師看診第二次以後 = 17,

            /// <summary>
            /// 門急診當次轉住院之入院
            /// </summary>
            [Display(Name = "BA")]
            門急診當次轉住院之入院 = 18,

            /// <summary>
            /// 出院
            /// </summary>
            [Display(Name = "BB")]
            出院 = 19,

            /// <summary>
            /// 急診中住院中執行項目
            /// </summary>
            [Display(Name = "BC")]
            急診中住院中執行項目 = 20,

            /// <summary>
            /// 急診第二日含以後之離院
            /// </summary>
            [Display(Name = "BD")]
            急診第二日含以後之離院 = 21,

            /// <summary>
            /// 職業傷害或職業病之住院
            /// </summary>
            [Display(Name = "BE")]
            職業傷害或職業病之住院 = 22,

            /// <summary>
            /// 繼續住院依規定分段結清者
            /// </summary>
            [Display(Name = "BF")]
            繼續住院依規定分段結清者 = 23,

            /// <summary>
            /// 其他規定不須累計就醫序號即不扣除就醫次數者
            /// </summary>
            [Display(Name = "CA")]
            其他規定不須累計就醫序號即不扣除就醫次數者 = 24,

            /// <summary>
            /// 門診轉出
            /// </summary>
            [Display(Name = "DA")]
            門診轉出 = 25,

            /// <summary>
            /// 門診手術後需於7日內之1次回診
            /// </summary>
            [Display(Name = "DB")]
            門診手術後需於7日內之1次回診 = 26,

            /// <summary>
            /// 住院患者出院後需於7日內之1次回診
            /// </summary>
            [Display(Name = "DC")]
            住院患者出院後需於7日內之1次回診 = 27,

            /// <summary>
            /// 取消孕婦產前檢查
            /// </summary>
            [Display(Name = "XA")]
            取消孕婦產前檢查 = 28,

            /// <summary>
            /// 兒童預防保健
            /// </summary>
            [Display(Name = "YA")]
            兒童預防保健 = 29,

            /// <summary>
            /// 成人預防保健
            /// </summary>
            [Display(Name = "YB")]
            成人預防保健 = 30,

            /// <summary>
            /// 婦女子宮頸抹片檢查
            /// </summary>
            [Display(Name = "YC")]
            婦女子宮頸抹片檢查 = 31,

            /// <summary>
            /// 兒童牙齒預防保健
            /// </summary>
            [Display(Name = "YD")]
            兒童牙齒預防保健 = 32,

            /// <summary>
            /// 婦女乳房檢查
            /// </summary>
            [Display(Name = "YE")]
            婦女乳房檢查 = 33,

            /// <summary>
            /// 六十五歲老人流行性感冒疫苗
            /// </summary>
            [Display(Name = "YF")]
            六十五歲老人流行性感冒疫苗 = 34,

            /// <summary>
            /// 定量免疫法糞便潛血檢查
            /// </summary>
            [Display(Name = "YG")]
            定量免疫法糞便潛血檢查 = 35,

            /// <summary>
            /// 口腔黏膜檢查
            /// </summary>
            [Display(Name = "YH")]
            口腔黏膜檢查 = 36,

            /// <summary>
            /// 取消24小時內所有就醫類別
            /// </summary>
            [Display(Name = "ZA")]
            取消24小時內所有就醫類別 = 37,

            /// <summary>
            /// 取消24小時內部分就醫類別
            /// </summary>
            [Display(Name = "ZB")]
            取消24小時內部分就醫類別 = 38,

            /// <summary>
            /// 透析門診 (111年1月1日起新增) 
            /// </summary>
            [Display(Name = "09")]
            透析門診 = 39,

            /// <summary>
            /// 透析門診療程第二次(含)以後 (111年1月1日起新增) 
            /// </summary>
            [Display(Name = "AJ")]
            透析門診療程第二次含以後 = 40,

            /// <summary>
            /// 門診當次轉住院之入院  (110年12月20日起新增) 
            /// </summary>
            [Display(Name = "BG")]
            門診當次轉住院之入院 = 41,

            /// <summary>
            /// 床號變更或轉床 (110年7月1日起新增) 
            /// </summary>
            [Display(Name = "EA")]
            床號變更或轉床 =42,

            /// <summary>
            /// 床號變更或轉床 (110年7月1日起新增) 
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
            [Display(Name = "安全模組(SAM)")]
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
        #endregion IC卡 定義

        #region 身分類別 20210415 Created 林伯翰
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
            None = -1,

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
            /// 自費兵役
            /// </summary>
            [Display(Name = "自費兵役")]
            [Description("AB")]
            SelfPayMilitary,

            /// <summary>
            /// 無給付兵役
            /// </summary>
            [Display(Name = "無給付兵役")]
            [Description("AC")]
            NonPayMilitary,

            /// <summary>
            /// 老人健康檢查
            /// </summary>
            [Display(Name = "老人健康檢查")]
            [Description("B1")]
            ELderlyHealthCheck,

            /// <summary>
            /// 成人健康檢查
            /// </summary>
            [Display(Name = "成人健康檢查")]
            [Description("B2")]
            AdultHealthCheck,

            /// <summary>
            /// 新進員工體檢
            /// </summary>
            [Display(Name = "新進員工體檢")]
            [Description("B3")]
            NewStaffHealthCheck,

            /// <summary>
            /// HIV
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
            /// </summary>
            [Display(Name = "重大傷病")]
            [Description("001")]
            MajorInjury,

            /// <summary>
            /// 分娩
            /// </summary>
            [Display(Name = "分娩")]
            [Description("002")]
            ChildBirth,

            /// <summary>
            /// 低收入戶
            /// </summary>
            [Display(Name = "低收入戶")]
            [Description("003")]
            LowIncomeHouseHolds,

            /// <summary>
            /// 榮民、榮民遺眷
            /// </summary>
            [Display(Name = "榮民、榮民遺眷")]
            [Description("004")]
            VenteransAndFamily,

            /// <summary>
            /// 結核病患
            /// </summary>
            [Display(Name = "結核病患")]
            [Description("005")]
            TuberculosisPatients,

            /// <summary>
            /// 勞工職業傷害或職業病
            /// </summary>
            [Display(Name = "勞工職業傷害或職業病")]
            [Description("006")]
            EmploymentInjuryOrOccupationalDisease,

            /// <summary>
            /// 山地離島地區之醫院門急診
            /// </summary>
            [Display(Name = "山地離島地區之醫院門急診")]
            [Description("007")]
            MountainousIslandsOPDAndER,

            /// <summary>
            /// 離島醫院轉診至台灣門急診就醫
            /// </summary>
            [Display(Name = "離島醫院轉診至台灣門急診就醫")]
            [Description("008")]
            OutlyingIslandReferralToTWOPDAndER,

            /// <summary>
            /// 其他
            /// </summary>
            [Display(Name = "其他")]
            [Description("009")]
            Other,

            /// <summary>
            /// 多氯聯苯中毒
            /// </summary>
            [Display(Name = "多氯聯苯中毒")]
            [Description("901")]
            PCBPoisoning,

            /// <summary>
            /// 未滿3足歲兒童
            /// </summary>
            [Display(Name = "未滿3足歲兒童")]
            [Description("902")]
            ChildrenUnder3YearsOld,

            /// <summary>
            /// 新生兒就醫(出生六十日)
            /// </summary>
            [Display(Name = "新生兒就醫(出生六十日)")]
            [Description("903")]
            NewbornsSeekMedicalAttention_60DaysAfterBirth,

            /// <summary>
            /// 愛滋病患
            /// </summary>
            [Display(Name = "愛滋病患")]
            [Description("904")]
            AIDS,

            /// <summary>
            /// 替代役役男
            /// </summary>
            [Display(Name = "替代役役男")]
            [Description("906")]
            AlternativeServiceman,

            /// <summary>
            /// 代辦海巡署輔助部份負擔
            /// </summary>
            [Display(Name = "代辦海巡署輔助部份負擔")]
            [Description("908")]
            CoastGuardPartTypeAgent,

            /// <summary>
            /// 代辦中央警察大學輔助部份負擔
            /// </summary>
            [Display(Name = "代辦中央警察大學輔助部份負擔")]
            [Description("909")]
            CenterPoliceUniversityPartTypeAgent,

            /// <summary>
            /// 代辦內政部消防署輔助部份負擔
            /// </summary>
            [Display(Name = "代辦內政部消防署輔助部份負擔")]
            [Description("910")]
            MinistryOfTheInteriorFireDepartmentPartTypeAgent,

            /// <summary>
            /// 代辦內政部空勤總隊輔助部份負擔
            /// </summary>
            [Display(Name = "代辦內政部空勤總隊輔助部份負擔")]
            [Description("911")]
            MinistryOfTheInteriorAireCrewCorpsPartTypeAgent,

            /// <summary>
            /// 代辦內政部警政署輔助部份負擔
            /// </summary>
            [Display(Name = "代辦內政部警政署輔助部份負擔")]
            [Description("912")]
            MinistryOfTheInteriorPoliceDepartmentPartTypeAgent,

            /// <summary>
            /// 代辦內政部警政署輔助部份負擔
            /// </summary>
            [Display(Name = "代辦國防部輔助部份負擔")]
            [Description("913")]
            MinistryOfNationalDefensePartTypeAgent,

            /// <summary>
            /// 代辦疾管署輔助部份負擔
            /// </summary>
            [Display(Name = "代辦疾管署輔助部份負擔")]
            [Description("914")]
            CDCPartTypeAgent,

            /// <summary>
            /// 代辦移民署輔助部份負擔
            /// </summary>
            [Display(Name = "代辦移民署輔助部份負擔")]
            [Description("915")]
            MinistryOfTheInteriorImmigrationPartTypeAgent,

            /// <summary>
            /// 醫學中心急診
            /// </summary>
            [Display(Name = "醫學中心急診")]
            [Description("A00")]
            MedicalCenter_EmergencyRoom,

            /// <summary>
            /// 醫學中心一般門診
            /// </summary>
            [Display(Name = "醫學中心一般門診")]
            [Description("A12")]
            MedicalCenter_OutpatientClinic,

            /// <summary>
            /// 醫學中心一般門診；持殘障手冊
            /// </summary>
            [Display(Name = "醫學中心一般門診；持殘障手冊")]
            [Description("A13")]
            MedicalCenter_OutpatientClinic_WithHandicapHandbook,

            /// <summary>
            /// 醫學中心;藥品.復健
            /// </summary>
            [Display(Name = "醫學中心;藥品.復健")]
            [Description("A20")]
            MedicalCenter_Medicines_Rehabilitation,

            /// <summary>
            /// 醫學中心;藥品.復健;持殘障手冊
            /// </summary>
            [Display(Name = "醫學中心;藥品.復健;持殘障手冊")]
            [Description("A23")]
            MedicalCenter_Medicines_RehabilitationWithHandicapHandbook,

            /// <summary>
            /// 醫學中心轉診
            /// </summary>
            [Display(Name = "醫學中心轉診")]
            [Description("A30")]
            MedicalCenter_Referral,

            /// <summary>
            /// 醫學中心第二至五次轉診
            /// </summary>
            [Display(Name = "醫學中心第二至五次轉診")]
            [Description("A31")]
            MedicalCenter_SecondToFifthReferrals,

            /// <summary>
            /// 醫學中心回診
            /// </summary>
            [Display(Name = "醫學中心回診")]
            [Description("A40")]
            MedicalCenter_Visit,

            /// <summary>
            /// 醫學中心牙醫急診
            /// </summary>
            [Display(Name = "醫學中心牙醫急診")]
            [Description("E00")]
            MedicalCenter_DEN_ER,

            /// <summary>
            /// 醫學中心牙醫一般門診
            /// </summary>
            [Display(Name = "醫學中心牙醫一般門診")]
            [Description("E10")]
            MedicalCenter_OutpatientClinicOf_DEN,

            /// <summary>
            /// 醫學中心牙醫一般門診；持殘障手冊
            /// </summary>
            [Display(Name = "醫學中心牙醫一般門診；持殘障手冊")]
            [Description("E13")]
            MedicalCenter_OutpatientClinicOf_DEN_WithHandicapHandbook,

            /// <summary>
            /// 醫學中心;高利用率者(93年1月後停用)
            /// </summary>
            [Display(Name = "醫學中心;高利用率者(93年1月後停用)")]
            [Description("E20")]
            MedicalCenter_HighUtilizationRate_StoppedAfterJan1993,

            /// <summary>
            /// 醫學中心;高利用率者;持殘障手冊(93年1月後停用)
            /// </summary>
            [Display(Name = "醫學中心;高利用率者;持殘障手冊(93年1月後停用)")]
            [Description("E23")]
            MedicalCenter_HighUtilizationRateWithHandicapHandbook_StoppedAfterJan1993,

            /// <summary>
            /// 居家照護(沒有開藥)
            /// </summary>
            [Display(Name = "居家照護(沒有開藥)")]
            [Description("K00")]
            HomeCare_NonMedicationIsPrescribed,

            /// <summary>
            /// 居家照護(有開藥)
            /// </summary>
            [Display(Name = "居家照護(有開藥)")]
            [Description("K20")]
            HomeCare_WithMedication,

            /// <summary>
            /// 戒菸門診
            /// </summary>
            [Display(Name = "戒菸門診")]
            [Description("Z00")]
            SmokingCessationClinic,
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
            /// 門診指定就醫病人
            /// </summary>
            [Display(Name = "門診指定就醫病人")]
            [Description("00")]
            CLinicAppointmentPatient,

            /// <summary>
            /// 西醫門診
            /// </summary>
            [Display(Name = "西醫門診")]
            [Description("01")]
            WesternMedicineClinic,

            /// <summary>
            /// 牙醫門診
            /// </summary>
            [Display(Name = "牙醫門診")]
            [Description("02")]
            DentistClinic,

            /// <summary>
            /// 中醫門診
            /// </summary>
            [Display(Name = "中醫門診")]
            [Description("03")]
            ChineseMedicineClinic,

            /// <summary>
            /// 急診
            /// </summary>
            [Display(Name = "急診")]
            [Description("04")]
            EmergencyRoom,

            /// <summary>
            /// 住院
            /// </summary>
            [Display(Name = "住院")]
            [Description("05")]
            BeHospitalized,

            /// <summary>
            /// 門診轉診就醫
            /// </summary>
            [Display(Name = "門診轉診就醫")]
            [Description("06")]
            OPDReferral,

            /// <summary>
            /// 門診手術後之回診
            /// </summary>
            [Display(Name = "門診手術後之回診")]
            [Description("07")]
            FollowUpAfterOPDSurgery,

            /// <summary>
            /// 住院患者出院之回診
            /// </summary>
            [Display(Name = "住院患者出院之回診")]
            [Description("08")]
            InpatientFollowUpAfterDischarge,

            /// <summary>
            /// 同一療程(六次內)
            /// </summary>
            [Display(Name = "同一療程(六次內)")]
            [Description("AA")]
            SameTreatmentWithinSixTimes,

            /// <summary>
            /// 同一療程(一個月內)
            /// </summary>
            [Display(Name = "同一療程(一個月內)")]
            [Description("AB")]
            SameTreatmentWithinOneMonth,

            /// <summary>
            /// 預防保健
            /// </summary>
            [Display(Name = "預防保健")]
            [Description("AC")]
            PreventiveHealthCare,

            /// <summary>
            /// 職業傷害或職業病
            /// </summary>
            [Display(Name = "職業傷害或職業病")]
            [Description("AD")]
            OccupationalInjuryOrDisease,

            /// <summary>
            /// 慢性病連續處方箋領藥
            /// </summary>
            [Display(Name = "慢性病連續處方箋領藥")]
            [Description("AE")]
            ContinuousPrescriptionForChronicDisease,

            /// <summary>
            /// 藥局調劑
            /// </summary>
            [Display(Name = "藥局調劑")]
            [Description("AF")]
            PharmacyRegulation,

            /// <summary>
            /// 排程檢查
            /// </summary>
            [Display(Name = "排程檢查")]
            [Description("AG")]
            ScheduledCheck,

            /// <summary>
            /// 居家照護(第二次以後)
            /// </summary>
            [Display(Name = "居家照護(第二次以後)")]
            [Description("AH")]
            HomeCareAfterSecondTime,

            /// <summary>
            /// 同日同醫師看診(第二次以後)
            /// </summary>
            [Display(Name = "同日同醫師看診(第二次以後)")]
            [Description("AI")]
            SameDaysSameDoctorAfterSecondTime,

            /// <summary>
            /// 門急診當次轉住院之入院
            /// </summary>
            [Display(Name = "門急診當次轉住院之入院")]
            [Description("BA")]
            OPDAndERAdmissionInTheCurrent,

            /// <summary>
            /// 出院
            /// </summary>
            [Display(Name = "出院")]
            [Description("BB")]
            Discharged,

            /// <summary>
            /// 急診中,住院中執行項目
            /// </summary>
            [Display(Name = "急診中,住院中執行項目")]
            [Description("BC")]
            ExecuteProjectInERAndHospital,

            /// <summary>
            /// 急診第二日以後
            /// </summary>
            [Display(Name = "急診第二日以後")]
            [Description("BD")]
            ERAfterSecondDay,

            /// <summary>
            /// 職業傷害或職業病之入院
            /// </summary>
            [Display(Name = "職業傷害或職業病之入院")]
            [Description("BE")]
            AdmissionToHospitalForOccupationalInjuryOrDisease,

            /// <summary>
            /// 繼續住院依規定分段結清者,切帳申報
            /// </summary>
            [Display(Name = "繼續住院依規定分段結清者,切帳申報")]
            [Description("BF")]
            ContinueToBeHospitalized_AccountWillBeCutOff,

            /// <summary>
            /// 其他(不扣卡)
            /// </summary>
            [Display(Name = "其他(不扣卡)")]
            [Description("CA")]
            Others_NotDeducted,

            /// <summary>
            /// 門診轉出
            /// </summary>
            [Display(Name = "門診轉出")]
            [Description("DA")]
            OPDTransfer,

            /// <summary>
            /// 門診手術需回診
            /// </summary>
            [Display(Name = "門診手術需回診")]
            [Description("DB")]
            OPDSurgeryRequiresReturnVisit,

            /// <summary>
            /// 出院患者需回診
            /// </summary>
            [Display(Name = "出院患者需回診")]
            [Description("DC")]
            DischargedPatientsComeBack,
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
            Null = -1,
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
            ///// <summary>
            ///// 觀察（超過一小時)
            ///// </summary>
            //[Display(Name = "ObserveOverOneHours")]
            //[Description("觀察（超過一小時)")]
            //ObserveOverOneHours = 3,
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
            Escape = 8
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
        public enum OPDDashboard_MenuItemTitle
        {
            SystemPerformance,

        }
        /// <summary>
        /// Display(Name = "中文名"), Description("描述"), EnumName之"_"為分隔主次階層用，不可用來命名
        /// </summary>
        public enum OPDDashboard_MenuItem
        {
            /// <summary>
            /// 套餐
            /// </summary>
            [Display(Name = "套餐維護功能")]
            [Description("")]
            SystemPerformance_PackageOrder,
            /// <summary>
            /// 片語
            /// </summary>
            [Display(Name = "片語維護功能")]
            [Description("")]
            SystemPerformance_CommonPhrases,
            /// <summary>
            /// 設定健保讀卡機設定檔
            /// </summary>
            [Display(Name = "設定健保(舊)讀卡機設定檔")]
            [Description("複製設定檔並運行健保讀卡程式")]
            SystemPerformance_NHISettingsNonPCSC,
            /// <summary>
            /// 設定晶片讀卡機設定檔
            /// </summary>
            [Display(Name = "設定晶片(新)讀卡機設定檔")]
            [Description("複製設定檔並運行健保讀卡程式")]
            SystemPerformance_NHISettingsPCSC,
            /// <summary>
            /// 安裝健保署雲端讀卡機主控台
            /// </summary>
            [Display(Name = "安裝/修復健保署雲端讀卡機主控台")]
            [Description("111/03/23發佈, Ver:5.1.5.5")]
            SystemPerformance_InstalNHIPCSC,

        }
        #endregion
    }
}
