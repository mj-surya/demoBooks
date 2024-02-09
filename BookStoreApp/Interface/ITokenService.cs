using BookStoreApp.Models.DTOs;

namespace BookStoreApp.Interface
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
