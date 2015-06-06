using Microsoft.Win32;

namespace Sunnerberg.Autostarter
{
    /// <summary>
    /// Provides tools to allow an executable to be automatically started upon Windows boot.
    /// </summary>
    public class Autostarter
    {
        private readonly RegistryKey _registryKey =
            Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        private readonly string _executablePath;

        /// <summary>
        /// Path to the executable which should be automatically started.
        /// </summary>
        /// <param name="executablePath">Path to the executable</param>
        public Autostarter(string executablePath)
        {
            _executablePath = executablePath;
        }

        /// <returns>Whether the executable already will be started upon boot</returns>
        public bool IsEnabled()
        {
            return _registryKey.GetValue("ApplicationName") != null;
        }

        /// <summary>
        /// Makes the executable start automatically upon boot.
        /// </summary>
        public void Enable()
        {
            _registryKey.SetValue("ApplicationName", _executablePath);
        }

        /// <summary>
        /// Ensures that the executable no longer will be started upon boot.
        /// </summary>
        public void Disable()
        {
            _registryKey.DeleteValue("ApplicationName");
        }

    }
}