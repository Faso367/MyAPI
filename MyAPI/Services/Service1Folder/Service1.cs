using MyAPI.Controllers.Main;
using MyAPI.Data;

namespace MyAPI.Services.Service1Folder
{
    public class Service1 : ServicePapaz// : IService1
    {
        //private ServicePapaz _SP;

        public Service1()
        {
            //ServicePapaz SP = new ServicePapaz();
            //_SP = SP;
        }

        public async Task Work1()
        {
            //while (true)
            //{
                Console.WriteLine("Service1 начал работу");
                StatusChange(new DescriptionOfEventArgs("Работает", 1));

                //Thread.Sleep(5000);
                await Task.Delay(5000);

                StatusChange(new DescriptionOfEventArgs("Нестабильно работает", 1));

                //Thread.Sleep(2000);
                await Task.Delay(2000);

                StatusChange(new DescriptionOfEventArgs("Не работает", 1));
                Console.WriteLine("Service1 отработал");
            //}
        }
    }
}
        //    // Метод для уведомления подписчиков
        //    private void StatusChange(DescriptionOfEventArgs e)
        //    //public void StatusChange(DescriptionOfEventArgs e)
        //    {
        //        // Сохраняем ссылку на делегат во временной переменной, для обеспечения безопасности потоков
        //        EventHandler<DescriptionOfEventArgs> temp = Volatile.Read(ref NoticeFromService);

        //        // Если есть объекты, зарегистрированные для получения уведомления о событии,
        //        // уведомляем их, чтобы избежать NullReferenceException
        //        if (temp != null) 
        //            temp(this, e);
        //    }
        //}

        //// Класс для описания данных, которые передаются подписчикам
        //public class DescriptionOfEventArgs : EventArgs
        //{
        //    // Этап 1. Определение типа для хранения информации,
        //    // которая передается получателям уведомления о событии

        //    public int ServiceId { get; private set; }
        //    public string Message { get; private set; }
        //    public DescriptionOfEventArgs(string message, int serviceId)
        //    {
        //        Message = message;
        //        ServiceId = serviceId;
        //    }
        //}
//    }
//}
