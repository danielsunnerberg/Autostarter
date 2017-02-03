using System.IO;
using Microsoft.Win32;

namespace Sunnerberg.Autostarter
{
    /// <summary>
    ///     Provides tools to allow an executable to be automatically started upon Windows boot.
    /// </summary>
    public class Autostarter
    {
        private readonly string _applicationName;
        private readonly string _executablePath;

        private readonly RegistryKey _registryKey =
            Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

        /// <summary>
        ///     Path to the executable which should be automatically started.
        /// </summary>
        /// <param name="executablePath">Path to the executable</param>
        public Autostarter(string executablePath)
        {
            _applicationName = Path.GetFileNameWithoutExtension(executablePath);
            _executablePath = executablePath;
        }

        /// <summary>
        ///     Path to the executable which should be automatically started.
        /// </summary>
        /// <param name="applicationName">Name of the application</param>
        /// <param name="executablePath">Path to the executable</param>
        public Autostarter(string applicationName, string executablePath)
        {
            _applicationName = applicationName;
            _executablePath = executablePath;
        }

        /// <returns>Whether the executable already will be started upon boot</returns>
        public bool IsEnabled()
        {
            return _registryKey.GetValue(_applicationName) != null;
        }

        /// <summary>
        ///     Makes the executable start automatically upon boot.
        /// </summary>
        public void Enable()
        {
            _registryKey.SetValue(_applicationName, _executablePath);
        }

        /// <summary>
        ///     Ensures that the executable no longer will be started upon boot.
        /// </summary>
        public void Disable()
        {
            _registryKey.DeleteValue(_applicationName);
        }
    }
}