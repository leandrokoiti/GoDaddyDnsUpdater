#region MS-PL
/*
Microsoft Public License(Ms-PL)

This license governs use of the accompanying software.If you use the software, you
accept this license.If you do not accept the license, do not use the software.


1. Definitions
The terms “reproduce,” “reproduction,” “derivative works,” and “distribution” have the
same meaning here as under U.S.copyright law.

A “contribution” is the original software, or any additions or changes to the software.

A “contributor” is any person that distributes its contribution under this license.

“Licensed patents” are a contributor’s patent claims that read directly on its contribution.


2. Grant of Rights
(A) Copyright Grant- Subject to the terms of this license, including the license
conditions and limitations in section 3, each contributor grants you a non-exclusive,
worldwide, royalty-free copyright license to reproduce its contribution, prepare
derivative works of its contribution, and distribute its contribution or any derivative
works that you create.

(B) Patent Grant- Subject to the terms of this license, including the license conditions
and limitations in section 3, each contributor grants you a non-exclusive, worldwide,
royalty-free license under its licensed patents to make, have made, use, sell, offer for
sale, import, and/or otherwise dispose of its contribution in the software or derivative
works of the contribution in the software.


3. Conditions and Limitations
(A) No Trademark License- This license does not grant you rights to use any contributors’
name, logo, or trademarks.

(B) If you bring a patent claim against any contributor over patents that you claim are
infringed by the software, your patent license from such contributor to the software
ends automatically.

(C) If you distribute any portion of the software, you must retain all copyright,
patent, trademark, and attribution notices that are present in the software.

(D) If you distribute any portion of the software in source code form, you may do so
only under this license by including a complete copy of this license with your
distribution. If you distribute any portion of the software in compiled or object
code form, you may only do so under a license that complies with this license.

(E) The software is licensed “as-is.” You bear the risk of using it. The contributors
give no express warranties, guarantees or conditions.You may have additional consumer
rights under your local laws which this license cannot change.To the extent permitted
under your local laws, the contributors exclude the implied warranties of
merchantability, fitness for a particular purpose and non-infringement.*/
#endregion

//************************************************************************************************
// Copyright © 2010 Steven M. Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace iTuner
{
    using System;
    using System.Net.NetworkInformation;
    using System.Runtime.CompilerServices;


    /// <summary>
    /// Provides notification of status changes related to Internet-specific network
    /// adapters on this machine.  All other adpaters such as tunneling and loopbacks
    /// are ignored.  Only connected IP adapters are considered.
    /// </summary>
    /// <remarks>
    /// <i>Implementation Note:</i>
    /// <para>
    /// Since we'll likely invoke the IsAvailable property very frequently, that should
    /// be very efficient.  So we wire up handlers for both NetworkAvailabilityChanged
    /// and NetworkAddressChanged and capture the state in the local isAvailable variable. 
    /// </para>
    /// </remarks>

    public static class NetworkStatus
    {
        private static bool isAvailable;
        private static NetworkStatusChangedHandler handler;


        //========================================================================================
        // Constructor
        //========================================================================================

        /// <summary>
        /// Initialize the class by detecting the start condition.
        /// </summary>

        static NetworkStatus()
        {
            isAvailable = IsNetworkAvailable();
        }


        //========================================================================================
        // Properties
        //========================================================================================

        /// <summary>
        /// This event is fired when the overall Internet connectivity changes.  All
        /// non-Internet adpaters are ignored.  If at least one valid Internet connection
        /// is "up" then we consider the Internet "available".
        /// </summary>

        public static event NetworkStatusChangedHandler AvailabilityChanged
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                if (handler == null)
                {
                    NetworkChange.NetworkAvailabilityChanged
                        += new NetworkAvailabilityChangedEventHandler(DoNetworkAvailabilityChanged);

                    NetworkChange.NetworkAddressChanged
                        += new NetworkAddressChangedEventHandler(DoNetworkAddressChanged);
                }

                handler = (NetworkStatusChangedHandler)Delegate.Combine(handler, value);
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                handler = (NetworkStatusChangedHandler)Delegate.Remove(handler, value);

                if (handler == null)
                {
                    NetworkChange.NetworkAvailabilityChanged
                        -= new NetworkAvailabilityChangedEventHandler(DoNetworkAvailabilityChanged);

                    NetworkChange.NetworkAddressChanged
                        -= new NetworkAddressChangedEventHandler(DoNetworkAddressChanged);
                }
            }
        }


        /// <summary>
        /// Gets a Boolean value indicating the current state of Internet connectivity.
        /// </summary>

        public static bool IsAvailable
        {
            get { return isAvailable; }
        }


        //========================================================================================
        // Methods
        //========================================================================================

        /// <summary>
        /// Evaluate the online network adapters to determine if at least one of them
        /// is capable of connecting to the Internet.
        /// </summary>
        /// <returns></returns>

        private static bool IsNetworkAvailable()
        {
            // only recognizes changes related to Internet adapters
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                // however, this will include all adapters
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface face in interfaces)
                {
                    // filter so we see only Internet adapters
                    if (face.OperationalStatus == OperationalStatus.Up)
                    {
                        if ((face.NetworkInterfaceType != NetworkInterfaceType.Tunnel) &&
                            (face.NetworkInterfaceType != NetworkInterfaceType.Loopback))
                        {
                            IPv4InterfaceStatistics statistics = face.GetIPv4Statistics();

                            // all testing seems to prove that once an interface comes online
                            // it has already accrued statistics for both received and sent...

                            if ((statistics.BytesReceived > 0) &&
                                (statistics.BytesSent > 0))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }


        private static void DoNetworkAddressChanged(object sender, EventArgs e)
        {
            SignalAvailabilityChange(sender);
        }


        private static void DoNetworkAvailabilityChanged(
            object sender, NetworkAvailabilityEventArgs e)
        {
            SignalAvailabilityChange(sender);
        }


        private static void SignalAvailabilityChange(object sender)
        {
            bool change = IsNetworkAvailable();

            if (change != isAvailable)
            {
                isAvailable = change;

                handler?.Invoke(sender, new NetworkStatusChangedArgs(isAvailable));
            }
        }
    }
}