namespace HostelManagementSystem.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Province { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime LeavingDate { get; set; }

        public int? RoomId { get; set; }
        public Room? Room { get; set; }

        
    }
}
