using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLB_TinHoc_64131060.Models
{
    public class Email_64131060
    {
        [DisplayName("Sender")]
        [Required(ErrorMessage = "Nhập email người gửi")]
        [EmailAddress]
        public string From { get; set; }

        [Required(ErrorMessage = "Nhập mật khẩu của bạn")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Nhập email của người nhận")]
        [EmailAddress]
        public string To { get; set; }

        [Required(ErrorMessage = "Nhập tiêu đề")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Nhập nội dung")]
        public string Body { get; set; }
    }
}