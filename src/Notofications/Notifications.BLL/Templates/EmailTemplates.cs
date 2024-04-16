namespace Notifications.BLL.Templates
{
    public static class EmailTemplates
    {
        public const string AppointmentEmailTemplate = "<html>" +
                                                    "<body>" +
                                                   "<div>" +
                                                   "<p>Hello</p>" +
                                                   "<p>Your appointment:</p>" +
                                                   "<p>@Model,</p>" +
                                                   "<p>Date and time is @System.DateTime.Now</p>" +
                                                   "</div>" +
                                                    "</body>" +
                                                    "</html>";

        public const string ResultEmailTemplate = "<html>" +
                                                    "<body>" +
                                                   "<div>" +
                                                   "<p>Hello</p>" +
                                                   "<p>Your appointment results:</p>" +
                                                   "<p>@Model,</p>" +
                                                   "<p>Date and time is @System.DateTime.Now</p>" +
                                                   "</div>" +
                                                    "</body>" +
                                                    "</html>";
    }
}
