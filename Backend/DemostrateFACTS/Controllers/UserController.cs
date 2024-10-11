using Microsoft.AspNetCore.Mvc;
using DemostrateFACTS.Data;
using Microsoft.EntityFrameworkCore;

namespace DemostrateFACTS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UserController(UserDbContext context)
        {
            _context = context;
        }

        // Get all users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.UserMaster.ToListAsync();
            return users.Count > 0 ? Ok(users) : NoContent();
        }

        // Get user by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _context.UserMaster.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            return Ok(user);
        }

        // Update users
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User updatedUser)
        {
            var user = await _context.UserMaster.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            user.UserType = updatedUser.UserType;
            user.UserEmail = updatedUser.UserEmail;
            user.Password = updatedUser.Password;
            user.FirstName = updatedUser.FirstName; 
            user.FamilyName = updatedUser.FamilyName; 
            user.DateLastUpdated = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok(new { message = "User updated successfully." });
        }
    }
}
