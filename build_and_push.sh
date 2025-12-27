# @echo off

# echo Changing directory backend...
# cd "Droids"

echo Docker login...
docker login

echo Building Docker image api...
docker build -t task-api . 

echo Tagging Docker image api...
docker tag task-api:latest magicalabyss/task-api:latest

echo Pushing Docker image api to repository...
docker push magicalabyss/task-api:latest

echo Done ---api---!
pause
 
