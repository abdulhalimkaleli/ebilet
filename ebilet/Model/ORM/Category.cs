namespace ebilet.Model.ORM
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }

        public ICollection<Event>? Event { get; set;}
    }
}
