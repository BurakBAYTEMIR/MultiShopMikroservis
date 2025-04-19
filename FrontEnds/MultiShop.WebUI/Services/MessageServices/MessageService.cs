using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInBoxMessageDto>> GetInBoxMessageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5000/services/Message/UserMessage/GetMessageInBox?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultInBoxMessageDto>>();
            return values;
        }

        public async Task<List<ResultSendBoxMessageDto>> GetSendBoxMessageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5000/services/Message/UserMessage/GetMessageSendBox?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSendBoxMessageDto>>();
            return values;
        }
    }
}
