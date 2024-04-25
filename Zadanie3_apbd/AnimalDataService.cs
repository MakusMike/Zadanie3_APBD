namespace Zadanie3_apbd;
using System.Data.SqlClient;

public class AnimalDataService : I_AnimalDataService
{
    private readonly string _connectionstring =
        "Data source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s25713;Integreted Security=true";

    public List<Animal> GetAnimal(string orderBy)
    {
        string orderByTrue = "";
        if (string.IsNullOrWhiteSpace(orderBy) || orderBy.Equals("IdAnimal"))
        {
            orderByTrue = "Name";
        }
        else
        {
            orderByTrue = orderBy;
        }

        var sql = "SELECT * FROM Animal ORDER BY " + orderByTrue;
        var output = new List<Animal>();using (var connection = new SqlConnection(_connectionstring))
        {
            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = sql;
            connection.Open();
            var dr = command.ExecuteReader();
            while (dr.Read())
            {
                output.Add(new Animal
                {
                    IdAnimal = int.Parse(dr["IdAnimal"].ToString()),
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Category = dr["Category"].ToString(),
                    Area = dr["Area"].ToString()
                });
            }
            connection.Close();
            return output;
        }
        
    }
    public void UpdateAnimal(string idAnimal, Animal animal)
    {
        using (var connection = new SqlConnection(_connectionstring))
        {
            SqlCommand con = new SqlCommand();
            con.Connection = connection;
    
            con.CommandText = "UPDATE Animal SET " +
                              "Name = @Name ," +
                              "Description = @Description," +
                              " Category = @Category," +
                              " Area = @Area " +                   
                              "WHERE idAnimal= @IdAnimal";

            con.Parameters.AddWithValue("@IdAnimal", idAnimal);
            con.Parameters.AddWithValue("@Name", animal.Name);
            con.Parameters.AddWithValue("@Description", animal.Description);
            con.Parameters.AddWithValue("@Category", animal.Category);
            con.Parameters.AddWithValue("@Area", animal.Area);
    
            connection.Open();
            con.ExecuteNonQuery();
            connection.Close();
        }
    }
    public void AddAnimal(Animal animal)
    {
        using (var connection = new SqlConnection(_connectionstring))
        {
            SqlCommand con = new SqlCommand();
            con.Connection = connection;
            con.CommandText = "INSERT INTO Animal VALUES" +
                              "(@Name,@Description,@Category,@Area)";
            con.Parameters.AddWithValue("@Name", animal.Name);
            con.Parameters.AddWithValue("@Description", animal.Description);
            con.Parameters.AddWithValue("@Category", animal.Category);
            con.Parameters.AddWithValue("@Area", animal.Area);

            connection.Open();
            con.ExecuteNonQuery();
            connection.Close();
        }
    }
    public void DeleteAnimal(string idAnimal)
    {
        using (var connection = new SqlConnection(_connectionstring))
        {
            SqlCommand con = new SqlCommand();
            con.Connection = connection;
            con.CommandText = "DELETE FROM Animal WHERE IdAnimal = @idAnimal";
            con.Parameters.AddWithValue("@idAnimal", idAnimal);
            connection.Open();
            con.ExecuteNonQuery();
        }
    }
}