using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFDemo.Models;

namespace WCFDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAthletesService" in both code and config file together.
    [ServiceContract]
    public interface IAthletesService
    {
        [OperationContract]
        Task<AthletesNF> GetRandom();
    }
}
