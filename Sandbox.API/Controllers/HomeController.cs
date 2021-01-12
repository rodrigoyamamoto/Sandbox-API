using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sandbox.Business.Interfaces;
using Sandbox.Business.Models;
using Sandbox.Data.Context;

namespace Sandbox.API.Controllers
{
    [ApiController()]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository context)
        {
            _userRepository = context;
        }

        [HttpGet("/")]
        public IActionResult Index()
            => Ok();

        [HttpGet("/users")]
        public async Task<IEnumerable<User>> ListAsync()
            => await _userRepository.ListAsync();

        [HttpGet("/users/{id}")]
        public async Task<User> GetUserById(Guid id)
            => await _userRepository.GetByIdAsync(id);

    }
}
