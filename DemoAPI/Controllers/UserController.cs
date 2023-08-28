using MediatorDemoLibrary.Commands;
using MediatorDemoLibrary.Models;
using MediatorDemoLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<List<UserModel>> Get()
        {
            return await _mediator.Send(new GetUsersListQuery());
        }

        // GET api/<UserController>/id
        [HttpGet("{id}")]
        public async Task<UserModel>Get(int id)
        {
            return await _mediator.Send(new GetUserByIDQuery(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<UserModel> Post([FromBody] UserModel value)
        {
            //var model= new InsertUserCommand(value.Name, value.Email);
            //return await _mediator.Send(model);
            return await _mediator.Send(request:new InsertUserCommand(value.Name, value.Email));
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<UserModel> Put(int id, [FromBody] UserModel value)
        {
            return await _mediator.Send(request:new UpdateUserCommand(value.Id, value.Name,value.Email));
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<List<UserModel>> Delete(int id)
        {
            return await _mediator.Send(request: new DeleteUserCommand(id));
        }
    }
}
