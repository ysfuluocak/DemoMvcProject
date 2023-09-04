using DemoMvcProject.Core.Entities.Abstract;

namespace DemoMvcProject.Entities.Dtos.UserDtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
