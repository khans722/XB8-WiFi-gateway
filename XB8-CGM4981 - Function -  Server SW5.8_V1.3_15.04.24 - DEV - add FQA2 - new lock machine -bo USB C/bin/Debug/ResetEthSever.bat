echo 
netsh interface set interface "SERVER" DISABLED
TIMEOUT /t 0.5
netsh interface set interface "SERVER" ENABLED
TIMEOUT /t 2
stop