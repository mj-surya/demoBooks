using BookStoreApp.Interface;
using BookStoreApp.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using BookStoreApp.Exceptions;
using BookStoreApp.Models;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _booksService;

        public BookController(IBookService hotelService)
        {
            _booksService = hotelService;
        }
        [HttpPost("AddBook")]
        [Authorize(Roles = "Admin")]
        public ActionResult AddBook([FromForm] IFormCollection data)
        {
            IFormFile file = data.Files["image"];

            if (file != null && file.Length > 0)
            {
                string filename = file.FileName;
                string path = Path.Combine(@".\wwwroot\Images", filename);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            string json = data["json"];
            BookDTO bookDTO = JsonConvert.DeserializeObject<BookDTO>(json);
            bookDTO.Image = file;

            string message = string.Empty;
            try
            {


                var book = _booksService.AddBook(bookDTO);
                if (book != null)
                {
                    return Ok(book);
                }
                message = "Could not add Book";
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            return BadRequest(message);
        }
        [HttpGet]
        public ActionResult GetBooks(string search,string genre)
        {
            string message = string.Empty;
            try
            {
                var result = _booksService.GetBooks(search,genre);
                return Ok(result);

            }
            catch (NoBooksAvailableException ex)
            {
                message = ex.Message;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return BadRequest(message);
        }
        [HttpGet("GetById")]
        public ActionResult GetBookById(int id)
        {
            string message = string.Empty;
            try
            {
                var result = _booksService.GetById(id);
                return Ok(result);

            }
            catch (NoBooksAvailableException ex)
            {
                message = ex.Message;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return BadRequest(message);
        }
        [HttpDelete("RemoveBook")]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveBook(int id)
        {
            string message = string.Empty;
            try
            {
                var result = _booksService.RemoveBook(id);
                if (result)
                {
                    return Ok("Book removed successfully");
                }
                message = "Could not delete Book";
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            return BadRequest(message);

        }
        [HttpPut("UpdateBook")]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateBook(int id, Books books)
        {
            string message = string.Empty;

            try
            {
                var result = _booksService.UpdateBook(id, books);
                if (result != null)
                {
                    return Ok(result);
                }
                message = "Could not update Book";
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            return BadRequest(message);
        }

        [HttpGet("GetByUserId")]
        public ActionResult GetById(string id)
        {
            string message = string.Empty;
            try
            {
                var result = _booksService.GetByUserId(id);
                if (result != null)
                {
                    return Ok(result);
                }
                message = "Could not Get book";
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            return BadRequest(message);
        }
    }
}
