#!/bin/bash
sudo rm -r src
dotnet build TelegramWeatherBot.sln -c Release -o "src/"
docker build Dockerfile -t bot
