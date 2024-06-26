﻿using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public string ThemeColor { get; set; }
    }
}
