using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContactsManagementWebApp.Models;

    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext (DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContactsManagementWebApp.Models.Contact> Contact { get; set; } = default!;
    }
