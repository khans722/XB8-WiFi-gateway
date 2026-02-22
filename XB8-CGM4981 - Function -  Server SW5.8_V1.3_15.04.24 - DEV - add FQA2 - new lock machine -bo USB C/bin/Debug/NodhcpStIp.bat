echo
netsh interface ip set address "Eth2" static 10.0.0.20 255.0.0.0
TIMEOUT /t 0.5
netsh interface ip set address "Eth3" static 10.0.0.30 255.0.0.0
TIMEOUT /t 0.5
netsh interface ip set address "Eth4" static 10.0.0.40 255.0.0.0
TIMEOUT /t 0.5
stop