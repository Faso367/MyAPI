//using MyAPI.Models;
//using MyAPI.Data;

//namespace MyAPI.Services.CreateServicesFolder
//{
//    public class CreateServices : ICreateServices
//    {
//        public Service service1_db_ekz;
//        public Service service2_db_ekz;
//        public Service service3_db_ekz;

//        public CreateServices(IRepository repo)
//        {

//            var _service1_db_ekz = new Service
//            {
//                Id = 1,
//                Name = "Service1",
//                Description = "Service1Description",
//                CreatedAt = DateTime.Now,
//                Status = "DontWork"
//            };
//            service1_db_ekz = _service1_db_ekz;
//            var _service2_db_ekz = new Service
//            {
//                Id = 2,
//                Name = "Service2",
//                Description = "Service2Description",
//                CreatedAt = DateTime.Now,
//                Status = "DontWork"
//            };
//            service2_db_ekz = _service1_db_ekz;
//            var _service3_db_ekz = new Service
//            {
//                Id = 3,
//                Name = "Service3",
//                Description = "Service3Description",
//                CreatedAt = DateTime.Now,
//                Status = "DontWork"
//            };
//            service3_db_ekz = _service3_db_ekz;

//            repo.AddService(service1_db_ekz);
//            repo.AddService(service2_db_ekz);
//            repo.AddService(service3_db_ekz);

//        }
//    }
//}
