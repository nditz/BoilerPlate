namespace Domain.Constants
{
    public static class DomainConstants
    {
        public static class User
        {
            public const int MaxUsernameLength = 50;
            public const int MaxFirstNameLength = 100;
            public const int MaxLastNameLength = 100;
            public const int MaxEmailLength = 255;
        }

        public static class Role
        {
            public const int MaxNameLength = 100;
        }

        public static class Permission
        {
            public const int MaxNameLength = 100;
        }

        public static class Audit
        {
            public const int MaxEntityNameLength = 100;
            public const int MaxActionLength = 50;
            public const int MaxDescriptionLength = 500;
        }
    }
} 