namespace DailyClientMeet.Models
{
    public class ServiceRequest
    {

        public int SrNo { get; set; }

        public string ICTId { get; set; } = "";

        public DateTime CreatedDate { get; set; }

        public string BusinessPOC { get; set; } = "";

        public string Status { get; set; } = "";

        public string Description { get; set; } = "";
    }
}
