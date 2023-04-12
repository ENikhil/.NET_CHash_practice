

namespace webapi.Models
{
    public class Transition
    {
        public int Id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string owner { get; set; } = string.Empty;
        public string co_owner { get; set; } = string.Empty;
        public bool is_active { get; set; }
        //[SwaggerSchema(Format="datetime")]
        public DateTime start_date { get; set; }
        //[SwaggerSchema(Format="datetime")]
        public DateTime end_date { get; set; }
        //Attempted to create a many to many relationship with applications and employees
        //public List<Application> applications { get; set; } = new List<Application>();
        //public List<Employee> employees { get; set; } = new List<Employee>();
    }

    public class Application
    {
        public int Id { get; set; }
        public string name { get; set; } = string.Empty;
        public string owner { get; set; } = string.Empty;
        //public List<Transition> transitions { get; set; } = new List<Transition>();
        //public List<int> transitions { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int phone { get; set; }
        public string location { get; set; } = string.Empty;
        //public List<Transition> transitions { get; set; } = new List<Transition>();
        //public List<int> transitions { get; set; }
    }
}
