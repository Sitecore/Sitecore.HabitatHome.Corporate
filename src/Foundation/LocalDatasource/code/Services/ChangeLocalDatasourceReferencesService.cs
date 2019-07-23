using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.HabitatHome.Foundation.LocalDatasource.Extensions;
using Sitecore.Jobs;

namespace Sitecore.HabitatHome.Foundation.LocalDatasource.Services
{
    public class UpdateLocalDatasourceReferencesService
    {
        public UpdateLocalDatasourceReferencesService(Item source, Item target)
        {
            Assert.ArgumentNotNull(source, nameof(source));
            Assert.ArgumentNotNull(target, nameof(target));
            Source = source;
            Target = target;
        }

        public Item Source { get; }

        public Item Target { get; }

        public void UpdateAsync()
        {
            var jobCategory = typeof(UpdateLocalDatasourceReferencesService).Name;
            var siteName = Context.Site == null ? "No Site Context" : Context.Site.Name;
            var jobOptions = new DefaultJobOptions(GetJobName(), jobCategory, siteName, this, nameof(Update));
            JobManager.Start(jobOptions);
        }

        private string GetJobName()
        {
            return $"Resolving item references between source {AuditFormatter.FormatItem(Source)} and target {AuditFormatter.FormatItem(Target)}.";
        }

        public void Update()
        {
            var referenceReplacer = new ItemReferenceReplacer();
            var dependencies = Source.GetLocalDatasourceDependencies();
            foreach (var sourceDependencyItem in dependencies)
            {
                var targetDependencyItem = GetTargetDependency(sourceDependencyItem);
                if (targetDependencyItem == null)
                {
                    Log.Warn($"ChangeLocalDatasourceReferences: Could not resolve {sourceDependencyItem.Paths.FullPath} on {Target.Paths.FullPath}", this);
                    continue;
                }

                referenceReplacer.AddItemPair(sourceDependencyItem, targetDependencyItem);
            }

            referenceReplacer.ReplaceItemReferences(Target);
        }

        private Item GetTargetDependency(Item sourceDependencyItem)
        {
            var sourcePath = sourceDependencyItem.Paths.FullPath;
            var relativePath = sourcePath.Remove(0, Source.Paths.FullPath.Length);
            var targetPath = Target.Paths.FullPath + relativePath;
            return Target.Database.GetItem(targetPath);
        }
    }
}