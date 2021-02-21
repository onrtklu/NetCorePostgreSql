using CorePostgre.Data;
using CorePostgre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorePostgre.Service.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly OnrDbContext _dbContext;

        public RoleService(OnrDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Role.Find(id);
            _dbContext.Role.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Role Get(int id)
        {
            return _dbContext.Role.Find(id);
        }

        public List<Role> Get()
        {
            return _dbContext.Role.ToList();
        }

        public void Insert(string name)
        {
            _dbContext.Role.Add(new Role()
            {
                Name = name
            });

            _dbContext.SaveChanges();
        }
    }
}
