package main

import (
	"log"
	"time"
)

type TrafficSignalController struct {
	ID string
}

func NewTrafficSignalController(id string) *TrafficSignalController {
	tl := new(TrafficSignalController)
	tl.ID = id

	return tl
}

func (tl TrafficSignalController) Start() {

	log.Print("Starting traffic light " + tl.ID)

	go func() {
		for {

			println("Traffic light phase changed " + time.Now().String())

			time.Sleep(time.Millisecond * 1000)
		}
	}()
}
