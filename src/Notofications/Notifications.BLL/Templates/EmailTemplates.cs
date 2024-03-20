namespace Notifications.BLL.Templates
{
    public static class EmailTemplates
    {
        public const string DefaultEmailTemplate = "<html>" +
                                                    "<body>" +
                                                   "<div>" +
                                                   "<p>Hello</p>" +
                                                   "<p>Office  was deleted</p>" +
                                                   "<p>@Model,</p>" +
                                                   "<p>Date and time is @System.DateTime.Now</p>" +
                                                   "<img src='https://static.mk.ru/upload/entities/2015/05/28/articles/detailPicture/b0/30/c7/818343149_4347189.jpg'>" +
                                                   "</div>" +
                                                    "</body>" +
                                                    "</html>";
    }
}
