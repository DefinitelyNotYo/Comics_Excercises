/* COSA MEGA UTILE PER METTERE LE COSE AL CENTRO DELLO SCHERMO */
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {/*
        Console.WriteLine("Hello, World!");
        Thread.Sleep(5000);
        Console.Clear();
        Console.WriteLine("Ok, hai cancellato");
     */
        string Clna = "                   A           B           c           D           E           F           G           H           I           J           K           L           M           N            O            P      ";
        string r100 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r010 = "      1      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r001 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string r200 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r020 = "      2      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r002 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string r300 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r030 = "      3      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r003 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string r400 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r040 = "      4      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r004 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string r500 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r050 = "      5      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r005 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string r600 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r060 = "      6      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r006 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string r700 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r070 = "      7      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r007 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string r800 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r080 = "      8      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r008 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string r900 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r090 = "      9      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r009 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string rX00 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r0X0 = "      0      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00X = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";


        string r10000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r01000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00100 = "      1      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00010 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00001 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string r20000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r02000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00200 = "      2      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00020 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00002 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string r30000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r03000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00300 = "      3      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00030 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00003 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string r40000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r04000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00400 = "      4      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00040 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00004 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string r50000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r05000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00500 = "      5      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00050 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00005 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string r60000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r06000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00600 = "      6      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00060 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00006 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string r70000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r07000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00700 = "      7      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00070 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00007 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string r80000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r08000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00800 = "      8      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00080 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00008 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string r90000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r09000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00900 = "      9      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00090 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00009 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";

        string rX0000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r0X000 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r00X00 = "      0      |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r000X0 = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";
        string r0000X = "             |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |  iiiiiii  |";







        //int[,] numbers2D = { { 9, 99 }, { 3, 33 }, { 5, 55 } };
        //int[,] nomeMatrice = { {i00, i01} {i10, i11} {i20, i21} };
        string[,] matrice =
        {
            { "    A1    ", "    B1    ", "    C1    ", "    D1    " }, 
            { "    A2    ", "    B2    ", "    C2    ", "    D2    " }, 
            { "    A3    ", "    B3    ", "    C3    ", "    D3    " }
        };



        //string[,] matrice ={ { "RIGA 0 COLONNA 0", "RIGA 0, COLONNA 1 },{ RIGA 0, COLONNA 2 }, { "RIGA 1 COLONNA 0", "RIGA 1, COLONNA 1 },{ RIGA 1, COLONNA 2 }};
        //Console.WriteLine(matrice.GetLength(0)); //TROVA IL NUMERO DELLE RIGHE e DELLE COLONNE (matrice quadrata)
        for (int i = 0; i < matrice.GetLength(0); i++)  //scorre le righe
        {
            for (int j = 0; j < matrice.GetLength(1); j++) //scorre le colonne
            {
                if (i == 1 && j == 2)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write($"{matrice[i, j]} ");
                    Console.ResetColor();
                }
                else
                    Console.Write($"{matrice[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.ReadLine();
        Console.Clear();
        for (int i = 0; i < matrice.GetLength(0); i++)  //scorre le righe
        {
            for (int j = 0; j < matrice.GetLength(1); j++) //scorre le colonne
            {
                if (i == 1 && j == 2)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write($"{matrice[i, j]} ");
                    Console.ResetColor();
                }
                else
                    Console.Write($"{matrice[i, j]} ");
            }
            Console.WriteLine();
        }
        /*
                      for (int i = 0; i < matrice.GetLength(0); i++)
                      {
                          for(int j = 0; j < matrice.GetLength(1); i++)
                          {
                              matrice[i, j] = "cane";
                          }
                      }

                      for (int i = 0; i < matrice.Length; i++)
                      {
                          for (int j = 0; j < matrice.Length; i++)
                          {
                              Console.Write(matrice[i, j]);
                          }
                          Console.WriteLine();
                      }
        */

        
        Console.WriteLine(Clna);
        Console.WriteLine();
        Console.WriteLine(r100);
        Console.WriteLine(r010);
        Console.WriteLine(r001);

        Console.WriteLine();

        Console.WriteLine(r200);
        Console.WriteLine(r020);
        Console.WriteLine(r002);

        Console.WriteLine();

        Console.WriteLine(r300);
        Console.WriteLine(r030);
        Console.WriteLine(r003);

        Console.WriteLine();

        Console.WriteLine(r400);
        Console.WriteLine(r040);
        Console.WriteLine(r004);

        Console.WriteLine();

        Console.WriteLine(r500);
        Console.WriteLine(r050);
        Console.WriteLine(r005);

        Console.WriteLine();

        Console.WriteLine(r600);
        Console.WriteLine(r060);
        Console.WriteLine(r006);

        Console.WriteLine();

        Console.WriteLine(r700);
        Console.WriteLine(r070);
        Console.WriteLine(r007);

        Console.WriteLine();

        Console.WriteLine(r800);
        Console.WriteLine(r080);
        Console.WriteLine(r008);

        Console.WriteLine();

        Console.WriteLine(r900);
        Console.WriteLine(r090);
        Console.WriteLine(r009);

        Console.WriteLine();

        Console.WriteLine(rX00);
        Console.WriteLine(r0X0);
        Console.WriteLine(r00X);

        Console.WriteLine();


        Console.WriteLine(Clna);
        Console.WriteLine();
        Console.WriteLine(r10000);
        Console.WriteLine(r01000);
        Console.WriteLine(r00100);
        Console.WriteLine(r00010);
        Console.WriteLine(r00001);

        Console.WriteLine();

        Console.WriteLine(r20000);
        Console.WriteLine(r02000);
        Console.WriteLine(r00200);
        Console.WriteLine(r00020);
        Console.WriteLine(r00002);
        Console.WriteLine();

        Console.WriteLine(r30000);
        Console.WriteLine(r03000);
        Console.WriteLine(r00300);
        Console.WriteLine(r00030);
        Console.WriteLine(r00003);

        Console.WriteLine();

        Console.WriteLine(r40000);
        Console.WriteLine(r04000);
        Console.WriteLine(r00400);
        Console.WriteLine(r00040);
        Console.WriteLine(r00004);

        Console.WriteLine();

        Console.WriteLine(r50000);
        Console.WriteLine(r05000);
        Console.WriteLine(r00500);
        Console.WriteLine(r00050);
        Console.WriteLine(r00005);

        Console.WriteLine();

        Console.WriteLine(r60000);
        Console.WriteLine(r06000);
        Console.WriteLine(r00600);
        Console.WriteLine(r00060);
        Console.WriteLine(r00006);

        Console.WriteLine();

        Console.WriteLine(r70000);
        Console.WriteLine(r07000);
        Console.WriteLine(r00700);
        Console.WriteLine(r00070);
        Console.WriteLine(r00007);

        Console.WriteLine();

        Console.WriteLine(r80000);
        Console.WriteLine(r08000);
        Console.WriteLine(r00800);
        Console.WriteLine(r00080);
        Console.WriteLine(r00008);

        Console.WriteLine();

        Console.WriteLine(r90000);
        Console.WriteLine(r09000);
        Console.WriteLine(r00900);
        Console.WriteLine(r00090);
        Console.WriteLine(r00009);

        Console.WriteLine();

        Console.WriteLine(rX0000);
        Console.WriteLine(r0X000);
        Console.WriteLine(r00X00);
        Console.WriteLine(r000X0);
        Console.WriteLine(r0000X);

        Console.WriteLine();
    
    }

    static void CenterText(string text)
    {
        Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
        Console.WriteLine(text);
    }

}