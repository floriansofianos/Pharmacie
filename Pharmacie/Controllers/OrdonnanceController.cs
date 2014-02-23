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
            string retValue = "Une erreur est survenue lors de l'envoi de vos données. Merci de remplir tous les champs ci-dessous.";
            if (!ModelState.IsValid || file == null)
            {
                TempData.Add("CustomMessageError",retValue);
                return CurrentUmbracoPage();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    form.ordonnanceFile = OrdonnanceManager.filePath + file.FileName;
                    form._isApproved = false;
                    file.SaveAs(OrdonnanceManager.filePath + file.FileName);
                    OrdonnanceManager.saveOrdonnance(form);
                    retValue = "Votre demande est acceptée. Vous recevrez un mail lorsque nous aurons traité votre demande.";
                    TempData.Add("CustomMessage", retValue);
                    return RedirectToCurrentUmbracoPage();
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