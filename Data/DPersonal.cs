using MedPortal.Models;
using MySql.Data.MySqlClient;

namespace MedPortal.Data
{

    public class DPersonal
    {
        private string _connectionString;
        private IConfiguration _Configuration;

      
        public DPersonal(IConfiguration configuration)
        {
            _Configuration = configuration;
            _connectionString = configuration.GetConnectionString("Mysql");
        }

        public bool save(Personal Personal)
        {
            bool result = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Personal (Nombres, Apellidos, Username, Password, CodigoMinsa, Especialidad, Rol) VALUES (@Nombres, @Apellidos, @Username, @Password, @CodigoMinsa, @Especialidad, @Rol)";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Nombres", Personal.Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", Personal.Apellidos);
                        cmd.Parameters.AddWithValue("@Username", Personal.Username);
                        cmd.Parameters.AddWithValue("@Password", Personal.Password);
                        cmd.Parameters.AddWithValue("@CodigoMinsa", Personal.CodigoMinsa);
                        cmd.Parameters.AddWithValue("@Especialidad", Personal.Especialidad);
                        cmd.Parameters.AddWithValue("@Rol", Personal.Rol);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            result = true;
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
         
        }

        public bool update(Personal Personal)
        {
            bool result = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    con.Open();
                    string query = "UPDATE Personal SET Nombres = @Nombres, Apellidos = @Apellidos, Username = @Username, Password = @Password, CodigoMinsa = @CodigoMinsa, Especialidad = @Especialidad, Rol = @Rol WHERE IdPersonal = @IdPersonal";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@IdPersonal", Personal.IdPersonal);
                        cmd.Parameters.AddWithValue("@Nombres", Personal.Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", Personal.Apellidos);
                        cmd.Parameters.AddWithValue("@Username", Personal.Username);
                        cmd.Parameters.AddWithValue("@Password", Personal.Password);
                        cmd.Parameters.AddWithValue("@CodigoMinsa", Personal.CodigoMinsa);
                        cmd.Parameters.AddWithValue("@Especialidad", Personal.Especialidad);
                        cmd.Parameters.AddWithValue("@Rol", Personal.Rol);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool delete(int IdPersonal)
        {
            bool result = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Personal WHERE IdPersonal = @IdPersonal";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@IdPersonal", IdPersonal);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public Personal? get(int IdPersonal) 
        {
            Personal? personal = null;
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Personal WHERE IdPersonal = @IdPersonal";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@IdPersonal", IdPersonal);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                personal = new Personal();
                                personal.IdPersonal = dr.GetInt32("IdPersonal");
                                personal.Nombres = dr.GetString("Nombres");
                                personal.Apellidos = dr.GetString("Apellidos");
                                personal.Username = dr.GetString("Username");
                                personal.Password = dr.GetString("Password");
                                personal.CodigoMinsa = dr.GetString("CodigoMinsa");
                                personal.Especialidad = dr.GetString("Especialidad");
                                personal.Rol = dr.GetInt32("Rol");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return personal;
        }

        public List<Personal> GetAll() 
        {
            List<Personal> list = new List<Personal>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Personal";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Personal personal = new Personal();
                                personal.IdPersonal = dr.GetInt32("IdPersonal");
                                personal.Nombres = dr.GetString("Nombres");
                                personal.Apellidos = dr.GetString("Apellidos");
                                personal.Username = dr.GetString("Username");
                                personal.Password = dr.GetString("Password");
                                personal.CodigoMinsa = dr.GetString("CodigoMinsa");
                                personal.Especialidad = dr.GetString("Especialidad");
                                personal.Rol = dr.GetInt32("Rol");
                                list.Add(personal);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        
        }

        

    }
}
