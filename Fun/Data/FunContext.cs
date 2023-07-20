using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fun.Models;
using Microsoft.EntityFrameworkCore;

namespace Fun.Data
{
    public class FunContext : DbContext
    {
        public FunContext(DbContextOptions<FunContext> options)
            : base(options)
        {
        }


        public DbSet<UsuarioModel> Usuarios{get;set;}
        public DbSet<Medidas> MedidasC{get; set;}

    }

}
