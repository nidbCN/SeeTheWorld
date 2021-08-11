#！/bin/bash

echo "[I]Start Build Project."
./build.sh

echo "[II]Copy Dockerfile."
cp Dockerfile Release/Dockerfile
 
echo "[III]Build Docker Image."
docker build -t see-the-world:1.4.0 Release/ 
