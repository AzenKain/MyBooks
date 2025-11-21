using MyBooks.Data;
using MyBooks.Models;
using MyBooks.DTOs;
using MyBooks.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Services
{


    public class AuthService
    {
        private readonly UserRepository userRepository;
        public static User? CurrentUser { get; private set; }
        public AuthService()
        {
            this.userRepository = new UserRepository();
        }

        public ServiceResponse<User> login(string username, string password)
        {
            var user = userRepository.GetByUsername(username);
            if (user == null)
                return new ServiceResponse<User> { Success = false, Message = "User không tồn tại" };

            string hashedPassword = Utils.PasswordHelper.HashPassword(password);
            if (user.Password != hashedPassword)
                return new ServiceResponse<User> { Success = false, Message = "Sai mật khẩu" };

            CurrentUser = user;
            return new ServiceResponse<User> { Success = true, Message = "Đăng nhập thành công", Data = user };
        }

        public ServiceResponse<bool> logout()
        {
            CurrentUser = null;
            return new ServiceResponse<bool> { Success = true, Message = "Đăng xuất thành công", Data = true };
        }

        public bool register(string username, string password)
        {
            var user = this.userRepository.GetByUsername(username);
            if (user != null)
            {
                return false;
            }

            string hashedPassword = Utils.PasswordHelper.HashPassword(password);
            this.userRepository.Insert(new User
            {
                Username = username,
                Password = hashedPassword,
            });

            CurrentUser = this.userRepository.GetByUsername(username);
            return true;
        }
    }
}