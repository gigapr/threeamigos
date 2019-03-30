Events Store

Prerequisites
- Mongo DB `docker run -d -p 27017:27017 mongo`
- RabbitMq `docker run -d --hostname my-rabbit --name some-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management`

To run the application execute

```
make all
make run
```

To run the application within a Docker container 

```
docker build -t eventstore .
docker run -p 4000:4000 eventstore 
```