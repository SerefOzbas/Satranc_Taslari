using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatrancTaslari
{
    class At : SatrancTaslari, IHareketEt
    {
        public void HareketEt(TasAdi adi)
        {
            while (TasindiMi == false)
            {
                Random rnd = new Random();              
                int sayi2 = rnd.Next(8);
                switch (sayi2)
                {
                    case 0:
                        if (DikeyKonum + 1 < 8 && YatayKonum + 2 < 8)
                        {
                            DikeyKonum += 1;
                            YatayKonum += 2;
                            TasindiMi = true;
                        }
                        break;
                    case 1:
                        if (DikeyKonum + 1 < 8 && YatayKonum - 2 >= 0)
                        {
                            DikeyKonum += 1;
                            YatayKonum -= 2;
                            TasindiMi = true;
                        }
                        break;
                    case 2:
                        if (DikeyKonum - 1 >= 0 && YatayKonum - 2 > 0)
                        {
                            DikeyKonum -= 1;
                            YatayKonum -= 2;
                            TasindiMi = true;
                        }
                        break;
                    case 3:
                        if (DikeyKonum - 1 >=0 && YatayKonum + 2 < 8)
                        {
                            DikeyKonum -= 1;
                            YatayKonum += 2;
                            TasindiMi = true;
                        }
                        break;
                    case 4:
                        if (DikeyKonum - 2 >=0 && YatayKonum + 1 < 8)
                        {
                            DikeyKonum -= 2;
                            YatayKonum += 1;
                            TasindiMi = true;
                        }
                        break;
                    case 5:
                        if (DikeyKonum + 2 <8 && YatayKonum + 1 < 8)
                        {
                            DikeyKonum += 2;
                            YatayKonum += 1;
                            TasindiMi = true;
                        }
                        break;
                    case 6:
                        if (DikeyKonum -2 >=0 && YatayKonum - 1 >=0)
                        {
                            DikeyKonum -= 2;
                            YatayKonum -= 1;
                            TasindiMi = true;
                        }
                        break;
                    case 7:
                        if (DikeyKonum +2 <8 && YatayKonum -1>=0)
                        {
                            YatayKonum -= 1;
                            DikeyKonum += 2;
                            TasindiMi = true;
                        }
                        break;              
                }
                
            }
            TasindiMi = false;
        }
    }
}
