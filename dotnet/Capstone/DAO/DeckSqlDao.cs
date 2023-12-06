using Capstone.DAO.Interface;
using Capstone.Exceptions;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class DeckSqlDao : IDeckDao
    {
        private readonly string connectionString;


        public DeckSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Deck> GetDecks()
        {
            List<Deck> decks = new List<Deck>();

            string sql = "SELECT user_id, deck_id, deck_tags, deck_title, deck_desc FROM decks";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Deck deck = MapRowToDeck(reader);
                        decks.Add(deck);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return decks;
        }

        public Deck createDeck(Deck deck)
        {
            string sql = "INSERT INTO decks (deck_title, deck_tags, deck_desc, user_id) " +
                "OUTPUT INSERTED.deck_id " +
                "VALUES (@deck_title, @deck_tags, @deck_desc, @user_id)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@deck_title", deck.deckTitle);
                        cmd.Parameters.AddWithValue("@deck_tags", deck.deckTags);
                        cmd.Parameters.AddWithValue("@deck_desc", deck.deckDesc);
                        cmd.Parameters.AddWithValue("@user_id", deck.userId);

                        deck.deckId = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return deck;
        }

        private Deck MapRowToDeck(SqlDataReader reader)
        {
            Deck deck = new Deck();
            deck.userId = Convert.ToInt32(reader["user_id"]);
            deck.deckTitle = Convert.ToString(reader["deck_title"]);
            deck.deckDesc = Convert.ToString(reader["deck_desc"]);
            deck.deckId = Convert.ToInt32(reader["deck_id"]);
            deck.deckTags = Convert.ToString(reader["deck_tags"]);
            return deck;
        }
    }
}
