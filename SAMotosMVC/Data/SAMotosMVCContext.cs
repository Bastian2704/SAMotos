using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAMotosMVC.Models;

namespace SAMotosMVC.Data
{
    public class SAMotosMVCContext : DbContext
    {
        public SAMotosMVCContext (DbContextOptions<SAMotosMVCContext> options)
            : base(options)
        {
        }

        public DbSet<SAMotosMVC.Models.SAMoto> SAMoto { get; set; } = default!;
    }
}
