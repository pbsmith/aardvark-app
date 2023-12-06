using Capstone.DAO.Interface;
using Capstone.Exceptions;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO

{
    public class CardSqlDao : ICardDao
    {
        private readonly string connectionString;

        public CardSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Card createCard(Card card)
        {

            string sql = "INSERT INTO cards (term, definition, deck_id, user_id) " +
                "OUTPUT INSERTED.card_id " +
                "VALUES (@term, @definition, @deck_id, @user_id)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@term", card.term);
                        cmd.Parameters.AddWithValue("@definition", card.definition);
                        cmd.Parameters.AddWithValue("@deck_id", card.deckId);
                        cmd.Parameters.AddWithValue("@user_id", card.userId);

                        card.cardId = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return card;

        }

    }
}
