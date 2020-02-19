﻿using System.Web.Mvc;
using Sitecore.HabitatHome.Feature.News.Repositories;
using Sitecore.HabitatHome.Feature.News.Services;
using Sitecore.Demo.Shared.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Mvc.Presentation;
using Sitecore.Web;

namespace Sitecore.HabitatHome.Feature.News.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;
        private readonly INewsSettingsService _newsSettingsService;
        private Models.News news;

        public NewsController(INewsSettingsService newsSettingsService, INewsRepository newsRepository)
        {
            _newsSettingsService = newsSettingsService;
            _newsRepository = newsRepository;
        }

        public Models.News News => news ?? (news = new Models.News {Item = Context.Item});

        public int NewsOverviewDefaultNumberOfItems
        {
            get
            {
                var defaultNumber = 10;
                var newsSettingsItem = _newsSettingsService.GetNewsSettingsItem();
                if (newsSettingsItem == null) return defaultNumber;
                var number = newsSettingsItem[Templates.NewsSettings.Fields.NewsOverviewDefaultNumberOfItems];
                if (!string.IsNullOrEmpty(number) && int.TryParse(number, out defaultNumber)) return defaultNumber;

                return defaultNumber;
            }
        }

        public ViewResult NewsOverview()
        {
            var queryStringValue = WebUtil.GetQueryString("page", "1");
            if (int.TryParse(queryStringValue, out var page))
            {
            }

            var list = _newsRepository.GetNewsItems(page, NewsOverviewDefaultNumberOfItems);
            return View("~/Areas/News/Views/NewsOverview.cshtml", list);
        }

        public ViewResult LatestNews()
        {
            var numberOfNewsItems = RenderingContext.Current.Rendering.GetIntegerParameter(Templates.RenderingParameters.NumberOfNewsItems.NumberOfNewsItemsFieldName, 4);
            var newsItems = _newsRepository.GetNewsItems(1, numberOfNewsItems);
            return View("~/Areas/News/Views/LatestNews.cshtml", newsItems);
        }

        public ViewResult NewsDetailHeading()
        {
            return View("~/Areas/News/Views/NewsDetailHeading.cshtml", News);
        }

        public ViewResult NewsDetailArticle()
        {
            return View("~/Areas/News/Views/NewsDetailArticle.cshtml", News);
        }
    }
}
