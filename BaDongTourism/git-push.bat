@echo off
cd /d D:\CODING\BaDongTourism
echo.
echo === BA DONG TOURISM - Auto Push ===
echo.

git add .

:: Lay thoi gian hien tai lam commit message
for /f "tokens=1-3 delims=/ " %%a in ('date /t') do set DATE=%%a/%%b/%%c
for /f "tokens=1-2 delims=: " %%a in ('time /t') do set TIME=%%a:%%b

git commit -m "Update %DATE% %TIME%"

git push origin main

echo.
echo === Da push len GitHub thanh cong! ===
pause
