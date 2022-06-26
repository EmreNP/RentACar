using Business.Abstract;
using Business.Concrete;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.IoC;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DtoS;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUI
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var context = new RentACarContext();
            UserManager userManager = new UserManager(new EfUserDal());
            var users = context.Users;
        
           
        }

    }
}