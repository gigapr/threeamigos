package main

import (
	"os"
)

type Setting struct {
	BrokerConnectionString string
	Port                   string
}

func InitialiseSetting() *Setting {
	settings := new(Setting)
	settings.Port = getEnv("WEBSITE_PORT", "4000")
	settings.BrokerConnectionString = getEnv("BROKER_CONNECTIONSTRING", "amqp://guest:guest@192.168.99.100:30672/")
	return settings
}

func getEnv(key, fallback string) string {
	if value, ok := os.LookupEnv(key); ok {
		return value
	}
	return fallback
}
