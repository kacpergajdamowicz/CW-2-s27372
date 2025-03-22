using CW_2_s27372.Interfejsy;

namespace CW_2_s27372.Klasy
{
    internal class KontenerGaz() : Kontener(TypKontenera.G), IHazardNotifier
    {
        public override void Zaladuj(float masa)
        {
            MasaLadunku = masa;
        }

        public void Oproznij()
        {
            MasaLadunku = MasaLadunku * 0.95f;
        }

        public void NotifyHazard(string message)
        {
            Console.Write($"Kontener {NrSeryjny}: {message}");
        }
    }
}
