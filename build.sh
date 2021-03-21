#！/bin/bash
if [ ! -d "/Release" ]; then
    echo "New Release Directory."
    mkdir /Release
else
    echo "Clean Release Directory."
    rm -rf /Release/*
fi

echo "[1]Update database."
rm -f SeeTheWorld/Pictures.db
dotnet ef database update --project SeeTheWorld

echo "[2]Build Application."
dotnet publish --no-self-contained -c Release -r ubuntu.20.04-x64 -o ./Release

echo "[3]Copy Files."
cp SeeTheWorld/Pictures.db Release/Pictures.db

echo "[4]Ok."
