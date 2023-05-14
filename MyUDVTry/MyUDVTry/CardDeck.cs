using System.Text;
using System.Xml.Linq;

namespace MyUDVTry
{
    public class CardDeck
    {
        public Card[] Cards { get; private set; }

        public string Name { get; private set; }

        public CardDeck(string name)
        {
            Name = name;
            CreateCardDeck();
        }

        /// <summary>
        /// Создание упорядоченной колоды.
        /// </summary>
        private void CreateCardDeck()
        {
            Cards = new Card[CardDeckStorage.DeckSize];
            var index = 0;
            for (int suitId = 0; suitId < CardDeckStorage.AmountOfSuits; suitId++)
            {
                for (int rank = CardDeckStorage.LowestRank; rank < CardDeckStorage.HighestRank; rank++)
                {
                    Cards[index] = new Card(suitId, rank);
                    index += 1;
                }
            }
        }

        /// <summary>
        /// Перемешивание колоды с помощью алгоритма перемешивания <see cref="sortType"/>.
        /// В случае неизвестного <see cref="sortType"/> колода остаётся неизменной.
        /// </summary>
        /// <param name="sortType">Тип перетасовки, получаемый из конфигурации приложения</param>
        public void Shuffle(string sortType)
        {
            if (sortType.Equals("Simple", StringComparison.OrdinalIgnoreCase))
            {
                SimpleShuffle();
            }
            if (sortType.Equals("ByHand", StringComparison.OrdinalIgnoreCase))
            {
                ByHandShuffle();
            }
        }

        /// <summary>
        /// Простое перемешивание колоды.
        /// </summary>
        private void SimpleShuffle()
        {
            var random = new Random();
            Cards = Cards.OrderBy(x => random.Next()).ToArray();
        }

        /// <summary>
        /// Перемешивание колоды рукам. Не реализовано,
        /// но добавлено для показания того,
        /// что алгоритм перемешивания колоды из конфигурации приложения считывается.
        /// </summary>
        private void ByHandShuffle()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var card in Cards)
            {
                result.AppendLine(card.ToString());
            }
            return result.ToString();
        }
    }
}
