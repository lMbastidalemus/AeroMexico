//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vuelo
    {
        public string NumeroVuelo { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaSalida { get; set; }
        public Nullable<int> IdPasajero { get; set; }
    
        public virtual Pasajero Pasajero { get; set; }
    }
}
