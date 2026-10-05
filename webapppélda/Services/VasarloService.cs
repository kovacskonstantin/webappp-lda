using MySql.Data.MySqlClient;
using webapppélda.Models;

namespace WebAppPelda.Services
{
    public class VasarloService
    {
        public string PostCustomer(Customer customer)
        {
            try { 
            string connectionString = "SERVER = localhost;" +
                          "DATABASE= webapppeldadb;" +
                          "UID = root;" +
                          "PASSWORD =;";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            string sql = "INSERT INTO vasarlo(Nev, Cim, Email, Telefon, Pontszam) Values(@nev,@cim,@email,@telefon,@pontszam)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nev", (customer as Customer).Nev);
            cmd.Parameters.AddWithValue("@cim", (customer as Customer).Cim);
            cmd.Parameters.AddWithValue("@email", (customer as Customer).Email);
            cmd.Parameters.AddWithValue("@telefon", (customer as Customer).Telefon);
            cmd.Parameters.AddWithValue("@pontszam", (customer as Customer).Pontszam);
            int sorokSzama = cmd.ExecuteNonQuery();
            conn.Close();
            if (sorokSzama > 0)
            {
                return "Sikeres beszúrás!";
            }
            else
            {
                return "Sikertelen beszúrás";
            }
            
            }
            catch (Exception ex)
            {
                return "Hiba történt az adatok beszúrása során!" + ex.Message;
            }

        }

        public string DeleteCustomer(int id)
        {
            try {
            string connectionString = "SERVER = localhost;" +
             "DATABASE= webapppeldadb;" +
             "UID = root;" +
             "PASSWORD =;";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            string sql = "DELETE FROM vasarlo WHERE Id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            int sorokSzama = cmd.ExecuteNonQuery();
            conn.Close();
            if (sorokSzama > 0)
            {
                return "Sikeres Törlés!";
            }
            else
            {
                return "Sikertelen Törlés!";
            }
            }
            catch (Exception ex)
            {
                return "Hiba történt az adatok törlése során!" + ex.Message;
            }
        }

        public List<Customer> GetAllCustomer()
        {
            List<Customer> customers = new List<Customer>();

            string connectionString = "SERVER = localhost;" +
                          "DATABASE= webapppeldadb;" +
                          "UID = root;" +
                          "PASSWORD =;";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            string sql = "SELECT * FROM vasarlo";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Customer customer = new Customer();
                customer.Id = reader.GetInt32("id");
                customer.Nev = reader.GetString("Nev");
                customer.Cim = reader.GetString("Cim");
                customer.Email = reader.GetString("Email");
                customer.Telefon = reader.GetString("Telefon");
                customer.Pontszam = reader.GetInt32("Pontszam");
                customers.Add(customer);
            }
            conn.Close();

            return customers;




        }

        public Customer GetById(int id)
        {
            Customer result = new Customer();
            
            try
            {
                List<Customer> customers = new List<Customer>();
                string connectionString = "SERVER = localhost;" +
                          "DATABASE= webapppeldadb;" +
                          "UID = root;" +
                          "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sql = "SELECT * FROM vasarlo WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.Id = reader.GetInt32("id");
                    result.Nev = reader.GetString("Nev");
                    result.Cim = reader.GetString("Cim");
                    result.Email = reader.GetString("Email");
                    result.Telefon = reader.GetString("Telefon");
                    result.Pontszam = reader.GetInt32("Pontszam");
                    customers.Add(result);
                }
                else
                {
                    Console.WriteLine("Nincs ilyen vásárló!");
                }
                conn.Close();


                return result;
            }
            catch (Exception ex)
            {
                return result;
            }

        }
        public string PutCustomer(Customer customer)
        {
            try {
            string connectionString = "SERVER = localhost;" +
                          "DATABASE= webapppeldadb;" +
                          "UID = root;" +
                          "PASSWORD =;";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            string sql = "UPDATE vasarlo SET (Nev = @nev, Cim = @cim, Email = @email, Telefon = @telefon, Pontszam = @pontszam WHERE Id = @id)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nev", (customer as Customer).Nev);
            cmd.Parameters.AddWithValue("@cim", (customer as Customer).Cim);
            cmd.Parameters.AddWithValue("@email", (customer as Customer).Email);
            cmd.Parameters.AddWithValue("@telefon", (customer as Customer).Telefon);
            cmd.Parameters.AddWithValue("@pontszam", (customer as Customer).Pontszam);
            cmd.Parameters.AddWithValue("@id", (customer as Customer).Id);
            int sorokSzama = cmd.ExecuteNonQuery();
            conn.Clone();
            if (sorokSzama > 0)
            {
                return "Sikeres frissítés!";
            }
            else
            {
                return "Ismeretlen vásárló!";
            }
            }
            catch (Exception ex)
            {
                return "Hiba történt az adatok felülírása során!" + ex.Message;
            }
        }
    }
}