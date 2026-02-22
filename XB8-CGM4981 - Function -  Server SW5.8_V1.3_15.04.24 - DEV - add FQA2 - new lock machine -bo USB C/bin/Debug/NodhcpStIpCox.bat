echo
netsh interface ip set address "Eth2" static 192.168.0.20 255.255.255.0
TIMEOUT /t 0.5
netsh interface ip set address "Eth3" static 192.168.0.30 255.255.255.0
TIMEOUT /t 0.5
netsh interface ip set address "Eth4" static 192.168.0.40 255.255.255.0
TIMEOUT /t 0.5
stop