using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main()
    {
        bool check = false;
        int n = 0;       
        check = false;
        int[] sequenza = new int[n];
        int[] conteggio = new int[n];
        string again = "-";
        do
        {
            Console.Write("Inserisci la lunghezza del vettore: ");
            while (check == false)
            {
                check = int.TryParse(Console.ReadLine(), out n);
                if (check == false)
                    Console.WriteLine("Valore non valido");
            }
            GeneraNumeriCasuali(ref sequenza);
            Console.Write($"Numeri casuali generati: [");
            for (int i= 0; i<sequenza.Length-1;i++)
                Console.Write($"{sequenza[i]}, ");
            Console.Write(sequenza[sequenza.Length]);
            AggiornaConteggioOccorrenze(sequenza, ref conteggio);
            StampaConteggio(conteggio);
            Console.Write("Generare nuovi numeri? (Si/No): ");
            do
            {
                again = toString(Console.ReadLine());
            }
            while (again != "si" || again != "Si" || again != "No" || again != "no");
        }
        while (check == false);
    }
    static void GeneraNumeriCasuali(ref int[] v)
    {
        Random rdm = new Random();
        for (int i = 0; i < v.Length; i++)
            v[i] = rdm.Next(0, 9);
    }
    static void AggiornaConteggioOccorrenze
     (int[] v, ref int[] cont)
    {
        for (int i = 0; i < cont.Length; i++)
            for (int j = 0; j < v.Length; j++)
                if (v[j] == i)
                    cont[i]++;
    }
    static void StampaConteggio(int[] v)
    {
        for (int i = 0; i < v.Length; i++)
            if (v[i] != 0)
                Console.Write($"Numero {i}: {v[i]}\n");
    }
}