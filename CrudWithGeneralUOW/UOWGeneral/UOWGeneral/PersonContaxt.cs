using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UOWGeneral.Models;

namespace UOWGeneral
{
    public class PersonContaxt : DbContext
    {
        public PersonContaxt()
            : base("name=DbConnectionString")
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}