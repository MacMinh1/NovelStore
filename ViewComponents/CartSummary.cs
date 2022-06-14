    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovelStore.Models;

namespace NovelStore.ViewComponents
{
    public class CartSummary : ViewComponent
    {
        private MyCart cart;
        public CartSummary(MyCart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}