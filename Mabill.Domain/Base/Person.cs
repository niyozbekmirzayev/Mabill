namespace Mabill.Domain.Base
{
    public class Person : BaseEntity
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
