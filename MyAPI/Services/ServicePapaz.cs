namespace MyAPI.Services
{
    public class ServicePapaz
    {
        public event EventHandler<DescriptionOfEventArgs> NoticeFromService;
        public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e) where TEventArgs : EventArgs;

        // Метод для уведомления подписчиков
        public void StatusChange(DescriptionOfEventArgs e)
        //public void StatusChange(DescriptionOfEventArgs e)
        {
            // Сохраняем ссылку на делегат во временной переменной, для обеспечения безопасности потоков
            EventHandler<DescriptionOfEventArgs> temp = Volatile.Read(ref NoticeFromService);

            // Если есть объекты, зарегистрированные для получения уведомления о событии,
            // уведомляем их, чтобы избежать NullReferenceException
            if (temp != null)
                temp(this, e);
        }
    }

    // Класс для описания данных, которые передаются подписчикам
    public class DescriptionOfEventArgs : EventArgs
    {
        // Этап 1. Определение типа для хранения информации,
        // которая передается получателям уведомления о событии

        public int ServiceId { get; private set; }
        public string Message { get; private set; }
        public DescriptionOfEventArgs(string message, int serviceId)
        {
            Message = message;
            ServiceId = serviceId;
        }
    }
}
