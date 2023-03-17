using CRUD_API.Data;
using CRUD_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly ContactApiDbContext dbContext;

        public ContactController(ContactApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //get all items
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
        }
        //get item by id
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);

            if(contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }
        //create item
        [HttpPost]
        public async Task<IActionResult> AddContacts(ContactsModel addContactReq)
        {
            var contact = new ContactsModel()
            {
                Id = Guid.NewGuid(),
                Code= addContactReq.Code,
                Firstname= addContactReq.Firstname,
                Surename= addContactReq.Surename,
                Address1 = addContactReq.Address1,
                Address2 = addContactReq.Address2,
                DoB = addContactReq.DoB,
                Status= addContactReq.Status,
                Initials = addContactReq.Initials,
            };

            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();

            return Ok(contact);
        }
        //update item
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpadateContact([FromRoute] Guid id, ContactsModel updateContactReq)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if(contact !=null)
            {
                contact.Initials = updateContactReq.Initials;
                contact.Code = updateContactReq.Code;
                contact.Firstname = updateContactReq.Firstname;
                contact.Address1 = updateContactReq.Address1;
                contact.Address2 = updateContactReq.Address2;
                contact.DoB= updateContactReq.DoB;
                contact.Status = updateContactReq.Status;


                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }
        //delete item
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if(contact != null)
            {
               dbContext.Remove(contact);
               await dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }
    }
}
