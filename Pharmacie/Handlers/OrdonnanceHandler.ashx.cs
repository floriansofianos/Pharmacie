using Pharmacie.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                    OrdonnanceManager.approveOrdonnance(Convert.ToInt32(context.Request.QueryString["id"]));
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