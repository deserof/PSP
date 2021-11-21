﻿using FuelGarage.Infrastructure.Db;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using FuelGarage.Domain.Entities;

namespace FuelGarage.Infrastructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly GarageContext _dbContext;

        public UserService(GarageContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(User user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetByEmail(string email)
        {
            return _dbContext.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
        }

        public User GetById(int id)
        {
            return _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public User GetUserByEmailAndPAssword(string email, string password)
        {
            return _dbContext.Users.Where(x => x.Email.Equals(email) && x.UserPassword.Equals(password)).FirstOrDefault();
        }

        public void Update(User user)
        {
            _dbContext.Update(user);
            _dbContext.SaveChanges();
        }
    }
}
