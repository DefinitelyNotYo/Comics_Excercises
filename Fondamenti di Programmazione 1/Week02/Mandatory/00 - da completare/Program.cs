
using ConsoleApp1;
using System.ComponentModel;
using System.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        Welcome();

        List<videogame> archive = new List<videogame>();
        bool exit = false;
        while (exit == false)
        {
            Console.Write("\nInserisci il comando: ");
            string comando = Console.ReadLine();
            switch (comando)
            {
                case "add":
                    AddGame(archive);
                    break;
                case "remove":
                    break;
                case "exit":
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;Console.Write("\nComando non valido. Inserisci un comando valido: ");
                    break;
            }
        }

    }
    public static void Welcome()
    {
        Console.Write("Questo programma permette la gestione di un archivio di videogiochi, ciascuno dei quali possiede un nome, un genere e un punteggio.\n" +
         "puoi manipolare l'archivio digitando i seguenti comandi:\n\n");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("add "); Console.ResetColor(); //comando : aggiungi gioco
        Console.Write("- Permette di inserire un nuovo gioco all'archivio\n");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("\nremove "); Console.ResetColor(); //comando : rimuovi gioco
        Console.Write("- Permette di rimuovere un gioco all'archivio\n");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("\nshow archive "); Console.ResetColor();  //comando : mostra archivio
        Console.Write("- Mostra l'archivio a schermo\n");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("\nshow stats "); Console.ResetColor();  //comando : mostra statistiche
        Console.Write("- Mostra il numero di giochi inseriti e la media dei loro punteggi schermo\n");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("\nfind by filter "); Console.ResetColor();  //comando : mostra statistiche
        Console.Write("- Mostra il numero di giochi inseriti e la media dei loro punteggi schermo\n");
        Console.ForegroundColor = ConsoleColor.Green; Console.Write("\nexit "); Console.ResetColor();  //comando : esci dal programma
        Console.Write("- Chiude il programma\n");
    }
    public class videogame
    {
        public string Name { get; set; }
        string Genre { get; set; }
        int Score { get; set; }

        public videogame() 
        {
            string n = null;
            string g = null;
            int s = -1;
            Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\nNome videogioco: "); Console.ResetColor();
            n = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\nGenere: "); Console.ResetColor();
            g = Console.ReadLine();
            bool check = false;
            Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\nPunteggio (voto da 1 a 10: "); Console.ResetColor();
            string fakeS = Console.ReadLine();
            try
            {
                if (s < 0 || s > 10)
                    throw new MiaEccezione();
            }
            catch (MiaEccezione)
            {

            }

        }
    }
    public static void AddGame(List<videogame> arc)
    {
        videogame x = new videogame();
        arc.Add(x);
    }
    public void RemoveGame(List<videogame> arc, videogame game)
    {
        arc.Remove(game);
    }
    public void ShowArchive(List<videogame> arc)
    {
        arc.ForEach(videogame => { Console.WriteLine(videogame.Name); });
    }
}
