
data "azurerm_resources" "rg-movie-demo" {
  resource_group_name = "rg-movie-demo"
}

resource "azurerm_app_service_plan" "asp-movie-demo" {
  name                = "asp-movie-demo"
  location            = "northeurope"
  resource_group_name = "rg-movie-demo"
  os_type             = "Linux"
  sku_name            = "B1"
}

resource "azurerm_linux_web_app" "example" {
  name                = "as-movie-demo"
  location            = "northeurope"
  resource_group_name = "rg-movie-demo"
  app_service_plan_id = azurerm_app_service_plan.asp-movie-demo.id
  site_config {}
}