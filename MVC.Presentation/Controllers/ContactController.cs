namespace MVC.Presentation.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailService _emailService;

        public ContactController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail(EmailViewModel model)
        {
            await _emailService.SendEmailAsync(model.Email, model.Subject, model.Message);
            return Ok("Email sent successfully!");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
