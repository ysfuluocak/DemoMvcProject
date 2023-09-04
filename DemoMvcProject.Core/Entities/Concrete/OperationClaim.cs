using DemoMvcProject.Core.Entities.Abstract;

namespace DemoMvcProject.Core.Entities.Concrete
{
    public class OperationClaim : BaseEntity
    {
        public OperationClaim()
        {
            Status = true;
            CreatedDate = DateTime.Now;
            Users = new HashSet<UserOperationClaim>();
        }
        public string Name { get; set; }
        public ICollection<UserOperationClaim> Users { get; set; }

    }
}
