#!/bin/bash 
sudo systemctl start mysql
sudo systemctl stop kestrel-ForExample-test.service
dotnet watch run