using CW_2_s27372.Interfejsy;

namespace CW_2_s27372.Klasy
{
    enum TypKontenera
    {
        L, G, C
    }

    class OverfillException(string message) : Exception(message);

    abstract class Kontener(TypKontenera typ, int wysokosc, int glebokosc, float masaWlasna, float maxLadownosc) : IHazardNotifier
    {
        private static Dictionary<TypKontenera, int> _liczniki = new()
        {
            {TypKontenera.L, 1},
            {TypKontenera.G, 1},
            { TypKontenera.C, 1}
        };
        private float _masaLadunku;
        public float MasaWlasna { get; set; } = masaWlasna;
        public int Wysykosc { get; set; } = wysokosc;
        public int Glebokosc { get; set; } = glebokosc;
        public string NrSeryjny { get; } = $"KON-{typ}-{_liczniki[typ]++}";
        public float MaxLadownosc { get; set; } = maxLadownosc;
        public float MasaLadunku
        {
            get => _masaLadunku;
            protected set
            {
                if (value > MaxLadownosc)
                {
                    throw new OverfillException($"Ladunek o masie {value} przekracza dopuszczalna ladownosc ({MaxLadownosc} kg).");
                }
                else
                {
                    _masaLadunku = value;
                }
            }
        }

        public abstract void Oproznij();

        public abstract void Zaladuj(float masa);

        public abstract override string ToString();

        public void NotifyHazard(string message) => Console.WriteLine($"Kontener {NrSeryjny}: {message}");
    }
}