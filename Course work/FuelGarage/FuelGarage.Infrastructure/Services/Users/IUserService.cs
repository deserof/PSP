using FuelGarage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuelGarage.Infrastructure.Services.Users
{
    public interface IUserService
    {
        List<User> GetAll();

        User GetById(int id);

        User GetUserByEmailAndPAssword(string email, string password);

        User GetByEmail(string email);

        string GetUserRoleByEmail(string email);

        void Edit(User user);

        void Delete(int id);

        void Create(User user);
    }
}
