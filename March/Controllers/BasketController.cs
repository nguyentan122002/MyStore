﻿using March.Context;
using March.Dtos;
using March.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace March.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly StoreDbContext _context;

        public BasketController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetBasket")]
        public async Task<ActionResult<BasketDto>> GetBasket()
        {
            var basket = await RetrieveBasket();

            if (basket != null)
            {
                return MapbasketToDto(basket);
            }

            else
            {
                return NotFound();
            }
        }



        [HttpPost]
        public async Task<ActionResult<BasketDto>> AddItemToBasket(int productId, int quantity)
        {
            var basket = await RetrieveBasket();

            if (basket == null)
            {
                basket = CreateBasket();
            }

            var product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            else
            {
                basket.AddItem(product, quantity);
            }

            var result = await _context.SaveChangesAsync() > 0;

            if (result)
            {
                return CreatedAtRoute("GetBasket",MapbasketToDto(basket));
            }

            return BadRequest(new ProblemDetails { Title = "Problem saving item to basket" });
        }



        [HttpDelete]

        public async Task<ActionResult> RemoveItemToBasket(int productId, int quantity)
        {
            var basket = await RetrieveBasket();

            if (basket == null)
            {
                return NotFound();
            }
            else
            {
                basket.RemoveItem(productId, quantity);
            } 
            
            var result = await _context.SaveChangesAsync() > 0;

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new ProblemDetails { Title = "Problem removing item from the basket" });
            }
        }


        private async Task<Basket> RetrieveBasket()
        {
            return await _context.Baskets.Include(i => i.Items)
                                         .ThenInclude(p => p.Product)
                                         .FirstOrDefaultAsync(x => x.BuyerId == Request.Cookies["buyerId"]);
        }

        private Basket CreateBasket()
        {
            var buyerId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(30) };
            Response.Cookies.Append("buyerId", buyerId, cookieOptions);
            var basket = new Basket { BuyerId = buyerId };
            _context.Baskets.Add(basket);
            return basket;
        }

        private BasketDto MapbasketToDto(Basket basket)
        {
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(item => new BasketItemDto
                {
                    ProductId = item.ProductId,
                    Name = item.Product.Name,
                    Price = item.Product.Price,
                    PictureUrl = item.Product.PictureUrl,
                    Type = item.Product.Type,
                    Brand = item.Product.Brand,
                    Quantity = item.Quantity,
                }).ToList()
            };
        }
    }
}
