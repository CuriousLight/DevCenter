using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev_Center.Repository
{
    interface IDomainRepository
    {
        string GetConnectionString();

        List<string[]> GetTable(string com);
    }
}
