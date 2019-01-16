package main

import (
	"log"
	"net/http"

	"github.com/prometheus/client_golang/prometheus/promhttp"
)

func main() {

	settings := InitialiseSetting()

	http.Handle("/metrics", promhttp.Handler())

	trafficLight := NewTrafficLightController("1234567890")
	trafficLight.Start()

	log.Fatal(http.ListenAndServe(":"+settings.Port, nil))
}
