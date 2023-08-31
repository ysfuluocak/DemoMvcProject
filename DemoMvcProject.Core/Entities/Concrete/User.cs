using DemoMvcProject.Core.Entities.Abstract;

namespace DemoMvcProject.Core.Entities.Concrete
{
    public class User : BaseEntity
    {
        public User()
        {
            Status = true;
            CreatedDate = DateTime.Now;
            Claims = new HashSet<UserOperationClaim>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public ICollection<UserOperationClaim> Claims { get; set; }

    }
}
