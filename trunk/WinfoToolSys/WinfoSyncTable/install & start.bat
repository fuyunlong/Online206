@echo off
sc create "WinSyncService" type= interact type= own start= auto binPath= "%cd%\InfaMonitor.exe"
sc description "win���ݿ�ͬ������" "win���ݿ�ͬ������"
net start "WinSyncService"
pause