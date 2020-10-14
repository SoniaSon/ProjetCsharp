using ProjetCSharp.NEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCSharp.Service
{
    public class MailService
    {
        private readonly Context context;

        public MailService(Context context)
        {
            this.context = context;
        }
        /// Envoyer un email
        public void SendMail(string smtp, string from, string to, string obj, string msg, string username, string password, string msg1, string text, string text1)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);

                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = obj;
                mail.Body = msg;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(username, password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }

        internal void SendMail(string text1, string text2, string mail, string obj, string msg, string text3, string text4)
        {
            throw new NotImplementedException();
        }
    }
}
