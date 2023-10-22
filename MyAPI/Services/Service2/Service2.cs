namespace MyAPI.Services.Service2
{
    public class Service2 : IService2
    {
        public string Work2()
        {
            int x = 0;
            for (int i = 1000000; i < 0; i++)
                x++;

            return "Сервис 2 отработал";
        }
    }
}
