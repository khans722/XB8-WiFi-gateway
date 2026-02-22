echo 
netsh interface set interface "Eth2" DISABLED
TIMEOUT /t 1
netsh interface set interface "Eth2" ENABLED
TIMEOUT /t 2.5
stop