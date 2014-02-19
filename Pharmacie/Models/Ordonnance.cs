using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Pharmacie.Models
{
    public class OrdonnanceModel
    {

            [Required]
            public string Name { get; set; }

            [Required]
            public string Email { get; set; }
            
            internal string ordonnanceFile { get; set; }

            public override string ToString()
            {
                return Name + ";" + Email + ";" + ordonnanceFile;
            }

    }
}