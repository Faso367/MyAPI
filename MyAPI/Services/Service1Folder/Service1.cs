using MyAPI.Controllers.Main;
using MyAPI.Data;
//using MyAPI.Services.Service1Folder;

namespace MyAPI.Services.Service1Folder
{
    //public class Service1 : IService1, IServiceEvent
    public class Service1 : IService1
    {
        //private IRepository _repo;
        public event EventHandler<DescriptionOfEventArgs> NoticeFromService;
        public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e) where TEventArgs : EventArgs;

        //public Service1(IRepository repo)
        //{
        //    _repo = repo; // Получаем экземпляр интерфейса для доступа ко всем методам его методам
        //}


        public Service1()
        {
            //Work1();
        }

        public void Work1()
        {
            Console.WriteLine("Service1 начал работу");

            //while (true)
            //{
                //_repo.
                StatusChange(new DescriptionOfEventArgs("Работает", 1));
                int x = 0;
                for (int i = 500000; i < 0; i++)
                    x++;

            for (int i = 200000; i < 0; i++)
                x++;
            StatusChange(new DescriptionOfEventArgs("Нестабильно работает", 1));

                for (int i = 500000; i < 0; i++)
                    x++;

                //return "Не работает";
                StatusChange(new DescriptionOfEventArgs("Не работает", 1));
            //}
            Console.WriteLine("Service1 отработал");
        }

        // Метод для уведомления подписчиков
        private void StatusChange(DescriptionOfEventArgs e)
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



    // Определение типа, унаследованного от EventArgs для этого события
    //public class FooEventArgs : EventArgs { }
    //    public class TypeWithLotsOfEvents
    //    {
    //        // Определение закрытого экземплярного поля, ссылающегося на коллекцию.
    //        // Коллекция управляет множеством пар "Event/Delegate"
    //        // Примечание: Тип EventSet не входит в FCL,
    //        // это мой собственный тип
    //        private readonly EventSet m_eventSet = new EventSet();
    //        // Защищенное свойство позволяет производным типам работать с коллекцией
    //        protected EventSet EventSet { get { return m_eventSet; } }
    //        #region Code to support the Foo event (repeat this pattern for additional events)
    //        // Определение членов, необходимых для события Foo.
    //        // 2a. Создайте статический, доступный только для чтения объект
    //        // для идентификации события.
    //        // Каждый объект имеет свой хеш-код для нахождения связанного списка
    //        // делегатов события в коллекции.
    //        protected static readonly EventKey s_fooEventKey = new EventKey();
    //        // 2b. Определение для события методов доступа для добавления
    //        // или удаления делегата из коллекции.
    //        public event EventHandler<FooEventArgs> Foo
    //        {
    //            add { m_eventSet.Add(s_fooEventKey, value); }
    //            remove { m_eventSet.Remove(s_fooEventKey, value); }
    //        }
    //        // 2c. Определение защищенного виртуального метода On для этого события.
    //        protected virtual void OnFoo(FooEventArgs e)
    //        {
    //            m_eventSet.Raise(s_fooEventKey, this, e);
    //        }
    //        // 2d. Определение метода, преобразующего входные данные этого события
    //        public void SimulateFoo() { OnFoo(new FooEventArgs()); }
    //        #endregion
    //    }
}
