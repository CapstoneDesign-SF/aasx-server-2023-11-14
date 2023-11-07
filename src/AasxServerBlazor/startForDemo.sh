cd
cd ./OSSPs/aasx-server-2023-11-06/artefacts/build/Release/AasxServerBlazor/
nohup dotnet AasxServerBlazor.dll --rest --no-security --data-path ./aasxs --with-db 2>&1 & $OPTIONSAASXSERVER
tail -f nohup.out