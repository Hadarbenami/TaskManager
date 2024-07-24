using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MvcTaskManager.Models
{
    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public class MyTask
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Priority Priority { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Parameterless constructor for model binding
        public MyTask() { }

        // Constructor to initialize Title and Priority
        public MyTask(string title, Priority priority)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Priority = priority;
            CreatedAt = DateTime.Now;
        }
    }
}
