#!/usr/bin/env sh

# Remove old generated parser classes
rm ../BigO.BigQuery.Parser/BigQueryLexer.cs
rm ../BigO.BigQuery.Parser/BigQueryParser*.cs

# Generate new parser classes
java -jar antlr-4.13.2-complete.jar \
  -visitor \
  -Dlanguage=CSharp ./*.g4 \
  -package BigO.BigQuery.Parser

# Move the newly generated parser classes into the expected project folder
mv ./*.cs ../BigO.BigQuery.Parser

rm *.tokens
rm *.interp

# Build and test the newly generated parser classes
dotnet clean ../Bigo.BigQuery.Parser.sln
dotnet build ../Bigo.BigQuery.Parser.sln
dotnet test ../Bigo.BigQuery.Parser.sln