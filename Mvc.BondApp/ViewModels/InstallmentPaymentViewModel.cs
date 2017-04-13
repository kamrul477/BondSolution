namespace Mvc.BondApp.ViewModels
{
    public class InstallmentPaymentViewModel
    {
        public BONDAPPLICATION Bondapplication { get; set; }
        public BONDINFO Bondinfo { get; set; }
        public TRANSCHD Transchd { get; set; }
        public TRANSMST Transmst { get; set; }
    }
}