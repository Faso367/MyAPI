using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Numerics;


namespace MyAPI.Models
{
    //[Keyless]
    public class Service
    {
        //[Key] // Помечаем, что это первичный ключ (уникальный ID)


        public bool isFirstTime { get; set; }
        //[Keyless] ???????
        public Stopwatch? Timer { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        //public int HistorySize { get; private set; }

        //public List<History> StatusHistory { get; set; }

        //[NotMapped]
        //public string[] History
        //{
        //    get
        //    {
        //        var tab = this.StatusHistory.Split(',');
        //        return tab.ToArray();
        //    }
        //    set
        //    {

        //        //this.StatusHistory += 
        //        //this.StatusHistory = string.Join(",", value);
        //        this.StatusHistory = string.Join(",", value);
        //        //this.StatusHistory
        //    }
        //}

        public string StatusHistory { get; set; }

        public int? WorkTime { get; set; }
        public int? BadWorkTime { get; set; }
        public int? DownTime { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime? UpdatedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        //    public ICollection<History>? StatusRecords { get; set; }
        //    public Service()
        //    {
        //        StatusRecords = new List<History>();
        //    }
        //}

        //public class History
        //{
        //    public int Id { get; set; }
        //    public string Record { get; set; }
        //}
    }
}
