using CorePostgre.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorePostgre.Data.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<OnrDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }


        /*
        - Not: Dependencies
            - API'de EntityFrameworkCore.Design olmalı
            - Data'da EFCore.SqlServer, EFCore.Tools, Npgsql.EFCore.PostgreSQL olmalı

        - Not: Çalıştırmak için 
            - Api projesi start up olmalı 
            - Package manager console'un default projesi Data projesi olmalı

        - Script-DbContext -context OnrDbContext -> script verir
        - Add-Migration yeni migration oluşturur.

         */

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<OnrDbContext>())
                {

                    //add admin user
                    if (!context.OnrTable.Any())
                    {
                        var entity = new OnrTable
                        {
                            Name = "onrtklu",
                            RoleId = 1
                        };
                        context.OnrTable.Add(entity);
                    }

                    //add admin user
                    if (!context.Role.Any())
                    {
                        var entity = new Role
                        {
                            //Id = 1, //incredible seed number arttmıyor
                            Name = "OnrRole"
                        };
                        context.Role.Add(entity);
                    }


                    context.SaveChanges();
                }
            }
        }
    }
}
