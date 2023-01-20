namespace HostelManagementSystem.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime LeavingDate { get; set; }

        public int? RoomId { get; set; }
        public Room? Room { get; set; }

        
    }
}
