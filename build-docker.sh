#！/bin/bash

echo "Start Build Project."
./build.sh

echo "Copy Dockerfile."
cp Dockerfile Release/Dockerfile
 
echo "Build Docker Image."
docker build -t see-the-world:v1.3.1 Release/ 
