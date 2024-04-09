using G4_HotelManagerDEMO.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace G4_HotelManagerDEMO.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail(string emailTo, string recepientName, string subject, string body)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(
                    _configuration["Mailtrap:EmailUsername"],
                    _configuration["MailTrap:EmailFrom"]
                    ));

                message.To.Add(new MailboxAddress(recepientName, emailTo));

                message.Subject = subject;

                var builder = new BodyBuilder();

				var templatePath = ""; //Declarando variable de ruta de plantilla 
				if (body == "Employee")//Si es un empleado
                {
					templatePath = Path.Combine(Directory.GetCurrentDirectory(),
					"EmailTemplates",
					"employeeMail.html"
					);
				}else if (body == "Client")//Si es un cliente
                {
					templatePath = Path.Combine(Directory.GetCurrentDirectory(),
					"EmailTemplates",
					"clientMail.html"
					);
				}

                var templateContent = File.ReadAllText(templatePath);
                templateContent = templateContent.Replace("@Name", recepientName);
                builder.HtmlBody = templateContent;

                message.Body = builder.ToMessageBody();


                using (var client = new SmtpClient())
                {
                    client.Connect(_configuration["Mailtrap:Host"], 
                        int.Parse(_configuration["Mailtrap:Port"]),
                        false);


                    client.Authenticate(_configuration["Mailtrap:Username"], _configuration["Mailtrap:Password"]);

                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
