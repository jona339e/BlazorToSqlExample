using BlazorApp1.Data;
using System.Data.SqlClient;

namespace BlazorApp1.Services
{
    public class SqlGetPerson
    {


        public List<PersonModel> GetPerson(string conn)
        {
            List<PersonModel> personList = new();


            using (SqlConnection connection = new SqlConnection(conn))
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
                            person.Age = DateTime.Now.Year - reader.GetDateTime(2).Year;
                            personList.Add(person);
                        }
                    }
                }
            }
            return personList;
        }
    }
}
