using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Data;
using PersonalFinance.Dtos;
using PersonalFinance.Models;

namespace PersonalFinance.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionsController(ApplicationDbContext _context, IMapper _mapper) : Controller
{
    // GET
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var transactions = await _context.Transactions.ToListAsync();
        if (!transactions.Any())
        {
            return NotFound("no transactions are found, create one first ");
        }

        var dtos = _mapper.Map<TransactionDto>(transactions);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var entity = await _context.Transactions.FindAsync(id);
        if (entity == null)
        {
            return NotFound("Requested Transaction was not found");
        }

        var dto = _mapper.Map<TransactionDto>(entity);
        return Ok(dto);
    }
[HttpPost]
    public async Task<IActionResult> CreateAsync(TransactionCreateDto? transaction)
    {
        var data = _mapper.Map<Transaction>(transaction);
        
        if (transaction == null)
        {
            return BadRequest("Transaction data can't be null");
        }
        
        await _context.AddAsync(data);

        await _context.SaveChangesAsync();
        
        var dto = _mapper.Map<TransactionCreateDto>(data);

        return CreatedAtAction(nameof(GetById), new { id = data.Id }, dto);
        
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, TransactionUpdateDto dto)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction == null)
        {
            return NotFound("transaction to be updated is not found");
        }

        _mapper.Map(dto, transaction);

        _context.Transactions.Update(transaction);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction == null)
        {
            return NotFound("transaction to be deleted is not found");
        }

        _context.Transactions.Remove(transaction);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}