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
        /// �������� ������������� ������ � ������ <see cref="name"/>.
        /// </summary>
        /// <param name="name">��� ����������� ������</param>
        /// <returns>��������� ���������� �������</returns>
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
        /// �������� ������ � ������ <see cref="name"/>.
        /// </summary>
        /// <param name="name">��� ��������� ������ ������</param>
        /// <returns>��������� ���������� �������</returns>
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
        /// ��������� ������ ��� ���� �����.
        /// </summary>
        /// <returns>��������� ���������� �������</returns>
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
        /// ������������� ������ � ������ <see cref="name"/>.
        /// </summary>
        /// <param name="name">��� �������������� ������</param>
        /// <returns>��������� ���������� �������</returns>
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
        /// ��������� ������ � ������ <see cref="name"/>.
        /// </summary>
        /// <param name="name">��� ���������� ������</param>
        /// <returns>��������� ���������� �������</returns>
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