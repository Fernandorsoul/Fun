using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fun.Models
{
    public class Medidas
    {
        public int Id{get;set;}
        public double Peso {get;set;}
        public double Altura { get; set; }
        public double Torax { get ; set ; }
        public double BracoD {get;set;}
        public double BracoE{get;set;}
        public double BracoDFlexionado {get;set;}
        public double BracoEFlexionado{get;set;}
        public double Cintura { get; set; }
        public double Quadril{get;set;}
        public double PernaD {get;set;}
        public double PernaE{get;set;}
        public double PanturilhaD {get;set;}
        public double PanturilhaE{get;set;}

        public int? UsuarioId{get;set;}

        public virtual UsuarioModel Usuario {get;set;}





    }
}
