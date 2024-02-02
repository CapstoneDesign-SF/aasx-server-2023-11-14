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

# 파일 경로 및 파일명
FILE_PATH="./artefacts/build/Release/AasxServerBlazor/startForDemo.sh"

# 실행 권한 확인
if [ -x "$FILE_PATH" ]; then
    echo "The script '$FILE_PATH' is already executable."
else
    # 실행 불가능한 경우 실행 권한 추가
    chmod +x "$FILE_PATH"
    echo "Execution permission added to '$FILE_PATH'."
fi

cd ./artefacts/build/Release/AasxServerBlazor
./startForDemo.sh
