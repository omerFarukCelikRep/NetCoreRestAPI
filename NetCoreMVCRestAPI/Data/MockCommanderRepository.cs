using NetCoreMVCRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVCRestAPI.Data
{
    public class MockCommanderRepository : ICommanderRepository
    {
        public void Create(Command command)
        {
            throw new NotImplementedException();
        }

        public void Delete(Command command)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAll()
        {
            var commands = new List<Command>
            {
                new Command
                {
                    Id = 0,
                    HowTo = "Boil an egg",
                    Line = "Boil water",
                    Platform = "Kettle & Pan"
                },
                new Command
                {
                    Id = 1,
                    HowTo = "Cut bread",
                    Line = "Get a knifer",
                    Platform = "Knifer & Chopping board"
                },
                new Command
                {
                    Id = 2,
                    HowTo = "Make cup of tea",
                    Line = "Place teabag in cup",
                    Platform = "Kettle & Cup"
                }
            };

            return commands;
        }

        public Command GetById(int id)
        {
            return new Command
            {
                Id = 0,
                HowTo = "Boil an egg",
                Line = "Boil water",
                Platform = "Kettle & Pan"
            };
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
