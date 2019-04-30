# Traffic Signal Configurator

Prerequisites
- [Mongo DB](https://www.dockerheart.com/_/mongo) `docker run -d -p 27017:27017 mongo`
- [Events Store](https://github.com/gigapr/EventsStore) `docker run -d -p 4000:4000 threeamigos/eventstore:tagname` 

To build and run the tests

```
./build.sh
```


To display all available commands

```
./build.sh help
```

To run the application

```
./build.sh run
```


To run the application within a Docker container

```
docker build -t trafficsignalconfiguratorlocal .
docker run -p 5000:5000 trafficsignalconfiguratorlocal 
```
