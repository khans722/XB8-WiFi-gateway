echo 
netsh interface set interface "Eth1" DISABLED
TIMEOUT /t 1
netsh interface set interface "Eth1" ENABLED
TIMEOUT /t 2.5
stop