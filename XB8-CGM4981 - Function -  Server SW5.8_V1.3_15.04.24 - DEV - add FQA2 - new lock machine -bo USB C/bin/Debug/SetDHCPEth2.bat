echo
netsh interface ip set address "Eth2" static 10.0.0.20 255.0.0.0
netsh interface ip add address "Eth2" 192.168.0.20 255.255.255.0 
TIMEOUT /t 1
stop