using MySql.Data.MySqlClient;

namespace API_CRUD.DAO
{
    public class ConnectionFactory
    {
        public static MySqlConnection Build()
        {
            return new MySqlConnection("Server=localhost;Database=Formula1;Uid=root;Pwd=root;");
        }
    }
}
