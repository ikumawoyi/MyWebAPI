﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MyHospitalManagement.Models;
using MyWebAPI.Models;

namespace MyWebAPI.Repositories
{
    public interface IUsersRepository
    {

        IEnumerable<User> GetUsers();

        User GetUser(int id);

        User AddUser(User user);

        void UpdateUser(int id, User user);

        void DeleteUser(int id);

    }
}
