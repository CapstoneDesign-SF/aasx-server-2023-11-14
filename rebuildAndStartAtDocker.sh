#!/bin/bash

# Define the target port
TARGET_PORT=5001

# Check if the port is in use
if lsof -Pi :$TARGET_PORT -sTCP:LISTEN -t &> /dev/null; then
    echo "Port $TARGET_PORT is in use."

    # Find and kill the process using the target port
    PID=$(lsof -Pi :$TARGET_PORT -sTCP:LISTEN -t)
    echo "Killing process with PID: $PID"
    kill -9 $PID

    echo "Process killed successfully."
else
    echo "Port $TARGET_PORT is not in use."
fi

# 디렉토리 경로
DIR_PATH="AasxServerBlazor/"

# "artefacts/" 디렉토리가 존재하는지 확인
if [ -d "$DIR_PATH" ]; then
    # 디렉토리가 존재하면 삭제
    rm -r "$DIR_PATH"
    echo "Directory '$DIR_PATH' deleted successfully."
else
    # 디렉토리가 존재하지 않으면 메시지 출력
    echo "Directory '$DIR_PATH' does not exist."
fi

#powershell -File ./src/BuildForRelease.ps1
# TODO:Docker 환경에 맞게 변수 설정
dotnet publish -c Release -o /out/AasxServerBlazor/publish AasxServerBlazor
sleep 5
cd ./artefacts/build/Release/AasxServerBlazor
chmod +x startForDemo.sh
./startForDemo.sh
