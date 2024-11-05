using CarRentalApp.Contexts;
using CarRentalApp.Dto.Cars;
using CarRentalApp.Dto.Insurances;
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
                .Select(c => new CarDto(
                    c.Id,
                    c.Make,
                    c.Model,
                    c.Year,
                    c.LicensePlate,
                    c.PricePerDay,
                    new InsuranceDto(
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
                .Select(c => new CarDto(
                    c.Id,
                    c.Make,
                    c.Model,
                    c.Year,
                    c.LicensePlate,
                    c.PricePerDay,
                    new InsuranceDto(
                        c.InsuranceId,
                        c.Insurance.Company,
                        c.Insurance.PolicyNumber,
                        c.Insurance.StartDate,
                        c.Insurance.EndDate,
                        c.Insurance.Price)))
                .FirstOrDefault();

            if (car == null)
            {
                return NotFound($"Car with id = {id} does not exist");
            }

            return Ok(car);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateCarDto createCarDto)
        {
            var relatedInsuranceExists = _context
                .Insurances
                .Any(i => i.Id == createCarDto.InsuranceId);

            if (!relatedInsuranceExists)
            {
                return NotFound($"Insurance with id = {createCarDto.InsuranceId} does not exist");
            }
            
            var car = new Car
            {
                Make = createCarDto.Make,
                Model = createCarDto.Model,
                Year = createCarDto.Year,
                LicensePlate = createCarDto.LicensePlate,
                PricePerDay = createCarDto.PricePerDay,
                InsuranceId = createCarDto.InsuranceId,
            };
            
            _context.Cars.Add(car);
            _context.SaveChanges();
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, UpdateCarDto updateCarDto)
        {
            var car = _context
                .Cars
                .Find(id);
            
            if (car == null)
            {
                return NotFound($"Car with id = {id} does not exist");
            }
            
            car.Make = updateCarDto.Make;
            car.Model = updateCarDto.Model;
            car.Year = updateCarDto.Year;
            car.LicensePlate = updateCarDto.LicensePlate;
            car.PricePerDay = updateCarDto.PricePerDay;
            
            _context.SaveChanges();
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var car = _context
                .Cars
                .Find(id);
            
            if (car == null)
            {
                return NotFound($"Car with id = {id} does not exist");
            }
        
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return Ok();
        }
    }
}
