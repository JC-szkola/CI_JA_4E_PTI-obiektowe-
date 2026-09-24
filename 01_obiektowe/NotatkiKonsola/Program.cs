using System;

namespace NotatkiKonsola
{
    // Klasa: Notatka
    // Opis: Reprezentuje pojedynczą notatkę tekstową (tytuł + treść) z automatycznie 
    //       nadawanym, unikalnym identyfikatorem numerycznym.
    // Pola: licznikNotatek (static, prywatny) - liczba utworzonych dotąd notatek
    //       identyfikator (prywatny) - unikalny numer danej notatki
    //       tytul (protected) - tytuł notatki
    //       tresc (protected) - treść notatki
    // Metody: WyswietlNotatke() - wypisuje tytuł i treść w czytelnej formie
    //         WyswietlDiagnostyke() - wypisuje wszystkie pola oddzielone średnikami
    // Autor: Ciepiałowski Jakub 4E PTI
    class Notatka
    {
        private static int licznikNotatek = 0;

        public static int LiczbaNotatek => licznikNotatek;

        private int identyfikator;

        protected string tytul;
        protected string tresc;

        public Notatka(string tytul, string tresc)
        {
            licznikNotatek++;
            this.identyfikator = licznikNotatek;
            this.tytul = tytul;
            this.tresc = tresc;
        }

        public void WyswietlNotatke()
        {
            Console.WriteLine($"[Notatka nr {identyfikator}]");
            Console.WriteLine($"Tytuł: {tytul}");
            Console.WriteLine($"Treść: {tresc}");
            Console.WriteLine(new string('-', 40));
        }

        public void WyswietlDiagnostyke()
        {
            string tytulDiag = tytul.Replace(",", ";");
            string trescDiag = tresc.Replace(",", ";");

            Console.WriteLine(
                $"ID={identyfikator};Tytul={tytulDiag};Tresc={trescDiag};LiczbaNotatek={licznikNotatek}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Notatka notatkaZakupy = new Notatka(
                "Lista zakupów",
                "Mleko, chleb, jajka, masło, kawa");

            Notatka notatkaSpotkanie = new Notatka(
                "Spotkanie projektowe",
                "Spotkanie z zespołem w piątek o 15:00, sala 204");

            Console.WriteLine($"Ilość notatek: {Notatka.LiczbaNotatek}\n");

            notatkaZakupy.WyswietlNotatke();
            notatkaZakupy.WyswietlDiagnostyke();
            Console.WriteLine();

            notatkaSpotkanie.WyswietlNotatke();
            notatkaSpotkanie.WyswietlDiagnostyke();

            Console.ReadKey();
        }
    }
}