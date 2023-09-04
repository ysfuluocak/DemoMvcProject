using DemoMvcProject.Core.Entities.Abstract;


namespace DemoMvcProject.Core.Entities.Concrete
{
    public class UserOperationClaim : BaseEntity
    {
        public UserOperationClaim()
        {
            Status = true;
            CreatedDate = DateTime.Now;
        }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public User User { get; set; }
        public OperationClaim OperationClaim { get; set; }
    }
}
