using BookStoreApp.Models;
using BookStoreApp.Models.DTOs;

namespace BookStoreApp.Interface
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserRegisterDTO userRegisterDTO);
        User GetById(string id);
    }
}
