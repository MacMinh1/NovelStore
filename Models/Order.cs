using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Họ và Tên")]
        [Display(Name = "Họ và Tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng địa chỉ Nhà ")]
        [Display(Name = "Địa Chỉ")]
        public string Line1 { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên Thành Phố")]
        [Display(Name = "Thành Phố")]
        public string City { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên Tỉnh")]
        public string TenTinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Số Điện Thoại")]
        [Display(Name = "Số Điện Thoại")]
        public string Phone { get; set; }

        public string Note { get; set; }

        [BindNever]
        public bool Shipped { get; set; }

    }
}