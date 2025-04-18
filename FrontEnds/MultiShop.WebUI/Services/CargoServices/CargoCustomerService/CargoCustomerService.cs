﻿using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerService
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("cargoCustomers/GetCargoCustomerById?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetCargoCustomerByIdDto>();
            return values;
        }
    }
}
