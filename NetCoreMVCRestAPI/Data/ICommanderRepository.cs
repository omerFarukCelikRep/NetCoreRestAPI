using NetCoreMVCRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVCRestAPI.Data
{
    public interface ICommanderRepository
    {
        bool Save();
        IEnumerable<Command> GetAll();
        Command GetById(int id);
        void Create(Command command);
        void Update(Command command);
        void Delete(Command command);
    }
}
