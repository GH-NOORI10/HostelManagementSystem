namespace HostelManagementSystem.Data
{
    public class ReceiveFee
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public DateTime ReceiveFeeDate { get; set; }

        public int StudentMonthlyFeeId { get; set; }
        public StudentMonthlyFee StudentMonthlyFee { get; set; }
    }
}
