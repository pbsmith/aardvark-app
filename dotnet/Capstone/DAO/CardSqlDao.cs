using Capstone.DAO.Interface;
using Capstone.Exceptions;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace Capstone.DAO

{
    public class CardSqlDao : ICardDao
    {
        private readonly string connectionString;

        public CardSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Card> GetCardsByDeckId(int deckId)
        {
            List<Card> cards = new List<Card>();

            string sql = "SELECT card_id, deck_id, term, definition, user_id " +
                "FROM cards WHERE deck_id = @deck_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@deck_id", deckId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Card card = new Card();
                        card = MapRowToCard(reader);
                        cards.Add(card);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return cards;
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

        private Card MapRowToCard(SqlDataReader reader)
        {
            Card card = new Card();
            card.cardId = Convert.ToInt32(reader["card_id"]);
            card.deckId = Convert.ToInt32(reader["deck_id"]);
            card.term = Convert.ToString(reader["term"]);
            card.definition = Convert.ToString(reader["definition"]);
            card.userId = Convert.ToInt32(reader["user_id"]);
            return card;
        }

    }
}
