using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerceShopingCartASPNET8.Data;
using ECommerceShopingCartASPNET8.Models;
using ECommerceShopingCartASPNET8.Services;

namespace ECommerceShopingCartASPNET8.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;
        private readonly CartService _cartService;

        public ProductsController(ProductContext context, CartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();

            var cart = _cartService.GetCart();
            foreach (var item in cart.Items)
            {
                var product = products.FirstOrDefault(p => p.Id == item.Product.Id);
                if (product != null)
                {
                    product.Quantity = item.Quantity;
                }
            }

            return View(products);
        }

        
    }
}
