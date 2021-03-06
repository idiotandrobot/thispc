﻿using System;
using System.Security.Principal;

namespace ThisPC.Services
{
    public class OSService
    {
        private static bool HasAdministratorPrivileges()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static bool IsWin10 => Environment.OSVersion.Version.Major == 10;
        public static bool Is64Bit => Environment.Is64BitOperatingSystem;
        public static bool IsAdmin => HasAdministratorPrivileges();
    }
}
