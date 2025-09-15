
namespace CERS.Models
{
    public class ExpenditureDetails
    {
        public string ExpenseID { get; set; }
        public string AutoID { get; set; }
        public string expDate { get; set; }
        public string expCode { get; set; }
        public string amtType { get; set; }
        public string amount { get; set; }
        public string paymentDate { get; set; }
        public string Totalamount { get; set; }
        public string voucherBillNumber { get; set; }
        public string payMode { get; set; }
        public string payeeName { get; set; }
        public string EnteredOn { get; set; }
        public string payeeAddress { get; set; }
        public string sourceMoney { get; set; }
        public string remarks { get; set; }
        public string DtTm { get; set; }
        public string ExpStatus { get; set; }
        public string lastupdated { get; set; }

        public string ExpTypeName { get; set; }
        public string ExpTypeNameLocal { get; set; }
        public string PayModeName { get; set; }
        public string PayModeNameLocal { get; set; }
        public string evidenceFile { get; set; }
        public string expDateDisplay { get; set; }
        public string paymentDateDisplay { get; set; }
        public string amountoutstanding { get; set; }
        public string ObserverRemarks { get; set; }
        public string Resultdatethirtydays { get; set; }
        public string displaytitle { get; set; }
        public string lblexpDate { get; set; }
        public string lblexptype { get; set; }
        public string lblamtType { get; set; }
        public string lblAmount { get; set; }
        public string lbl_amountoutstanding { get; set; }
        public string lblObserverRemarks { get; set; }
        public string lblpaymentDate { get; set; }
        public string lblvoucherBillNumber { get; set; }
        public string lblpayMode { get; set; }
        public string lblpayeeName { get; set; }
        public string lblpayeeAddress { get; set; }
        public string lblsourceMoney { get; set; }
        public string lblremarks { get; set; }
        public string lblEnteredOn { get; set; }
        public string lbledit { get; set; }
        public string btnEditVisibility { get; set; }
        public string exptypevisibility { get; set; }
        public string expdatevisibility { get; set; }

        public string amounttodisplay { get; set; }
        public string amountoutstandingtodisplay { get; set; }

        public string lblReplyToObserverRemarks { get; set; }
        public string btnrplyobserverremarksvisibility { get; set; }
    }
}
