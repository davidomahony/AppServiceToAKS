# AppServiceToAKS
Sample project to show the journey from an App service to various different containerized environments.

## Role of the Applicaiton
Right now this is a very basic application which adds and removes movies to a list of watched and movies to watch. The aim of this application is to show what changes are needed to deploy the following application with several different environemnts.

## Environments
1. Azure App Services
2. Azure Kubernetes Services
3. Azure Container Instance
4. Azure Container Apps

## Pipeline Stages
Each enivornment will have its own pipeline which will cover the following aspects:
1. Building application
2. Unit Testing Application
3. Deploying application.
4. Integration Tests against application.

These four stages are chosen in an attempt to mimic an actual deployment to a standard environment. Such as a development or test environment. A production grade deployment may contain more stages but at a high level would tackle the steps mentioned earlier.

## Progressions
As we progress through the various envionments we will update the application to show how it can be modified to interact with various other Azure offerings. (Cosmos, KeyVault, etc)


