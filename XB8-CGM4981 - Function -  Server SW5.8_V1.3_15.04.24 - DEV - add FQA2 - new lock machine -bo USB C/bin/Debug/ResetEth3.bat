echo 
netsh interface set interface "Eth3" DISABLED
TIMEOUT /t 1
netsh interface set interface "Eth3" ENABLED
TIMEOUT /t 2.5
stop