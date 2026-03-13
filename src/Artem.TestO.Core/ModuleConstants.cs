using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Settings;

namespace Artem.TestO.Core;

public static class ModuleConstants
{
    public static class Security
    {
        public static class Permissions
        {
            public const string Access = "test-o:access";
            public const string Create = "test-o:create";
            public const string Read = "test-o:read";
            public const string Update = "test-o:update";
            public const string Delete = "test-o:delete";

            public static string[] AllPermissions { get; } =
            [
                Access,
                Create,
                Read,
                Update,
                Delete,
            ];
        }
    }

    public static class Settings
    {
        public static class General
        {
            public static SettingDescriptor TestOEnabled { get; } = new()
            {
                Name = "TestO.Enabled",
                GroupName = "TestO|General",
                ValueType = SettingValueType.Boolean,
                DefaultValue = false,
            };

            public static IEnumerable<SettingDescriptor> AllGeneralSettings
            {
                get
                {
                    yield return TestOEnabled;
                }
            }
        }

        public static IEnumerable<SettingDescriptor> AllSettings
        {
            get
            {
                return General.AllGeneralSettings;
            }
        }
    }
}
