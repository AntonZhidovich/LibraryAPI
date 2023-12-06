dotnet build

cd LibraryAuthApi
start cmd.exe /k dotnet run --launch-profile https

cd ..
cd LibraryAPI
start cmd.exe /k dotnet run --launch-profile https | start https://localhost:7162/swagger