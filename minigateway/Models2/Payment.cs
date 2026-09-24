namespace minigateway.Models2
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = "PENDING";

        public string PixCode { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
