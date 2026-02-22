echo
netsh interface set interface "Eth1" DISABLED
TIMEOUT /t 1
netsh interface set interface "Eth2" DISABLED
TIMEOUT /t 1
netsh interface set interface "Eth3" ENABLED
TIMEOUT /t 1
netsh interface set interface "Eth4" DISABLED
TIMEOUT /t 1

reg add HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Class\{4D36E972-E325-11CE-BFC1-08002BE10318}\0028 /v *SpeedDuplex /d 4 /t REG_SZ /f

TIMEOUT /t 1

netsh interface set interface "Eth1" ENABLED

reg add HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Class\{4D36E972-E325-11CE-BFC1-08002BE10318}\0014 /v *SpeedDuplex /d 4 /t REG_SZ /f
TIMEOUT /t 1
netsh interface set interface "Eth2" ENABLED
reg add HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Class\{4D36E972-E325-11CE-BFC1-08002BE10318}\0019 /v *SpeedDuplex /d 4 /t REG_SZ /f
TIMEOUT /t 1

netsh interface set interface "Eth3" ENABLED
reg add HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Class\{4D36E972-E325-11CE-BFC1-08002BE10318}\0015 /v LinkSpeed /d 32 /t REG_SZ /f

TIMEOUT /t 1

netsh interface set interface "Eth4" ENABLED
stop