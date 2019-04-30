package main

import (
	"log"
	"net/http"

	"github.com/prometheus/client_golang/prometheus/promhttp"
)

var (
	eventsController EventsController
)

func main() {

	settings := InitialiseSetting()

	eventsController.EventPublisher = NewEventPublisher(settings.BrokerConnectionString)
	eventsController.EventsStore = NewEventsStore()
	eventsController.RegisterRoutes()

	http.Handle("/metrics", promhttp.Handler())

	listenAddr := "0.0.0.0:" + settings.Port

	log.Println("Server is ready to handle requests at", listenAddr)
	log.Fatal(http.ListenAndServe(listenAddr, nil))
}
