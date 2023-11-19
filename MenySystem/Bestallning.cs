using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_klasser_inner_outer
{   //ide från will att använda klasser i en klass
    internal class Bestallning
    {
        public List<string> egenskapHam;
        public List<string> egenskapTill;
        public List<string> egenskapDryck;

        public Bestallning(List<string> mvalHambugare, List<string> mvalTillbehör, List<string> mvalDryck)
        {
            egenskapHam = mvalHambugare;
            egenskapTill = mvalTillbehör;
            egenskapDryck = mvalDryck;
        }

        //Tar in listorna av egenskaperna beroende på vad användaren har valt och skapar en lista av dessa
        //den skapade listan blir då en beställning
        public List<List<string>> EgenskapValBestallning() //List<string> egHam, List<string> egTill, List<string> egDryck
        { 
            List<List<string>> listEnbestallning = new List<List<string>>();

            listEnbestallning.Add(egenskapHam);
            listEnbestallning.Add(egenskapTill);
            listEnbestallning.Add(egenskapDryck);

            return listEnbestallning;
        }

        public int FaPrisTotal()
        {
            int totalPris = Convert.ToInt32(egenskapHam[1]) + Convert.ToInt32(egenskapTill[1]) + Convert.ToInt32(egenskapDryck[1]);
            return totalPris;
        }

        public int FaKalTotal()
        {
            int totalKal = Convert.ToInt32(egenskapHam[2]) + Convert.ToInt32(egenskapTill[2]) + Convert.ToInt32(egenskapDryck[2]);
            return totalKal;
        }

        //klass för hamburgare
        public class Hamburgare
        {
            public string namn;
            public List<string> ingredienser;
            public string kalorier;
            public string pris;

            public Hamburgare(string mNamn, List<string> mIngredienser, string mKalorier, string mPris)
            {
                namn = mNamn;
                ingredienser = mIngredienser;
                kalorier = mKalorier;
                pris = mPris;
            }

            //används för att få tillbaka en lista av egenskaper från det objekt som användaren har valt, i detta fall val av hamburgare
            //ta ett objek i listanObjekt beroende på position och retunera en lista av egenskaper från objektet
            public static List<string> ReturnValHam(List<Hamburgare> listaObjekt, int position)
            {

                List<string> egenskaperAvObjekt = new List<string>();

                string Namn = listaObjekt[position].namn; 
                string pris = listaObjekt[position].pris;
                string kal = listaObjekt[position].kalorier;

                egenskaperAvObjekt.Add(Namn);
                egenskaperAvObjekt.Add(pris);
                egenskaperAvObjekt.Add(kal);

                return egenskaperAvObjekt;
            }

            //metod som loopar igenom ingredienserna från listan --> får ut alla ingredienser för specifik hamburgare --> ge ut en array med enbart namn, pris eller kalorier
            public void FaIngredienser()
            {
                Console.WriteLine($"\n{namn} innehåller: ");
                foreach (string ingred in ingredienser)
                {
                    Console.WriteLine($"\t{ingred} ");
                }
            }
        }

        //klass för tillbehör
        public class Tillbehor 
        {
            public string namn;
            public string pris;
            public string kalorier;


            public Tillbehor(string mName, string mKalorier, string mPris)
            {
                namn = mName;
                kalorier = mKalorier;
                pris = mPris;
            }
            //samma metod som returnValHam fast för tillbehör
            public static List<string> ReturnValTill(List<Tillbehor> listaObjekt, int position)
            {
                List<string> egenskaperAvObjekt = new List<string>();

                string Namn = listaObjekt[position].namn;
                string pris = listaObjekt[position].pris;
                string kal = listaObjekt[position].kalorier;
                
                egenskaperAvObjekt.Add(Namn);
                egenskaperAvObjekt.Add(pris);
                egenskaperAvObjekt.Add(kal);
                
                return egenskaperAvObjekt;
            }
        }

        //klass för Dryck
        public class Dryck 
        {
            public string namn;
            public string pris;
            public string kalorier;


            public Dryck(string mName, string mKalorier, string mPris)
            {
                namn = mName;
                kalorier = mKalorier;
                pris = mPris;
            }

            //samma metod som returnValHam fast för tillbehör
            public static List<string> ReturnValDryck(List<Dryck> listaObjekt, int position)
            {
                List<string> egenskaperAvObjekt = new List<string>();

                string Namn = listaObjekt[position].namn;
                string pris = listaObjekt[position].pris;
                string kal = listaObjekt[position].kalorier;
                
                egenskaperAvObjekt.Add(Namn);
                egenskaperAvObjekt.Add(pris);
                egenskaperAvObjekt.Add(kal);
                
                return egenskaperAvObjekt;
            }
        }
    }
}
