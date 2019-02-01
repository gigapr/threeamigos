#!/bin/bash

set -o xtrace               #prints commands to console

export ORGANISATION_NAME=threeamigos

export BUILD_NUMBER=$1
export IMAGE_NAME=$2
export DOCKER_HUB_USER=$3
export DOCKER_HUB_PASSWORD=$4
export BRANCH=$5

export TAG=$ORGANISATION_NAME/$IMAGE_NAME:$BUILD_NUMBER

docker build -t $IMAGE_NAME .

echo $BRANCH

if [ $BRANCH = 'master']
then
    echo "Pushing image to Docker Hub"
    docker tag $IMAGE_NAME $TAG
    docker login -u $DOCKER_HUB_USER -p $DOCKER_HUB_PASSWORD
    docker push $TAG
else
    echo "Not pushing image to docker. Current branch $BRANCH"
fi

docker logout