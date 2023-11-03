using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Numerics;


namespace MyAPI.Models
{
    public class Service
    {
        public bool isFirstTime { get; set; }
        public Stopwatch? Timer { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        //public string StatusHistory { get; set; } //БЫЛО
        public List<History> StatusHistory { get; set; }

        public int? WorkTime { get; set; }
        public int? BadWorkTime { get; set; }
        public int? DownTime { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
