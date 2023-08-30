using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; } 
        public CategoryDTO Category { get; set; }
        public List<SizeDTO> Sizes { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public  int CategoryId { get; set; }
        
    }

    public class ProductEditDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }

}
