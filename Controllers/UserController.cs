using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var users = _context.Users
                .Include(u => u.Interests)
                .Include(u => u.Group)
                .Include(u => u.Gatherings)
                .Include(u => u.Friends)
                .ToList();

            return users;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var user = _context.Users
                .Include(u => u.Interests)
                .Include(u => u.Group)
                .Include(u => u.Gatherings)
                .Include(u => u.Friends)
                .SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }
    }
    }

