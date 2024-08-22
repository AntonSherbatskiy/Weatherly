import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AppComponent} from "../components/main/app.component";
import {HeaderComponent} from "../components/header/header.component";
import {FooterComponent} from "../components/footer/footer.component";
import {BrowserModule} from "@angular/platform-browser";
import {WeatherContainerComponent} from "../components/weather-container/weather-container.component";
import {WeatherCardComponent} from "../components/weather-container/weather-card/weather-card.component";
import {RouterModule, RouterOutlet} from "@angular/router";
import {
  WeatherSelectorListComponent
} from "../components/weather-container/weather-selector-list/weather-selector-list.component";
import {routes} from "../config/routes";
import {
  WeatherSelectComponent
} from "../components/weather-container/weather-selector-list/weather-select/weather-select.component";
import {HttpClientModule} from "@angular/common/http";
import {
  WeatherSearchComponent
} from "../components/weather-container/weather-selector-list/weather-search/weather-search.component";
import {LoaderComponent} from "../components/helpers/loader/loader.component";

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    WeatherContainerComponent,
    WeatherCardComponent,
    WeatherSelectComponent,
    WeatherSelectorListComponent,
    WeatherSearchComponent,
    LoaderComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    RouterOutlet,
    HttpClientModule,
    RouterModule.forRoot(routes)
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
