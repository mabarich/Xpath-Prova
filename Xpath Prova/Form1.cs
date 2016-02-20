using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using HtmlAgilityPack;
using System.Xml.Schema;
using System.Net;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Diagnostics;
using System.Threading;

namespace Xpath_Prova
{
    public partial class Form1 : Form
    {
        ArrayList nomis;
        ArrayList dates;
        ArrayList prezzis;
        ArrayList immaginip;
        ArrayList nomip;
        ArrayList datep;
        ArrayList prezzip;
        ArrayList immaginis;
        ArrayList favsa=null;
        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
        DateTime date1 = DateTime.Today;
        Boolean bstar, bplanet;
        string ultimaModificaS = "";
        string ultimaModificaC = "";
        int navigateWeek, navigateYear;

        public Form1()
        { 
            InitializeComponent();

            checkOnStartUp();

            navigateWeek = dfi.Calendar.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            navigateYear = DateTime.Now.Year;
            label4.Text = "Settimana: " + navigateWeek.ToString();
            favs();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Nome";
            dataGridView1.Columns[0].Width = dataGridView1.Width * 160 / 100;
            dataGridView1.Columns[0].Frozen = true;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].Name = "Uscita";
            dataGridView1.Columns[1].Width = dataGridView1.Width * 35 / 100;
            dataGridView1.Columns[1].Frozen = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].Name = "Settimana";
            dataGridView1.Columns[2].Width = dataGridView1.Width * 25 / 100;
            dataGridView1.Columns[2].Frozen = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].Name = "Prezzo";
            dataGridView1.Columns[3].Width = dataGridView1.Width * 20 / 100;
            dataGridView1.Columns[3].Frozen = true;
            dataGridView1.Columns[3].ReadOnly = true;

            dataGridView2.ColumnCount = 4;
            dataGridView2.Columns[0].Name = "Nome";
            dataGridView2.Columns[0].Width = dataGridView1.Width * 160 / 100;
            dataGridView2.Columns[0].Frozen = true;
            dataGridView2.Columns[0].ReadOnly = true;
            dataGridView2.Columns[1].Name = "Uscita";
            dataGridView2.Columns[1].Width = dataGridView1.Width * 35 / 100;
            dataGridView2.Columns[1].Frozen = true;
            dataGridView2.Columns[1].ReadOnly = true;
            dataGridView2.Columns[2].Name = "Settimana";
            dataGridView2.Columns[2].Width = dataGridView1.Width * 25 / 100;
            dataGridView2.Columns[2].Frozen = true;
            dataGridView2.Columns[2].ReadOnly = true;
            dataGridView2.Columns[3].Name = "Prezzo";
            dataGridView2.Columns[3].Width = dataGridView1.Width * 20 / 100;
            dataGridView2.Columns[3].Frozen = true;
            dataGridView2.Columns[3].ReadOnly = true;

            dataGridView3.ColumnCount = 4;
            dataGridView3.Columns[0].Name = "Nome";
            dataGridView3.Columns[0].Width = dataGridView1.Width * 160 / 100;
            dataGridView3.Columns[0].Frozen = true;
            dataGridView3.Columns[0].ReadOnly = true;
            dataGridView3.Columns[1].Name = "Uscita";
            dataGridView3.Columns[1].Width = dataGridView1.Width * 35 / 100;
            dataGridView3.Columns[1].Frozen = true;
            dataGridView3.Columns[1].ReadOnly = true;
            dataGridView3.Columns[2].Name = "Settimana";
            dataGridView3.Columns[2].Width = dataGridView1.Width * 25 / 100;
            dataGridView3.Columns[2].Frozen = true;
            dataGridView3.Columns[2].ReadOnly = true;
            dataGridView3.Columns[3].Name = "Prezzo";
            dataGridView3.Columns[3].Width = dataGridView1.Width * 20 / 100;
            dataGridView3.Columns[3].Frozen = true;
            dataGridView3.Columns[3].ReadOnly = true;

            dataGridView4.ColumnCount = 4;
            dataGridView4.Columns[0].Name = "Nome";
            dataGridView4.Columns[0].Width = dataGridView1.Width * 160 / 100;
            dataGridView4.Columns[0].Frozen = true;
            dataGridView4.Columns[0].ReadOnly = true;
            dataGridView4.Columns[1].Name = "Uscita";
            dataGridView4.Columns[1].Width = dataGridView1.Width * 35 / 100;
            dataGridView4.Columns[1].Frozen = true;
            dataGridView4.Columns[1].ReadOnly = true;
            dataGridView4.Columns[2].Name = "Settimana";
            dataGridView4.Columns[2].Width = dataGridView1.Width * 25 / 100;
            dataGridView4.Columns[2].Frozen = true;
            dataGridView4.Columns[2].ReadOnly = true;
            dataGridView4.Columns[3].Name = "Prezzo";
            dataGridView4.Columns[3].Width = dataGridView1.Width * 20 / 100;
            dataGridView4.Columns[3].Frozen = true;
            dataGridView4.Columns[3].ReadOnly = true;

            dataGridView5.ColumnCount = 4;
            dataGridView5.Columns[0].Name = "Nome";
            dataGridView5.Columns[0].Width = dataGridView1.Width * 160 / 100;
            dataGridView5.Columns[0].Frozen = true;
            dataGridView5.Columns[0].ReadOnly = true;
            dataGridView5.Columns[1].Name = "Uscita";
            dataGridView5.Columns[1].Width = dataGridView1.Width * 35 / 100;
            dataGridView5.Columns[1].Frozen = true;
            dataGridView5.Columns[1].ReadOnly = true;
            dataGridView5.Columns[2].Name = "Settimana";
            dataGridView5.Columns[2].Width = dataGridView1.Width * 25 / 100;
            dataGridView5.Columns[2].Frozen = true;
            dataGridView5.Columns[2].ReadOnly = true;
            dataGridView5.Columns[3].Name = "Prezzo";
            dataGridView5.Columns[3].Width = dataGridView1.Width * 20 / 100;
            dataGridView5.Columns[3].Frozen = true;
            dataGridView5.Columns[3].ReadOnly = true;

            dataGridView6.ColumnCount = 1;
            dataGridView6.Columns[0].Name = "Nome";
            dataGridView6.Columns[0].Width = dataGridView6.Width;
            dataGridView6.Columns[0].Frozen = true;
            dataGridView6.Columns[0].ReadOnly = true;

            reset();
            bool ok = leggi("", "DBp.txt");
            bool ok2 = leggi("", "DBs.txt");
            stampa(1);
            stampa(2);
            stampa(3);
            stampa(4);
            stampa(5);
        }

        private void checkOnStartUp()
        {
            try
            {
                bool ok;
                ok = chk();
                if (ok)
                {
                    MessageBox.Show("Ho trovato un nuovo aggiornamento disponibile.", "Aggiornamento trovato", MessageBoxButtons.OK);
                }
            }
            catch (Exception) { }
        }

        //Leggi Tutte
        private void button1_Click(object sender, EventArgs e)
        {
            reset();
            bool ok = leggi("", "DBp.txt");
            bool ok2 = leggi("", "DBs.txt");
               if (!ok)
               {
                   bplanet = true;
                   bstar = true;
                   aggiorna();
               }
               favs();
               s(ok);
        }

        //Parse Star
        public void star()
        {
            Calendar cal = dfi.Calendar;
            int cy = DateTime.Now.Year - 2000;
            int cm = DateTime.Now.Month;
            //Parto dall'anno corrente e arrivo fino a quello successivo
            for (int zz = cy; zz < (cy+2); zz++)
            {
                //Passo ogni mese
                for (int z = 1; z < 13; z++)
                {
                    //Se il mese dell'anno corrente è già passato, lo salto
                    if((cy==zz && z>=(cm-1)) || (cy<zz))
                    {
                        string url = "";
                        if (z<10)
                        {
                            url = "http://maktheeater.altervista.org/0" + z.ToString() + zz.ToString() + ".html";
                        }
                        else 
                        {
                            url = "http://maktheeater.altervista.org/" + z.ToString() + zz.ToString() + ".html";
                        }
                        var webGet = new HtmlWeb();
                        var document = webGet.Load(url);
                        //Prendo la data di uscita del volume
                        HtmlNodeCollection tl3 = document.DocumentNode.SelectNodes("//div[@class=\"details\"]/p/span");
                        if (tl3 != null)
                        {
                            bool inserisci = true;
                            int i = 0;
                            foreach (HtmlAgilityPack.HtmlNode node2 in tl3)
                            {
                                inserisci = true;
                                int settimana = cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) - 1;
                                DateTime dt = Convert.ToDateTime(node2.InnerText);
                                //Gestione delle uscite anticipate della Star se il mese ha 5 giovedì/5 venerdì
                                int x = 0;
                                if (dt.ToString("ddd") == "gio")
                                    x = -1;
                                else if (dt.ToString("ddd") == "ven")
                                    x = -2;
                                else if (dt.ToString("ddd") == "sab")
                                    x = -3;
                                else if (dt.ToString("ddd") == "mar")
                                    x = 1;
                                dt = dt.AddDays(x);
                                if (cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) < settimana)
                                    inserisci = false;
                                if (inserisci)
                                {
                                    string gg0 = dt.Day.ToString();
                                    if (gg0.Length == 1)
                                        gg0 = "0" + gg0;
                                    string mm0 = dt.Month.ToString();
                                    if (mm0.Length == 1)
                                        mm0 = "0" + mm0;
                                    string datadainserire = gg0 + "/" + mm0 + "/" + dt.Year;
                                    if (dt.GetWeekOfMonth() == 1)
                                    {
                                        DateTime dt1 = dt.AddDays(-7);
                                        if (dt1.GetWeekOfMonth() == 5)
                                        {
                                            string gg = dt1.Day.ToString();
                                            if (gg.Length == 1)
                                                gg = "0" + gg;
                                            string mm = dt1.Month.ToString();
                                            if (mm.Length == 1)
                                                mm = "0" + mm;
                                            datadainserire = gg + "/" + mm + "/" + dt1.Year;
                                        }
                                    }
                                    dates.Add(datadainserire);
                                    i++;
                                }
                            }
                            //Prendo il nome del volume
                            HtmlNodeCollection tl2 = document.DocumentNode.SelectNodes("//div[@class=\"photo\"]/a/img");
                            int h = 0, j = 0;
                            foreach (HtmlAgilityPack.HtmlNode node2 in tl2)
                            {
                                if (h >= (tl2.Count - i))
                                {
                                    string nome;
                                    nome = node2.Attributes["alt"].Value.Replace("n. ", "");
                                    nome = nome.Replace("&amp;", "&");
                                    nomis.Add(nome);
                                    immaginis.Add("http://maktheeater.altervista.org/" + node2.Attributes["src"].Value);
                                }
                                h++;
                            }
                            //Prendo il prezzo del volume
                            HtmlNodeCollection tl4 = document.DocumentNode.SelectNodes("//div[@class=\"details\"]/div/span[@class=\"price button_small\"]/span");
                            foreach (HtmlAgilityPack.HtmlNode node2 in tl4)
                            {
                                if (j >= (tl3.Count - i))
                                {
                                    string prezzo = node2.InnerText.Replace("€ ", "");
                                    prezzo = prezzo.Replace("&#8364; ", "");
                                    prezzo = prezzo.Replace("&euro; ", "");
                                    prezzo = prezzo.Replace("&#x20AC; ", "");
                                    prezzo = prezzo.Replace("&#128; ", "");
                                    prezzo = prezzo.Replace("? ", "");
                                    prezzo = prezzo.Substring(prezzo.IndexOf(" ")+1, prezzo.Length - prezzo.IndexOf(" ")-1);
                                    prezzis.Add(prezzo);
                                }
                                j++;
                            }
                        }
                    }
                }
            }
        }

        //Parse Planet
        public void planet()
        {
            Calendar cal = dfi.Calendar;
            int cy = DateTime.Now.Year;
            int cw = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            //Parto dall'anno corrente e arrivo fino a quello successivo
            for (int kk = cy; kk < (cy+1); kk++)
            {
                //Passo ogni settimana
                for (int k = 0; k < 53; k++)
                {
                    //Se la settimana dell'anno corrente è già passata, la salto
                    if ((kk == cy && k >= (cw - 1)) || (kk > cy))
                    {
                        string url1 = "http://www.paninicomics.it/web/guest/planetmanga/checklist?year="+kk+"&weekOfYear=" + k;
                        var webGet1 = new HtmlWeb();
                        var document1 = webGet1.Load(url1);
                        HtmlNodeCollection tl1 = document1.DocumentNode.SelectNodes("//div[@class=\"detail\"]");
                        if (tl1 != null)
                        {
                            foreach (HtmlAgilityPack.HtmlNode node in tl1)
                            {
                                //Prendo il nome del volume
                                HtmlNodeCollection tl2 = node.SelectNodes("div[@class=\"title\"]/h3");
                                foreach (HtmlAgilityPack.HtmlNode node2 in tl2)
                                {
                                    string nome;
                                    nome = node2.InnerText;
                                    nome = nome.Replace("&amp;", "&");
                                    nomip.Add(nome);
                                }
                                //Prendo la data di uscita del volume
                                HtmlNodeCollection tl3 = node.SelectNodes("div[@class=\"logo_brand\"]/span");
                                foreach (HtmlAgilityPack.HtmlNode node2 in tl3)
                                {
                                    DateTime d = Convert.ToDateTime(node2.InnerText).AddDays(-1);
                                    string gg = d.Day.ToString();
                                    if (gg.Length == 1)
                                        gg = "0" + gg;
                                    string mm = d.Month.ToString();
                                    if (mm.Length == 1)
                                        mm = "0" + mm;
                                    datep.Add(gg + "/" + mm + "/" + d.Year);
                                }
                                //Prendo il prezzo del volume
                                HtmlNodeCollection tl4 = node.SelectNodes("div[@class=\"price\"]/h4");
                                foreach (HtmlAgilityPack.HtmlNode node2 in tl4)
                                {
                                    string stringa = node2.InnerText;
                                    stringa = stringa.Replace("prezzo: &euro; ", "");
                                    stringa = stringa.Replace(".", ",");
                                    prezzip.Add(stringa);
                                }
                                //Prendo la copertina del volume
                                HtmlNodeCollection tl5 = node.SelectNodes("div[@class=\"cover\"]/img");
                                foreach (HtmlAgilityPack.HtmlNode node2 in tl5)
                                {
                                    string immagine = "http://www.paninicomics.it" + node2.Attributes["src"].Value;
                                    immaginip.Add(immagine);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void stampa2()
        {
            dataGridView5.RowCount = 1;
            int righe = 0;
            for (int k = 0; k < nomip.Count; k++)
            {
                DateTime dt = Convert.ToDateTime(datep[k]);
                Calendar cal = dfi.Calendar;
                dataGridView5.Rows.Add(nomip[k], datep[k], cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek), prezzip[k]);
                dataGridView5.Rows[righe].DefaultCellStyle.BackColor = Color.LightCoral;
                righe++;
            }
            for (int k = 0; k < nomis.Count; k++)
            {
                DateTime dt = Convert.ToDateTime(dates[k]);
                Calendar cal = dfi.Calendar;
                dataGridView5.Rows.Add(nomis[k], dates[k], cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek), prezzis[k].ToString().Replace("? ", ""));
                dataGridView5.Rows[righe].DefaultCellStyle.BackColor = Color.LightBlue;
                righe++;
            }
        }

        //Stampa
        public void stampa(int dgw)
        {
            //Svuoto la tabella selezionata
            if (dgw == 1)
            {
                dataGridView1.RowCount = 1;
            }
            else if (dgw == 2)
            {
                dataGridView2.RowCount = 1;
            }
            else if (dgw == 3)
            {
                dataGridView3.RowCount = 1;
            }
            else if (dgw ==4)
            {
                dataGridView4.RowCount = 1;
            }
            else if (dgw == 5)
            {
                dataGridView5.RowCount = 1;
            }
            int righe=0;
            //Stampo le uscite della planet in base a quante ne ho lette
            for (int k = 0; k < nomip.Count; k++)
            {
                DateTime dt = Convert.ToDateTime(datep[k]);
                Calendar cal = dfi.Calendar;
                if (dgw == 1)
                {
                    dataGridView1.Rows.Add(nomip[k], datep[k], cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek), prezzip[k]);
                    dataGridView1.Rows[righe].DefaultCellStyle.BackColor = Color.LightCoral;
                    righe++;
                }
                else if (dgw==2)
                {
                    if(cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) == cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek))
                    {
                        dataGridView2.Rows.Add(nomip[k], datep[k], cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek), prezzip[k]);
                        dataGridView2.Rows[righe].DefaultCellStyle.BackColor = Color.LightCoral;
                        righe++;
                    }
                }
                else if (dgw==3)
                {
                    if(cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) == cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)+1)
                    {
                        dataGridView3.Rows.Add(nomip[k], datep[k], cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek), prezzip[k]);
                        dataGridView3.Rows[righe].DefaultCellStyle.BackColor = Color.LightCoral;
                        righe++;
                    }
                }
                else if (dgw == 4)
                {
                    if (isFav(nomip[k].ToString()))
                    {
                        dataGridView4.Rows.Add(nomip[k], datep[k], cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek), prezzip[k]);
                        dataGridView4.Rows[righe].DefaultCellStyle.BackColor = Color.LightCoral;
                        righe++;
                    }
                }
                else if (dgw == 5)
                {
                    if (cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) == navigateWeek)
                    {
                        dataGridView5.Rows.Add(nomip[k], datep[k], cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek), prezzip[k]);
                        dataGridView5.Rows[righe].DefaultCellStyle.BackColor = Color.LightCoral;
                        righe++;
                    }
                }
            }
            //Stampo le uscite star in base a quante ne ho lette
            for (int k = 0; k < nomis.Count; k++)
            {
                DateTime dt = Convert.ToDateTime(dates[k]);
                Calendar cal = dfi.Calendar;
                if (dgw == 1)
                {
                    dataGridView1.Rows.Add(nomis[k], dates[k], cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek), prezzis[k].ToString().Replace("? ", ""));
                    dataGridView1.Rows[righe].DefaultCellStyle.BackColor = Color.LightBlue;
                    righe++;
                }
                else if (dgw == 2)
                {
                    if (cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) == cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek))
                    {
                        dataGridView2.Rows.Add(nomis[k], dates[k], cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek), prezzis[k].ToString().Replace("? ", ""));
                        dataGridView2.Rows[righe].DefaultCellStyle.BackColor = Color.LightBlue;
                        righe++;
                    }
                }
                else if (dgw == 3)
                {
                    if(cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) == cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)+1)
                    {
                        dataGridView3.Rows.Add(nomis[k], dates[k], cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek), prezzis[k].ToString().Replace("? ", ""));
                        dataGridView3.Rows[righe].DefaultCellStyle.BackColor = Color.LightBlue;
                        righe++;
                    }
                }
                else if (dgw == 4)
                {
                    if (isFav(nomis[k].ToString()))
                    {
                        dataGridView4.Rows.Add(nomis[k], dates[k], cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek), prezzis[k].ToString().Replace("? ", ""));
                        dataGridView4.Rows[righe].DefaultCellStyle.BackColor = Color.LightBlue;
                        righe++;
                    }
                }
                else if (dgw == 5)
                {
                    if (cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) == navigateWeek)
                    {
                        dataGridView5.Rows.Add(nomis[k], dates[k], cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek), prezzis[k].ToString().Replace("? ", ""));
                        dataGridView5.Rows[righe].DefaultCellStyle.BackColor = Color.LightBlue;
                        righe++;
                    }
                }
            }
        }

        //Guarda se una serie è preferita
        private bool isFav(string p)
        {
            bool found = false;
            if (favsa != null)
            {
                for (int i = 0; i < favsa.Count; i++)
                {
                    int inizio = favsa[i].ToString().IndexOf(";");
                    if (inizio == -1)
                    {
                        string nom = favsa[i].ToString().ToLower();
                        if (p.ToLower().Contains(nom))
                            found = true;
                    }
                    else
                    {
                        string fin = favsa[i].ToString().Substring(0, inizio);
                        if (p.ToLower().Contains(fin.ToLower()))
                        {
                            bool filtro = false;
                            string resto = favsa[i].ToString().Replace(fin, "");
                            while (!filtro && resto.StartsWith(";"))
                            {
                                resto = resto.Substring(1);
                                inizio = resto.IndexOf(";");
                                string att = "";
                                if (inizio != -1)
                                {
                                    att = resto.Substring(0, inizio);
                                    resto = resto.Replace(att, "");
                                }
                                else
                                {
                                    att = resto;
                                    resto = "";
                                }
                                if (p.ToLower().Contains(att.ToLower()))
                                {
                                    filtro = true;
                                }
                            }
                            if(!filtro)
                                found = true;
                        }
                    }
                }
            }
            return found;
        }

        public void reset()
        {
            nomis = new ArrayList();
            dates = new ArrayList();
            prezzis = new ArrayList();
            immaginis = new ArrayList();
            nomip = new ArrayList();
            datep = new ArrayList();
            prezzip = new ArrayList();
            immaginip = new ArrayList();
        }

        public bool leggi(string n, string curFile1)
        {
            Calendar cal = dfi.Calendar;
            bool exists = File.Exists(curFile1);
            if (exists)
            {
                StreamReader sr = new StreamReader(curFile1, Encoding.GetEncoding(1252));
                String line = sr.ReadLine();
                string[] delimiterChars = { "||" };
                while (line != null)
                {
                    string[] words = line.Split(delimiterChars, StringSplitOptions.None);
                    for (int i = 0; i < words.Count(); i++)
                    {
                        string nome = words[i];
                        i++;
                        string data = words[i];
                        i++;
                        string prezzo = words[i];
                        i++;
                        string copertina = words[i];
                        int settimana = cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) - 1;
                        DateTime dt = Convert.ToDateTime(data);
                        if (cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) >= settimana && (n == "" || nome.Contains(n.ToUpper())))
                        {
                            if (curFile1 == "DBp.txt")
                            {
                                nomip.Add(nome);
                                datep.Add(data);
                                prezzip.Add(prezzo);
                                immaginip.Add(copertina);
                            }
                            else
                            {
                                nomis.Add(nome);
                                dates.Add(data);
                                prezzis.Add(prezzo);
                                immaginis.Add(copertina);
                            }
                        }
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            return exists;
        }

        public bool leggi2(string n, string curFile1)
        {
            Calendar cal = dfi.Calendar;
            bool exists = File.Exists(curFile1);
            if (exists)
            {
                StreamReader sr = new StreamReader(curFile1, Encoding.GetEncoding(1252));
                String line = sr.ReadLine();
                string[] delimiterChars = { "||" };
                while (line != null)
                {
                    string[] words = line.Split(delimiterChars, StringSplitOptions.None);
                    for (int i = 0; i < words.Count(); i++)
                    {
                        string nome = words[i];
                        i++;
                        string data = words[i];
                        i++;
                        string prezzo = words[i];
                        i++;
                        string copertina = words[i];
                        DateTime dt = Convert.ToDateTime(data);
                        if (cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) == navigateWeek && data.Contains(navigateYear.ToString()) /*&& (n == "" || nome.Contains(n.ToUpper()))*/)
                        {
                            if (curFile1 == "DBp.txt")
                            {
                                nomip.Add(nome);
                                datep.Add(data);
                                prezzip.Add(prezzo);
                                immaginip.Add(copertina);
                            }
                            else
                            {
                                nomis.Add(nome);
                                dates.Add(data);
                                prezzis.Add(prezzo);
                                immaginis.Add(copertina);
                            }
                        }
                    }
                    line = sr.ReadLine();
                }
                sr.Close();   
            }
            return exists;
        }

        public void salva()
        {
            if (bplanet)
            {
                try
                {
                    StreamWriter sw = new StreamWriter("DBp.txt", false, Encoding.GetEncoding(1252));
                    for (int i = 0; i < nomip.Count; i++)
                    {
                        sw.WriteLine(nomip[i] + "||" + datep[i] + "||" + prezzip[i] + "||" + immaginip[i]);
                    }
                    sw.Close();
                }
                catch (Exception)
                {
                }
            }
            if (bstar)
            {
                try
                {
                    StreamWriter sw = new StreamWriter("DBs.txt", false, Encoding.GetEncoding(1252));
                    for (int i = 0; i < nomis.Count; i++)
                    {
                        sw.WriteLine(nomis[i] + "||" + dates[i] + "||" + prezzis[i] + "||" + immaginis[i]);
                    }
                    sw.Close();
                }
                catch (Exception)
                {
                }
            }
        }

        public void aggiorna()
        {
            try
            {
                reset();
                if (bplanet)
                    planet();
                if (bstar)
                    star();
                stampa(1);
                stampa(2);
                stampa(3);
                stampa(4);
                stampa(5);
                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;
                toolStripButton4.Enabled = true;
                Leggi.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button6.Enabled = true;
                label2.Text = "";
                salva();
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();
            bool ok = leggi("", "DBp.txt");
            bplanet = true;
            bstar = false;
            favs();
            s(ok);
        }

        private void favs()
        {
            if(favsa==null || favsa.Count==0)
            {
                favsa = new ArrayList();
                string curFileF = "Favs.txt";
                bool exists3 = File.Exists(curFileF);
                if (exists3)
                {
                    StreamReader sr = new StreamReader(curFileF, Encoding.GetEncoding(1252));
                    String line = sr.ReadLine();
                    while (line != null)
                    {
                        favsa.Add(line);
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reset();
            bool ok = leggi("", "DBs.txt");
            bplanet = false;
            bstar = true;
            favs();
            s(ok);
        }

        public void s(Boolean ok)
        {
            if (!ok)
                aggiorna();
            stampa(1);
            stampa(2);
            stampa(3);
            stampa(4);
            stampa(5);
        }

        static public byte[] GetBytesFromUrl(string url)
        {
            byte[] b;
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            WebResponse myResp = myReq.GetResponse();

            Stream stream = myResp.GetResponseStream();
            using (BinaryReader br = new BinaryReader(stream))
            {
                b = br.ReadBytes(500000);
                br.Close();
            }
            myResp.Close();
            return b;
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string save = textBox1.Text;
            if (save != "")
            {
                favsa = null;
                favs();
                bool add = true;
                for(int i=0; i<favsa.Count; i++)
                {
                    string line=favsa[i].ToString();
                    if (line.Contains(save))
                    {
                        add = false;
                    }
                }
                if (add)
                {
                    string curFileF = "Favs.txt";
                    StreamWriter sw = new StreamWriter(curFileF, true);
                    sw.WriteLine(save);
                    sw.Close();
                    favsa.Add(save);
                    if (Uscite.SelectedTab == Uscite.TabPages["tabPage6"])
                    {
                        dataGridView6.Rows.Add(favsa[favsa.Count-1]);
                        dataGridView6.Rows[favsa.Count-1].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button7_Click(this, EventArgs.Empty);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && dataGridView1.RowCount > 2)
                {
                    {
                        string nome = dataGridView1.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
                        string url1 = "";
                        int indice = nomip.IndexOf(nome);
                        if (indice != -1)
                        {
                            url1 = immaginip[indice].ToString();
                        }
                        else
                        {
                            indice = nomis.IndexOf(nome);
                            url1 = immaginis[indice].ToString();
                        }
                        Image cover = byteArrayToImage(GetBytesFromUrl(url1));
                        pictureBox1.Image = (Image)(new Bitmap(cover, new Size(250, 381)));
                    }
                }
            }
            catch (Exception) { };
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && dataGridView2.RowCount > 2)
                {
                    {
                        string nome = dataGridView2.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
                        string url1 = "";
                        int indice = nomip.IndexOf(nome);
                        if (indice != -1)
                        {
                            url1 = immaginip[indice].ToString();
                        }
                        else
                        {
                            indice = nomis.IndexOf(nome);
                            url1 = immaginis[indice].ToString();
                        }
                        Image cover = byteArrayToImage(GetBytesFromUrl(url1));
                        pictureBox1.Image = (Image)(new Bitmap(cover, new Size(250, 381)));
                    }
                }
            }
            catch (Exception) { };
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && dataGridView3.RowCount > 2)
                {
                    {
                        string nome = dataGridView3.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
                        string url1 = "";
                        int indice = nomip.IndexOf(nome);
                        if (indice != -1)
                        {
                            url1 = immaginip[indice].ToString();
                        }
                        else
                        {
                            indice = nomis.IndexOf(nome);
                            url1 = immaginis[indice].ToString();
                        }
                        Image cover = byteArrayToImage(GetBytesFromUrl(url1));
                        pictureBox1.Image = (Image)(new Bitmap(cover, new Size(250, 381)));
                    }
                }
            }
            catch (Exception) { };
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && dataGridView4.RowCount > 2)
                {
                    {
                        string nome = dataGridView4.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
                        string url1 = "";
                        int indice = nomip.IndexOf(nome);
                        if (indice != -1)
                        {
                            url1 = immaginip[indice].ToString();
                        }
                        else
                        {
                            indice = nomis.IndexOf(nome);
                            url1 = immaginis[indice].ToString();
                        }
                        Image cover = byteArrayToImage(GetBytesFromUrl(url1));
                        pictureBox1.Image = (Image)(new Bitmap(cover, new Size(250, 381)));
                    }
                }
            }
            catch (Exception) { };
        }

        private void button7_Click(object sender, EventArgs e)
        {
            reset();
            leggi(textBox1.Text, "DBp.txt");
            leggi(textBox1.Text, "DBs.txt");
            stampa(1);
            stampa(2);
            stampa(3);
            stampa(4);
            stampa(5);
        }

        public bool chk()
        {
            string url1 = "http://maktheeater.altervista.org/UltimoAggiornamento.html";
            var webGet1 = new HtmlWeb();
            var document1 = webGet1.Load(url1);
            HtmlNodeCollection tl1 = document1.DocumentNode.SelectNodes("//p");
            if (tl1 != null)
            {
                foreach (HtmlAgilityPack.HtmlNode node in tl1)
                {
                    ultimaModificaS = node.InnerText;
                }
            }
            string lastU = "UltimaModifica.txt";
            bool exists = File.Exists(lastU);
            if (exists)
            {
                StreamReader sr = new StreamReader(lastU, Encoding.GetEncoding(1252));
                ultimaModificaC = sr.ReadLine();
                sr.Close();
            }
            if (ultimaModificaS != ultimaModificaC)
                return true;
            else
                return false;
        }

        private void toolStripSplitButton1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("- L'aggiornamento e la lettura delle uscite possono richiedere qualche secondo.\n- Scrivi e premi invio per cercare.\n- Scrivi e premi il cuore per aggiungere ai preferiti.\n   - Nome;Parole da escludere;parole da escludere;Parole da escludere.\n- Doppio clic sull'uscita per vedere la copertina.\n- Aggiornamenti dall'ultima versione:\n   - Rimozione aggiornamento automatico\n   - Gestione preferiti con parole da escludere", "Barichello Marco", MessageBoxButtons.OK);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            bplanet = true;
            bstar = true;
            label2.Text = "Sto aggiornando tutte le uscite!";
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = false;
            Leggi.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button6.Enabled = false;
            aggiorna();
            /*Thread mt=new Thread(new ThreadStart(aggiorna));
            mt.Start();
            mt.Join();
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = true;
            Leggi.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button6.Enabled = true;
            label2.Text = "";*/
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            bplanet = true;
            bstar = false;
            label2.Text = "Sto aggiornando le uscite della Planet Manga!";
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = false;
            Leggi.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button6.Enabled = false;
            aggiorna();
            /*Thread mt=new Thread(new ThreadStart(aggiorna));
            mt.Start();
            mt.Join();
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = true;
            Leggi.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button6.Enabled = true;
            label2.Text = "";*/
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            bplanet = false;
            bstar = true;
            label2.Text = "Sto aggiornando le uscite della Star Comics!";
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = false;
            Leggi.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button6.Enabled = false;
            aggiorna();
            /*Thread mt=new Thread(new ThreadStart(aggiorna));
            mt.Start();
            mt.Join();
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = true;
            Leggi.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button6.Enabled = true;
            label2.Text = "";*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            navigateWeek--;
            if (navigateWeek > 0)
            {
                label4.Text = "Settimana: " + navigateWeek.ToString();
                reset();
                bool ok = leggi("", "DBp.txt");
                bool ok2 = leggi("", "DBs.txt");
                bplanet = true;
                bstar = true;
                favs();
                s(ok);
            }
            else
            {
                navigateYear--;
                navigateWeek = 53;
                label4.Text = "Settimana: " + navigateWeek.ToString();
                reset();
                bool ok = leggi2("", "DBp.txt");
                bool ok2 = leggi2("", "DBs.txt");
                stampa2();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            navigateWeek++;
            if (navigateWeek <54)
            {
                label4.Text = "Settimana: "+navigateWeek.ToString();
                reset();
                bool ok = leggi("", "DBp.txt");
                bool ok2 = leggi("", "DBs.txt");
                bplanet = true;
                bstar = true;
                favs();
                s(ok);
            }
            else
            {
                navigateYear++;
                navigateWeek=1;
                label4.Text = "Settimana: " + navigateWeek.ToString();
                reset();
                bool ok = leggi2("", "DBp.txt");
                bool ok2 = leggi2("", "DBs.txt");
                stampa2();
            }
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && dataGridView5.RowCount > 2)
                {
                    {
                        string nome = dataGridView5.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
                        string url1 = "";
                        int indice = nomip.IndexOf(nome);
                        if (indice != -1)
                        {
                            url1 = immaginip[indice].ToString();
                        }
                        else
                        {
                            indice = nomis.IndexOf(nome);
                            url1 = immaginis[indice].ToString();
                        }
                        Image cover = byteArrayToImage(GetBytesFromUrl(url1));
                        pictureBox1.Image = (Image)(new Bitmap(cover, new Size(250, 381)));
                    }
                }
            }
            catch (Exception) { };
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Uscite.SelectedIndex = 5;
            dataGridView6.RowCount = 1;
            for(int i=0; i<favsa.Count;i++)
            {
                dataGridView6.Rows.Add(favsa[i]);
                dataGridView6.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("favs.txt", false);
            for (int i = 0; i < favsa.Count; i++)
            {
                sw.WriteLine(favsa[i]);
            }
            sw.Close();
            dataGridView6.RowCount = 1;
            Uscite.SelectedIndex = 0;
            tabPage6.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView6.SelectedRows.Count > 0)
            {
                for (int i = dataGridView6.SelectedRows.Count; i >0; i--)
                {
                    int riga = dataGridView6.SelectedRows[i-1].Index;
                    favsa.RemoveAt(riga);
                }
                dataGridView6.ClearSelection();
                dataGridView6.RowCount = 1;
                for (int i = 0; i < favsa.Count; i++)
                {
                    dataGridView6.Rows.Add(favsa[i]);
                    dataGridView6.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }
    }

    static class DateTimeExtensions
    {
        static GregorianCalendar _gc = new GregorianCalendar();
        public static int GetWeekOfMonth(this DateTime time)
        {
            DateTime first = new DateTime(time.Year, time.Month, 1);
            return time.GetWeekOfYear() - first.GetWeekOfYear() + 1;
        }

        static int GetWeekOfYear(this DateTime time)
        {
            return _gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }
    }
}
