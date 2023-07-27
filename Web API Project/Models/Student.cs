namespace Web_API_Project.Models
{
    public class Student : User
    {
        public string IndexNumber  { get; set; }
        public DateTime DateOfBirth  { get; set; }
        public int YearOfStudy { get; set; }

    }
}
