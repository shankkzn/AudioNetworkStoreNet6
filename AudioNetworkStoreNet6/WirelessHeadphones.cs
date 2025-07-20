using System;

namespace AudioNetworkStoreNet6
{
    /// <summary>
    /// Represents a wireless headphone product.
    /// Представляет товар — беспроводные наушники.
    /// </summary>
    public class WirelessHeadphones : Product
    {
        /// <summary>
        /// Reception range of the headphones (e.g., "10m").
        /// Радиус приёма наушников (например, "10m").
        /// </summary>
        private readonly string _receptionRange;

        /// <summary>
        /// Initializes a new instance of the WirelessHeadphones class.
        /// Инициализирует новый экземпляр класса WirelessHeadphones.
        /// </summary>
        /// <param name="receptionRange">Reception range / Радиус действия</param>
        /// <param name="manufacture">Manufacturer name / Название производителя</param>
        /// <param name="model">Model name / Название модели</param>
        /// <param name="price">Unit price / Цена</param>
        /// <param name="qty">Quantity in stock / Количество на складе</param>
        public WirelessHeadphones(string receptionRange, string manufacture, string model, int price, int qty)
            : base(manufacture, model, price, qty)
        {
            // Ensure reception range is not null or whitespace
            // Проверка, что радиус действия не пустой
            _receptionRange = !string.IsNullOrWhiteSpace(receptionRange)
                ? receptionRange
                : throw new ArgumentException("Reception range cannot be empty.", nameof(receptionRange));
        }

        /// <summary>
        /// Gets the reception range of the headphones.
        /// Получает радиус действия наушников.
        /// </summary>
        public string GetReceptionRange() => _receptionRange;

        /// <summary>
        /// Returns string representation of the wireless headphones.
        /// Возвращает строковое представление беспроводных наушников.
        /// </summary>
        public override string ToString()
        {
            return $"{base.ToString()} | Range: {_receptionRange}";
        }
    }
}
