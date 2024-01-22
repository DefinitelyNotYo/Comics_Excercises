using System.ComponentModel.Design;

internal class Program
{
    private static void Main(string[] args)
    {
        AlberoBinario tree = new AlberoBinario();

        Console.WriteLine("Sto aggiungendo 10"); 
        tree.add(10);
        Console.WriteLine("Sto aggiungendo 20"); 
        tree.add(20);
        Console.WriteLine("Sto aggiungendo 15"); 
        tree.add(15);


        
        Console.WriteLine($"\nLa radice {tree.Root.Valore} ha un'altezza di {tree.Root.Altezza}\n");
        Console.WriteLine($"Altezza sottoalbero Sx: {tree.AltezzaSx}");
        Console.WriteLine($"Altezza sottoalbero Dx: {tree.AltezzaDx}");


        Console.WriteLine("Sto aggiungendo 16"); 
        tree.add(16);
        Console.WriteLine("Sto aggiungendo 14"); 
        tree.add(14);
        Console.WriteLine("Sto aggiungendo 13"); 
        tree.add(13);
        Console.WriteLine("Sto aggiungendo 12"); 
        tree.add(12);

        Console.WriteLine($"\n\n");
        tree.show();

        tree.LeftRotate(ref tree.Root);

        tree.show();
        //Console.WriteLine($"\n\n{tree.Root.Sinistro.Destro.Valore} - {tree.Root.Sinistro.Destro.Altezza}");

        /*
        tree.add(50);
        tree.add(30);
        tree.add(25);

        tree.add(37);
        tree.add(35);
        tree.add(60);
        tree.add(59);
        tree.add(57);
        tree.add(58);
        tree.add(56);
        tree.add(54);
        tree.add(53);

        tree.add(55);
        tree.add(70);
        tree.add(63);
        tree.add(80);
        
        */

    }
    public class Nodo
    {
        public int Valore;
        public int Altezza;
        public Nodo Sinistro;
        public Nodo Destro;
        public Nodo(int value)
        {
            Valore = value;
            Altezza = 1;
            Sinistro = Destro = null;
        }

    }
    public class AlberoBinario
    {
        public Nodo Root;
        public int AltezzaSx;
        public int AltezzaDx;
        public AlberoBinario()
        {
            Root = null;
            AltezzaDx = 0;
            AltezzaSx = 0;
        }
        public void add(int value)
        {
            addNode(ref Root, value);
            equilibrium(ref Root);
            updateHeights(ref Root);
        }
        public void addNode(ref Nodo root, int value)
        {
            if (root == null)
            {
                root = new Nodo(value);
            }
            else if (value < root.Valore)
            {
                addNode(ref root.Sinistro, value);
            }
            else if (value > root.Valore)
            {
                addNode(ref root.Destro, value);
            }
            root.Altezza = 1 + Math.Max(findHeight(ref root.Sinistro), findHeight(ref root.Destro));
            AltezzaSx = findHeight(ref Root.Sinistro);
            AltezzaDx = findHeight(ref Root.Destro);
        }
        public void equilibrium(ref Nodo root)
        {
            updateHeights(ref root);
            AltezzaSx = findHeight(ref root.Sinistro);
            AltezzaDx = findHeight(ref root.Destro);
            int statusQuo = AltezzaSx - AltezzaDx;
            if (statusQuo > 1)
                RightRotate();
            else if (statusQuo < -1)
                LeftRotate(ref root);
            else
                return; //l'albero è equilibrato quindi non fa niente
        }
        public void show()
        {
            showBT(Root);
        }
        public void showBT(Nodo root)
        {
            if (root == null)
                return;          
            showBT(root.Sinistro);
            Console.Write($" {root.Valore}");
            Console.Write($" - {root.Altezza}\n");
            showBT(root.Destro);
        }
        public int findHeight(ref Nodo root)
        {
            if (root == null)
                return 0;
            return root.Altezza;
        }
        public Nodo findMin(ref Nodo root)
        {
            if (root != null)
            {
                if (root.Sinistro != null)
                    return findMin(ref root.Sinistro);
                else
                    return root;
            }
            else
                return root;
        }
        public Nodo findMinBeta(ref Nodo root)
        {
            if (root != null)
            {
                if (root.Sinistro.Sinistro != null)
                    findGenitoreDelMinore(ref root.Sinistro);
                else
                {
                    Nodo son = root.Sinistro;
                    if (son.Destro != null)
                        root.Sinistro = son.Destro;
                    return son;
                }
            }
            return root;
        }
        public Nodo findGenitoreDelMinore(ref Nodo root)
        {
            if (root != null)
            {
                if (root.Sinistro.Sinistro != null)
                    findGenitoreDelMinore(ref root.Sinistro);
                else
                    return root;
            }
            return root;
        }
        public void fixGenitoreDelMinore(ref Nodo root)
        {
            if (root != null)
            {
                if (root.Sinistro.Sinistro != null)
                    fixGenitoreDelMinore(ref root.Sinistro);
                else
                {
                    Nodo tmp = root.Sinistro.Destro;
                    root.Sinistro = tmp;
                }
            }
        }
        public void setGenitoreDelMaggiore(ref Nodo root)
        {
            if (root != null)
            {
                if (root.Destro.Destro != null)
                    setGenitoreDelMaggiore(ref root.Destro);
                else
                {
                    Nodo tmp = root.Destro.Sinistro;
                    root.Destro = tmp;
                }
            }
        }
        public Nodo findMax(ref Nodo root)
        {
            if (root != null)
            {
                if (root.Destro != null)
                    findMax(ref root.Destro);
                else
                    return root;
            }
            return root;
        }
        public Nodo findGenitoreDelMaggiore(ref Nodo root)
        {
            if (root != null)
            {
                if (root.Destro.Destro != null)
                    findGenitoreDelMinore(ref root.Destro);
                else
                    return root;
            }
            return root;
        }
        public void LeftRotate(ref Nodo root)
        {
            Console.WriteLine($"In questo momento il valore più piccolo del sotto-albero di dx è {findMin(ref Root.Destro).Valore}");
            if(findMin(ref root.Destro) == root.Destro) //questa parte funziona (?)
            {
                Nodo prevRoot = root;
                Nodo prevRootDxDx = root.Destro.Destro;


                Nodo tmp = findMin(ref root.Destro);
                Console.WriteLine($"Sto ruotando a sinistra e impostando {tmp.Valore} come radice");
                root = tmp;
                root.Sinistro = prevRoot;
                root.Destro = prevRootDxDx;
                root.Sinistro.Destro = null;
            }
            else 
            {
                Nodo PrevRoot = root;
                Nodo PrevRootDx = root.Destro;
                Nodo Tmp = findMinBeta(ref root.Destro);

                Console.WriteLine($"Sto ruotando a sinistra e impostando {Tmp.Valore} come radice");

                root = Tmp;
                root.Sinistro = PrevRoot;
                root.Sinistro.Destro = null;
                root.Destro = PrevRootDx;

                Console.WriteLine($"\nAlla fine della rotazione i tuoi nodi sono disposti nel seguente modo\n\n Root: {root.Valore}\nRoot Sx: {root.Sinistro.Valore}\nRoot Dx: {root.Destro.Valore}");
            }
        }
        public void RightRotate()
        {
            if (findMin(ref Root.Sinistro) == Root.Sinistro)
            {
                Nodo prevRoot = Root;
                Nodo prevRootSxSx = Root.Sinistro.Sinistro;


                Nodo tmp = findMax(ref Root.Sinistro);
                Console.WriteLine($"Sto ruotando a destra e impostando {tmp.Valore} come radice");
                Root = tmp;
                Root.Destro = prevRoot;
                Root.Sinistro = prevRootSxSx;
                Root.Destro.Sinistro = null;
            }
            else
            {
                Nodo PrevRoot = Root;
                Nodo PrevRootSx = Root.Sinistro;
                Nodo Tmp = findMax(ref Root.Sinistro);
                Nodo Tmp2 = findGenitoreDelMaggiore(ref Root.Sinistro);

                Console.WriteLine($"Sto ruotando a destra e impostando {Tmp.Valore} come radice");

                Root = Tmp;
                Root.Destro = PrevRoot;
                Root.Sinistro = PrevRootSx;
                Root.Destro.Sinistro = null;

                setGenitoreDelMaggiore(ref Root.Sinistro);
            }
        }
        public int updateHeights(ref Nodo root)
        {
            if (root == null)
                return 0;
            root.Altezza = 1 + Math.Max(updateHeights(ref root.Sinistro), updateHeights(ref root.Destro));
            return root.Altezza;
        }
    }
}