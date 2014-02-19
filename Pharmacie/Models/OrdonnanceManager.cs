using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Pharmacie.Models
{
    public static class OrdonnanceManager
    {

        public static string filePath = HostingEnvironment.MapPath("~") + @"Ordonnances\";
        public static string configPath = HostingEnvironment.MapPath("~") + @"App_Data\ordonnances.csv";

        public static List<OrdonnanceModel> getAllOrdonnances()
        {
            List<OrdonnanceModel> lstOrdonnances = new List<OrdonnanceModel>();
            using(StreamReader fichierOrdonnances = File.OpenText(configPath))
            {
                string line = fichierOrdonnances.ReadLine();
                while(line != null)
                {
                    lstOrdonnances.Add(new OrdonnanceModel
                    {
                        Name = line.Split(';')[0],
                        Email = line.Split(';')[1],
                        ordonnanceFile = line.Split(';')[2]
                    });
                    line = fichierOrdonnances.ReadLine();
                }
                
            }
            return lstOrdonnances;

        }

        public static void saveOrdonnance(OrdonnanceModel ordonnance)
        {
            File.WriteAllText(configPath,ordonnance.ToString() + Environment.NewLine);
        }
    }
}