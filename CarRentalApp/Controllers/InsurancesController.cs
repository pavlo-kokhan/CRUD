using CarRentalApp.Contexts;
using CarRentalApp.Dto.Insurances;
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
            .Select(i => new InsuranceDto(
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
            .Select(i => new InsuranceDto(
                i.Id,
                i.Company,
                i.PolicyNumber,
                i.StartDate,
                i.EndDate,
                i.Price))
            .FirstOrDefault();

        if (insurance == null)
        {
            return NotFound($"Insurance with id = {id} does not exist");
        }

        return Ok(insurance);
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] CreateInsuranceDto createInsuranceDto)
    {
        var insurance = new Insurance
        {
            Company = createInsuranceDto.Company,
            PolicyNumber = createInsuranceDto.PolicyNumber,
            StartDate = createInsuranceDto.StartDate,
            EndDate = createInsuranceDto.EndDate,
            Price = createInsuranceDto.Price
        };
        
        _context.Insurances.Add(insurance);
        _context.SaveChanges();
        return Ok();
    }
    
    [HttpPut("{id}")]
    public IActionResult Put([FromRoute] int id, UpdateInsuranceDto updateInsuranceDto)
    {
        var insurance = _context
            .Insurances
            .Find(id);
        
        if (insurance == null)
        {
            return NotFound($"Insurance with id = {id} does not exist");
        }
            
        insurance.Company = updateInsuranceDto.Company;
        insurance.PolicyNumber = updateInsuranceDto.PolicyNumber;
        insurance.StartDate = updateInsuranceDto.StartDate;
        insurance.EndDate = updateInsuranceDto.EndDate;
        insurance.Price = updateInsuranceDto.Price;
            
        _context.SaveChanges();
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var insurance = _context
            .Insurances
            .Find(id);
        
        if (insurance == null)
        {
            return NotFound($"Insurance with id = {id} does not exist");
        }

        _context.Insurances.Remove(insurance);
        _context.SaveChanges();
        return Ok();
    }
}