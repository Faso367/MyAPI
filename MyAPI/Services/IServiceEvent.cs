//using static MyAPI.Controllers.Main.ServiceEvent;

//namespace MyAPI.Services
//{
//    public interface IServiceEvent
//    {
//        //public event EventHandler<DescriptionOfEventArgs> NoticeFromService;
//        //public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e) where TEventArgs : EventArgs;
//        //protected virtual void StatusChange(DescriptionOfEventArgs e)
//        //{
//        //    // Сохраняем ссылку на делегат во временной переменной, для обеспечения безопасности потоков
//        //    //EventHandler<DescriptionOfEventArgs> temp = Volatile.Read(ref NoticeFromService);
//        //    EventHandler<DescriptionOfEventArgs> temp = NoticeFromService;
//        //    // Если есть объекты, зарегистрированные для получения уведомления о событии,
//        //    // уведомляем их, чтобы избежать NullReferenceException
//        //    if (temp != null) temp(this, e);
//        //}
//        //public void StatusChange(DescriptionOfEventArgs e);
//    }
//}
