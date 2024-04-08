namespace Services.API.ViewModels.ServiceCategory
{
    public class BaseServiceCategoryViewModel
    {
        public string? CategoryName { get; set; } = string.Empty;
        public DateTime TimeSlotSize { get; set; }
    }
}
