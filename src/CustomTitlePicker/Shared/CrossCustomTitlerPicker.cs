using System;

namespace Plugin.CustomTitlePicker
{
    /// <summary>
    /// Cross CustomTitlerPicker
    /// </summary>
    public static class CrossCustomTitlerPicker
    {
        static Lazy<ICustomTitlerPicker> implementation = new Lazy<ICustomTitlerPicker>(() => CreateCustomTitlerPicker(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Gets if the plugin is supported on the current platform.
        /// </summary>
        public static bool IsSupported => implementation.Value == null ? false : true;

        /// <summary>
        /// Current plugin implementation to use
        /// </summary>
        public static ICustomTitlerPicker Current
        {
            get
            {
                ICustomTitlerPicker ret = implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        static ICustomTitlerPicker CreateCustomTitlerPicker()
        {
#if NETSTANDARD1_0 || NETSTANDARD2_0
            return null;
#else
#pragma warning disable IDE0022 // Use expression body for methods
            return new CustomTitlePickerImplementation();
#pragma warning restore IDE0022 // Use expression body for methods
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly() =>
            new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");

    }
}
