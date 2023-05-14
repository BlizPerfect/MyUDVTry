using System.Text;

namespace MyUDVTry
{
    public static class CardDeckStorage
    {
        public const int DeckSize = 52;
        public const int AmountOfSuits = 4;
        public const int LowestRank = 2;
        public const int HighestRank = 15;

        public static Dictionary<string, CardDeck> CardDecks = new Dictionary<string, CardDeck>();

        /// <summary>
        /// Проверка существования колоды с именем <see cref="name"/>.
        /// </summary>
        /// <param name="name">Имя проверяемой колоды</param>
        /// <returns>true в случае существования колоды с именем <see cref="name"/>, иначе false </returns>
        public static bool IsDeckExist(string name) => CardDecks.ContainsKey(name);

        /// <summary>
        /// Проверка отсутствия какой-либо колоды.
        /// </summary>
        /// <returns>true в случае существования какой-либо колоды, иначе false </returns>
        public static bool IsEmpty() => CardDecks.Count == 0;

        /// <summary>
        /// Создание упорядоченной колоды с именем <see cref="name"/>.
        /// </summary>
        /// <param name="name">Имя создаваемой колоды</param>
        public static void CreateNewCardDeck(string cardDeckName)
        {
            CardDecks.Add(cardDeckName, new CardDeck(cardDeckName));
        }

        /// <summary>
        /// Удаление колоды с именем <see cref="name"/>.
        /// </summary>
        /// <param name="name">Имя удаляемой колоды колоды</param>
        public static void DeleteDeck(string deckName)
        {
            CardDecks.Remove(deckName);
        }

        /// <summary>
        /// Получение списка имён всех колод.
        /// </summary>
        /// <returns>Список имён всех существующих колод</returns>
        public static string GetAllDeckNames()
        {
            var result = new StringBuilder();
            result.AppendLine("Deck List:");
            var index = 0;
            foreach (var deckName in CardDecks.Keys)
            {
                result.AppendLine(string.Format("{0}: {1}", index, deckName));
                index += 1;
            }
            return result.ToString();
        }

        /// <summary>
        /// Перемешивание колоды с именем <see cref="name"/>.
        /// </summary>
        /// <param name="name">Имя перемешиваемой колоды</param>
        /// <param name="sortType">Тип перетасовки, получаемый из конфигурации приложения</param>
        /// <returns>Результат выполнения запроса</returns>
        public static void ShuffleDeck(string deckName, string sortType)
        {
            var cardDeck = CardDecks[deckName];
            cardDeck.Shuffle(sortType);
        }

        /// <summary>
        /// Получение колоды с именем <see cref="name"/>.
        /// </summary>
        /// <param name="name">Имя получаемой колоды</param>
        /// <returns>Получение состояния колоды</returns>
        public static string GetDeck(string deckName)
        {
            return CardDecks[deckName].ToString();
        }
    }
}
