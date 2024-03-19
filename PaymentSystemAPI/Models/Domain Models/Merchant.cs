namespace PaymentSystemAPI.Models
{
    public class Merchant
    {
        public int Id { get; set; }
        public string BusinessIdNumber { get; set; }
        public string BusinessName { get; set; }
        public string FirstName { get; set; }
        public string SurName{ get; set; }
        public DateTime DateOfEstablishment { get; set; }
        public string PhoneNumber {  get; set; }
        public double AverageTransactionVolume { get; set; }

    }
}
