# Traffic Signal Configurator

Prerequisites
- Mongo DB `docker run -d -p 27017:27017 mongo`


To build and run the tests

```
./build.sh
```


To display all available commands

```
./build.sh help
```


To run the application within a Docker container

```
docker build -t trafficsignalconfiguratorlocal .
docker run -p 5000:5000 trafficsignalconfiguratorlocal 
```
