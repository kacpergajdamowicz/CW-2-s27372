using CW_2_s27372.Interfejsy;

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
    internal class KontenerChlodniczy(int wysokosc, int glebokosc, float masaWlasna, float maxLadownosc) : Kontener(TypKontenera.C, wysokosc, glebokosc, masaWlasna, maxLadownosc)
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
        public RodzajProduktu? Produkt { get; set; }
        private float _temperatura;
        public float Temperatura
        {
            get => _temperatura;
            set
            {
                if (!Produkt.HasValue)
                    NotifyHazard("Przed ustawieniem temeperatury ustaw rodzaj produktu");
                if (WymaganaTemperatura[Produkt.Value] > value)
                    NotifyHazard($"Temperatura {value} jest zbyt niska dla produktu {Produkt}, maksymalna wynosi {WymaganaTemperatura[Produkt.Value]}");
                _temperatura = value;
            }
        }
        public void PrzygotujDoZaladunku(RodzajProduktu rodzajProduktu, float temperatura)
        {
            Produkt = rodzajProduktu;
            Temperatura = temperatura;
        }
        public void PrzygotujDoZaladunku(RodzajProduktu rodzajProduktu)
        {
            Produkt = rodzajProduktu;
            Temperatura = WymaganaTemperatura[rodzajProduktu];
        }
        public override void Zaladuj(float masa)
        {
            if(!Produkt.HasValue)
            {
                NotifyHazard("Kontener nie przygotowany do zaladunku, ustaw rodzaj produktu oraz temperature.");
                return;
            }
            if(WymaganaTemperatura[Produkt.Value] > Temperatura)
            {
                NotifyHazard($"Kontener nie ma ustawionej odpowiedniej temperatury do zaladunku towaru {Produkt}");
                return;
            }
            MasaLadunku = masa;
            Console.WriteLine($"Kontener {NrSeryjny}: ladunek zaladowany");
        }
        public override void Oproznij()
        {
            MasaLadunku = 0;
            Produkt = null;
            Temperatura = 0;
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
Rodzaj produktu: {Produkt}
Temperatura: {Temperatura}
            ";
        }
    }
}
