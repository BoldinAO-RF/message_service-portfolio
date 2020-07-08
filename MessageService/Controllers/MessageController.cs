using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using MessageService.Contract;
using MessageService.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace MessageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IMessageRepository _messageRepository;
        private IUserRepository _userRepository;
        private IValidator<MessageViewModel> _validator;

        public MessageController(IMessageRepository messageRepository, IUserRepository userRepository, IValidator<MessageViewModel> validator)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _validator = validator;
        }

        // GET: api/<MessageController>
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return _messageRepository.GetAll();
        }

        // POST api/<MessageController>
        [HttpPost]
        public IActionResult Post([FromBody] MessageViewModel message)
        {
            var validatorResult = _validator.Validate(message);

            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);

            _messageRepository.Save(message);
            return Created("test", message);
        }

        // PUT api/<MessageController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MessageViewModel message)
        {
            var validatorResult = _validator.Validate(message);

            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);
            //else if (!_messageRepository.GetAll().Where(m => m.Id == id).Any())
            //    return BadRequest($"Object with Id = {id} not exist");

            return Ok(_messageRepository.Edit(id, message));
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //if (!_messageRepository.GetAll().Where(m => m.Id == id).Any())
            //    return BadRequest($"Object with Id = {id} not exist");

            _messageRepository.Delete(id);

            return Ok();
        }
    }
}
