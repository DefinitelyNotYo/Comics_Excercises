internal class Program
{
    private static void Main(string[] args)
    {
        int[] v = { 2, 10, 7, 1, 117, 54 };
        Console.Write($"Il tuo array iniziale è:");
        showArray(v);
        Console.Write($"\n\nIl tuo array ordinato è:");
        //bubblesort(v);
        insertionsort(v);
        showArray(v);
    }
    public static void showArray(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write($" {a[i]}");
        }
    }
    public static int[] bubblesort(int[] a) //testato e funzionante
    {
        int box;
        for (int i = 0; i < a.Length-1; i++)
        {
            for(int j = 0; j < a.Length-i-1; j++)
            {
                if (a[j] > a[j + 1])
                {
                    box = a[j + 1];
                    a[j + 1] = a[j];
                    a[j] = box;
                }
            }
        }
        return a;
    }
    public static int[] insertionsort(int[] a) //WiP, vanno sistemate alcune cose
    {
        int box;
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (a[i] < a[j])
                {
                    box = a[i];
                    a[i] = a[j];
                    a[j] = box;
                    break;
                }
            }
        }
        return a;
    }
}