using System.Reflection.Metadata;
using System.Xml.Serialization;

namespace CW_2_s27372.Klasy
{
    internal class Statek(string nazwa, int maxPredkosc, int maxLiczbaKontenerow, float maxWagaKontenerow)
    {
        public List<Kontener> Kontenery { get; } = new List<Kontener>();
        public string Nazwa { get; set; } = nazwa;
        public int MaxPredkosc { get; set; } = maxPredkosc;
        public int MaxLiczbaKontererow { get; set; } = maxLiczbaKontenerow;
        public float MaxWagaKontenerow { get; set; } = maxWagaKontenerow;

        public void ZaladujKontener(Kontener kontener)
        {
            if(Kontenery.Count() < MaxLiczbaKontererow)
            {
                if(AktualnaMasa() < MaxWagaKontenerow)
                {
                    Kontenery.Add(kontener);
                    Console.WriteLine($"Kontener {kontener.NrSeryjny} zaladowany na statek");
                }
                else
                {
                    throw new OverfillException("Statek osiagnal maksymalna ladownosc, zaladunek kontenera nie mozliwy");
                }
            }
            else
            {
                throw new OverfillException("Statek osiagnal maksymalna pojemonosc kontenerow, zaladunek kontenera nie mozliwy");
            }
        }

        private float AktualnaMasa()
        {
            return Kontenery.Sum(x => x.MasaLadunku + x.MasaWlasna);
        }

        public void ZaladujKontenery(List<Kontener> kontenery)
        {
            foreach (Kontener kon in kontenery)
            {
                ZaladujKontener(kon);
            }
        }

        public void UsunKontener(Kontener kontener)
        {
            Kontenery.Remove(kontener);
            Console.WriteLine($"Kontener {kontener.NrSeryjny} usuniety ze statku");
        }

        public void ZastapKontener(Kontener kontenerDoUsuniecia, Kontener kontenerDoDodania)
        {
            var i = Kontenery.IndexOf(kontenerDoUsuniecia);
            if(i != -1)
            {
                if(AktualnaMasa() - kontenerDoUsuniecia.MasaLadunku - kontenerDoUsuniecia.MasaWlasna + kontenerDoDodania.MasaLadunku + kontenerDoDodania.MasaWlasna < MaxWagaKontenerow)
                {
                    Kontenery[i] = kontenerDoDodania;
                    Console.WriteLine($"Kontener {kontenerDoUsuniecia.NrSeryjny} zastapiony kontenerem {kontenerDoDodania.NrSeryjny}");
                }
                else
                {
                    throw new OverfillException("Dodawany kontener jest za ciezki, podmiana kontenera nie mozliwa");
                }
            }
            else
            {
                Console.WriteLine($"Kontener {kontenerDoUsuniecia.NrSeryjny} nie znajduje sie na statku.");
            }
        }

        public void PrzeniesKontenerNaInnyStatek(Statek statek, Kontener kontener)
        {
            var i = Kontenery.IndexOf(kontener);
            if (i != -1)
            {
                UsunKontener(kontener);
                statek.ZaladujKontener(kontener);
            }
            else
            {
                Console.WriteLine($"Kontener {kontener.NrSeryjny} nie znajduje sie na statku.");
            }
        }

        public override string ToString()
        {
            return $@"
=== Parametry statku ===
Maksymalna predkosc: {MaxPredkosc} w.
Maksymalna liczba kontenerow: {MaxLiczbaKontererow}
Maksymalna waga kontenerow: {MaxWagaKontenerow} t
=== Aktualne dane ===
Liczba kontenerow: {Kontenery.Count()}
Waga kontenerow: {AktualnaMasa()}
Kontenery: {string.Join(", ",Kontenery.Select(x => x.NrSeryjny))}
            ";
        }
    }
}
