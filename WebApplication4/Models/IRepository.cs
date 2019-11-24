using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public interface IRepository
    {
        void SaveCountries(List<Country> countries);

        void SaveRecallData(List<Recall> recallData);


    }
}
