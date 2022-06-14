using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NovelStore.MyTagHelper;
using NovelStore.Models;
using System.Linq;

namespace NovelStore.Pages
{
    public class MyCartModel : PageModel
    {
        private INovelStoreRepository repository;
        public MyCartModel(INovelStoreRepository repo, MyCart myCartService)
        {
            repository = repo;
            myCart = myCartService;
        }
        public MyCart myCart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long novelId, string returnUrl)
        {
            Novel novel = repository.Novels
            .FirstOrDefault(b => b.NovelId == novelId);
            myCart.AddItem(novel, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long novelId, string returnUrl)
        {
            myCart.RemoveLine(myCart.Lines.First(cl =>
            cl.Novel.NovelId == novelId).Novel);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }

}
