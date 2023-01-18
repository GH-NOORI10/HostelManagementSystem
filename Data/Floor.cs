namespace HostelManagementSystem.Data
{
    public class Floor
    {
        public int Id { get; set; }
        public string FloorLocation { get; set; }

        public List<Room> Room { get; set; }
    }
}
