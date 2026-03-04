using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySqlConnector;
using AppNuvem.Models;
using Xamarin.Forms;

namespace AppNuvem.Controller
{
    public class MySQLCon
    {
        static string conn = @"
            server=sql.freedb.tech;
            port=3306;
            database=freedb_senai_db;
            user id=freedb_dj_userdb;
            password=GCqj7dqW8uqXKz!;
            charset=utf8;";

        public static MySqlConnection GetConnection()
        {
            MySqlConnection con = new MySqlConnection(conn);
            return con;
        }

        public static List<Pessoa> ListaClientes()
        {
            MySqlConnection conn = GetConnection();
            List<Pessoa> li = new List<Pessoa>();
            string sql = "SELECT * FROM clientes";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Pessoa p = new Pessoa();
                    p.id = reader.GetInt32("id");
                    p.nome = reader.GetString("nome");
                    p.celular = reader.GetString("celular");
                    p.datanasc = reader.GetDateTime("datanasc");
                    p.genero = reader.GetString("genero");
                    li.Add(p);
                }
                
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Erro", $"Ocorreu um erro ao buscar os clientes: {ex.Message}", "OK");
            }
            finally { conn.Close(); }
			return li;
		}

        public static void CriarCliente(Pessoa cliente)
        {
            MySqlConnection con = GetConnection();
            string sql = "INSERT INTO clientes (nome, celular, datanasc, genero) VALUES(@nome, @celular, @datanac, @genero)";
            MySqlCommand cmd = new MySqlCommand( sql, con);
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@nome", cliente.nome);
                cmd.Parameters.AddWithValue("celular", cliente.celular);
                cmd.Parameters.AddWithValue("datanas", cliente.datanasc.Date);
                cmd.Parameters.AddWithValue("genero", cliente.genero);

                cmd.ExecuteNonQuery();
                
            }
            catch (MySqlException sqlError)
            {
				Application.Current.MainPage.DisplayAlert("Erro", $"Erro do SQL: {sqlError.Message}", "OK");
			}
            catch(Exception ex)
            {
				Application.Current.MainPage.DisplayAlert("Erro", $"Ocorreu um erro ao inserir o cliente {cliente.nome}: {ex.Message}", "OK");
			}
            finally { con.Close(); }
		}

		public static void ExcluirCliente(Pessoa cliente)
		{
			MySqlConnection con = GetConnection();
			string sql = "DELETE FROM clientes WHERE id = @id";
			MySqlCommand cmd = new MySqlCommand(sql, con);
			try
			{
				con.Open();
				cmd.Parameters.AddWithValue("@id", cliente.id);
				

				cmd.ExecuteNonQuery();

			}
			catch (MySqlException sqlError)
			{
				Application.Current.MainPage.DisplayAlert("Erro", $"Erro do SQL: {sqlError.Message}", "OK");
			}
			catch (Exception ex)
			{
				Application.Current.MainPage.DisplayAlert("Erro", $"Ocorreu um erro ao excluir o cliente {cliente.nome}: {ex.Message}", "OK");
			}
			finally { con.Close(); }
		}

		public static void AtualizarPessoa(Pessoa cliente)
		{
			MySqlConnection con = GetConnection();
			string sql = "UPDATE FROM clientes SET nome=@nome, celular=@celular, datanasc=@datanasc, genero=@genero WHERE id = @id";
			MySqlCommand cmd = new MySqlCommand(sql, con);
			try
			{
				con.Open();
				cmd.Parameters.AddWithValue("@id", cliente.id);
				cmd.Parameters.AddWithValue("@nome", cliente.nome);
				cmd.Parameters.AddWithValue("@celular", cliente.celular);
				cmd.Parameters.AddWithValue("@datanasc", cliente.datanasc);
				cmd.Parameters.AddWithValue("@genero", cliente.genero);


				cmd.ExecuteNonQuery();

			}
			catch (MySqlException sqlError)
			{
				Application.Current.MainPage.DisplayAlert("Erro", $"Erro do SQL: {sqlError.Message}", "OK");
			}
			catch (Exception ex)
			{
				Application.Current.MainPage.DisplayAlert("Erro", $"Ocorreu um erro ao excluir o cliente {cliente.nome}: {ex.Message}", "OK");
			}
			finally { con.Close(); }
		}
	}
}
