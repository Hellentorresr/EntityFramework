namespace IntroductionToEFCore.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Furtune { get; set; }
        public DateTime Birthday { get; set; }

        //setting the relationship many to many with MovieActor table
        public List<MovieActor> MovieActors { get; set; } = new List<MovieActor>(); //List, because I need to order movieActor
    }
}
