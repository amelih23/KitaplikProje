﻿using System.ComponentModel.DataAnnotations;

namespace KitaplikProje.Models
{
    public class Category
    {
        public int CategoryID{ get; set; }
        
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
       
        public List<Product>? Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }


    }
}
