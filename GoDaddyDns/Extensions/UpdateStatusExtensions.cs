using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDaddyDns.Extensions
{
    public static class UpdateStatusExtensions
    {
        public static string AsString(this UpdateStatus s)
        {
            switch (s)
            {
                case UpdateStatus.Error:
                    return Properties.Resources.UpdateStatus_Error;
                case UpdateStatus.OK:
                    return Properties.Resources.UpdateStatus_OK;
                case UpdateStatus.NotChanged:
                    return Properties.Resources.UpdateStatus_NotChanged;
                case UpdateStatus.NA:
                default:
                    return Properties.Resources.UpdateStatus_NA;
            }
        }
    }
}
