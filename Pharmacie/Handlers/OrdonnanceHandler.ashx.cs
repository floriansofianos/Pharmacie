using Pharmacie.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Pharmacie.Views
{
    /// <summary>
    /// Description résumée de OrdonnanceHandler
    /// </summary>
    public class OrdonnanceHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            switch (context.Request.QueryString["cas"])
            {
                case "deleteOrdonnance":
                    OrdonnanceManager.deleteOrdonnance(Convert.ToInt32(context.Request.QueryString["id"]));
                    File.Delete(OrdonnanceManager.getAllOrdonnances()[Convert.ToInt32(context.Request.QueryString["id"])].ordonnanceFile);
                    break;
                case "approveOrdonnance":
                    OrdonnanceModel ordonnance = OrdonnanceManager.getAllOrdonnances()[Convert.ToInt32(context.Request.QueryString["id"])];
                    OrdonnanceManager.approveOrdonnance(Convert.ToInt32(context.Request.QueryString["id"]));
                    SmtpClient smtp = new SmtpClient("smtp.sendgrid.net");
                    smtp.Credentials = new System.Net.NetworkCredential("fsofianos", "Herblay=95");
                    smtp.Send("noreply@gmail.com", ordonnance.Email, "Pharmacie Sofianos : Vos médicaments sont prêts", "Bonjour " + ordonnance.Name + ", <br /> Votre ordonnance a été traitée. Vous pouvez venir chercher vos médicaments. <br /><br /> Cordialement, <br /><br /> Pharmacie Sofianos <br />135 Rue de Conflans<br />95220 Herblay");
                    break;
                default:
                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}