namespace minigateway.Models2
{
    public class PaymentWebhook
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
