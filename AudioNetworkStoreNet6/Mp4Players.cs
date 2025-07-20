using System;

namespace AudioNetworkStoreNet6
{
    /// <summary>
    /// Represents an MP4 player product.
    /// Представляет товар — MP4-плеер.
    /// </summary>
    public class Mp4Players : Product
    {
        /// <summary>
        /// Indicates whether the player has a built-in radio.
        /// Показывает, есть ли у плеера встроенное радио.
        /// </summary>
        private readonly bool _radio;

        /// <summary>
        /// Indicates whether the player has an internal speaker.
        /// Показывает, есть ли у плеера встроенный динамик.
        /// </summary>
        private readonly bool _internalSpeaker;

        /// <summary>
        /// Length of the screen in inches.
        /// Размер экрана в дюймах.
        /// </summary>
        private readonly double _screenLength;

        /// <summary>
        /// Initializes a new instance of the Mp4Players class.
        /// Инициализирует новый экземпляр класса Mp4Players.
        /// </summary>
        /// <param name="radio">Has built-in radio / Наличие встроенного радио</param>
        /// <param name="internalSpeaker">Has internal speaker / Наличие встроенного динамика</param>
        /// <param name="screenLength">Screen size in inches / Размер экрана в дюймах</param>
        /// <param name="manufacture">Manufacturer name / Название производителя</param>
        /// <param name="model">Model name / Название модели</param>
        /// <param name="price">Unit price / Цена</param>
        /// <param name="qty">Quantity in stock / Количество на складе</param>
        public Mp4Players(bool radio, bool internalSpeaker, double screenLength, string manufacture, string model, int price, int qty)
            : base(manufacture, model, price, qty)
        {
            // Ensure screen length is not negative
            // Проверка, что размер экрана неотрицателен
            _screenLength = screenLength >= 0
                ? screenLength
                : throw new ArgumentOutOfRangeException(nameof(screenLength), "Screen length must be non-negative.");
            _radio = radio;
            _internalSpeaker = internalSpeaker;
        }

        /// <summary>
        /// Returns true if the player has radio.
        /// Возвращает true, если есть радио.
        /// </summary>
        public bool HasRadio() => _radio;

        /// <summary>
        /// Returns true if the player has internal speaker.
        /// Возвращает true, если есть встроенный динамик.
        /// </summary>
        public bool HasInternalSpeaker() => _internalSpeaker;

        /// <summary>
        /// Returns screen length in inches.
        /// Возвращает размер экрана в дюймах.
        /// </summary>
        public double GetScreenLength() => _screenLength;

        /// <summary>
        /// Returns string representation of the MP4 player.
        /// Возвращает строковое представление MP4-плеера.
        /// </summary>
        public override string ToString()
        {
            return $"{base.ToString()} | Radio: {(_radio ? "Yes" : "No")}, Speaker: {(_internalSpeaker ? "Yes" : "No")}, Screen: {_screenLength:0.0}\"";
        }
    }
}
