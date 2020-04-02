using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;

namespace BookListRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet] 
        public IActionResult GetAll()
        {
            return Json(new {data=_db.Books.ToList()});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var book = _db.Books.Find(id);
            if (book == null)
            {
                return Json(new {success = false, message = "Error While Deleting"});
            }

            _db.Books.Remove(book);
            _db.SaveChanges();

            return Json(new {success = true, message = "Delete Successful"});
        }
    }
}