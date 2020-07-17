namespace ItemsPlanning.Pn.Infrastructure.Models
{
    public class PlanningItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ItemNumber { get; set; }
        public string LocationCode { get; set; }
        public string BuildYear { get; set; }
        public string Type { get; set; }
    }
}