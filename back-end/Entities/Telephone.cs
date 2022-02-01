namespace Entities
{
    public class Telephone
    {
        public int Id { get; set; }
        public string number { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}