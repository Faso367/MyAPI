namespace MyAPI.Services.Service3Folder
{
    public class Service3 : ServicePapaz// : IService1
    {
        //private ServicePapaz _SP;

        public Service3()
        {
            //ServicePapaz SP = new ServicePapaz();
            //_SP = SP;
        }

        public async Task Work3()
        {
            //Console.WriteLine("Service3 начал работу");
            //StatusChange(new DescriptionOfEventArgs("Работает", 3));
            //int x = 0;
            //for (int i = 1000000; i < 0; i++)
            //    x++;

            //for (int i = 500000; i < 0; i++)
            //    x++;
            //StatusChange(new DescriptionOfEventArgs("Нестабильно работает", 3));

            //for (int i = 1000000; i < 0; i++)
            //    x++;

            //StatusChange(new DescriptionOfEventArgs("Не работает", 3));
            //Console.WriteLine("Service3 отработал");
            //while (true)
            //{
                Console.WriteLine("Service3 начал работу");
                StatusChange(new DescriptionOfEventArgs("Работает", 3));
                //Thread.Sleep(3000); //БЫЛО
                await Task.Delay(3000);

                StatusChange(new DescriptionOfEventArgs("Нестабильно работает", 3));

                //Thread.Sleep(2000);  //БЫЛО
                await Task.Delay(2000);

                StatusChange(new DescriptionOfEventArgs("Не работает", 3));
                Console.WriteLine("Service3 отработал");
            //}
        }
    }
}
