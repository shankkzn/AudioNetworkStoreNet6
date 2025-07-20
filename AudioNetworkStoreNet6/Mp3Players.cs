using System;

namespace AudioNetworkStoreNet6
{
    /// <summary>
    /// Represents an MP3 player product.
    /// Представляет товар — MP3-плеер.
    /// </summary>
    public class Mp3Players : Product
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
        /// Initializes a new instance of the Mp3Players class.
        /// Инициализирует новый экземпляр класса Mp3Players.
        /// </summary>
        /// <param name="radio">Has built-in radio / Наличие встроенного радио</param>
        /// <param name="internalSpeaker">Has internal speaker / Наличие встроенного динамика</param>
        /// <param name="manufacture">Manufacturer name / Название производителя</param>
        /// <param name="model">Model name / Модель</param>
        /// <param name="price">Unit price / Цена</param>
        /// <param name="qty">Quantity in stock / Количество на складе</param>
        public Mp3Players(bool radio, bool internalSpeaker, string manufacture, string model, int price, int qty)
            : base(manufacture, model, price, qty)
        {
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
        /// Returns string representation of the MP3 player.
        /// Возвращает строковое представление MP3-плеера.
        /// </summary>
        public override string ToString()
        {
            return $"{base.ToString()} | Radio: {(_radio ? "Yes" : "No")}, Speaker: {(_internalSpeaker ? "Yes" : "No")}";
        }
    }
}
