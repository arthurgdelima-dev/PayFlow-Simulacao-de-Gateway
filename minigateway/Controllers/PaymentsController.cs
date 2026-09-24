
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minigateway.Data;
using minigateway.Models2;

namespace minigateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PaymentsController(AppDbContext context, HttpClient httpClient, IConfiguration configuration)
        {
            _context = context;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest request)
        {
            var payment = new Payment
            {
                Amount = request.Amount,
                Status = "PENDING",
                PixCode = $"PAYFLOW-{Guid.NewGuid()}"
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return Ok(payment);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayment(int id)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        [HttpPost("{id}/confirm")]

        public async Task<IActionResult> ConfirmPayment(int id)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);
         

            if (payment == null)
            {
                return NotFound();
            }

            if (payment.Status == "PENDING")
            {
                payment.Status = "PAID";
                await _context.SaveChangesAsync();
                var webhookUrl = _configuration["Webhook:Url"];
                var webhook = new PaymentWebhook
                {
                    PaymentId = payment.Id,
                    Status = payment.Status,
                    Amount = payment.Amount,
                };
               var response = await _httpClient.PostAsJsonAsync(webhookUrl, webhook);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Webhook enviado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Falha ao enviar webhook.");
                }
                return Ok(payment);

            }
            else
            {
                return BadRequest("Payment is already paid.");
            }

        }
    }

    public class CreatePaymentRequest
    {
        public decimal Amount { get; set; }
    }
}