using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFDemo.Models;

namespace WCFDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AthletesService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AthletesService.svc or AthletesService.svc.cs at the Solution Explorer and start debugging.
    public class AthletesService : IAthletesService
    {
        public async Task<AthletesNF> GetRandom()
        {
            //Dovrei creare un controller!
            using(OlympicsContext context = new OlympicsContext())
            {
                Random random = new Random();

                var min = (await context.AthletesNFs.OrderBy(ob => ob.IdAthlete).FirstOrDefaultAsync()).IdAthlete;
                var max = await context.AthletesNFs.MaxAsync(m => m.IdAthlete);

                while (true)
                {
                    int id = random.Next(min, max);
                    var a = await context.AthletesNFs.FirstOrDefaultAsync(q => q.IdAthlete == id);
                    if (a != null) return a;
                }
            }
        }
    }
}
