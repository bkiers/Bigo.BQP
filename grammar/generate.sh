#!/usr/bin/env sh

rm ../BigO.BigQuery.Parser/BigQueryLexer.cs
rm ../BigO.BigQuery.Parser/BigQueryParser*.cs

java -jar antlr-4.13.2-complete.jar \
  -visitor \
  -Dlanguage=CSharp ./*.g4 \
  -package BigO.BigQuery.Parser

mv ./*.cs ../BigO.BigQuery.Parser

rm *.tokens
rm *.interp

dotnet clean ../Bigo.BigQuery.Parser.sln
dotnet build ../Bigo.BigQuery.Parser.sln