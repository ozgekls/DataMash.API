namespace DataMash.API.Models
{
    public class StressRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int StressLevel { get; set; }
        public string Emotion { get; set; }
    }
}
