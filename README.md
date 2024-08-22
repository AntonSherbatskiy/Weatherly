# Weatherly
___
Welcome to the Weather App! This application allows you to view weather forecasts for different cities as well as for your current location. The app provides real-time weather updates.


### Features
* Search by City: Enter the name of any city to get the current weather and forecast.
* Current Location Weather: Automatically detect your location and show the weather details.
* 7-Day Forecast: View the weather forecast for the next 7 days.

## Installation
### Prerequisites
* Docker

Clone the repository
```bash
cd weather-app
git clone https://github.com/AntonSherbatskiy/Weatherly.git
```
Open docker-compose.yml and copy your api key to `Configuration__OpenWeatherMapKey`

Run docker compose
```bash
docker compose up -d
```

Now you have 3 containers in the docker: `Backend`, `Frontend`, `Proxy` (NGINX Reverse proxy server). 
To get to the main page, open your browser and go to http://localhost:80. The API is available at http://localhost:5000/api/v1/weather/{city}