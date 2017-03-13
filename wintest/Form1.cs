using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wintest
{
    public partial class Form1 : Form
    {
        int c;
        public Form1()
        {
            InitializeComponent();
            c = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
    }
}
