using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Krujz_Gergely_p71jvi_beadando_prog2
{
    public delegate void KiirasSablon(); // eventhez tartozó delegált
    public interface Izene // 1. feladat
    {
        int idotartam { get; set; }
        int ertekeles { get; set; }
        int tarhely { get; set; }
    }
    class komolyzene : Izene
    {
        string zeneszero;
        string cim;
        int hossz;
        int ertekeles1;
        int tarhely1;
        public int ertekeles
        {
            get
            {
                return ertekeles1;
            }

            set
            {
                ertekeles1 = value;
            }
        }

        public int idotartam
        {
            get
            {
                return hossz;
            }

            set
            {
                hossz = value;
            }
        }

        public int tarhely
        {
            get
            {
                return tarhely1;
            }

            set
            {
                tarhely1 = value;
            }
        }

        public string Zeneszero
        {
            get
            {
                return zeneszero;
            }

            set
            {
                zeneszero = value;
            }
        }

        public string Cim
        {
            get
            {
                return cim;
            }

            set
            {
                cim = value;
            }
        }
        public komolyzene(string zeneszero, string cim, int hossz, int ertekeles1, int tarhely1)
        {
            this.zeneszero = zeneszero;
            this.cim = cim;
            this.hossz = hossz;
            this.ertekeles1 = ertekeles1;
            this.tarhely1 = tarhely1;
        }
    } // 2. feladat /a
    class konnyuzene : Izene
    {
        string eloado;
        string cim;
        int hossz;
        int ertekeles1;
        int tarhely1;

        public string Eloado
        {
            get
            {
                return eloado;
            }

            set
            {
                eloado = value;
            }
        }

        public string Cim
        {
            get
            {
                return cim;
            }

            set
            {
                cim = value;
            }
        }

        public int idotartam
        {
            get
            {
                return hossz;
            }

            set
            {
                hossz = value;
            }
        }

        public int ertekeles
        {
            get
            {
                return ertekeles1;
            }

            set
            {
                ertekeles1 = value;
            }
        }

        public int tarhely
        {
            get
            {
                return tarhely1;
            }

            set
            {
                tarhely1 = value;
            }
        }
        public konnyuzene(string eloado, string cim, int hossz, int ertekeles1, int tarhely1)
        {
            this.eloado = eloado;
            this.cim = cim;
            this.hossz = hossz;
            this.ertekeles1 = ertekeles1;
            this.tarhely1 = tarhely1;
        }
    } // 2. feladat /b
    class sajatzene : Izene
    {
        int ertekeles1;
        int idotartam1;
        int tarhely1;
        public int ertekeles
        {
            get
            {
                return 5;
            }

            set
            {
                ertekeles1 = value;
            }
        }

        public int idotartam
        {
            get
            {
                return idotartam1;
            }

            set
            {
                idotartam1 = value;
            }
        }

        public int tarhely
        {
            get
            {
                return tarhely1;
            }

            set
            {
                tarhely1 = value;
            }
        }

        public sajatzene(int tarhely, int idotartam1)
        {
            this.ertekeles1 = 5;
            this.idotartam1 = idotartam1;
            this.tarhely1 = tarhely;
        }
    } // 2. feladat /c
    public class lejatszo<t> where t : Izene // binaris fa elkészítése a metódusaival együtt
    {
        public event KiirasSablon lejatszaskiiras; //event 1
        public event KiirasSablon ertekeles_valtozas_kiiras; //event 2
        public event KiirasSablon uj_szam_feltoltes_kiiras; //event 3
        public event KiirasSablon regi_szamok_torlese_kiiras; //event 4

        public class binaris_fa // bináris faelem beágyazva
        {
            // a felvett adatai a bináris fának
            public List<t> adatok; // listában is tárolunk ,mert  esetleg olyan helyzet alakulhat ki ,ahol az értékelések megegyeznek.
            public int ertekeles; // a kulcs
            public binaris_fa balelem;
            public binaris_fa jobbelem;

            public int Tarhely // kiszámoljuk, hogy mekkora az eddig lefoglalt memória ,úgy hogy összaadogatjuk a tárhelyeket
            {
                get
                {
                    int lefoglalt = 0;
                    foreach (var item in adatok)
                    {
                        lefoglalt += item.tarhely;
                    }
                    return lefoglalt;
                }

            }

            public binaris_fa(t adatok, int kulcs) // bináris fa konstruktor
            {
                this.adatok = new List<t>();
                this.ertekeles = kulcs;
                this.adatok.Add(adatok);
            }

            public override string ToString()
            {

                string kimenet = "";
                foreach (var item in adatok)
                {
                    if (item is komolyzene)
                    {
                        kimenet += (item as komolyzene).Zeneszero + " - " + (item as komolyzene).Cim + " Mérete: " + (item as komolyzene).tarhely + " MB Hossza " + (item as komolyzene).idotartam + " sec Értékelése: " + (item as komolyzene).ertekeles + "\n";
                    }
                    else if (item is konnyuzene)
                    {
                        kimenet += kimenet += (item as konnyuzene).Eloado + " - " + (item as konnyuzene).Cim + " Mérete: " + (item as konnyuzene).tarhely + " MB Hossza " + (item as konnyuzene).idotartam + " sec Értékelése: " + (item as konnyuzene).ertekeles + "\n";
                    }
                    else if (item is sajatzene)
                    {
                        kimenet += "A saját zenéd Mérete: " + (item as sajatzene).tarhely + "  MB Hossza: " + (item as sajatzene).idotartam + " sec\n";
                    }
                }
                return kimenet;
            } // kiiratás foreach-el
        }


        public void Kiiras() //Kiírja a zenéket
        {
            Kiiras_privat(ref gyoker);
        }

        void Kiiras_privat(ref binaris_fa p) //postorder 
        {
            
            if (p != null)
            {
                Kiiras_privat(ref p.balelem);
                Kiiras_privat(ref p.jobbelem);
                Console.WriteLine(p.ToString());
            }
        }



        binaris_fa gyoker; // a bináris fa gyökere
        int meret; // a lejátszó teljes mérete amit a programban adunk be a ctorba

        public lejatszo(int meret) // lejatszo konstruktora ahol,a meretet bekérjük
        {

            this.meret = meret;
        }


        public void Beszuras(ref binaris_fa p, t tartalom, int kulcs) // A beszúrja a bináris fába az adatokat
        {
            if (p == null) // megvizsgáljuk, hogy nem null az érték, ha igen akkor létrehozunk 1 újat
            {
                p = new binaris_fa(tartalom, kulcs);
            }
            else if (kulcs > p.ertekeles) // pszeudokód szerint beszúrunk
            {
                Beszuras(ref p.jobbelem, tartalom, kulcs);
            }
            else if (kulcs < p.ertekeles) // pszeudokód szerint beszúrunk
            {
                Beszuras(ref p.balelem, tartalom, kulcs);
            }
            else
            {
                foreach (t elem in p.adatok) // Megvizsgaljuk ,hogy létezik -e ez a zene már, és ha igen akkor  MarVanIlyenZeneException -t dobunk
                {
                    if ((tartalom is konnyuzene) && (elem is konnyuzene))
                    {
                        if ((elem as konnyuzene).Cim == (tartalom as konnyuzene).Cim && ((elem as konnyuzene).Eloado == (tartalom as konnyuzene).Eloado))
                        {

                            throw new MarVanIlyenZeneException();

                        }

                    }
                    else if ((tartalom is komolyzene) && (elem is komolyzene))
                    {
                        if ((elem as komolyzene).Cim == (tartalom as komolyzene).Cim && ((elem as komolyzene).Zeneszero == (tartalom as komolyzene).Zeneszero))
                        {

                            throw new MarVanIlyenZeneException();

                        }

                    }
                    else if ((tartalom is sajatzene) && (elem is sajatzene))
                    {
                        if ((elem as sajatzene).tarhely == (tartalom as sajatzene).tarhely && ((elem as sajatzene).idotartam == (tartalom as sajatzene).idotartam))
                        {

                            throw new MarVanIlyenZeneException();

                        }

                    }

                }
                p.adatok.Add(tartalom); // ADDoljuk a listahoz
            }
        }
       

        public void MemoriaKartyaMeret(binaris_fa p, ref int meret_osszes) // postorder bejaras, az órán tanultak szerint, megnézzük ,hogy mekkora a memoria mérete.
        {
            if (p != null)
            {
                MemoriaKartyaMeret(p.balelem, ref meret_osszes);
                MemoriaKartyaMeret(p.jobbelem, ref meret_osszes);
                meret_osszes += p.Tarhely;
            }


        }
        //UjZeneFeltoltes metódusban megtalálható
        public binaris_fa  LegalacsonyabbErtekeles(binaris_fa p) // ha nem fér el a szám, akkor a legalacsonyabban értékelt számokat töröljük .v
        {
            if (p != null)
            {
                binaris_fa minelem = p;

                if (p.balelem != null && p.ertekeles < p.balelem.ertekeles )
                {
                    return minelem = LegalacsonyabbErtekeles(p.balelem);
                }
                else
                {
                    return minelem;
                }
            }
            else
            {
                throw new Exception();
            }
        }
        //UjZeneFeltoltes metódusban megtalálható


       
      
        
        public void Torles_fajtak(ref binaris_fa p, int kulcs) // órán vett anyag (elemek törlése a bináris fában)
        {
            // az "e" elem törlését végzi el a "p" gyökerű részfában
            if (p != null)
            {
                if (p.ertekeles.Equals(kulcs))
                {
                    // megvan a törlendő elem
                    if (p.balelem == null && p.jobbelem == null)
                    {
                        // 0 gyermek (levél)
                        p = null;
                    }
                    else if (p.balelem == null && p.jobbelem != null)
                    {
                        // 1 gyermek (jobb)
                        p = p.jobbelem;
                    }
                    else if (p.jobbelem == null && p.balelem != null)
                    {
                        // 1 gyermek (bal)
                        p = p.balelem;
                    }
                    else if (p.balelem != null && p.jobbelem != null)
                    {
                        // 2 gyermek (bal és jobb)
                        KetGyermekTorlese(ref p, ref p.balelem);
                    }
                }
                else if (p.ertekeles < kulcs)
                {
                    Torles_fajtak(ref p.jobbelem, kulcs);
                }
                else Torles_fajtak(ref p.balelem, kulcs);
            }
            else
                throw new Exception("Nincs ilyen elem törlésnél.");
        }
        //MegmaradtUresElemekTorlesében találtaho
        public void KetGyermekTorlese(ref binaris_fa e, ref binaris_fa r)
        {

            if (r.jobbelem != null)
                KetGyermekTorlese(ref e, ref r.jobbelem);
            else
            {
                e.adatok = r.adatok;
                e.ertekeles = r.ertekeles;
                r = r.balelem;
            }
        }
        // UjZeneFeltoltes metódusban megtalálható
        public void UjZeneFeltoltes(t adatok, int kulcs) // új zene fetöltése
        {
            int meret_0 = 0;
           

            Beszuras(ref gyoker, adatok, kulcs);
            uj_szam_feltoltes_kiiras(); // esemény elsütés
            MemoriaKartyaMeret(gyoker, ref meret_0);


            if (meret_0 > meret) // megvizsgáljuk ,hogy a lejátszó mérete kisebb -e a memoriakártya méreténél, ha nem akkor törlés
            {
                while (!(meret_0 < meret))
                {
                    binaris_fa legalacsonyabbElem = LegalacsonyabbErtekeles(gyoker);
                    Torles_fajtak(ref gyoker, legalacsonyabbElem.ertekeles);
                    meret_0 -= legalacsonyabbElem.adatok[0].tarhely;
                    if (legalacsonyabbElem.adatok.Count > 1)
                    {
                        for (int i = 0; i < legalacsonyabbElem.adatok.Count; i++)
                        {
                            regi_szamok_torlese_kiiras?.Invoke();
                        }
                    }
                    else
                    {
                        regi_szamok_torlese_kiiras?.Invoke();
                    }
                }
            }
          

        }
        public void lejatszas(lejatszo<t> lejatszo1, int meret) // lejátszás metódus ami létrehozza a binaris fát, és lefuttatja a "lejatszas" metódust
        {
            lejatszo1 = new lejatszo<t>(meret); // megadjuk a méretet
            lejatszas(gyoker, ref lejatszo1);

        }

        public void lejatszas(binaris_fa p, ref lejatszo<t> lejatszas_0)
        {
            string beirt = ""; // amiben leírja a felhasználó  hogy tetszett e neki, e vagy sem a zene
            int beirt_ertekeles = 0;  // amiben értékel a felhasználó
                                      // do while azért kell ,mert ha mellé ütünk ne legyen hiba
            bool igaz_e = false;// külső do while ha a beirt adat i vagy n akkor kilép a do whileból
            bool igaz_e2 = false; // belső do while ha a beírt adattal nem lesz több vag kevesebb az értékelés mint 5 kilép a do whileból
            int elozo_ertekeles = 0; // kell mert szeretnék a hallgatók ,hogy kiírjam nekik a jelenlegi értékelést ,hogy tudják azt ,hogy mennyit lehet változtatni rajta
            if (p != null)
            {
                lejatszas(p.balelem, ref lejatszas_0);
                lejatszas(p.jobbelem, ref lejatszas_0);
                for (int i = 0; i < p.adatok.Count; i++) //a listát átpörgetjük és csak a végéig megyünk
                {
                    t adat = p.adatok[i]; //a mostani adatokat lementjük , hogy a metódus végén felhasználjuk
                    elozo_ertekeles = adat.ertekeles; // kell hogy kitudjuk iratni az eredeti értéket
                    do
                    {


                        Console.WriteLine("Az " + (i + 1) + ". zeneszám lejátszódott. Hogy tetszett? // (i) - igen tetszett ! , (n) - nem tetszett");
                        beirt = Console.ReadLine();
                        Console.Clear();



                        if (beirt == "i")
                        {
                            igaz_e = true;
                            do
                            {

                                Console.WriteLine("Látom tetszett a zene");
                                Console.WriteLine("Eredeti értékelés: {0}", elozo_ertekeles);
                                Console.WriteLine("Mennyivel szeretnéd növelni az értékelést ? ");
                                beirt_ertekeles = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();


                                if (adat.ertekeles + beirt_ertekeles <= 5)
                                {

                                    igaz_e2 = true;
                                }
                                else
                                {
                                    igaz_e2 = false;

                                    Console.WriteLine("Az értékelésed meghaladja az 5-ös (maximum értéket)! jelenlegi értékelés : {0}", adat.ertekeles);
                                    Console.WriteLine("Nyomj egy ENTER -t az újrapróbálkozáshoz");
                                    Console.ReadLine();
                                    Console.Clear();

                                }

                            } while (igaz_e2 != true);
                            adat.ertekeles = adat.ertekeles + beirt_ertekeles; // ha megfelelt ,akkor hozzáadjuk az értékelést
                        }
                        else if (beirt == "n")
                        {
                            igaz_e = true;
                            do
                            {

                                Console.WriteLine("Látom nem tetszett a zene");
                                Console.WriteLine("Eredeti értékelés: {0}", elozo_ertekeles);
                                Console.WriteLine("Mennyivel szeretnéd csökkenteni az értékelést ? ");

                                beirt_ertekeles = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();


                                if (adat.ertekeles - beirt_ertekeles > 0)
                                {
                                    igaz_e2 = true;
                                }
                                else
                                {
                                    igaz_e2 = false;

                                    Console.WriteLine("Az értékelésed nem éri el a 0-ás (minimum értéket)! jelenlegi értékelés : {0}", adat.ertekeles);
                                    Console.WriteLine("Nyomj egy ENTER -t az újrapróbálkozáshoz");
                                    Console.ReadLine();
                                    Console.Clear();

                                }

                            } while (igaz_e2 != true);

                            adat.ertekeles = adat.ertekeles - beirt_ertekeles; // ha megfelelt kivonjuk
                        }
                        else
                        {
                            igaz_e = false;

                            Console.WriteLine("Nem jó gombot ütöttél le, lehet csak megcsúszott a kezed :). A beirt adatod {0} ", beirt);
                            Console.WriteLine("Kérlek az ENTER-gomb lenyomása után próbáld újra !");
                            Console.ReadLine();
                            Console.Clear();

                        }

                    } while (igaz_e != true);


                    Console.WriteLine("Szuper, az értékelés megváltozott! (kivéve ha 0-át írtál be, te kis sunyi :) )");
                    Console.WriteLine("Eredeti értékelés: {0}", elozo_ertekeles);
                    Console.WriteLine("Új értékelés: {0}", adat.ertekeles);
                    Console.WriteLine("Az ENTER lenyomásával tovább léphetsz");
                    ertekeles_valtozas_kiiras?.Invoke(); // esemény elsütés
                    Console.ReadLine();
                    Console.Clear();
                    lejatszaskiiras?.Invoke(); // esemény elsütés




                }
            }

        } // itt történik az zenék meghallgatása és értékelése

    } //3. , 4., 5.,6. feladatok

    class MarVanIlyenZeneException : Exception
    {
        public MarVanIlyenZeneException() : base("A zene amit felszeretnél tölteni már létezik !")
        {

        }
    } //4. feladat
    class MegteltAMemoriaException : Exception
    {
        public MegteltAMemoriaException() : base("A memória megtelt !")
        {

        }
    } //5. feladat


    static class Naplozas //esemeny , mindegyik metódus kiírja  a log.txt fáljba ,hogy mikor mi történt 7. feladat
    {
        public static void ZeneLejatszas()
        {
            DateTime dt = DateTime.Now;
            StreamWriter sw = new StreamWriter("log.txt", true);
            Console.Beep();
            Console.WriteLine("A Zene lejátszódott");
            Console.WriteLine();
            sw.WriteLine("A Zene lejátszódott : " + dt);

            sw.Close();
        }
        public static void Ertekeles_Megvaltozas()
        {
            DateTime dt = DateTime.Now;
            StreamWriter sw2 = new StreamWriter("log.txt", true);
            Console.WriteLine("Az értékelés megváltozott");
            Console.WriteLine();
            sw2.WriteLine("Az értékelés megváltozott" + dt);
            sw2.Close();


        }
        public static void Uj_szam_feltoltese()
        {
            DateTime dt = DateTime.Now;
            StreamWriter sw3 = new StreamWriter("log.txt", true);
            Console.WriteLine("Új számok feltöltésének kísérlete");
            Console.WriteLine();
            sw3.WriteLine("Új számok feltöltésének kísérlete" + dt);

            sw3.Close();
        }
        public static void Regi_szamok_torlese()
        {
            DateTime dt = DateTime.Now;
            StreamWriter sw4 = new StreamWriter("log.txt", true);
            Console.WriteLine("A Zeneszám törlése végrehajtódott");
            Console.WriteLine();
            sw4.WriteLine("A Zeneszám törlése végrehajtódott" + dt);
            sw4.Close();


        }

    }

    class Program
    {
        public static void Beolvasas_Feltoltes(lejatszo<Izene> lejatszo) // Beolvassuk a zenéket
        {
            Console.Clear();
            StreamReader sr = new StreamReader("beolvas.txt");
            string[] sor;


            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine().Split(';');

                if (sor[0] == "konnyuzene")
                {
                    if (int.Parse(sor[4]) > 100000)
                    {
                        Console.WriteLine("Sajnos ez a fájl túl nagy méretű volt ezért nem töltődött fel");
                    }
                    else
                    {
                        lejatszo.UjZeneFeltoltes(new komolyzene(sor[1], sor[2], int.Parse(sor[3]), int.Parse(sor[5]), int.Parse(sor[4])), int.Parse(sor[5]));

                    }

                }
                else if (sor[0] == "komolyzene")
                {
                    if (int.Parse(sor[4]) > 100000)
                    {
                        Console.WriteLine("Sajnos ez a fájl túl nagy méretű volt ezért nem töltődött fel");
                    }
                    else
                    {
                        lejatszo.UjZeneFeltoltes(new komolyzene(sor[1], sor[2], int.Parse(sor[3]), int.Parse(sor[5]), int.Parse(sor[4])), int.Parse(sor[5]));
                    }
                }
                else if (sor[0] == "sajatzene")
                {
                    if (int.Parse(sor[2]) > 100000)
                    {
                        Console.WriteLine("Sajnos ez a fájl túl nagy méretű volt ezért nem töltődött fel");
                    }
                    else
                    {
                        lejatszo.UjZeneFeltoltes(new sajatzene(int.Parse(sor[2]), int.Parse(sor[1])), 5);
                    }
                }
            }
            Console.ReadLine();
            Console.Clear();
            sr.Close();

        }
        static void Main(string[] args)
        {
            int meret = 100000; // a mérete a memóriának
            try
            {
                string exit; // a felhasználói bevitel
                int db = 0; // ennek a kicsi darab változónak a lényege ,hogy ha egyszer lefutott a Beolvasas_Feltoltes akkor már nem töltünk fel újra, hanem már megvan az összes zeneszám egy stringbe beletöltve
                            // és ha már megvan, az összes string léptetjük a db ot és ha 2 szer léptettük , már csak a zeneszámokat és adatait írja ki majd nekünk 
                            //példányosítás
                lejatszo<Izene> lejatszo = new lejatszo<Izene>(meret);

                //Feliratkoztatások 7. feladat
                lejatszo.ertekeles_valtozas_kiiras += Naplozas.Ertekeles_Megvaltozas;
                lejatszo.lejatszaskiiras += Naplozas.ZeneLejatszas;
                lejatszo.regi_szamok_torlese_kiiras += Naplozas.Regi_szamok_torlese;
                lejatszo.uj_szam_feltoltes_kiiras += Naplozas.Uj_szam_feltoltese;




                //menürendszer
                do
                {
                    db++; // db változó léptetése
                    Console.Title = "A saját zenelejátszód : Menü";
                    Console.WriteLine("Warning: ( A 2 -es menüpont csak az 1. feltöltés után működik , ezért kérlek nyomd meg az 1-es gombot");
                    Console.WriteLine("1 - A zenéid feltöltése / megtekintése");
                    Console.WriteLine("2 - A zenéid meghallgatása ");
                    Console.WriteLine("esc - kilépés");
                    exit = Console.ReadLine(); // felhasználói bevitel
                    if (exit.Equals("1"))
                    {
                        if (db < 2)
                        {
                            Beolvasas_Feltoltes(lejatszo); // itt beolvassa a zenéidet a fájlból majd megnézi h megfelelő-e a méret , ha igen akkor feltölti 
                        }
                        else
                        {
                            Console.Clear();
                            Console.Title = " Könyvtárad ";
                            lejatszo.Kiiras();
                            Console.ReadLine();
                            Console.Clear();

                        }


                    }
                    else if (exit.Equals("2"))
                    {
                        Console.Clear();
                        Console.Title = "A saját zenelejátszód";
                        lejatszo.lejatszas(lejatszo, meret);
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (exit.Equals("esc"))
                    {
                        Console.Clear();
                        Console.Title = "A saját zenelejátszód : kilépés";
                        Console.WriteLine("Most kilépsz a zenelejátszóból, köszönjük hogy minket választottál ! További szép napot :)");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Mellényúltál ,az ENTER -lenyomása után próbáld újra");
                        Console.ReadLine();
                        Console.Clear();
                    }

                } while (!exit.Equals("esc"));


            }
            catch (MarVanIlyenZeneException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (MegteltAMemoriaException e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}

