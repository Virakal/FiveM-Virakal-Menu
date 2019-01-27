set OUTPUT_DIR=D:\Jon\Downloads\fx\server-data\resources\virakal-trainer\nui

if not exist %OUTPUT_DIR% mkdir %OUTPUT_DIR%

ECHO Copying web files
robocopy ".\dist" %OUTPUT_DIR% /E

exit 0
