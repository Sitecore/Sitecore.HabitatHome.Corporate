using Sitecore.Data;

namespace Sitecore.HabitatHome.Feature.Components
{
    public struct Templates
    {
        public struct NavigationBase
        {
            public static readonly ID ID = new ID("{3A1E055A-9933-4F01-BFB1-E123F221D0CB}");

            public struct Fields
            {
                public static readonly ID NavigationTitle = new ID("{03F0061A-309D-4732-A722-2F2A1488AC60}");
            }
        }

        public struct ContactInfo
        {
            public static readonly string Name = "ContactInfo";

            public struct Fields
            {
                public static readonly string ContactTitle = "Contact Title";

                public static readonly string ContactBody = "Contact Body";
            }
        }
    }
}