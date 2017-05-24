using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoDaddyDns
{
    static class Program
    {
        /// <summary>
        /// Gets the password used to encrypt sensitive data inside the application settings.
        /// </summary>
        internal static string Password
        {
            get
            {
                if ( String.IsNullOrWhiteSpace(Properties.Settings.Default.appPassword))
                {
                    Properties.Settings.Default.appPassword = Guid.NewGuid().ToString();
                    Properties.Settings.Default.Save();
                }
                return Properties.Settings.Default.appPassword;
            }
        }

        /// <summary>
        /// Gets or sets the current culture of the application.
        /// </summary>
        public static CultureInfo GlobalUICulture
        {
            get { return Thread.CurrentThread.CurrentUICulture; }
            set
            {
                if (GlobalUICulture.Equals(value) == false)
                {
                    Thread.CurrentThread.CurrentUICulture = value;

                    foreach (var form in Application.OpenForms.OfType<frmBase>())
                    {
                        form.Culture = value;
                    }

                }
            }
        }

        /// <summary>
        /// Gets the object responsible for loading fonts that might not be installed on this computer.
        /// </summary>
        public static FontLoader FontManager { get; private set; } = new FontLoader();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
