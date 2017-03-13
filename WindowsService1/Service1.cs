using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public Timer tm;
        public int c;
        public Service1()
        {
            InitializeComponent();
            tm = new Timer();
            tm.Interval = 60000;
            tm.Elapsed += new ElapsedEventHandler(tm_action);
            c = 0;
        }

        private void tm_action(object sender, ElapsedEventArgs e)
        {
            c++;

            MailMessage mail = new MailMessage();
            mail.To.Add("elvictor-003@hotmail.com");
            mail.From = new MailAddress("v.m.e.ll1996@gmail.com", "Correo AutoEnviado");

            mail.Subject = "GMANTEQ - Informe preliminar de Orden de Trabajo Nro: " + c;

            mail.Body = "Correo de prueba N° " + c;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new System.Net.NetworkCredential("v.m.e.ll1996@gmail.com", "P@ssw0rd2016+++");
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnStart(string[] args)
        {
            tm.Enabled = true;
        }

        protected override void OnStop()
        {
        }
    }
}
