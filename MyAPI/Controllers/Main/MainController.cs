using Microsoft.AspNetCore.Mvc;
using MyAPI.Data;
using MyAPI.Services;
//using MyAPI.Services.CreateServicesFolder;

namespace MyAPI.Controllers.Main
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {

        private IRepository _repo;
        //private ICreateServices _createServices;
        //private IService1 _service1;

        //public event EventHandler<DescriptionOfEventArgs> NoticeFromService;
        //public delegate void EventHandler<TEventArgs> (object sender, TEventArgs e) where TEventArgs : EventArgs;

        //Прототип метода: void MethodName(object sender, DescriptionOfEventArgs e);

        public MainController(IRepository repo)
        {
            _repo = repo; // Получаем экземпляр интерфейса для доступа ко всем методам его методам
            //_createServices = createServices;
            //_service1 = service1;
            // Создаем экземпляр делегата EventHandler<NewMailEventArgs>,
            // ссылающийся на метод обратного вызова FaxMsg
            // Регистрируем обратный вызов для события NewMail объекта MailManager
            //Service1.
            //    mm.NoticeFromService += FaxMsg;
        }

        [HttpGet]
        public JsonResult Get()
        {
            //return new JsonResult(_repo.GetAllServices());
            //var ekz = new EventHandler();
            return new JsonResult(_repo.GetService(1));
        }

        [HttpPost]
        public JsonResult Post()
        {
            //RepairService.Work();
            return new JsonResult("Work was successfully done");
        }

        //public Fax(Service1 mm)
        //{
        //    // Создаем экземпляр делегата EventHandler<NewMailEventArgs>,
        //    // ссылающийся на метод обратного вызова FaxMsg
        //    // Регистрируем обратный вызов для события NewMail объекта MailManager
        //    mm.NoticeFromService += FaxMsg;
        //}
        // MailManager вызывает этот метод для уведомления
        // объекта Fax о прибытии нового почтового сообщения




        // Этап 3. Определение метода, ответственного за уведомление
        // зарегистрированных объектов о событии
        // Если этот класс изолированный, нужно сделать метод закрытым
        // или невиртуальным

        //// Метод для уведомления подписчиков
        //    protected virtual void StatusChange(DescriptionOfEventArgs e)
        //    {
        //        // Сохраняем ссылку на делегат во временной переменной, для обеспечения безопасности потоков
        //        EventHandler<DescriptionOfEventArgs> temp = Volatile.Read(ref NoticeFromService);
        //    // Если есть объекты, зарегистрированные для получения уведомления о событии,
        //    // уведомляем их, чтобы избежать NullReferenceException
        //    if (temp != null) temp(this, e);
        //    }

    }

    //// Класс для описания данных, которые передаются подписчикам
    //public class DescriptionOfEventArgs : EventArgs
    //{
    //    // Этап 1. Определение типа для хранения информации,
    //    // которая передается получателям уведомления о событии

    //    public string ServiceId { get; private set; }
    //    public string Message { get; private set; }
    //    public DescriptionOfEventArgs(string serviceId, string message)
    //    {
    //        ServiceId = serviceId;
    //        Message = message;
    //    }
    //}
}

