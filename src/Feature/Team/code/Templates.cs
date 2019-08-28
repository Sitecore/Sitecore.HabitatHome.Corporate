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

        public struct MemberInfo
        {
            public struct Fields
            {
                public static readonly string TeamMemberPhoto = "Team Member Photo";

                public static readonly string TeamMemberName = "Team Member Name";

                public static readonly string TeamMemberTitle = "Team Member Title";

                public static readonly string TeamMemberDesc = "Team Member Description";
            }
        }
    }
}