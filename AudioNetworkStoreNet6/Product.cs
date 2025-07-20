using System;

namespace AudioNetworkStoreNet6
{
    /// <summary>
    /// Base class for all audio products.
    /// Базовый класс для всех аудиопродуктов.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Manufacturer name.
        /// Название производителя.
        /// </summary>
        public string Manufacture { get; init; }

        /// <summary>
        /// Model name.
        /// Название модели.
        /// </summary>
        public string Model { get; init; }

        /// <summary>
        /// Product price in USD.
        /// Цена товара в долларах США.
        /// </summary>
        public int Price { get; init; }

        /// <summary>
        /// Quantity of items in stock.
        /// Количество единиц на складе.
        /// </summary>
        public int QTY { get; set; }

        /// <summary>
        /// Constructor to initialize product information.
        /// Конструктор для инициализации информации о товаре.
        /// </summary>
        /// <param name="manufacture">Manufacturer name / Название производителя</param>
        /// <param name="model">Model name / Название модели</param>
        /// <param name="price">Price in USD / Цена в долларах</param>
        /// <param name="qty">Stock quantity / Количество на складе</param>
        public Product(string manufacture, string model, int price, int qty)
        {
            Manufacture = manufacture ?? throw new ArgumentNullException(nameof(manufacture), "Manufacturer cannot be null.");
            Model = model ?? throw new ArgumentNullException(nameof(model), "Model cannot be null.");
            Price = price >= 0 ? price : throw new ArgumentOutOfRangeException(nameof(price), "Price must be non-negative.");
            QTY = qty >= 0 ? qty : throw new ArgumentOutOfRangeException(nameof(qty), "Quantity must be non-negative.");
        }

        /// <summary>
        /// Returns a string representation of the product.
        /// Возвращает строковое представление товара.
        /// </summary>
        /// <returns>Formatted product info / Форматированная информация о товаре</returns>
        public override string ToString()
        {
            return $"{Manufacture} {Model} ({QTY} pcs, ${Price})";
        }
    }
}
