namespace HostelManagementSystem.Data
{
    public class StudentMonthlyFee
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public string Fee { get; set; }
        public string AdmissionFee { get; set; }

        public int? StudentId { get; set; }
        public Student? Student { get; set; }

        public List<ReceiveFee> ReceiveFee { get; set; }
    }
}
