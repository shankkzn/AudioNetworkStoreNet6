using System;
using System.Linq;

namespace AudioNetworkStoreNet6
{
    /// <summary>
    /// Entry point of the application.
    /// Точка входа в приложение.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method that initializes and runs the audio store simulation.
        /// Основной метод, инициализирующий и запускающий симуляцию аудиомагазина.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                // Initialize store and network thresholds
                // Инициализация магазина и порогов сети
                Store store = new();
                Store.MinQty = 3;
                Network.MinQty = 5;

                // Create sample products / Создание тестовых товаров
                var (mp3s, mp4s, headphones) = CreateTestProducts();

                // Add products to the store / Добавление товаров в магазин
                AddProductsToStore(store, mp3s, mp4s, headphones);

                // Display all products / Отображение всех товаров
                PrintProductList(store.GetAllProducts().ToArray());

                // Create a network and add store / Создание сети и добавление магазина
                var network = new Network();
                network.AddStore(store);

                // Display total and low-stock info / Показ общей стоимости и дефицитных товаров
                PrintDisplayTotals(network);
            }
            catch (Exception ex)
            {
                // Handle unexpected errors / Обработка ошибок
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            // Pause before exit / Пауза перед выходом
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Creates test product data for MP3, MP4 and headphones.
        /// Создаёт тестовые данные для MP3, MP4 и наушников.
        /// </summary>
        static (Product[] mp3s, Product[] mp4s, Product[] headphones) CreateTestProducts()
        {
            var mp3s = new Product[]
            {
                new Mp3Players(true, true, "Sony", "Walkman-X", 250, 2),
                new Mp3Players(false, true, "Philips", "GoGear", 200, 5)
            };

            var mp4s = new Product[]
            {
                new Mp4Players(true, true, 4.3, "Apple", "iPod Touch", 450, 1),
                new Mp4Players(false, false, 3.5, "Samsung", "Galaxy Play", 300, 6)
            };

            var headphones = new Product[]
            {
                new WirelessHeadphones("10m", "JBL", "Tune 500BT", 120, 4),
                new WirelessHeadphones("8m", "Sony", "WH-CH510", 100, 2)
            };

            return (mp3s, mp4s, headphones);
        }

        /// <summary>
        /// Adds all product arrays to the given store.
        /// Добавляет все массивы товаров в переданный магазин.
        /// </summary>
        static void AddProductsToStore(Store store, Product[] mp3s, Product[] mp4s, Product[] headphones)
        {
            foreach (var p in mp3s)
                store.AddMp3((Mp3Players)p);

            foreach (var p in mp4s)
                store.AddMp4((Mp4Players)p);

            foreach (var p in headphones)
                store.AddWireless((WirelessHeadphones)p);
        }

        /// <summary>
        /// Displays a list of products to the console.
        /// Отображает список товаров в консоли.
        /// </summary>
        static void PrintProductList(params Product[] products)
        {
            PrintSectionHeader("PRODUCT LIST:");
            foreach (var product in products)
            {
                if (product != null)
                    Console.WriteLine(product);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Displays total stock value and low-stock models.
        /// Показывает общую стоимость и модели с низким запасом.
        /// </summary>
        static void PrintDisplayTotals(Network network)
        {
            // Print total inventory value / Печать общей стоимости
            PrintSectionHeader("Total stock value in network:");
            Console.WriteLine(network.GetTotalQTY());
            Console.WriteLine();

            // Print models below stock threshold / Печать моделей с низким запасом
            var lowStockModels = network.GetLowStockModels();
            PrintSectionHeader("LOW-STOCK ITEMS:");
            Console.WriteLine(string.IsNullOrWhiteSpace(lowStockModels)
                ? "All items are sufficiently stocked." // Все товары в наличии
                : lowStockModels);
            Console.WriteLine();
        }

        /// <summary>
        /// Prints a colored section header.
        /// Печатает цветной заголовок раздела.
        /// </summary>
        static void PrintSectionHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(title);
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
