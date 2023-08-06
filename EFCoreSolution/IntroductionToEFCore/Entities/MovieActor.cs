namespace IntroductionToEFCore.Entities
{
    //Junction table, I adding this Entity because I need to set its own properties beside of the foreign keys
    public class MovieActor
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!; //navegation property

        //
        public int ActorId { get ; set; }
        public Actor Actor { get; set; } = null!; //navegation property

        // Its own properties
        public string Character { get; set; } = null!;
        public int SearchOrder { get; set; }
    }
}
