using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MvcMusicStore.Infrastructure;

namespace MvcMusicStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

       // [Remote("CheckUserName","Account")]
        public string Username { get; set; }
        [Required(ErrorMessage ="your {0} is required!")]
        [StringLength(160, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "your {0} is required!")]
        [StringLength(160)]
        [MaxWords(10)]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage ="Email doesn't look like a valid email address")]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Email")]
        public string EmailConfirm { get; set; }

        [Range(typeof(decimal), "0.00", "10000.00")]
        public decimal Price { get; set; }

        [Range(35, 50)]
        public int Age { get; set; }

        public decimal Total { get; set; }
        // public List<OrderDetail> OrderDetails { get; set; }

    }
}