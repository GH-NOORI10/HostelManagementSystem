namespace HostelManagementSystem.Data
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CNIC { get; set; }
        public string Phone { get; set; }
        public DateTime ArrivingDate { get; set; }
        public DateTime LeavingDate { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
