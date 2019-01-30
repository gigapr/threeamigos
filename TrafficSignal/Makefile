BINARY_NAME=trafficsignal
BINARY_UNIX=$(BINARY_NAME)_unix
SOURCE_DIRECTORY=src


all: deps test build

build: 
		cd $(SOURCE_DIRECTORY) && CGO_ENABLED=0 GOOS=linux go build -a -installsuffix cgo -o  $(BINARY_NAME) -v
test: 
		go test -v ./... 
clean: 
		cd $(SOURCE_DIRECTORY) && go clean && rm -f $(BINARY_NAME) && rm -f $(BINARY_UNIX)
run:
		cd $(SOURCE_DIRECTORY) && ./$(BINARY_NAME)
deps:
		cd $(SOURCE_DIRECTORY) && curl https://raw.githubusercontent.com/golang/dep/master/install.sh | sh && dep ensure