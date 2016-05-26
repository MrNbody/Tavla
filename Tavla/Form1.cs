using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Tavla
{
    public partial class Form1 : Form
    {
        bool suruklenme_durumu;//taşın sürüklenme durumu
        Taslar secili_tas;//seçtiğimiz taş
        kolon[] kolonlar,bkolon,skolon;//taşların listesini tutmak için
        Point position;
        Panel[] paneller,bpanel,spanel;//taşların konumlarını ayarlamak için
        kolon tasoncekikonum;//taşın önceki konumu
        Panel tasoncekiko;
        int zar1, zar2, hamle1, hamle2, toplam1 = 0, toplam2 = 0, ssayi = 0, bsayi = 0;
        int ilki;
        Boolean zar1oyna = true, zar2oyna = true, çift1, çift2, oyuncu1 = true, oyuncu2 = true, btopla = false, stopla = false;

        private void button2_Click(object sender, EventArgs e)//oynama sırasını rakibe veriyoruz
        {
            if (toplam1 != toplam2)
            {
                if (oyuncu1)
                {
                    oyuncu1 = false;
                    oyuncu2 = true;
                }
                else
                {
                    oyuncu2 = false;
                    oyuncu1 = true;
                }
            }
            else return;

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            paneller = new Panel[24];// paneller ve kolonlar dizilerimizi oluşturduk
            kolonlar = new kolon[24];
            bpanel = new Panel[2];
            spanel = new Panel[2];
            bkolon = new kolon[2];
            skolon = new kolon[2];
            Panel p1,pb,ps;
            suruklenme_durumu = false;
            int px=47;
            int px2 = 846;
            for (int i = 0; i < 2; i++)// boyutları ve konumları
            {
                if (i==0)
                {
                    bkolon[i] = new kolon();// kolon oluşturduk
                    
                    pb = new Panel();// panel oluşturduk
                    pb.Width = 40;
                    pb.Height = 40;
                    pb.Top = 250;
                    pb.Left = 382;
                    bpanel[i] = pb;

                    skolon[i] = new kolon();
                    ps = new Panel();
                    ps.Width = 40;
                    ps.Height = 40;
                    ps.Top = 250;
                    ps.Left = 511;
                    spanel[i] = ps;
                }
                else
                {
                    bkolon[i] = new kolon();
                    pb = new Panel();
                    pb.Width = 40;
                    pb.Height = 40;
                    pb.Top = 250;
                    pb.Left = 47;
                    bpanel[i] = pb;

                    skolon[i] = new kolon();
                    ps = new Panel();
                    ps.Width = 40;
                    ps.Height = 40;
                    ps.Top = 250;
                    ps.Left = 846;
                    spanel[i] = ps;
                }
            }
            for (int i = 0; i < 24; i++)
            {
                kolonlar[i] = new kolon();
            }
            for (int i = 0; i < 24; i++)
            {
                if (i<12)
                {
                    if (i==6)
                    {
                        px2-=62;
                    }
                    p1 = new Panel();
                    p1.Width = 60;
                    p1.Height = 200;
                    p1.Left = px2;
                    p1.Top = 327;
                    paneller[i] = p1;
                    px2 -= 67;
                }
                else
                {
                    if (i==18)
                    {
                        px += 62;
                    }
                    p1 = new Panel();
                    p1.Width = 60;
                    p1.Height = 200;
                    p1.Left = px;
                    p1.Top = 20;
                    paneller[i] = p1;
                    px += 67;
                }
            }
            for (int i = 0; i < 5; i++)//Taşlarımızı oluşturuyoruz ve listemize ekliyoruz
            {
                Taslar tas;
                tas = new SiyahTas();// tas oluşturdum
                tas.Top = i * 40;
                properti(tas, paneller[12]);
                kolonlar[12].ekle(tas);
            }

            for (int i = 0; i < 3; i++)
            {
                Taslar tas;
                tas = new BeyazTas();
                tas.Top = i * 40;
                properti(tas, paneller[16]);
                kolonlar[16].ekle(tas);
            }

            for (int i = 0; i < 5; i++)
            {
                Taslar tas;
                tas = new BeyazTas();
                tas.Top = i * 40;
                properti(tas, paneller[18]);
                kolonlar[18].ekle(tas);
            }

            for (int i = 0; i < 2; i++)
            {
                Taslar tas;
                tas = new SiyahTas();
                tas.Top = i * 40;
                properti(tas, paneller[23]);
                kolonlar[23].ekle(tas);
            }

            for (int i = 0; i < 5; i++)
            {
                Taslar tas;
                tas = new BeyazTas();
                tas.Top = paneller[11].Top + paneller[11].Height - i * 40;
                properti(tas, paneller[11]);
                kolonlar[11].ekle(tas);
            }

            for (int i = 0; i < 3; i++)
            {
                Taslar tas;
                tas = new SiyahTas();
                tas.Top = paneller[7].Top + paneller[7].Height - i * 40;
                properti(tas, paneller[7]);
                kolonlar[7].ekle(tas);
            }

            for (int i = 0; i < 5; i++)
            {
                Taslar tas;
                tas = new SiyahTas();
                tas.Top = paneller[5].Top + paneller[5].Height - i * 40;
                properti(tas, paneller[5]);
                kolonlar[5].ekle(tas);
            }

            for (int i = 0; i < 2; i++)
            {
                Taslar tas;
                tas = new BeyazTas();
                tas.Top = paneller[0].Top+ paneller[0].Height- i * 40;
                properti(tas, paneller[0]);
                kolonlar[0].ekle(tas);
            }
            for (int i = 0; i < 24; i++)// taşlarımızı zemine ekliyoruz
            {
                
                    int top = 20;
                    if (i<12)
                    {
                        top = 490;
                    }
                    for (int k = 0; k < kolonlar[i].list.Count; k++)
                    {
                        kolonlar[i].list[k].Top = top;
                        if (k<4)
                        {
                           if (i<12)
                           {
                                top -= 40;
                            }
                            else
                            {
                                top += 40;
                            }
                        }
                        zemin.Controls.Add(kolonlar[i].list[k]);
                    }
                
            }

        }
        void properti(Taslar t,Panel p)//taşlarımıza hareket kabiliyeti ekliyoruz
        {
            t.Left = p.Left;
            t.MouseDown += new MouseEventHandler(Mouse_Down);
            t.MouseMove += new MouseEventHandler(Mouse_Move);
            t.MouseUp += new MouseEventHandler(Mouse_Up);
        }
        void Mouse_Down(object sender, MouseEventArgs e)// mouse tıklanma anı
        {
            secili_tas = (Taslar)sender as Taslar;
            if (oyuncu1&&secili_tas.GetType()!=typeof(SiyahTas))// siyahın sırası ise sadece siyah taşlar hareket eder
            {
                return;
            }
            else if (oyuncu2&&secili_tas.GetType()!=typeof(BeyazTas))// beyazın sırası ise sadece beyaz hareket eder
            {
                return;
            }
            suruklenme_durumu = true;
            secili_tas.Cursor = Cursors.SizeAll;
            position = e.Location;

            Rectangle mouse = new Rectangle(secili_tas.Left, secili_tas.Top, 2, 2);// imlec için 2*2 kare oluşturduk
            for (int i = 0; i < 24; i++)// hangi panele tıkladığımızı kontrol edip, seçtiğimiz taşı listeden çıkarıyoruz
            {
                Rectangle panel = new Rectangle(paneller[i].Left, paneller[i].Top, paneller[i].Width, paneller[i].Height);// panel için dikdörtgen oluşturduk
                if (mouse.IntersectsWith(panel))// mouse imleci ile tüm panellerin kesişimlerini kontrol ediyoruz, kesişiyor ise true değer döner
                {
                    ilki = i;
                    kolonlar[i].cikar(secili_tas);// taşı listeden çıkardık
                    tasoncekikonum = kolonlar[i];// önceki konumunu lazım olabileceğinden saklıyoruz
                    tasoncekiko = paneller[i];// aynı şekilde önceki konumunu saklıyoruz
                    break;// for dan çıkıyoruz
                }
                else if (i==23)// 24 panelden hiç biri ile kesişim yok ise, kırılan taşların bulunduğu panel ile kesişimi kontrol edeceğiz 
                {
                    Rectangle panelb = new Rectangle(bpanel[0].Left, bpanel[0].Top, bpanel[0].Width, bpanel[0].Height);//kırık taşları tuttuğumuz 
                    Rectangle panels = new Rectangle(spanel[0].Left, spanel[0].Top, spanel[0].Width, spanel[0].Height);//paneller için dikdörtgernler oluşturduk
                    if (mouse.IntersectsWith(panelb))// kesişimlerini kontrol ettik
                    {
                        ilki = -1;
                        bkolon[0].cikar(secili_tas);// kırık siyah taşları tuttuğumuz panel ile kesişim var ise, taşı listeden çıkarıyoruz
                        tasoncekikonum = bkolon[0];// önceki konumu yine saklıyoruz
                        tasoncekiko = bpanel[0];
                        break;
                    }
                    else if (mouse.IntersectsWith(panels))
                    {
                        ilki = 24;
                        skolon[0].cikar(secili_tas);// aynı şekilde kırık beyaz taşları ile kesişim var ise taşı isteden çıkarıyoruz
                        tasoncekikonum = skolon[0];// önceki konum yine saklıyoruz
                        tasoncekiko = spanel[0];
                        break;
                    }
                }
            }
        }

        void Mouse_Move(object sender, MouseEventArgs e)// taşın sürükleniyor olduğu durum, yani mouse tuşunu basılı tuttuğumuz an
        {
            if (suruklenme_durumu)
            {
                secili_tas.Left = e.X + secili_tas.Left - (position.X);// konum sürekli değişiyor, mouse imlecine göre
                secili_tas.Top = e.Y + secili_tas.Top - (position.Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)// zar atmak için
        {
            if (toplam1==toplam2)// başlangıçta oyuna birinci başlayacak oyuncuyu seçmek için
            {
                    Random rast = new Random();
                    zar1 = rast.Next(1, 7);
                    toplam1 = zar1;
                    zar2 = rast.Next(1, 7);
                    toplam2 = zar2;
                    MessageBox.Show("Beyazın puanı: "+toplam1+" | Siyahın puanı: "+toplam2);
                if (toplam1==toplam2)
                    MessageBox.Show("Tekrar zar atın");// eşit zar atarlar ise , tekrar zar atacaklar
                else if (toplam1 < toplam2)
                {
                    MessageBox.Show("1. Oyuncu Siyah");// büyük zarı atan birinci
                    oyuncu2 = false;
                }
                else
                {
                    MessageBox.Show("1.Oyuncu Beyaz");
                    oyuncu1 = false;
                }
            }
            else// birinciyi seçtikten sonra atılan zarlar, oyunda kaç hamle oynayacağımızı belirlemek için atılır
            {
                zar1oyna = false;// zarı oynamadığımızı göstermek için
                zar2oyna = false;
                Random rast = new Random();
                zar1 = rast.Next(1, 7);
                zar2 = rast.Next(1, 7);
                if (zar1 == zar2)// zarlar aynı gelirse, çift oynamamız gerektiğini bilmek için, bazı değişkenlerimizi var
                {
                    if (!oyuncu2)
                    {
                        çift1 = true;// çift oynamamız gerekiyor
                        çift2 = true;// çift oynamamız gerekiyor
                        label2.Text=("Siyahın zarı ("+zar1 + "," + zar2+") çift geldi");
                    }
                    else
                    {
                        çift1 = true;// çift oynamamız gerekiyor
                        çift2 = true;// çift oynamamız gerekiyor
                        label1.Text = ("Beyazın zarı (" + zar1 + "," + zar2 + ") çift geldi");
                    }
                }
                else
                {
                    if (!oyuncu2)
                    {
                        label2.Text = ("Siyahın zarı (" + zar1 + "," + zar2 + ")");
                    }
                    else
                    {
                        label1.Text = ("Beyazın zarı (" + zar1 + "," + zar2 + ")");
                    }
                }
            }
        }

        void Mouse_Up(object sender, MouseEventArgs e)// taşın bıraktığımız an, yani mouse tuşunu bıraktığımız an
        {
            if (suruklenme_durumu)// sürükleme durumunu kontrol ediyoruz,
            {
                Rectangle r1 = new Rectangle(secili_tas.Left, secili_tas.Top, secili_tas.Width, secili_tas.Height);// taşımızı ve panellerimizin kesişimlerini
                Rectangle rs = new Rectangle(spanel[1].Left, spanel[1].Top, spanel[1].Width, spanel[1].Height);// kontrol etmek için
                Rectangle rb = new Rectangle(bpanel[1].Left, bpanel[1].Top, bpanel[1].Width, bpanel[1].Height);// dikdörtgenler oluşturuyoruz

                for (int i = 0; i < 24; i++)// her panele göz atmak için, dolaşıyoruz
                    {
                        Rectangle r2 = new Rectangle(paneller[i].Left, paneller[i].Top, paneller[i].Width, paneller[i].Height);// paneller için dikdörtgen
                        int adet = kolonlar[i].list.Count;// panellerdeki taş sayısını tutmak için
                        if (r1.IntersectsWith(r2))// taş ve panel kesişimi kontrol ediyoruz
                        {
                            if (adet > 4)// bir panelde üst üste en fazla 5 tane taş olabilir
                            {
                                adet = 4;
                            }
                                if (secili_tas.GetType() == typeof(BeyazTas))// seçtiğimiz taşın tipini kontrol ediyoruz, beyaz mı siyah mı ?
                                {
                                    hamle1 = ilki + zar1;// hamle hakkımızı hesaplıyoruz
                                    hamle2 = ilki + zar2;
                                }
                                else
                                {
                                    hamle1 = ilki - zar1;// hamle hakkımızı hesaplıyoruz
                                    hamle2 = ilki - zar2;
                                }
                                if ((i == hamle1) && zar1oyna == false)// zar1oyna= zar oynamaya hakkımız olup olmadığımız bilgisini tutuyor
                                {// hamle hakkımız, taşı bıraktığımız panel ile kesişiyor mu, yani taşı o noktaya oynayabiliyor muyuz diye kontrol ediyoruz
                                    if (i < 12)// taşı alt panele bırakmışsak, farklı bir şekilde konumlandırıyoruz
                                    {
                                        secili_tas.Top = paneller[i].Top + paneller[i].Height - secili_tas.Height - adet * secili_tas.Height;
                                    }
                                    else// taşı üst panele bırakmışsak farklı bir şekilde konumandırıyoruz
                                    {
                                        secili_tas.Top = paneller[i].Top + adet * secili_tas.Height;
                                    }
                                    secili_tas.Left = paneller[i].Left;

                                    if(kolonlar[i].tasGonder(secili_tas, i, tasoncekikonum,skolon[0],bkolon[0]))
                                    {// taşı konumlandırdıktan sonra, listeye ekleme durumunu kontrol ediyoru, duruma göre taşı listeye ekliyoruz
                                        if (çift1 == true)// oynadığımız hamleye göre, hamle hakkımızı yeniden hesaplıyoruz
                                        {
                                            zar1oyna = false;
                                            çift1 = false;
                                        }
                                        else
                                        {
                                            zar1oyna = true;
                                        }
                                    }

                                    break;// taş hareketi, konumlandırması, listeye eklemesi bittikten sonra, for döngüsünden çıkıyoruz
                                }
                                else if ((i == hamle2) && zar2oyna == false)
                                {// aynı şekilde hamle hakkımıza göre taşı konumlandırmayı kontrol ediyoruz
                                    if (i < 12)
                                    {
                                        secili_tas.Top = paneller[i].Top + paneller[i].Height - secili_tas.Height - adet * secili_tas.Height;
                                    }
                                    else
                                    {
                                        secili_tas.Top = paneller[i].Top + adet * secili_tas.Height;
                                    }
                                    secili_tas.Left = paneller[i].Left;

                                    if(kolonlar[i].tasGonder(secili_tas, i, tasoncekikonum,skolon[0],bkolon[0]))
                                    {
                                        if (çift2 == true)
                                        {
                                            zar2oyna = false;
                                            çift2 = false;
                                        }
                                        else
                                        {
                                            zar2oyna = true;
                                        }
                                    }

                                    break;
                                }
                                else// taş yerleştirmeye çalıştığımız nokta için hamle hakkımız yetmiyor veya tutmuyor ise
                                {// taş eski konumuna geri yerleşir
                                    if (i < 12)
                                    {
                                        secili_tas.Top = tasoncekiko.Top + tasoncekiko.Height - secili_tas.Height - adet * secili_tas.Height;
                                    }
                                    else
                                    {
                                        secili_tas.Top = tasoncekiko.Top + adet * secili_tas.Height;
                                    }
                                    secili_tas.Left = tasoncekiko.Left;
                                    tasoncekikonum.ekle(secili_tas);// önceki listesine de geri eklenir
                                    break;// taş ekleme işlemi bittikten sonra for döngüsünden çıkılır
                                }
                        }
                        else if (r1.IntersectsWith(rs)&&stopla==true)// eğer tüm siyah taşlar siyah kalede ise,
                        {//   taşları toplama işlemini kontrol ediyoruz, taşları topladığımız panel ile taşın kesişimini kontro ediyoruz
                            if ((ilki+1) <= zar1 && zar1oyna == false)// hamle hakkımız yetiyor ise taşın yerleşmesine izin veriyoruz / taşı topluyoruz
                            {
                                secili_tas.Top = spanel[1].Top;// taşı yei konumunu ayarlıyoruz
                                secili_tas.Left = spanel[1].Left;
                                skolon[1].ekle(secili_tas);// taşı, taşları topladığımız listeye ekliyoruz
                                if (çift1 == true)
                                {
                                    zar1oyna = false;// oynadığımız hamleye göre, hamle hakkımızı tekrar düzenliyoruz
                                    çift1 = false;
                                }
                                else
                                {
                                    zar1oyna = true;
                                }
                                break;
                            }
                            else if((ilki + 1) <= zar2 && zar2oyna == false)// aynı şekilde hamle hakkımız yetiyor ise taşı topluyoruz
                            {
                                secili_tas.Top = spanel[1].Top;
                                secili_tas.Left = spanel[1].Left;
                                skolon[1].ekle(secili_tas);
                                if (çift2 == true)
                                {
                                    zar2oyna = false;
                                    çift2 = false;
                                }
                                else
                                {
                                    zar2oyna = true;
                                }
                                break;
                            }
                            else // hamle hakkımız yetmiyor ise taşı eski yerine geri yerleştiriyoruz
                            {
                                if (i < 12)// 
                                {
                                    secili_tas.Top = tasoncekiko.Top + tasoncekiko.Height - secili_tas.Height - adet * secili_tas.Height;
                                }
                                else
                                {
                                    secili_tas.Top = tasoncekiko.Top + adet * secili_tas.Height;
                                }
                                secili_tas.Left = tasoncekiko.Left;
                                tasoncekikonum.ekle(secili_tas);
                                break;
                            }
                    }
                        else if (r1.IntersectsWith(rb)&&btopla==true)// aynı şekilde bu sefer beyaz taşların hepsi beyaz kalede ise
                         {//taşları toplama işlemini kontrol ediyoruz, taşları topladığımız panel ile taşın kesişimini kontro ediyoruz
                        if ((ilki + zar1) >= 24 && zar1oyna == false)
                            {
                                secili_tas.Top = bpanel[1].Top;
                                secili_tas.Left = bpanel[1].Left;
                                bkolon[1].ekle(secili_tas);
                                if (çift1 == true)
                                {
                                    zar1oyna = false;
                                    çift1 = false;
                                }
                                else
                                {
                                    zar1oyna = true;
                                }
                                break;
                            }
                            else if ((ilki + zar2) >= 24 && zar2oyna == false)
                            {
                                secili_tas.Top = bpanel[1].Top;
                                secili_tas.Left = bpanel[1].Left;
                                bkolon[1].ekle(secili_tas);
                                if (çift2 == true)
                                {
                                    zar2oyna = false;
                                    çift2 = false;
                                }
                                else
                                {
                                    zar2oyna = true;
                                }
                                break;
                            }
                            else// hamle hakkımız yetmiyor ise taşı eski yerine yereştiriyoruz
                            {
                                if (i < 12)
                                {
                                    secili_tas.Top = tasoncekiko.Top + tasoncekiko.Height - secili_tas.Height - adet * secili_tas.Height;
                                }
                                else
                                {
                                    secili_tas.Top = tasoncekiko.Top + adet * secili_tas.Height;
                                }
                                secili_tas.Left = tasoncekiko.Left;
                                tasoncekikonum.ekle(secili_tas);
                                break;
                            }
                    }
                        else if (i == 23)// taşı bıraktığımız yer hiç bir panel ile kesişmiyor ise, eski yerine yereştiriyoruz
                        {
                            if (i < 12)
                            {
                                secili_tas.Top = tasoncekiko.Top + tasoncekiko.Height - secili_tas.Height - adet * secili_tas.Height;
                            }
                            else
                            {
                                secili_tas.Top = tasoncekiko.Top + adet * secili_tas.Height;
                            }
                            secili_tas.Left = tasoncekiko.Left;
                            tasoncekikonum.ekle(secili_tas);
                            break;
                        }
                    }



                suruklenme_durumu = false;

                secili_tas.Cursor = Cursors.Default;

            }
            ssayi = 0;
            for (int i = 0; i < 6; i++)// siyah kaledeki taş sayısını kontrol ediyoruz, eğer 15 tane ise,
            {// yani tüm siyah taşlar siyah kalede ise, taşları toplayabimemize izin veriyoruz
                if (kolonlar[i].list.Count!=0&&kolonlar[i].list[0].GetType()==typeof(SiyahTas))
                    ssayi+=kolonlar[i].list.Count;
                if (ssayi==15)
                {
                    stopla = true;//siyah taşlarımı toplayıp toplayamayacağımızı belirler
                }
            }
            bsayi = 0;
            for (int i = 18; i < 24; i++)// siyah kaledeki taş sayısını kontrol ediyoruz, eğer 15 tane ise,
            {// yani tüm siyah taşlar siyah kalede ise, taşları toplayabimemize izin veriyoruz
                if (kolonlar[i].list.Count != 0 && kolonlar[i].list[0].GetType() == typeof(BeyazTas))
                    bsayi += kolonlar[i].list.Count;
                if (bsayi == 15)
                {
                    btopla = true;//beyaz taşlarımı toplayıp toplayamayacağımızı belirler
                }
            }
            if (skolon[1].list.Count==15)// bütün siyah taşlar toplanmışsa oyun biter
            {
                MessageBox.Show("Tebrikler Siyah Taş Kazandı");
                this.Close();
            }
            if (bkolon[1].list.Count == 15)// bütün beyaz taşlar toplanmışsa oyun biter
            {
                MessageBox.Show("Tebrikler Beyaz Taş Kazandı");
                this.Close();
            }
        }

        private void zemin_Paint(object sender, PaintEventArgs e)//listedeki taşları yeniden yazdırıyor, yenileme
        {
            for (int i = 0; i < 24; i++)
            {
                    int adet = kolonlar[i].list.Count;
                    for (int k = 0; k < kolonlar[i].list.Count; k++)
                    {
                        adet = k;
                        if (adet > 4)
                        {
                            adet = 4;
                        }
                        if (i < 12)
                        {
                            adet++;
                            kolonlar[i].list[k].Top =paneller[i].Top + paneller[i].Height - kolonlar[i].list[k].Height*(adet);
                        }
                        else
                        {
                            kolonlar[i].list[k].Top = paneller[i].Top + kolonlar[i].list[k].Height*(adet);
                        }
                        kolonlar[i].list[k].Left = paneller[i].Left;
                    }
            }
        }
    }

    public class kolon// kolon diye bir sınıfımız var, içinde liste tutuyoruz, listeler içinde de taşlarımızı tutuyoruz
    {
        public List<Taslar> list = new List<Taslar>();// listemiz, her nesne için farklı bir liste
       
        public void ekle(Taslar tas)// listeye taş ekleme
        {
            list.Add(tas);
        }
        public Boolean tasGonder(Taslar tas ,int satir,kolon onceki,kolon skolon,kolon bkolon)
        {// listeye taş eklemeyi kontrol etme metodu, uygunluğuna göre farklı şekilde listeye taş ekleniyor veya çıkarılıyor
            if (list.Count == 1)// taşı yerleştirmek istediğimiz listede sadece 1 taş var ise
            {
                if (list[0].GetType() != tas.GetType())// ve o taş seçtiğimiz taş ile farklı tipte ise(beyaz ve siyah)
                {
                    if (list[0].GetType() == typeof(BeyazTas))// listedeki 1 tek taş olan taş beyaz ise
                    {
                        list[0].Top = 250;//taşın konumunu değiştiriyoruz
                        list[0].Left = 382;//
                        list.Add(tas);// seçili taşı istediğimiz isteye ekiyoruz
                        bkolon.list.Add(list[0]);// tek olan taşı beyaz kırık taşlar listesine ekliyoruz
                        list.Remove(list[0]);
                    }
                    else if(list[0].GetType() == typeof(SiyahTas))// lsitedeki tek taş siyah ise
                    {
                        list[0].Top = 250;//taşın konumunu değiştiriyoruz
                        list[0].Left = 511;//
                        list.Add(tas);// seçili taşı istediğimiz isteye ekiyoruz
                        skolon.list.Add(list[0]);// tek olan taşı siyah kırık taşlar listesine ekliyoruz
                        list.Remove(list[0]);
                    }
                    //list.Remove(list[0]);// tek olan taşı eski listesinden siliyoruz
                    return true;// taş kırma işemini yaptıktan sonra, bu metoddan çıkıyoruz, ve seçii taşı yerleştirdiğimizi göstermek için geriye true değeri dönderiyoruz
                }
            }
            else
            {
                if (list.Count > 0 && list[0].GetType() != tas.GetType())
                {// taşı yerleştirmek istediğimiz listede 1 den fazla taş var ise ve seçili taş ile farklı tipte ise
                    onceki.ekle(tas);// taşın buraya yerleştiremeyiz, bu yüzden taşı eski konumuna geri yerleştiriyoruz
                    return false;// taşın yeri değişmediği ve bunu göstermek için geriye false değer döndürüyoruz
                }
            }
                ekle(tas);// bunların haricinde seçili taşı istediğimiz yere yerleştiriyoruz
                return true;// yerleştirdiğimiz için geriye true değer dönderiyoruz
        }
        public void cikar(Taslar tas)// listeden taş çıkarma metodu
        {
            list.Remove(tas);
        }
    }
}
