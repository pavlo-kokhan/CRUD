using CarRentalApp.Contexts;
using CarRentalApp.Dtos.Requests;
using CarRentalApp.Dtos.Responses;
using CarRentalApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApp.Controllers;

[Route("api/insurances")]
[ApiController]
public class InsurancesController : ControllerBase
{
    private readonly CarsRentalDbContext _context;

    public InsurancesController(CarsRentalDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var insurances = _context
            .Insurances
            .Select(i => new InsuranceResponseDto(
                i.Id,
                i.Company,
                i.PolicyNumber,
                i.StartDate,
                i.EndDate,
                i.Price))
            .ToList();

        return Ok(insurances);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var insurance = _context
            .Insurances
            .Where(i => i.Id == id)
            .Select(i => new InsuranceResponseDto(
                i.Id,
                i.Company,
                i.PolicyNumber,
                i.StartDate,
                i.EndDate,
                i.Price))
            .FirstOrDefault();

        if (insurance == null)
        {
            return NotFound();
        }

        return Ok(insurance);
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] InsuranceRequestDto insuranceRequestDto)
    {
        var insurance = new Insurance()
        {
            Company = insuranceRequestDto.Company,
            PolicyNumber = insuranceRequestDto.PolicyNumber,
            StartDate = insuranceRequestDto.StartDate,
            EndDate = insuranceRequestDto.EndDate,
            Price = insuranceRequestDto.Price
        };
        
        _context.Insurances.Add(insurance);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new {id = insurance.Id}, insurance);
    }
    
    [HttpPut("{id}")]
    public IActionResult Put([FromRoute] int id, InsuranceRequestDto insuranceRequestDto)
    {
        var insurance = _context.Insurances.Find(id);
        if (insurance == null)
        {
            return NotFound();
        }
            
        insurance.Company = insuranceRequestDto.Company;
        insurance.PolicyNumber = insuranceRequestDto.PolicyNumber;
        insurance.StartDate = insuranceRequestDto.StartDate;
        insurance.EndDate = insuranceRequestDto.EndDate;
        insurance.Price = insuranceRequestDto.Price;
            
        _context.SaveChanges();
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var insurance = _context.Insurances.Find(id);
        if (insurance == null)
        {
            return NotFound();
        }

        _context.Insurances.Remove(insurance);
        _context.SaveChanges();
        return Ok();
    }
}