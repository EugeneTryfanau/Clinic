namespace Clinic.BLL.Interfaces
{
    public interface IRabbitMqProducerService
    {
        void SendMessage(object obj);
        void SendMessage(string message);
    }
}
