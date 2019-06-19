using Sitecore.Data.Items;
using Sitecore.Demo.Foundation.SitecoreExtensions.Models;

namespace Sitecore.HabitatHome.Feature.Components.Models
{
    public class Settings : ItemBase
    {
        public MediaItem Logo { get; set; }

        public MediaItem Favicon { get; set; }

        public string Title { get; set; }
    }
}