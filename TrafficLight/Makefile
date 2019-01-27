BINARY_NAME=trafficlight
BINARY_UNIX=$(BINARY_NAME)_unix
SOURCE_DIRECTORY=src

all: deps test build
build: 
		cd $(SOURCE_DIRECTORY) && go build -o $(BINARY_NAME) -v
test: 
		go get golang.org/x/tools/cmd/cover && go test -v ./... -coverprofile fmt
clean: 
		cd $(SOURCE_DIRECTORY) && go clean && rm -f $(BINARY_NAME) && rm -f $(BINARY_UNIX)
run:
		cd $(SOURCE_DIRECTORY) && ./$(BINARY_NAME)
deps:
		cd $(SOURCE_DIRECTORY) && dep ensure