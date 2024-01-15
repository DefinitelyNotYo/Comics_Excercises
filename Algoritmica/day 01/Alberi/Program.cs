using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        AlberoBinario tree = new AlberoBinario();
        tree.addNode(ref tree.Root, 50);
        tree.addNode(ref tree.Root, 30);
        tree.addNode(ref tree.Root, 20);
        tree.addNode(ref tree.Root, 40);
        tree.addNode(ref tree.Root, 70);
        tree.addNode(ref tree.Root, 60);
        tree.addNode(ref tree.Root, 80);
        Nodo nodoRicerca = new Nodo(100);
        Console.WriteLine(nodoRicerca.Valore);
        nodoRicerca = tree.searchNode(tree.Root, 40);
        Console.WriteLine(nodoRicerca.Valore); //'sta roba dice che nodoRicerca è null
    }
}

public class Nodo
{
    public int Valore;
    public Nodo Sinistro, Destro;

    public Nodo(int valore)
    {
        Valore = valore;
        Sinistro = Destro = null;
    }
}

public class AlberoBinario
{
    public Nodo Root;

    public AlberoBinario()
    {
        Root = null;
    }

    public void addNode(ref Nodo root, int value)
    {
        if (root == null)
        {
            root = new Nodo(value);
        }
        if (value < root.Valore)
        {
            addNode(ref root.Sinistro, value);
        }
        else if (value > root.Valore)
        {
            addNode(ref root.Destro, value);
        }
        return;
    }
    public Nodo searchNode(Nodo root, int value)
    {
        if(root.Valore == value)
        {
            Console.WriteLine("ho trovato il nodo"); //testing
            Console.WriteLine(root.Valore); //testing
            return root;
        }
        if(value < root.Valore)
        {
            searchNode(root.Sinistro, value);
        }
        if(value > root.Valore)
        {
            searchNode(root.Destro, value);
        }
        return null;
    }
    public void showBT(Nodo root)
    {
        if (root != null)
        {
            showBT(root.Sinistro);
            Console.Write($" {root.Valore}");
            showBT(root.Destro);
        }
    }
}
