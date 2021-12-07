using FuelGarage.Domain.Entities;
using FuelGarage.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public string GetUserPassword(int id)
        {
            var user = _dbContext.Users
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
            return user.UserPassword;
        }

        public void EditFuel(int userId, int fuelCount, int fuelCurrent)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _dbContext.Users
                .Include(x => x.Role)
                .Include(x => x.Vehicle)
                .AsNoTracking()
                .ToList();
        }

        public User GetByEmail(string email)
        {
            return _dbContext.Users
                .AsNoTracking()
                .FirstOrDefault(x => x.Email.Equals(email));
        }

        public User GetById(int id)
        {
            return _dbContext.Users
                .Where(x => x.Id == id)
                .Include(x => x.Role)
                .Include(x => x.Vehicle)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return _dbContext.Users
                .AsNoTracking()
                .FirstOrDefault(x => x.Email.Equals(email) && x.UserPassword.Equals(password));
        }

        public string GetUserRoleByEmail(string email)
        {
            var user = _dbContext.Users
                .Include(x => x.Role)
                .AsNoTracking()
                .FirstOrDefault(x => x.Email.Equals(email));
            return user?.Role.RoleName;
        }

        public void Edit(User user)
        {
            _dbContext.Update(user);
            _dbContext.SaveChanges();
        }
    }
}
