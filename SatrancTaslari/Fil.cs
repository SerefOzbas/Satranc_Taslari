using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatrancTaslari
{
    class Fil : SatrancTaslari, IHareketEt
    {
        public void HareketEt(TasAdi adi)
        {
            while (TasindiMi == false)
            {
                Random rnd = new Random();
                int sayi1 = rnd.Next(1, 8);
                int sayi2 = rnd.Next(4);
                switch (sayi2)
                {
                    case 0:
                        if (DikeyKonum + sayi1 < 8 && YatayKonum+sayi1<8)
                        {
                            DikeyKonum += sayi1;
                            YatayKonum += sayi1;
                            TasindiMi = true;
                        }
                        break;
                    case 1:
                        if (DikeyKonum + sayi1 < 8 && YatayKonum - sayi1 >=0)
                        {
                            DikeyKonum += sayi1;
                            YatayKonum -= sayi1;
                            TasindiMi = true;
                        }
                        break;
                    case 2:
                        if (DikeyKonum-sayi1>=0 && YatayKonum - sayi1 >=0)
                        {
                            DikeyKonum -= sayi1;
                            YatayKonum -= sayi1;
                            TasindiMi = true;
                        }
                        break;
                    case 3:
                        if (DikeyKonum - sayi1 >=0 && YatayKonum + sayi1<8)
                        {
                            DikeyKonum -= sayi1;
                            YatayKonum += sayi1;
                            TasindiMi = true;
                        }
                        break;
                }
                
            }
            TasindiMi = false;
        }
    }
}
