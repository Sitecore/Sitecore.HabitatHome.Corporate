using System;
using Sitecore.Data.Items;
using Sitecore.Events;
using Sitecore.HabitatHome.Foundation.LocalDatasource.Services;

namespace Sitecore.HabitatHome.Foundation.LocalDatasource.Infrastructure.Events
{
    /// <summary>
    ///     Updates references to local datasource items when item is being copied or created from a branch
    ///     https://reasoncodeexample.com/2013/01/13/changing-sitecore-item-references-when-creating-copying-duplicating-and-cloning/
    ///     Thanks Uli!
    /// </summary>
    public class UpdateLocalDatasourceReferences
    {
        protected void OnItemCopied(object sender, EventArgs args)
        {
            var sourceItem = Event.ExtractParameter(args, 0) as Item;
            if (sourceItem == null)
                return;
            var targetItem = Event.ExtractParameter(args, 1) as Item;
            if (targetItem == null)
                return;
            new UpdateLocalDatasourceReferencesService(sourceItem, targetItem).UpdateAsync();
        }

        protected void OnItemAdded(object sender, EventArgs args)
        {
            var targetItem = Event.ExtractParameter(args, 0) as Item;
            if (targetItem?.Branch?.InnerItem.Children.Count != 1)
                return;
            var branchRoot = targetItem.Branch.InnerItem.Children[0];
            new UpdateLocalDatasourceReferencesService(branchRoot, targetItem).UpdateAsync();
        }
    }
}