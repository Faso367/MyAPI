using System.ComponentModel.DataAnnotations;

namespace MyAPI.Models
{
    public class Service
    {
        [Key] // Помечаем, что это первичный ключ (уникальный ID)
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
