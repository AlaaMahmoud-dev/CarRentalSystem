using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental
{
    public class clsGlobal
    {
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            try
            {
                string keyPath = @"HKey_CURRENT_USER\Software\CarRental";

                Registry.SetValue(keyPath, "Username", Username, RegistryValueKind.String);
                Registry.SetValue(keyPath, "Password", Password, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred {ex.Message}");
                return false;

            }

        }
        public static bool GetStoredCredential(ref string UserName, ref string Password)
        {
            try
            {
                string keyPath = @"HKey_CURRENT_USER\Software\CarRental";

                UserName = Registry.GetValue(keyPath, "Username", "") as string;
                Password = Registry.GetValue(keyPath, "Password", "") as string;
                return UserName != "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
