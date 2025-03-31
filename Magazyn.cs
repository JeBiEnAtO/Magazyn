using System;
using System.Collections.Generic;

class Produkt
{
    public string KodKreskowy { get; set; }
    public string Nazwa { get; set; }
    public int Ilosc { get; set; }
    public double Cena { get; set; }

    public Produkt(string kod, string nazwa, int ilosc, double cena)
    {
        KodKreskowy = kod;
        Nazwa = nazwa;
        Ilosc = ilosc;
        Cena = cena;
    }
}

class Program
{
    static List<Produkt> magazyn = new();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Dodaj | 2. Usuń | 3. Lista | 4. Aktualizuj | 5. Wartość | 6. Wyjście");
            switch (Console.ReadLine())
            {
                case "1": DodajProdukt(); break;
                case "2": UsunProdukt(); break;
                case "3": WyswietlProdukty(); break;
                case "4": AktualizujProdukt(); break;
                case "5": ObliczWartosc(); break;
                case "6": return;
                default: Console.WriteLine("Nieprawidłowy wybór"); break;
            }
        }
    }

    static void DodajProdukt()
    {
        Console.Write("Kod kreskowy: "); string kod = Console.ReadLine();
        Console.Write("Nazwa: "); string nazwa = Console.ReadLine();
        Console.Write("Ilość: "); int ilosc = int.Parse(Console.ReadLine());
        Console.Write("Cena: "); double cena = double.Parse(Console.ReadLine());
        magazyn.Add(new Produkt(kod, nazwa, ilosc, cena));
    }

    static void UsunProdukt()
    {
        Console.Write("Podaj kod kreskowy: ");
        magazyn.RemoveAll(p => p.KodKreskowy == Console.ReadLine());
    }

    static void WyswietlProdukty()
    {
        magazyn.ForEach(p => Console.WriteLine($"{p.KodKreskowy} | {p.Nazwa} | {p.Ilosc} | {p.Cena:C}"));
    }

    static void AktualizujProdukt()
    {
        Console.Write("Podaj kod kreskowy: ");
        var produkt = magazyn.Find(p => p.KodKreskowy == Console.ReadLine());
        if (produkt == null) return;
        Console.Write("Nowa ilość: "); produkt.Ilosc = int.Parse(Console.ReadLine());
        Console.Write("Nowa cena: "); produkt.Cena = double.Parse(Console.ReadLine());
    }

    static void ObliczWartosc()
    {
        Console.WriteLine($"Wartość magazynu: {magazyn.Sum(p => p.Ilosc * p.Cena):C}");
    }
}
