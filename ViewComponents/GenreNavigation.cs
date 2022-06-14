using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovelStore.Models;

namespace NovelStore.ViewComponents
{
    public class GenreNavigation : ViewComponent
    {
        private INovelStoreRepository repository;
        public GenreNavigation(INovelStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.Novels
            .Select(x => x.Genre)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}