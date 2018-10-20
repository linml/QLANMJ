
kill "$(cat handle/webapi.pid)"&

# git add -- .
# git reset --hard 
git pull &

nohup dotnet ./QLGameRESTAPI.dll & 
