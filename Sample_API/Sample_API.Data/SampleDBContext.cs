using Microsoft.EntityFrameworkCore;
using Sample_API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_API.Data
{
    public class SampleDBContext : DbContext
    {
        public SampleDBContext(DbContextOptions<SampleDBContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Model1> Model1 { get; set; }
    }
}
