// Create registry
// Create container instance


data "azurerm_resource_group" "rg-movie-demo" {
  name = "rg-movie-demo"
}

resource "azurerm_container_registry" "movie-demo-registry" {
  name                  = "moviedemoregistry"
  location              = "${data.azurerm_resource_group.rg-movie-demo.location}"
  resource_group_name   = "${data.azurerm_resource_group.rg-movie-demo.name}"
  sku                   = "Basic"
  admin_enabled         = false
}

resource "azurerm_container_group" "movie-demo-container-instance" {
  name                  = "movie-demo-container-instance"
  location              = "${data.azurerm_resource_group.rg-movie-demo.location}"
  resource_group_name   = "${data.azurerm_resource_group.rg-movie-demo.name}"
  ip_address_type       = "Public"
  dns_name_label        = "movie-demo-container-instance"
  os_type               = "Linux"

  container {
    name   = "movie-demo-container"
    image  = "mcr.microsoft.com/azuredocs/aci-helloworld:latest"
    cpu    = "0.5"
    memory = "1.5"
    // May need to set env value in here
    environment_variables  = {
      "omdbAppKey" = var.omdbAppKey
    }

    ports {
      port     = 443
      protocol = "TCP"
    }
  }

  tags = {
    environment = "testing"
  }
}

// May need to give different container groups an identity with access to registry