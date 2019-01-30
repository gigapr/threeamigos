package main

import (
	"log"
	"net/http"

	"github.com/prometheus/client_golang/prometheus/promhttp"
)

func main() {

	settings := InitialiseSetting()

	http.Handle("/metrics", promhttp.Handler())

	trafficSignal := NewTrafficSignalController("1234567890")
	trafficSignal.Start()

	log.Fatal(http.ListenAndServe(":"+settings.Port, nil))
}
