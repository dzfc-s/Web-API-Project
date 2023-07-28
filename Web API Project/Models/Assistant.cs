namespace Web_API_Project.Models
{
    public class Assistant : User
    {
        public int WorkingYears { get; set; } = 0;
        public string SubjectTeaching { get; set; } = string.Empty;
    }
}
