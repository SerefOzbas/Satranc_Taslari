using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatrancTaslari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Button> Hucreler = new List<Button>();
        List<Button> EklenenTaslar = new List<Button>();
        List<Button> EklenenKaleler = new List<Button>();
        List<Button> EklenenFiller = new List<Button>();
        List<Button> EklenenAtlar = new List<Button>();
        List<Button> EklenenPiyonlar = new List<Button>();
        List<Button> YeniEklenenler = new List<Button>();       
        Kale kale = new Kale();
        Fil fil = new Fil();
        At at = new At();
        Piyon piyon = new Piyon();
        int toplamtassayisi;
        private void Form1_Load(object sender, EventArgs e)
        {

            int i = 0, j = 0, yer = 0;
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {

                    if (i % 2 == 0)
                    {

                        if (yer == 1)
                        {
                            Button btn = new Button();
                            btn.BackColor = Color.Sienna;
                            btn.Size = new Size(55, 55);
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                            btn.Name = i + "." + j;
                            Hucreler.Add(btn);
                            flowLayoutPanel1.Controls.Add(btn);
                            yer = 0;
                        }
                        else
                        {
                            yer++;
                            Button btn = new Button();
                            btn.BackColor = Color.Khaki;
                            btn.Size = new Size(55, 55);
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                            btn.Name = i + "." + j;
                            Hucreler.Add(btn);
                            flowLayoutPanel1.Controls.Add(btn);
                        }

                    }
                    else
                    {
                        if (yer == 0)
                        {
                            Button btn = new Button();
                            btn.BackColor = Color.Sienna;
                            btn.Size = new Size(55, 55);
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                            btn.Name = i + "." + j;
                            Hucreler.Add(btn);
                            flowLayoutPanel1.Controls.Add(btn);
                            yer++;
                        }
                        else
                        {
                            yer = 0;
                            Button btn = new Button();
                            btn.BackColor = Color.Khaki;
                            btn.Size = new Size(55, 55);
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                            btn.Name = i + "." + j;
                            Hucreler.Add(btn);
                            flowLayoutPanel1.Controls.Add(btn);
                        }

                    }
                }
            }
            cmbtas.Items.AddRange(Enum.GetNames(typeof(TasAdi)));
        }

        int kalesayisi = 0;
        int filsayisi = 0;
        int atsayisi = 0;
        int piyonsayisi = 0;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (toplamtassayisi < 64)
            {
                Random rnd = new Random();
                int sayi1 = rnd.Next(64);
                if (Hucreler[sayi1].BackgroundImage == null)
                {
                    for (int i = 0; i < 1; i++)
                    {

                        if (cmbtas.SelectedIndex == 0)
                        {
                            Hucreler[sayi1].BackgroundImage = Image.FromFile(@"C:\Users\serefdm\source\repos\SatrancTaslari\SatrancTaslari\Resources\kale.png");
                            Hucreler[sayi1].Text = "Kale";
                            label2.Text = Hucreler[sayi1].Text;
                            EklenenTaslar.Add(Hucreler[sayi1]);
                            EklenenKaleler.Add(Hucreler[sayi1]);
                            kalesayisi++;
                        }
                        else if (cmbtas.SelectedIndex == 1)
                        {
                            Hucreler[sayi1].BackgroundImage = Image.FromFile(@"C:\Users\serefdm\source\repos\SatrancTaslari\SatrancTaslari\Resources\fil.png");
                            Hucreler[sayi1].Text = "Fil";
                            EklenenTaslar.Add(Hucreler[sayi1]);
                            EklenenFiller.Add(Hucreler[sayi1]);
                            filsayisi++;
                        }
                        else if (cmbtas.SelectedIndex == 2)
                        {
                            Hucreler[sayi1].BackgroundImage = Image.FromFile(@"C:\Users\serefdm\source\repos\SatrancTaslari\SatrancTaslari\Resources\at.png");
                            Hucreler[sayi1].Text = "At";
                            EklenenTaslar.Add(Hucreler[sayi1]);
                            EklenenAtlar.Add(Hucreler[sayi1]);
                            atsayisi++;

                        }
                        else if (cmbtas.SelectedIndex == 3)
                        {
                            Hucreler[sayi1].BackgroundImage = Image.FromFile(@"C:\Users\serefdm\source\repos\SatrancTaslari\SatrancTaslari\Resources\piyon.png");
                            Hucreler[sayi1].Text = "Piyon";
                            EklenenTaslar.Add(Hucreler[sayi1]);
                            EklenenPiyonlar.Add(Hucreler[sayi1]);
                            piyonsayisi++;
                        }
                    }
                    toplamtassayisi++;
                }
                else
                {
                    MessageBox.Show("Aynı hücreye iki taş bırakılmaz, lütfen tekrar deneyin.");
                }

            }
            else
            {
                MessageBox.Show("Hücre sayınız dolmuştur.Daha fazla taş ekleyemezsiniz.");
            }

        }
     
        private void Button2_Click(object sender, EventArgs e)
        {
           

            for (int s = EklenenKaleler.Count-1; s >= 0; s--)
            {
                string[] parcalar = new string[2];
                parcalar = EklenenKaleler[s].Name.Split('.');
                kale.YatayKonum = int.Parse(parcalar[1]);
                kale.DikeyKonum = int.Parse(parcalar[0]);
                kale.HareketEt(TasAdi.Kale);
                string name = kale.DikeyKonum + "." + kale.YatayKonum;
                for (int j = 0; j < Hucreler.Count; j++)
                {
                    if (Hucreler[j].Name == name && Hucreler[j].BackgroundImage == null)
                    {
                        EklenenKaleler[s].BackgroundImage = null;
                        EklenenKaleler[s].Text = "";                        
                        Hucreler[j].BackgroundImage = Image.FromFile(@"C:\Users\serefdm\source\repos\SatrancTaslari\SatrancTaslari\Resources\kale.png");
                        Hucreler[j].Text = "Kale";                      
                       YeniEklenenler.Add(Hucreler[j]);
                        break;
                    }
                    else if (Hucreler[j].Name == name && Hucreler[j].BackgroundImage != null)
                    {
                        YeniEklenenler.Add(EklenenKaleler[s]);
                    }
                }
                EklenenKaleler.Remove(EklenenKaleler[s]);                              
            }
            EklenenKaleler.AddRange(YeniEklenenler);
            YeniEklenenler.Clear();


            for (int s = EklenenFiller.Count - 1; s >= 0; s--)
            {
                string[] parcalar = new string[2];
                parcalar = EklenenFiller[s].Name.Split('.');
                fil.YatayKonum = int.Parse(parcalar[1]);
                fil.DikeyKonum = int.Parse(parcalar[0]);
                fil.HareketEt(TasAdi.Fil);
                string name = fil.DikeyKonum + "." + fil.YatayKonum;
                for (int j = 0; j < Hucreler.Count; j++)
                {
                    if (Hucreler[j].Name == name && Hucreler[j].BackgroundImage == null)
                    {
                        EklenenFiller[s].BackgroundImage = null;
                        EklenenFiller[s].Text = "";
                        Hucreler[j].BackgroundImage = Image.FromFile(@"C:\Users\serefdm\source\repos\SatrancTaslari\SatrancTaslari\Resources\fil.png");
                        Hucreler[j].Text = "Fil";
                        YeniEklenenler.Add(Hucreler[j]);
                        break;
                    }
                    else if (Hucreler[j].Name == name && Hucreler[j].BackgroundImage != null)
                    {
                        YeniEklenenler.Add(EklenenFiller[s]);
                    }
                }
                EklenenFiller.Remove(EklenenFiller[s]);
            }
            EklenenFiller.AddRange(YeniEklenenler);
            YeniEklenenler.Clear();

            for (int s = EklenenAtlar.Count - 1; s >= 0; s--)
            {
                string[] parcalar = new string[2];
                parcalar = EklenenAtlar[s].Name.Split('.');
                at.YatayKonum = int.Parse(parcalar[1]);
                at.DikeyKonum = int.Parse(parcalar[0]);
                at.HareketEt(TasAdi.At);
                string name = at.DikeyKonum + "." + at.YatayKonum;
                for (int j = 0; j < Hucreler.Count; j++)
                {
                    if (Hucreler[j].Name == name && Hucreler[j].BackgroundImage == null)
                    {
                        EklenenAtlar[s].BackgroundImage = null;
                        EklenenAtlar[s].Text = "";
                        Hucreler[j].BackgroundImage = Image.FromFile(@"C:\Users\serefdm\source\repos\SatrancTaslari\SatrancTaslari\Resources\at.png");
                        Hucreler[j].Text = "At";
                        YeniEklenenler.Add(Hucreler[j]);
                        break;
                    }
                    else if (Hucreler[j].Name == name && Hucreler[j].BackgroundImage != null)
                    {
                        YeniEklenenler.Add(EklenenAtlar[s]);
                    }
                }
                EklenenAtlar.Remove(EklenenAtlar[s]);
            }
            EklenenAtlar.AddRange(YeniEklenenler);
            YeniEklenenler.Clear();

            for (int s = EklenenPiyonlar.Count - 1; s >= 0; s--)
            {
                string[] parcalar = new string[2];
                parcalar = EklenenPiyonlar[s].Name.Split('.');
                piyon.YatayKonum = int.Parse(parcalar[1]);
                piyon.DikeyKonum = int.Parse(parcalar[0]);
                piyon.HareketEt(TasAdi.Piyon);
                string name = piyon.DikeyKonum + "." + piyon.YatayKonum;
                for (int j = 0; j < Hucreler.Count; j++)
                {
                    if (Hucreler[j].Name == name && Hucreler[j].BackgroundImage == null)
                    {
                        EklenenPiyonlar[s].BackgroundImage = null;
                        EklenenPiyonlar[s].Text = "";
                        Hucreler[j].BackgroundImage = Image.FromFile(@"C:\Users\serefdm\source\repos\SatrancTaslari\SatrancTaslari\Resources\piyon.png");
                        Hucreler[j].Text = "Piyon";
                        YeniEklenenler.Add(Hucreler[j]);
                        break;
                    }
                    else if (Hucreler[j].Name == name && Hucreler[j].BackgroundImage != null)
                    {
                        YeniEklenenler.Add(EklenenPiyonlar[s]);
                    }
                }
                EklenenPiyonlar.Remove(EklenenPiyonlar[s]);
            }
            EklenenPiyonlar.AddRange(YeniEklenenler);
            YeniEklenenler.Clear();
          

        }
    }
}