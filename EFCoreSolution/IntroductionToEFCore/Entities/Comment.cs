namespace IntroductionToEFCore.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Content { get; set; }  //optional
        public bool Recommend { get; set; }
    }
}
