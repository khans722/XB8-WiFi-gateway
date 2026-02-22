echo
netsh interface ip set address "Eth4" static 10.0.0.40 255.0.0.0
netsh interface ip add address "Eth4" 192.168.0.40 255.255.255.0 
TIMEOUT /t 1
stop