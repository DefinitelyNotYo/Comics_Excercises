class program
{
    static void Main(string[] args)
    {
        Student prova = new Student();
        //prova.GetFullName(); ritorna una stringa ma non stampa niente
        string etichetta = prova.GetFullName();
        Console.WriteLine();
        prova.VisualizzaInventario();
        prova.Aggiungi("torcia");
        prova.VisualizzaInventario();
        prova.Aggiungi("b");
        prova.VisualizzaInventario();
        prova.Aggiungi("c");
        prova.Aggiungi("d");
        prova.Aggiungi("e");
        prova.Aggiungi("f");
        prova.Aggiungi("g");
        prova.Aggiungi("h");
        prova.Aggiungi("i");
        prova.VisualizzaInventario();
        prova.Rimuovi("g");
        prova.VisualizzaInventario();
        prova.Rimuovi("topo");
        prova.Aggiungi("topo");
        prova.VisualizzaInventario();


    }
    class Student
    {
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string[] inventario = {"-","-", "-", "-", "-", "-", "-", "-", "-"};
        public Student() //interfaccia di creazione del personaggio
        {
            Console.WriteLine("Inserisci nome e cognome");
            FirstName = Console.ReadLine();
            LastName = Console.ReadLine();
        }
        public void VisualizzaInventario() //serve a visualizzare gli oggetti che il giocatore ha raccolto fino ad ora
        {
            Console.WriteLine("----- Hai raccolto questi oggetti -----");
            for (int i = 0; i < inventario.Length-6; i++)
            {
                Console.Write($"{inventario[i]}\t");
            }
            Console.WriteLine();
            for (int i = 3; i < inventario.Length-3; i++)
            {
                Console.Write($"{inventario[i]}\t");
            }
            Console.WriteLine();
            for (int i = 6; i < inventario.Length; i++)
            {
                Console.Write($"{inventario[i]}\t");
            }
            Console.WriteLine();
        }
        public void Aggiungi(string item) //serve ad aggiungere gli oggetti all'inventario
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
            if(trovato==false)
                Console.WriteLine("\nNon puoi raccogliere altri oggetti perché l'inventario pieno\n");
        }
        public void Rimuovi(string item)
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
            if(trovato==false)
                Console.WriteLine("\nOggetto non trovato...\n");
        }
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
