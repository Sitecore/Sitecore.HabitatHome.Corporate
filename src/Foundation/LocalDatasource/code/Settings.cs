namespace Sitecore.HabitatHome.Foundation.LocalDatasource
{
    public static class Settings
    {
        private static readonly string LocalDatasourceFolderNameSetting = "Sitecore.HabitatHome.Foundation.LocalDatasource.LocalDatasourceFolderName";
        private static readonly string LocalDatasourceFolderNameDefault = "_Local";
        private static readonly string LocalDatasourceFolderTemplateSetting = "Sitecore.HabitatHome.Foundation.LocalDatasource.LocalDatasourceFolderTemplate";

        public static string LocalDatasourceFolderName => Configuration.Settings.GetSetting(LocalDatasourceFolderNameSetting, LocalDatasourceFolderNameDefault);
        public static string LocalDatasourceFolderTemplate => Configuration.Settings.GetSetting(LocalDatasourceFolderTemplateSetting);
    }
}