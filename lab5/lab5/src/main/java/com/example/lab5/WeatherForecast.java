package com.example.lab5;

public class WeatherForecast {
    private String temperature;
    private String day;
    private String weather;

    public WeatherForecast(String temperature, String weather, String day){
        this.temperature = temperature;
        this.weather = weather;
        this.day = day;
    }

    public String getDay() {
        return day;
    }

    public String getTemperature() {
        return temperature;
    }

    public String getWeather() {
        return weather;
    }
}
