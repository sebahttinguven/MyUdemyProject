using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel adminMailViewModel)
        {
            MimeMessage mimeMessage = new MimeMessage();
            //Kimden
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin","sebahattinguven3@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            //Kime
            MailboxAddress mailboxAdressTo = new MailboxAddress("User",adminMailViewModel.ReceiverMail);
            mimeMessage.To.Add(mailboxAdressTo);
            //İçerik
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody= adminMailViewModel.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject=adminMailViewModel.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com",587,false);
            client.Authenticate("sebahattinguven3@gmail.com", "nrhlmjlkqigvxlcn");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
