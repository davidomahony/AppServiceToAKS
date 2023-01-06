data "azurerm_resource_group" "rg-movie-demo" {
  name = "rg-${local.name}"
}

resource "azurerm_container_group" "movie-demo-container-instance" {
  name                  = "cg-${local.name}"
  location              = "${data.azurerm_resource_group.rg-movie-demo.location}"
  resource_group_name   = "${data.azurerm_resource_group.rg-movie-demo.name}"
  ip_address_type       = "Public"
  dns_name_label        = "cg-${local.name}"
  os_type               = "Linux"

  container {
    name   = "${local.name}-container"
    image  = "mcr.microsoft.com/azuredocs/aci-helloworld:latest"
    cpu    = "0.5"
    memory = "1.5"
    ports {
      port     = 443
      protocol = "TCP"
    }
  }
}