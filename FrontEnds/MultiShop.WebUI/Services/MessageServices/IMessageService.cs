using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultInBoxMessageDto>> GetInBoxMessageAsync(string id);
        Task<List<ResultSendBoxMessageDto>> GetSendBoxMessageAsync(string id);
    }
}
