﻿using System.Data.Linq.Mapping;

namespace DomainModel.Entities
{
    [Table(Name = "Products")]
    public class Product
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert, CanBeNull = false)]
        public int ProductID { get; set; }
        [Column]public string Name { get; set; }
        [Column]public string Description { get; set; }
        [Column]public decimal Price { get; set; }
        [Column]public string Category { get; set; }
    }
}
