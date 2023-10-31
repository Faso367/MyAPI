//using MyAPI.Services.Service1Folder;

namespace MyAPI.Services.Service2Folder
{
    public class Service2 : ServicePapaz// : IService1
    {
        //private ServicePapaz _SP;

        public Service2()
        {
            //ServicePapaz SP = new ServicePapaz();
            //_SP = SP;
        }

        public void Work2()
        {
            //Console.WriteLine("Service2 начал работу");
            //StatusChange(new DescriptionOfEventArgs("Работает", 2));
            //int x = 0;
            //for (int i = 1000000; i < 0; i++)
            //    x++;

            //for (int i = 500000; i < 0; i++)
            //    x++;
            //StatusChange(new DescriptionOfEventArgs("Нестабильно работает", 2));

            //for (int i = 1000000; i < 0; i++)
            //    x++;

            //StatusChange(new DescriptionOfEventArgs("Не работает", 2));
            //Console.WriteLine("Service2 отработал");

            Console.WriteLine("Service2 начал работу");
            StatusChange(new DescriptionOfEventArgs("Работает", 2));
            int x = 0;
            Thread.Sleep(4000);
            //for (int i = 1000000; i < 0; i++)
            //    x++;

            //for (int i = 500000; i < 0; i++)
            //    x++;
            StatusChange(new DescriptionOfEventArgs("Нестабильно работает", 2));

            Thread.Sleep(1000);
            //for (int i = 1000000; i < 0; i++)
            //    x++;

            StatusChange(new DescriptionOfEventArgs("Не работает", 2));
            Console.WriteLine("Service2 отработал");
        }
    }
}

