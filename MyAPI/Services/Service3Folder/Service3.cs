//namespace MyAPI.Services.Service3Folder
//{
//    public class Service3// : IService3
//    {
//        //private IRepository _repo;
//        public event EventHandler<DescriptionOfEventArgs> NoticeFromService;
//        public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e) where TEventArgs : EventArgs;

//        public Service3()
//        {
//        }

//        public void Work3()
//        {
//            Console.WriteLine("Service3 начал работу");
//            StatusChange(new DescriptionOfEventArgs("Работает", 3));
//            int x = 0;
//            for (int i = 500000; i < 0; i++)
//                x++;

//            for (int i = 200000; i < 0; i++)
//                x++;
//            StatusChange(new DescriptionOfEventArgs("Нестабильно работает", 3));

//            for (int i = 500000; i < 0; i++)
//                x++;

//            StatusChange(new DescriptionOfEventArgs("Не работает", 3));
//            Console.WriteLine("Service2 отработал");
//        }

//        // Метод для уведомления подписчиков
//        private void StatusChange(DescriptionOfEventArgs e)
//        //public void StatusChange(DescriptionOfEventArgs e)
//        {
//            // Сохраняем ссылку на делегат во временной переменной, для обеспечения безопасности потоков
//            EventHandler<DescriptionOfEventArgs> temp = Volatile.Read(ref NoticeFromService);

//            // Если есть объекты, зарегистрированные для получения уведомления о событии,
//            // уведомляем их, чтобы избежать NullReferenceException
//            if (temp != null)
//                temp(this, e);
//        }
//    }

//    // Класс для описания данных, которые передаются подписчикам
//    public class DescriptionOfEventArgs : EventArgs
//    {
//        // Этап 1. Определение типа для хранения информации,
//        // которая передается получателям уведомления о событии

//        public int ServiceId { get; private set; }
//        public string Message { get; private set; }
//        public DescriptionOfEventArgs(string message, int serviceId)
//        {
//            Message = message;
//            ServiceId = serviceId;
//        }
//    }
//}
//}
