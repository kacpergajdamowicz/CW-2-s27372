using CW_2_s27372.Interfejsy;

namespace CW_2_s27372.Klasy
{
    enum TypLadunku
    {
        Zwykly, Niebezpieczny
    }
    internal class KontenerPlyn(int wysokosc, int glebokosc, float masaWlasna, float maxLadownosc) : Kontener(TypKontenera.L, wysokosc, glebokosc, masaWlasna, maxLadownosc)
    {
        public TypLadunku? Ladunek { get; set; }
        public void PrzygotujDoZaladunku(TypLadunku typLadunku)
        {
            Ladunek = typLadunku;
        }
        public override void Zaladuj(float masa)
        {
            if(!Ladunek.HasValue)
            {
                NotifyHazard("Kontener nie przygotowany do zaladunku, ustaw typ ladunku.");
                return;
            }
            else if (Ladunek == TypLadunku.Niebezpieczny)
            {
                if (masa > MaxLadownosc * 0.5)
                {
                    NotifyHazard("Nie mozna zaladowac niebezpiecznego ladunku powyzej 50% maksymalnej ladownosci");
                    return;
                }
                else
                {
                    MasaLadunku = masa;
                }
            }
            else
            {
                if (masa > MaxLadownosc * 0.9)
                {
                    NotifyHazard("Nie mozna zaladowac ladunku powyzej 90% maksymalnej ladownosci");
                    return;
                }
                else
                {
                    MasaLadunku = masa;
                }
            }
            Console.WriteLine($"Kontener {NrSeryjny}: ladunek zaladowany");
        }

        public override void Oproznij()
        {
            MasaLadunku = 0;
            Ladunek = null;
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
Typ ladunku: {Ladunek}
            ";
        }
    }
}
