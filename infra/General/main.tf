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