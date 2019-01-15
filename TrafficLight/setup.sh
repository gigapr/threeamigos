#!/bin/bash

set -e & set -o pipefail    #to exit on command error
set -o xtrace               #prints commands to console

cd $(dirname $0)

export PORT=8080

dep ensure