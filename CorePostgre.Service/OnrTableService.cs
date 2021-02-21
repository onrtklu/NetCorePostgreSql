using CorePostgre.Data;
using CorePostgre.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorePostgre.Service
{
    public class OnrTableService : IOnrTableService
    {
        private readonly OnrDbContext _dbContext;

        public OnrTableService(OnrDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public OnrTable Get(int id)
        {
            return _dbContext.OnrTable.Find(id);
        }

        public List<OnrTable> Get()
        {
            return _dbContext.OnrTable.Include(s => s.Role).ToList();
        }

        public void Insert(string name, int roleId)
        {
            _dbContext.OnrTable.Add(new OnrTable()
            {
                Name = name,
                RoleId = roleId
            });

            _dbContext.SaveChanges();
        }
    }
}
