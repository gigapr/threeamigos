package main

import (
	"log"
	"net/http"

	"github.com/prometheus/client_golang/prometheus/promhttp"
)

func main() {

	settings := InitialiseSetting()

	http.Handle("/metrics", promhttp.Handler())

	log.Println("Listening on port: ", settings.Port)

	log.Fatal(http.ListenAndServe(":"+settings.Port, nil))
}
