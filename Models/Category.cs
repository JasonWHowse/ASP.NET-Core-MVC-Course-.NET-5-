using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rocku.Models {
    public class Category {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Required(ErrorMessage = "<font style=\"background-color:#000000\" color=\"#00ff00\">WRONG</font>")]
        [Range(1,int.MaxValue,ErrorMessage = "<font style=\"background-color:#000000\" color=\"#00ff00\">Order must be greater <font color=\"#ff0000\">than</font> 0</font>")]
        public int DisplayOrder { get; set; }
    }
}
