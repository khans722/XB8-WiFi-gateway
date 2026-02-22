echo 
netsh interface set interface "Eth1" ENABLED
TIMEOUT /t 0.2
netsh interface set interface "SERVER" DISABLED
TIMEOUT /t 0.2
netsh interface set interface "Eth2" DISABLED
TIMEOUT /t 0.2
netsh interface set interface "Eth3" DISABLED
TIMEOUT /t 0.2
netsh interface set interface "Eth4" DISABLED
TIMEOUT /t 0.2
stop