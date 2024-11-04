using CarRentalApp.Contexts;
using CarRentalApp.Dtos.Requests;
using CarRentalApp.Dtos.Responses;
using CarRentalApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApp.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarsRentalDbContext _context;

        public CarsController(CarsRentalDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var cars = _context
                .Cars
                .Select(c => new CarsResponseDto(
                    c.Id,
                    c.Make,
                    c.Model,
                    c.Year,
                    c.LicensePlate,
                    c.PricePerDay,
                    new InsuranceResponseDto(
                        c.InsuranceId,
                        c.Insurance.Company,
                        c.Insurance.PolicyNumber,
                        c.Insurance.StartDate,
                        c.Insurance.EndDate,
                        c.Insurance.Price)))
                .ToList();
            
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var car = _context
                .Cars
                .Where(c => c.Id == id)
                .Select(c => new CarsResponseDto(
                    c.Id,
                    c.Make,
                    c.Model,
                    c.Year,
                    c.LicensePlate,
                    c.PricePerDay,
                    new InsuranceResponseDto(
                        c.InsuranceId,
                        c.Insurance.Company,
                        c.Insurance.PolicyNumber,
                        c.Insurance.StartDate,
                        c.Insurance.EndDate,
                        c.Insurance.Price)))
                .FirstOrDefault();

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CarRequestDto carRequestDto)
        {
            var relatedInsurance = _context
                .Insurances
                .FirstOrDefault(i => i.Id == carRequestDto.InsuranceId);

            if (relatedInsurance == null)
            {
                return BadRequest($"Insurance with id = {carRequestDto.InsuranceId} does not exist");
            }
            
            var car = new Car
            {
                Make = carRequestDto.Make,
                Model = carRequestDto.Model,
                Year = carRequestDto.Year,
                LicensePlate = carRequestDto.LicensePlate,
                PricePerDay = carRequestDto.PricePerDay,
                InsuranceId = carRequestDto.InsuranceId,
                Insurance = relatedInsurance
            };
            
            _context.Cars.Add(car);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new {id = car.Id}, car);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, CarRequestDto carRequestDto)
        {
            var car = _context
                .Cars
                .Find(id);
            
            if (car == null)
            {
                return NotFound();
            }
            
            car.Make = carRequestDto.Make;
            car.Model = carRequestDto.Model;
            car.Year = carRequestDto.Year;
            car.LicensePlate = carRequestDto.LicensePlate;
            car.PricePerDay = carRequestDto.PricePerDay;
            
            _context.SaveChanges();
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var car = _context
                .Cars
                .Find(id);
            
            if (car == null)
            {
                return NotFound();
            }
        
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
