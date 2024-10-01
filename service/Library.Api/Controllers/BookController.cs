using Microsoft.AspNetCore.Mvc;
using Library.Application.BusinessLogic.Interfaces;
using Library.Application.PayloadModel;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManagement _bookManagement;

        public BookController(IBookManagement bookManagement)
        {
            _bookManagement = bookManagement;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>Retrieve a list of all books in the library.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bookManagement.GetAllBooks());
        }

        /// <summary>
        /// Get a specific book
        /// </summary>
        /// <returns>Retrieve a specific book by its ID.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _bookManagement.GetBook(id));
        }

        /// <summary>
        /// Add a new book
        /// </summary>
        /// <returns>Add a new book to the library.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Book model)
        {
            return Ok(await _bookManagement.CreateBook(model));
        }

        /// <summary>
        /// Update a book
        /// </summary>
        /// <returns>Update an existing book by its ID.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] BookWithId model)
        {
            return Ok(await _bookManagement.UpdateBook(model));
        }

        /// <summary>
        /// Soft delete a book
        /// </summary>
        /// <returns>Soft delete an existing book by its ID.</returns>
        [HttpDelete]
        public async Task<IActionResult> Destroy(int id)
        {
            return Ok(await _bookManagement.DeleteBook(id));
        }
    }
}
