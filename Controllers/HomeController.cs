using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NovelStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NovelStore.Models.ViewModels;

namespace NovelStore.Controllers
{
    public class HomeController : Controller
    {
        private INovelStoreRepository repository;
        public int PageSize = 2;
        public HomeController(INovelStoreRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index(string genre, int novelPage = 1)
         => View(new NovelListViewModel
         {
             Novels = repository.Novels
         .Where(p => genre == null || p.Genre == genre)
         .OrderBy(p => p.NovelId)
         .Skip((novelPage - 1) * PageSize)
         .Take(PageSize),
             PagingInfo = new PagingInfo
             {
                 CurrentPage = novelPage,
                 ItemsPerPage = PageSize,
                 TotalItems = genre == null ?
         repository.Novels.Count() :
         repository.Novels.Where(e =>
         e.Genre == genre).Count()
             },
             CurrentGenre = genre
         });
    }
}
