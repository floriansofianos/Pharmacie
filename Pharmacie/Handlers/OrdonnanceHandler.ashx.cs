using Pharmacie.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using SendGridMail;
using System.Net;

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

                    // Setup the email properties.
                    SendGrid myMessage = SendGrid.GetInstance();
                    myMessage.From = new MailAddress("noreply@pharmacie-sofianos.fr");
                    myMessage.AddTo(ordonnance.Email);
                    myMessage.Subject = "Pharmacie Sofianos : Vos médicaments sont prêts";
                    myMessage.Html = "Bonjour " + ordonnance.Name + ", <br /> Votre ordonnance a été traitée. Vous pouvez venir chercher vos médicaments. <br /><br /> Cordialement, <br /><br /> Pharmacie Sofianos <br />135 Rue de Conflans<br />95220 Herblay";
                    var credentials = new NetworkCredential("azure_91d42b559d28f5ec5715199fdd24ccd6@azure.com", "ehztctbb");

                    var transportSMTP = Web.GetInstance(credentials);
                    transportSMTP.Deliver(myMessage);

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