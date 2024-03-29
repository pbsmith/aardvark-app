﻿using Capstone.DAO.Interface;
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

        public Deck GetDeckById(int deckId)
        {
            Deck deck = new Deck();

            string sql = "SELECT user_id, deck_id, deck_tags, deck_title, deck_desc FROM decks WHERE deck_id = @deck_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@deck_id", deckId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        deck = MapRowToDeck(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return deck;
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

        public Deck CreateDeck(Deck deck)
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

        public Deck UpdateDeck(Deck deck)
        {
            string SqlUpdateDeck = "UPDATE decks SET deck_title=@deck_title, deck_tags=@deck_tags, " +
            "deck_desc=@deck_desc " +
            "WHERE deck_id = @deck_id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlUpdateDeck, conn))
                {
                    cmd.Parameters.AddWithValue("@deck_title", deck.deckTitle);
                    cmd.Parameters.AddWithValue("@deck_tags", deck.deckTags);
                    cmd.Parameters.AddWithValue("@deck_desc", deck.deckDesc);
                    cmd.Parameters.AddWithValue("@deck_id", deck.deckId);

                    int count = cmd.ExecuteNonQuery();
                    if (count == 1)
                    {
                        return deck;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
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
