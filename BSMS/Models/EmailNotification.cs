using BSMS.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using BSMS.bsms.localhost;
using BSMS.Session;

namespace BSMS.Models
{
    public class EmailNotification
    {
        private const String BSMS_EMAIL = "malagch17223@fpt.edu.vn";
        private const String BSMS_EMAIL_PASS = "Malagch17223";
        
        internal static void ForgetPassword(string email, String hashCode, int userID)
        {
            String ResetPasswordMessage = String.Format("you have requested to reset your password<br />"+
                "Click here <a href='{0}/Authentication/ResetPassword?hash={1}&userID={2}'> Reset Password </a> to reset your password",
                Constant.BASE_URL,  hashCode, userID);
            SendEmail(email, ResetPasswordMessage, "Reset Email");
        }
        internal static void StaffAccountCreated(string email, String hashCode, int userID)
        {
            String ResetPasswordMessage = String.Format("your account have been created change your password for first use <br />" +
                "Click here <a href='http://localhost:52350/Authentication/ResetPassword?hash={0}&userID={1}'> Reset Password </a> to reset your password",
                hashCode, userID);
            SendEmail(email, ResetPasswordMessage, "Reset Email");
        }
        private static void SendEmail(String email, String Message, String title)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(BSMS_EMAIL);
            mail.To.Add(email);
            mail.Subject = title;
            mail.Body = Message;
            mail.IsBodyHtml = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(BSMS_EMAIL, BSMS_EMAIL_PASS);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }

        internal static void AccountDeletedNotification(USER user)
        {
            String message = "Your account have been remove by the administrator <br>" +
                "You might have violated the code of ethics of Online Library System";

            SendEmail(user.EMAIL, message, "Account Deleted");
        }
    }
}