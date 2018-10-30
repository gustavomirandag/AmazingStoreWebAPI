﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleApp.Models.DTO
{
    public class CartItem
    {
        public Guid ProductId { get; set; }
        public string Title { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}