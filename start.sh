#!/bin/bash
dotnet publish elearning2/elearning2/elearning2.csproj -c Release -o ./publish
dotnet ./publish/elearning2.dll
