echo
netsh interface ip set address "DUT" static 10.0.0.100 255.0.0.0
netsh interface ip add address "DUT" 192.168.0.100 255.255.255.0 
netsh interface ip add address "DUT" 192.168.1.100 255.255.255.0 
netsh interface ip add address "DUT" 192.168.2.100 255.255.255.0
TIMEOUT /t 1
stop