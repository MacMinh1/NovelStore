using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NovelStore.Models
{
    public class Novel
    {
        public long NovelId { get; set; }

        [Display(Name = "Tên Tiểu Thuyết")]
        public string Title { get; set; }

        [Display(Name = "Tác Giả")]
        public string Author { get; set; }

        [Display(Name = "Mô Tả")]
        public string Description { get; set; }
        [Column(TypeName = "decimal(8, 2)")]

        [Display(Name = "Giá Tiền")]
        public decimal Price { get; set; }

        [Display(Name = "Thể Loại")]
        public string Genre { get; set; }
    }
}