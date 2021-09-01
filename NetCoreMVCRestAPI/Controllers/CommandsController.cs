using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NetCoreMVCRestAPI.Data;
using NetCoreMVCRestAPI.Dtos;
using NetCoreMVCRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVCRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepository _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAll()
        {
            var commandItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<CommandReadDto> GetById(int id)
        {
            var commandItem = _repository.GetById(id);

            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }

            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> Create(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);

            _repository.Create(commandModel);

            var save = _repository.Save();

            if (save)
            {
                var commandRead = _mapper.Map<CommandReadDto>(commandModel);

                return CreatedAtRoute(nameof(GetById), new { Id = commandRead.Id }, commandRead);
            }

            return BadRequest();
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepository = _repository.GetById(id);

            if (commandModelFromRepository == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepository);

            _repository.Update(commandModelFromRepository);

            var save = _repository.Save();

            if (!save)
            {
                return BadRequest();
            }

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var commandModelFromRepository = _repository.GetById(id);

            if (commandModelFromRepository == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepository);
            patchDocument.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepository);

            _repository.Update(commandModelFromRepository);

            var save = _repository.Save();

            if (!save)
            {
                return BadRequest();
            }

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var commandModelFromRepository = _repository.GetById(id);

            if (commandModelFromRepository == null)
            {
                return NotFound();
            }

            _repository.Delete(commandModelFromRepository);

            var save = _repository.Save();

            if (!save)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
