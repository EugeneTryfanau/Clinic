namespace Documents.BLL.Templates
{
    public static class PdfTemplates
    {
        public const string ResultPdfTemplate = "<html>" +
                                                    "<body>" +
                                                   "<div>" +
                                                   "<p>Hello</p>" +
                                                   "<p>Your appointment result:</p>" +
                                                   "<p>@Model,</p>" +
                                                   "<p>Date and time is @System.DateTime.Now</p>" +
                                                   "</div>" +
                                                    "</body>" +
                                                    "</html>";
    }
}
