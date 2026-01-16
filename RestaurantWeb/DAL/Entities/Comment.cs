namespace RestaurantWeb.DAL.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string Content { get; set; }
        public bool IsSeeHome { get; set; }
    }
}
