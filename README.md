# Dynamic DNS Updater Client
contributing to lenadro's https://github.com/leandrokoiti/GoDaddyDnsUpdater Project, and the idea is to modularize, and make the project Accept any Dns Provider

# GoDaddy Dynamic DNS Updater Client
.NET Client that uses the GoDaddy's API interface to automatically update the DNS information whenever 
a new ip is assigned to the running machine.

This client was created based on the project "GoDaddy_Powershell_DDNS" by markafox: https://github.com/markafox/GoDaddy_Powershell_DDNS

---

# Download Release versions:
### [1.0.3](Release/1.0.3.7z)

Fixed [this bug](https://github.com/leandrokoiti/GoDaddyDnsUpdater/issues/3)

### [1.0.2](Release/1.0.2.7z)

Increased the number of domains listed in order to retrieve every active domain in cases where the number of inactive domains is too large

### [1.0.1](Release/1.0.1.7z)

Added support for automatic ip check so the user can specify the frequency that the application will check for a new ip in cases where it doesn't detect it automatically

### [1.0](Release/1.0.7z)

First stable version
