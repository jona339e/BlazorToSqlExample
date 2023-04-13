namespace BlazorApp1.Data
{
    public class PersonModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }

        // Create database table called person with these values
        // the create a stored procedure called usp_GetPerson
    }
}
