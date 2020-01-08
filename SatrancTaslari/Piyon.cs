using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatrancTaslari
{
    class Piyon : SatrancTaslari, IHareketEt
    {
        public int HareketSayisi { get; set; }

        public void HareketEt(TasAdi adi)
        {
            Random rnd = new Random();
            if (HareketSayisi==0)
            {              
                int sayi = rnd.Next(2);
                if (DikeyKonum -2 >=0)
                {
                    switch (sayi)
                    {
                        case 0:
                            DikeyKonum -= 1;
                            break;
                        case 1:
                            DikeyKonum -= 2;
                            break;
                    }
                }
            }
            else
            {
                if (DikeyKonum - 1 >=0 )
                {                   
                  DikeyKonum -= 1;                         
                }
            }

            HareketSayisi++;         
        }
    }
}
