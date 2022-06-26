namespace Core.Entities.Concrete
{
    public class OperationClaim:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Nav

        public List<User> Users { get; set; }=new List<User>();
    }
}