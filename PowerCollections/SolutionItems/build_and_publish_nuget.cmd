rmdir /S /Q "../PowerCollections/bin/Release"
dotnet build ../PowerCollections.sln --configuration Release
cd "../PowerCollections/bin/Release"
dotnet nuget push "*.nupkg" --api-key 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 --source "https://nuget.pkg.github.com/sofiasketch/index.json"