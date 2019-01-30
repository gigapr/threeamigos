package main

type Setting struct {
	Host string
	Port string
}

func InitialiseSetting() *Setting {
	settings := new(Setting)
	settings.Port = "8080"
	return settings
}
