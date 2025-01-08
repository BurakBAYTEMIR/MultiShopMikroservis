namespace MultiShop.Catalog.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public string ContactNameSurname { get; set; }
        public string ContactEmail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
        public bool ContactIsRead { get; set; }
        public DateTime ContactSendDate { get; set; }
    }
}
