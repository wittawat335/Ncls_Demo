using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NCLS.WEB.Utility
{
    public static class Constants
    {

        public struct SessionKey
        {
            public const string LoginInfo = "SessionKey.LoginInfo";
            public const string Menu = "SessionKey.Menu";
            public const string SysDate = "SessionKey.SysDate";
            public const string PageSize = "SessionKey.PageSize";
            public const string LastLoginDateTime = "SessionKey.LastLoginDateTime";
            public const string Ip = "SessionKey.Ip";
        }

        public struct SessionTempName
        {
            public const string JudgmentDebtorDetailsTemp = "SessionTemp.JudgmentDebtorDetailsTemp";
            public const string SuggestWriteOff = "SessionTemp.WriteOffTemp";
            public const string ReceiveYellowCard = "SessionTemp.R3TEMP";
            public const string AssignTempOa = "SessionTemp.AssignTemp";
            public const string R3Export = "R3Excel";
            public const string WfExport = "WFExcel";
            public const string TodolistExport = "ToDoExcel";
            public const string CourtFeesExport = "CourtFeesExcel";
            public const string OtherExpenseExport = "OtherExpenseExcel";
            public const string AssignRepoExport = "AssignRepoExcel";
            public const string ReceiveBackExport = "ReceiveBackExcel";
        }


        public struct UserRole
        {
            public const string Manager = "MA";
            public const string LegalAdmin = "LA";
        }


        /// <summary>
        /// TempData["Name"]
        /// </summary>
        public struct TempDataName
        {
            public const string JudgmentDebtor_HID = "TempData.JudgmentDebtor_HID";
            public const string JudgmentDebtor_JOB_ID = "TempData.JudgmentDebtor_JOB_ID";

        }

        public struct Msg
        {
            public const string LoginSucc = "Login success";
            public const string LoginFail = "Login failed";
            public const string LoginDuplicate = "Login Duplicate Do you want Login?";
            public const string DataNotFound = "Data not found";
            public const string ConfirmDelete = "Do you want to delete ?";
            public const string ConfirmSave = "Do you want to save ?";
            public const string ConfirmSaveR310Status = "R3 Status is กำลังส่ง Please input Send Letter Date & Tracking Number for change R3 status to รอใบตอบรับ";
            public const string ConfirmSaveR320Status = "R3 Status is รอใบตอบรับ Please input Receive Date or Rejected Letter Date";
            public const string ConfirmSendToRps = "Do you want to send ?";
            public const string ConfirmClear = "Do you want to clear data ?";
            public const string SessionExp = "Session expired";
            public const string Duplicate = "Duplicate Data";
            public const string SaveSucc = "Save success";
            public const string SaveFail = "Save failed";
            public const string SelectRole = "Select Role";
            public const string SwitchRoleSucc = "Switch Role success";
            public const string SwitchRoleFail = "Switch Role fail";
            public const string IssueDateFail = "Issue Date From must be less than or equal to Issue Date To";
            public const string AssignDateFail = "Assign Date From must be less than or equal to Assign Date To";
            public const string SendDateFail = "Send Date From must be less than or equal to Send Date To";
            public const string AdminDateFail = "Admin Date From must be less than or equal to Admin Date To";
            public const string OADateFail = "OA Date From must be less than or equal to OA Date To";
            public const string ReceiveDateFail = "Receive Yellow Card Date From must be less than or equal to Receive Yellow Card Date To";
            public const string DefaultSelect2 = "Please Select Data";
            public const string DuplicateInFile = "Duplicate in file";
            public const string DuplicateRecord = "Duplicate existing record";
            public const string DataNotMatch = "Data not Match";
            public const string CheckSendLetterDate = "Must Not less than Generate Letter Date";
            public const string Blank = "Blank";
            public const string UploadCompleted = "Upload Completed";
            public const string UploadIncompleted = "Upload Incompleted";
            public const string LegalOaBlank = "Please Check Data : Legal OA is not null";
            public const string TrackingDateBlank = "Please Check Data : Tracking Date is not null";
            public const string RemarkBlank = "Please Check Data : Remark is not null";
            public const string ContractBlank = "Please Check Data : Contract NO is not null";
            public const string PaymentDateFail = "PaymentNo Date From must be less than or equal to PaymentNo Date To";
            public const string CheckMatchContract = "Contract No. not Match!";
            public const string DataBlank = "Please Check Data!";
            public const string ConfirmApprove = "Do you want to approve ?";
            public const string ConfirmReject = "Do you want to reject ?";
            public const string ConfirmUpdate = "Do you want to update ?";
            public const string CheckContract = "Contract No. Not Exist";
            public const string CheckDataAndStatus = "Contract No. is Exist";
            public const string CheckCitizenId = "Citizen ID Not Exist";
            public const string Success = "Success";
            public const string Failed = "Failed";
            public const string RejectSucc = "Reject success";
            public const string RejectFail = "Reject failed";
            public const string FirstDueDateBlank = "Please Check Data : First Due Date is not null";
            public const string UploadNotFormat = "Template Not Current";
            public const string CancelLegal = "Do you want to cancel legal";
        }

        public struct LinkReport
        {
            public static string PayIn = "~/Report/PayIn.rpt";
            public static string WriteoffCompanyTax = "~/Report/WriteoffCompanyTax.rpt";
            public static string WriteoffFromSystem = "~/Report/WriteoffSystem.rpt";
            public static string WriteoffCompanyTaxCover = "~/Report/Writeoff.rpt";
        }


        #region Enum
        public struct Mode
        {
            public const string New = "New";
            public const string Edit = "Edit";
            public const string View = "View";
            public const string Add = "Add";
            public const string Approved = "Approved";
            public const string Delete = "Del";
            public const string Send = "Send";
            public const string Save = "Save";
            public const string Reject = "Reject";
            public const string Upload = "Upload";
        }
        public struct Color
        {
            public const string Green = "Green";
            public const string Yellow = "Yellow";
            public const string Red = "Red";
            public const string GreenCode = "#008000";
            public const string YellowCode = "#F3C200";
            public const string RedCode = "#FF0000";
        }
        public struct TextMode
        {
            public const string InteingerPos = "inteingerpos";
            public const string Doublepos = "doublepos";
            public const string Integer = "integer";
        }
        public struct SelectOption
        {
            public static string SelectAll = "Select All";
            public static string SelectOne = "Please Select";
        }

        public struct YesNo
        {
            public const string Yes = "1";
            public const string No = "0";
        }

        /// <summary>
        /// เอาไว้ใช้กับ GetListByMasterType(MasterTypeCode);
        /// </summary>
        public struct MasterType
        {
            // public const string SpecialCase = "SpecialCase";
            //  public const string CourtType = "CourtType";
            public const string DocumentType = "DocumentType";
            public const string GroupTransactionType = "TransactionGroup";
            public const string ReasonType = "ReasonType";
            public const string CarPark = "CarPark";
            public const string ReceiveCar = "ReceiveCar";
            public const string WriteoffType = "WriteoffType";
            public const string DebtorStatus = "DebtorStatus";
            public const string Bank = "Bank";
            public const string ReceiveBackType = "ReceiveBackType";
            public const string Auction = "Auction";
            public const string AttorneyStatus = "AttorneyStatus";
            public const string AppearType = "AppearType";
            public const string WriteOffType = "WriteOffType";
            public const string R3Status = "R3Status";
            public const string OaType = "OA";
        }
        public struct Result
        {
            public const string True = "T";
            public const string False = "F";
        }
        public struct SendResult
        {
            public const string True = "SC";
            public const string False = "SF";
        }
        public struct Status
        {
            public static string Active = "A";
            public static string ActiveText = "Active";
            public static string Inactive = "I";
            public static string InactiveText = "Inactive";
        }
        public struct InterestStep
        {
            public const string Period = "P";
            public const string PeriodText = "Period";
            public const string Months = "M";
            public const string MonthsText = "Months";
            public const string Days = "D";
            public const string DaysText = "Days";

        }
        public struct ApproveStatus
        {
            public static string Pending = "W";
            public static string PendingText = "Pending";
            public static string Approved = "A";
            public static string ApprovedText = "Approved";
            public static string Rejected = "R";
            public static string RejectedText = "Rejected";
            public static string Cancel = "C";
            public static string CancelText = "Cancel";
        }

        public struct StatusData
        {
            public static string Mailing = "M";
            public static string Registered = "R";
        }


        public struct StatusCustomer
        {
            public static string Borrower = "B";
            public static string Guarantor = "G";
        }

        public struct DataLevel
        {
            public const string All = "3";
            public const string Team = "2";
            public const string Owner = "1";

        }
        public static class CostType
        {
            public const string COLLECTION_FEE = "FC00008";
            public const string REPOS_FEE = "FC00009";
            public const string OTHER_FEE = "FC00010";
        }
        public struct ParaCode
        {
            public const string sysDate = "SYSDATE";
            public const string pageSize = "PAGESIZE";
            public const string timeOut = "TIMEOUT";
            public const string DaysR3 = "X08";
            public const string GapDocDays = "X03";
            public const string ParaX09 = "X09";
            public const string ParaX10 = "X10";
            public const string ParaX11 = "X11";
            public const string ParaVat = "X12";
            public const string ParaX13 = "X13";
            public const string ParaX14 = "X14";
            public const string ParaX15 = "X15";
            public const string ParaX16 = "X16";
            public const string ParaX17 = "X17";
            public const string ParaX18 = "X18";
            public const string ParaX19 = "X19";
            public const string ParaX22 = "X22";
        }
        public struct TableJob
        {
            public const string T_JOB_SPECIAL = "T_JOB_SPECIAL";
            public const string T_JOB_REPO = "T_JOB_REPO";
            public const string T_JOB_LEGAL = "T_JOB_LEGAL";
        }

        public struct FormatGenExpenseID
        {
            public const string CourtFeesImport = "IPC";
            public const string CourtFeesManaul = "MPC";
            public const string ReceiveBack = "MRC";
            public const string OtherExpenseImport = "IPV";
            public const string OtherExpenseManaul = "MPV";
        }

        public struct FormatGenDocID
        {
            public const string DocID = "SBR";
            public const string GenDociD = "SWO";
        }

        public struct FormatGenRepoId
        {
            public const string JobId = "RP";

        }
        public struct FormatGenJudgmentDebtor
        {
            public const string JDID = "JD";
        }

        public struct BankFraud_Type
        {
            public const string Bankruptcy = "Bankruptcy";
            public const string Fraud = "Fraud";
        }
        public struct ExpenseType
        {
            public const string CourtFees = "C";
            public const string OtherExpense = "O";
        }

        public struct JudgmentType
        {
            public const string Contract = "Contract";
            public const string Cheque = "Cheque";
        }

        public struct ModeReceiveBack
        {
            public const string True = "T";
            public const string False = "F";
        }
        public struct ReceiveBackType
        {
            public const string Cheque = "C";
            public const string Transfer = "T";
        }
        public struct TransGroup
        {
            public const string CourtFees = "GT01";
            public const string OtherExpense = "GT02";
            public const string RepoFee = "GT03";
            public const string TravelFee = "GT04";
            public const string Verdict = "GT05";
            public const string Compromise = "GT06";


        }
        public struct ReceiveFlag
        {
            public const string ReceiveTrue = "1";
            public const string ReceiveFalse = "0";
        }

        public struct ContractType
        {
            public const string Individual = "Individual";
            public const string Corporate = "Corporate";
        }

        #region Security
        public struct ActCode
        {

            public const string DashboardAdd = "AC001";
            public const string DashboardEdit = "AC002";
            public const string DashboardView = "AC003";
            public const string TodoListAdd = "AC004";
            public const string TodoListEdit = "AC005";
            public const string TodoListView = "AC006";
            public const string ContractInformationAdd = "AC007";
            public const string ContractInformationEdit = "AC008";
            public const string ContractInformationView = "AC009";
            public const string ReceiveYellowCardAdd = "AC010";
            public const string ReceiveYellowCardEdit = "AC011";
            public const string ReceiveYellowCardView = "AC012";
            public const string ReceiveCarAdd = "AC013";
            public const string ReceiveCarEdit = "AC014";
            public const string ReceiveCarView = "AC015";
            public const string ReceiveCarSend = "AC109";
            public const string IFLegalCaseAdd = "AC016";
            public const string IFLegalCaseEdit = "AC017";
            public const string IFLegalCaseView = "AC018";
            public const string IFChequeAdd = "AC019";
            public const string IFChequeEdit = "AC020";
            public const string IFChequeView = "AC021";
            public const string SpecialCaseAdd = "AC022";
            public const string SpecialCaseEdit = "AC023";
            public const string SpecialCaseView = "AC024";
            public const string CourtFeesAdd = "AC025";
            public const string CourtFeesEdit = "AC026";
            public const string CourtFeesView = "AC027";
            public const string CourtFeesApprove = "AC098";
            public const string OtherExpenseAdd = "AC028";
            public const string OtherExpenseEdit = "AC029";
            public const string OtherExpenseView = "AC030";
            public const string OtherExpenseApprove = "AC099";
            public const string JDLegalCaseAdd = "AC031";
            public const string JDLegalCaseEdit = "AC032";
            public const string JDLegalCaseView = "AC033";
            public const string JDLegalCaseApprove = "AC102";
            public const string JDChequeAdd = "AC034";
            public const string JDChequeEdit = "AC035";
            public const string JDChequeView = "AC036";
            public const string JDChequeApprove = "AC103";
            public const string CashReceiptAdd = "AC037";
            public const string CashReceiptEdit = "AC038";
            public const string CashReceiptView = "AC039";
            public const string SuggesttoWriteoffAdd = "AC040";
            public const string SuggesttoWriteoffEdit = "AC041";
            public const string SuggesttoWriteoffView = "AC042";
            public const string SuggesttoWriteoffApprove = "AC100";
            public const string AssetSearchAdd = "AC043";
            public const string AssetSearchEdit = "AC044";
            public const string AssetSearchView = "AC045";
            public const string SeizureAdd = "AC046";
            public const string SeizureEdit = "AC047";
            public const string SeizureView = "AC048";
            public const string BatchMonitoringAdd = "AC049";
            public const string BatchMonitoringEdit = "AC050";
            public const string BatchMonitoringView = "AC051";
            public const string PerformanceReportAdd = "AC052";
            public const string PerformanceReportEdit = "AC053";
            public const string PerformanceReportView = "AC054";
            public const string UserAdd = "AC055";
            public const string UserEdit = "AC056";
            public const string UserView = "AC057";
            public const string RoleAdd = "AC058";
            public const string RoleEdit = "AC059";
            public const string RoleView = "AC060";
            public const string MasterDataAdd = "AC064";
            public const string MasterDataEdit = "AC065";
            public const string MasterDataView = "AC066";
            public const string DocumentAdd = "AC067";
            public const string DocumentEdit = "AC068";
            public const string DocumentView = "AC069";
            public const string CourtAdd = "AC070";
            public const string CourtEdit = "AC071";
            public const string CourtView = "AC072";
            public const string StatusAdd = "AC073";
            public const string StatusEdit = "AC074";
            public const string StatusView = "AC075";
            public const string LegalStatusAdd = "AC076";
            public const string LegalStatusEdit = "AC077";
            public const string LegalStatusView = "AC078";
            public const string OutsourceGroupAdd = "AC079";
            public const string OutsourceGroupEdit = "AC080";
            public const string OutsourceGroupView = "AC081";
            public const string OutsourceAdd = "AC082";
            public const string OutsourceEdit = "AC083";
            public const string OutsourceView = "AC084";
            public const string TransactionAdd = "AC085";
            public const string TransactionEdit = "AC086";
            public const string TransactionView = "AC087";
            public const string SystemParameterAdd = "AC088";
            public const string SystemParameterEdit = "AC089";
            public const string SystemParameterView = "AC090";
            public const string WriteoffTyperAdd = "AC091";
            public const string WriteoffTypeEdit = "AC092";
            public const string WriteoffTypeView = "AC093";
            public const string BankruptcyFraudAdd = "AC094";
            public const string BankruptcyFraudEdit = "AC095";
            public const string BankruptcyFraudView = "AC096";
            public const string BankruptcyFraudApprove = "AC101";
            public const string MappingOAAdd = "AC105";
            public const string MappingOAEdit = "AC106";
            public const string MappingOAView = "AC104";
            public const string BucketAdd = "AC110";
            public const string BucketEdit = "AC111";
            public const string BucketView = "AC112";
            public const string ReciveBackAdd = "AC113";
            public const string ReceiveBackEdit = "AC114";
            public const string ReceiveBackView = "AC115";
            public const string ReceiveBackApprove = "AC116";
            public const string SignatureEdit = "AC117";
            public const string SignatureView = "AC118";
            public const string ProvinceAdd = "AC120";
            public const string ProvinceEdit = "AC121";
            public const string ProvinceView = "AC122";
        }
        public struct ProgramCode
        {
            public const string AssetSearch = "NCLS015P01";
            public const string BatchMonitoring = "NCLS017P01";
            public const string CashReceipt = "NCLS013P01";
            public const string IFCheque = "NCLS007P01";
            public const string JDCheque = "NCLS012P01";
            public const string ContractInformation = "NCLS003P01";
            public const string Court = "NCLS024P01";
            public const string CourtFees = "NCLS009P01";
            public const string Dashboard = "NCLS001P01";
            public const string Document = "NCLS023P01";
            public const string IFLegalCase = "NCLS006P01";
            public const string JDLegalCase = "NCLS011P01";
            public const string LegalStatus = "NCLS026P01";
            public const string MasterData = "NCLS022P01";
            public const string OtherExpense = "NCLS010P01";
            public const string Outsource = "NCLS028P01";
            public const string OutsourceGroup = "NCLS027P01";
            public const string PerformanceReport = "NCLS018P01";
            public const string ReceiveCar = "NCLS005P01";
            public const string ReceiveYellowCard = "NCLS004P01";
            public const string Role = "NCLS020P01";
            public const string Seizure = "NCLS016P01";
            public const string SpecialCase = "NCLS008P01";
            public const string Status = "NCLS025P01";
            public const string SuggesttoWriteoff = "NCLS014P01";
            public const string SystemParameter = "NCLS030P01";
            public const string TodoList = "NCLS002P01";
            public const string Transaction = "NCLS029P01";
            public const string User = "NCLS019P01";
            public const string WriteoffType = "NCLS030P";
            public const string BankruptcyFraud = "NCLS014P02";
            public const string MappingOA = "NCLS031P01";
            public const string Bucket = "NCLS033P01";
            public const string Signature = "NCLS034P01";
            public const string ReceiveBack = "NCLS009P02";
            public const string Province = "NCLS035P01";
        }
        #endregion
        #endregion

        #region Table
        public struct NameParameter
        {

            public static string ContractNo = "ContractNo";
            public static string BarCodeBBL = "BarCodeBBL";
            public static string BarCodeBBL1 = "BarCodeBBL1";
            public static string BarCodeBBL2 = "BarCodeBBL2";
            public static string BarCodeBBL3 = "BarCodeBBL3";
            public static string BarCodeBBL4 = "BarCodeBBL4";
            public static string BarCodeBBL5 = "BarCodeBBL5";
            public static string BarCodeCITI = "BarCodeCITI";
            public static string BarCodeCITI1 = "BarCodeCITI1";
            public static string BarCodeCITI2 = "BarCodeCITI2";
            public static string BarCodeCITI3 = "BarCodeCITI3";
            public static string BarCodeCITI4 = "BarCodeCITI4";
            public static string BarCodeCITI5 = "BarCodeCITI5";
            public static string StrDueDate = "StrDueDate";
            public static string OVDAmt = "OVDAmt";
            public static string OVDTermStart = "OVDTermStart";
            public static string CustName = "CustName";
            public static string Asset = "Asset";
            public static string Plate = "Plate";
            public static string DealerType = "DealerType";
            public static string InstallAmt = "InstallAmt";

        }
        #endregion

        public struct Config
        {
            public static string JSNull = "null";
            public static string JSUndefined = "undefined";
            public static int PageSize = 5;
            public static int PageDisplay = 10;
            public static string DateFormat = "dd/MM/yyyy";
            public const string DateTimeFormat = "dd/MM/yyyy HH:mm";
            public static string Dateyyyymmdd = "yyyymmdd";
            public static string DateCultureTH = "th-TH";
            public static string DateyyyyMMdd = "yyyyMMdd";
            public static string UICulture = "en-EN";

            public static string TempFileDownloadPath = "~/TempFiles/Download/";
            public static string TempFileDownloadExcelExt = ".xls";
        }
        public struct UrlAction
        {
            //Base
            public static string ContractSearch = VirtualPathUtility.ToAbsolute("~/Base/SearchContract");
            public static string ContractRepoSearch = VirtualPathUtility.ToAbsolute("~/Base/ContractNoRepoSearch");

            //Home
            public static string HomeSwitchRole = VirtualPathUtility.ToAbsolute("~/Home/_SwitchRole");
            public static string HomeSelectRole = VirtualPathUtility.ToAbsolute("~/Home/_SelectRole");
            public static string HomeCheckLogin = VirtualPathUtility.ToAbsolute("~/Home/CheckLogin");
            public static string HomeCheckLoginADandDb = VirtualPathUtility.ToAbsolute("~/Home/CheckLoginADandDB");
            public static string HomeLogin = VirtualPathUtility.ToAbsolute("~/Home/Login");
            public static string HomeLogout = VirtualPathUtility.ToAbsolute("~/Home/Logout");
            //Dashboard
            public static string DashboardR3 = VirtualPathUtility.ToAbsolute("~/Dashboard/GetChartsR3");
            public static string DashboardRepo = VirtualPathUtility.ToAbsolute("~/Dashboard/GetChartsRepo");
            public static string DashboardDoc = VirtualPathUtility.ToAbsolute("~/Dashboard/GetChartsDoc");
            public static string DashboardLegal = VirtualPathUtility.ToAbsolute("~/Dashboard/GetChartsLegal");
            public static string DashboardLegalStatus = VirtualPathUtility.ToAbsolute("~/Dashboard/GetChartsLegalStatus");
            public static string DashboardLegalCase = VirtualPathUtility.ToAbsolute("~/Dashboard/GetChartsLegalCase");

            //ContractInfo
            public static string ContractInfoViewContract = VirtualPathUtility.ToAbsolute("~/ContractInfo/_ViewContract");

            //YellowCard
            public static string ReceiveSearch = VirtualPathUtility.ToAbsolute("~/ReceiveYellowCard/_Search");
            public static string ContractSearchR3 = VirtualPathUtility.ToAbsolute("~/ReceiveYellowCard/ContractSerachR3");
            public static string SearchCusName = VirtualPathUtility.ToAbsolute("~/ReceiveYellowCard/SearchCusName");
            public static string ImportExcel = VirtualPathUtility.ToAbsolute("~/ReceiveYellowCard/ImportExcel");

            public static string Save = VirtualPathUtility.ToAbsolute("~/ReceiveYellowCard/Save");
            public static string DownloadTemplateR3 = VirtualPathUtility.ToAbsolute("~/ReceiveYellowCard/GetExcelFile");
            public static string PathDownloadTemplateR3 = VirtualPathUtility.ToAbsolute("~/TempFiles/EMS_TrackingTemplate2.xls");
            public static string UploadSave = VirtualPathUtility.ToAbsolute("~/ReceiveYellowCard/SaveUpload");
            public static string YellowBarCode = VirtualPathUtility.ToAbsolute("~/ReceiveYellowCard/_BarCode");
            public static string YellowBarCodeValidate = VirtualPathUtility.ToAbsolute("~/ReceiveYellowCard/ValidateBarcode");
            public static string YellowBarCodeDetail = VirtualPathUtility.ToAbsolute("~/ReceiveYellowCard/_BarCodeDetail");
            public static string YellowBarCodeSave = VirtualPathUtility.ToAbsolute("~/ReceiveYellowCard/BarCodeSave");
            public static string CheckReceivrDateBarcode = VirtualPathUtility.ToAbsolute("~/ReceiveYellowCard/CheckMaxSendDate");
            public static string ExportExcelR3 = VirtualPathUtility.ToAbsolute("~/ReceiveYellowCard/DownloadFile");

            //Receive Car
            public static string ReceiveCarSearch = VirtualPathUtility.ToAbsolute("~/ReceiveCar/_Search");
            public static string ContractReceiveCarSearch = VirtualPathUtility.ToAbsolute("~/ReceiveCar/ContractSearchJobRepo");
            public static string SearchRefNoReceiveCar = VirtualPathUtility.ToAbsolute("~/ReceiveCar/SearchRef");
            public static string SearchBorrowerReceiveCar = VirtualPathUtility.ToAbsolute("~/ReceiveCar/SearchBorrower");
            public static string SearchAdminReceiveCar = VirtualPathUtility.ToAbsolute("~/ReceiveCar/SearchAdmin");
            public static string SearchLegalReceiveCar = VirtualPathUtility.ToAbsolute("~/ReceiveCar/SearchLegal");
            public static string SearchLegalOaSuc = VirtualPathUtility.ToAbsolute("~/ReceiveCar/SearchLegalOASuc");
            public static string ImportExcelCar = VirtualPathUtility.ToAbsolute("~/ReceiveCar/ImportExcel");
            public static string ImportExcelCar2 = VirtualPathUtility.ToAbsolute("~/ReceiveCar/ImportExcelContract");
            public static string ViewTracking = VirtualPathUtility.ToAbsolute("~/ReceiveCar/_Tracking");
            public static string SaveTracking = VirtualPathUtility.ToAbsolute("~/ReceiveCar/SaveTracking");
            public static string SendDataToRps = VirtualPathUtility.ToAbsolute("~/ReceiveCar/SendDataToRps");
            public static string UploadSaveRc = VirtualPathUtility.ToAbsolute("~/ReceiveCar/SaveUpload");
            public static string SaveTrackingNote = VirtualPathUtility.ToAbsolute("~/ReceiveCar/SaveTrackingNote");
            public static string SearchTrackingNote = VirtualPathUtility.ToAbsolute("~/ReceiveCar/_tbTracking");
            public static string PathDownloadTemplateTrackingNote = VirtualPathUtility.ToAbsolute("~/TempFiles/ReceiveCarTemplate.xls");
            public static string DownloadTemplateTrackingNote = VirtualPathUtility.ToAbsolute("~/ReceiveCar/GetExcelFile");
            public static string Calculate = VirtualPathUtility.ToAbsolute("~/ReceiveCar/Calculate");

            //Master
            public static string MasterIndex = VirtualPathUtility.ToAbsolute("~/Master/Index");
            public static string MasterSave = VirtualPathUtility.ToAbsolute("~/Master/Save");
            public static string MasterDelete = VirtualPathUtility.ToAbsolute("~/Master/Delete");
            public static string MasterSearch = VirtualPathUtility.ToAbsolute("~/Master/_Search");
            public static string MasterDetail = VirtualPathUtility.ToAbsolute("~/Master/_Detail");

            //Bucket
            public static string BucketSerach = VirtualPathUtility.ToAbsolute("~/Bucket/_Search");
            public static string BucketSave = VirtualPathUtility.ToAbsolute("~/Bucket/Save");

            //Court
            public static string CourtSerach = VirtualPathUtility.ToAbsolute("~/Court/_Search");
            public static string CourtIndex = VirtualPathUtility.ToAbsolute("~/Court/Index");
            public static string CourtSave = VirtualPathUtility.ToAbsolute("~/Court/Save");

            //Province
            public static string ProvinceSerach = VirtualPathUtility.ToAbsolute("~/Province/_Search");
            public static string ProvinceIndex = VirtualPathUtility.ToAbsolute("~/Province/Index");
            public static string ProvincetSave = VirtualPathUtility.ToAbsolute("~/Province/Save");

            //User
            public static string UserIndex = VirtualPathUtility.ToAbsolute("~/User/Index");
            public static string UserSave = VirtualPathUtility.ToAbsolute("~/User/Save");
            public static string UserSerach = VirtualPathUtility.ToAbsolute("~/User/_Search");
            public static string UserSerachAd = VirtualPathUtility.ToAbsolute("~/User/SearchAD");

            //Doc
            public static string DocIndex = VirtualPathUtility.ToAbsolute("~/Document/Index");
            public static string DocSave = VirtualPathUtility.ToAbsolute("~/Document/Save");
            public static string DocSerach = VirtualPathUtility.ToAbsolute("~/Document/_Search");

            //Status
            public static string StatusIndex = VirtualPathUtility.ToAbsolute("~/Status/Index");
            public static string StatusSave = VirtualPathUtility.ToAbsolute("~/Status/Save");
            public static string StatusSerach = VirtualPathUtility.ToAbsolute("~/Status/_Search");

            //Trans
            public static string TranIndex = VirtualPathUtility.ToAbsolute("~/Transaction/Index");
            public static string TranSave = VirtualPathUtility.ToAbsolute("~/Transaction/Save");
            public static string TranSerach = VirtualPathUtility.ToAbsolute("~/Transaction/_Search");

            //Role
            public static string RoleSerach = VirtualPathUtility.ToAbsolute("~/Role/_Search");
            public static string RoleSave = VirtualPathUtility.ToAbsolute("~/Role/Save");
            public static string RoleIndex = VirtualPathUtility.ToAbsolute("~/Role/Index");
            public static string RoleSearchPermission = VirtualPathUtility.ToAbsolute("~/Role/GetPermissionData");
            public static string RoleSavePermission = VirtualPathUtility.ToAbsolute("~/Role/SavePermission");

            //Permission
            public static string PermissionSerach = VirtualPathUtility.ToAbsolute("~/Permission/_Search");
            public static string PermissionSave = VirtualPathUtility.ToAbsolute("~/Permission/Save");
            public static string PermissionIndex = VirtualPathUtility.ToAbsolute("~/Permission/Index");

            //Parameter
            public static string ParameterIndex = VirtualPathUtility.ToAbsolute("~/Parameter/Index");
            public static string ParameterSearch = VirtualPathUtility.ToAbsolute("~/Parameter/_Search");
            public static string ParameterSave = VirtualPathUtility.ToAbsolute("~/Parameter/Save");

            //Signature
            public static string SignatureSearch = VirtualPathUtility.ToAbsolute("~/Signature/_search");
            public static string SignatureSave = VirtualPathUtility.ToAbsolute("~/Signature/Save");

            //BatchLog
            public static string BatchSerach = VirtualPathUtility.ToAbsolute("~/Batch/_Search");

            //OutsourceGroup
            public static string OutsourceGroupIndex = VirtualPathUtility.ToAbsolute("~/OutsourceGroup/Index");
            public static string OutsourceGroupSave = VirtualPathUtility.ToAbsolute("~/OutsourceGroup/Save");
            public static string OutsourceGroupSearch = VirtualPathUtility.ToAbsolute("~/OutsourceGroup/_Search");
            public static string OutsourceGroupDetail = VirtualPathUtility.ToAbsolute("~/OutsourceGroup/_Detail");

            //Outsource
            public static string OutsourceIndex = VirtualPathUtility.ToAbsolute("~/Outsource/Index");
            public static string OutsourceSave = VirtualPathUtility.ToAbsolute("~/Outsource/Save");
            public static string OutsourceSearch = VirtualPathUtility.ToAbsolute("~/Outsource/_Search");
            public static string OutsourceDetail = VirtualPathUtility.ToAbsolute("~/Outsource/_Detail");
            public static string OutsourceSaveMappingOa = VirtualPathUtility.ToAbsolute("~/Outsource/SaveMappingOA");

            //Test
            public static string TestIndex = "~/Test/Index";
            public static string TestSearch = "~/Test/_Search";
            public static string TestSave = "~/Test/Save";

            //LegalStatus


            public static string LegalStatusIndex = VirtualPathUtility.ToAbsolute("~/LegalStatus/Index");
            public static string LegalStatusSearch = VirtualPathUtility.ToAbsolute("~/LegalStatus/_Search");
            public static string LegalStatusSave = VirtualPathUtility.ToAbsolute("~/LegalStatus/Save");
            public static string LegalStatusSaveStatus = VirtualPathUtility.ToAbsolute("~/LegalStatus/SaveStatus");

            //To do list
            public static string TodoListsearchRefNo = VirtualPathUtility.ToAbsolute("~/TodoList/searchRefNo");
            public static string TodoListsearchCustomer = VirtualPathUtility.ToAbsolute("~/TodoList/searchCustomer");
            public static string TodoListsearchLegalStatus = VirtualPathUtility.ToAbsolute("~/TodoList/_ddlStatus");
            public static string TodoListSearchDefault = VirtualPathUtility.ToAbsolute("~/TodoList/_SearchDefault");
            public static string TodoListSearch = VirtualPathUtility.ToAbsolute("~/TodoList/_Search");
            public static string TodoListSave = VirtualPathUtility.ToAbsolute("~/TodoList/Save");
            public static string TodoList = VirtualPathUtility.ToAbsolute("~/TodoList/searchRefNo");
            public static string TodoListCheckDocument = VirtualPathUtility.ToAbsolute("~/TodoList/_CheckDocument");
            public static string TodoListSacveCalcelLegal = VirtualPathUtility.ToAbsolute("~/TodoList/SaveCancelLegal");
            public static string TodoListSacveCalcelRepo = VirtualPathUtility.ToAbsolute("~/TodoList/SaveCancelRepo");
            public static string TodoListDownloadExcelFile = VirtualPathUtility.ToAbsolute("~/TodoList/DownloadFile");
            //Court Fees
            public static string CourtFeesSearchRefNo = VirtualPathUtility.ToAbsolute("~/CourtFees/searchRefNo");
            public static string CourtFeesSearchRefNoAdd = VirtualPathUtility.ToAbsolute("~/CourtFees/searchRefNoAdd");
            public static string CourtFeesSearchPaymentNo = VirtualPathUtility.ToAbsolute("~/CourtFees/searchPaymentNo");
            public static string CourtFeesSelectDataByRefNo = VirtualPathUtility.ToAbsolute("~/CourtFees/selectDataByRefNo");
            public static string CourtFeesSearchLegalOa = VirtualPathUtility.ToAbsolute("~/CourtFees/legalOA");
            public static string CourtFeesDetail = VirtualPathUtility.ToAbsolute("~/CourtFees/_CourtFeesDetail");
            public static string CourtFeesSearch = VirtualPathUtility.ToAbsolute("~/CourtFees/_Search");
            public static string CourtFeesShowDetails = VirtualPathUtility.ToAbsolute("~/CourtFees/_ShowDetails");
            public static string CourtFeesShowDetailsApprove = VirtualPathUtility.ToAbsolute("~/CourtFees/_ShowDetailsApprove");
            public static string CourtFeesShowHeadApprove = VirtualPathUtility.ToAbsolute("~/CourtFees/_ShowHeadApprove");
            public static string CourtFeesDetailEdit = VirtualPathUtility.ToAbsolute("~/CourtFees/_CourtFeesDetailEdit");
            public static string CourtFeesSave = VirtualPathUtility.ToAbsolute("~/CourtFees/SaveAll");
            public static string CourtFeesUploadExcel = VirtualPathUtility.ToAbsolute("~/CourtFees/ImportExcel");
            public static string CourtFeesSaveUpload = VirtualPathUtility.ToAbsolute("~/CourtFees/SaveUpload");
            public static string CourtFeesSaveDownloadTemp = VirtualPathUtility.ToAbsolute("~/CourtFees/SaveDownloadTemplete");
            public static string CourtFeesApprove = VirtualPathUtility.ToAbsolute("~/CourtFees/CourtFeesApprove");
            public static string CourtFeesReject = VirtualPathUtility.ToAbsolute("~/CourtFees/CourtFeesReject");
            public static string CourtFeesSearchContractNo = VirtualPathUtility.ToAbsolute("~/CourtFees/searchContractNo");
            public static string CourtFeesReceiveBackEdit = VirtualPathUtility.ToAbsolute("~/CourtFees/_CourtFeesReceiveBackEdit");
            public static string AddAndRemoveReceiveBlack = VirtualPathUtility.ToAbsolute("~/CourtFees/_AddAndRemoveReceiveBlack");
            public static string CourtFeesSaveReceiveBlack = VirtualPathUtility.ToAbsolute("~/CourtFees/CourtFeesSaveReceiveBlack");
            public static string ValidateCourtFees = VirtualPathUtility.ToAbsolute("~/CourtFees/ValidateCourtFees");
            public static string CourtFeesReceiveBack = VirtualPathUtility.ToAbsolute("~/CourtFees/_CourtFeesReceiveBack");
            public static string CourtFeesSelectDataByContract = VirtualPathUtility.ToAbsolute("~/CourtFees/CourtFeesSelectDataByContract");
            public static string CourtFeesSaveReceiveBack = VirtualPathUtility.ToAbsolute("~/CourtFees/SaveAllReceiveBack");
            public static string CourtFeesDownloadExcelFile = VirtualPathUtility.ToAbsolute("~/CourtFees/DownloadFile");
            // public static string CheckReceiveBackAmount = VirtualPathUtility.ToAbsolute("~/CourtFees/CheckReceiveBackAmount");
            //Other Expense
            public static string OtherExpenseSearchRefNo = VirtualPathUtility.ToAbsolute("~/OtherExpense/searchRefNo");
            public static string OtherExpenseSearchRefNoAdd = VirtualPathUtility.ToAbsolute("~/OtherExpense/searchRefNoAdd");
            public static string OtherExpensearchPaymentNo = VirtualPathUtility.ToAbsolute("~/OtherExpense/searchPaymentNo");
            public static string OtherExpenseSearch = VirtualPathUtility.ToAbsolute("~/OtherExpense/_Search");
            public static string OtherExpenseShowDetails = VirtualPathUtility.ToAbsolute("~/OtherExpense/_ShowDetails");
            public static string OtherExpenseDetailEdit = VirtualPathUtility.ToAbsolute("~/OtherExpense/_OtherExpenseDetailEdit");
            public static string OtherExpenseTableDetail = VirtualPathUtility.ToAbsolute("~/OtherExpense/_OtherExpenseTableDetail");
            public static string OtherExpenseSave = VirtualPathUtility.ToAbsolute("~/OtherExpense/SaveAll");
            public static string OtherExpenseUploadExcel = VirtualPathUtility.ToAbsolute("~/OtherExpense/ImportExcel");
            public static string OtherExpenseHeadApprove = VirtualPathUtility.ToAbsolute("~/OtherExpense/_ShowHeadApprove");
            public static string OtherExpenseDetailsApprove = VirtualPathUtility.ToAbsolute("~/OtherExpense/_ShowDetailsApprove");
            public static string OtherExpenseApprove = VirtualPathUtility.ToAbsolute("~/OtherExpense/OtherExpenseApprove");
            public static string OtherExpenseReject = VirtualPathUtility.ToAbsolute("~/OtherExpense/OtherExpenseReject");
            public static string SelectDataByExpenseCode = VirtualPathUtility.ToAbsolute("~/OtherExpense/SelectDataByExpenseCode");
            public static string SelectDataByLegalOA = VirtualPathUtility.ToAbsolute("~/OtherExpense/SelectDataByLegalOA");
            public static string OtherExpenseSaveDetail = VirtualPathUtility.ToAbsolute("~/OtherExpense/_OtherExpenseTableTemp");
            public static string ValidateOtherExpense = VirtualPathUtility.ToAbsolute("~/OtherExpense/ValidateOtherExpense");
            public static string OtherExpenseDownloadTemp = VirtualPathUtility.ToAbsolute("~/OtherExpense/SaveDownloadTemplete");
            public static string OtherExpenseSaveUpload = VirtualPathUtility.ToAbsolute("~/OtherExpense/SaveUpload");
            public static string OtherExpenseSelectDataByRefNo = VirtualPathUtility.ToAbsolute("~/OtherExpense/selectDataByRefNo");
            public static string OtherExpenseSelectGroupExpense = VirtualPathUtility.ToAbsolute("~/OtherExpense/SelectGroupExpense");

            public static string OtherExpenseDownloadExcelFile = VirtualPathUtility.ToAbsolute("~/OtherExpense/DownloadFile");

            //ReceiveBack
            public static string ReceiveBackSearchRefNo = VirtualPathUtility.ToAbsolute("~/ReceiveBack/searchRefNo");
            public static string ReceiveBackSearchPaymentNo = VirtualPathUtility.ToAbsolute("~/ReceiveBack/searchPaymentNo");
            public static string ReceiveBackSearch = VirtualPathUtility.ToAbsolute("~/ReceiveBack/_Search");
            public static string ReceiveBackShowDetails = VirtualPathUtility.ToAbsolute("~/ReceiveBack/_ShowDetails");
            public static string ReceiveBackShowHeadApprove = VirtualPathUtility.ToAbsolute("~/ReceiveBack/_ShowHeadApprove");
            public static string ReceiveBackShowDetailsApprove = VirtualPathUtility.ToAbsolute("~/ReceiveBack/_ShowDetailsApprove");
            public static string ReceiveBackApprove = VirtualPathUtility.ToAbsolute("~/ReceiveBack/ReveiveBackApprove");
            public static string ReceiveBackReject = VirtualPathUtility.ToAbsolute("~/ReceiveBack/ReveiveReject");
            public static string ReceiveBackAddAndRemove = VirtualPathUtility.ToAbsolute("~/ReceiveBack/_AddAndRemoveReceiveBlack");
            public static string ReceiveBackSave = VirtualPathUtility.ToAbsolute("~/ReceiveBack/SaveAllReceiveBack");
            public static string ReceiveBackSearchContractNo = VirtualPathUtility.ToAbsolute("~/ReceiveBack/searchContractNo");
            public static string ReceiveBackSelectDataByContract = VirtualPathUtility.ToAbsolute("~/ReceiveBack/SelectDataByContract");
            public static string CheckReceiveBackAmount = VirtualPathUtility.ToAbsolute("~/ReceiveBack/CheckReceiveBackAmount");
            public static string ReceiveBackEdit = VirtualPathUtility.ToAbsolute("~/ReceiveBack/_ReceiveBackEdit");
            public static string ValidateReceiveBack = VirtualPathUtility.ToAbsolute("~/ReceiveBack/ValidateReceiveBack");
            public static string ReceiveBackDownloadExcelFile = VirtualPathUtility.ToAbsolute("~/ReceiveBack/DownloadFile");
            //LegalCase
            public static string LegalSaveTracking = VirtualPathUtility.ToAbsolute("~/LegalInfo/SaveTracking");
            public static string _DetailCase = VirtualPathUtility.ToAbsolute("~/LegalInfo/_DetailCase");
            public static string _AttachmentCase = VirtualPathUtility.ToAbsolute("~/LegalInfo/_AttachmentCase");
            public static string _CarReceivesCase = VirtualPathUtility.ToAbsolute("~/LegalInfo/_CarReceivesCase");
            public static string _CourtFeeCase = VirtualPathUtility.ToAbsolute("~/LegalInfo/_CourtFeeCase");
            public static string _LegalTrackingCase = VirtualPathUtility.ToAbsolute("~/LegalInfo/_LegalTrackingCase");
            public static string _OtherExpenseCase = VirtualPathUtility.ToAbsolute("~/LegalInfo/_OtherExpenseCase");
            public static string _ContractListCase = VirtualPathUtility.ToAbsolute("~/LegalInfo/_ContractListCase");
            public static string _RepossessionCase = VirtualPathUtility.ToAbsolute("~/LegalInfo/_RepossessionCase");

            //Suggest Write-off
            public static string GeneralSearch = VirtualPathUtility.ToAbsolute("~/WriteOff/_SearchGeneral");
            public static string ViewDocSearch = VirtualPathUtility.ToAbsolute("~/WriteOff/_SearchViewDoc");
            public static string DropDownSubType = VirtualPathUtility.ToAbsolute("~/WriteOff/_ddlSubType");
            public static string ApproveSuggest = VirtualPathUtility.ToAbsolute("~/WriteOff/Approve");
            public static string RejectSuggest = VirtualPathUtility.ToAbsolute("~/WriteOff/Reject");
            public static string SaveSuggest = VirtualPathUtility.ToAbsolute("~/WriteOff/Save");
            public static string SearchContractWriteOff = VirtualPathUtility.ToAbsolute("~/WriteOff/SearchContract");
            public static string EditWriteOff = VirtualPathUtility.ToAbsolute("~/WriteOff/_EditWriteOff");
            public static string WriteOffDetail = VirtualPathUtility.ToAbsolute("~/WriteOff/_showWriteOffDoc");
            public static string SaveToWriteOff = VirtualPathUtility.ToAbsolute("~/WriteOff/_ShowWriteOff");
            public static string ClearSessionWriteOff = VirtualPathUtility.ToAbsolute("~/WriteOff/DestroySession");
            public static string WriteOffLegalStatus = VirtualPathUtility.ToAbsolute("~/WriteOff/_ddlLegalStatus");
            public static string ContractWriteOffSerach = VirtualPathUtility.ToAbsolute("~/WriteOff/ContractSerach");
            public static string PrintDoc = VirtualPathUtility.ToAbsolute("~/WriteOff/PrintDoc");
            public static string ContractSerachWO = VirtualPathUtility.ToAbsolute("~/WriteOff/ContractSerach");
            public static string ExportExcelWF = VirtualPathUtility.ToAbsolute("~/WriteOff/DownloadFile");

            //Bankrupcy && Frauad
            public static string DocNoSearch = VirtualPathUtility.ToAbsolute("~/BankrupcyFraud/SearchDoc");
            public static string BankFraudSearch = VirtualPathUtility.ToAbsolute("~/BankrupcyFraud/_SearchBankAndFraud");
            public static string UploadFraud = VirtualPathUtility.ToAbsolute("~/BankrupcyFraud/ImportExcelFraud");
            public static string UploadBank = VirtualPathUtility.ToAbsolute("~/BankrupcyFraud/ImportExcelBank");
            public static string SaveFraud = VirtualPathUtility.ToAbsolute("~/BankrupcyFraud/SaveFraudUpload");
            public static string SaveBank = VirtualPathUtility.ToAbsolute("~/BankrupcyFraud/SaveBankUpload");
            public static string ApproveBf = VirtualPathUtility.ToAbsolute("~/BankrupcyFraud/Approve");
            public static string RejectBf = VirtualPathUtility.ToAbsolute("~/BankrupcyFraud/Reject");
            public static string DownloadTremplateFraud = VirtualPathUtility.ToAbsolute("~/BankrupcyFraud/GetFraudFile");
            public static string PathDownloadTremplateFraud = VirtualPathUtility.ToAbsolute("~/TempFiles/ExcelTemplate/FraudTemplate.xls");

            //AssSignRepoOA
            public static string AssSignRepoSearch = VirtualPathUtility.ToAbsolute("~/AssignRepoOa/_Search");
            public static string AssSignRepoSearchGen = VirtualPathUtility.ToAbsolute("~/AssignRepoOa/_SearchGen");
            public static string SendToOA = VirtualPathUtility.ToAbsolute("~/AssignRepoOa/_SendToOA");
            public static string SaveOA = VirtualPathUtility.ToAbsolute("~/AssignRepoOa/Save");
            public static string ClearSessionOA = VirtualPathUtility.ToAbsolute("~/AssignRepoOa/DestroySession");
            public static string ContractNoAssignSearch = VirtualPathUtility.ToAbsolute("~/AssignRepoOa/ContractNoSearch");
            public static string ExportExcelAssignRepoOA = VirtualPathUtility.ToAbsolute("~/AssignRepoOa/DownloadFile");

            //Write-Off Type
            public static string WriteoffTypeSave = VirtualPathUtility.ToAbsolute("~/WriteOffType/Save");
            public static string WriteoffTypeSearch = VirtualPathUtility.ToAbsolute("~/WriteOffType/_Search");
            public static string DropDownSubType2 = VirtualPathUtility.ToAbsolute("~/WriteOffType/_ddlSubType");


            //Cash Receipt
            public static string CashReceiptSearch = VirtualPathUtility.ToAbsolute("~/CashReceipt/_Search");
            public static string bindSchedule = VirtualPathUtility.ToAbsolute("~/CashReceipt/_tbShow");

            //Judgment Debtor
            public static string JudgmentDebtorLegalCaseSearch = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/_SearchLegalCase");
            public static string JudgmentDebtorChequeSearch = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/_SearchCheque");

            public static string JudgmentDebtorSelectViewDetailDebtor = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/SelectViewDetailDebtor");
            public static string JudgmentDebtorViewDetailDebtor = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/_ViewDetailDebtor");

            public static string JudgmentDebtorSelectViewDetailDebtorDetails = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/SelectViewDetailDebtorDetails");
            public static string JudgmentDebtorAddDetailDebtorDetails = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/AddDetailDebtorDetails");
            public static string JudgmentDebtorEditDetailDebtorDetails = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/EditDetailDebtorDetails");
            public static string JudgmentDebtorUpdateDetailDebtorDetails = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/UpdateDetailDebtorDetails");
            public static string JudgmentDebtorDeleteDetailDebtorDetails = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/DeleteDetailDebtorDetails");
            public static string JudgmentDebtorViewTableDetailDebtorDetails = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/ViewTableDetailDebtorDetails");
            public static string JudgmentDebtortbViewDetailDebtorDetail = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/_tbViewDetailDebtorDetails");

            public static string JudgmentDebtorSelecttbPayment = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/SelecttbPayment");

            public static string JudgmentDebtorCheckNumOfDays = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/CheckNumOfDays");
            public static string JudgmentDebtorAddMonth = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/AddMonth");
            public static string JudgmentDebtorSetEndDate = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/SetEndDate");
            public static string JudgmentDebtorCalInterestAmount = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/CalInterestAmount");
            public static string JudgmentDebtorCalculateMonthPayment = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/CalculateMonthPayment");

            public static string JudgmentDebtorViewDetailDebtorDetails = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/_ViewDetailDebtorDetails");
            public static string JudgmentDebtorViewDetailDebtorCompromise = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/_ViewDetailDebtorCompromise");

            public static string JudgmentDebtorSelectChequeDetails = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/SelectChequeDetails");
            public static string JudgmentDebtorGetChequeInfomationByRefNo = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/GetChequeInfomationByRefNo");
            public static string JudgmentDebtorGetChequeInfomationByJDID = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/GetChequeInfomationByJDID");

            public static string JudgmentDebtorLegalCaseSearchRefNo = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/SearchLegalCaseRefNo");
            public static string JudgmentDebtorLegalCaseSelectRefNo = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/SelectLegalCaseRefNo");
            public static string JudgmentDebtorGetContractByRefNo = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/GetContractByRefNo");
            public static string JudgmentDebtorGetContractByJDID = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/GetContractByJDID");

            public static string JudgmentDebtorChequeSearchRefNo = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/SearchChequeRefNo");
            public static string JudgmentDebtorChequeSelectRefNo = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/SelectChequeRefNo");


            public static string JudgmentDebtorRefreshSchTotalAmount = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/RefreshSchTotalAmount");
            public static string JudgmentDebtorGenerateSchedulePayment = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/GenerateSchedulePayment");
            public static string JudgmentDebtortbPayment = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/_tbPayment");
            public static string JudgmentDebtorGeneratePayment = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/GeneratePayment");

            public static string JudgmentDebtorAttachDocument = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/AttachDocument");
            public static string JudgmentDebtorDeleteAttachDocument = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/DeleteAttachDocument");



            public static string JudgmentDebtorApprove = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/Approve");
            public static string JudgmentDebtorReject = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/Reject");
            public static string JudgmentDebtorSave = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/Save");
            public static string JudgmentDebtorSaveCompromise = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/SaveCompromise");
            public static string JudgmentDebtorSaveJudgmentDebtor = VirtualPathUtility.ToAbsolute("~/JudgmentDebtor/SaveJudgmentDebtor");

            public static string Error = VirtualPathUtility.ToAbsolute("~/Error/Error");

            // MappignOA
            public static string MappingOASearch = VirtualPathUtility.ToAbsolute("~/MappingOA/_Search");
            public static string MappingOADetail = VirtualPathUtility.ToAbsolute("~/MappingOA/_Detail");
            public static string MappingOASaveMappingOA = VirtualPathUtility.ToAbsolute("~/MappingOA/SaveMappingOA");
            public static string MappingOAValidateAdd = VirtualPathUtility.ToAbsolute("~/MappingOA/ValidateAdd");
            public static string MappingOASumAllPercent = VirtualPathUtility.ToAbsolute("~/MappingOA/SumAllPercent");

            // SpecialCase 
            public static string SpecialCaseAddChequeList = VirtualPathUtility.ToAbsolute("~/SpecialCase/_AddChequeList");
            public static string SpecialCaseCheckDuplicateCheque = VirtualPathUtility.ToAbsolute("~/SpecialCase/CheckDuplicateCheque");
            public static string SpecialCaseReject = VirtualPathUtility.ToAbsolute("~/SpecialCase/SpecialCaseReject");
            public static string SpecialCaseSearchRefNo = VirtualPathUtility.ToAbsolute("~/SpecialCase/searchRefNo");
        }

        public struct JsTreeConfig
        {
            public const string TextAdd = "Add";
            public const string TextEdit = "Edit";
            public const string TextView = "View";

            public const string IconDefault = "fa fa-folder icon-state-warning icon-lg";
            public const string IconAdd = "fa fa-plus font-green-jungle icon-lg";
            public const string IconEdit = "fa fa-pencil icon-state-warning icon-lg";
            public const string IconView = "fa fa-eye font-dark icon-lg";
        }

        public struct DebtorStatus
        {
            public const string AppearText = "ลูกหนี้แสดงตน";
            public const string AppearCode = "A";
            public const string NotAppearText = "ลูกหนี้ไม่แสดงตน";
            public const string NotAppearCode = "N";

            public const string CompromiseIOUText = "ลูกหนี้สัญญายอม (IOU)";
            public const string CompromiseIOUCode = "DSCI";
            public const string CompromiseVIOUText = "ลูกหนี้ตามคําพิพากษา (Verdict IOU)";
            public const string CompromiseVIOUCode = "DSCV";

            public const string CompromiseText = "ลูกหนี้สัญญายอม (On court)";
            public const string CompromiseCode = "DSCP";
            public const string JudgmentDebtorText = "ลูกหนี้ตามคําพิพากษา";
            public const string JudgmentDebtorCode = "DSJD";

        }
        public struct R3Status
        {
            public static string SendR310 = "R310";
            public static string PendingR320 = "R320";
            public static string AcceptR330 = "R330";
            public static string RejectR340 = "R340";

            public static string SendR3Text = "กำลังส่ง";
            public static string PendingR3Text = "รอใบตอบรับ";
            public static string AcceptR3Text = "ลูกค้าตอบรับ";
            public static string RejectR3Text = "จดหมายตีกลับ";

        }
        public struct RepoStatus
        {
            public static string Re01 = "RE01";
            public static string Re02 = "RE02";
            public static string Re03 = "RE03";
            public static string Re04 = "RE04";
            public static string Pending = "กำลังดำเนินการยึด";
            public static string Success = "ยึดรถสำเร็จ";
            public static string SendToRps = "ส่งข้อมูลไป Rps";

        }

        public struct WriteOffStatus
        {
            public static string CompanySt1 = "WT001";
            public static string CompanySt2 = "WT002";
            public static string CaimTaxSt1 = "WT003";
            public static string CaimTaxSt2 = "WT004";
            public static string FromSystem = "WT005";
        }

        //Description Legal Case
        //LC001	คดีอื่นๆ
        //LC002	คดีสคบ
        //LC003	คดียักยอกทร้พย์
        //LC004	คดีฉ้อโกง
        //LC005	คดีโกงเจ้าหนี้
        //LC006	คดีล้มละลาย
        //LC007	คดีฟิ้นฟูกิจการ
        //LC008	คดีร้องคืนของกลาง
        //LC009	คดีปปส
        //LC010	คดีปปง
        //LC011	งานติดตามและยึดรถ
        //LC012	คดีเช็ค
        //LC013	คดีรถหาย
        //LC014	เสียหายโดยสิ้นเชิง
        //LC015	ฟ้องเรียกทรัพย์คืน
        //LC016	ฟ้องส่วนขาดทุน

        public struct LegalCase
        {
            /// <summary>
            /// LC001	คดีอื่นๆ
            /// </summary>
            public const string LC001 = "LC001";
            /// <summary>
            /// LC002	คดีสคบ
            /// </summary>
            public const string LC002 = "LC002";
            /// <summary>
            /// LC003	คดียักยอกทร้พย์
            /// </summary>
            public const string LC003 = "LC003";
            /// <summary>
            /// LC004	คดีฉ้อโกง
            /// </summary>
            public const string LC004 = "LC004";
            /// <summary>
            /// LC005	คดีโกงเจ้าหนี้
            /// </summary>
            public const string LC005 = "LC005";
            /// <summary>
            /// LC006	คดีล้มละลาย
            /// </summary>
            public const string LC006 = "LC006";
            /// <summary>
            /// LC007	คดีฟิ้นฟูกิจการ
            /// </summary>
            public const string LC007 = "LC007";
            /// <summary>
            /// LC008	คดีร้องคืนของกลาง
            /// </summary>
            public const string LC008 = "LC008";
            /// <summary>
            /// LC009	คดีปปส
            /// </summary>
            public const string LC009 = "LC009";
            /// <summary>
            /// LC010	คดีปปง
            /// </summary>
            public const string LC010 = "LC010";
            /// <summary>
            /// LC011	งานติดตามและยึดรถ
            /// </summary>
            public const string LC011 = "LC011";
            /// <summary>
            /// LC012	คดีเช็ค
            /// </summary>
            public const string LC012 = "LC012";
            /// <summary>
            /// LC013	คดีรถหาย
            /// </summary>
            public const string LC013 = "LC013";
            /// <summary>
            /// LC014	เสียหายโดยสิ้นเชิง
            /// </summary>
            public const string LC014 = "LC014";
            /// <summary>
            /// LC015	ฟ้องเรียกทรัพย์คืน
            /// </summary>
            public const string LC015 = "LC015";
            /// <summary>
            /// LC016	ฟ้องส่วนขาดทุน
            /// </summary>
            public const string LC016 = "LC016";
        }

        /// <summary>
        /// Transaction Constant
        /// </summary>
        public struct Transaction
        {
            /// <summary>
            ///EX0001 Asset Search Fee
            ///</summary>
            public const string EX0001 = "EX0001";
            /// <summary>
            ///EX0002 Auction Annoucement
            ///</summary>
            public const string EX0002 = "EX0002";
            /// <summary>
            ///EX0003 Car Transfer Fee
            ///</summary>
            public const string EX0003 = "EX0003";
            /// <summary>
            ///EX0004 Collection Fee
            ///</summary>
            public const string EX0004 = "EX0004";
            /// <summary>
            ///EX0005 Court Fee
            ///</summary>
            public const string EX0005 = "EX0005";
            /// <summary>
            ///EX0006 Criminal Fee
            ///</summary>
            public const string EX0006 = "EX0006";
            /// <summary>
            ///EX0007 Damages Fee
            ///</summary>
            public const string EX0007 = "EX0007";
            /// <summary>
            ///EX0008 Duty Stamp Fee
            ///</summary>
            public const string EX0008 = "EX0008";
            /// <summary>
            ///EX0009 First Lawyer Fee Civil Case
            ///</summary>
            public const string EX0009 = "EX0009";
            /// <summary>
            ///EX0010 First Lawyer Fee of Criminal Case
            ///</summary>
            public const string EX0010 = "EX0010";
            /// <summary>
            ///EX0011 First Lawyer Fee of bouce cheque
            ///</summary>
            public const string EX0011 = "EX0011";
            /// <summary>
            ///EX0012 First Lawyer Fee of Appeal
            ///</summary>
            public const string EX0012 = "EX0012";
            /// <summary>
            ///EX0013 First Lawyer Fee of Auction Asset
            ///</summary>
            public const string EX0013 = "EX0013";
            /// <summary>
            ///EX0014 First Seizure Fee
            ///</summary>
            public const string EX0014 = "EX0014";
            /// <summary>
            ///EX0015 First Lawyer Fee of Supreme
            ///</summary>
            public const string EX0015 = "EX0015";
            /// <summary>
            ///EX0016 Juristic Fee
            ///</summary>
            public const string EX0016 = "EX0016";
            /// <summary>
            ///EX0017 Lawyer Fee of Embezzle
            ///</summary>
            public const string EX0017 = "EX0017";
            /// <summary>
            ///EX0018 Newspaper Fee
            ///</summary>
            public const string EX0018 = "EX0018";
            /// <summary>
            ///EX0019 Notice Fee
            ///</summary>
            public const string EX0019 = "EX0019";
            /// <summary>
            ///EX0020 Opportunity Fee
            ///</summary>
            public const string EX0020 = "EX0020";
            /// <summary>
            ///EX0021 Other Fee
            ///</summary>
            public const string EX0021 = "EX0021";
            /// <summary>
            ///EX0022 Re Assignment Fee
            ///</summary>
            public const string EX0022 = "EX0022";
            /// <summary>
            ///EX0023 Re Finance Fee
            ///</summary>
            public const string EX0023 = "EX0023";
            /// <summary>
            ///EX0024 Re Structuring Fee
            ///</summary>
            public const string EX0024 = "EX0024";
            /// <summary>
            ///EX0025 Registration Fee
            ///</summary>
            public const string EX0025 = "EX0025";
            /// <summary>
            ///EX0026 Reminder Letter Fee 1
            ///</summary>
            public const string EX0026 = "EX0026";
            /// <summary>
            ///EX0027 Reminder Letter Fee 2
            ///</summary>
            public const string EX0027 = "EX0027";
            /// <summary>
            ///EX0028 Reminder Letter Fee 3
            ///</summary>
            public const string EX0028 = "EX0028";
            /// <summary>
            ///EX0029 Repossess Car Fee
            ///</summary>
            public const string EX0029 = "EX0029";
            /// <summary>
            ///EX0030 Second Lawyer Fee Civil Case
            ///</summary>
            public const string EX0030 = "EX0030";
            /// <summary>
            ///EX0031 Second Lawyer Fee Civil Case /withdraw
            ///</summary>
            public const string EX0031 = "EX0031";
            /// <summary>
            ///EX0032 Second Lawyer Fee Civil Case /verdict
            ///</summary>
            public const string EX0032 = "EX0032";
            /// <summary>
            ///EX0033 Second Lawyer Fee Civil Case /compromise
            ///</summary>
            public const string EX0033 = "EX0033";
            /// <summary>
            ///EX0034 Second Lawyer Fee of Criminal Case
            ///</summary>
            public const string EX0034 = "EX0034";
            /// <summary>
            ///EX0035 Second Lawyer Fee of bouce cheque
            ///</summary>
            public const string EX0035 = "EX0035";
            /// <summary>
            ///EX0036 Second Lawyer Fee of Appeal
            ///</summary>
            public const string EX0036 = "EX0036";
            /// <summary>
            ///EX0037 Second Lawyer Fee of Auction Asset
            ///</summary>
            public const string EX0037 = "EX0037";
            /// <summary>
            ///EX0038 First Seizure Fee
            ///</summary>
            public const string EX0038 = "EX0038";
            /// <summary>
            ///EX0039 Second Lawyer Fee of Supreme
            ///</summary>
            public const string EX0039 = "EX0039";
            /// <summary>
            ///EX0040 Tax
            ///</summary>
            public const string EX0040 = "EX0040";
            /// <summary>
            ///EX0041 Travel Expense
            ///</summary>
            public const string EX0041 = "EX0041";

            /// <summary>
            ///EX0045 First Lawyer Fee of Bankruptcy
            ///</summary>
            public const string EX0045 = "EX0045";
            /// <summary>
            ///EX0046 Second Lawyer Fee of Bankruptcy
            ///</summary>
            public const string EX0046 = "EX0046";
            /// <summary>
            ///EX0047 Receiving order Fee (BMWL plaintif)
            ///</summary>
            public const string EX0047 = "EX0047";
            /// <summary>
            ///EX0048 Receiving order Fee (Other plaintif)
            ///</summary>
            public const string EX0048 = "EX0048";
            /// <summary>
            ///EX0049 ยื่นคัดค้านแผน Rehabilitation
            ///</summary>
            public const string EX0049 = "EX0049";
            /// <summary>
            ///EX0050 Receiving order Fee of Rehabilitation
            ///</summary>
            public const string EX0050 = "EX0050";
            /// <summary>
            ///EX0051 Arrest warrnat fee/Bankruptcy
            ///</summary>
            public const string EX0051 = "EX0051";
            /// <summary>
            ///EX0052 filing case to police/Bankruptcy
            ///</summary>
            public const string EX0052 = "EX0052";
            /// <summary>
            ///EX0053 Lawyer Fee of Forgery
            ///</summary>
            public const string EX0053 = "EX0053";
            /// <summary>
            ///EX0054 Lawyer Fee of fraudulent
            ///</summary>
            public const string EX0054 = "EX0054";
            /// <summary>
            ///EX0055 Lawyer Fee of cheating Fraud
            ///</summary>
            public const string EX0055 = "EX0055";
            /// <summary>
            ///EX0056 Arrest warrnat fee/Forgery
            ///</summary>
            public const string EX0056 = "EX0056";
            /// <summary>
            ///EX0057 Arrest warrnat fee/Fraudulent
            ///</summary>
            public const string EX0057 = "EX0057";
            /// <summary>
            ///EX0058 Arrest warrant fee/cheating Fraud
            ///</summary>
            public const string EX0058 = "EX0058";
            /// <summary>
            ///EX0059 Slide Car Fee
            ///</summary>
            public const string EX0059 = "EX0059";
            /// <summary>
            ///EX0060 Lawyer fee of Drug  (vehicle)
            ///</summary>
            public const string EX0060 = "EX0060";
            /// <summary>
            ///EX0061 Lawyer fee of Drug  (Cashier cheque)
            ///</summary>
            public const string EX0061 = "EX0061";
            /// <summary>
            ///EX0062 Lawyer fee of AML  (vehicle)
            ///</summary>
            public const string EX0062 = "EX0062";
            /// <summary>
            ///EX0063 Lawyer fee of AML (submit complaint)
            ///</summary>
            public const string EX0063 = "EX0063";
            /// <summary>
            ///EX0064 Lawyer fee of OCPB
            ///</summary>
            public const string EX0064 = "EX0064";
            /// <summary>
            ///EX0065 Lawyer  fee/ vehicle in dispute
            ///</summary>
            public const string EX0065 = "EX0065";
            /// <summary>
            ///EX0066 Miscellaneous
            ///</summary>
            public const string EX0066 = "EX0066";
            /// <summary>
            ///EX0067 Compromise
            ///</summary>
            public const string EX0067 = "EX0067";

        }
    }
}
