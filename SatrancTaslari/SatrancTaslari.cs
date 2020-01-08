using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatrancTaslari
{
   public class SatrancTaslari
    {
        public TasAdi Adi { get; set; }
        public int TasAdedi { get; set; }     
        public int DikeyKonum { get; set; }
        public int YatayKonum { get; set; }
        public bool  TasindiMi { get; set; }
        public int ToplamTasAdedi { get; set; }
    }

   public enum TasAdi
    {
        Kale,
        Fil,
        At,
        Piyon
    }
}
