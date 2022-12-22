terraform {
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
    tenant_id       = var.tenant_id
    client_id       = var.agent_client_id
    client_secret   = var.agent_client_secret
    subscription_id = var.subscription_id
}