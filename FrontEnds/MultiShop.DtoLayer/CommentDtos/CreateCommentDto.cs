namespace MultiShop.DtoLayer.CommentDtos
{
    public class CreateCommentDto
    {
        public string UserCommentNameSurname { get; set; }
        public string? UserCommentImageUrl { get; set; }
        public string UserCommentEmail { get; set; }
        public string UserCommentCommentDetail { get; set; }
        public int UserCommentRating { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool UserCommentStatus { get; set; }
        public string ProductId { get; set; }
    }
}
