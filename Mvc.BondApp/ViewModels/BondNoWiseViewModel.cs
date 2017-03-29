using System;

namespace Mvc.BondApp.ViewModels
{
    public class BondNoWiseViewModel
    {
        public string AppNo { get; set; }
        public string BondType { get; set; }
        public string Prefix { get; set; }
        public string BondNo { get; set; }
        public string BondHolder { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public string CurrentStatus { get; set; }
        public string LocalAddress { get; set; }
        public string ForeignAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PassportNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public string ChangeStatus { get; set; }
    }
}