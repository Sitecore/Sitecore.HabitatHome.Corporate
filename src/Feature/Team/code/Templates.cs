using Sitecore.Data;

namespace Sitecore.HabitatHome.Feature.Team
{
    public struct Templates
    {
        public struct ContactInfo
        {
            public static readonly string Name = "ContactInfo";

            public struct Fields
            {
                public static readonly string ContactTitle = "Contact Title";

                public static readonly string ContactBody = "Contact Body";
            }
        }

        public struct MemberPhoto
        {
            public struct Fields
            {
                public static readonly string TeamMemberPhoto = "Team Member Photo";
            }
        }
    }
}