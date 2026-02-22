echo
netsh interface ip set address "Eth1" static 10.0.0.121 255.0.0.0
TIMEOUT /t 0.5
stop