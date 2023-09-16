using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Models
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Nazwa kategorii jest wymagana!")]
        [StringLength(100,ErrorMessage ="Minimum 3, minimum 5, minimum 5 i maximum 100 jest dozwolonych", MinimumLength =3)]
        public string CatgoryName { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDelete { get; set; }
    }

    public class ProductDetails
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Nazwa produktu jest wymagana!")]
        [StringLength(100, ErrorMessage = "Minimum 3, minimum 5, minimum 5 i maximum 100 jest dozwolonych", MinimumLength = 3)]
        public string ProductName { get; set; }
        [Required]
        [Range(1,50)]
        public Nullable<int> CategoryId { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        [Required(ErrorMessage ="Opis jest wymagany!")]
        public Nullable<System.DateTime> Description { get; set; }
        public string ProductImage { get; set; }
        public Nullable<bool> IsFeatured { get; set; }
        [Required]
        [Range(typeof(int), "1","500",ErrorMessage ="Nieprawidłowa ilość!")]
        public Nullable<int> Quantify { get; set; }
        [Required]
        [Range(typeof(decimal), "1","200000", ErrorMessage ="Nieprawidłowa cena!")]
        public Nullable<decimal> Price { get; set; }
        public SelectList Categories { get; set; }
    }
}