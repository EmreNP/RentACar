using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EFEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RentACarContext())
            {
                var eagerUser = context.Users.Include(U => U.OperationClaims).Single(u=>u.Id==user.Id);

                return eagerUser.OperationClaims;

            }
        }
    }
}
