using System;
using System.Collections.Generic;
using System.Linq;

namespace AudioNetworkStoreNet6
{
    /// <summary>
    /// Represents a single physical store containing audio products.
    /// Представляет отдельный физический магазин с аудиотоварами.
    /// </summary>
    public class Store
    {
        /// <summary>
        /// Shared quantity value (optional logic).
        /// Общая величина количества (опциональная логика).
        /// </summary>
        public static int Qty { get; set; }

        /// <summary>
        /// Minimum stock threshold for identifying low-stock items.
        /// Минимальный порог запаса для определения дефицита.
        /// </summary>
        public static int MinQty { get; set; }

        // Internal lists to store products by type
        // Внутренние списки для хранения товаров по типам
        private readonly List<Mp3Players> _mp3 = new();
        private readonly List<Mp4Players> _mp4 = new();
        private readonly List<WirelessHeadphones> _wireless = new();

        /// <summary>
        /// Adds an MP3 player to the store.
        /// Добавляет MP3-плеер в магазин.
        /// </summary>
        public void AddMp3(Mp3Players player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));
            _mp3.Add(player);
        }

        /// <summary>
        /// Adds an MP4 player to the store.
        /// Добавляет MP4-плеер в магазин.
        /// </summary>
        public void AddMp4(Mp4Players player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));
            _mp4.Add(player);
        }

        /// <summary>
        /// Adds wireless headphones to the store.
        /// Добавляет беспроводные наушники в магазин.
        /// </summary>
        public void AddWireless(WirelessHeadphones headphones)
        {
            if (headphones == null)
                throw new ArgumentNullException(nameof(headphones));
            _wireless.Add(headphones);
        }

        /// <summary>
        /// Calculates the total value of all products in stock.
        /// Вычисляет общую стоимость всех товаров на складе.
        /// </summary>
        /// <returns>Total inventory value / Общая стоимость запасов</returns>
        public int GetTotalQTY()
        {
            return _mp3.Sum(p => p.Price * p.QTY)
                 + _mp4.Sum(p => p.Price * p.QTY)
                 + _wireless.Sum(p => p.Price * p.QTY);
        }

        /// <summary>
        /// Returns a list of product models that are below the minimum stock threshold.
        /// Возвращает список моделей товаров с количеством ниже минимального порога.
        /// </summary>
        /// <returns>String with models below MinQty / Строка с моделями ниже MinQty</returns>
        public string GetLowStockModels()
        {
            var lowStock = new List<string>();

            // MP3 products with low stock / Товары MP3 с низким запасом
            lowStock.AddRange(_mp3.Where(p => p.QTY < MinQty).Select(p => p.Model));

            // MP4 products with low stock / Товары MP4 с низким запасом
            lowStock.AddRange(_mp4.Where(p => p.QTY < MinQty).Select(p => p.Model));

            // Wireless products with low stock / Беспроводные устройства с низким запасом
            lowStock.AddRange(_wireless.Where(p => p.QTY < MinQty).Select(p => p.Model));

            return string.Join("\n", lowStock);
        }

        /// <summary>
        /// Returns all products in the store as a single enumerable list.
        /// Возвращает все товары магазина как единый перечисляемый список.
        /// </summary>
        /// <returns>All products in store / Все товары в магазине</returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return _mp3.Cast<Product>()
                       .Concat(_mp4)
                       .Concat(_wireless);
        }
    }
}
