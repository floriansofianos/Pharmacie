using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Pharmacie.Models;
using System.Web;

namespace Pharmacie.Controller
{
    public class OrdonnanceController : Umbraco.Web.Mvc.SurfaceController
    {
        [HttpPost]
        public ActionResult SendMail(OrdonnanceModel form, HttpPostedFileBase file)
        {
            string retValue = "There was an error submitting the form, please try again later.";
            if (!ModelState.IsValid || file == null)
            {
                return Content(retValue);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    form.ordonnanceFile = OrdonnanceManager.filePath + file.FileName;
                    form._isApproved = false;
                    file.SaveAs(OrdonnanceManager.filePath + file.FileName);
                    OrdonnanceManager.saveOrdonnance(form);
                    retValue = "Your Request was submitted successfully. We will contact you shortly.";
                }
                catch (Exception)
                {

                    throw;
                }

            }
            return Content(retValue);
        }

        [HttpGet]
        public ActionResult DeleteOrdonnance(int id)
        {
           
            return Content("");
        }
    }
}