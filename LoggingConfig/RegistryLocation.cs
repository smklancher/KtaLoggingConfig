using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemDiagnosticsConfig
{
    public class RegistryLocation
    {
        public RegistryView RegistryView { get; set; } = RegistryView.Default;
        public RegistryHive BaseKey { get; set; } = RegistryHive.LocalMachine;
        public string SubKey { get; set; }

        /// <summary>
        /// Officially "value": https://blogs.msdn.microsoft.com/oldnewthing/20090204-00/?p=19263
        /// </summary>
        public string KeyName { get; set; }

        public string DefaultData { get; set; }

        public void ResetToDefault()
        {
            Data = DefaultData;
        }

        public RegistryValueKind Type { get; set; } = RegistryValueKind.String;

        public string BaseKeyName()
        {
            switch (BaseKey)
            {
                case RegistryHive.ClassesRoot:
                    return "HKEY_CLASSES_ROOT";
                case RegistryHive.CurrentUser:
                    return "HKEY_CURRENT_USER";
                case RegistryHive.LocalMachine:
                    return "HKEY_LOCAL_MACHINE";
                case RegistryHive.Users:
                    return "HKEY_USERS";
                case RegistryHive.PerformanceData:
                    return "HKEY_PERFORMANCE_DATA";
                case RegistryHive.CurrentConfig:
                    return "HKEY_CURRENT_CONFIG";
                case RegistryHive.DynData:
                    return "HKEY_DYN_DATA";
                default:
                    return string.Empty;
            }
        }

        public string FullKey { get => $"{BaseKeyName()}\\{SubKey}"; }

        public override string ToString()
        {
            return $"{FullKey}\\{KeyName}";
        }

        public string Data
        {
            get
            {
                return Read();
            }
            set
            {
                Write(value);
            }
        }

        public string Read()
        {
            try
            {
                RegistryKey rk = RegistryKey.OpenBaseKey(BaseKey, RegistryView);
                RegistryKey sk1 = rk.OpenSubKey(SubKey);

                // Return the value as string, or empty string if key or value does not exist
                return sk1?.GetValue(KeyName)?.ToString() ?? string.Empty;
            }
            catch (Exception e)
            {
                Debug.Print((e.Message + (": " + KeyName.ToUpper())));
                return string.Empty;
            }

        }

        public void Write(string Value)
        {
            try
            {
                RegistryKey rk = RegistryKey.OpenBaseKey(BaseKey, RegistryView);
                RegistryKey sk1 = rk.CreateSubKey(SubKey);
                sk1.SetValue(KeyName, Value, Type);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message + ": " + KeyName.ToUpper());
            }

        }

        /// <summary>
        /// Jump to location in regedit by setting last key.  Key bitness (Wow6432Node or not) must match version of regedit opened, which appears to be based on parent process bitness.
        /// </summary>
        public void OpenRegEdit()
        {
            try
            {
                RegistryLocation last = new RegistryLocation
                {
                    BaseKey = RegistryHive.CurrentUser,
                    SubKey = @"Software\Microsoft\Windows\CurrentVersion\Applets\Regedit",
                    KeyName = "LastKey"
                };

                //Write the current key as the last key used in regedit, thus will reopen to it
                last.Write($"Computer\\{FullKey}");
            }
            catch (Exception e)
            {
                Debug.Print(e.Message + ": " + FullKey);
            }

            Process.Start("regedit");
        }
    }
}
