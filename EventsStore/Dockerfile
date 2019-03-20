FROM golang:1.8.5-jessie as builder

# install xz
RUN apt-get update && apt-get install -y \
    xz-utils \
&& rm -rf /var/lib/apt/lists/*

# install UPX
ADD https://github.com/upx/upx/releases/download/v3.94/upx-3.94-amd64_linux.tar.xz /usr/local
RUN xz -d -c /usr/local/upx-3.94-amd64_linux.tar.xz | \
    tar -xOf - upx-3.94-amd64_linux/upx > /bin/upx && \
    chmod a+x /bin/upx

# setup the working directory
WORKDIR /go/src/eventsstore/src

# add source code
ADD src .

RUN go get -v

RUN ls .

# build the source
RUN CGO_ENABLED=0 GOOS=linux go build -a -installsuffix cgo -o main *.go

# run tests
RUN go test ./... -v

# strip and compress the binary
RUN strip --strip-unneeded main
RUN upx main

# use a minimal alpine image
FROM alpine:3.7

# set working directory
WORKDIR /root

# copy the binary and templates from builder
COPY --from=builder /go/src/eventsstore/src/main .

# run the binary
CMD ["./main"]