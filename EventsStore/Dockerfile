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
WORKDIR /go/src/EventsStore/

# add source code
ADD src src
ADD Makefile .

# build the source
RUN make deps
RUN make build

RUN make test

# strip and compress the binary
RUN strip --strip-unneeded src/EventsStore
RUN upx src/EventsStore

FROM alpine:3.9

EXPOSE 4000

WORKDIR /root

COPY --from=builder /go/src/EventsStore/src/EventsStore .

CMD ["./EventsStore"]
