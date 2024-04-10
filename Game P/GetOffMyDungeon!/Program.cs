//Riprendi dalla non colorazione del generale in a5 sistemando la funzione checkbattlesquare [Ultima modifica: 27/01, 16:33]

using System;
using System.ComponentModel;
using System.Security.Cryptography;
using static Program;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.Read();
        newGame();
    }

    public class Square
    {
        public int[] rowReference { get; set; }           //il nome della casella?
        public int[] columnReference { get; set; }           //il nome della casella?
        public string top { get; set; }                   //le tre parti di una casella
        public string mid { get; set; }
        public string bot { get; set; }
        public bool occupied { get; set; }               //indica se la casella è occupata
        public bool lighted { get; set; }                 //indica se la casella deve essere evidenziata
        public string idP { get; set; }                 //indica se la casella deve essere evidenziata
        public Square(int[] r, int[] c, string topSquare, string midSquare, string botSquare) //costruttore della classe casella, questo iipo viene usato per il campo
        {
            rowReference = r;
            columnReference = c;
            idP = "0";
            top = topSquare;
            mid = midSquare;
            bot = botSquare;
        }
        public Square(int[] r, int[] c, string topSquare, string botSquare) //costruttore della classe casella, questo tipo viene usato per i comandi
        {
            rowReference = r;
            columnReference = c;
            top = topSquare;
            bot = botSquare;
        }
    }
    public class Unit
    {
        public string coordinate { get; set; }
        public string identity { get; set; } //identifica la classe dell'unità di cui si sta parlando
        public string idUnit { get; set; } //Identifica l'appartenenza a un giocatore
        public string name1 { get; set; } //prima riga del nome
        public string name2 { get; set; } //seconda riga del nome
        public int currentHealth { get; set; } //hp attuali
        public int maxHealth { get; set; } //hp massimi
        public int maxAttack { get; set; } //danni massimi
        public int minAttack { get; set; } //danni minimi
        public int manaCost { get; set; } //costo di evocazione
        public Unit(string idplayer, string unit_name)
        {
            idUnit = idplayer;
            switch (unit_name)
            {
                case " ":
                    name1 = "             ";
                    break;
                case " sgorbio        ":
                    identity = " sgorbio        ";
                    name1 = "   Sgorbio   ";
                    name2 = "             ";
                    currentHealth = 10;
                    maxHealth = 10;
                    maxAttack = 15;
                    minAttack = 5;
                    manaCost = 100;
                    break;
                case " lancia ciottoli":
                    identity = " lancia ciottoli";
                    name1 = "   Lancia    ";
                    name2 = "   Ciottoli  ";
                    currentHealth = 10;
                    maxHealth = 10;
                    maxAttack = 15;
                    minAttack = 5;
                    manaCost = 150;
                    break;
                case " cavalca pony   ":
                    identity = " cavalca pony   ";
                    name1 = "   Cavalca   ";
                    name2 = "   Pony      ";
                    currentHealth = 10;
                    maxHealth = 10;
                    maxAttack = 15;
                    minAttack = 5;
                    manaCost = 200;
                    break;
                case " sciamano goblin":
                    identity = " sciamano goblin";
                    name1 = "   Sciamano  ";
                    name2 = "   Goblin    ";
                    currentHealth = 10;
                    maxHealth = 10;
                    maxAttack = 15;
                    minAttack = 1;
                    manaCost = 300;
                    break;
                case " ogre           ":
                    identity = " ogre           ";
                    name1 = "   Ogre      ";
                    name2 = "             ";
                    currentHealth = 10;
                    maxHealth = 10;
                    maxAttack = 15;
                    minAttack = 1;
                    manaCost = 400;
                    break;
                case "generale goblin":
                    name1 = "   Generale  ";
                    name2 = "   Goblin    ";
                    currentHealth = 10;
                    maxHealth = 10;
                    maxAttack = 15;
                    minAttack = 5;
                    manaCost = 1001;
                    break;
            }
        }
        public string showHealthBar()
        {
            return $"   {currentHealth}/{maxHealth}     ";
        }
    }
    public class Player
    {

        public string id { get; set; } //Identifica il giocatore, quindi giocatore 1 o giocatore 2

        public bool turn = false;
        public int manaLeft { get; set; } //Risorse del giocatore
        public int manaSpentThisTurn { get; set; }
        public List<Unit> pool = new List<Unit> //pool intera da cui vengono tolti quelli in mano
        {

        };
        public List<Unit> hand = new List<Unit> //mano da cui vengono tolti quando generati
        {

        };
        public List<Unit> field = new List<Unit> //elenco di quelli in campo
        {

        };
        public List<Unit> tokens = new List<Unit> //segnaposto per quando un giocatore finisce le unità
        {

        };
        public Player(string idplayer)
        {
            manaLeft = 1000;
            id = idplayer;

            Unit spaziovuoto = new Unit(id, " ");
            Unit sgorbio1 = new Unit(id, " sgorbio        ");
            Unit sgorbio2 = new Unit(id, " sgorbio        ");
            Unit sgorbio3 = new Unit(id, " sgorbio        ");
            Unit sgorbio4 = new Unit(id, " sgorbio        ");
            Unit sgorbio5 = new Unit(id, " sgorbio        ");
            Unit sgorbio6 = new Unit(id, " sgorbio        ");
            Unit lanciaciottoli1 = new Unit(id, " lancia ciottoli");
            Unit lanciaciottoli2 = new Unit(id, " lancia ciottoli");
            Unit lanciaciottoli3 = new Unit(id, " lancia ciottoli");
            Unit lanciaciottoli4 = new Unit(id, " lancia ciottoli");
            Unit lanciaciottoli5 = new Unit(id, " lancia ciottoli");
            Unit lanciaciottoli6 = new Unit(id, " lancia ciottoli");
            Unit cavalcapony1 = new Unit(id, " cavalca pony   ");
            Unit cavalcapony2 = new Unit(id, " cavalca pony   ");
            Unit cavalcapony3 = new Unit(id, " cavalca pony   ");
            Unit sciamanogoblin1 = new Unit(id, " sciamano goblin");
            Unit sciamanogoblin2 = new Unit(id, " sciamano goblin");
            Unit sciamanogoblin3 = new Unit(id, " sciamano goblin");
            Unit ogre1 = new Unit(id, " ogre           ");
            Unit ogre2 = new Unit(id, " ogre           ");
            Unit generalegoblin = new Unit(id, "generale goblin");
            field.Add(generalegoblin);
            pool.Add(sgorbio1);
            pool.Add(sgorbio2);
            pool.Add(sgorbio3);
            pool.Add(sgorbio4);
            pool.Add(sgorbio5);
            pool.Add(sgorbio6);
            pool.Add(lanciaciottoli1);
            pool.Add(lanciaciottoli2);
            pool.Add(lanciaciottoli3);
            pool.Add(lanciaciottoli4);
            pool.Add(lanciaciottoli5);
            pool.Add(lanciaciottoli6);
            pool.Add(cavalcapony1);
            pool.Add(cavalcapony2);
            pool.Add(cavalcapony3);
            pool.Add(sciamanogoblin1);
            pool.Add(sciamanogoblin2);
            pool.Add(sciamanogoblin3);
            pool.Add(ogre1);
            pool.Add(ogre2);

        }
    }
    public static void newGame()
    {
        Player player1 = new Player("1");
        Player player2 = new Player("2");
        shuffle(player1);
        shuffle(player2);

        Square a1 = new Square([5, 6, 7], [2, 2, 2], "             ", "             ", "             ");
        Square a2 = new Square([9, 10, 11], [2, 2, 2], "             ", "             ", "             ");
        Square a3 = new Square([13, 14, 15], [2, 2, 2], "             ", "             ", "             ");
        Square a4 = new Square([17, 18, 19], [2, 2, 2], "             ", "             ", "             ");
        Square a5 = new Square([21, 22, 23], [2, 2, 2], "             ", "             ", "             ");
        Square a6 = new Square([25, 26, 27], [2, 2, 2], "             ", "             ", "             ");
        Square a7 = new Square([29, 30, 31], [2, 2, 2], "             ", "             ", "             ");
        Square a8 = new Square([33, 34, 35], [2, 2, 2], "             ", "             ", "             ");
        Square a9 = new Square([37, 38, 39], [2, 2, 2], "             ", "             ", "             ");
        Square a10 = new Square([41, 42, 43], [2, 2, 2], "             ", "             ", "             ");

        Square b1 = new Square([5, 6, 7], [4, 4, 4], "             ", "             ", "             ");
        Square b2 = new Square([9, 10, 11], [4, 4, 4], "             ", "             ", "             ");
        Square b3 = new Square([13, 14, 15], [4, 4, 4], "             ", "             ", "             ");
        Square b4 = new Square([17, 18, 19], [4, 4, 4], "             ", "             ", "             ");
        Square b5 = new Square([21, 22, 23], [4, 4, 4], "             ", "             ", "             ");
        Square b6 = new Square([25, 26, 27], [4, 4, 4], "             ", "             ", "             ");
        Square b7 = new Square([29, 30, 31], [4, 4, 4], "             ", "             ", "             ");
        Square b8 = new Square([33, 34, 35], [4, 4, 4], "             ", "             ", "             ");
        Square b9 = new Square([37, 38, 39], [4, 4, 4], "             ", "             ", "             ");
        Square b10 = new Square([41, 42, 43], [4, 4, 4], "             ", "             ", "             ");

        Square c1 = new Square([5, 6, 7], [6, 6, 6], "             ", "             ", "             ");
        Square c2 = new Square([9, 10, 11], [6, 6, 6], "             ", "             ", "             ");
        Square c3 = new Square([13, 14, 15], [6, 6, 6], "             ", "             ", "             ");
        Square c4 = new Square([17, 18, 19], [6, 6, 6], "             ", "             ", "             ");
        Square c5 = new Square([21, 22, 23], [6, 6, 6], "             ", "             ", "             ");
        Square c6 = new Square([25, 26, 27], [6, 6, 6], "             ", "             ", "             ");
        Square c7 = new Square([29, 30, 31], [6, 6, 6], "             ", "             ", "             ");
        Square c8 = new Square([33, 34, 35], [6, 6, 6], "             ", "             ", "             ");
        Square c9 = new Square([37, 38, 39], [6, 6, 6], "             ", "             ", "             ");
        Square c10 = new Square([41, 42, 43], [6, 6, 6], "             ", "             ", "             ");

        Square d1 = new Square([5, 6, 7], [8, 8, 8], "             ", "             ", "             ");
        Square d2 = new Square([9, 10, 11], [8, 8, 8], "             ", "             ", "             ");
        Square d3 = new Square([13, 14, 15], [8, 8, 8], "             ", "             ", "             ");
        Square d4 = new Square([17, 18, 19], [8, 8, 8], "             ", "             ", "             ");
        Square d5 = new Square([21, 22, 23], [8, 8, 8], "             ", "             ", "             ");
        Square d6 = new Square([25, 26, 27], [8, 8, 8], "             ", "             ", "             ");
        Square d7 = new Square([29, 30, 31], [8, 8, 8], "             ", "             ", "             ");
        Square d8 = new Square([33, 34, 35], [8, 8, 8], "             ", "             ", "             ");
        Square d9 = new Square([37, 38, 39], [8, 8, 8], "             ", "             ", "             ");
        Square d10 = new Square([41, 42, 43], [8, 8, 8], "             ", "             ", "             ");

        Square e1 = new Square([5, 6, 7], [10, 10, 10], "             ", "             ", "             ");
        Square e2 = new Square([9, 10, 11], [10, 10, 10], "             ", "             ", "             ");
        Square e3 = new Square([13, 14, 15], [10, 10, 10], "             ", "             ", "             ");
        Square e4 = new Square([17, 18, 19], [10, 10, 10], "             ", "             ", "             ");
        Square e5 = new Square([21, 22, 23], [10, 10, 10], "             ", "             ", "             ");
        Square e6 = new Square([25, 26, 27], [10, 10, 10], "             ", "             ", "             ");
        Square e7 = new Square([29, 30, 31], [10, 10, 10], "             ", "             ", "             ");
        Square e8 = new Square([33, 34, 35], [10, 10, 10], "             ", "             ", "             ");
        Square e9 = new Square([37, 38, 39], [10, 10, 10], "             ", "             ", "             ");
        Square e10 = new Square([41, 42, 43], [10, 10, 10], "             ", "             ", "             ");

        Square f1 = new Square([5, 6, 7], [12, 12, 12], "             ", "             ", "             ");
        Square f2 = new Square([9, 10, 11], [12, 12, 12], "             ", "             ", "             ");
        Square f3 = new Square([13, 14, 15], [12, 12, 12], "             ", "             ", "             ");
        Square f4 = new Square([17, 18, 19], [12, 12, 12], "             ", "             ", "             ");
        Square f5 = new Square([21, 22, 23], [12, 12, 12], "             ", "             ", "             ");
        Square f6 = new Square([25, 26, 27], [12, 12, 12], "             ", "             ", "             ");
        Square f7 = new Square([29, 30, 31], [12, 12, 12], "             ", "             ", "             ");
        Square f8 = new Square([33, 34, 35], [12, 12, 12], "             ", "             ", "             ");
        Square f9 = new Square([37, 38, 39], [12, 12, 12], "             ", "             ", "             ");
        Square f10 = new Square([41, 42, 43], [12, 12, 12], "             ", "             ", "             ");

        Square g1 = new Square([5, 6, 7], [14, 14, 14], "             ", "             ", "             ");
        Square g2 = new Square([9, 10, 11], [14, 14, 14], "             ", "             ", "             ");
        Square g3 = new Square([13, 14, 15], [14, 14, 14], "             ", "             ", "             ");
        Square g4 = new Square([17, 18, 19], [14, 14, 14], "             ", "             ", "             ");
        Square g5 = new Square([21, 22, 23], [14, 14, 14], "             ", "             ", "             ");
        Square g6 = new Square([25, 26, 27], [14, 14, 14], "             ", "             ", "             ");
        Square g7 = new Square([29, 30, 31], [14, 14, 14], "             ", "             ", "             ");
        Square g8 = new Square([33, 34, 35], [14, 14, 14], "             ", "             ", "             ");
        Square g9 = new Square([37, 38, 39], [14, 14, 14], "             ", "             ", "             ");
        Square g10 = new Square([41, 42, 43], [14, 14, 14], "             ", "             ", "             ");

        Square h1 = new Square([5, 6, 7], [16, 16, 16], "             ", "             ", "             ");
        Square h2 = new Square([9, 10, 11], [16, 16, 16], "             ", "             ", "             ");
        Square h3 = new Square([13, 14, 15], [16, 16, 16], "             ", "             ", "             ");
        Square h4 = new Square([17, 18, 19], [16, 16, 16], "             ", "             ", "             ");
        Square h5 = new Square([21, 22, 23], [16, 16, 16], "             ", "             ", "             ");
        Square h6 = new Square([25, 26, 27], [16, 16, 16], "             ", "             ", "             ");
        Square h7 = new Square([29, 30, 31], [16, 16, 16], "             ", "             ", "             ");
        Square h8 = new Square([33, 34, 35], [16, 16, 16], "             ", "             ", "             ");
        Square h9 = new Square([37, 38, 39], [16, 16, 16], "             ", "             ", "             ");
        Square h10 = new Square([41, 42, 43], [16, 16, 16], "             ", "             ", "             ");

        Square i1 = new Square([5, 6, 7], [18, 18, 18], "             ", "             ", "             ");
        Square i2 = new Square([9, 10, 11], [18, 18, 18], "             ", "             ", "             ");
        Square i3 = new Square([13, 14, 15], [18, 18, 18], "             ", "             ", "             ");
        Square i4 = new Square([17, 18, 19], [18, 18, 18], "             ", "             ", "             ");
        Square i5 = new Square([21, 22, 23], [18, 18, 18], "             ", "             ", "             ");
        Square i6 = new Square([25, 26, 27], [18, 18, 18], "             ", "             ", "             ");
        Square i7 = new Square([29, 30, 31], [18, 18, 18], "             ", "             ", "             ");
        Square i8 = new Square([33, 34, 35], [18, 18, 18], "             ", "             ", "             ");
        Square i9 = new Square([37, 38, 39], [18, 18, 18], "             ", "             ", "             ");
        Square i10 = new Square([41, 42, 43], [18, 18, 18], "             ", "             ", "             ");

        Square j1 = new Square([5, 6, 7], [20, 20, 20], "             ", "             ", "             ");
        Square j2 = new Square([9, 10, 11], [20, 20, 20], "             ", "             ", "             ");
        Square j3 = new Square([13, 14, 15], [20, 20, 20], "             ", "             ", "             ");
        Square j4 = new Square([17, 18, 19], [20, 20, 20], "             ", "             ", "             ");
        Square j5 = new Square([21, 22, 23], [20, 20, 20], "             ", "             ", "             ");
        Square j6 = new Square([25, 26, 27], [20, 20, 20], "             ", "             ", "             ");
        Square j7 = new Square([29, 30, 31], [20, 20, 20], "             ", "             ", "             ");
        Square j8 = new Square([33, 34, 35], [20, 20, 20], "             ", "             ", "             ");
        Square j9 = new Square([37, 38, 39], [20, 20, 20], "             ", "             ", "             ");
        Square j10 = new Square([41, 42, 43], [20, 20, 20], "             ", "             ", "             ");

        Square command1 = new Square([45, 46], [13, 13], "   evoca     ", "   unità     ");
        Square command2 = new Square([45, 46], [14, 14], " seleziona   ", " unità       ");
        Square command3 = new Square([45, 46], [15, 15], " rimescola   ", " mano        ");
        Square command4 = new Square([45, 46], [16, 16], " esamina     ", " casella     ");
        Square command5 = new Square([45, 46], [17, 17], " mostra      ", " manuale     ");
        Square command6 = new Square([45, 46], [18, 18], " passa       ", " turno       ");

        string[] display = { "Mossa: ", "Indica la casella dove vuoi posizionare l'unità (Es. a1, g7, c5):", "Seleziona l'unità da evocare: " };

        //var rdm = new Random();
        int playerplaying = /*rdm.Next(1, 3)*/1;

        int round = 0;
        //PUNTATORI DEL CAMPO DI GIOCO v
        Square[,] battlecamp = new Square[10, 10] {
            { a1, b1, c1, d1, e1, f1, g1, h1, i1, j1 },
            { a2, b2, c2, d2, e2, f2, g2, h2, i2, j2 },
            { a3, b3, c3, d3, e3, f3, g3, h3, i3, j3 },
            { a4, b4, c4, d4, e4, f4, g4, h4, i4, j4 },
            { a5, b5, c5, d5, e5, f5, g5, h5, i5, j5 },
            { a6, b6, c6, d6, e6, f6, g6, h6, i6, j6 },
            { a7, b7, c7, d7, e7, f7, g7, h7, i7, j7 },
            { a8, b8, c8, d8, e8, f8, g8, h8, i8, j8 },
            { a9, b9, c9, d9, e9, f9, g9, h9, i9, j9 },
            { a10, b10, c10, d10, e10, f10, g10, h10, i10, j10 },
        };

        a5.top = player1.field[0].name1;
        a5.mid = player1.field[0].name2;
        a5.bot = player1.field[0].showHealthBar();
        a5.occupied = true;
        a5.idP = "1";

        j6.top = player2.field[0].name1;
        j6.mid = player2.field[0].name2;
        j6.bot = player2.field[0].showHealthBar();
        j6.occupied = true;
        j6.idP = "2";


        string[,] wholeTable =
        {      

            //  RIGA 0   V
            { "             ","             ","             "," ","             "," ","             "," ","             ","","","","","","","         Round",$"  {round}         ","             ","             ","             ","             ","             ","             "},
            { "             ","             ","             "," ","             "," ","             "," ","             ","","","","","","","  Turno  di",$" Giocatore {playerplaying}   ","             ","             ","             ","             ","             ","             ",},
            { "             ","             ","             "," ","             "," ","             "," ","             ","","","","","","","             ","             ","             ","             ","             ","             ","             ","             "},
            { "             ","             ","      A      "," ","      B      "," ","      C      "," ","      D      "," ","      E      "," ","      F      "," ","      G      "," ","      H      "," ","      I      "," ","      J      ","             ","             "},

            { "             ","             ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             ","             ","             "},

            //  RIGA 1   V
            { "             ","             ",     a1.top   ," ",     b1.top   ," ",     c1.top   ," ",     d1.top   ," ",     e1.top   ," ",     f1.top   ," ",     g1.top   ," ",     h1.top   ," ",     i1.top   ," ",     j1.top    ,"             ","             "},
            { "             ","        1    ",     a1.mid   ," ",     b1.mid   ," ",     c1.mid   ," ",     d1.mid   ," ",     e1.mid   ," ",     f1.mid   ," ",     g1.mid   ," ",     h1.mid   ," ",     i1.mid   ," ",     j1.mid    ,"    1        ","             "},
            { "             ","             ",     a1.bot   ," ",     b1.bot   ," ",     c1.bot   ," ",     d1.bot   ," ",     e1.bot   ," ",     f1.bot   ," ",     g1.bot   ," ",     h1.bot   ," ",     i1.bot   ," ",     j1.bot    ,"             ","             "},

            { " Giocatore 1 ","             ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             ","         ","  Giocatore 2    "},
            //  RIGA 2   V
            { "             ","             ",     a2.top   ," ",     b2.top   ," ",     c2.top   ," ",     d2.top   ," ",     e2.top   ," ",     f2.top   ," ",     g2.top   ," ",     h2.top   ," ",     i2.top   ," ",     j2.top    ,"             ","             "},
            { "             ","        2    ",     a2.mid   ," ",     b2.mid   ," ",     c2.mid   ," ",     d2.mid   ," ",     e2.mid   ," ",     f2.mid   ," ",     g2.mid   ," ",     h2.mid   ," ",     i2.mid   ," ",     j2.mid    ,"    2        ","             "},
            { "             ","             ",     a2.bot   ," ",     b2.bot   ," ",     c2.bot   ," ",     d2.bot   ," ",     e2.bot   ," ",     f2.bot   ," ",     g2.bot   ," ",     h2.bot   ," ",     i2.bot   ," ",     j2.bot    ,"             ","             "},
            { "             ","             ","                "," ","            "," ","            "," ","            "," ","            "," ","            "," ","            "," ","            "," ","            "," ","                ","           ","             "},

            //  RIGA 3   V
            { "                ","          ",     a3.top   ," ",     b3.top   ," ",     c3.top   ," ",     d3.top   ," ",     e3.top   ," ",     f3.top   ," ",     g3.top   ," ",     h3.top   ," ",     i3.top   ," ",     j3.top    ,"          ","                "},
            { player1.hand[0].identity,"     3    ",     a3.mid   ," ",     b3.mid   ," ",     c3.mid   ," ",     d3.mid   ," ",     e3.mid   ," ",     f3.mid   ," ",     g3.mid   ," ",     h3.mid   ," ",     i3.mid   ," ",     j3.mid    ,"    3     ",player2.hand[0].identity},
            { $" {player1.hand[0].manaCost}","                      ",     a3.bot   ," ",     b3.bot   ," ",     c3.bot   ," ",     d3.bot   ," ",     e3.bot   ," ",     f3.bot   ," ",     g3.bot   ," ",     h3.bot   ," ",     i3.bot   ," ",     j3.bot    ,"          ",$" {player2.hand[0].manaCost}"},
            { "                ","          ","              "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             ","             ","             "},

            //  RIGA 4   V
            { player1.hand[1].identity,"          ",     a4.top   ," ",     b4.top   ," ",     c4.top   ," ",     d4.top   ," ",     e4.top   ," ",     f4.top   ," ",     g4.top   ," ",     h4.top   ," ",     i4.top   ," ",     j4.top    ,"          ",player2.hand[1].identity},
            { $" {player1.hand[1].manaCost}","                 4    ",     a4.mid   ," ",     b4.mid   ," ",     c4.mid   ," ",     d4.mid   ," ",     e4.mid   ," ",     f4.mid   ," ",     g4.mid   ," ",     h4.mid   ," ",     i4.mid   ," ",     j4.mid    ,"    4     ",$" {player2.hand[1].manaCost}"},
            { "                ","          ",     a4.bot   ," ",     b4.bot   ," ",     c4.bot   ," ",     d4.bot   ," ",     e4.bot   ," ",     f4.bot   ," ",     g4.bot   ," ",     h4.bot   ," ",     i4.bot   ," ",     j4.bot    ,"          ","                "},
            { player1.hand[2].identity,"","","","","","          ","            "," ","            "," ","             "," ","            "," ","             ","             ","             ","             ","             ","             ","                  ",player2.hand[2].identity},  
            
            //  RIGA 5   V
            { $" {player1.hand[2].manaCost}","                      ",     a5.top   ," ",     b5.top   ," ",     c5.top   ," ",     d5.top   ," ",     e5.top   ," ",     f5.top   ," ",     g5.top   ," ",     h5.top   ," ",     i5.top   ," ",     j5.top    ,"          ",$" {player2.hand[2].manaCost}"},
            { "                ","     5    ",     a5.mid   ," ",     b5.mid   ," ",     c5.mid   ," ",     d5.mid   ," ",     e5.mid   ," ",     f5.mid   ," ",     g5.mid   ," ",     h5.mid   ," ",     i5.mid   ," ",     j5.mid    ,"    5     ","                "},
            { player1.hand[3].identity,"          ",     a5.bot   ," ",     b5.bot   ," ",     c5.bot   ," ",     d5.bot   ," ",     e5.bot   ," ",     f5.bot   ," ",     g5.bot   ," ",     h5.bot   ," ",     i5.bot   ," ",     j5.bot    ,"          ",player2.hand[3].identity},
            { $" {player1.hand[3].manaCost}","","","","","","","            "," ","            "," ","             "," ","            "," ","             ","             ","             ","             ","             ","             ","                            ",$"             {player2.hand[3].manaCost}"},           
            
            //  RIGA 6   V
            { "                ","          ",     a6.top   ," ",     b6.top   ," ",     c6.top   ," ",     d6.top   ," ",     e6.top   ," ",     f6.top   ," ",     g6.top   ," ",     h6.top   ," ",     i6.top   ," ",     j6.top    ,"          ","                "},
            { player1.hand[4].identity,"     6    ",     a6.mid   ," ",     b6.mid   ," ",     c6.mid   ," ",     d6.mid   ," ",     e6.mid   ," ",     f6.mid   ," ",     g6.mid   ," ",     h6.mid   ," ",     i6.mid   ," ",     j6.mid    ,"    6     ",player2.hand[4].identity},
            { $" {player1.hand[4].manaCost}","                      ",     a6.bot   ," ",     b6.bot   ," ",     c6.bot   ," ",     d6.bot   ," ",     e6.bot   ," ",     f6.bot   ," ",     g6.bot   ," ",     h6.bot   ," ",     i6.bot   ," ",     j6.bot    ,"          ",$" {player2.hand[4].manaCost}"},
            { "                ","          ","              "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             ","             ","             "},
           
            //  RIGA 7   V
            { "                 ","         ",     a7.top   ," ",     b7.top   ," ",     c7.top   ," ",     d7.top   ," ",     e7.top   ," ",     f7.top   ," ",     g7.top   ," ",     h7.top   ," ",     i7.top   ," ",     j7.top    ,"          ","                 "},
            { "                 ","    7    ",     a7.mid   ," ",     b7.mid   ," ",     c7.mid   ," ",     d7.mid   ," ",     e7.mid   ," ",     f7.mid   ," ",     g7.mid   ," ",     h7.mid   ," ",     i7.mid   ," ",     j7.mid    ,"    7     ","                 "},
            { " Mana Disponibile","         ",     a7.bot   ," ",     b7.bot   ," ",     c7.bot   ," ",     d7.bot   ," ",     e7.bot   ," ",     f7.bot   ," ",     g7.bot   ," ",     h7.bot   ," ",     i7.bot   ," ",     j7.bot    ,"          "," Mana Disponibile"},
            { " 500/500         ","          ","              "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","            ","         "," 500/500         "},
          
            //  RIGA 8   V
            { "                 ","         ",     a8.top   ," ",     b8.top   ," ",     c8.top   ," ",     d8.top   ," ",     e8.top   ," ",     f8.top   ," ",     g8.top   ," ",     h8.top   ," ",     i8.top   ," ",     j8.top    ,"         ","                 "},
            { "                 ","    8    ",     a8.mid   ," ",     b8.mid   ," ",     c8.mid   ," ",     d8.mid   ," ",     e8.mid   ," ",     f8.mid   ," ",     g8.mid   ," ",     h8.mid   ," ",     i8.mid   ," ",     j8.mid    ,"    8     ","                 "},
            { " Riserva di Mana ","         ",     a8.bot   ," ",     b8.bot   ," ",     c8.bot   ," ",     d8.bot   ," ",     e8.bot   ," ",     f8.bot   ," ",     g8.bot   ," ",     h8.bot   ," ",     i8.bot   ," ",     j8.bot    ,"          "," Riserva di Mana "},
            { " 1000/1000       ","          ","              "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","            ","         "," 1000/1000       "},
          
            //  RIGA 9   V
            { "             ","             ",     a9.top   ," ",     b9.top   ," ",     c9.top   ," ",     d9.top   ," ",     e9.top   ," ",     f9.top   ," ",     g9.top   ," ",     h9.top   ," ",     i9.top   ," ",     j9.top    ,"             ","             "},
            { "             ","        9    ",     a9.mid   ," ",     b9.mid   ," ",     c9.mid   ," ",     d9.mid   ," ",     e9.mid   ," ",     f9.mid   ," ",     g9.mid   ," ",     h9.mid   ," ",     i9.mid   ," ",     j9.mid    ,"    9        ","             "},
            { "             ","             ",     a9.bot   ," ",     b9.bot   ," ",     c9.bot   ," ",     d9.bot   ," ",     e9.bot   ," ",     f9.bot   ," ",     g9.bot   ," ",     h9.bot   ," ",     i9.bot   ," ",     j9.bot    ,"             ","             "},
            { "                ","          ","              "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             ","             ","             "},

            //  RIGA 10   V
            { "             ","             ",     a10.top   ," ",     b10.top   ," ",     c10.top   ," ",     d10.top   ," ",     e10.top   ," ",     f10.top   ," ",     g10.top   ," ",     h10.top   ," ",     i10.top   ," ",     j10.top   ,"             ","             "},
            { "             ","        10   ",     a10.mid   ," ",     b10.mid   ," ",     c10.mid   ," ",     d10.mid   ," ",     e10.mid   ," ",     f10.mid   ," ",     g10.mid   ," ",     h10.mid   ," ",     i10.mid   ," ",     j10.mid   ,"    10       ","             "},
            { "             ","             ",     a10.bot   ," ",     b10.bot   ," ",     c10.bot   ," ",     d10.bot   ," ",     e10.bot   ," ",     f10.bot   ," ",     g10.bot   ," ",     h10.bot   ," ",     i10.bot   ," ",     j10.bot   ,"             ","             "},
            { "                ","          ","              "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             "," ","             ","             ","             "},

            //  RIGA 11  V
            { "             ","             ","            "," ","            ","","","","","","","","",  command1.top ,  command2.top ,  command3.top ,  command4.top ,  command5.top ,  command6.top ,"             ","             ","             ","             "},
            { "             ","             ","            "," ","            ","","","","","","","","",  command1.bot ,  command2.bot ,  command3.bot ,  command4.bot ,  command5.bot ,  command6.bot ,"             ","             ","             ","             "},
            { "             ","             ","            "," ","            ","","","","","","","","",             "",            "","             ","             ","             ","             ","             ","             ","             ","             "},
            { "             ","             ","            "," ","            ","","","","","","","","","","","","","","","","","",display[0]}
        };


        while (player1.field != null || player2.field != null) //finché uno dei due giocatori ha pedine in campo
        {
            round++;
            wholeTable[0, 16] = round.ToString();
            int[] actions1 = { 1, 1, 1 };
            while (playerplaying == 1)
            {
                Console.Clear();
                showGame(ref wholeTable, "0", "1", battlecamp, ref actions1);
                Console.WriteLine(checkBattleSquare(ref a5, 21, 2));
                string input1 = Console.ReadLine();
                switch (input1) //input menù di gioco
                {
                    case "evoca unità":
                        bool check = false;
                        while (check == false) //finché non hai compiuto l'evocazione o hai digitato indietro
                        {
                            Console.Clear();
                            showGame(ref wholeTable, "presummon", "1", battlecamp, ref actions1);
                            string inputHand = Console.ReadLine(); //chiede il nome dell'unità da evocare
                            switch (inputHand)
                            {
                                case "sgorbio":
                                    check = summonUnit(" sgorbio        ", ref battlecamp, ref player1, ref wholeTable, ref actions1);
                                    break;
                                case "lancia ciottoli":
                                    check = summonUnit(" lancia ciottoli", ref battlecamp, ref player1, ref wholeTable, ref actions1);
                                    break;
                                case "cavalca pony":
                                    check = summonUnit(" cavalca pony   ", ref battlecamp, ref player1, ref wholeTable, ref actions1);
                                    break;
                                case "sciamano goblin":
                                    check = summonUnit(" sciamano goblin", ref battlecamp, ref player1, ref wholeTable, ref actions1);
                                    break;
                                case "ogre":
                                    check = summonUnit(" ogre           ", ref battlecamp, ref player1, ref wholeTable, ref actions1);
                                    break;
                                case "indietro":
                                    check = true;
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "seleziona unità":
                        break;
                    case "rimescola mano":
                        if (actions1[2] > 0)
                        {
                            shuffle(player1);
                            wholeTable[14, 0] = player1.hand[0].identity;
                            wholeTable[15, 0] = $" {player1.hand[0].manaCost.ToString()}";
                            wholeTable[17, 0] = player1.hand[1].identity;
                            wholeTable[18, 0] = $" {player1.hand[1].manaCost.ToString()}";
                            wholeTable[20, 0] = player1.hand[2].identity;
                            wholeTable[21, 0] = $" {player1.hand[2].manaCost.ToString()}";
                            wholeTable[23, 0] = player1.hand[3].identity;
                            wholeTable[24, 0] = $" {player1.hand[3].manaCost.ToString()}";
                            wholeTable[26, 0] = player1.hand[4].identity;
                            wholeTable[27, 0] = $" {player1.hand[4].manaCost.ToString()}";
                            //actions1[2] -= 1;
                        }
                        break;
                    case "esamina casella":
                        break;
                    case "mostra manuale":
                        break;
                    case "passa turno":
                        playerplaying = 2;
                        wholeTable[1, 16] = " Giocatore 2";
                        break;
                    default:
                        break;
                }
            }
            int[] actions2 = { 1, 1, 1 };
            while (playerplaying == 2)
            {
                Console.Clear();
                showGame(ref wholeTable, "0", "2", battlecamp, ref actions2);
                string input2 = Console.ReadLine();
                switch (input2) //input menù di gioco
                {
                    case "evoca unità":
                        bool check = false;
                        while (check == false) //finché non hai compiuto l'evocazione o hai digitato indietro
                        {
                            Console.Clear();
                            showGame(ref wholeTable, "presummon", "2", battlecamp, ref actions1);
                            string inputHand = Console.ReadLine(); //chiede il nome dell'unità da evocare
                            switch (inputHand)
                            {
                                case "sgorbio":
                                    check = summonUnit(" sgorbio        ", ref battlecamp, ref player2, ref wholeTable, ref actions2);
                                    break;
                                case "lancia ciottoli":
                                    check = summonUnit(" lancia ciottoli", ref battlecamp, ref player2, ref wholeTable, ref actions2);
                                    break;
                                case "cavalca pony":
                                    check = summonUnit(" cavalca pony   ", ref battlecamp, ref player2, ref wholeTable, ref actions2);
                                    break;
                                case "sciamano goblin":
                                    check = summonUnit(" sciamano goblin", ref battlecamp, ref player2, ref wholeTable, ref actions2);
                                    break;
                                case "ogre":
                                    check = summonUnit(" ogre           ", ref battlecamp, ref player2, ref wholeTable, ref actions2);
                                    break;
                                case "indietro":
                                    check = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case "seleziona unità":
                        break;
                    case "rimescola mano":
                        if (actions2[2] > 0)
                        {
                            shuffle(player2);
                            wholeTable[14, 22] = player2.hand[0].identity;
                            wholeTable[15, 22] = $" {player2.hand[0].manaCost.ToString()}";
                            wholeTable[17, 22] = player2.hand[1].identity;
                            wholeTable[18, 22] = $" {player2.hand[1].manaCost.ToString()}";
                            wholeTable[20, 22] = player2.hand[2].identity;
                            wholeTable[21, 22] = $" {player2.hand[2].manaCost.ToString()}";
                            wholeTable[23, 22] = player2.hand[3].identity;
                            wholeTable[24, 22] = $"             {player2.hand[3].manaCost.ToString()}";
                            wholeTable[26, 22] = player2.hand[4].identity;
                            wholeTable[27, 22] = $" {player2.hand[4].manaCost.ToString()}";
                            actions2[2] -= 1;
                        }
                        break;
                    case "esamina casella":
                        break;
                    case "mostra manuale":
                        break;
                    case "passa turno":
                        playerplaying = 1;
                        wholeTable[1, 16] = " Giocatore 1";
                        break;
                    default:
                        break;
                }
            }
        }

    }
    public static void showGame(ref string[,] tabellone, string call, string idplayer, Square[,] battlecamp, ref int[] actions)
    {
        switch (call)
        {
            case "0":
                int indexR = 0;
                int indexC = 0;
                tabellone[48, 22] = "Mossa: ";
                for (int i = 0; i < tabellone.GetLength(0); i++)  //scorre le righe
                {
                    for (int j = 0; j < tabellone.GetLength(1); j++) //scorre le colonne
                    {
                        if (checkBattleSquare(ref battlecamp[indexR, indexC], i, j)) //A1                                                          
                        {
                            if (battlecamp[indexR, indexC].idP == "1")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (battlecamp[indexR, indexC].idP == "2")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            if(indexC == 9)
                            {
                                indexC = 0;
                                indexR += 1;
                            }
                            else
                            {
                                indexC += 1;
                            }
                        }

                        if (((i == 45 && j == 14) || (i == 46 && j == 14)) && actions[1] < 1) //Seleziona Unità                                                                    
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((i == 45 && j == 13) || (i == 46 && j == 13)) && actions[0] < 1) //Evoca Unità                                                                   
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((i == 45 && j == 15) || (i == 46 && j == 15)) && actions[2] < 1) //Rimescola Mano                                                                  
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (i == 8 && j == 0) //Giocatore 1                                                                 
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 14 && j == 0) || (i == 15 && j == 0)) //Slot 1-1                                                                 
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 17 && j == 0) || (i == 18 && j == 0)) //Slot 1-2                                                                 
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 20 && j == 0) || (i == 21 && j == 0)) //Slot 1-3                                                                  
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 23 && j == 0) || (i == 24 && j == 0)) //Slot 1-4                                                                
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 26 && j == 0) || (i == 27 && j == 0)) //Slot 1-5                                                               
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (i == 8 && j == 22) //Giocatore 2                                                                 
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 14 && j == 22) || (i == 15 && j == 22)) //Slot 2-1                                                                 
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 17 && j == 22) || (i == 18 && j == 22)) //Slot 2-2                                                                 
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 20 && j == 22) || (i == 21 && j == 22)) //Slot 2-3                                                                  
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 23 && j == 22) || (i == 24 && j == 22)) //Slot 2-4                                                                
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 26 && j == 22) || (i == 27 && j == 22)) //Slot 2-5                                                               
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else

                            Console.Write($"{tabellone[i, j]} ");
                    }
                    if (i < tabellone.GetLength(0) - 1)
                        Console.WriteLine();
                }
                break;
            case "presummon":
                tabellone[48, 22] = "Seleziona l'unità da evocare: ";
                for (int i = 0; i < tabellone.GetLength(0); i++)  //scorre le righe
                {
                    for (int j = 0; j < tabellone.GetLength(1); j++) //scorre le colonne
                    {
                        if (((i == 45 && j == 14) || (i == 46 && j == 14)) && actions[1] < 1) //Seleziona Unità                                                                    
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((i == 45 && j == 13) || (i == 46 && j == 13)) && actions[0] < 1) //Evoca Unità                                                                   
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((i == 45 && j == 15) || (i == 46 && j == 15)) && actions[2] < 1) //Rimescola Mano                                                                  
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (i == 8 && j == 15) //Giocatore 1                                                                 
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 14 && j == 0) || (i == 15 && j == 0)) //Slot 1                                                                 
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 17 && j == 0) || (i == 18 && j == 0)) //Slot 2                                                                 
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 20 && j == 0) || (i == 21 && j == 0)) //Slot 3                                                                  
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 23 && j == 0) || (i == 24 && j == 0)) //Slot 4                                                                
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 26 && j == 0) || (i == 27 && j == 0)) //Slot 5                                                               
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (i == 8 && j == 22) //Giocatore 2                                                                 
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 14 && j == 22) || (i == 15 && j == 22)) //Slot 2-1                                                                 
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 17 && j == 22) || (i == 18 && j == 22)) //Slot 2-2                                                                 
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 20 && j == 22) || (i == 21 && j == 22)) //Slot 2-3                                                                  
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 23 && j == 22) || (i == 24 && j == 22)) //Slot 2-4                                                                
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if ((i == 26 && j == 22) || (i == 27 && j == 22)) //Slot 2-5                                                               
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[0, 0].rowReference[0] == i && battlecamp[1, 0].columnReference[0] == j) ||
                                 (battlecamp[0, 0].rowReference[1] == i && battlecamp[1, 0].columnReference[1] == j) ||
                                 (battlecamp[0, 0].rowReference[2] == i && battlecamp[1, 0].columnReference[2] == j)) &&
                                  battlecamp[0, 0].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[1, 0].rowReference[0] == i && battlecamp[1, 0].columnReference[0] == j) ||
                                 (battlecamp[1, 0].rowReference[1] == i && battlecamp[1, 0].columnReference[1] == j) ||
                                 (battlecamp[1, 0].rowReference[2] == i && battlecamp[1, 0].columnReference[2] == j)) &&
                                  battlecamp[1, 0].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[2, 0].rowReference[0] == i && battlecamp[2, 0].columnReference[0] == j) ||
                                 (battlecamp[2, 0].rowReference[1] == i && battlecamp[2, 0].columnReference[1] == j) ||
                                 (battlecamp[2, 0].rowReference[2] == i && battlecamp[2, 0].columnReference[2] == j)) &&
                                  battlecamp[2, 0].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[3, 0].rowReference[0] == i && battlecamp[3, 0].columnReference[0] == j) ||
                                 (battlecamp[3, 0].rowReference[1] == i && battlecamp[3, 0].columnReference[1] == j) ||
                                 (battlecamp[3, 0].rowReference[2] == i && battlecamp[3, 0].columnReference[2] == j)) &&
                                  battlecamp[3, 0].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[4, 0].rowReference[0] == i && battlecamp[4, 0].columnReference[0] == j) ||
                                 (battlecamp[4, 0].rowReference[1] == i && battlecamp[4, 0].columnReference[1] == j) ||
                                 (battlecamp[4, 0].rowReference[2] == i && battlecamp[4, 0].columnReference[2] == j)) &&
                                  battlecamp[4, 0].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[5, 0].rowReference[0] == i && battlecamp[5, 0].columnReference[0] == j) ||
                                  (battlecamp[5, 0].rowReference[1] == i && battlecamp[5, 0].columnReference[1] == j) ||
                                  (battlecamp[5, 0].rowReference[2] == i && battlecamp[5, 0].columnReference[2] == j)) &&
                                   battlecamp[5, 0].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[6, 0].rowReference[0] == i && battlecamp[6, 0].columnReference[0] == j) ||
                                  (battlecamp[6, 0].rowReference[1] == i && battlecamp[6, 0].columnReference[1] == j) ||
                                  (battlecamp[6, 0].rowReference[2] == i && battlecamp[6, 0].columnReference[2] == j)) &&
                                   battlecamp[6, 0].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[7, 0].rowReference[0] == i && battlecamp[7, 0].columnReference[0] == j) ||
                                  (battlecamp[7, 0].rowReference[1] == i && battlecamp[7, 0].columnReference[1] == j) ||
                                  (battlecamp[7, 0].rowReference[2] == i && battlecamp[7, 0].columnReference[2] == j)) &&
                                   battlecamp[7, 0].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[8, 0].rowReference[0] == i && battlecamp[8, 0].columnReference[0] == j) ||
                                  (battlecamp[8, 0].rowReference[1] == i && battlecamp[8, 0].columnReference[1] == j) ||
                                  (battlecamp[8, 0].rowReference[2] == i && battlecamp[8, 0].columnReference[2] == j)) &&
                                   battlecamp[8, 0].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[9, 0].rowReference[0] == i && battlecamp[9, 0].columnReference[0] == j) ||
                                  (battlecamp[9, 0].rowReference[1] == i && battlecamp[9, 0].columnReference[1] == j) ||
                                  (battlecamp[9, 0].rowReference[2] == i && battlecamp[9, 0].columnReference[2] == j)) &&
                                   battlecamp[9, 0].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[0, 1].rowReference[0] == i && battlecamp[0, 1].columnReference[0] == j) ||
                                  (battlecamp[0, 1].rowReference[1] == i && battlecamp[0, 1].columnReference[1] == j) ||
                                  (battlecamp[0, 1].rowReference[2] == i && battlecamp[0, 1].columnReference[2] == j)) &&
                                   battlecamp[0, 1].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[1, 1].rowReference[0] == i && battlecamp[1, 1].columnReference[0] == j) ||
                                  (battlecamp[1, 1].rowReference[1] == i && battlecamp[1, 1].columnReference[1] == j) ||
                                  (battlecamp[1, 1].rowReference[2] == i && battlecamp[1, 1].columnReference[2] == j)) &&
                                   battlecamp[1, 1].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[2, 1].rowReference[0] == i && battlecamp[2, 1].columnReference[0] == j) ||
                                  (battlecamp[2, 1].rowReference[1] == i && battlecamp[2, 1].columnReference[1] == j) ||
                                  (battlecamp[2, 1].rowReference[2] == i && battlecamp[2, 1].columnReference[2] == j)) &&
                                   battlecamp[2, 1].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[3, 1].rowReference[0] == i && battlecamp[3, 1].columnReference[0] == j) ||
                                  (battlecamp[3, 1].rowReference[1] == i && battlecamp[3, 1].columnReference[1] == j) ||
                                  (battlecamp[3, 1].rowReference[2] == i && battlecamp[3, 1].columnReference[2] == j)) &&
                                   battlecamp[3, 1].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[4, 1].rowReference[0] == i && battlecamp[4, 1].columnReference[0] == j) ||
                                  (battlecamp[4, 1].rowReference[1] == i && battlecamp[4, 1].columnReference[1] == j) ||
                                  (battlecamp[4, 1].rowReference[2] == i && battlecamp[4, 1].columnReference[2] == j)) &&
                                   battlecamp[4, 1].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[5, 1].rowReference[0] == i && battlecamp[5, 1].columnReference[0] == j) ||
                                  (battlecamp[5, 1].rowReference[1] == i && battlecamp[5, 1].columnReference[1] == j) ||
                                  (battlecamp[5, 1].rowReference[2] == i && battlecamp[5, 1].columnReference[2] == j)) &&
                                   battlecamp[5, 1].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[6, 1].rowReference[0] == i && battlecamp[6, 1].columnReference[0] == j) ||
                                  (battlecamp[6, 1].rowReference[1] == i && battlecamp[6, 1].columnReference[1] == j) ||
                                  (battlecamp[6, 1].rowReference[2] == i && battlecamp[6, 1].columnReference[2] == j)) &&
                                   battlecamp[6, 1].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[7, 1].rowReference[0] == i && battlecamp[7, 1].columnReference[0] == j) ||
                                  (battlecamp[7, 1].rowReference[1] == i && battlecamp[7, 1].columnReference[1] == j) ||
                                  (battlecamp[7, 1].rowReference[2] == i && battlecamp[7, 1].columnReference[2] == j)) &&
                                   battlecamp[7, 1].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[8, 1].rowReference[0] == i && battlecamp[8, 1].columnReference[0] == j) ||
                                  (battlecamp[8, 1].rowReference[1] == i && battlecamp[8, 1].columnReference[1] == j) ||
                                  (battlecamp[8, 1].rowReference[2] == i && battlecamp[8, 1].columnReference[2] == j)) &&
                                   battlecamp[8, 1].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else if (((battlecamp[9, 1].rowReference[0] == i && battlecamp[9, 1].columnReference[0] == j) ||
                                  (battlecamp[9, 1].rowReference[1] == i && battlecamp[9, 1].columnReference[1] == j) ||
                                  (battlecamp[9, 1].rowReference[2] == i && battlecamp[9, 1].columnReference[2] == j)) &&
                                   battlecamp[9, 1].occupied == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else
                            Console.Write($"{tabellone[i, j]} ");
                    }
                    if (i < tabellone.GetLength(0) - 1)
                        Console.WriteLine();
                }
                break;
            case "summon":
                tabellone[48, 22] = "Indica la casella dove vuoi posizionare l'unità (Es. a1, g7, c5): ";
                if (idplayer == "1")
                {
                    for (int i = 0; i < tabellone.GetLength(0); i++)  //scorre le righe
                    {
                        for (int j = 0; j < tabellone.GetLength(1); j++) //scorre le colonne
                        {
                            if (((battlecamp[0, 0].rowReference[0] == i && battlecamp[0, 0].columnReference[0] == j) ||
                                     (battlecamp[0, 0].rowReference[1] == i && battlecamp[0, 0].columnReference[1] == j) ||
                                     (battlecamp[0, 0].rowReference[2] == i && battlecamp[0, 0].columnReference[2] == j)) &&
                                      battlecamp[0, 0].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[1, 0].rowReference[0] == i && battlecamp[1, 0].columnReference[0] == j) ||
                                     (battlecamp[1, 0].rowReference[1] == i && battlecamp[1, 0].columnReference[1] == j) ||
                                     (battlecamp[1, 0].rowReference[2] == i && battlecamp[1, 0].columnReference[2] == j)) &&
                                      battlecamp[1, 0].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[2, 0].rowReference[0] == i && battlecamp[2, 0].columnReference[0] == j) ||
                                     (battlecamp[2, 0].rowReference[1] == i && battlecamp[2, 0].columnReference[1] == j) ||
                                     (battlecamp[2, 0].rowReference[2] == i && battlecamp[2, 0].columnReference[2] == j)) &&
                                      battlecamp[2, 0].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[3, 0].rowReference[0] == i && battlecamp[3, 0].columnReference[0] == j) ||
                                     (battlecamp[3, 0].rowReference[1] == i && battlecamp[3, 0].columnReference[1] == j) ||
                                     (battlecamp[3, 0].rowReference[2] == i && battlecamp[3, 0].columnReference[2] == j)) &&
                                      battlecamp[3, 0].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[4, 0].rowReference[0] == i && battlecamp[4, 0].columnReference[0] == j) ||
                                     (battlecamp[4, 0].rowReference[1] == i && battlecamp[4, 0].columnReference[1] == j) ||
                                     (battlecamp[4, 0].rowReference[2] == i && battlecamp[4, 0].columnReference[2] == j)) &&
                                      battlecamp[4, 0].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[5, 0].rowReference[0] == i && battlecamp[5, 0].columnReference[0] == j) ||
                                      (battlecamp[5, 0].rowReference[1] == i && battlecamp[5, 0].columnReference[1] == j) ||
                                      (battlecamp[5, 0].rowReference[2] == i && battlecamp[5, 0].columnReference[2] == j)) &&
                                       battlecamp[5, 0].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[6, 0].rowReference[0] == i && battlecamp[6, 0].columnReference[0] == j) ||
                                      (battlecamp[6, 0].rowReference[1] == i && battlecamp[6, 0].columnReference[1] == j) ||
                                      (battlecamp[6, 0].rowReference[2] == i && battlecamp[6, 0].columnReference[2] == j)) &&
                                       battlecamp[6, 0].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[7, 0].rowReference[0] == i && battlecamp[7, 0].columnReference[0] == j) ||
                                      (battlecamp[7, 0].rowReference[1] == i && battlecamp[7, 0].columnReference[1] == j) ||
                                      (battlecamp[7, 0].rowReference[2] == i && battlecamp[7, 0].columnReference[2] == j)) &&
                                       battlecamp[7, 0].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[8, 0].rowReference[0] == i && battlecamp[8, 0].columnReference[0] == j) ||
                                      (battlecamp[8, 0].rowReference[1] == i && battlecamp[8, 0].columnReference[1] == j) ||
                                      (battlecamp[8, 0].rowReference[2] == i && battlecamp[8, 0].columnReference[2] == j)) &&
                                       battlecamp[8, 0].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[9, 0].rowReference[0] == i && battlecamp[9, 0].columnReference[0] == j) ||
                                      (battlecamp[9, 0].rowReference[1] == i && battlecamp[9, 0].columnReference[1] == j) ||
                                      (battlecamp[9, 0].rowReference[2] == i && battlecamp[9, 0].columnReference[2] == j)) &&
                                       battlecamp[9, 0].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[0, 1].rowReference[0] == i && battlecamp[0, 1].columnReference[0] == j) ||
                                      (battlecamp[0, 1].rowReference[1] == i && battlecamp[0, 1].columnReference[1] == j) ||
                                      (battlecamp[0, 1].rowReference[2] == i && battlecamp[0, 1].columnReference[2] == j)) &&
                                       battlecamp[0, 1].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[1, 1].rowReference[0] == i && battlecamp[1, 1].columnReference[0] == j) ||
                                      (battlecamp[1, 1].rowReference[1] == i && battlecamp[1, 1].columnReference[1] == j) ||
                                      (battlecamp[1, 1].rowReference[2] == i && battlecamp[1, 1].columnReference[2] == j)) &&
                                       battlecamp[1, 1].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[2, 1].rowReference[0] == i && battlecamp[2, 1].columnReference[0] == j) ||
                                      (battlecamp[2, 1].rowReference[1] == i && battlecamp[2, 1].columnReference[1] == j) ||
                                      (battlecamp[2, 1].rowReference[2] == i && battlecamp[2, 1].columnReference[2] == j)) &&
                                       battlecamp[2, 1].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[3, 1].rowReference[0] == i && battlecamp[3, 1].columnReference[0] == j) ||
                                      (battlecamp[3, 1].rowReference[1] == i && battlecamp[3, 1].columnReference[1] == j) ||
                                      (battlecamp[3, 1].rowReference[2] == i && battlecamp[3, 1].columnReference[2] == j)) &&
                                       battlecamp[3, 1].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[4, 1].rowReference[0] == i && battlecamp[4, 1].columnReference[0] == j) ||
                                      (battlecamp[4, 1].rowReference[1] == i && battlecamp[4, 1].columnReference[1] == j) ||
                                      (battlecamp[4, 1].rowReference[2] == i && battlecamp[4, 1].columnReference[2] == j)) &&
                                       battlecamp[4, 1].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[5, 1].rowReference[0] == i && battlecamp[5, 1].columnReference[0] == j) ||
                                      (battlecamp[5, 1].rowReference[1] == i && battlecamp[5, 1].columnReference[1] == j) ||
                                      (battlecamp[5, 1].rowReference[2] == i && battlecamp[5, 1].columnReference[2] == j)) &&
                                       battlecamp[5, 1].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[6, 1].rowReference[0] == i && battlecamp[6, 1].columnReference[0] == j) ||
                                      (battlecamp[6, 1].rowReference[1] == i && battlecamp[6, 1].columnReference[1] == j) ||
                                      (battlecamp[6, 1].rowReference[2] == i && battlecamp[6, 1].columnReference[2] == j)) &&
                                       battlecamp[6, 1].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[7, 1].rowReference[0] == i && battlecamp[7, 1].columnReference[0] == j) ||
                                      (battlecamp[7, 1].rowReference[1] == i && battlecamp[7, 1].columnReference[1] == j) ||
                                      (battlecamp[7, 1].rowReference[2] == i && battlecamp[7, 1].columnReference[2] == j)) &&
                                       battlecamp[7, 1].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[8, 1].rowReference[0] == i && battlecamp[8, 1].columnReference[0] == j) ||
                                      (battlecamp[8, 1].rowReference[1] == i && battlecamp[8, 1].columnReference[1] == j) ||
                                      (battlecamp[8, 1].rowReference[2] == i && battlecamp[8, 1].columnReference[2] == j)) &&
                                       battlecamp[8, 1].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[9, 1].rowReference[0] == i && battlecamp[9, 1].columnReference[0] == j) ||
                                      (battlecamp[9, 1].rowReference[1] == i && battlecamp[9, 1].columnReference[1] == j) ||
                                      (battlecamp[9, 1].rowReference[2] == i && battlecamp[9, 1].columnReference[2] == j)) &&
                                       battlecamp[9, 1].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write($"{tabellone[i, j]} ");
                            }
                        }
                        if (i < tabellone.GetLength(0) - 1)
                            Console.WriteLine();
                    }
                }
                else //caselle disponibili per l'evocazione del giocatore 2
                {
                    for (int i = 0; i < tabellone.GetLength(0); i++)  //scorre le righe
                    {
                        for (int j = 0; j < tabellone.GetLength(1); j++) //scorre le colonne
                        {
                            if (((battlecamp[0, 8].rowReference[0] == i && battlecamp[0, 8].columnReference[0] == j) ||
                                 (battlecamp[0, 8].rowReference[1] == i && battlecamp[0, 8].columnReference[1] == j) ||
                                 (battlecamp[0, 8].rowReference[2] == i && battlecamp[0, 8].columnReference[2] == j)) &&
                                  battlecamp[0, 8].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[1, 8].rowReference[0] == i && battlecamp[1, 8].columnReference[0] == j) ||
                                      (battlecamp[1, 8].rowReference[1] == i && battlecamp[1, 8].columnReference[1] == j) ||
                                      (battlecamp[1, 8].rowReference[2] == i && battlecamp[1, 8].columnReference[2] == j)) &&
                                       battlecamp[1, 8].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[2, 8].rowReference[0] == i && battlecamp[2, 8].columnReference[0] == j) ||
                                      (battlecamp[2, 8].rowReference[1] == i && battlecamp[2, 8].columnReference[1] == j) ||
                                      (battlecamp[2, 8].rowReference[2] == i && battlecamp[2, 8].columnReference[2] == j)) &&
                                       battlecamp[2, 8].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[3, 8].rowReference[0] == i && battlecamp[3, 8].columnReference[0] == j) ||
                                      (battlecamp[3, 8].rowReference[1] == i && battlecamp[3, 8].columnReference[1] == j) ||
                                      (battlecamp[3, 8].rowReference[2] == i && battlecamp[3, 8].columnReference[2] == j)) &&
                                       battlecamp[3, 8].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[4, 8].rowReference[0] == i && battlecamp[4, 8].columnReference[0] == j) ||
                                      (battlecamp[4, 8].rowReference[1] == i && battlecamp[4, 8].columnReference[1] == j) ||
                                      (battlecamp[4, 8].rowReference[2] == i && battlecamp[4, 8].columnReference[2] == j)) &&
                                       battlecamp[4, 8].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[5, 8].rowReference[0] == i && battlecamp[5, 8].columnReference[0] == j) ||
                                      (battlecamp[5, 8].rowReference[1] == i && battlecamp[5, 8].columnReference[1] == j) ||
                                      (battlecamp[5, 8].rowReference[2] == i && battlecamp[5, 8].columnReference[2] == j)) &&
                                       battlecamp[5, 8].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[6, 8].rowReference[0] == i && battlecamp[6, 8].columnReference[0] == j) ||
                                      (battlecamp[6, 8].rowReference[1] == i && battlecamp[6, 8].columnReference[1] == j) ||
                                      (battlecamp[6, 8].rowReference[2] == i && battlecamp[6, 8].columnReference[2] == j)) &&
                                       battlecamp[6, 8].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[7, 8].rowReference[0] == i && battlecamp[7, 8].columnReference[0] == j) ||
                                      (battlecamp[7, 8].rowReference[1] == i && battlecamp[7, 8].columnReference[1] == j) ||
                                      (battlecamp[7, 8].rowReference[2] == i && battlecamp[7, 8].columnReference[2] == j)) &&
                                       battlecamp[7, 8].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[8, 8].rowReference[0] == i && battlecamp[8, 8].columnReference[0] == j) ||
                                      (battlecamp[8, 8].rowReference[1] == i && battlecamp[8, 8].columnReference[1] == j) ||
                                      (battlecamp[8, 8].rowReference[2] == i && battlecamp[8, 8].columnReference[2] == j)) &&
                                       battlecamp[8, 8].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[9, 8].rowReference[0] == i && battlecamp[9, 8].columnReference[0] == j) ||
                                      (battlecamp[9, 8].rowReference[1] == i && battlecamp[9, 8].columnReference[1] == j) ||
                                      (battlecamp[9, 8].rowReference[2] == i && battlecamp[9, 8].columnReference[2] == j)) &&
                                       battlecamp[9, 8].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[0, 9].rowReference[0] == i && battlecamp[0, 9].columnReference[0] == j) ||
                                      (battlecamp[0, 9].rowReference[1] == i && battlecamp[0, 9].columnReference[1] == j) ||
                                      (battlecamp[0, 9].rowReference[2] == i && battlecamp[0, 9].columnReference[2] == j)) &&
                                       battlecamp[0, 9].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[1, 9].rowReference[0] == i && battlecamp[1, 9].columnReference[0] == j) ||
                                      (battlecamp[1, 9].rowReference[1] == i && battlecamp[1, 9].columnReference[1] == j) ||
                                      (battlecamp[1, 9].rowReference[2] == i && battlecamp[1, 9].columnReference[2] == j)) &&
                                       battlecamp[1, 9].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[2, 9].rowReference[0] == i && battlecamp[2, 9].columnReference[0] == j) ||
                                      (battlecamp[2, 9].rowReference[1] == i && battlecamp[2, 9].columnReference[1] == j) ||
                                      (battlecamp[2, 9].rowReference[2] == i && battlecamp[2, 9].columnReference[2] == j)) &&
                                       battlecamp[2, 9].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[3, 9].rowReference[0] == i && battlecamp[3, 9].columnReference[0] == j) ||
                                      (battlecamp[3, 9].rowReference[1] == i && battlecamp[3, 9].columnReference[1] == j) ||
                                      (battlecamp[3, 9].rowReference[2] == i && battlecamp[3, 9].columnReference[2] == j)) &&
                                       battlecamp[3, 9].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[4, 9].rowReference[0] == i && battlecamp[4, 9].columnReference[0] == j) ||
                                      (battlecamp[4, 9].rowReference[1] == i && battlecamp[4, 9].columnReference[1] == j) ||
                                      (battlecamp[4, 9].rowReference[2] == i && battlecamp[4, 9].columnReference[2] == j)) &&
                                       battlecamp[4, 9].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[5, 9].rowReference[0] == i && battlecamp[5, 9].columnReference[0] == j) ||
                                      (battlecamp[5, 9].rowReference[1] == i && battlecamp[5, 9].columnReference[1] == j) ||
                                      (battlecamp[5, 9].rowReference[2] == i && battlecamp[5, 9].columnReference[2] == j)) &&
                                       battlecamp[5, 9].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[6, 9].rowReference[0] == i && battlecamp[6, 9].columnReference[0] == j) ||
                                      (battlecamp[6, 9].rowReference[1] == i && battlecamp[6, 9].columnReference[1] == j) ||
                                      (battlecamp[6, 9].rowReference[2] == i && battlecamp[6, 9].columnReference[2] == j)) &&
                                       battlecamp[6, 9].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[7, 9].rowReference[0] == i && battlecamp[7, 9].columnReference[0] == j) ||
                                      (battlecamp[7, 9].rowReference[1] == i && battlecamp[7, 9].columnReference[1] == j) ||
                                      (battlecamp[7, 9].rowReference[2] == i && battlecamp[7, 9].columnReference[2] == j)) &&
                                       battlecamp[7, 9].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[8, 9].rowReference[0] == i && battlecamp[8, 9].columnReference[0] == j) ||
                                      (battlecamp[8, 9].rowReference[1] == i && battlecamp[8, 9].columnReference[1] == j) ||
                                      (battlecamp[8, 9].rowReference[2] == i && battlecamp[8, 9].columnReference[2] == j)) &&
                                       battlecamp[8, 9].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else if (((battlecamp[9, 9].rowReference[0] == i && battlecamp[9, 9].columnReference[0] == j) ||
                                      (battlecamp[9, 9].rowReference[1] == i && battlecamp[9, 9].columnReference[1] == j) ||
                                      (battlecamp[9, 9].rowReference[2] == i && battlecamp[9, 9].columnReference[2] == j)) &&
                                       battlecamp[9, 9].occupied == false)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write($"{tabellone[i, j]} ");
                            }
                        }
                        if (i < tabellone.GetLength(0) - 1)
                            Console.WriteLine();
                    }
                }
                break;
        }

    }
    public static void shuffle(Player p) //rimescola la mano e pesca 5 nuove unità
    {
        while (p.hand.Count != 0) //svuota la mano rimettendo tutte le unità nella pool, tranne quelle "unità esaurite" che invece vengono eliminate
        {

            if (p.hand[0].identity == "                ")
                p.hand.Remove(p.hand[0]);
            else
            {
                p.pool.Add(p.hand[0]);
                p.hand.Remove(p.hand[0]);
            }
        }
        for (int i = 0; i < 5; i++) //riempe la mano (max 5 slot) con unità se la pool non è vuota, e in quel caso la riempie con "unità esaurite"
        {
            var rdm = new Random();
            int indexPool = rdm.Next(p.pool.Count - 1);
            p.hand.Add(p.pool[indexPool]);
            p.pool.Remove(p.pool[indexPool]);
        }
    }
    public static bool summon(ref Square casella, ref Player p, ref string[,] tabellone, int index)
    {
        if (p.id == "1")
        {

            if (casella.occupied == true)
                return false;
            else
            {

                //assegnazione al tabellone di puntatori
                casella.top = p.hand[index].name1;
                casella.mid = p.hand[index].name2;
                casella.bot = p.hand[index].showHealthBar();
                casella.occupied = true;
                casella.idP = "1";

                //assegnazione al tabellone fisico
                tabellone[casella.rowReference[0], casella.columnReference[0]] = p.hand[index].name1;
                tabellone[casella.rowReference[1], casella.columnReference[1]] = p.hand[index].name2;
                tabellone[casella.rowReference[2], casella.columnReference[2]] = p.hand[index].showHealthBar();

                //tolgo l'unità dalla mano fisica   
                tabellone[14 + (index * 3), 0] = "                ";
                tabellone[15 + (index * 3), 0] = "    ";

                //trasferimento dalla mano al campo (puntatori)
                p.field.Add(p.hand[index]);
                p.hand[index].identity = "                ";

                return true;
            }
        }
        else
        {
            if (casella.occupied == true)
                return false;
            else
            {

                //assegnazione al tabellone di puntatori
                casella.top = p.hand[index].name1;
                casella.mid = p.hand[index].name2;
                casella.bot = p.hand[index].showHealthBar();
                casella.occupied = true;
                casella.idP = "2";

                //assegnazione al tabellone fisico
                tabellone[casella.rowReference[0], casella.columnReference[0]] = p.hand[index].name1;
                tabellone[casella.rowReference[1], casella.columnReference[1]] = p.hand[index].name2;
                tabellone[casella.rowReference[2], casella.columnReference[2]] = p.hand[index].showHealthBar();

                //tolgo l'unità dalla mano fisica   
                tabellone[14 + (index * 3), 22] = "                ";
                tabellone[15 + (index * 3), 22] = "    ";

                //trasferimento dalla mano al campo (puntatori)
                p.field.Add(p.hand[index]);
                p.hand[index].identity = "                ";

                return true;
            }
        }
    }
    public static bool summonUnit(string name, ref Square[,] field, ref Player p, ref string[,] tabellone, ref int[] actions)
    {
        if (p.id == "1")
        {

            bool check2 = false;
            for (int i = 0; i < p.hand.Count; i++) //cerca in ogni slot della mano o finché non si digita indietro o finché non lo trova
            {
                if (p.hand[i].identity == name) //se trova l'unità selezionata dal giocatore
                {
                    while (check2 == false)
                    {
                        Console.Clear();
                        showGame(ref tabellone, "summon", "1", field, ref actions);
                        string inputSquare = Console.ReadLine();
                        switch (inputSquare)
                        {
                            case "a1":
                                check2 = summon(ref field[0, 0], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "a2":
                                check2 = summon(ref field[1, 0], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "a3":
                                check2 = summon(ref field[2, 0], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "a4":
                                check2 = summon(ref field[3, 0], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "a5":
                                check2 = summon(ref field[4, 0], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "a6":
                                check2 = summon(ref field[5, 0], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "a7":
                                check2 = summon(ref field[6, 0], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "a8":
                                check2 = summon(ref field[7, 0], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "a9":
                                check2 = summon(ref field[8, 0], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "a10":
                                check2 = summon(ref field[9, 0], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "b1":
                                check2 = summon(ref field[0, 1], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "b2":
                                check2 = summon(ref field[1, 1], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "b3":
                                check2 = summon(ref field[2, 1], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "b4":
                                check2 = summon(ref field[3, 1], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "b5":
                                check2 = summon(ref field[4, 1], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "b6":
                                check2 = summon(ref field[5, 1], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "b7":
                                check2 = summon(ref field[6, 1], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "b8":
                                check2 = summon(ref field[7, 1], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "b9":
                                check2 = summon(ref field[8, 1], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "b10":
                                check2 = summon(ref field[9, 1], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "indietro":
                                check2 = true;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                }
            }
            return check2;
        }
        else
        {
            bool check2 = false;
            for (int i = 0; i < p.hand.Count; i++) //cerca in ogni slot della mano o finché non si digita indietro o finché non lo trova
            {
                if (p.hand[i].identity == name) //se trova l'unità selezionata dal giocatore
                {
                    while (check2 == false)
                    {
                        Console.Clear();
                        showGame(ref tabellone, "summon", "2", field, ref actions);
                        string inputSquare = Console.ReadLine();
                        switch (inputSquare)
                        {
                            case "i1":
                                check2 = summon(ref field[0, 8], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "i2":
                                check2 = summon(ref field[1, 8], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "i3":
                                check2 = summon(ref field[2, 8], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "i4":
                                check2 = summon(ref field[3, 8], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "i5":
                                check2 = summon(ref field[4, 8], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "i6":
                                check2 = summon(ref field[5, 8], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "i7":
                                check2 = summon(ref field[6, 8], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "i8":
                                check2 = summon(ref field[7, 8], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "i9":
                                check2 = summon(ref field[8, 8], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "i10":
                                check2 = summon(ref field[9, 8], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "j1":
                                check2 = summon(ref field[0, 9], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "j2":
                                check2 = summon(ref field[1, 9], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "j3":
                                check2 = summon(ref field[2, 9], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "j4":
                                check2 = summon(ref field[3, 9], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "j5":
                                check2 = summon(ref field[4, 9], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "j6":
                                check2 = summon(ref field[5, 9], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "j7":
                                check2 = summon(ref field[6, 9], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "j8":
                                check2 = summon(ref field[7, 9], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "j9":
                                check2 = summon(ref field[8, 9], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "j10":
                                check2 = summon(ref field[9, 9], ref p, ref tabellone, i);
                                return check2;
                                break;
                            case "indietro":
                                check2 = true;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                }
            }
            return check2;
        }
    }

    static void summonNOTWORKING(Player p, int round, ref Square[,] battlecamp, ref string[,] wholetable)
    {
        bool found = false;
        while (found == false)
        {
            string unitName = Console.ReadLine();

            for (int i = 0; i < p.hand.Count; i++)
            {          //controlla che l'unità sia presente nella mano del giocatore && che il mana residuo del giocatore sia sufficiente && che il costo dell'evocazione non ecceda dal mana massimo spendibile per turno
                if (unitName == p.hand[i].identity && p.manaLeft - p.hand[i].manaCost > 0 && maxManaPerTurn(round) - p.manaSpentThisTurn + p.hand[i].manaCost > 0)
                {
                    if (p.id == "1")  //svolge questo solo per il giocatore 1
                    {

                    }
                    if (p.id == "2")   //svolge questo solo per il giocatore 2
                    {
                        for (int ij = 9; ij > 7; ij--) //sonda le ultime due righe
                        {
                            for (int jj = 0; jj < battlecamp.GetLength(1); jj++)  //sonda tutte le colonne
                            {
                                if (battlecamp[ij, jj].occupied == false)
                                    battlecamp[ij, jj].lighted = true;
                            }
                        }
                    }
                    p.field.Add(p.hand[i]);
                    p.hand.Remove(p.hand[i]);
                    p.hand.Add(p.pool[20]);
                    found = true;
                    break;
                }
            }
        }
    }
    public static bool checkBattleSquare(ref Square casella, int x, int y)
    {
        if (((casella.rowReference[0] == x && casella.columnReference[0] == y) ||
             (casella.rowReference[1] == x+1 && casella.columnReference[1] == y) ||
             (casella.rowReference[2] == x+2 && casella.columnReference[2] == y)) &&
                                    casella.occupied == true)
            return true;
        else
            return false;
    }
    static int maxManaPerTurn(int round)
    {
        int start = (round + 1) / 2 * 100;
        if (start <= 500)
            return start;
        else
            return 500;
    }

}