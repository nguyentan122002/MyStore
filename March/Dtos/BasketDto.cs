﻿using March.Models;

namespace March.Dtos
{
    public class BasketDto
    {
        public int Id { get; set; }

        public string BuyerId { get; set; }

        public List<BasketItemDto> Items { get; set; }
    }
}
