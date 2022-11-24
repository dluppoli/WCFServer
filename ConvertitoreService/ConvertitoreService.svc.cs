using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services.Description;

namespace ConvertitoreService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ConvertitoreService : IConvertitoreService
    {
        Dictionary<string, float> tassiConversione;

        public float Converti(float importo, string da, string a)
        {
            if (da == a) return importo;

            //Converto in euro:  da --> EUR (dividere per i tassi)
            float importoEuro = ConvertiInEuro(importo, da);
            //Converto in a:  EUR --> a (moltiplico per i tassi)
            return Converti(importoEuro, a);
        }

        private float Converti(float importoEuro, string aValuta)
        {
            if (!tassiConversione.ContainsKey(aValuta)) throw new ArgumentException();

            return importoEuro * tassiConversione[aValuta];
        }

        private float ConvertiInEuro(float importo, string daValuta)
        {
            if (!tassiConversione.ContainsKey(daValuta)) throw new ArgumentException();

            return importo / tassiConversione[daValuta];
        }

        public ConvertitoreService()
        {
            tassiConversione = new Dictionary<string, float>();
            tassiConversione.Add("ITL", 1936.27f);
            tassiConversione.Add("DEM", 1.95583f);
            tassiConversione.Add("FRF", 6.55957f);
            tassiConversione.Add("EUR", 1);
        }
    }
}
