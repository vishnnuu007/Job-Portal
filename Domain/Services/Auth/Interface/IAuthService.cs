using Domain.Services.Auth.DTO;

namespace Domain.Services.Auth.Interface
{
    public interface IAuthService
    {
        Task<Guid> Signup(SignupRequestDTO dto);

        Task<bool> VerifyEmail(Guid signupId);

        Task<string> SetPassword(Guid signupId, PasswordDTO dto);

        Task<LoginDTO> Login(LoginrequestDto dto);

        Task<string> ForgetPassword(ForgetPasswordDTO dto);
    }
}
