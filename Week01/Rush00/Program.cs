using System.ComponentModel.Design;
using System.IO;
using System.Security.Cryptography;
class program
{
    static void Main(string[] args)
    {
        Personaggio Caleb = new Personaggio("Caleb");
        Personaggio Kaitlyn = new Personaggio("Kaitlyn");
        Personaggio Alan = new Personaggio("Alan");
        Personaggio Valery = new Personaggio("Valery");
        Personaggio Sam = new Personaggio("Sam");
        Caleb.AddItem("polaroid");
        Kaitlyn.AddItem("accendino");
        Alan.AddItem("carta e penna");
        Valery.AddItem("borsa");
        Sam.AddItem("spray al peperoncino");
        WelcomeMessage();
        Commands();
        Console.ForegroundColor = ConsoleColor.Green;Console.WriteLine("-------------------- Capitolo 1 --------------------");Console.ResetColor();
        Console.WriteLine("Valery, 18:53");
        Valery.ChapterOne(Alan, Caleb, Kaitlyn, Sam, Valery);
    }
    class Personaggio
    {
        public string Name
        {
            get;
            set;
        }
        public string[] inventario = { "-", "-", "-", "-" };
        public string[] party = { "-", "-", "-", "-" };
        public Personaggio(string x) //costruttore della classe personaggio
        {
            Name = x;
            switch (x)
            {
                case "Caleb":
                    party[0] = "Alan";
                    party[1] = "Kaitlyn";
                    party[2] = "Sam";
                    party[3] = "Valery";
                    break;
                case "Kaitlyn":
                    party[0] = "Caleb";
                    party[1] = "Nicholas";
                    party[2] = "Sam";
                    party[3] = "Valery";
                    break;
                case "Valery":
                    party[0] = "Caleb";
                    party[1] = "Alan";
                    party[2] = "Sam";
                    party[3] = "Kaitlyn";
                    break;
                case "Alan":
                    party[0] = "Caleb";
                    party[1] = "Valery";
                    party[2] = "Sam";
                    party[3] = "Kaitlyn";
                    break;
                case "Sam":
                    party[0] = "Caleb";
                    party[1] = "Valery";
                    party[2] = "Alan";
                    party[3] = "Kaitlyn";
                    break;
                default:
                    Console.WriteLine("C'è qualcosa che non va...");
                    break;
            }
        }
        public void ShowParty() //mostra i personaggi vicini a quello in scena
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Al momento sei accompagnato da questi personaggi: \n");
            Console.ResetColor();
            for (int i = 0; i < party.Length; i++)
                if (party[i] != "-")
                    Console.Write($"{party[i]}    ");
            Console.WriteLine();
        }
        public void AddToParty(string p) //serve ad aggiungere un membro al gruppo di un personaggio
        {
            for (int i = 0; i < party.Length; i++)
            {
                if (party[i] == "-")
                {
                    party[i] = p;
                    break;
                }
            }
        }
        public void RemoveFromParty(string p) //serve ad aggiungere un membro al gruppo di un personaggio
        {
            for (int i = 0; i < party.Length; i++)
            {
                if (party[i] == p)
                {
                    party[i] = "-";
                    break;
                }
            }
        }
        public void ShowBag() //serve a visualizzare gli oggetti che il giocatore ha raccolto fino ad ora
        {
            Console.WriteLine($"\n----- {Name} ha raccolto questi oggetti -----");
            for (int i = 0; i < inventario.Length - 2; i++)
            {
                Console.Write($"{inventario[i]}\t");
            }
            Console.WriteLine();
            for (int i = 2; i < inventario.Length; i++)
            {
                Console.Write($"{inventario[i]}\t");
            }
            Console.WriteLine("\n");
        }
        public void AddItem(string item) //serve ad aggiungere un oggetto all'inventario
        {
            bool trovato = false;
            for (int i = 0; i < inventario.Length; i++)
            {
                trovato = false;
                if (inventario[i] == "-")
                {
                    inventario[i] = item;
                    trovato = true;
                    break;
                }
            }
            if (trovato == false)
                Console.WriteLine("\nNon puoi raccogliere altri oggetti perché l'inventario pieno\n");
        }
        public void RemoveItem(string item) //serve a rimuovere un oggetto dall'inventario
        {
            bool trovato = false;
            for (int i = 0; i < inventario.Length; i++)
            {
                if (inventario[i] == item)
                {
                    inventario[i] = "-";
                    trovato = true;
                    break;
                }
            }
            if (trovato == false && item != "fazzoletti")
                Console.WriteLine("\nOggetto non trovato o non distruttibile...\n");
        }
        public bool AskFindItem(string item) //verifica se nell'inventario è presente un certo oggetto
        {
            for (int i = 0; i < inventario.Length; i++)
            {
                if (inventario[i] == item)
                {
                    return true;
                }
            }
            return false;
        }
        public void AskRemoveItem() //serve a rimuovere un oggetto dall'inventario
        {
            Console.WriteLine("Quale oggetto vuoi buttare?");
            string item = Console.ReadLine();
            bool trovato = false;
            for (int i = 0; i < inventario.Length; i++)
            {
                if (inventario[i] == item)
                {
                    inventario[i] = "-";
                    trovato = true;
                    break;
                }
                else if (item == "annulla")
                    break;
            }
            if (trovato == false && item != "annulla")
                Console.WriteLine("\nOggetto non trovato o non distruttibile...\n");
        }
        public void SwapItems(Personaggio p) //scambia due oggetti fra i personaggi
        {
            string boxGive = "-"; //salva l'oggetto in uscita in una variabile temporanea
            string boxTake = "-"; //salva l'oggetto in entrata in una variabile temporanea
            string itemGive, itemTake;
            bool found = false;
            ShowBag();
            p.ShowBag();
            Console.WriteLine("Che cosa vuoi scambiare?\n");
            Console.Write($"{Name}: ");
            while (found == false)
            {
                itemGive = Console.ReadLine();
                itemGive.ToString();
                for (int i = 0; i < inventario.Length; i++)
                    if (inventario[i] == itemGive)
                    {
                        found = true;
                        boxGive = itemGive;
                        RemoveItem(itemGive);
                        break;
                    }
                if(found == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nOggetto inesistente... INSERISCI un oggetto valido\n\n"); Console.ResetColor();
                }
            }
            found = false;
            Console.Write($"\n{p.Name}: ");
            while (found == false)
            {
                itemTake = Console.ReadLine();
                itemTake.ToString();
                for (int i = 0; i < p.inventario.Length; i++)
                    if (p.inventario[i] == itemTake)
                    {
                        found = true;
                        boxTake = itemTake;
                        p.RemoveItem(itemTake);
                        break;
                    }
                if (found == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nOggetto inesistente... inserisci un oggetto valido\n"); Console.ResetColor();
                }
            }
            AddItem(boxTake);
            p.AddItem(boxGive);
            Console.WriteLine();
        }
        public void Investigate(Personaggio p1, Personaggio p2, Personaggio p3, Personaggio p4, Personaggio p5)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------- Hai trovato i seguenti oggetti ----------");
            Console.ResetColor();
            Console.Write($"\n{p1.Name}: ");
            for (int i = 0; i < p1.inventario.Length; i++)
                if (p1.inventario[i] != "-")
                    Console.Write($"'{p1.inventario[i]}' ");
            Console.Write($"\n\n{p2.Name}: ");
            for (int i = 0; i < p2.inventario.Length; i++)
                if (p2.inventario[i] != "-")
                    Console.Write($"'{p2.inventario[i]}' ");
            Console.Write($"\n\n{p3.Name}: ");
            for (int i = 0; i < p3.inventario.Length; i++)
                if (p3.inventario[i] != "-")
                    Console.Write($"'{p3.inventario[i]}' ");
            Console.Write($"\n\n{p4.Name}: ");
            for (int i = 0; i < p4.inventario.Length; i++)
                if (p4.inventario[i] != "-")
                    Console.Write($"'{p4.inventario[i]}' ");
            Console.Write($"\n\n{p5.Name}: ");
            for (int i = 0; i < p5.inventario.Length; i++)
                if (p5.inventario[i] != "-")
                    Console.Write($"'{p5.inventario[i]}' ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\nInserisci l'oggetto da esaminare: ");
            Console.ResetColor();
            string item = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < p1.inventario.Length && found == false; i++)
            {
                if (p1.inventario[i] == item)
                {
                    found = true;
                    break;
                }
            }
            for (int i = 0; i < p2.inventario.Length && found == false; i++)
            {
                if (p2.inventario[i] == item)
                {
                    found = true;
                    break;
                }
            }
            for (int i = 0; i < p3.inventario.Length && found == false; i++)
            {
                if (p3.inventario[i] == item)
                {
                    found = true;
                    break;
                }
            }
            for (int i = 0; i < p4.inventario.Length && found == false; i++)
            {
                if (p4.inventario[i] == item)
                {
                    found = true;
                    break;
                }
            }
            for (int i = 0; i < p5.inventario.Length && found == false; i++)
            {
                if (p5.inventario[i] == item)
                {
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nOggetto non trovato o inesistente"); Console.ResetColor();
            }
            if (found == true)
                switch (item)
                {
                    case "fazzoletti":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\nUn semplice pacchetto di fazzoletti");
                        Console.ResetColor();
                        break;
                    case "spray al peperoncino":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\nUna carica di questo potentissimo spray al peperoncino farebbe piangere persino " +
                            "delle spaventose e abominevoli creature occulte assetate di sangue, sempre che abbiano occhi da cui piangere. Provare per credere.");
                        Console.ResetColor();
                        break;
                    case "polaroid":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\nVuoi immortalare un dolce momento? Fotografare qualcosa di importante? Avere le prove di un evento sovrannaturale? " +
                            "Niente di più facile: prendi la mira e fai click! ");
                        Console.ResetColor();
                        break;
                    case "carta e penna":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\nTi permette di prendere un appunto al volo, lasciare messaggi, inventare nuovi modi per passare il tempo e funziona anche offline!");
                        Console.ResetColor();
                        break;
                    case "borsa":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\nQuesta borsa è costata così tanto da essere addirittura idrorepellente, ma di sicuro ne è valsa la pena");
                        Console.ResetColor();
                        break;
                    case "accendino":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\nTutto il potere della scoperta del fuoco fra le cinque dita di una mano");
                        Console.ResetColor();
                        break;
                }
            string yesOrNot = "-";
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nVuoi esaminare altri oggetti? (si/no)"); Console.ResetColor();
            yesOrNot = Console.ReadLine();
            while (yesOrNot != "no" && yesOrNot != "si") //va sistemato il controllo
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nInserisci un valore valido '(si/no)'"); Console.ResetColor();
                yesOrNot = Console.ReadLine();
            }
            if (yesOrNot == "si")
                Investigate(p1, p2, p3, p4, p5);
            Console.ResetColor();

        }
        public Personaggio CheckPartyMember(Personaggio p1, Personaggio p2, Personaggio p3, Personaggio p4, Personaggio p5) //si accerta che i personaggi intenti a scambiare esistano e siano insieme
        {
            Console.WriteLine("\nScegli il personaggio con cui effettuare lo scambio\n");
            string thisOne = "-";
            bool found = false;
            while (found == false)
            {
                thisOne = Console.ReadLine();
                for (int i = 0; i < party.Length; i++)
                    if (thisOne == party[i])
                    {
                        found = true;
                        break;
                    }
                if (found == false)
                    Console.ForegroundColor = ConsoleColor.Red;Console.WriteLine("\nQuesto personaggio non esiste o al momento non è disponibile. Inserisci un personaggio valido.\n");Console.ResetColor();
            }
            if (p1.Name == thisOne)
                return p1;
            else if (p2.Name == thisOne)
                return p2;
            else if (p3.Name == thisOne)
                return p3;
            else if (p4.Name == thisOne)
                return p4;
            else
                return p5;
        }
        public void Trade(Personaggio p1, Personaggio p2, Personaggio p3, Personaggio p4, Personaggio p5) //funziona più ampia che controllola l'esistenza di due oggetti e li scambia fra loro
        {
            ShowParty();
            SwapItems(CheckPartyMember(p1, p2, p3, p4, p5));
        }
        public void ChapterOne(Personaggio p1, Personaggio p2, Personaggio p3, Personaggio p4, Personaggio p5)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nValery: «Come promesso, quest'oggi ci imbarcheremo in un'avventura oltre i confini del mare! Ci saranno feste, bei ragazzi, giochi e qualche pettegolezzo.\n" +
                "Ad accompagnarmi in questo viaggio mozzafiato abbiamo Caleb, che fa il duro solo per nascondere il suo lato tenero. Alan ci intrattiene con le sue battute strampalate, poi abbiamo-»\n\n" +
                "Alan: «Ehi, sono battute! Devono esserlo!»\n\n" +
                "Valery: «Quest* è Sam, che solleva più peso di quanto Caleb non riuscirà mai»\n\n" +
                "*Caleb rotea gli occhi e sbuffa, Sam arrossice appena e distoglie lo sguardo dalla fotocamera dello smartphone di Valery mentre saluta*\n\n" +
                "Sam: «C-ciao»\n\n" +
                "Valery: «Infine abbiamo Kaitlyn, che non posso farvi vedere perché non ho idea di dove sia finita»\n\n" +
                "Caleb: «Incredibile, abbiamo trovato qualcosa che miss perfezione non sa!»\n\n" +
                "*Valery interrompe la diretta e lancia un'occhiataccia verso Caleb*\n\n" +
                "Valery: «Smettila di fare lo stronzo»\n\n" +
                "Caleb: *le fa il verso* «Smettila di fare lo stronzo»\n\n" +
                "Alan: «Potete smetterla adesso, sta tornando la vostra babysitter. Kaitlyn! Kaitlyn!»\n\n" +
                "*Kaitlyn, con un'espressione più scocciata di quella che aveva quando si è allontanata, torna al tavolino dove il resto del gruppo si è accomodato.*\n\n" +
                "Kaitlyn: «Qualsiasi cosa tu voglia, Alan, non ora. Ho una notizia buona e una di merda, cosa volete sentire prima?»\n\n");               
            Console.ResetColor();
            Console.WriteLine("Inserisci un valore qualsiasi o premi invio per visualizzare il menù di scelta");Console.ReadLine();
            Console.WriteLine("1 - La buona notizia");
            Console.WriteLine("2 - La notizia di merda\n");
            string path = "-";
            bool found = false;
            while (found == false)
            {
                path = Console.ReadLine();
                switch (path)
                {
                    case "1":
                        ChapterOne1(p1, p2, p3, p4, p5);
                        found = true;
                        break;
                    case "2":
                        ChapterOne2(p1, p2, p3, p4, p5);
                        found = true;
                        break;
                    case "scambia":
                        Trade(p1, p2, p3, p4, p5);
                        break;
                    case "butta":
                        AskRemoveItem();
                        break;
                    case "inventario":
                        ShowBag();
                        break;
                    case "aggiorna":
                        ChapterOne(p1, p2, p3, p4, p5);
                        break;
                    case "gruppo":
                        ShowParty();
                        break;
                    case "comandi":
                        Commands();
                        break;
                    case "esamina":
                        Investigate(p1, p2, p3, p4, p5);
                        break;
                    default:
                        break;
                }
            }
        }
        public void ChapterOne1(Personaggio p1, Personaggio p2, Personaggio p3, Personaggio p4, Personaggio p5)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nValery: «Restiamo positivi, prima la buona notizia!»\n\n" +
                "Kaitlyn: «D'accordo: ho preso la chiave della cabina e possiamo finalmente andare a lasciare lì i nostri bagagli»\n\n" +
                "Alan: «Finalmente! Il mio culo sta diventando quadrato su questa poltrona»\n\n" +
                "Kaitlyn: «Frena l'entusiasmo, Alan. La notizia di merda è che ci sono stati dei problemi qui sulla nave e le varie attività non avranno inizio fino a domani.»\n\n" +
                "Caleb: «COSA?!»\n\n" +
                "Kaitlyn: «...servizio ristorante compreso»\n\n" +
                "Tutti: «COOOOOSA?!»\n\n" +
                "*Kaitlyn lancia un'occhiata gelida a tutti e sospira*\n\n" +
                "Kaitlyn: «Avete finito? Andiamo ragazzi non è la fine del mondo. Caleb e Sam, i vostri zaini traboccano di snacks. So che è una soluzione un po' raffazzonata, ma secondo me " +
                "possiamo arrangiarci con quelli per stasera. Avrei voluto cantargliene quattro, ma il tipo che mi ha dato la chiave metteva i brividi.»\n\n" +
                "*Tutti ponderano l'idea di Kaitlyn per qualche secondo, ma alla fine si arrendono all'evidenza e si mostrano d'accordo*\n\n" +
                "Alan: «Direi che possiamo andare a sistemare i bagagli e organizzarci»\n\n" +
                "*Alzandosi, Alan urta il tavolino col fianco e rovescia la bottiglietta d'acqua che Valery ha comprato ad un distributore automatico prima di imbarcarsi.*\n\n" +
                "Alan: «Cazzo, mi dispiace» \n\n" +
                "Valery: *sospira* «Non preoccuparti. Qualcuno ha qualcosa per asciugare?»\n\n" +
                "Kaitlyn: «Dovremmo usare la felpa di Alan per asciugare» *rotea gli occhi* «Ho dei fazzoletti, prendili pure»\n\n");
            Console.ResetColor(); Console.WriteLine("Inserisci un valore qualsiasi o premi invio per visualizzare il menù di scelta"); Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green; Console.Write("Utilizza il comando scambia per prendere i fazzoletti da Kaitlyn\n\n");
            if (p1.Name == "Kailyn")
                p1.AddItem("fazzoletti");
            else if (p2.Name == "Kaitlyn")
                p2.AddItem("fazzoletti");
            else if (p3.Name == "Kaitlyn")
                p3.AddItem("fazzoletti");
            else if (p4.Name == "Kaitlyn")
                p4.AddItem("fazzoletti");
            else if (p5.Name == "Kaitlyn")
                p5.AddItem("fazzoletti");
            Console.ResetColor();
            if (AskFindItem("fazzoletti"))
                Console.WriteLine("1 - (fazzoletti) Pulisci sul tavolo");
            string path = "-";
            bool found = false;
            while (found == false)
            {
                path = Console.ReadLine();
                switch (path)
                {
                    case "1":
                        if (AskFindItem("fazzoletti"))
                        {
                            RemoveItem("fazzoletti");
                            ChapterOne3(p1, p2, p3, p4, p5);
                            found = true;
                            break;
                        }
                        break;
                    case "scambia":
                        Trade(p1, p2, p3, p4, p5);
                        break;
                    case "butta":
                        AskRemoveItem();
                        break;
                    case "inventario":
                        ShowBag();
                        break;
                    case "aggiorna":
                        ChapterOne1(p1, p2, p3, p4, p5);
                        break;
                    case "gruppo":
                        ShowParty();
                        break;
                    case "comandi":
                        Commands();
                        break;
                    case "esamina":
                        Investigate(p1, p2, p3, p4, p5);
                        break;
                    default:
                        break;
                }
            }
        }
        public void ChapterOne2(Personaggio p1, Personaggio p2, Personaggio p3, Personaggio p4, Personaggio p5)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nValery: «Lasciamo la buona notizia per la fine\n\n" +
                "Kaitlyn: «La notizia di merda è che ci sono stati dei problemi qui sulla nave e le varie attività non avranno inizio fino a domani.»\n\n" +
                "Caleb: «COSA?!»\n\n" +
                "Kaitlyn: «...servizio ristorante compreso»\n\n" +
                "Tutti: «COOOOOSA?!»\n\n" +
                "*Kaitlyn lancia un'occhiata gelida a tutti e sospira*\n\n" +
                "Kaitlyn: «Avete finito? Andiamo ragazzi non è la fine del mondo. Caleb e Sam, i vostri zaini traboccano di snacks. So che è una soluzione un po' raffazzonata, ma secondo me " +
                "possiamo arrangiarci con quelli per stasera. Avrei voluto cantargliene quattro, ma il tipo che mi ha dato la chiave metteva i brividi.»\n\n" +
                "*Tutti ponderano l'idea di Kaitlyn per qualche secondo, ma alla fine si arrendono all'evidenza e si mostrano d'accordo*\n\n" +
                "Valery: «...e la buona notizia?»\n\n" +
                "Kaitlyn: «Possiamo finalmente andare a poggiare i nostri culi in cabina, ho preso la chiave»\n\n" +
                "Alan: «Direi che possiamo andare a sistemare i bagagli e organizzarci»\n\n" +
                "*Alzandosi, Alan urta il tavolino col fianco e rovescia la bottiglietta d'acqua che Valery ha comprato ad un distributore automatico prima di imbarcarsi.*\n\n" +
                "Alan: «Cazzo, mi dispiace» \n\n" +
                "Valery: *sospira* «Non preoccuparti. Qualcuno ha qualcosa per asciugare?»\n\n" +
                "Kaitlyn: «Dovremmo usare la felpa di Alan per asciugare» *rotea gli occhi* «Ho dei fazzoletti, prendili pure»\n\n");
            Console.ResetColor(); Console.WriteLine("Inserisci un valore qualsiasi o premi invio per visualizzare il menù di scelta"); Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green; Console.Write("Utilizza il comando scambia per prendere i fazzoletti da Kaitlyn\n\n");
            if (p1.Name == "Kailyn")
                p1.AddItem("fazzoletti");
            else if (p2.Name == "Kaitlyn")
                p2.AddItem("fazzoletti");
            else if (p3.Name == "Kaitlyn")
                p3.AddItem("fazzoletti");
            else if (p4.Name == "Kaitlyn")
                p4.AddItem("fazzoletti");
            else if (p5.Name == "Kaitlyn")
                p5.AddItem("fazzoletti");
            Console.ResetColor();
            if (AskFindItem("fazzoletti"))
                Console.WriteLine("1 - (fazzoletti) Pulisci sul tavolo");
            string path = "-";
            bool found = false;
            while (found == false)
            {
                path = Console.ReadLine();
                switch (path)
                {
                    case "1":
                        if (AskFindItem("fazzoletti"))
                        {
                            RemoveItem("fazzoletti");
                            ChapterOne3(p1, p2, p3, p4, p5);
                            found = true;
                            break;
                        }
                        break;
                    case "scambia":
                        Trade(p1,p2,p3,p4,p5);
                        break;
                    case "butta":
                        AskRemoveItem();
                        break;
                    case "inventario":
                        ShowBag();
                        break;
                    case "aggiorna":
                        ChapterOne2(p1, p2, p3, p4, p5);
                        break;
                    case "gruppo":
                        ShowParty();
                        break;
                    case "comandi":
                        Commands();
                        break;
                    case "esamina":
                        Investigate(p1, p2, p3, p4, p5);
                        break;
                    default:
                        break;
                }
            }
        }
        public void ChapterOne3(Personaggio p1, Personaggio p2, Personaggio p3, Personaggio p4, Personaggio p5)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n*Una volta ripulito il tavolo, tutti e cinque si lasciano alle spalle l'area ristoro e vanno in cabina a sistemare i bagagli*\n\n");
            Console.ResetColor(); Console.WriteLine("Caleb, 22:13\t\tTO BE CONTINUED...\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.ResetColor();
            Console.WriteLine("Inserisci un valore qualsiasi o premi invio per visualizzare il menù di scelta"); Console.ReadLine();
            Console.WriteLine("1 - Finisci il tutorial");
            string path = "-";
            bool found = false;
            while (found == false)
            {
                path = Console.ReadLine();
                switch (path)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("----------FINE DEMO----------");
                        found = true;
                        break;
                    case "scambia":
                        Trade(p1, p2, p3, p4, p5);
                        break;
                    case "butta":
                        AskRemoveItem();
                        break;
                    case "inventario":
                        ShowBag();
                        break;
                    case "aggiorna":
                        ChapterOne3(p1, p2, p3, p4, p5);
                        break;
                    case "gruppo":
                        ShowParty();
                        break;
                    case "comandi":
                        Commands();
                        break;
                    case "esamina":
                        Investigate(p1, p2, p3, p4, p5);
                        break;
                    default:
                        break;
                }
            }
        }
    }
    public static void Commands()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("\ninventario"); Console.ResetColor();
        Console.Write(" - Mostra cosa sta trasportando il tuo personaggio in questo momento. Il numero massimo di oggetti che ogni personaggio può trasportare è pari a quattro.");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("\ngruppo"); Console.ResetColor();
        Console.Write(" - I personaggi non saranno sempre tutti insieme, anzi, molto spesso capiterà loro di trovarsi separati dai propri compagni. Questo comando mostra i personaggi protagonisti presenti in scena"); Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("\nscambia"); Console.ResetColor();
        Console.Write(" - Consente lo scambio di un oggetto con un altro fra due personaggi in scena. Puoi scambiare oggetti anche con slot vuoti inserendo -");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("\nbutta"); Console.ResetColor();
        Console.Write(" - Serve a buttare un oggetto fra quelli che hai in inventario. Una volta buttato, l'oggetto è irrecuperabile.");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("\nesamina"); Console.ResetColor();
        Console.Write(" - Mostra la descrizione dell'oggetto esaminato. Puoi esaminare anche gli oggetti dei personaggi che non sono in scena");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("\naggiorna"); Console.ResetColor();
        Console.Write(" - Ripete la scena corrente");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("\ncomandi"); Console.ResetColor();
        Console.Write(" - Riporta a schermo questo elenco di comandi. Si noti che, così come gli oggetti, anche i comandi devono essere inseriti in minuscolo\n\n");
    }
    public static void WelcomeMessage()
    {
        Console.WriteLine("Benvenuto caro adoratore dell'orrore! La trama di Dreadful Destinies: Sinister Seas è malleabile, " +
            "plasmabile da ciò che sceglierai di fare o... di non fare." +
            " L'avventura si svolge su una nave da crociera per la quale i cinque protagonisti hanno avuto la fortuna di recuperare un biglietto. " +
            "Ciò che questi ragazzi ignorano è che forze malevole e occulte si agitano attorno a loro pregustando qualcosa di sinistro. \n");
        Console.Write("Puoi imbarcarti in questa avventura da solo o in compagnia, a seconda di quanto sono coraggiosi i tuoi amici. I personaggi disponibili" +
            " sono 5 (");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("Alan"); Console.ResetColor();
        Console.Write(", ");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("Caleb"); Console.ResetColor();
        Console.Write(", ");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("Kaitlyn"); Console.ResetColor();
        Console.Write(", ");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("Sam"); Console.ResetColor();
        Console.Write(" e ");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("Valery"); Console.ResetColor();
        Console.Write(").\nAssegnate uno o più personaggi a ciascun giocatore e alternate il controllo dei comandi di gioco.\n\n");
        Console.Write("In Dreadful Destinies: Sinister Seas ogni scelta è contrassegnata da un ");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("numero"); Console.ResetColor();
        Console.Write(". Le scelte costituiscono il cuore del gioco e permettono alla trama di evolversi in un modo o nell'altro a seconda delle decisioni prese." +
            "Alcune scelte diventano visibili solo se il personaggio in uso possiede un determinato oggetto. Ogni personaggio ha un ");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("inventario"); Console.ResetColor();
        Console.Write(" che può contenere fino a quattro oggetti. Ogni giocatore può manipolare questi oggetti attraverso i comandi descritti qui di seguito." +
            " Si noti che gli oggetti sono scritti senza l'ausilio di lettere maiuscole ed è così che vanno inseriti quando richiesto.\n");
    }
}
