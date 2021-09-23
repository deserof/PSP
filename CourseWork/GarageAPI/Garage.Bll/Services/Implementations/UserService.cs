using Garage.Bll.Services.Interfaces;
using Garage.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Bll.Services.Implementations
{
    public class UserService : IUserService
    {
        private protected IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
    }
}
