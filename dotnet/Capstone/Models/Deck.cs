namespace Capstone.Models
{
    public class Deck
    {
        public int deckId { get; set; }
        public int userId { get; set; }
        public string deckTitle { get; set; }
        public string deckTags { get; set; }
        public string deckDesc { get; set; }
    }
}
