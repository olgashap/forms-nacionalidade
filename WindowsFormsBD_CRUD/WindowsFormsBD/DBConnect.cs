using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsBD
{
    internal class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string username;
        private string password;
        private string database;
        private string port;

        public DBConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "192.168.1.102";  //"192.168.1.158";
            username = "Prog15"; // "programador";
            password = "programador15"; // "Programador15";
            database = "gestaoformandos";
            port = "3306";
            string connectionString = "Server = " + server + "; Port = " + port +
                "; Database = " + database + "; Uid = " + username + "; Pwd = " + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public string StatusConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                else
                {
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return connection.State.ToString();
        }

        public int Count()
        {
            string query = "select count(*) from formando;";

            int count = -1;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    count = int.Parse(cmd.ExecuteScalar().ToString());
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return count;
        }

        //Insert statement
        public void Insert()
        {
            string query = "insert into formando (nome, id_formando, morada, contacto, iban, sexo, data_nascimento) values ('Pinto da Costa', " +
                "'10099', 'Rua do Porto', NULL, '000000000000000000000', 'M', '1950-06-22')";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

        }

        public bool Insert(string ID, string nome, string morada, string iban, char sexo, string data_nascimneto)
        {
            bool flag = true;

            string query = "insert into formando (id_formando, nome, morada, iban, sexo, data_nascimento) values ('" +
                ID + "', '" + nome + "', '" + morada + "', '" + iban + "', '" + sexo + "', '" + data_nascimneto + "');";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }

            return flag;

        }

        public bool Insert(string ID, string nome, string morada, string contacto, string iban, char sexo, string data_nascimneto)
        {
            bool flag = true;

            string query = "insert into formando (id_formando, nome, morada, contacto, iban, sexo, data_nascimento) values ('" +
                ID + "', '" + nome + "', '" + morada + "', '" + contacto + "', '" + iban + "', '" + sexo + "', '" + data_nascimneto + "');";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }

            return flag;

        }

        public bool Update(string ID, string nome, string morada, string contacto, string iban, char sexo, string data_nascimneto)
        {
            bool flag = true;

            string query = "update formando set nome = '" + nome + "', morada = '" + morada + "', contacto = '" +
                contacto + "', iban = '" + iban + "', sexo = '" + sexo + "', data_nascimento = '" + data_nascimneto +
                "' where id_formando = " + ID;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }

            return flag;

        }

        public bool Delete()
        {
            bool flag = true;

            string query = "delete from formando where id_formando = 10099;";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public bool Update()
        {
            bool flag = true;

            string query = "Update formando set nome = 'Maria da Costa', sexo = 'F' where id_formando = 10099;";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public bool Delete(string id)
        {
            bool flag = true;

            string query = "delete from formando where id_formando = '" + id + "';";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public int DevolveUltimaID()
        {
            int ultimoID = 0;

            string query = "select max(id_formando) from formando;";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //ultimoID = int.Parse(cmd.ExecuteScalar().ToString());
                    int.TryParse(cmd.ExecuteScalar().ToString(), out ultimoID);
                    ultimoID++;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            //catch 
            //{
            //    //MessageBox.Show("ERRO");
            //}           
            finally
            {
                CloseConnection();
            }

            return ultimoID;

        }

        public bool PesquisaFormando(string ID_pesquisa, ref string nome, ref string morada, ref string contacto,
            ref string iban, ref char sexo, ref string data_nascimento)
        {
            bool flag = false;

            string query = "select nome, morada, contacto, iban, sexo, data_nascimento from formando " +
                "where id_formando = '" + ID_pesquisa + "'";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        nome = dataReader[0].ToString();
                        morada = dataReader["morada"].ToString();
                        contacto = dataReader[2].ToString();
                        iban = dataReader[3].ToString();
                        sexo = dataReader["sexo"].ToString()[0];
                        data_nascimento = dataReader[5].ToString();
                        flag = true;
                    }
                    dataReader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public void PreencherDataGridViewFormandos(ref DataGridView dgv)
        {
            string query = "select id_formando, nome, iban, contacto, sexo from formando order by nome";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    int idxLinha = 0;
                    while (dr.Read())
                    {
                        dgv.Rows.Add();
                        dgv.Rows[idxLinha].Cells["codID"].Value = dr[0].ToString();
                        dgv.Rows[idxLinha].Cells["Nome"].Value = dr["nome"].ToString();
                        dgv.Rows[idxLinha].Cells[2].Value = dr[2].ToString();
                        dgv.Rows[idxLinha].Cells[3].Value = dr["contacto"].ToString();
                        dgv.Rows[idxLinha].Cells["Genero"].Value = dr["sexo"].ToString();
                        idxLinha++;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

        }

        public void PreencherDataGridViewFormandos(ref DataGridView dgv, char genero, string nome)
        {
            string query = "select id_formando, nome, iban, contacto, sexo from formando";

            if (genero != 'T')
            {
                query = query + " where sexo = '" + genero + "'";
            }

            if (nome.Length > 0 && genero != 'T')
            {
                query = query + " and nome like '%" + nome + "%'";
            }
            else if (nome.Length > 0)
            {
                query = query + " where nome like '%" + nome + "%'";
            }

            query = query + " order by nome;";


            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    int idxLinha = 0;
                    while (dr.Read())
                    {
                        dgv.Rows.Add();
                        dgv.Rows[idxLinha].Cells["codID"].Value = dr[0].ToString();
                        dgv.Rows[idxLinha].Cells["Nome"].Value = dr["nome"].ToString();
                        dgv.Rows[idxLinha].Cells[2].Value = dr[2].ToString();
                        dgv.Rows[idxLinha].Cells[3].Value = dr["contacto"].ToString();
                        dgv.Rows[idxLinha].Cells["Genero"].Value = dr["sexo"].ToString();
                        idxLinha++;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }


            //Nacionalidade



        public bool InsertNacionalidade(string alf2, string nacionalidade)
        {
            bool flag = true;
            string query = "insert into Nacionalidade values (0,'" + alf2 + "', '" + nacionalidade + "')";

            try
            {

                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }

            this.CloseConnection();
            return flag;

        }


        public bool DeleteNacionalidade(string id_nacionalidade)
        {
            bool flag = true;
            string query = "Delete from Nacionalidade where id_nacionalidade = " + id_nacionalidade;

            try
            {

                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }

            this.CloseConnection();
            return flag;

        }


        public void PreencherComboNacionalidade(ref System.Windows.Forms.ComboBox cmb)
        {
            string query = "select id_nacionalidade, alf2, nacionalidade from Nacionalidade";
            cmb.Items.Clear();

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    int idxLinha = 0;
                    while (dr.Read())
                    {
                        string id = dr["id_nacionalidade"].ToString();
                        string name = dr["alf2"].ToString();
                        string nationality = dr["nacionalidade"].ToString();

                        // Concatenate name and nationality if needed
                        string displayText = $"{name} - {nationality} - {id}";

                        // Add to ComboBox
                        cmb.Items.Add(displayText);
                        idxLinha++;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

        }


        public bool AtualizarNacionalidade(string id_nacionalidade, string alf2, string nacionalidade)
        {
            bool flag = true;

            string query = "update nacionalidade set alf2 = '" + alf2 + "', nacionalidade = '" + nacionalidade +
                "' where id_nacionalidade = " + id_nacionalidade;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }

            return flag;

        }
        public void PreencherDataGridViewNacionalidade(ref DataGridView dgv)
        {
            string query = "select id_nacionalidade, alf2, nacionalidade from Nacionalidade";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    int idxLinha = 0;
                    while (dr.Read())
                    {
                        dgv.Rows.Add();
                        dgv.Rows[idxLinha].Cells["id_nacionalidade"].Value = dr[0].ToString();
                        dgv.Rows[idxLinha].Cells["ALF2"].Value = dr[1].ToString();
                        dgv.Rows[idxLinha].Cells["Nacionalidade"].Value = dr[2].ToString();
          
                        
                        idxLinha++;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

        }

    }
}