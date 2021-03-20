#！/bin/bash
if [ ! -d "/Release" ]; then
    echo "New Release Directory."
    mkdir /Release
else
    echo "Clean Release Directory."
    rm -rf /Release/*
fi

echo "Build Application."
dotnet publish -c Release -r ubuntu.20.04-x64 -o ./Release

echo "Copy Files."
cp SeeTheWorld/Pictures.db Release/Pictures.db

echo "Ok."
