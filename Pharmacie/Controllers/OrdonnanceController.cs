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
            form.ordonnanceFile = file;
            if (!ModelState.IsValid)
            {
                return Content(retValue);
            }

            if (ModelState.IsValid)
            {
                //DO Something
                try
                {
                    retValue = "Your Request for Contact was submitted successfully. We will contact you shortly.";
                }
                catch (Exception)
                {

                    throw;
                }

            }
            return Content(retValue);
        }
    }
}