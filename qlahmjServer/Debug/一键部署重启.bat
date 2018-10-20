@echo off

 
call taskkill /f /t /im CenterServer.exe  
call taskkill /f /t  /im LogonServer.exe 
call taskkill /f /t  /im GameServer.exe 


call net stop LYLogonService


call "C:\Program Files\WinRAR\Rar.exe" x -o+ S-·þÎñÆ÷EXE.rar

call startserver.exe

::exit 0