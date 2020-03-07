using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace EmailTask
{
	class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("Sähköpostin lähetys alkaa ...");
            Console.WriteLine(System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY"));
            Execute().Wait();
            Console.WriteLine("Sähköpostin lähetys on valmis");
        }
        static async Task Execute()
        {
            //var apiKey = "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";  
            var apiKey = System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            Console.WriteLine(apiKey);
            var client = new SendGridClient(apiKey);
            // client.UrlPath = "smtp.sendgrid.net";
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("jonne.kiukas@gmail.com", "Jonne Kiukas"),
                Subject = "Test",
                PlainTextContent = "",
                HtmlContent = "Test"
            };
            msg.AddTo(new EmailAddress("jonne.kiukas@hotmail.com", "Jonne Kiukas"));
            var response = await client.SendEmailAsync(msg);
            // Console.WriteLine($"Palaute: {response}");
        }
    }
}
