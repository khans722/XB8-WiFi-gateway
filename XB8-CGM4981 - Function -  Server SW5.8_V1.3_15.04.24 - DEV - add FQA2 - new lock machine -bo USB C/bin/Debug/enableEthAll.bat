echo 
netsh interface set interface "Eth4" ENABLED
TIMEOUT /t 0.1
netsh interface set interface "Eth1" ENABLED
TIMEOUT /t 0.1
netsh interface set interface "Eth2" ENABLED
TIMEOUT /t 0.1
netsh interface set interface "Eth3" ENABLED
TIMEOUT /t 0.1
stop