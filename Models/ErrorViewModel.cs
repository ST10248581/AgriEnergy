namespace AgriEnergyConnect.Models
{
    public class ErrorViewModel
    {
        public string? Message { get; set; }

        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        public string ControllerName { get; set; }
        public string ControllerAction { get; set; }
    }
}
