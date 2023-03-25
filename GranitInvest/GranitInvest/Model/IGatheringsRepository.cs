using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranitInvest.Model
{
    internal interface IGatheringsRepository
    {
        void Add(Gatherings gatherings);
        Gatherings GetById(int id);
        Gatherings GetByName(string name);
        DataTable GetAll(DataTable dt);
    }
}
