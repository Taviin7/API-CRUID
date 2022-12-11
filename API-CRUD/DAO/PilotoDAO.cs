using API_CRUD.DTO;
using MySql.Data.MySqlClient;

namespace API_CRUD.DAO
{
    public class PilotoDAO
    {
        public List<PilotoDTO> Listar()
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT*FROM Pilotos";

            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();

            var pilotos = new List<PilotoDTO>();

            while (dataReader.Read())
            {
                var piloto = new PilotoDTO();
                piloto.ID = int.Parse(dataReader["ID"].ToString());
                piloto.Nome = dataReader["Nome"].ToString();
                piloto.Nacionalidade = dataReader["Nacionalidade"].ToString();
                piloto.Equipe = dataReader["Equipe"].ToString();
                piloto.UltimaVitoria = Convert.ToDateTime(dataReader["UltimaVitoria"]);
                pilotos.Add(piloto);
            }
            conexao.Close();

            return pilotos;
        }

        public void Cadastrar(PilotoDTO piloto)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO Pilotos (Nome, Nacionalidade, Equipe, UltimaVitoria) VALUES
						(@nome,@nacionalidade,@equipe,@ultimaVitoria)";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@nome", piloto.Nome);
            comando.Parameters.AddWithValue("@nacionalidade", piloto.Nacionalidade);
            comando.Parameters.AddWithValue("@equipe", piloto.Equipe);
            comando.Parameters.AddWithValue("@ultimaVitoria", piloto.UltimaVitoria);

            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void Alterar(PilotoDTO piloto)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"UPDATE Pilotos Set Nome=@nome, Nacionalidade=@nacionalidade, Equipe=@equipe, UltimaVitoria=@ultimaVitoria where ID=@id";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@id", piloto.ID);
            comando.Parameters.AddWithValue("@nome", piloto.Nome);
            comando.Parameters.AddWithValue("@nacionalidade", piloto.Nacionalidade);
            comando.Parameters.AddWithValue("@equipe", piloto.Equipe);
            comando.Parameters.AddWithValue("@ultimaVitoria", piloto.UltimaVitoria);

            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void Remover(int id)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"DELETE FROM Pilotos WHERE ID=@id";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
    }
}
