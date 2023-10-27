using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OTTER
{
    public partial class BGL
    {
        #region inicijalizacija
        private List<Sprite> lista = new List<Sprite>();
        private int indeks;
        private int potez = 15;
        private int[] niz = new int[2];
        private delegate int[] ProvjeraDelegate(List<Sprite> sprites, int index);

        private void SetupGame()
        {
            //1. setup stage
            SetStageTitle("PMF");
            //setBackgroundColor(Color.WhiteSmoke);            
            setBackgroundPicture("backgrounds\\pijesak.jpg");
            //none, tile, stretch, center, zoom
            setPictureLayout("stretch");
            //2. add sprites
            for (int i = 0; i < 8; i++)
            {
                Legionari l = new Legionari(i);
                l.AddCostumes("sprites\\SelectedLegionary.jpg");
                lista.Add(l);
            }
            for (int i = 8; i < 10; i++)
            {
                Konjanici k = new Konjanici(i);
                k.AddCostumes("sprites\\SelectedHorseman.jpg");
                lista.Add(k);
            }
            for (int i = 10; i < 12; i++)
            {
                KonjiStrijelci ks = new KonjiStrijelci(i);
                ks.AddCostumes("sprites\\SelectedHorseArcher.jpg");
                lista.Add(ks);
            }
            for (int i = 12; i < 15; i++)
            {
                Infantry inf = new Infantry(i);
                inf.AddCostumes("sprites\\SelectedLegionary.jpg");
                lista.Add(inf);
            }
            for (int i = 15; i < 18; i++)
            {
                Konjanici1 k1 = new Konjanici1(i);
                k1.AddCostumes("sprites\\SelectedHorseman.jpg");
                lista.Add(k1);
            }
            for (int i = 18; i < 24; i++)
            {
                KonjiStrijelci1 ks1 = new KonjiStrijelci1(i);
                ks1.AddCostumes("sprites\\SelectedHorseArcher.jpg");
                lista.Add(ks1);
            }
            foreach (Sprite a in lista)
            {
                Game.AddSprite(a);

                a.SetX(11 + 78 * a.JedinstveniBroj);
                if (a.JedinstveniBroj < 5)
                {
                    a.SetX(11 + 78 * (a.JedinstveniBroj + 2));
                    a.SetY(12 + 49);
                }
                else if (a.JedinstveniBroj >= 5 && a.JedinstveniBroj < 8)
                {
                    a.SetX(11 + 78 * (a.JedinstveniBroj - 2));
                    a.SetY(12);
                }
                else if (a.JedinstveniBroj >= 8 && a.JedinstveniBroj < 10)
                {
                    a.SetX(11 + 78 * (a.JedinstveniBroj - 8));
                    a.SetY(12 + 49 * 2);
                }
                else if (a.JedinstveniBroj >= 10 && a.JedinstveniBroj < 12)
                {
                    a.SetX(11 + 78 * (a.JedinstveniBroj - 3));
                    a.SetY(12 + 49 * 2);
                }
                else if (a.JedinstveniBroj >= 12 && a.JedinstveniBroj < 15)
                {
                    a.SetX(11 + 78 * (a.JedinstveniBroj - 9));
                    a.SetY(12 + 49 * 8);
                }
                else if (a.JedinstveniBroj >= 15 && a.JedinstveniBroj < 17)
                {
                    a.SetX(11 + 78 * (a.JedinstveniBroj - 9));
                    a.SetY(12 + 49 * 7);
                }
                else if (a.JedinstveniBroj == 17)
                {
                    a.SetX(11 + 78 * 2);
                    a.SetY(12 + 49 * 7);
                }
                else if (a.JedinstveniBroj == 18)
                {
                    a.SetX(11 + 78 * 1);
                    a.SetY(12 + 49 * 7);
                }
                else if (a.JedinstveniBroj >= 19 && a.JedinstveniBroj < 24)
                {
                    a.SetX(11 + 78 * (a.JedinstveniBroj - 17));
                    a.SetY(12 + 49 * 9);
                }

            }
            //3. scripts that start
            Game.StartScript(OdabirJedinice1);
            Game.StartScript(PredajaJedinice);
            Game.StartScript(Predaja);
            Game.StartScript(ZavrsiPotez);
        }
        #endregion

        #region skripteimetode
        private int ZavrsiPotez()
        {
            while (START)
            {
                if (sensing.KeyPressed("K"))
                {
                    potez = 0;
                }
            }
            return 0;
        }
        
        private double[] Ukupno(List<Sprite> lista)
        {
            double[] ukupno = new double[4];
            double w = 0;
            double t = 0;
            for (int i = 0; i < 12; i++)
            {
                ukupno[0] += lista[i].GetLjudstvo();
                w += lista[i].GetMoral();
            }
            ukupno[1] = Math.Round(w / 12, 2);
            for (int j = 12; j < 24; j++)
            {
                ukupno[2] += lista[j].GetLjudstvo();
                t += lista[j].GetMoral();
            }
            ukupno[3] = Math.Round(t / 12, 2);
            return ukupno;
        }

        private int PredajaJedinice()
        {
            int w = 1;
            while (START)
            {
                for (int i = 0; i < 24; i++)
                {
                    if (lista[i].GetMoral() <= 0 || lista[i].GetLjudstvo() <= 0)
                    {
                        if (w == 1)
                        {
                            MessageBox.Show("Jedinica je uništena ili se predala.");
                        }
                        lista[i].SetVisible(false);
                        w = 0;
                    }
                }
            }
            return 0;
        }
        
        private int Predaja()
        {
            int w = 1;
            while (START)
            {
                if (Ukupno(lista)[0] <= 0 || Ukupno(lista)[1] <= 0)
                {
                    if (w == 1)
                    {
                        MessageBox.Show("Pobijedili su Parćani!");
                        w = 0;
                    }
                }
                else if (Ukupno(lista)[2] <= 0 || Ukupno(lista)[3] <= 0)
                {
                    if (w == 1)
                    {
                        MessageBox.Show("Pobijedili su Rimljani!");
                        w = 0;
                    }
                }
            }
            return 0;
        }
        
        private void ZamijeniStrane(int posljednjafrakcija)
        {
            for (int i = 0; i < 24; i++)
            {
                lista[i].Napadao = false;
            }
            potez = 15;
            lblPotez.Invoke((MethodInvoker)delegate { lblPotez.Text = potez.ToString(); });
            while (true)
            {
                if (posljednjafrakcija == 1)
                {
                    Game.StartScript(OdabirJedinice2);
                    break;
                }
                else if (posljednjafrakcija == 2)
                {
                    Game.StartScript(OdabirJedinice1);
                    break;
                }
            }
        }
        
        private int OdabirJedinice1()
        {
            sensing.MouseClick = false;
            while (START)
            {
                if (potez != 0)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        if (sensing.MouseClick && sensing.Mouse.X <= lista[i].Width + lista[i].X &&
                            lista[i].X <= sensing.Mouse.X && sensing.Mouse.Y <= lista[i].Heigth + lista[i].Y
                            && lista[i].Y <= sensing.Mouse.Y)
                        {
                            lblPotez.Invoke((MethodInvoker)delegate { lblPotez.Text = potez.ToString(); });
                            indeks = i;
                            lista[indeks].NextCostume();
                            Wait(0.1);
                            lblLjudstvo.Invoke((MethodInvoker)delegate { lblLjudstvo.Text = lista[indeks].GetLjudstvo().ToString(); });
                            lblMoral.Invoke((MethodInvoker)delegate { lblMoral.Text = lista[indeks].GetMoral().ToString(); });
                            Pomicanje(indeks, 1);
                            return 0;
                        }
                    }
                }
                else
                {
                    ZamijeniStrane(1);
                    return 0;
                }
            }
            return 0;
        }

        private int OdabirJedinice2()
        {
            sensing.MouseClick = false;
            while (START)
            {
                if (potez != 0)
                {
                    for (int i = 12; i < 24; i++)
                    {
                        if (sensing.MouseClick && sensing.Mouse.X <= lista[i].Width + lista[i].X &&
        lista[i].X <= sensing.Mouse.X && sensing.Mouse.Y <= lista[i].Heigth + lista[i].Y
        && lista[i].Y <= sensing.Mouse.Y)
                        {
                            lblPotez.Invoke((MethodInvoker)delegate { lblPotez.Text = potez.ToString(); });
                            indeks = i;
                            lista[indeks].NextCostume();
                            Wait(0.1);
                            lblLjudstvo.Invoke((MethodInvoker)delegate { lblLjudstvo.Text = lista[indeks].GetLjudstvo().ToString(); });
                            lblMoral.Invoke((MethodInvoker)delegate { lblMoral.Text = lista[indeks].GetMoral().ToString(); });
                            Pomicanje(indeks, 2);
                            return 0;
                        }
                    }
                }
                else
                {
                    ZamijeniStrane(2);
                    return 0;
                }
            }
            return 0;
        }

        private void PocniBorbu(ProvjeraDelegate provjeraDelegate, int index, int posljednjafrakcija)
        {
            int lj1 = lista[index].GetLjudstvo();
            double mr1 = lista[index].GetMoral();
            int lj2 = lista[provjeraDelegate(lista, index)[1]].GetLjudstvo();
            double mr2 = lista[provjeraDelegate(lista, index)[1]].GetMoral();
            Borba(index, provjeraDelegate(lista, index)[1]);
            lista[index].Napadao = true;
            Borba forma = new Borba();
            forma.lblNapadacMoral.Text = lista[index].GetMoral().ToString();
            forma.lblNapadacLjudstvo.Text = lista[index].GetLjudstvo().ToString();
            forma.lblNapadnutiMoral.Text = lista[provjeraDelegate(lista, index)[1]].GetMoral().ToString();
            forma.lblNapadnutiLjudstvo.Text = lista[provjeraDelegate(lista, index)[1]].GetLjudstvo().ToString();
            forma.lblIzgubljenoLjudstvo1.Text = (lj1 - lista[index].GetLjudstvo()).ToString();
            forma.lblIzgubljeniMoral1.Text = Math.Round(mr1 - lista[index].GetMoral(), 2).ToString();
            forma.lblIzgubljenoLjudstvo2.Text = (lj2 - lista[provjeraDelegate(lista, index)[1]].GetLjudstvo()).ToString();
            forma.lblIzgubljeniMoral2.Text = Math.Round(mr2 - lista[provjeraDelegate(lista, index)[1]].GetMoral(), 2).ToString();
            forma.ShowDialog();
            Pomicanje(index, posljednjafrakcija);
        }
        
        private void Pomicanje(int index, int posljednjafrakcija)
        {
            if (potez != 0)
            {
                Wait(0.1);
                niz[0] = 3;
                while (START)
                {
                    if (posljednjafrakcija == 1)
                    {
                        if (ProvjeraDesno1(lista, index)[0] == 0 && sensing.MouseClick && sensing.Mouse.X > lista[index].X + 78 &&
                            sensing.Mouse.X < lista[index].X + 78 + lista[index].Width && sensing.Mouse.Y > lista[index].Y
                            && sensing.Mouse.Y < lista[index].Y + 49 && lista[index].Napadao == false)
                        {
                            PocniBorbu(ProvjeraDesno1, index, posljednjafrakcija);
                            break;
                        }
                        else if (ProvjeraGore1(lista, index)[0] == 0 && sensing.MouseClick && sensing.Mouse.X > lista[index].X &&
                            sensing.Mouse.X < lista[index].X + lista[index].Width && sensing.Mouse.Y > lista[index].Y - 49
                            && sensing.Mouse.Y < lista[index].Y + 49 - lista[index].Heigth && lista[index].Napadao == false)
                        {
                            PocniBorbu(ProvjeraGore1, index, posljednjafrakcija);
                            break;
                        }
                        else if (ProvjeraDolje1(lista, index)[0] == 0 && sensing.MouseClick && sensing.Mouse.X > lista[index].X &&
                            sensing.Mouse.X < lista[index].X + lista[index].Width && sensing.Mouse.Y > lista[index].Y + 49
                            && sensing.Mouse.Y < lista[index].Y + 49 + lista[index].Heigth && lista[index].Napadao == false)
                        {
                            PocniBorbu(ProvjeraDolje1, index, posljednjafrakcija);
                            break;
                        }
                        else if (ProvjeraLijevo1(lista, index)[0] == 0 && sensing.MouseClick && sensing.Mouse.X > lista[index].X - 78 &&
                            sensing.Mouse.X < lista[index].X - 78 + lista[index].Width && sensing.Mouse.Y > lista[index].Y
                            && sensing.Mouse.Y < lista[index].Y + lista[index].Heigth && lista[index].Napadao == false)
                        {
                            PocniBorbu(ProvjeraLijevo1, index, posljednjafrakcija);
                            break;
                        }

                    }
                    else if (posljednjafrakcija == 2)
                    {
                        if (ProvjeraDesno2(lista, index)[0] == 0 && sensing.MouseClick && sensing.Mouse.X > lista[index].X + 78 &&
                            sensing.Mouse.X < lista[index].X + 78 + lista[index].Width && sensing.Mouse.Y > lista[index].Y
                            && sensing.Mouse.Y < lista[index].Y + 49 && lista[index].Napadao == false)
                        {
                            PocniBorbu(ProvjeraDesno2, index, posljednjafrakcija);
                            break;
                        }
                        else if (ProvjeraGore2(lista, index)[0] == 0 && sensing.MouseClick && sensing.Mouse.X > lista[index].X &&
                            sensing.Mouse.X < lista[index].X + lista[index].Width && sensing.Mouse.Y > lista[index].Y - 49
                            && sensing.Mouse.Y < lista[index].Y + 49 - lista[index].Heigth && lista[index].Napadao == false)
                        {
                            PocniBorbu(ProvjeraGore2, index, posljednjafrakcija);
                            break;
                        }
                        else if (ProvjeraDolje2(lista, index)[0] == 0 && sensing.MouseClick && sensing.Mouse.X > lista[index].X &&
                            sensing.Mouse.X < lista[index].X + lista[index].Width && sensing.Mouse.Y > lista[index].Y + 49
                            && sensing.Mouse.Y < lista[index].Y + 49 + lista[index].Heigth && lista[index].Napadao == false)
                        {
                            PocniBorbu(ProvjeraDolje2, index, posljednjafrakcija);
                            break;
                        }
                        else if (ProvjeraLijevo2(lista, index)[0] == 0 && sensing.MouseClick && sensing.Mouse.X > lista[index].X - 78 &&
                            sensing.Mouse.X < lista[index].X - 78 + lista[index].Width && sensing.Mouse.Y > lista[index].Y
                            && sensing.Mouse.Y < lista[index].Y + lista[index].Heigth && lista[index].Napadao == false)
                        {
                            PocniBorbu(ProvjeraLijevo2, index, posljednjafrakcija);
                            break;
                        }
                    }

                    if (sensing.MouseClick && Provjera21(lista, sensing.Mouse, index)[0] == 0 && posljednjafrakcija == 1)
                    {
                        int w = Provjera21(lista, sensing.Mouse, index)[1];
                        lista[index].NextCostume();
                        lista[w].NextCostume();
                        lblLjudstvo.Invoke((MethodInvoker)delegate { lblLjudstvo.Text = lista[w].GetLjudstvo().ToString(); });
                        lblMoral.Invoke((MethodInvoker)delegate { lblMoral.Text = lista[w].GetMoral().ToString(); });
                        Pomicanje(w, 1);
                        break;
                    }
                    else if (sensing.MouseClick && Provjera21(lista, sensing.Mouse, index)[0] == 1 && posljednjafrakcija == 1)
                    {
                        lista[index].NextCostume();
                        lblLjudstvo.Invoke((MethodInvoker)delegate { lblLjudstvo.Text = Ukupno(lista)[0].ToString(); });
                        lblMoral.Invoke((MethodInvoker)delegate { lblMoral.Text = Ukupno(lista)[1].ToString(); });
                        Game.StartScript(OdabirJedinice1);
                        break;
                    }
                    else if (sensing.MouseClick && Provjera22(lista, sensing.Mouse, index)[0] == 0 && posljednjafrakcija == 2)
                    {
                        int w = Provjera22(lista, sensing.Mouse, index)[1];
                        lista[index].NextCostume();
                        lista[w].NextCostume();
                        lblLjudstvo.Invoke((MethodInvoker)delegate { lblLjudstvo.Text = lista[w].GetLjudstvo().ToString(); });
                        lblMoral.Invoke((MethodInvoker)delegate { lblMoral.Text = lista[w].GetMoral().ToString(); });
                        Pomicanje(w, 2);
                        break;
                    }
                    else if (sensing.MouseClick && Provjera22(lista, sensing.Mouse, index)[0] == 1 && posljednjafrakcija == 2)
                    {
                        lista[index].NextCostume();
                        lblLjudstvo.Invoke((MethodInvoker)delegate { lblLjudstvo.Text = Ukupno(lista)[2].ToString(); });
                        lblMoral.Invoke((MethodInvoker)delegate { lblMoral.Text = Ukupno(lista)[3].ToString(); });
                        Game.StartScript(OdabirJedinice2);
                        break;
                    }
                    else if (sensing.KeyPressed("Down"))
                    {
                        if (ProvjeraDolje(lista, index) == "slobodno")
                        {
                            if ((index <= 7 || index >= 12 && index < 15) && potez >= 2)
                            {
                                potez -= 2;
                                lblPotez.Invoke((MethodInvoker)delegate { lblPotez.Text = potez.ToString(); });
                                lista[index].PomicanjeDolje();
                            }
                            else if ((index > 7 || index < 12 && index >= 15) && potez >= 1)
                            {
                                potez -= 1;
                                lblPotez.Invoke((MethodInvoker)delegate { lblPotez.Text = potez.ToString(); });
                                lista[index].PomicanjeDolje();
                            }
                        }
                        Pomicanje(index, posljednjafrakcija);
                        break;
                    }
                    else if (sensing.KeyPressed("Up"))
                    {
                        if (ProvjeraGore(lista, index) == "slobodno")
                        {
                            if ((index <= 7 || index >= 12 && index < 15) && potez >= 2)
                            {
                                potez -= 2;
                                lblPotez.Invoke((MethodInvoker)delegate { lblPotez.Text = potez.ToString(); });
                                lista[index].PomicanjeGore();
                            }
                            else if ((index > 7 || index < 12 && index >= 15) && potez >= 1)
                            {
                                potez -= 1;
                                lblPotez.Invoke((MethodInvoker)delegate { lblPotez.Text = potez.ToString(); });
                                lista[index].PomicanjeGore();
                            }
                        }
                        Pomicanje(index, posljednjafrakcija);
                        break;
                    }
                    else if (sensing.KeyPressed("Right"))
                    {
                        if (ProvjeraDesno(lista, index) == "slobodno")
                        {
                            if ((index <= 7 || index >= 12 && index < 15) && potez >= 2)
                            {
                                potez -= 2;
                                lblPotez.Invoke((MethodInvoker)delegate { lblPotez.Text = potez.ToString(); });
                                lista[index].PomicanjeDesno();
                            }
                            else if ((index > 7 || index < 12 && index >= 15) && potez >= 1)
                            {
                                potez -= 1;
                                lblPotez.Invoke((MethodInvoker)delegate { lblPotez.Text = potez.ToString(); });
                                lista[index].PomicanjeDesno();
                            }
                        }
                        Pomicanje(index, posljednjafrakcija);
                        break;
                    }
                    else if (sensing.KeyPressed("Left"))
                    {
                        if (ProvjeraLijevo(lista, index) == "slobodno")
                        {
                            if ((index <= 7 || index >= 12 && index < 15) && potez >= 2)
                            {
                                potez -= 2;
                                lblPotez.Invoke((MethodInvoker)delegate { lblPotez.Text = potez.ToString(); });
                                lista[index].PomicanjeLijevo();
                            }
                            else if ((index > 7 || index < 12 && index >= 15) && potez >= 1)
                            {
                                potez -= 1;
                                lblPotez.Invoke((MethodInvoker)delegate { lblPotez.Text = potez.ToString(); });
                                lista[index].PomicanjeLijevo();
                            }
                        }
                    }

                    Pomicanje(index, posljednjafrakcija);
                    break;
                }
            }
            else
            {
                lista[index].NextCostume();
                ZamijeniStrane(posljednjafrakcija);
            }
        }

        private int[] Provjera21(List<Sprite> lista, Point point, int indeks)
        {
            int ab = lista[indeks].Y + 49;
            for (int j = 0; j < 12; j++)
            {
                if (point.X <= lista[j].Width + lista[j].X &&
                    lista[j].X <= point.X && point.Y <= lista[j].Heigth + lista[j].Y
                    && lista[j].Y <= point.Y && indeks != j && lista[j].Show == true)
                {
                    niz[0] = 0;
                    niz[1] = j;
                    return niz;
                }
                else if (point.X <= lista[j].Width + lista[j].X &&
                    lista[j].X <= point.X && point.Y <= lista[j].Heigth + lista[j].Y
                    && lista[j].Y <= point.Y && indeks == j)
                {
                    niz[0] = 1;
                    niz[1] = j;
                    return niz;
                }
            }
            niz[0] = 2;
            niz[1] = 0;
            return niz;
        }

        private int[] Provjera22(List<Sprite> lista, Point point, int indeks)
        {
            int ab = lista[indeks].Y + 49;
            for (int j = 12; j < 24; j++)
            {
                if (point.X <= lista[j].Width + lista[j].X &&
                    lista[j].X <= point.X && point.Y <= lista[j].Heigth + lista[j].Y
                    && lista[j].Y <= point.Y && indeks != j && lista[j].Show == true)
                {
                    niz[0] = 0;
                    niz[1] = j;
                    return niz;
                }
                else if (point.X <= lista[j].Width + lista[j].X &&
                    lista[j].X <= point.X && point.Y <= lista[j].Heigth + lista[j].Y
                    && lista[j].Y <= point.Y && indeks == j)
                {
                    niz[0] = 1;
                    niz[1] = j;
                    return niz;
                }
            }
            niz[0] = 2;
            niz[1] = 0;
            return niz;
        }

        private string ProvjeraDolje(List<Sprite> lista, int indeks)
        {
            for (int i = 0; i < 24; i++)
            {
                if (((lista[indeks].Y + 49 == lista[i].Y && lista[indeks].X == lista[i].X) || lista[indeks].Y >= 12 + 9 * 49) && lista[i].Show == true)
                {
                    return "";
                }
            }
            return "slobodno";
        }

        private string ProvjeraGore(List<Sprite> lista, int indeks)
        {
            for (int i = 0; i < 24; i++)
            {
                if (((lista[indeks].Y - 49 == lista[i].Y && lista[indeks].X == lista[i].X) || lista[indeks].Y <= 12) && lista[i].Show == true)
                {
                    return "";
                }
            }
            return "slobodno";
        }
        
        private string ProvjeraDesno(List<Sprite> lista, int indeks)
        {
            for (int i = 0; i < 24; i++)
            {
                if (((lista[indeks].X + 78 == lista[i].X && lista[indeks].Y == lista[i].Y) || lista[indeks].X >= 11 + 8 * 78) && lista[i].Show == true)
                {
                    return "";
                }
            }
            return "slobodno";
        }
        
        private string ProvjeraLijevo(List<Sprite> lista, int indeks)
        {
            for (int i = 0; i < 24; i++)
            {
                if (((lista[indeks].X - 78 == lista[i].X && lista[indeks].Y == lista[i].Y) || lista[indeks].X <= 11) && lista[i].Show == true)
                {
                    return "";
                }
            }
            return "slobodno";
        }

        private int[] ProvjeraDolje1(List<Sprite> lista, int indeks)
        {
            int[] niz = new int[2];
            for (int i = 12; i < 24; i++)
            {
                if ((lista[indeks].Y + 49 == lista[i].Y && lista[indeks].X == lista[i].X) && lista[i].Show == true)
                {
                    niz[0] = 0;
                    niz[1] = i;
                    return niz;
                }
            }
            niz[0] = 1;
            niz[1] = 0;
            return niz;
        }
        
        private int[] ProvjeraGore1(List<Sprite> lista, int indeks)
        {
            int[] niz = new int[2];
            for (int i = 12; i < 24; i++)
            {
                if ((lista[indeks].Y - 49 == lista[i].Y && lista[indeks].X == lista[i].X) && lista[i].Show == true)
                {
                    niz[0] = 0;
                    niz[1] = i;
                    return niz;
                }
            }
            niz[0] = 1;
            niz[1] = 0;
            return niz;
        }
        
        private int[] ProvjeraDesno1(List<Sprite> lista, int indeks)
        {
            int[] niz = new int[2];
            for (int i = 12; i < 24; i++)
            {
                if ((lista[indeks].X + 78 == lista[i].X && lista[indeks].Y == lista[i].Y) && lista[i].Show == true)
                {
                    niz[0] = 0;
                    niz[1] = i;
                    return niz;
                }
            }
            niz[0] = 1;
            niz[1] = 0;
            return niz;
        }
        
        private int[] ProvjeraLijevo1(List<Sprite> lista, int indeks)
        {
            int[] niz = new int[2];
            for (int i = 12; i < 24; i++)
            {
                if ((lista[indeks].X - 78 == lista[i].X && lista[indeks].Y == lista[i].Y) && lista[i].Show == true)
                {
                    niz[0] = 0;
                    niz[1] = i;
                    return niz;
                }
            }
            niz[0] = 1;
            niz[1] = 0;
            return niz;
        }

        private int[] ProvjeraDolje2(List<Sprite> lista, int indeks)
        {
            int[] niz = new int[2];
            for (int i = 0; i < 12; i++)
            {
                if ((lista[indeks].Y + 49 == lista[i].Y && lista[indeks].X == lista[i].X) && lista[i].Show == true)
                {
                    niz[0] = 0;
                    niz[1] = i;
                    return niz;
                }
            }
            niz[0] = 1;
            niz[1] = 0;
            return niz;
        }
        
        private int[] ProvjeraGore2(List<Sprite> lista, int indeks)
        {
            int[] niz = new int[2];
            for (int i = 0; i < 12; i++)
            {
                if ((lista[indeks].Y - 49 == lista[i].Y && lista[indeks].X == lista[i].X) && lista[i].Show == true)
                {
                    niz[0] = 0;
                    niz[1] = i;
                    return niz;
                }
            }
            niz[0] = 1;
            niz[1] = 0;
            return niz;
        }
        
        private int[] ProvjeraDesno2(List<Sprite> lista, int indeks)
        {
            int[] niz = new int[2];
            for (int i = 0; i < 12; i++)
            {
                if ((lista[indeks].X + 78 == lista[i].X && lista[indeks].Y == lista[i].Y) && lista[i].Show == true)
                {
                    niz[0] = 0;
                    niz[1] = i;
                    return niz;
                }
            }
            niz[0] = 1;
            niz[1] = 0;
            return niz;
        }
        
        private int[] ProvjeraLijevo2(List<Sprite> lista, int indeks)
        {
            for (int i = 0; i < 12; i++)
            {
                if ((lista[indeks].X - 78 == lista[i].X && lista[indeks].Y == lista[i].Y) && lista[i].Show == true)
                {
                    niz[0] = 0;
                    niz[1] = i;
                    return niz;
                }
            }
            niz[0] = 1;
            niz[1] = 0;
            return niz;
        }

        private void Borba(int napadac, int napadnuti)
        {
            Wait(0.1);
            for (int i = 0; i < 5; i++)
            {
                if (lista[napadnuti].Show == true)
                {
                    lista[napadac].Borba(lista[napadnuti]);
                }
                else
                {
                    return;
                }
            }
            potez -= 1;
            lblPotez.Invoke((MethodInvoker)delegate { lblPotez.Text = potez.ToString(); });
        }
        #endregion
    }
}
