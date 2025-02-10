
using MySql.Data.MySqlClient;
using projetoAPI.DataBase;


namespace projetoAPI.Models
{
    public class AparicaoDAO
    {

        private static ConnectionMysql conn;

        public AparicaoDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Aparicao item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "insert into Aparicao values (null, 'Propiedade-1','Pasto-1', 'Cavalo', '9 meses', 'ASD', 'Lote-2', '2020-01-01')";

                query.Parameters.AddWithValue("@Propriedade", item.Propriedade);
                query.Parameters.AddWithValue("@Pasto", item.Pasto);
                query.Parameters.AddWithValue("@Animal", item.Animal);
                query.Parameters.AddWithValue("@Situação", item.Situacao);
                query.Parameters.AddWithValue("@Observação", item.Observacao);
                query.Parameters.AddWithValue("@TransferirParaLote", item.TransferirParaLote);
                query.Parameters.AddWithValue("@DataTransferenciaLote", item.DataTransferenciaLote);
                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");
                }

                return (int)query.LastInsertedId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public List<Aparicao> List()
        {
            try
            {
                List<Aparicao> list = new List<Aparicao>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Aparicao";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Aparicao()
                    {
                        Id = reader.GetInt32("Id_apa"),
                        Propriedade = reader.GetString("Propriedade_apa"),
                        Pasto = reader.GetString("Pasto_apa"),
                        Animal = reader.GetString("Animal_apa"),
                        Situacao = reader.GetString("Situacao_apa"),
                        Observacao = reader.GetString("Observacao_apa"),
                        TransferirParaLote = reader.GetString("TransferirParaLote_apa"),
                        DataTransferenciaLote = reader.GetDateTime("DataTransferenciaLote_apa")


                    });

                }

                return list;


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();

            }



        }
    
    }
}
