using Microsoft.AspNetCore.Mvc;
using minigateway.Models2;

namespace minigateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhookController : ControllerBase
    {
        [HttpPost("payment")]
        public IActionResult ReceivePaymentWebhook([FromBody] PaymentWebhook webhook)
        {
            Console.WriteLine($"WEBHOOK RECEBIDO - Pagamento: {webhook.PaymentId} | Status: {webhook.Status} | Valor: {webhook.Amount}");
            return Ok(webhook);
        }
    }
}