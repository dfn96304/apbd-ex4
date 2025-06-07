using apbd_ex4.DTOs;
using apbd_ex4.Models;
using apbd_ex4.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_ex4.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IDbService _dbService;

    public BooksController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks(DateTime? releaseDate)
    {
        var books = await _dbService.GetBooks(releaseDate);
        return Ok(books);
    }

    /*[HttpPost]
    public async Task<IActionResult> NewBook([FromBody] NewBookDTO book)
    {
        
    }*/
}