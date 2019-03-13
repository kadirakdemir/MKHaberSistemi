using MKHaberSistemi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MKHaberSistemi.Web.Models
{
    public class CommentModel
    {
        public int HaberId { get; set; }

        public IQueryable<Yorum> Yorumlar { get; set; }
    }

    public class EditCommentModel
    {
        public int HaberId { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "Yorum Ekle")]
        public string Yorum { get; set; }
    }
}