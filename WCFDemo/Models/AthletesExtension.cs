using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFDemo.Models
{
    [MetadataType(typeof(AthletesNFMetadata))]
    public partial class AthletesNF
    {
    }

    [DataContract]
    public class AthletesNFMetadata
    {
        [DataMember]
        public int IdAthlete { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Sex { get; set; }
        [DataMember]
        public Nullable<short> Height { get; set; }
        [DataMember]
        public Nullable<short> Weight { get; set; }
    }
}