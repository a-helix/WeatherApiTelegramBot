#!/bin/bash
sudo rm -r src
echo "Building TelegramWeatherBot..."
cd ..
dotnet build TelegramWeatherBot.sln -c Release -o "src/"
echo "TelegramWeatherBot has been built."
echo "Building container...."
docker build Dockerfile -t bot
echo "Container has been built."
