To run the application in Minikube

`kubectl create -f ./threeamigos-namespace.yaml`

`kubectl --namespace=threeamigos apply -f ./MongoDb/minikube_hostpath.yaml`

`kubectl --namespace=threeamigos kubectl apply -f ./MongoDb/mongo-statefulset.yaml`