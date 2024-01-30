
internal class Program
{
    private static void Main(string[] args)
    {
        string scemo = "roma/rosso/rabarbaro";
        string scemo1 = "firenze azzurro bietola";
        string scemo2 = "firenze rosso amarena";
        string app = null;
        for (int i = 0; i != '/'; i++)
        {
            app = app + scemo[i];
        }
    }

    public class Immobile
    {
        public string id;
        public string codice;
        public string indirizzo;
        public string cap;
        public string città;
        public string superficie;
        public Immobile(string i, string codic, string indirizz, string ca, string citt, string superfici)
        {
            id = i;
            codice = codic;
            indirizzo = indirizz;
            cap = ca;
            città = citt;
            superficie = superfici;
        }
        public virtual string Readable()
        {
            string s = $"{id}" + "/" + $"{ codice }" + "/" + $"{ indirizzo }" + "/" + $"{ cap }" + "/" + $"{ città }" + "/" + $"{ superficie }";
            return s;
        }
    }

    public class Appartamento : Immobile
    {
        string n_vani;
        string n_bagni;

        public Appartamento(string i, string codic, string indirizz, string ca, string citt, string superfici, string vani, string bagni) : base(i, codic, indirizz, ca, citt, superfici)
        {
            n_vani = vani;
            n_bagni = bagni;
        }
        public override string Readable()
        {
            string s = $"{id}" + "/" + $"{codice}" + "/" + $"{indirizzo}" + "/" + $"{cap}" + "/" + $"{città}" + "/" + $"{superficie}" + "/" + $"{n_vani}" + "/" + $"{n_bagni}";
            return s;
        }
    }
    public class Villa : Immobile
    {
        string d_giardino;
        public Villa(string i, string codic, string indirizz, string ca, string citt, string superfici, string giardino) : base(i, codic, indirizz, ca, citt, superfici)
        {
            d_giardino = giardino;
        }
        public override string Readable()
        {
            string s = $"{id}" + "/" + $"{codice}" + "/" + $"{indirizzo}" + "/" + $"{cap}" + "/" + $"{città}" + "/" + $"{superficie}" + "/" + $"{d_giardino}";
            return s;
        }
    }
    public class AgenziaImmobiliare
    {
       public List<Immobile> immobili;
        public AgenziaImmobiliare()
        {
            immobili = null;
        }
    }
}