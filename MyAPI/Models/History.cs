using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace MyAPI.Models
{
    [Owned]
    public class History
    {
        //public History(int id, string record) 
        public History(string record)
        {
        //    Id = id;
            Record = record;
        }


        //public int Id { get; set; }
        public string Record { get; set; }
        //public int Id { get; set; }
        //public virtual Service Service { get; set; }
    }
}
