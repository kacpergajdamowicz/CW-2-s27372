using CW_2_s27372.Interfejsy;

namespace CW_2_s27372.Klasy
{
    internal class KontenerGaz(int wysokosc, int glebokosc, float masaWlasna, float maxLadownosc) : Kontener(TypKontenera.G, wysokosc, glebokosc, masaWlasna, maxLadownosc)
    {
        public override void Zaladuj(float masa)
        {
            MasaLadunku = masa;
            Console.WriteLine($"Kontener {NrSeryjny}: ladunek zaladowany");
        }

        public override void Oproznij()
        {
            MasaLadunku = MasaLadunku * 0.95f;
            Console.WriteLine($"Kontener {NrSeryjny}: ladunek rozaladowany");
        }

        public override string ToString()
        {
            return @$"
=== Dane kontenera ===
Numer seryjny: {NrSeryjny}
Maksymalna ladownosc: {MaxLadownosc}
Wysykosc: {Wysykosc}
Glebokosc: {Glebokosc}
MasaWlasna: {MasaWlasna}
=== Aktualne dane ===
Masa ladunku: {MasaLadunku}
            ";
        }
    }
}
