namespace EntityFrameworkCore_WithSP_Demo.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string PersonDNI { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public DateTime PersonDOB { get; set; }
        public bool IsActive { get; set; }
    }
}
