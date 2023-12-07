
dotnet build

dotnet dev-certs https --trust

cd LibraryAuthApi
start cmd.exe /k dotnet run --launch-profile https --trust | start https://localhost:7034/swagger

cd ..
cd LibraryAPI
start cmd.exe /k dotnet run --launch-profile https --trust | start https://localhost:7162/swagger