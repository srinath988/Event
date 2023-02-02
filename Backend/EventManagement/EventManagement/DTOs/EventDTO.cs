namespace EventManagement.Api.Event.Dtos
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Details { get; set; }
        public DateTime Time { get; set; }
        public string Duration { get; set; }
        public string Comments { get; set; }
    }
}
