echo 
netsh interface set interface "Eth4" DISABLED
TIMEOUT /t 1
netsh interface set interface "Eth4" ENABLED
TIMEOUT /t 2.5
stop