namespace PaymentSystemAPI.Models
{
    public class Customer 
    {
        public int Id { get; set; }
        public string NIN { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string TransactionHistory { get; set; }

    }

}
