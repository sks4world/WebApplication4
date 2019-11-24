using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class Repository:IRepository
    {
        private readonly AppDbContext _appDbContext;

        

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
