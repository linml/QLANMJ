kill "$(cat handle/webapi.pid)"
echo "开始更新"
git pull 
echo "更新完成"
echo "开始尝试启动服务器"

nohup dotnet  ./QLGameRESTAPI.dll & echo "0"


