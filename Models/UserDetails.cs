namespace CERS.Models
{
  public  class UserDetails
    {
        public string AUTO_ID { get; set; }
        public string EPIC_NO { get; set; }
        public string VOTER_NAME { get; set; }
        public string RELATION_TYPE { get; set; }
        public string RELATIVE_NAME { get; set; }
        public string GENDER { get; set; }
        public string AGE { get; set; }
        public string EMAIL_ID { get; set; }
        public string MOBILE_NUMBER { get; set; }
        public string AgentName { get; set; }
        public string AgentMobile { get; set; }
        public string Panchayat_Name { get; set; }
        public string LoggedInAs { get; set; }
        public string OTPID { get; set; }
        public string NominationForName { get; set; }
        public string NominationForNameLocal { get; set; }
        public string PollDate { get; set; }
        public string NominationDate { get; set; }
        public string IsLoggedIn { get; set; }

        public string postcode { get; set; }
        public string LimitAmt { get; set; }
        public string ResultDate { get; set; }
        public string Resultdatethirtydays { get; set; }
        public string Block_Code { get; set; }
        public string panwardcouncilname { get; set; }
        public string panwardcouncilnamelocal { get; set; }
        public string ExpStatus { get; set; }
        //added on 25sep24

        public string expStartDate { get; set; }
        public string expEndDate { get; set; }
    }
}
