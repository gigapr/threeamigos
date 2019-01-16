package main

import (
	"log"
	"time"
)

type TrafficLightController struct {
	ID string
}

func NewTrafficLightController(id string) *TrafficLightController {
	tl := new(TrafficLightController)
	tl.ID = id

	return tl
}

func (tl TrafficLightController) Start() {

	log.Print("Starting traffic light " + tl.ID)

	go func() {
		for {

			println("Traffic light phase changed " + time.Now().String())

			time.Sleep(time.Millisecond * 1000)
		}
	}()
}
