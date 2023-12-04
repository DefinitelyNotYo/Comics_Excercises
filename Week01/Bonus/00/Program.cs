string password = "Password2023";
string trys = "Segnaposto";
Console.WriteLine("Inserisci la password");

for (int nTentativi = 0; nTentativi < 3; nTentativi++)
{
    trys = Console.ReadLine();
    if (trys != password && nTentativi < 2)
        Console.WriteLine("Mi dispiace, la password è sbagliata! Riprova...");
    else if (trys != password)
        Console.WriteLine("Mi dispiace, hai esaurito i tentativi");
    else
        Console.WriteLine("Complimenti! La password è corretta");
}
