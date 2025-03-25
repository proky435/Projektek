using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace feleltetogep
{
    internal class dbconect
    {
        private MySqlConnection conn;

        public dbconect(string host, string dbname, string uid, string pw)
        {
            conn = new MySqlConnection(connectionString: $"Database = {dbname}; Data Source = {host}; User ID = {uid}; Password = {pw}");
        }

        private bool Connect()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ConnectClose()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void InstertData(sqlOsztalyok temp)
        {
            if (Connect())
            {
                string query = "INSERT INTO Osztalyok(OsztalyNeve) VALUES(@osztNev)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue(parameterName: "@osztNev", temp.osztNev);
                cmd.ExecuteNonQuery();
                ConnectClose();
            }
        }

        public void InstertDataTanulok(sqlTanulok temp)
        {
            if (Connect())
            {
                string query = "INSERT INTO Tanulok(TanuloNeve,OsztalyId) VALUES(@tnev,@OsztID)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue(parameterName: "@tnev", temp.tnev);
                cmd.Parameters.AddWithValue(parameterName: "@OsztID", temp.OsztID);
                cmd.ExecuteNonQuery();
                ConnectClose();
            }
        }

        public void InstertDataFelelt(sqlFeleltek temp)
        {
            if (Connect())
            {
                string query = "INSERT INTO Felelok(TanuloId) VALUES(@felelt)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue(parameterName: "@felelt", temp.felelt);
                cmd.ExecuteNonQuery();
                ConnectClose();
            }
        }

        public void InsertIntoOsztalyzatok(int Tanid, int jegy)
        {
            if (Connect())
            {
                string query = "INSERT INTO Osztalyzatok(TanuloId,Osztalyzat) VALUES(@Tanid,@jegy)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue(parameterName: "@Tanid", Tanid);
                cmd.Parameters.AddWithValue(parameterName: "@jegy", jegy);
                cmd.ExecuteNonQuery();
                ConnectClose();
            }
        }
        public void DeleteFelelo(int Tanid)
        {
            if (Connect())
            {
                string query = "DELETE FROM Felelok WHERE TanuloId = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue(parameterName: "@id", Tanid);
                cmd.ExecuteNonQuery();
                ConnectClose();
            }
        }
        public void DeleteFelelok()
        {
            if (Connect())
            {
                string query = "DELETE FROM Felelok";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                ConnectClose();
            }
        }

        public List<sqlOsztalyok> selectAllOsztalyok()
        {
            List<sqlOsztalyok> list = new List<sqlOsztalyok>();
            if (Connect())
            {
                string query = "SELECT OsztalyId,OsztalyNeve FROM Osztalyok;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new sqlOsztalyok(reader.GetInt32(0), reader.GetString(1)));
                }
                ConnectClose();
            }
            return list;
        }
        public List<sqlFeleltek> selectAllFeleltek()
        {
            List<sqlFeleltek> list = new List<sqlFeleltek>();
            if (Connect())
            {
                string query = "SELECT TanuloId FROM Felelok;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new sqlFeleltek(reader.GetInt32(0)));
                }
                ConnectClose();
            }
            return list;
        }

        public List<sqlOsztalyok> selectOsztID()
        {
            List<sqlOsztalyok> list = new List<sqlOsztalyok>();
            if (Connect())
            {
                string query = "SELECT OsztalyId FROM Osztalyok;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new sqlOsztalyok(reader.GetInt32(0), reader.GetString(1)));
                }
                ConnectClose();
            }
            return list;
        }

        public List<sqlTanulok> selectAllTanulok()
        {
            List<sqlTanulok> list = new List<sqlTanulok>();
            if (Connect())
            {
                string query = "SELECT Tanulok.TanuloId,Tanulok.TanuloNeve AS tnev, Tanulok.OsztalyId AS Osztály FROM Tanulok INNER JOIN Osztalyok ON Tanulok.OsztalyId = Osztalyok.OsztalyId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new sqlTanulok(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                }
                ConnectClose();
            }
            return list;
        }

        public List<jegyekLekérdez> selectJegyek()
        {
            List<jegyekLekérdez> list = new List<jegyekLekérdez>();
            if (Connect())
            {
                string query = "SELECT Osztalyzatok.Osztalyzat,Tanulok.TanuloNeve,Osztalyok.OsztalyNeve FROM Osztalyzatok INNER JOIN Tanulok ON Tanulok.TanuloId = Osztalyzatok.TanuloId INNER JOIN Osztalyok ON Tanulok.OsztalyId = Osztalyok.TanuloId;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new jegyekLekérdez(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
                ConnectClose();
            }
            return list;
        }
        public List<tanuloJegyek> selectAllTanuloJegyek()
        {
            List<tanuloJegyek> list = new List<tanuloJegyek>();
            if (Connect())
            {
                string query = "SELECT Tanulok.TanuloId,Tanulok.TanuloNeve AS tnev,Tanulok.OsztalyId AS Osztály, Osztalyzatok.Osztalyzat AS Érdemjegy FROM Tanulok INNER JOIN Osztalyok ON Tanulok.OsztalyId = Osztalyok.OsztalyId INNER JOIN Osztalyzatok ON Tanulok.TanuloId = Osztalyzatok.TanuloId ORDER BY Tanulok.TanuloNeve ASC";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new tanuloJegyek(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3)));
                }
                ConnectClose();
            }
            return list;
        }
    }
}
