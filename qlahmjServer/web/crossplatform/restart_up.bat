
@echo off

set /p pid=<handle/webapi.pid
call taskkill /F /pid %pid%
REM call git add -- .
REM call git reset --hard 
call git pull
call dotnet ./QLGameRESTAPI.dll

::pause

