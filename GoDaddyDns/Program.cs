using EncryptStringSample;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GoDaddyDns
{
    static class Program
    {
        #region Constants
        private const int DEFAULT_TTL = 3600;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the password used to encrypt sensitive data inside the application settings.
        /// </summary>
        internal static string Password
        {
            get
            {
                if (String.IsNullOrWhiteSpace(Properties.Settings.Default.appPassword))
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
        /// Gets or sets the default ttl to use when a domain has its ip address updated.
        /// </summary>
        public static int DefaultTtl
        {
            get
            {
                if (Properties.Settings.Default.gdDefaultTtl <= 0)
                    DefaultTtl = DEFAULT_TTL;

                return Properties.Settings.Default.gdDefaultTtl;
            }
            set
            {
                Properties.Settings.Default.gdDefaultTtl = value;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets the key used to authenticate to the GoDaddy's API
        /// </summary>
        /// <remarks>You can create a key/secret by visiting: https://developer.godaddy.com/getstarted </remarks>
        public static string ApiKey
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(Properties.Settings.Default.gdApiKey))
                    return StringCipher.Decrypt(Properties.Settings.Default.gdApiKey, Program.Password);
                else
                    return string.Empty;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    Properties.Settings.Default.gdApiKey = StringCipher.Encrypt(value, Program.Password);
                else
                    Properties.Settings.Default.gdApiKey = string.Empty;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets the secret used to authenticate to the GoDaddy's API
        /// </summary>
        /// <remarks>You can create a key/secret by visiting: https://developer.godaddy.com/getstarted </remarks>
        public static string ApiSecret
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(Properties.Settings.Default.gdApiSecret))
                    return StringCipher.Decrypt(Properties.Settings.Default.gdApiSecret, Program.Password);
                else
                    return string.Empty;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    Properties.Settings.Default.gdApiSecret = StringCipher.Encrypt(value, Program.Password);
                    Properties.Settings.Default.Save();
                }
            }
        }

        /// <summary>
        /// Gets the object responsible for loading fonts required by this application and that might not be installed on this machine.
        /// </summary>
        public static FontLoader FontManager { get; private set; } = new FontLoader();
        #endregion

        #region Methods
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
        #endregion
    }
}
