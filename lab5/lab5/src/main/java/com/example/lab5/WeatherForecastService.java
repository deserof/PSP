package com.example.lab5;

import java.util.ArrayList;
import java.util.*;

public class WeatherForecastService {
    public ArrayList<WeatherForecast> getWeatherForecast(){
        return new ArrayList<WeatherForecast>(Arrays.asList(
                new WeatherForecast("10","Sunny", "1"),
                new WeatherForecast("-10", "Cloudy", "2"),
                new WeatherForecast("15","Windy", "3"),
                new WeatherForecast("13","Sunny", "4"),
                new WeatherForecast("20","Sunny", "5"),
                new WeatherForecast("-55","heat ", "6"),
                new WeatherForecast("234","heat ", "7"),
                new WeatherForecast("-10","heat ", "8"),
                new WeatherForecast("22","Sunny", "9"),
                new WeatherForecast("4","rain ", "10"),
                new WeatherForecast("4","Sunny", "11"),
                new WeatherForecast("55","rain ", "12"),
                new WeatherForecast("-3","breeze ", "13"),
                new WeatherForecast("2","breeze ", "14"),
                new WeatherForecast("11","Windy", "15"),
                new WeatherForecast("14","fog ", "16"),
                new WeatherForecast("13","Sunny", "17"),
                new WeatherForecast("12","Sunny", "18"),
                new WeatherForecast("-13","fog ", "19"),
                new WeatherForecast("8","rain ", "20"),
                new WeatherForecast("5","rain ", "21"),
                new WeatherForecast("5","rain ", "22"),
                new WeatherForecast("0","Sunny", "23"),
                new WeatherForecast("-10","thunderstorm ", "24"),
                new WeatherForecast("1","Sunny", "25"),
                new WeatherForecast("4","Windy", "26"),
                new WeatherForecast("34","Sunny", "27"),
                new WeatherForecast("32","thunderstorm ", "28"),
                new WeatherForecast("22","Sunny", "29"),
                new WeatherForecast("23","rain ", "30"),
                new WeatherForecast("-1","Windy", "31")));
    }

    public int getAverageTemperature(){
        ArrayList<WeatherForecast> wet = getWeatherForecast();
        int average = 0;
        for (WeatherForecast item:wet) {
            average +=  Integer.parseInt(item.getTemperature());
        }

        return average / wet.size();
    }

    public int getTemperatureWhenMoreThanAverage(){
        int average = getAverageTemperature();
        int counter = 0;
        ArrayList<WeatherForecast> wet = getWeatherForecast();

        for (WeatherForecast item:wet) {
            if (Integer.parseInt(item.getTemperature()) > average) {
                counter++;
            }
        }

        return counter;
    }

    public int getTemperatureWhenLessThanZero(){
        int counter = 0;
        ArrayList<WeatherForecast> wet = getWeatherForecast();

        for (WeatherForecast item:wet) {
            if (Integer.parseInt(item.getTemperature()) < 0) {
                counter++;
            }
        }

        return counter;
    }

    public ArrayList<WeatherForecast> getMostHottestDays(){
        ArrayList<WeatherForecast> wet = getWeatherForecast();
        ArrayList<WeatherForecast> hottestDays = new ArrayList<WeatherForecast>();
int indexOfMax = 0;
        for (int i = 0; i < 3; i++){
            int max = Integer.parseInt(wet.get(0).getTemperature());
            for (int j = 0; j < wet.size(); j++){
                if(max < Integer.parseInt(wet.get(j).getTemperature())){
                    max = Integer.parseInt(wet.get(j).getTemperature());
                    indexOfMax = j;
                }
            }
            hottestDays.add(wet.get(indexOfMax));
            wet.remove(indexOfMax);
        }

        return hottestDays;
    }
}
