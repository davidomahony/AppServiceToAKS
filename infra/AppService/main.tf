
data "azurerm_resource_group" "rg-movie-demo" {
  name = "rg-movie-demo"
}

resource "azurerm_service_plan" "asp-movie-demo" {
  name                  = "asp-movie-demo"
  location              = "${data.azurerm_resource_group.rg-movie-demo.location}"
  resource_group_name   = "${data.azurerm_resource_group.rg-movie-demo.name}"
  os_type               = "Linux"
  sku_name              = "F1"
}

resource "azurerm_linux_web_app" "example" {
  name                  = "as-movie-demo"
  location              = "${data.azurerm_resource_group.rg-movie-demo.location}"
  resource_group_name   = "${data.azurerm_resource_group.rg-movie-demo.name}"
  service_plan_id       = azurerm_service_plan.asp-movie-demo.id
  site_config {
    always_on           = false
    application_stack {
      dotnet_version    = "6.0"
    }
  }
}