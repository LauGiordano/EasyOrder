using EasyOrder.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyOrder.Datos
{
    public class BaseDeDatos : DbContext
    {
        public BaseDeDatos(DbContextOptions opciones) : base(opciones)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}
