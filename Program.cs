using System.ComponentModel;
using System.Security.Cryptography;

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
        public string coordinate { get; set; }           //il nome della casella?
        public string top { get; set; }                   //le tre parti di una casella
        public string mid { get; set; }
        public string bot { get; set; }
        public bool occupied { get; set; }               //indica se la casella è occupata
        public bool lighted { get; set; }                 //indica se la casella deve essere evidenziata
        public Square(string coordinateBox, string topSquare, string midSquare, string botSquare) //costruttore della classe casella, questo iipo viene usato per il campo
        {
            coordinate = coordinateBox;
            top = topSquare;
            mid = midSquare;
            bot = botSquare;
        }
        public Square(string coordinateBox, string topSquare, string botSquare) //costruttore della classe casella, questo tipo viene usato per i comandi
        {
            coordinate = coordinateBox;
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
        public Unit(string idplayer, string identity)
        {
            idUnit = idplayer;
            switch (identity)
            {
                case " ":
                    name1 = "             ";
                    break;
                case "sgorbio":
                    name1 = "   Sgorbio   ";
                    name2 = "             ";
                    currentHealth = 10;
                    maxHealth = 10;
                    maxAttack = 15;
                    minAttack = 5;
                    manaCost = 50;
                    break;
                case "lancia ciottoli":
                    name1 = "   Lancia    ";
                    name2 = "  Ciottoli   ";
                    currentHealth = 10;
                    maxHealth = 10;
                    maxAttack = 15;
                    minAttack = 5;
                    manaCost = 75;
                    break;
                case "cavalca pony":
                    name1 = "   Cavalca   ";
                    name2 = "    Pony     ";
                    currentHealth = 10;
                    maxHealth = 10;
                    maxAttack = 15;
                    minAttack = 5;
                    manaCost = 100;
                    break;
                case "sciamano goblin":
                    name1 = "  Sciamano   ";
                    name2 = "   Goblin    ";
                    currentHealth = 10;
                    maxHealth = 10;
                    maxAttack = 15;
                    minAttack = 1;
                    manaCost = 150;
                    break;
                case "ogre":
                    name1 = "    Ogre     ";
                    name2 = "             ";
                    currentHealth = 10;
                    maxHealth = 10;
                    maxAttack = 15;
                    minAttack = 1;
                    manaCost = 200;
                    break;
                case "generale goblin":
                    name1 = "  Generale   ";
                    name2 = "   Goblin    ";
                    currentHealth = 10;
                    maxHealth = 10;
                    maxAttack = 15;
                    minAttack = 5;
                    manaCost = 1001;
                    break;
            }
        }
    }
    public class Player
    {

        public string id { get; set; } //Identifica il giocatore, quindi giocatore 1 o giocatore 2
        public int manaLeft { get; set; } //Risorse del giocatore
        public int manaSpentThisTurn { get; set; }
        public List<Unit> pool = new List<Unit> //pool intera da cui vengono tolti quelli in mano
        {

        };
        public List<Unit> hand = new List<Unit> //mano da cui vengono tolti quando generati
        {

        };
        public List<Unit> field = new List<Unit> //mano da cui vengono tolti quando generati
        {

        };
        public Player(string idplayer)
        {
            manaLeft = 1000;
            id = idplayer;

            Unit spaziovuoto = new Unit(id, " ");
            Unit sgorbio1 = new Unit(id, "sgorbio");
            Unit sgorbio2 = new Unit(id, "sgorbio");
            Unit sgorbio3 = new Unit(id, "sgorbio");
            Unit sgorbio4 = new Unit(id, "sgorbio");
            Unit sgorbio5 = new Unit(id, "sgorbio");
            Unit sgorbio6 = new Unit(id, "sgorbio");
            Unit lanciaciottoli1 = new Unit(id, "lancia ciottoli");
            Unit lanciaciottoli2 = new Unit(id, "lancia ciottoli");
            Unit lanciaciottoli3 = new Unit(id, "lancia ciottoli");
            Unit lanciaciottoli4 = new Unit(id, "lancia ciottoli");
            Unit lanciaciottoli5 = new Unit(id, "lancia ciottoli");
            Unit lanciaciottoli6 = new Unit(id, "lancia ciottoli");
            Unit cavalcapony1 = new Unit(id, "cavalca pony");
            Unit cavalcapony2 = new Unit(id, "cavalca pony");
            Unit cavalcapony3 = new Unit(id, "cavalca pony");
            Unit sciamanogoblin1 = new Unit(id, "sciamano goblin");
            Unit sciamanogoblin2 = new Unit(id, "sciamano goblin");
            Unit sciamanogoblin3 = new Unit(id, "sciamano goblin");
            Unit ogre1 = new Unit(id, "ogre");
            Unit ogre2 = new Unit(id, "ogre");
            Unit generalegoblin = new Unit(id, "generale goblin");
            field.Add(generalegoblin);
            pool.Add(sgorbio1);
            pool.Add(sgorbio2);
            pool.Add(sgorbio3);
            pool.Add(sgorbio1);
            pool.Add(sgorbio1);
            pool.Add(sgorbio1);
            pool.Add(lanciaciottoli1);
            pool.Add(lanciaciottoli1);
            pool.Add(lanciaciottoli1);
            pool.Add(lanciaciottoli1);
            pool.Add(lanciaciottoli1);
            pool.Add(lanciaciottoli1);
            pool.Add(cavalcapony1);
            pool.Add(cavalcapony1);
            pool.Add(cavalcapony1);
            pool.Add(sciamanogoblin1);
            pool.Add(sciamanogoblin1);
            pool.Add(sciamanogoblin1);
            pool.Add(ogre1);
            pool.Add(ogre1);
            pool.Add(spaziovuoto);

        }
    }
    public static void newGame()
    {
        Player player1 = new Player("1");
        Player player2 = new Player("2");
        shuffle(player1);
        shuffle(player2);

        Square a1 = new Square("a1", "             ", "             ", "             ");
        Square a2 = new Square("a2", "             ", "             ", "             ");
        Square a3 = new Square("a3", "             ", "             ", "             ");
        Square a4 = new Square("a4", "             ", "             ", "             ");
        Square a5 = new Square("a5", "             ", "             ", "             ");
        Square a6 = new Square("a6", "             ", "             ", "             ");
        Square a7 = new Square("a7", "             ", "             ", "             ");
        Square a8 = new Square("a8", "             ", "             ", "             ");
        Square a9 = new Square("a9", "             ", "             ", "             ");
        Square a10 = new Square("a10", "             ", "             ", "             ");

        Square b1 = new Square("b1", "             ", "             ", "             ");
        Square b2 = new Square("b2", "             ", "             ", "             ");
        Square b3 = new Square("b3", "             ", "             ", "             ");
        Square b4 = new Square("b4", "             ", "             ", "             ");
        Square b5 = new Square("b5", "             ", "             ", "             ");
        Square b6 = new Square("b6", "             ", "             ", "             ");
        Square b7 = new Square("b7", "             ", "             ", "             ");
        Square b8 = new Square("b8", "             ", "             ", "             ");
        Square b9 = new Square("b9", "             ", "             ", "             ");
        Square b10 = new Square("b10", "             ", "             ", "             ");

        Square c1 = new Square("c1", "             ", "             ", "             ");
        Square c2 = new Square("c2", "             ", "             ", "             ");
        Square c3 = new Square("c3", "             ", "             ", "             ");
        Square c4 = new Square("c4", "             ", "             ", "             ");
        Square c5 = new Square("c5", "             ", "             ", "             ");
        Square c6 = new Square("c6", "             ", "             ", "             ");
        Square c7 = new Square("c7", "             ", "             ", "             ");
        Square c8 = new Square("c8", "             ", "             ", "             ");
        Square c9 = new Square("c9", "             ", "             ", "             ");
        Square c10 = new Square("c10", "             ", "             ", "             ");

        Square d1 = new Square("d1", "             ", "             ", "             ");
        Square d2 = new Square("d2", "             ", "             ", "             ");
        Square d3 = new Square("d3", "             ", "             ", "             ");
        Square d4 = new Square("d4", "             ", "             ", "             ");
        Square d5 = new Square("d5", "             ", "             ", "             ");
        Square d6 = new Square("d6", "             ", "             ", "             ");
        Square d7 = new Square("d7", "             ", "             ", "             ");
        Square d8 = new Square("d8", "             ", "             ", "             ");
        Square d9 = new Square("d9", "             ", "             ", "             ");
        Square d10 = new Square("d10", "             ", "             ", "             ");

        Square e1 = new Square("e1", "             ", "             ", "             ");
        Square e2 = new Square("e2", "             ", "             ", "             ");
        Square e3 = new Square("e3", "             ", "             ", "             ");
        Square e4 = new Square("e4", "             ", "             ", "             ");
        Square e5 = new Square("e5", "             ", "             ", "             ");
        Square e6 = new Square("e6", "             ", "             ", "             ");
        Square e7 = new Square("e7", "             ", "             ", "             ");
        Square e8 = new Square("e8", "             ", "             ", "             ");
        Square e9 = new Square("e9", "             ", "             ", "             ");
        Square e10 = new Square("e10", "             ", "             ", "             ");

        Square f1 = new Square("f1", "             ", "             ", "             ");
        Square f2 = new Square("f2", "             ", "             ", "             ");
        Square f3 = new Square("f3", "             ", "             ", "             ");
        Square f4 = new Square("f4", "             ", "             ", "             ");
        Square f5 = new Square("f5", "             ", "             ", "             ");
        Square f6 = new Square("f6", "             ", "             ", "             ");
        Square f7 = new Square("f7", "             ", "             ", "             ");
        Square f8 = new Square("f8", "             ", "             ", "             ");
        Square f9 = new Square("f9", "             ", "             ", "             ");
        Square f10 = new Square("f10", "             ", "             ", "             ");

        Square g1 = new Square("g1", "             ", "             ", "             ");
        Square g2 = new Square("g2", "             ", "             ", "             ");
        Square g3 = new Square("g3", "             ", "             ", "             ");
        Square g4 = new Square("g4", "             ", "             ", "             ");
        Square g5 = new Square("g5", "             ", "             ", "             ");
        Square g6 = new Square("g6", "             ", "             ", "             ");
        Square g7 = new Square("g7", "             ", "             ", "             ");
        Square g8 = new Square("g8", "             ", "             ", "             ");
        Square g9 = new Square("g9", "             ", "             ", "             ");
        Square g10 = new Square("g10", "             ", "             ", "             ");

        Square h1 = new Square("h1", "             ", "             ", "             ");
        Square h2 = new Square("h2", "             ", "             ", "             ");
        Square h3 = new Square("h3", "             ", "             ", "             ");
        Square h4 = new Square("h4", "             ", "             ", "             ");
        Square h5 = new Square("h5", "             ", "             ", "             ");
        Square h6 = new Square("h6", "             ", "             ", "             ");
        Square h7 = new Square("h7", "             ", "             ", "             ");
        Square h8 = new Square("h8", "             ", "             ", "             ");
        Square h9 = new Square("h9", "             ", "             ", "             ");
        Square h10 = new Square("h10", "             ", "             ", "             ");

        Square i1 = new Square("i1", "             ", "             ", "             ");
        Square i2 = new Square("i2", "             ", "             ", "             ");
        Square i3 = new Square("i3", "             ", "             ", "             ");
        Square i4 = new Square("i4", "             ", "             ", "             ");
        Square i5 = new Square("i5", "             ", "             ", "             ");
        Square i6 = new Square("i6", "             ", "             ", "             ");
        Square i7 = new Square("i7", "             ", "             ", "             ");
        Square i8 = new Square("i8", "             ", "             ", "             ");
        Square i9 = new Square("i9", "             ", "             ", "             ");
        Square i10 = new Square("i10", "             ", "             ", "             ");

        Square j1 = new Square("j1", "             ", "             ", "             ");
        Square j2 = new Square("j2", "             ", "             ", "             ");
        Square j3 = new Square("j3", "             ", "             ", "             ");
        Square j4 = new Square("j4", "             ", "             ", "             ");
        Square j5 = new Square("j5", "             ", "             ", "             ");
        Square j6 = new Square("j6", "             ", "             ", "             ");
        Square j7 = new Square("j7", "             ", "             ", "             ");
        Square j8 = new Square("j8", "             ", "             ", "             ");
        Square j9 = new Square("j9", "             ", "             ", "             ");
        Square j10 = new Square("j10", "             ", "             ", "             "); 

        Square command1 = new Square("command1", "   evoca     ", "   unità     ");
        Square command2 = new Square("command2", " seleziona   ", " unità       ");
        Square command3 = new Square("command3", " rimescola   ", " mano        ");
        Square command4 = new Square("command4", " esamina     ", " casella     ");
        Square command5 = new Square("command5", " mostra      ", " manuale     ");
        Square command6 = new Square("command6", " passa       ", " turno       ");

        string[] display = { "Mossa:", "Indica la casella dove vuoi posizionare l'unità (Es. a1, g7, c5):" };
        bool win1 = false;
        bool win2 = false;
        int round = 0;
        var rdm = new Random();
        int playerplaying = rdm.Next(1, 2);

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
        string[,] wholeTable =
        {      

            //  RIGA 0   V
            { "             ","             ","             ","             ","             ","             ","         Round",$"  {round}         ","             ","             ","             ","             ","             ","             "},
            { "             ","             ","             ","             ","             ","             ","  Turno  di"," Giocatore N   ","             ","             ","             ","             ","             ","             "},
            { "             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             "},
            { "             ","             ","      A      ","      B      ","      C      ","      D      ","      E      ","      F      ","      G      ","      H      ","      I      ","      J      ","             ","             "},

            { "             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             "},

            //  RIGA 1   V
            { "             ","             ",     a1.top    ,     b1.top    ,     c1.top    ,     d1.top    ,     e1.top    ,     f1.top    ,     g1.top    ,     h1.top    ,     i1.top    ,     j1.top    ,"             ","             "},
            { "             ","        1    ",     a1.mid    ,     b1.mid    ,     c1.mid    ,     d1.mid    ,     e1.mid    ,     f1.mid    ,     g1.mid    ,     h1.mid    ,     i1.mid    ,     j1.mid    ,"    1        ","             "},
            { "             ","             ",     a1.bot    ,     b1.bot    ,     c1.bot    ,     d1.bot    ,     e1.bot    ,     f1.bot    ,     g1.bot    ,     h1.bot    ,     i1.bot    ,     j1.bot    ,"             ","             "},

            { "             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             "},

            //  RIGA 2   V
            { "             ","             ",     a2.top    ,     b2.top    ,     c2.top    ,     d2.top    ,     e2.top    ,     f2.top    ,     g2.top    ,     h2.top    ,     i2.top    ,     j2.top    ,"             ","             "},
            { "             ","        2    ",     a2.mid    ,     b2.mid    ,     c2.mid    ,     d2.mid    ,     e2.mid    ,     f2.mid    ,     g2.mid    ,     h2.mid    ,     i2.mid    ,     j2.mid    ,"    2        ","             "},
            { "             ","             ",     a2.bot    ,     b2.bot    ,     c2.bot    ,     d2.bot    ,     e2.bot    ,     f2.bot    ,     g2.bot    ,     h2.bot    ,     i2.bot    ,     j2.bot    ,"             ","             "},
            { " Giocatore 1 ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","          "," Giocatore 2    "},

            //  RIGA 3   V
            { "                ","          ",     a3.top    ,     b3.top    ,     c3.top    ,     d3.top    ,     e3.top    ,     f3.top    ,     g3.top    ,     h3.top    ,     i3.top    ,     j3.top    ,"          ","                "},
            { " Sgorbio        ","     3    ",     a3.mid    ,     b3.mid    ,     c3.mid    ,     d3.mid    ,     e3.mid    ,     f3.mid    ,     g3.mid    ,     h3.mid    ,     i3.mid    ,     j3.mid    ,"    3     "," Sgorbio        "},
            { " 50             ","          ",     a3.bot    ,     b3.bot    ,     c3.bot    ,     d3.bot    ,     e3.bot    ,     f3.bot    ,     g3.bot    ,     h3.bot    ,     i3.bot    ,     j3.bot    ,"          "," 50             "},
            { "                ","          ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","          ","                "},

            //  RIGA 4   V
            { " Lancia Ciottoli","          ",     a4.top    ,     b4.top    ,     c4.top    ,     d4.top    ,     e4.top    ,     f4.top    ,     g4.top    ,     h4.top    ,     i4.top    ,     j4.top    ,"          "," Lancia Ciottoli"},
            { " 75             ","     4    ",     a4.mid    ,     b4.mid    ,     c4.mid    ,     d4.mid    ,     e4.mid    ,     f4.mid    ,     g4.mid    ,     h4.mid    ,     i4.mid    ,     j4.mid    ,"    4     "," 75             "},
            { "                ","          ",     a4.bot    ,     b4.bot    ,     c4.bot    ,     d4.bot    ,     e4.bot    ,     f4.bot    ,     g4.bot    ,     h4.bot    ,     i4.bot    ,     j4.bot    ,"          ","                "},
            { " Cavalca Pony   ","          ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","          "," Cavalca Pony   "},  
            
            //  RIGA 5   V
            { " 100            ","          ",     a5.top    ,     b5.top    ,     c5.top    ,     d5.top    ,     e5.top    ,     f5.top    ,     g5.top    ,     h5.top    ,     i5.top    ,     j5.top    ,"          "," 100            "},
            { "                ","     5    ",     a5.mid    ,     b5.mid    ,     c5.mid    ,     d5.mid    ,     e5.mid    ,     f5.mid    ,     g5.mid    ,     h5.mid    ,     i5.mid    ,     j5.mid    ,"    5     ","                "},
            { " Sciamano Goblin","          ",     a5.bot    ,     b5.bot    ,     c5.bot    ,     d5.bot    ,     e5.bot    ,     f5.bot    ,     g5.bot    ,     h5.bot    ,     i5.bot    ,     j5.bot    ,"          "," Sciamano Goblin"},
            { " 150            ","          ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","          "," 150            "},           
            
            //  RIGA 6   V
            { "                ","          ",     a6.top    ,     b6.top    ,     c6.top    ,     d6.top    ,     e6.top    ,     f6.top    ,     g6.top    ,     h6.top    ,     i6.top    ,     j6.top    ,"          ","                "},
            { " Ogre           ","     6    ",     a6.mid    ,     b6.mid    ,     c6.mid    ,     d6.mid    ,     e6.mid    ,     f6.mid    ,     g6.mid    ,     h6.mid    ,     i6.mid    ,     j6.mid    ,"    6     "," Ogre           "},
            { " 200            ","          ",     a6.bot    ,     b6.bot    ,     c6.bot    ,     d6.bot    ,     e6.bot    ,     f6.bot    ,     g6.bot    ,     h6.bot    ,     i6.bot    ,     j6.bot    ,"          "," 200            "},
            { "                ","          ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","          ","                "}, 
            
            //  RIGA 7   V
            { "                 ","         ",     a7.top    ,     b7.top    ,     c7.top    ,     d7.top    ,     e7.top    ,     f7.top    ,     g7.top    ,     h7.top    ,     i7.top    ,     j7.top    ,"         ","                 "},
            { " Mana Disponibile","    7    ",     a7.mid    ,     b7.mid    ,     c7.mid    ,     d7.mid    ,     e7.mid    ,     f7.mid    ,     g7.mid    ,     h7.mid    ,     i7.mid    ,     j7.mid    ,"    7    "," Mana Disponibile"},
            { " 500/500         ","         ",     a7.bot    ,     b7.bot    ,     c7.bot    ,     d7.bot    ,     e7.bot    ,     f7.bot    ,     g7.bot    ,     h7.bot    ,     i7.bot    ,     j7.bot    ,"         "," 500/500         "},
            { "                 ","         ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","         ","                 "},           
            
            //  RIGA 8   V
            { "                 ","         ",     a8.top    ,     b8.top    ,     c8.top    ,     d8.top    ,     e8.top    ,     f8.top    ,     g8.top    ,     h8.top    ,     i8.top    ,     j8.top    ,"         ","                 "},
            { " Riserva di Mana ","    8    ",     a8.mid    ,     b8.mid    ,     c8.mid    ,     d8.mid    ,     e8.mid    ,     f8.mid    ,     g8.mid    ,     h8.mid    ,     i8.mid    ,     j8.mid    ,"    8    "," Riserva di Mana "},
            { " 1000/1000       ","         ",     a8.bot    ,     b8.bot    ,     c8.bot    ,     d8.bot    ,     e8.bot    ,     f8.bot    ,     g8.bot    ,     h8.bot    ,     i8.bot    ,     j8.bot    ,"         "," 1000/1000       "},
            { "                 ","         ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","         ","                 "},            
            
            //  RIGA 9   V
            { "             ","             ",     a9.top    ,     b9.top    ,     c9.top    ,     d9.top    ,     e9.top    ,     f9.top    ,     g9.top    ,     h9.top    ,     i9.top    ,     j9.top    ,"             ","             "},
            { "             ","        9    ",     a9.mid    ,     b9.mid    ,     c9.mid    ,     d9.mid    ,     e9.mid    ,     f9.mid    ,     g9.mid    ,     h9.mid    ,     i9.mid    ,     j9.mid    ,"    9        ","             "},
            { "             ","             ",     a9.bot    ,     b9.bot    ,     c9.bot    ,     d9.bot    ,     e9.bot    ,     f9.bot    ,     g9.bot    ,     h9.bot    ,     i9.bot    ,     j9.bot    ,"             ","             "},
            { "             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             "},

            //  RIGA 10   V
            { "             ","             ",     a10.top   ,     b10.top   ,     c10.top   ,     d10.top   ,     e10.top   ,     f10.top   ,     g10.top   ,     h10.top   ,     i10.top   ,     j10.top   ,"             ","             "},
            { "             ","        10   ",     a10.mid   ,     b10.mid   ,     c10.mid   ,     d10.mid   ,     e10.mid   ,     f10.mid   ,     g10.mid   ,     h10.mid   ,     i10.mid   ,     j10.mid   ,"    10       ","             "},
            { "             ","             ",     a10.bot   ,     b10.bot   ,     c10.bot   ,     d10.bot   ,     e10.bot   ,     f10.bot   ,     g10.bot   ,     h10.bot   ,     i10.bot   ,     j10.bot   ,"             ","             "},
            { "             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             "},

            //  RIGA 11  V
            { "             ","             ","             ","             ",  command1.top ,  command2.top ,  command3.top ,  command4.top ,  command5.top ,  command6.top ,"             ","             ","             ","             "},
            { "             ","             ","             ","             ",  command1.bot ,  command2.bot ,  command3.bot ,  command4.bot ,  command5.bot ,  command6.bot ,"             ","             ","             ","             "},
            { "             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             ","             "},
            { "             ","             ","             ","       ","","","","","","","","","",display[0]}
        };

        while (win1 == false || win2 == false) //finché la partita non è vinta
        {
            round++;
            showGame(wholeTable, "0", /*playerplaying.ToString()*/"1", battlecamp);
            string input = Console.ReadLine();
            switch (input) //input menù di gioco
            {
                case "evoca unità":
                    break;
                case "seleziona unità":
                    break;
                case "rimescola mano":
                    break;
                case "esamina casella":
                    break;
                case "mostra manuale":
                    break;
                case "passa turno":
                    break;
                default: 
                    break;
            }
        }

    }
    public static void showGame(string[,] tabellone, string call, string idplayer, Square[,] battlecamp)
    {
        switch (call)
        {
            case "0":
                for (int i = 0; i < tabellone.GetLength(0); i++)  //scorre le righe
                {
                    for (int j = 0; j < tabellone.GetLength(1); j++) //scorre le colonne
                    {
                        //colora la singola casella di rosso
                        if ((i == 5 && j == 2) || (i == 6 && j == 2) || (i == 7 && j == 2))
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write($"{tabellone[i, j]} ");
                            Console.ResetColor();
                        }
                        else

                            Console.Write($"{tabellone[i, j]} ");
                    }
                    if (i < tabellone.GetLength(0) - 1)
                        Console.WriteLine();
                }
                Console.ReadLine();
                break;
            case "summon":
                if(idplayer == "1")
                {
                    for (int i = 0; i < tabellone.GetLength(0); i++)  //scorre le righe
                    {
                        for (int j = 0; j < tabellone.GetLength(1); j++) //scorre le colonne
                        {
                            //colora la singola casella di verde
                            if (
                                ((i == 5 && j == 2) || (i == 6 && j == 2) || (i == 7 && j == 2)) && battlecamp[0, 0].occupied == false || // A1
                                ((i == 5 && j == 3) || (i == 6 && j == 3) || (i == 7 && j == 3)) && battlecamp[0, 1].occupied == false || // B1
                                ((i == 5 && j == 4) || (i == 6 && j == 4) || (i == 7 && j == 4)) && battlecamp[0, 2].occupied == false || // C1
                                ((i == 5 && j == 5) || (i == 6 && j == 5) || (i == 7 && j == 5)) && battlecamp[0, 3].occupied == false || // D1
                                ((i == 5 && j == 6) || (i == 6 && j == 6) || (i == 7 && j == 6)) && battlecamp[0, 4].occupied == false || // E1
                                ((i == 5 && j == 7) || (i == 6 && j == 7) || (i == 7 && j == 7)) && battlecamp[0, 5].occupied == false || // F1
                                ((i == 5 && j == 8) || (i == 6 && j == 8) || (i == 7 && j == 8)) && battlecamp[0, 6].occupied == false || // G1
                                ((i == 5 && j == 9) || (i == 6 && j == 9) || (i == 7 && j == 9)) && battlecamp[0, 7].occupied == false || // H1
                                ((i == 5 && j == 10) || (i == 6 && j == 10) || (i == 7 && j == 10)) && battlecamp[0, 8].occupied == false || // I1
                                ((i == 5 && j == 11) || (i == 6 && j == 11) || (i == 7 && j == 11)) && battlecamp[0, 9].occupied == false || // J1

                                ((i == 11 && j == 2) || (i == 9 && j == 2) || (i == 10 && j == 2)) && battlecamp[1, 0].occupied == false || // A2
                                ((i == 11 && j == 3) || (i == 9 && j == 3) || (i == 10 && j == 3)) && battlecamp[1, 1].occupied == false || // B2
                                ((i == 11 && j == 4) || (i == 9 && j == 4) || (i == 10 && j == 4)) && battlecamp[1, 2].occupied == false || // C2
                                ((i == 11 && j == 5) || (i == 9 && j == 5) || (i == 10 && j == 5)) && battlecamp[1, 3].occupied == false || // D2
                                ((i == 11 && j == 6) || (i == 9 && j == 6) || (i == 10 && j == 6)) && battlecamp[1, 4].occupied == false || // E2
                                ((i == 11 && j == 7) || (i == 9 && j == 7) || (i == 10 && j == 7)) && battlecamp[1, 5].occupied == false || // F2
                                ((i == 11 && j == 8) || (i == 9 && j == 8) || (i == 10 && j == 8)) && battlecamp[1, 6].occupied == false || // G2
                                ((i == 11 && j == 9) || (i == 9 && j == 9) || (i == 10 && j == 9)) && battlecamp[1, 7].occupied == false || // H2 
                                ((i == 11 && j == 10) || (i == 9 && j == 10) || (i == 10 && j == 10)) && battlecamp[1, 8].occupied == false || // I2
                                ((i == 11 && j == 11) || (i == 9 && j == 11) || (i == 10 && j == 11)) && battlecamp[1, 9].occupied == false    // J2
                               )
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write($"{tabellone[i, j]} ");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ResetColor();
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
                            //colora la singola casella di verde
                            if (
                                ((i == 38 && j == 2) || (i == 39 && j == 2) || (i == 37 && j == 2)) && battlecamp[8, 0].occupied == false ||
                                ((i == 38 && j == 3) || (i == 39 && j == 3) || (i == 37 && j == 3)) && battlecamp[8, 1].occupied == false ||
                                ((i == 38 && j == 4) || (i == 39 && j == 4) || (i == 37 && j == 4)) && battlecamp[8, 2].occupied == false ||
                                ((i == 38 && j == 5) || (i == 39 && j == 5) || (i == 37 && j == 5)) && battlecamp[8, 3].occupied == false ||
                                ((i == 38 && j == 6) || (i == 39 && j == 6) || (i == 37 && j == 6)) && battlecamp[8, 4].occupied == false ||
                                ((i == 38 && j == 7) || (i == 39 && j == 7) || (i == 37 && j == 7)) && battlecamp[8, 5].occupied == false ||
                                ((i == 38 && j == 8) || (i == 39 && j == 8) || (i == 37 && j == 8)) && battlecamp[8, 6].occupied == false ||
                                ((i == 38 && j == 9) || (i == 39 && j == 9) || (i == 37 && j == 9)) && battlecamp[8, 7].occupied == false ||
                                ((i == 38 && j == 10) || (i == 39 && j == 10) || (i == 37 && j == 10)) && battlecamp[8, 8].occupied == false ||
                                ((i == 38 && j == 11) || (i == 39 && j == 11) || (i == 37 && j == 11)) && battlecamp[8, 9].occupied == false ||

                                ((i == 41 && j == 2) || (i == 43 && j == 2) || (i == 42 && j == 2)) && battlecamp[9, 0].occupied == false ||
                                ((i == 41 && j == 3) || (i == 43 && j == 3) || (i == 42 && j == 3)) && battlecamp[9, 1].occupied == false ||
                                ((i == 41 && j == 4) || (i == 43 && j == 4) || (i == 42 && j == 4)) && battlecamp[9, 2].occupied == false ||
                                ((i == 41 && j == 5) || (i == 43 && j == 5) || (i == 42 && j == 5)) && battlecamp[9, 3].occupied == false ||
                                ((i == 41 && j == 6) || (i == 43 && j == 6) || (i == 42 && j == 6)) && battlecamp[9, 4].occupied == false ||
                                ((i == 41 && j == 7) || (i == 43 && j == 7) || (i == 42 && j == 7)) && battlecamp[9, 5].occupied == false ||
                                ((i == 41 && j == 8) || (i == 43 && j == 8) || (i == 42 && j == 8)) && battlecamp[9, 6].occupied == false ||
                                ((i == 41 && j == 9) || (i == 43 && j == 9) || (i == 42 && j == 9)) && battlecamp[9, 7].occupied == false ||
                                ((i == 41 && j == 10) || (i == 43 && j == 10) || (i == 42 && j == 10)) && battlecamp[9, 8].occupied == false ||
                                ((i == 41 && j == 11) || (i == 43 && j == 11) || (i == 42 && j == 11)) && battlecamp[9, 9].occupied == false
                               )
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
                }
                Console.ReadLine();
            break;
        }

    }
    public static void shuffle(Player p) //rimescola la mano e pesca 5 nuove unità
    {
        while (p.hand.Count != 0) //svuota la mano rimettendo tutte le unità nella pool, tranne quelle "unità esaurite" che invece vengono eliminate
        {
            if (p.hand[0].identity == " ")
                p.hand.Remove(p.hand[0]);
            else
            {
                p.pool.Add(p.hand[0]);
                p.hand.Remove(p.hand[0]);
            }
        }
        for (int i = 0; i < 5; i++) //riempe la mano (max 5 slot) con unità se la pool non è vuota, e in quel caso la riempie con "unità esaurite"
        {
            if (p.pool.Count != 0)
            {
                var rdm = new Random();
                int indexPool = rdm.Next(p.pool.Count - 2);
             //   p.hand[i] = p.pool[indexPool];
                p.pool.Remove(p.pool[indexPool]);
            }
            else
            {
                p.hand[i] = p.pool[20];
            }
        }
    }
    static void summon(Player p, int round, ref Square[,] battlecamp, ref string[,] wholetable)
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
    static int maxManaPerTurn(int round)
    {
        int start = (round + 1) / 2 * 100;
        if (start <= 500)
            return start;
        else
            return 500;
    }
}
