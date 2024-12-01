using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAMotosMVC.Models;

namespace SAMotosApi.Data
{
    public class SAMotosApiContext : DbContext
    {
        public SAMotosApiContext (DbContextOptions<SAMotosApiContext> options)
            : base(options)
        {
        }

        public DbSet<SAMotosMVC.Models.SAMoto> SAMoto { get; set; } = default!;
    }
}
