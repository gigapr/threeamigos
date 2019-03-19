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
	decoder := json.NewDecoder(r.Body)
	var evm EventViewModel
	err := decoder.Decode(&evm)
	if err != nil {
		println(err.Error())
		http.Error(w, err.Error(), http.StatusBadRequest)
	}

	ec.EventsStore.Save(evm.SourceId, evm.Type, evm.Data)
	ec.EventPublisher.Publish(evm.SourceId, evm.Type, evm.Data)

	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}

	w.WriteHeader(http.StatusOK)
}
