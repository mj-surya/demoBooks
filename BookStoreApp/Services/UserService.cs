﻿using BookStoreApp.Interface;
using BookStoreApp.Models.DTOs;
using BookStoreApp.Models;
using System.Security.Cryptography;
using System.Text;

namespace BookStoreApp.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<string, User> _repository;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<string, User> repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }
        public User GetById(string id)
        {
            var user = _repository.GetById(id);
            return user;
        }
        public UserDTO Login(UserDTO userDTO)
        {
            var user = _repository.GetById(userDTO.Email);
            if (user != null)
            {
                HMACSHA512 hmac = new HMACSHA512(user.Key);
                var userpass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userpass.Length; i++)
                {
                    if (user.Password[i] != userpass[i])
                        return null;
                }
                userDTO.Role = user.Role;
                userDTO.Token = _tokenService.GetToken(userDTO);
                userDTO.Password = "";
                userDTO.Name = user.Name;
                return userDTO;
            }
            return null;
        }
        public UserDTO Register(UserRegisterDTO userRegisterDTO)
        {
            HMACSHA512 hmac = new HMACSHA512();
            User user = new User()
            {
                Email = userRegisterDTO.Email,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.Password)),
                Phone = userRegisterDTO.Phone,
                Name = userRegisterDTO.Name,
                Key = hmac.Key,
                Role = userRegisterDTO.Role
            };
            var result = _repository.Add(user);
            if (result != null)
            {
                userRegisterDTO.Token = _tokenService.GetToken(userRegisterDTO);
                userRegisterDTO.Password = "";
                userRegisterDTO.ReTypePassword = "";
                return userRegisterDTO;
            }
            return null;

        }
    }
}
