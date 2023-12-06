namespace Capstone.Models
{
    public class Card
    {
        public int cardId { get; set; }
        public int deckId { get; set; }
        public string term { get; set; }
        public string definition { get; set; }
        public int userId { get; set; }
    }
}
