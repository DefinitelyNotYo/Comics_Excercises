internal class Program
{
    private static void Main(string[] args)
    {
        bool nSpecial;
        Console.WriteLine("Inserisci quattro numeri interi");
        int n1 = Convert.ToInt32(Console.ReadLine());
        int n2 = Convert.ToInt32(Console.ReadLine());
        int n3 = Convert.ToInt32(Console.ReadLine());
        int n4 = Convert.ToInt32(Console.ReadLine());
        nSpecial = true;

        nSpecial=(((n1 + n2) * (n3 - n4)) == 42);
        Console.WriteLine(nSpecial);


    }   
}
