using System;
using System.Collections.Generic;
using System.Linq;

namespace AudioNetworkStoreNet6
{
    /// <summary>
    /// Represents a network of stores.
    /// Представляет сеть магазинов.
    /// </summary>
    public class Network
    {
        /// <summary>
        /// Global quantity threshold (not used in current implementation).
        /// Глобальный лимит количества (не используется в текущей реализации).
        /// </summary>
        public static int Qty { get; set; }

        /// <summary>
        /// Minimum allowed quantity before items are considered low-stock.
        /// Минимальное допустимое количество перед тем, как товар считается дефицитным.
        /// </summary>
        public static int MinQty { get; set; }

        /// <summary>
        /// List of all stores in the network.
        /// Список всех магазинов в сети.
        /// </summary>
        private readonly List<Store> _stores = new();

        /// <summary>
        /// Adds a new store to the network.
        /// Добавляет новый магазин в сеть.
        /// </summary>
        /// <param name="store">Store instance / Экземпляр магазина</param>
        public void AddStore(Store store)
        {
            if (store == null)
                throw new ArgumentNullException(nameof(store), "Store cannot be null."); // Проверка на null

            _stores.Add(store);
        }

        /// <summary>
        /// Calculates total inventory value across all stores.
        /// Вычисляет общую стоимость запасов по всем магазинам.
        /// </summary>
        /// <returns>Total inventory value / Общая стоимость запасов</returns>
        public int GetTotalQTY() => _stores.Sum(s => s.GetTotalQTY());

        /// <summary>
        /// Gets a list of all low-stock models from all stores.
        /// Возвращает список моделей с низким остатком со всех магазинов.
        /// </summary>
        /// <returns>Formatted string of low-stock model names / Форматированная строка с названиями моделей</returns>
        public string GetLowStockModels()
        {
            return string.Join(
                "\n",
                _stores
                    .Select(s => s.GetLowStockModels())
                    .Where(m => !string.IsNullOrWhiteSpace(m))
            );
        }
    }
}
