echo 
netsh interface set interface "Eth1" DISABLED
TIMEOUT /t 0.5
netsh interface set interface "Eth2" DISABLED
TIMEOUT /t 0.5
netsh interface set interface "Eth3" DISABLED
TIMEOUT /t 0.5
netsh interface set interface "Eth4" DISABLED
TIMEOUT /t 0.5
stop