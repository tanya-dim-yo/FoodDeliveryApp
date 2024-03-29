﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class BlogArticle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public virtual IdentityUser User { get; set; } = null!;

        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public int Likes { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public int BlogCategoryId { get; set; }

        [ForeignKey(nameof(BlogCategoryId))]
        public virtual BlogCategory BlogCategory { get; set; } = null!;

        public string[] Tags { get; set; } = Array.Empty<string>();

        public virtual IEnumerable<BlogComment> BlogComments { get; set; } = new List<BlogComment>();
    }
}