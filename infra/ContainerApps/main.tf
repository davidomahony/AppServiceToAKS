// Create registry
// Create container instance


data "azurerm_resource_group" "rg-movie-demo" {
  name = "rg-movie-demo"
}

resource "azurerm_container_registry" "movie-demo-registry" {
  name                = "movie-demo-registry"
  resource_group_name = azurerm_resource_group.rg-movie-demo.name
  location            = azurerm_resource_group.rg-movie-demo.location
  sku                 = "Basic"
  admin_enabled       = false
}

// May need to give different container groups an identity with access to registry