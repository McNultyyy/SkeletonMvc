namespace Model.Entities
{
    public class Employee : Entity
    {
        public override int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string KnownAs { get; set; }
    }

}
