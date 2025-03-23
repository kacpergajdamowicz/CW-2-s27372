using CW_2_s27372.Klasy;

namespace CW_2_s27372
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var konL01 = new KontenerPlyn(4, 8, 853.8f, 5000f);
            var konL02 = new KontenerPlyn(4, 8, 952.8f, 3000f);
            var konG01 = new KontenerGaz(3, 5, 522.1f, 952.54f);
            var konC01 = new KontenerChlodniczy(5, 10, 1203.7f, 9500f);

            konL01.PrzygotujDoZaladunku(TypLadunku.Niebezpieczny);
            konL01.Zaladuj(3400f);

            konL02.PrzygotujDoZaladunku(TypLadunku.Zwykly);
            konL02.Zaladuj(1200f);

            konG01.Zaladuj(300f);

            konC01.PrzygotujDoZaladunku(RodzajProduktu.Bananas);
            konC01.Zaladuj(123f);
            Console.WriteLine(konC01.ToString());

            var statek01 = new Statek("Statek1", 30, 10, 20000f);
            statek01.ZaladujKontener(konL02);
            statek01.ZaladujKontenery(new List<Kontener>{ konG01, konC01});

            statek01.UsunKontener(konG01);

            konG01.Oproznij();

            var statek02 = new Statek("Statek2", 30, 10, 20000f);
            statek01.PrzeniesKontenerNaInnyStatek(statek02, konC01);

            konL01.Zaladuj(200f);
            statek02.ZastapKontener(konC01, konL01);

            Console.WriteLine(statek01.ToString());
        }
    }
}