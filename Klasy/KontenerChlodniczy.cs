namespace CW_2_s27372.Klasy
{
    enum RodzajProduktu
    {
        Bananas,
        Chocolate,
        Fish,
        Meat,
        IceCream,
        FrozenPizza,
        Cheese,
        Sausages,
        Butter,
        Eggs
    }
    internal class KontenerChlodniczy(RodzajProduktu rodzajProduktu) : Kontener(TypKontenera.C)
    {
        private static readonly Dictionary<RodzajProduktu, float> WymaganaTemperatura = new()
        {
            { RodzajProduktu.Bananas, 13.3f },
            { RodzajProduktu.Chocolate, 18f },
            { RodzajProduktu.Fish, 2f },
            { RodzajProduktu.Meat, -15f },
            { RodzajProduktu.IceCream, -18f },
            { RodzajProduktu.FrozenPizza, -30f },
            { RodzajProduktu.Cheese, 7.2f },
            { RodzajProduktu.Sausages, 5f },
            { RodzajProduktu.Butter, 20.5f },
            { RodzajProduktu.Eggs, 19f }
        };
        public RodzajProduktu RodzajProduktu { get; set; } = rodzajProduktu;
        private float _temperatura;
        public float Temperatura
        {
            get => _temperatura;
            set
            {
                if (WymaganaTemperatura[RodzajProduktu] > value)
                    throw new Exception($"Temperatura {value} jest zbyt niska dla produktu {RodzajProduktu}, maksymalna wynosi {WymaganaTemperatura[RodzajProduktu]}");
                _temperatura = value;
            }
        }
        public override void Zaladuj(float masa)
        {
            MasaLadunku = masa;
        }
    }
}
