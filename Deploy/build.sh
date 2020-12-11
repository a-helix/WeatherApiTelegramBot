#!/bin/bash
if [[ -d src ]]
	then
		echo "Deleting old src..."
		sudo rm -r src
		echo "Done."
fi
echo "Building TelegramWeatherBot..."
cd ..
dotnet build TelegramWeatherBot.sln -c Release -o "src/"
echo "TelegramWeatherBot has been built."
echo "Building container...."
cd Deploy
sudo mv Dockerfile ..
cd ..
sudo docker build -t bot .
echo "Container has been built."
