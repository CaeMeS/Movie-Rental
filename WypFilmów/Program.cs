using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypFilmów
{
    class Klient
    {
        private string imie;
        private string nazwisko;
        private int punkty;
        public Klient()
        {
            imie = "";
            nazwisko = "";
            punkty = 0;
        }
        public Klient(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
        public void ShowKlient()
        {
            Console.WriteLine("\nKlient");
            Console.WriteLine("------");
            Console.WriteLine("Imie: {0} \nNazwisko: {1} \nPunkty Stalego Klienta: {2}", imie, nazwisko, punkty);
        }
        public int Punkty
        {          
            set { punkty = value; }
        }
    }
    abstract class Film
    {
        protected string tytul;
        protected string rezyser;
        protected int rok;
        protected int czas_trwania;
        protected double cena;
        protected string rodzaj;
        public Film()
        {
            tytul = "";
            rezyser = "";
            rok = 0;
            czas_trwania = 0;
        }
        public Film(string tytul, string rezyser, int rok, int czas_trwania)
        {
            this.tytul = tytul;
            this.rezyser = rezyser;
            this.rok = rok;
            this.czas_trwania = czas_trwania;
        }
        public abstract double AddCena();
        public abstract string AddRodzaj();
        public virtual void ShowFilm()
        {
            Console.WriteLine("\nFilm");
            Console.WriteLine("----");
            Console.WriteLine("Tytul: {0} \nRezyser: {1} \nRok: {2} \nCzas trwania: {3} \nCena za dzien: {4} \nRodzaj: {5}", tytul, rezyser, rok, czas_trwania, AddCena(), AddRodzaj());
        }
        public string Tytul
        {
            get { return tytul; }
        }
    }
    class Nowosc : Film
    {
        public Nowosc()
        {
            tytul = "";
            rezyser = "";
            rok = 0;
            czas_trwania = 0;
        }
        public Nowosc(string tytul, string rezyser, int rok, int czas_trwania)
        {
            this.tytul = tytul;
            this.rezyser = rezyser;
            this.rok = rok;
            this.czas_trwania = czas_trwania;
        }
        public override double AddCena()
        {
            return cena = 7;
        }
        public override string AddRodzaj()
        {
            return rodzaj = "nowosc";
        }
    }
    class Normalny : Film
    {
        public Normalny()
        {
            tytul = "";
            rezyser = "";
            rok = 0;
            czas_trwania = 0;
        }
        public Normalny(string tytul, string rezyser, int rok, int czas_trwania)
        {
            this.tytul = tytul;
            this.rezyser = rezyser;
            this.rok = rok;
            this.czas_trwania = czas_trwania;
        }
        public override double AddCena()
        {
            return cena = 5;
        }
        public override string AddRodzaj()
        {
            return rodzaj = "normalny";
        }
    }
    class Dladzieci : Film
    {
        public Dladzieci()
        {
            tytul = "";
            rezyser = "";
            rok = 0;
            czas_trwania = 0;
        }
        public Dladzieci(string tytul, string rezyser, int rok, int czas_trwania)
        {
            this.tytul = tytul;
            this.rezyser = rezyser;
            this.rok = rok;
            this.czas_trwania = czas_trwania;
        }
        public override double AddCena()
        {
            return cena = 3;
        }
        public override string AddRodzaj()
        {
            return rodzaj = "dzieciecy";
        }
    }
    class Western : Film
    {
        public Western()
        {
            tytul = "";
            rezyser = "";
            rok = 0;
            czas_trwania = 0;
        }
        public Western(string tytul, string rezyser, int rok, int czas_trwania)
        {
            this.tytul = tytul;
            this.rezyser = rezyser;
            this.rok = rok;
            this.czas_trwania = czas_trwania;
        }
        public override double AddCena()
        {
            return cena = 4.5;
        }
        public override string AddRodzaj()
        {
            return rodzaj = "western";
        }
    }
    class Wypozyczenie
    {
        private int czas_wyp;
        public Klient a;
        public Film b;
        public Wypozyczenie()
        {
            czas_wyp = 0;
        }
        public Wypozyczenie(Klient k, Film f, int czas_wyp)
        {
            this.czas_wyp = czas_wyp;
            a = k;
            b = f;
        }
        public int PSK()
        {
            if (b.AddRodzaj() != "nowosc")        
                return 4 + czas_wyp;
            else
                return 2 * (4 + czas_wyp);
        }
        public void ShowWyp()
        {
            Console.WriteLine("\n.:Dane wypozyczenia:.");
            a.ShowKlient();
            b.ShowFilm();
            Console.WriteLine("\nWypozyczono na {0} dni", czas_wyp);
            Console.WriteLine("Kwota do zaplaty: {0}", czas_wyp * b.AddCena());
            Console.WriteLine("Otrzymane Punkty Stalego Klienta: {0}", PSK());
            a.Punkty = PSK();
        }
        public int Czas_wyp
        {
            get { return czas_wyp; }
        }
    }
    abstract class Drukowanie
    {
        public abstract void Drukuj();
    }
    class Standard : Drukowanie
    {
        private Wypozyczenie c;
        public Standard(Wypozyczenie w)
        {
            c = w;
        }
        public override void Drukuj()
        {
            Console.WriteLine("\nWydruk potwierdzenia:");
            Console.WriteLine("---------------------");
            Console.WriteLine("Tytul: {0} \nDlugosc wypozyczenia: {1} dni \nRodzaj filmu: {2} \nCena za dzien: {3} \nPodsumowanie zaplaty: {4} \nOtrzymane PSK: {5}\n", c.b.Tytul, c.Czas_wyp, c.b.AddRodzaj(), c.b.AddCena(), c.b.AddCena() * c.Czas_wyp, c.PSK());
        }
    }
    class HTML : Drukowanie
    {
        public override void Drukuj()
        {
            Console.WriteLine("\nOpcja obecnie nie dostepna\n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0, ni = 0, noi = 0, di = 0, wi = 0, idwyp = 0, Rrok = 0, Rczas = 0, x1 = 0, x2 = 0, x3 = 0;
            string Rimie, Rnazwisko, Rtytul, Rrezyser, pot;
            Klient[] k = new Klient[99];
            Film[] now = new Nowosc[99];
            Film[] nor = new Normalny[99];
            Film[] dzi = new Dladzieci[99];
            Film[] wes = new Western[99];          
            Wypozyczenie[] w = new Wypozyczenie[200];
            while (true)
            {
                Console.WriteLine("1. Dodaj Klienta");
                Console.WriteLine("2. Pokaż klientów");
                Console.WriteLine("3. Dodaj film");
                Console.WriteLine("4. Pokaż filmy");
                Console.WriteLine("5. Utworz wypozyczenie");
                Console.WriteLine("6. Pokaz wypozyczenia");
                int x = int.Parse(System.Console.ReadLine());
                switch (x)
                {
                    case 1:                       
                        Console.WriteLine("\nImie:");
                        Rimie = Console.ReadLine();
                        Console.WriteLine("Nazwisko:");
                        Rnazwisko = Console.ReadLine();
                        Console.WriteLine("\nDodano\n");
                        k[i] = new Klient(Rimie, Rnazwisko);
                        i++;
                        break;
                    case 2:
                        if(i == 0)
                            Console.WriteLine("\nBrak klientow w bazie\n");
                        else                     
                            for (int j = 0; j < i; j++)
                            {                                
                                k[j].ShowKlient();
                                Console.WriteLine("ID: {0}\n", j);
                            }                                                
                        break;
                    case 3:
                        Console.WriteLine("\nTytul:");
                        Rtytul = Console.ReadLine();
                        Console.WriteLine("Rezyser:");
                        Rrezyser = Console.ReadLine();
                        Console.WriteLine("Rok produkcji:");
                        Rrok = int.Parse(System.Console.ReadLine());
                        Console.WriteLine("Czas trwania:");
                        Rczas = int.Parse(System.Console.ReadLine());
                        Console.WriteLine("\nWybierz kategorie");
                        Console.WriteLine("1. Nowosc");
                        Console.WriteLine("2. Normalny");
                        Console.WriteLine("3. Dzieciecy");
                        Console.WriteLine("4. Western");
                        int y = int.Parse(System.Console.ReadLine());
                        switch (y)
                        {
                            case 1:
                                now[ni] = new Nowosc(Rtytul, Rrezyser, Rrok, Rczas);
                                ni++;
                                break;
                            case 2:
                                nor[noi] = new Normalny(Rtytul, Rrezyser, Rrok, Rczas);
                                noi++;
                                break;
                            case 3:
                                dzi[di] = new Dladzieci(Rtytul, Rrezyser, Rrok, Rczas);
                                di++;
                                break;
                            case 4:
                                wes[wi] = new Western(Rtytul, Rrezyser, Rrok, Rczas);
                                wi++;
                                break;
                            default:
                                Console.WriteLine("\nNiepoprawny wybor\n");
                                break;
                        }
                        Console.WriteLine("\nDodano\n");
                        break;
                    case 4:                      
                        if (ni + noi + di + wi == 0)
                            Console.WriteLine("\n~Brak filmow w bazie~\n");
                        else
                            for (int j = 0; j < ni; j++)
                            {
                                now[j].ShowFilm();
                                Console.WriteLine("ID: {0}\n", j);
                            }                                                                           
                            for (int j = 0; j < noi; j++)
                            {
                                nor[j].ShowFilm();
                                Console.WriteLine("ID: {0}\n", j+ni);
                            }                                                       
                            for (int j = 0; j < di; j++)
                            {
                                dzi[j].ShowFilm();
                                Console.WriteLine("ID: {0}\n", j+ni+noi);
                            }                                                        
                            for (int j = 0; j < wi; j++)
                            {
                                wes[j].ShowFilm();
                                Console.WriteLine("ID: {0}\n", j+ni+noi+di);
                            }                                
                        break;
                    case 5:
                        if (i == 0 || ni + noi + di + wi == 0)
                            Console.WriteLine("\nZa malo danych w bazie\n");
                        else
                        {
                            Console.WriteLine("\nWybierz ID klienta:");
                            for (int j = 0; j < i; j++)
                            {
                                k[j].ShowKlient();
                                Console.WriteLine("ID: {0}", j);
                            }
                            x1 = int.Parse(System.Console.ReadLine());
                            if(x1 > i || x1 < 0)
                            {
                                Console.WriteLine("\nBrak takiego ID\n");
                                break;
                            }                            
                            Console.WriteLine("\nWybierz ID filmu:");
                            for (int j = 0; j < ni; j++)
                            {
                                now[j].ShowFilm();
                                Console.WriteLine("ID: {0}", j);
                            }
                            for (int j = 0; j < noi; j++)
                            {
                                nor[j].ShowFilm();
                                Console.WriteLine("ID: {0}", j + ni);
                            }
                            for (int j = 0; j < di; j++)
                            {
                                dzi[j].ShowFilm();
                                Console.WriteLine("ID: {0}", j + ni + noi);
                            }
                            for (int j = 0; j < wi; j++)
                            {
                                wes[j].ShowFilm();
                                Console.WriteLine("ID: {0}", j + ni + noi + di);
                            }
                            x2 = int.Parse(System.Console.ReadLine());                            
                            if (x2 < 0 || x2 > ni + noi + di + wi)
                            {
                                Console.WriteLine("\nBrak takiego ID\n");
                                break;
                            }
                            Console.WriteLine("\nPodaj czas wypozyczenia:");
                            x3 = int.Parse(System.Console.ReadLine());
                            if (x2 < ni)
                            {
                                w[idwyp] = new Wypozyczenie(k[x1], now[x2], x3);
                                idwyp++;
                                Console.WriteLine("\nDodano pomyślnie\n");
                            }
                            else if (x2 < ni + noi)
                            {
                                w[idwyp] = new Wypozyczenie(k[x1], nor[x2], x3);
                                idwyp++;
                                Console.WriteLine("\nDodano pomyślnie\n");
                            }
                            else if (x2 < ni + noi + di)
                            {
                                w[idwyp] = new Wypozyczenie(k[x1], dzi[x2], x3);
                                idwyp++;
                                Console.WriteLine("\nDodano pomyślnie\n");
                            }
                            else if (x2 < ni + noi + di + wi)
                            {
                                w[idwyp] = new Wypozyczenie(k[x1], wes[x2], x3);
                                idwyp++;
                                Console.WriteLine("\nDodano pomyślnie\n");
                            }
                            else
                                Console.WriteLine("\nError: sprobuj ponownie\n");
                        }
                        break;                        
                    case 6:
                        if (idwyp == 0)
                            Console.WriteLine("\nBrak wypozyczen\n");
                        else
                        {
                            for (int j = 0; j < idwyp; j++)
                            {
                                w[j].ShowWyp();
                                Console.WriteLine("ID: {0}", j);
                            }
                            Console.WriteLine("\nCzy chcesz wydrukowac potwierdzenie wypozycznia?(tak/nie)");
                            pot = Console.ReadLine();
                            if(pot == "tak")
                            {
                                Console.WriteLine("\nPodaj ID wypozyczenia");
                                int idw = int.Parse(System.Console.ReadLine());
                                if(idw > idwyp || idw < 0)
                                    Console.WriteLine("\nBrak takiego ID\n");
                                else
                                {
                                    Console.WriteLine("\nWersja standardowa, czy online?(s/o)");
                                    pot = Console.ReadLine();
                                    if (pot == "s")
                                    {
                                        Drukowanie d = new Standard(w[idw]);
                                        d.Drukuj();
                                    }
                                    else if(pot == "o")
                                    {
                                        Drukowanie d = new HTML();
                                        d.Drukuj();
                                    }
                                    else
                                        Console.WriteLine("\nNiepoprawny wybor\n");
                                }                               
                            }
                        }                           
                        break;
                    default:
                        Console.WriteLine("\nNiepoprawny wybor\n");
                        break;
               }
            }                                
        }       
    }
}