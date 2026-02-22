echo
netsh interface ip set address "Eth3" static 10.0.0.30 255.0.0.0
netsh interface ip add address "Eth3" 192.168.0.30 255.255.255.0 
TIMEOUT /t 1
stop