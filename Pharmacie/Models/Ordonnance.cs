using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Pharmacie.Models
{
    public class OrdonnanceModel
    {

            [Required]
            [DisplayName("Nom")]
            public string Name { get; set; }

            [Required]
            [DisplayName("Adresse mail")]
            public string Email { get; set; }
            
            internal string ordonnanceFile { get; set; }

            internal bool _isApproved { get; set; }

            public override string ToString()
            {
                return Name + ";" + Email + ";" + ordonnanceFile + ";" + _isApproved;
            }

            public string getOrdonnanceFileURL()
            {
                return "/Ordonnances/" + Path.GetFileName(ordonnanceFile);
            }

            public bool isApproved()
            {
                return _isApproved;
            }

    }
}