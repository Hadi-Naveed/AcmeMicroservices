using UserService.DTOs;


namespace UserService.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterDTO dto);
        Task<AuthResponse> LoginAsync(LoginDTO dto);
    }
}
