namespace MyUDVTry
{
    public class Card
    {
        public enum Suits
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        }

        public enum Ranks
        {
            Two = 2,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace
        }

        private static readonly Dictionary<Suits, string> VisualSuitsReprisentation = new Dictionary<Suits, string>()
        {
            {Suits.Clubs,"♣" },
            {Suits.Diamonds,"♦" },
            {Suits.Hearts,"♥" },
            {Suits.Spades,"♠" },
        };

        public Suits Suit { get; private set; }
        public string VisualSuit { get; private set; }
        public Ranks Rank { get; private set; }


        public Card(int suit, int rank)
        {
            Suit = (Suits)suit;
            VisualSuit = VisualSuitsReprisentation[Suit];
            Rank = (Ranks)rank;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", Rank, VisualSuit);
        }


    }
}
