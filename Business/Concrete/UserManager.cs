using Business.Abstract;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
           _userDal.Add(user);
        }

        public User getByUserName(string userName)
        {
            return _userDal.Get(filter: u => u.UserName == userName);
        }
    }
}
