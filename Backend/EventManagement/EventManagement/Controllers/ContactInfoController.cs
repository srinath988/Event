using EventManagement.Models;
using EventManagementRepository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactInfoController : ControllerBase
{

    private readonly EventManagementContext _dbcontext;
    public ContactInfoController(EventManagementContext _dbcontext)
    {
        this._dbcontext = _dbcontext;
    }

    //[httpget("getcontactinfo")]
    //public async task<actionresult<list<dto.contact>?>> getallcontact()
    //{
    //    var list = await _dbcontext.contactsinfos.select(c => new dto.contact
    //    {
    //        message = c.message,
    //        phone = c.phone,
    //        useremail = c.useremail,
    //        username = c.username
    //    }).tolistasync();

    //    console.writeline(list);

    //    if (list.count < 0)
    //    {
    //        return notfound(list);
    //    }

    //    return ok(list);
    //}


    [HttpPost("insertcontactinfo")]
    public async Task<HttpStatusCode> insert(Contact contact)
    {
        try
        {
            var entity = new ContactsInfo()
            {
                Message = contact.Message,
                Phone = contact.phone,
                UserEmail = contact.UserEmail,
                UserName = contact.UserName
            };
            await _dbcontext.ContactsInfos.AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}

    //[httpdelete("deleteuser/{phone}")]
    //public async task<httpstatuscode> deleteuser(string phone)
    //{
    //    var entity = new contactsinfo()
    //    {
    //        phone = phone,
    //    };
    //    _dbcontext.contactsinfos.attach(entity);
    //    _dbcontext.contactsinfos.remove(entity);
    //    await _dbcontext.savechangesasync();
    //    return httpstatuscode.ok;
    //}

