using CorePostgre.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorePostgre.Service
{
    public interface IOnrTableService
    {
        void Insert(string name, int roleId);
        OnrTable Get(int id);
        List<OnrTable> Get();
    }
}
