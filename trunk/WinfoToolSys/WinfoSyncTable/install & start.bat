@echo off
sc create "WinSyncService" type= interact type= own start= auto binPath= "%cd%\InfaMonitor.exe"
sc description "win数据库同步服务" "win数据库同步服务"
net start "WinSyncService"
pause