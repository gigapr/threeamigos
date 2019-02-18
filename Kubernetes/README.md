## How to run in Minikube

- Install Istio in Kubernetes

- `kubectl create -f ./threeamigos-namespace.yaml istio-injection=enabled`

- `kubectl --namespace=threeamigos apply -f ./MongoDb/minikube_hostpath.yaml`

- `kubectl --namespace=threeamigos apply -f ./MongoDb/mongo-statefulset.yaml`