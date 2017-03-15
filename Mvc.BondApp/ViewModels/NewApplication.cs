using System;
using System.ComponentModel.DataAnnotations;

namespace templateMvc
{
    public class NewApplication
    {
        [Display(Name = "File No")]
        public int FileNo { get; set; }
        [Display(Name = "Bond Type")]
        public int BondType { get; set; }
        [Display(Name = "App Date")]
        public DateTime AppDate { get; set; }
        [Display(Name = "Total Script")]
        public int TotalScript { get; set; }

        //dont know where it come from
        public string BondAppNo { get; set; }

        public string IssueingBranch { get; set; }

        public DateTime ReInvestmentDate { get; set; }

        public DateTime RespondingDate { get; set; }



        //===================Applicants===============Wage Earners Info
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Display(Name = "Designation")]
        public string Designation { get; set; }
        [Display(Name = "Organisation")]
        public string Organisation { get; set; }
        [Display(Name = "Company Address")]
        public string CompanyAddress { get; set; }
        [Display(Name = "Foreign Address")]
        public string ForeignAddress { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "Local Address")]
        public string LocalAddress { get; set; }
        [Display(Name = "Thana")]
        public string Thana { get; set; }
        [Display(Name = "District")]
        public string District { get; set; }
        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }
        [Display(Name = "Place")]
        public string Place { get; set; }
        [Display(Name = "Issue Date")]
        public DateTime IssueDate { get; set; }
        //Others
        [Display(Name = "Payment Mode")]
        public string PaymentMode { get; set; }
        [Display(Name = "Fc Account No")]
        public int FcAccountNo { get; set; }
        [Display(Name = "Fc Account Branch")]
        public string FcAccountBranch { get; set; }
        [Display(Name = "Currency")]
        public string Currency { get; set; }
        [Display(Name = "Value Date")]
        public DateTime ValueDate { get; set; }
        [Display(Name = "Currency Rate")]
        public decimal CurrencyRate { get; set; }
        [Display(Name = "Amount In Fc")]
        public decimal AmountInFc { get; set; }
        [Display(Name = "Amount For Credit")]
        public decimal AmountForCredit { get; set; }
        [Display(Name = "Demand Draft No")]
        public int DemandDraftNo { get; set; }
        [Display(Name = "Ex. House Or Bank")]
        public string ExHouseOrBank { get; set; }
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        //=====================Others Information=================================
        public string FathersNameOfOthers { get; set; }
        [Display(Name = "Mothers Name Of Beneficiary")]
        public string MothersNameOfOthers { get; set; }

        //=====================Beneficiary====Beneficiary Information=============
        [Display(Name = "Name Of Beneficiary")]
        public string NameOfBeneficiary { get; set; }
        [Display(Name = "Fathers Name Of Beneficiary")]
        public string FathersNameOfBeneficiary { get; set; }
        [Display(Name = "Mothers Name Of Beneficiary")]
        public string MothersNameOfBeneficiary { get; set; }
        [Display(Name = "Address Of Beneficiary")]
        public string AddressOfBeneficiary { get; set; }
        [Display(Name = "Date Of Birth Of Beneficiary")]
        public DateTime DateOfBirthOfBeneficiary { get; set; }

        //========================Bond Script==========================================
        [Display(Name = "Paying Office")]
        public string PayingOffice { get; set; }
        [Display(Name = "Denomination")]
        public int Denomination { get; set; }
        [Display(Name = "Nominee Name")]
        public string NomineeName { get; set; }
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        [Display(Name = "Total No Of Script:")]
        public int TotalNoOfScript { get; set; }
        [Display(Name = "Total No Of Scrrpt For This Nominee:")]
        public int TotalNoOfScrrptForThisNominee { get; set; }

        [Display(Name = "Relation")]
        public string Relation { get; set; }


        public string Prefix { get; set; }

        [Display(Name = "Bond Start No")]
        public int StartNo { get; set; }




    }
}