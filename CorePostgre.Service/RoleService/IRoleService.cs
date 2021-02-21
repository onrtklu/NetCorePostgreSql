using CorePostgre.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorePostgre.Service.RoleService
{
    public interface IRoleService
    {
        void Insert(string name);
        Role Get(int id);
        List<Role> Get();
        void Delete(int id);
    }
}
