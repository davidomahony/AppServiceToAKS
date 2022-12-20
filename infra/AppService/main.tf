
data "azurerm_resources" "rg-movie-demo" {
  resource_group_name = "rg-movie-demo"
}

resource "azurerm_service_plan" "asp-movie-demo" {
  name                = "asp-movie-demo"
  location            = "northeurope"
  resource_group_name = "rg-movie-demo"
  os_type             = "Linux"
  sku_name            = "F1"
}

resource "azurerm_linux_web_app" "example" {
  name                = "as-movie-demo"
  resource_group_name = "rg-movie-demo"
  location            = azurerm_service_plan.asp-movie-demo.location
  service_plan_id     = azurerm_service_plan.asp-movie-demo.id
  site_config {
    always_on = false
  }
}