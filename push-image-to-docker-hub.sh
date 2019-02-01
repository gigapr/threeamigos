#!/bin/bash

set -o xtrace               #prints commands to console

export ORGANISATION_NAME=threeamigos

export BUILD_NUMBER=$1
export IMAGE_NAME=$2
export DOCKER_HUB_USER=$3
export DOCKER_HUB_PASSWORD=$4
export PUBLISH_TO_DOCKER_HUB=$5

export TAG=$ORGANISATION_NAME/$IMAGE_NAME:$BUILD_NUMBER

docker build -t $IMAGE_NAME .
docker tag $IMAGE_NAME $TAG
docker login -u $DOCKER_HUB_USER -p $DOCKER_HUB_PASSWORD

echo '$PUBLISH_TO_DOCKER_HUB'

if [ $PUBLISH_TO_DOCKER_HUB ]
then
    docker push $TAG
fi

docker logout