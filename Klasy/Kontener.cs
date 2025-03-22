namespace CW_2_s27372.Klasy
{
    enum TypKontenera
    {
        L, G, C
    }

    class OverfillException(string message) : Exception(message);

    abstract class Kontener(TypKontenera typ)
    {
        private static Dictionary<TypKontenera, int> _liczniki = new()
        {
            {TypKontenera.L, 1},
            {TypKontenera.G, 1},
            { TypKontenera.C, 1}
        };
        private float _masaLadunku;
        public float MasaWlasna { get; set; }
        public int Wysykosc { get; set; }
        public int Glebokosc { get; set; }
        public string NrSeryjny { get; } = $"KON-{typ}-{_liczniki[typ]++}";
        public float MaxLadownosc { get; set; }
        public float MasaLadunku
        {
            get => _masaLadunku;
            set
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

        public void Oproznij()
        {
            MasaLadunku = 0;
        }

        public abstract void Zaladuj(float masa);
    }
}