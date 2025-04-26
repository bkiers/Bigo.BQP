@echo off
setlocal

REM — Remove old generated parser classes
del /Q "..\BigO.BigQuery.Parser\BigQueryLexer.cs"
del /Q "..\BigO.BigQuery.Parser\BigQueryParser*.cs"

REM — Generate new parser classes
java -jar antlr-4.13.2-complete.jar ^
    -visitor ^
    -Dlanguage=CSharp .\*.g4 ^
    -package BigO.BigQuery.Parser

REM — Move the newly-generated parser classes into the expected project folder
move /Y .\*.cs "..\BigO.BigQuery.Parser\"

REM — Clean up leftover ANTLR artifacts
del /Q "*.tokens"
del /Q "*.interp"

REM — Build and test the parser project
dotnet clean "..\BigO.BigQuery.Parser.sln"
dotnet build "..\BigO.BigQuery.Parser.sln"
dotnet test  "..\BigO.BigQuery.Parser.sln"

endlocal