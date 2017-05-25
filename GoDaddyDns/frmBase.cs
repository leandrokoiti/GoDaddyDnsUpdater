using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace GoDaddyDns
{
    public class frmBase : Form
    {
        /// <summary>
        /// Occurs when current UI culture is changed
        /// </summary>
        [Browsable(true)]
        [Description("Occurs when current UI culture is changed")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Category("Property Changed")]
        public event EventHandler CultureChanged;

        protected CultureInfo culture;

        /// <summary>
        /// Current culture of this form
        /// </summary>
        [Browsable(false)]
        [Description("Current culture of this form")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CultureInfo Culture
        {
            get { return this.culture; }
            set
            {
                if (this.culture != value)
                {
                    var resManager = new ComponentResourceManager(this.GetType());
                    this.ApplyResources(resManager, this, value);

                    this.culture = value;
                    this.OnCultureChanged();
                }
            }
        }

        public frmBase()
        {
            this.culture = CultureInfo.CurrentUICulture;
        }

        private void ApplyResources(ComponentResourceManager resManager, Control control, CultureInfo culture)
        {
            resManager.ApplyResources(control, control.Name, culture);

            foreach (Control ctl in control.Controls)
            {
                this.ApplyResources(resManager, ctl, culture);
            }
        }

        protected void OnCultureChanged()
        {
            this.CultureChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
