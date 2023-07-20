using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fun.Models
{
    public class Dobras
    {
        public int Id { get; set;}
        public double Tricipital { get; set;}
        public double Subescapular { get; set;}
        public double Suprailiaca{ get; set;}
        public double Abdominal { get; set; }
        public double Coxa { get; set;}
        public int MedidasId { get; set;}

        public virtual Medidas Medidas{get;set;}

    }
}
