using CW_2_s27372.Interfejsy;

namespace CW_2_s27372.Klasy
{
    enum TypLadunku
    {
        Zwykly, Niebezpieczny
    }
    internal class KontenerPlyn(TypLadunku typLadunku) : Kontener(TypKontenera.L), IHazardNotifier
    {
        public TypLadunku TypLadunku { get; set; } = typLadunku;
        public override void Zaladuj(float masa)
        {
            if (TypLadunku == TypLadunku.Niebezpieczny)
            {
                if (masa > MaxLadownosc * 0.5)
                {
                    NotifyHazard("Nie mozna zaladowac niebezpiecznego ladunku powyzej 50% maksymalnej ladownosci");
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
                }
                else
                {
                    MasaLadunku = masa;
                }
            }
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"Kontener {NrSeryjny}: {message}");
        }
    }
}
