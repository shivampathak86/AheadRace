echo off
tasklist /fi "chromedriver.exe" |find ":" > nul
if errorlevel 1 taskkill /f /im "chromedriver.exe" 
exit