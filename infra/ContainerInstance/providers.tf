terraform {
  backend "azurerm" {
    resource_group_name  = "rg-movie-demo"
    storage_account_name = "samoviedemo"
    container_name       = "movie-api-containerinstance"
    key                  = "infra-tfstate"
  }
  required_version = ">=0.12"

  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = ">=2.97.0"
    }
  }
}

provider "azurerm" {
  features {}
}