using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerService
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id);
    }
}
