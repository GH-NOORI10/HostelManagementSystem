namespace HostelManagementSystem.Data
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public string RoomType { get; set; }
        public int NoOfBed { get; set; }
        public double PerSeatPrice { get; set; }
        public string RoomStatus { get; set; }

        public int? FloorId { get; set; }
        public Floor? Floor { get; set; }

        public List<Student> Student { get;set; }
        
    }
}
