using NetCoreMVCRestAPI.Data.Context;
using NetCoreMVCRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVCRestAPI.Data
{
    public class SqlCommanderRepository : ICommanderRepository
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepository(CommanderContext context)
        {
            _context = context;
        }

        public void Create(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _context.Commands.Add(command);
        }

        public void Delete(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _context.Commands.Remove(command);
        }

        public IEnumerable<Command> GetAll()
        {
            return _context.Commands.ToList();
        }

        public Command GetById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update(Command command)
        {
            //Do not need update method
        }
    }
}
