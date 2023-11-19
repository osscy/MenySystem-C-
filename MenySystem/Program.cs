/*
 * Iden med detta pogram är att kunna göra en beställning av en eller flera menyer samt singel produkter
 * Pogrammet kommer sedan att skriva ut vad användaren har beställt, i meny samt singel produkt och spara ner detta i en txt som kan ses som ett kvitto
 * 
 * Användaren får välja mellan 4 olika hamburgare (listan typHamburgare), 4 olika tillbehör (listan TypTillbehor) och 4 olika drycker (listan typDryck)
 * 
 * Pogrammet kommer först fråga användaren om de vill beställa meny eller en singel produkt. Beroende på vad användaren har valt går pogrammet in i case 1 eller case 2
 * 
 * case 1: kommer fråga användaren med att välja meny, får välja mellan hamburgare, tillbehör och dryck. 
 * Beroende på vad användaren har valt kommer ett objekt Bestallning skapas som har egenskaper som är en lista av ex en Hamburgares egenskaper.
 * En metod kommer sedan ta denna lista av genskaper och lagra i en lista som blir en beställning.
 * En beställning kommer vara en lista som består av 3 andra listor som består av egenskaperna av ham,till och dryck. 
 * En beställning kommer sedan att lagras i listan allaBestallningar.
 * 
 * case 2: Frågar om användaren vill köpa en produkt. Pogrammet går in i metoden: ValAvEnProdukt där användaren får välja en produkt. 
 * Denna metod kommer retunera en lista av produktens egenskaper som sedan lagras i listan enProduktLista.
 * 
 * Pris och kalorier kommer också lagras i två separata variabler.
 * 
 * Sedan kommer metoden: bestallaIgen. Denna kommer retunera true or false beroende på om användaren vill beställa igen eller inte. 
 * 
 * Vill användaren inte det kommer allt som användaren ha valt skrivas ut med hjälp av skrivUtBestallning metoden. Denna metod kommer också
 * spara till en txt file som sedan kan "ses" som ett kvitto. 
 *
 *
 * Jag siktar på VG
 * Gjord av Oscar Bergling.
 */


namespace Test_klasser_inner_outer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //lista med alla olika typer av hamburgare, tillbehör och dryck
            List<string> typHamburgare = new List<string> { "Cheeseburgare: 70kr", "Doubelcheeseburgare: 100kr", "Orginalburgare: 79kr", "Specialburgare: 110kr" };
            List<string> typTillbehor = new List<string> { "Pommes frites: 18kr", "Bönsallad: 20kr", "Lökringar: 22kr", "Minimorötter: 16kr" };
            List<string> typDryck = new List<string> { "Cola (0,5L): 22kr", "Fanta (05L): 22kr", "Ramlösa (33cl): 25kr", "Äpplejuice (25cl): 17kr" };

            //lista av alla objekt
            List<Bestallning.Hamburgare> minaHamburgar = new List<Bestallning.Hamburgare>();
            List<Bestallning.Tillbehor> minaTillbehor = new List<Bestallning.Tillbehor>();
            List<Bestallning.Dryck> minaDrycker = new List<Bestallning.Dryck>();

            //minHamburgare innehålle en lista av objekten av hamburgare, samma för alla fast med tillbehör och drycker
            HamburgarObjekt(minaHamburgar);
            TillbehorObjekt(minaTillbehor);
            DryckObjekt(minaDrycker);

            //lagrar beställningar
            List<List<List<string>>> allabestallningar = new List<List<List<string>>>();

            //lagrar ifall användaren väljär att köpa någon singel produkt
            List<List<string>> enProduktLista = new List<List<string>>();

            //lagra totala priset
            int totalPris = 0;
            //lagra total antal kalorier
            int totalKal = 0; 


            bool bestallaNogotMer = true;
            int valMenyEnProd = 0;

            Console.WriteLine("Hej och välkommen!");

            while (bestallaNogotMer) //denna loop avlutas om användaren inte vill beställa något mer
            {
                Console.Write("\nSkriv (1) för att beställa meny." +
                            "\nSkriv (2) för att beställa enstaka produkt." +
                            "\nSkriv här: ");

                bool bestaller = true;
                while (bestaller)       //denna loop kommer köras så länge användaren vill beställa meny eller enstaka produkt
                {
                    try
                    {
                        valMenyEnProd = Convert.ToInt32(Console.ReadLine());

                        switch (valMenyEnProd)
                        {
                            case 1:
                                //ValAvProdukt kommer retunera ett tal från 4 olika produkter, beroende på vad användaren har valt
                                Console.Write($"\nVälj produkt genom att skriva in en siffra(1-4), skriv 5 för att få ingredienserna för hamburgarna: \n");

                                int valHam = ValAvProdukt(typHamburgare, "hamburgare", 4);

                                int valTill = ValAvProdukt(typTillbehor, "tillbehör", 4);

                                int valDryck = ValAvProdukt(typDryck, "dryck", 4);
                              
                                //En lista av egenskaper från det objekt som användaren har valt, beroende på val från 1-4
                                List<string> egenskapHam = Bestallning.Hamburgare.ReturnValHam(minaHamburgar, valHam - 1); //måste ta minus ett eftersom index i listan av objekten börjar på 0 och valHam kommer vara från 1-4
                                List<string> egenskapTill = Bestallning.Tillbehor.ReturnValTill(minaTillbehor, valTill - 1);
                                List<string> egenskapDryck = Bestallning.Dryck.ReturnValDryck(minaDrycker, valDryck - 1);

                                Bestallning valbestallning = new Bestallning(egenskapHam, egenskapTill, egenskapDryck);
                                
                                //En lista av en beställning som består av 3 listor med egenskaperna från ham,till och dryck objekten
                                List<List<String>> EnBestastallning = valbestallning.EgenskapValBestallning();

                                //adderar en beställning/meny 
                                allabestallningar.Add(EnBestastallning); 

                                int pris = valbestallning.FaPrisTotal();
                                totalPris += pris;

                                int kal = valbestallning.FaKalTotal();
                                totalKal += kal;

                                bestaller = false;
                                break;

                            case 2:
                                //ValAvEnProdukt kommer ge en lista av egenskaper för enbart en produkt, beroende på vad användaren har valt
                                //lista = {Namn, kal, pris}
                                List<string> valAvProdSingel = ValAvEnProdukt(typHamburgare, typTillbehor, typDryck);

                                enProduktLista.Add(valAvProdSingel); 

                                //tar ut priset från produktern som användaren har valt
                                pris = Convert.ToInt32(valAvProdSingel[1]); 
                                totalPris += pris;

                                //tar ut kalorier från produktern som användaren har valt
                                kal = Convert.ToInt32(valAvProdSingel[2]);  
                                totalKal += kal;
                                bestaller = false;

                                break;

                            default:
                                Console.Write("Du måste välja ett tal mellan 1 och 2: ");
                                bestaller = true;
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.Write("Du har skrivit en bokstav/ord, skriv siffran 1 eller 2: ");
                        bestaller = true;
                    }

                }

                //metod som frågar användaren om de vill beställa igen eller inte, kommer retunera true eller false
                //false --> hoppar ur while loopen   
                bestallaNogotMer = BestallaIgen();
            }

            SkrivUtBetallning(allabestallningar, enProduktLista, totalPris, totalKal);
        }


        //Metod som retunerar en vald siffra som användaren väljer, beroende av produkt
        public static int ValAvProdukt(List<string> typProdukt, string typ, int antalProdukter)
        {
            Console.WriteLine($"\nTyp av {typ}: ");
            int count = 1;

            //skriver ut alla möjliga val
            foreach (string produkt in typProdukt)
            {
                Console.WriteLine($"\n\t{produkt} ({count})");
                count++;
            }

            bool valjer = true;
            int valdSiffra = 0;
            //fångar in vad användaren väljer
            while (valjer)
            {
                try
                {
                    Console.Write($"\nSkriv Här: ");

                    valdSiffra = Convert.ToInt32(Console.ReadLine());

                    if (valdSiffra >= 1 && valdSiffra <= antalProdukter) //om talet är mellan 1-4, där antalProdukter i alla fall är 4
                    {
                        valjer = false;
                    }
                    else if (valdSiffra == 5) //Ifall användaren vill se ingredienserna för hamburgarna
                    {
                        Ingredienser();
                    }
                    else
                    {
                        Console.WriteLine($"Talet måste vara mellan 1 och {antalProdukter} eller 5 för att se ingredienserna av hamburgarna.");
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Du måste skriva en siffra");
                }
                catch (Exception)
                {
                    Console.Write($"Något hände, ge ett tal mellan 1 och {antalProdukter}: ");
                }

            }
            return valdSiffra;
        }

        //metod som retunerar en lista av egenskaper beroende på vad användaren valde för produkt
        public static List<string> ValAvEnProdukt(List<string> typHamburgare, List<string> typTillbehor, List<string> typDryck)
        {
        
            List<Bestallning.Hamburgare> minaHamburgar = new List<Bestallning.Hamburgare>(); //lista av alla objekt
            List<Bestallning.Tillbehor> minaTillbehor = new List<Bestallning.Tillbehor>();
            List<Bestallning.Dryck> minaDrycker = new List<Bestallning.Dryck>();

            HamburgarObjekt(minaHamburgar); //minHamburgare innehålle en lista av objekten
            TillbehorObjekt(minaTillbehor);
            DryckObjekt(minaDrycker);
        
            Console.Write("Skriv in siffra för vad du vill köpa \n\t(1)Hamburgare, \n\t(2)Tillbehör \n\t(3)Dryck\n\tSkriv här: ");

            bool valjer = true;

            List<string> egenskaperList = new List<string>(); //retunerar en lista av egenskaper av vald produkt
           
            while (valjer)
            {
                try
                {

                    int valSeparat = Convert.ToInt32(Console.ReadLine()); //läser av vad användaren skriver in
                    
                    if (valSeparat == 1)
                    {
                        Console.Write($"\nVälj produkt genom att skriva in en siffra(1-4)");
                        int valHamSep = ValAvProdukt(typHamburgare, "hamburgare", 4); //valHamSep (sep = seperat) kommer vara den siffra till respektive hamburgare

                        egenskaperList = Bestallning.Hamburgare.ReturnValHam(minaHamburgar, valHamSep - 1); //väljer användaren hamburgare kommer returnValHam retunera en array av egenskaperna och läggas i infoArray

                        valjer = false;
                    }
                    else if (valSeparat == 2)
                    {
                        Console.Write($"\nVälj produkt genom att skriva in en siffra(1-4)");
                        int valTillSep = ValAvProdukt(typTillbehor, "tillbehör", 4); //valHamSep (sep = seperat) kommer vara den siffra till respektive hamburgare

                        egenskaperList = Bestallning.Tillbehor.ReturnValTill(minaTillbehor, valTillSep - 1);

                        valjer = false;
                    }
                    else if (valSeparat == 3)
                    {
                        Console.Write($"\nVälj produkt genom att skriva in en siffra(1-4)");
                        int valDryckSep = ValAvProdukt(typDryck, "dryck", 4); //valHamSep (sep = seperat) kommer vara den siffra till respektive hamburgare

                        egenskaperList = Bestallning.Dryck.ReturnValDryck(minaDrycker, valDryckSep - 1);

                        valjer = false;
                    }
                    else
                    {
                        Console.WriteLine("Du måste skriva ett tal mellan 1 och 3");

                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Du måste skriva ett tal mellan 1 och 3");
                }

            }
            return egenskaperList;
        }

        public static void Ingredienser()
        {
            List<Bestallning.Hamburgare> minaHamburgar = new List<Bestallning.Hamburgare>();
            HamburgarObjekt(minaHamburgar); //lista av objekt för de olika hamburgarna

            //itererar igenom all objekt i listan av hamburgar objekten
            for (int i = 0; i < minaHamburgar.Count; i++)
            {
                Bestallning.Hamburgare ham = minaHamburgar[i];  //ham kommer vara ett objekt från listan av objekten
                ham.FaIngredienser();               //Här kommer ingredienserna för objektet att skrivas ut,
            }
        }


        public static bool BestallaIgen()
        {
            //fraga används för att hoppar ur whileloopen --> fraga användaren
            //flag är den som retuneras
            bool bestallaIgen = true, fraga = true; 
            string svar;
            while (fraga)
            {
                Console.Write("Vill du beställa något mer? (ja/nej): ");
                svar = Console.ReadLine();

                if (svar == "ja")
                {
                    bestallaIgen = true;
                    fraga = false;
                }
                else if (svar == "nej")
                {
                    bestallaIgen = false;
                    fraga = false;
                }
                else
                {
                    Console.WriteLine("Du måste skriva in 'ja' eller 'nej'");
                    fraga = true;
                }
            }
            return bestallaIgen;
        }


        //metod som skriver ut beställninarna som användaren har valt samt adderar detta till en txt fil (kvitto)
        public static void SkrivUtBetallning(List<List<List<string>>> allabestallningar, List<List<string>> enProduktLista, int totalPris, int totalKal)
        {
            string filePath = "kvitto.txt";         // Insperation: https://www.youtube.com/watch?v=cST5TT3OFyg&t=342s 
            
            //info används för att skriva till txt file
            List<string> info = new List<string>();
            info.Add("\tKVITTO FÖR DIN BESTÄLLNING");

            int meny = 1; //för att skriva ut meny 1, meny 2 osv

            Console.WriteLine("\nDu har valt följande menyer: ");
            info.Add("Du har valt följande menyer: ");

            for (int i = 0; i < allabestallningar.Count; i++)
            {
                
                List<List<string>> bestellning = allabestallningar[i]; // i = 0 är första beställningen

                Console.WriteLine($"\nMeny {meny}: ");
                info.Add($"\nMeny {meny}: ");

                for (int j = 0; j < bestellning.Count; j++)
                {
                    List<string> egenskaper = bestellning[j]; // j = 0 är första produkten i en beställning
                    Console.WriteLine($"{egenskaper[0]} ({egenskaper[1]}kr) ({egenskaper[2]}kal)");
                    info.Add($"{egenskaper[0]} ({egenskaper[1]}kr) ({egenskaper[2]}kal)");
                }
                meny++;
            }

            if (enProduktLista.Count != 0)
                Console.WriteLine("\nDu har beställt följande singel produkt(er): \n");
                info.Add("\nDu har beställt följande singel produkt: ");
            {
                foreach (var produkt in enProduktLista)
                {
                    Console.WriteLine($"{produkt[0]} ({produkt[1]}kr) ({produkt[2]}kal)");
                    info.Add($"{produkt[0]} ({produkt[1]}kr) ({produkt[2]}kal)");
                }

            }
            Console.WriteLine($"\nTotala Priset är: {totalPris}kr");
            info.Add($"\nTotala Priset är: {totalPris}kr");

            Console.WriteLine($"\nTotala antal kalorier är: {totalKal}kcal");
            info.Add($"\nTotala antal kalorier är: {totalKal}kcal");

            Console.WriteLine("Välkommen åter!");
            info.Add("\tVälkommen åter!");
            
            File.WriteAllLines(filePath, info.ToArray());
        }
        
        
        //fick iden av Malin att använda objekten på detta sätt, alltså som en lista
        public static void HamburgarObjekt(List<Bestallning.Hamburgare> ham) //metod för att skapa en lista av objekt av hamburgare
        {
            List<string> hamCheese = new List<string> { "sesambröd", "cheddarost", "isbergssallad", "orginal dressing", "kött(90g)" };
            List<string> hamDoubleCheese = new List<string> { "sesambröd", "cheddarost", "isbergssallad", "orginal dressing,kött(180g)" };
            List<string> hamOrginal = new List<string> { "sesambröd", "cheddarost", "isbergssallad", "lök", "tomat", "ketchup", "majonnäs", "kött(90g)" };
            List<string> hamSpecial = new List<string> { "briochebröd", "emmentalerost", "isbergssallad", "tomat", "bacon", "umamidressing", "kött(90g)" };

            //typ av hamburgare, kalorier, pris 
            Bestallning.Hamburgare cheeseBurgare = new Bestallning.Hamburgare("Cheeseburgare", hamCheese, "789", "70");
            Bestallning.Hamburgare doublecheeseBurgare = new Bestallning.Hamburgare("Doubelcheeseburgare", hamDoubleCheese, "1011", "100");
            Bestallning.Hamburgare orginalBurgare = new Bestallning.Hamburgare("Orginalburgare", hamOrginal, "955", "79");
            Bestallning.Hamburgare specialBurgare = new Bestallning.Hamburgare("Specialburgare", hamSpecial, "1167", "110");

            ham.Add(cheeseBurgare); 
            ham.Add(doublecheeseBurgare);
            ham.Add(orginalBurgare);
            ham.Add(specialBurgare);
        }

        public static void TillbehorObjekt(List<Bestallning.Tillbehor> till)  //metod för att göra en lista av tillbehör objekt
        {
            //typ av tillbehör, kalorier, pris 
            Bestallning.Tillbehor pommes = new Bestallning.Tillbehor("Pommes frites", "140", "18");
            Bestallning.Tillbehor bonsallad = new Bestallning.Tillbehor("Bönsallad", "40", "20");
            Bestallning.Tillbehor lokringar = new Bestallning.Tillbehor("Lökringar", "160", "22");
            Bestallning.Tillbehor morotter = new Bestallning.Tillbehor("Minimorötter", "20", "16");

            till.Add(pommes);
            till.Add(bonsallad);
            till.Add(lokringar);
            till.Add(morotter);
        }

        public static void DryckObjekt(List<Bestallning.Dryck> dryck)  //metod som skapar en lista av dryck objekt
        {
            //typ av dryck, kalorier, pris 
            Bestallning.Dryck oCola = new Bestallning.Dryck("Cola", "110", "22");
            Bestallning.Dryck oFanta = new Bestallning.Dryck("Fanta", "100", "22");
            Bestallning.Dryck oRamlosa = new Bestallning.Dryck("Ramlösa", "11", "25");
            Bestallning.Dryck oAjuice = new Bestallning.Dryck("Äpplejuice", "77", "17");

            dryck.Add(oCola);
            dryck.Add(oFanta);
            dryck.Add(oRamlosa);
            dryck.Add(oAjuice);
        }
    }
}