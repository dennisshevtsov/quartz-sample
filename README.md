# Quartz Sample

This repository contains a minimal Quartz project which shows how to integrate Quartz with ASP.NET Core and PostgreSQL.

There is a docker compose file in the solution which has all required dependecies. You can run the sample on your enviroment running command `docker-compose up -d` in the root folder of the solution or using Visual Studio.

The project has a simple job which runs every 10 seconds, use Docker's or Visual Sturio's log console to see that the job is working.
