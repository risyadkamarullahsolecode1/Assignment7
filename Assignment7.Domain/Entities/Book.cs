﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Domain.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        public string? Category { get; set; }
        [Required]
        [MinLength(1)]
        public string? Title { get; set; }
        [Required]
        public string? ISBN { get; set; }
        [Required]
        public string? Author { get; set; }
        [Required]
        [MinLength(1)]
        public string? Publisher { get; set; }
        public string? Description { get; set; }
        [Required]
        [RegularExpression("English|Spanish|French", ErrorMessage = "Language must be English, Spanish or French")]
        public string? Language { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public DateTime? PurchaseDate { get; set; }
        [Required]
        public int? Price { get; set; }
        [Required]
        public int? TotalBook { get; set; }
        public string? DeleteStatus { get; set; }
        public bool DeleteStamp { get; set; }
    }
}
