namespace School.DataAccess.Entities
{
    public class Course : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Mark { get; set; }
    }
}
