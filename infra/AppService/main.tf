
data "azurerm_resources" "rg-movie-demo" {
  resource_group_name = "rg-movie-demo"
}

resource "azurerm_app_service_plan" "asp-movie-demo" {
  name                = "asp-movie-demo"
  location            = data.azurerm_resources.rg-movie-demo.location
  resource_group_name = data.azurerm_resources.rg-movie-demo.name

  sku {
    tier = "Standard"
    size = "S1"
  }
}

resource "azurerm_app_service" "as-movie-demo" {
  name                = "as-movie-demo"
  location            = data.azurerm_resources.rg-movie-demo.location
  resource_group_name = data.azurerm_resources.rg-movie-demo.name
  app_service_plan_id = azurerm_app_service_plan.asp-movie-demo.id

  site_config {
    dotnet_framework_version = "v4.0"
    scm_type                 = "LocalGit"
  }

  app_settings = {
    "SOME_KEY" = "some-value"
  }
}