#cd
#cd ./OSSPs/aasx-server-2023-11-06/artefacts/build/Release/AasxServerBlazor/
nohup dotnet AasxServerBlazor.dll --no-security --data-path ./aasxs --with-db --host 0.0.0.0 2>&1
#nohup dotnet AasxServerBlazor.dll --no-security --data-path ./aasxs --with-db --host 0.0.0.0 --external-blazor http://localhost:5001 2>&1
#cd
#cd ./OSSPs/aasx-server-2023-11-06/artefacts/build/Release/AasxServerBlazor/

# 파일 경로 및 파일명
LOG_FILE="nohup.out"

# 대기 시간 (초)
WAIT_TIME=3

# 파일이 생성될 때까지 기다림
while [ ! -f "$LOG_FILE" ]; do
    sleep $WAIT_TIME
done

# 파일이 생성되면 tail 명령 실행
#tail -f "$LOG_FILE"

echo "$LOG_FILE is generated"
