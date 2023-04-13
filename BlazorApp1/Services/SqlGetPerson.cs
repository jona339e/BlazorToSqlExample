using BlazorApp1.Data;
using System.Data.SqlClient;

namespace BlazorApp1.Services
{
    public class SqlGetPerson
    {
        string conn = @"Data Source=localhost\SQLEXPRESS;Database=BlazorApp1;Trusted_Connection=True;";
        public List<PersonModel> GetPerson()
        {
            List<PersonModel> personList = new();


            using (SqlConnection connection = new(conn))
            {
                connection.Open();
                using (SqlCommand command = new("EXEC usp_GetPerson", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PersonModel person = new();
                            person.FName = reader.GetString(0);
                            person.LName = reader.GetString(1);
                            person.Birthdate = reader.GetDateTime(2);
                            personList.Add(person);
                        }
                    }
                }
            }
            return personList;
        }
    }
}
