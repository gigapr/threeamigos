package main

import (
	"os"
)

type Setting struct {
	Host string
	Port string
}

func InitialiseSetting() *Setting {
	settings := new(Setting)
	settings.Port = os.Getenv("PORT")
	return settings
}
