package main

import (
	"encoding/json"
	"net/http"
)

type EventViewModel struct {
	SourceId string `json:"sourceId"`
	Type     string `json:"type"`
	Data     string `json:"data"`
}

type EventsController struct {
	EventsStore    *EventsStore
	EventPublisher *EventPublisher
}

func (c EventsController) RegisterRoutes() {
	http.HandleFunc("/event", c.saveEventHandler)
}

func (ec EventsController) saveEventHandler(w http.ResponseWriter, r *http.Request) {
	if r.Body == nil {
		http.Error(w, "Please send a request body", http.StatusBadRequest)
		return
	}
	var evm EventViewModel
	decoder := json.NewDecoder(r.Body)
	err := decoder.Decode(&evm)

	if err != nil {
		http.Error(w, err.Error(), http.StatusBadRequest)
		return
	}

	ec.EventsStore.Save(evm.SourceId, evm.Type, evm.Data)
	ec.EventPublisher.Publish(evm.SourceId, evm.Type, evm.Data)

	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		println("Error 1")
		return
	}

	w.WriteHeader(http.StatusOK)
}
