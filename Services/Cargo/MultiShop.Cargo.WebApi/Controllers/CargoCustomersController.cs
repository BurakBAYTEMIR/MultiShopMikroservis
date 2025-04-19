using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerAddress = createCargoCustomerDto.CargoCustomerAddress,
                CargoCustomerCity = createCargoCustomerDto.CargoCustomerCity,
                CargoCustomerDistrict = createCargoCustomerDto.CargoCustomerDistrict,
                CargoCustomerEmail = createCargoCustomerDto.CargoCustomerEmail,
                CargoCustomerName = createCargoCustomerDto.CargoCustomerName,
                CargoCustomerPhone = createCargoCustomerDto.CargoCustomerPhone,
                CargoCustomerSurname = createCargoCustomerDto.CargoCustomerSurname,
                UserCustomerId = createCargoCustomerDto.UserCustomerId
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Kargo müşterisi oluşturldu");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo müşterisi silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var values = _cargoCustomerService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                CargoCustomerAddress = updateCargoCustomerDto.CargoCustomerAddress,
                CargoCustomerCity = updateCargoCustomerDto.CargoCustomerCity,
                CargoCustomerDistrict = updateCargoCustomerDto.CargoCustomerDistrict,
                CargoCustomerEmail = updateCargoCustomerDto.CargoCustomerEmail,
                CargoCustomerName = updateCargoCustomerDto.CargoCustomerName,
                CargoCustomerPhone = updateCargoCustomerDto.CargoCustomerPhone,
                CargoCustomerSurname = updateCargoCustomerDto.CargoCustomerSurname,
                UserCustomerId = updateCargoCustomerDto.UserCustomerId
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo müşterisi güncellendi");
        }

        [HttpGet("GetCargoCustomerById")]
        public IActionResult GetCargoCustomer(string id) 
        {
            var values = _cargoCustomerService.TGetCargoCustomerById(id);
            return Ok(values);
        }
    }
}
