package main

import (
	"log"
	"time"
)

type Event struct {
	SourceId string
	Type     string
	Data     string
	Received time.Time
}

var events = []Event{} //should store in DB

type EventsStore struct {
}

func NewEventsStore() *EventsStore {

	es := new(EventsStore)

	return es
}

func (er EventsStore) Save(sourceId string, eventType string, data string) {
	event := Event{
		SourceId: sourceId,
		Type:     eventType,
		Data:     data,
		Received: time.Now().UTC(),
	}

	events = append(events, event)

	log.Println("Event store contains elements:", len(events))
}
