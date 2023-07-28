using Swashbuckle.AspNetCore.Annotations;

namespace Web_API_Project.Models
{
    public abstract class User
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
