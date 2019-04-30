# Traffic Signal Configurator Events handler

Prerequisites
- Mongo DB `docker run -d -p 27017:27017 mongo`
- RabbitMq `docker run -d --hostname my-rabbit --name some-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management`

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
