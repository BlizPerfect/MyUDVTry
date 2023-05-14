using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace MyUDVTry.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardDeckStorageController : ControllerBase
    {
        private string SortType = string.Empty;
        public CardDeckStorageController(IConfiguration configuration)
        {
            SortType = configuration["SortType"];
        }

        /// <summary>
        /// Создание упорядоченной колоды с именем <see cref="name"/>.
        /// </summary>
        /// <param name="name">Имя создаваемой колоды</param>
        /// <returns>Результат выполнения запроса</returns>
        [HttpPost, Route("CreateDeck/{name}")]
        public string CreateDecks(string name)
        {
            if (CardDeckStorage.IsDeckExist(name))
            {
                return string.Format("Deck with the name \"{0}\" already exists.", name);
            }

            CardDeckStorage.CreateNewCardDeck(name);
            return string.Format("Deck with the name \"{0}\" has been successfully created.", name);
        }

        /// <summary>
        /// Удаление колоды с именем <see cref="name"/>.
        /// </summary>
        /// <param name="name">Имя удаляемой колоды колоды</param>
        /// <returns>Результат выполнения запроса</returns>
        [HttpDelete, Route("DeleteDeck/{name}")]
        public string DeleteDeck(string name)
        {
            if (!CardDeckStorage.IsDeckExist(name))
            {
                return string.Format("Deck with the name \"{0}\" does not exist.", name);
            }

            CardDeckStorage.DeleteDeck(name);
            return string.Format("Deck with the name \"{0}\" has been successfully deleted.", name);
        }

        /// <summary>
        /// Получение списка имён всех колод.
        /// </summary>
        /// <returns>Результат выполнения запроса</returns>
        [HttpGet, Route("GetAllDeckNames")]
        public string GetAllDeckNames()
        {
            if (CardDeckStorage.IsEmpty())
            {
                return "There are no decks.";
            }

            return CardDeckStorage.GetAllDeckNames();
        }

        /// <summary>
        /// Перемешивание колоды с именем <see cref="name"/>.
        /// </summary>
        /// <param name="name">Имя перемешиваемой колоды</param>
        /// <returns>Результат выполнения запроса</returns>
        [HttpPut, Route("ShuffleDeck/{name}")]
        public string ShuffleDeck(string name)
        {
            if (!CardDeckStorage.IsDeckExist(name))
            {
                return string.Format("Deck with the name \"{0}\" does not exist.", name);
            }

            CardDeckStorage.ShuffleDeck(name, SortType);
            return string.Format("Deck with the name \"{0}\" has been successfully shuffled.", name);
        }

        /// <summary>
        /// Получение колоды с именем <see cref="name"/>.
        /// </summary>
        /// <param name="name">Имя получаемой колоды</param>
        /// <returns>Результат выполнения запроса</returns>
        [HttpGet, Route("GetDeck/{name}")]
        public string GetDeck(string name)
        {
            if (!CardDeckStorage.IsDeckExist(name))
            {
                return string.Format("Deck with the name \"{0}\" does not exist.", name);
            }

            return CardDeckStorage.GetDeck(name);
        }

    }
}