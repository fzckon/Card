using EF.Core;
using EF.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.System.Respository
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        private SystemContext _systemContext = null;
        public UserRepository(SystemContext systemContext) : base(systemContext)
        {
            _systemContext = systemContext;
        }

        public async Task<User> LoginAsync(LoginUser loginUser)
        {
            User user = await FirstOrDefaultAsync(t => t.Tel == loginUser.Name);
            if (_systemContext.UserPwds.Any(t => t.UserId == user.Id && t.Password == loginUser.Password && t.PwdStatus == PwdStatus.Normal))
            {
                return user;
            }
            if (user != null)
                user = new User();
            return user;
        }
    }

    public interface IUserRepository
    {
        Task<User> LoginAsync(LoginUser user);
    }
}
