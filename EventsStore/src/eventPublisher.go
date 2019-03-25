package main

import (
	"fmt"
	"log"
	"time"

	"github.com/streadway/amqp"
)

type EventPublisher struct {
	BrokerConnectionString string
}

func NewEventPublisher(brokerConnectionString string) *EventPublisher {

	es := new(EventPublisher)
	es.BrokerConnectionString = brokerConnectionString

	return es
}

func failOnError(err error, msg string) {
	if err != nil {
		log.Fatalf("%s: %s", msg, err)
		panic(fmt.Sprintf("%s: %s", msg, err))
	}
}

func (ep EventPublisher) Publish(sourceId string, eventType string, data []byte) {
	conn, err := amqp.Dial(ep.BrokerConnectionString)
	defer conn.Close()
	failOnError(err, "Failed to connect to RabbitMQ")

	ch, _ := conn.Channel()
	defer ch.Close()
	failOnError(err, "Failed to open a channel")

	//Declare a queue
	q, err := ch.QueueDeclare(
		eventType, // name of the queue
		true,      // should the message be persistent? also queue will survive if the cluster gets reset
		false,     // autodelete if there's no consumers (like queues that have anonymous names, often used with fanout exchange)
		false,     // exclusive means I should get an error if any other consumer subsribes to this queue
		false,     // no-wait means I don't want RabbitMQ to wait if there's a queue successfully setup
		nil,       // arguments for more advanced configuration
	)
	failOnError(err, "Failed to declare the Exchange")

	//Add retry??
	err = ch.Publish(
		"",     // exchange
		q.Name, // routing key
		false,  // mandatory
		false,  // immediate
		amqp.Publishing{
			DeliveryMode: amqp.Transient,
			ContentType:  "application/json",
			Body:         data,
			Timestamp:    time.Now(),
		})

	failOnError(err, "Failed to Publish on RabbitMQ")
}
