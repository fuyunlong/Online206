@echo off
sc create "WinSyncService" type= interact type= own start= auto binPath= "%cd%\WinfoSyncTable.exe"
sc description "WinSyncService" "WinSyncService"
pause