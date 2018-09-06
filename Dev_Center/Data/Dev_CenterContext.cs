using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dev_Center;

namespace Dev_Center.Models
{
    public class Dev_CenterContext : DbContext
    {
        public Dev_CenterContext (DbContextOptions<Dev_CenterContext> options)
            : base(options)
        {
        }

    }
}
