using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _appDbContext;

        private List<Recall> recallData;

        private List<Country> countries;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void SaveCountries(List<Country> countries)
        {
            if (countries != null && countries.Count != 0)
            {
                foreach (Country c in countries)
                {
                    _appDbContext.Countries.Add(c);
                }
                _appDbContext.SaveChanges();
            }
        }

        public void SaveRecallData(List<Recall> recallData)
        {
            if (recallData != null && recallData.Count != 0)
            {
                foreach (Recall r in recallData)
                {
                    _appDbContext.Recalls.Add(r);
                }
                _appDbContext.SaveChanges();
            }
        }
    }
}
