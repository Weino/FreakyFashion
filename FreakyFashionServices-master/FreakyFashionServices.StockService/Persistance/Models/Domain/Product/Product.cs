﻿namespace FreakyFashionServices.StockService.Models.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ArticleNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
        public string UrlSlug { get; set; }
    }
}
