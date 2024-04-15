using System;
using System.Threading.Tasks;

namespace CoreCoin
{
    class Program
    {
        public static string Me = string.Empty;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("- CoreCoin Menu -");
                Console.WriteLine("");
                Console.WriteLine("1. BlockChain oluştur");
                Console.WriteLine("2. Para al-gönder");
                Console.WriteLine("3. Coin Mine başlat");
                Console.WriteLine("4. Peer-to-Peer sync");
                Console.WriteLine();
                Console.WriteLine("9. Çıkış");
                Console.WriteLine();
                Console.Write("Seçiminiz : ");
                var menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        StartBlockChain();
                        break;
                    case "2":
                        MakeTransactions();
                        break;
                    case "3":
                        StartMining();
                        break;
                    case "4":
                        StartSyncing();
                        break;
                    case "9":
                    default:
                        return;
                }
            }
        }

        static void StartSyncing()
        {

        }

        static void StartMining()
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    Console.WriteLine("Mining başlıyor");

                    chain.MineCoreCoin();

                    Console.WriteLine("Mining bitti");

                    await Task.Delay(TimeSpan.FromSeconds(30));
                }
            });
        }

        static void MakeTransactions()
        {
            var engin = Guid.NewGuid().ToString("N");
            var ahmet = Guid.NewGuid().ToString("N");
            var mehmet = Guid.NewGuid().ToString("N");

            Me = engin;

            chain.AddBlock(new BlockData(engin, ahmet, 100));
            chain.AddBlock(new BlockData(engin, mehmet, 60));
            chain.AddBlock(new BlockData(ahmet, mehmet, 30));
            chain.AddBlock(new BlockData(ahmet, engin, 90));

            Console.WriteLine("İyi alış-veriş yaptık :)");
        }

        static Chain chain = null;

        static void StartBlockChain()
        {
            chain = new Chain();

            Console.WriteLine("Chain hazır!");
        }
    }
}
