package com.example.lab5;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.ArrayList;

@WebServlet("/temperatureWhenMoreThanAverage")
public class TemperatureWhenMoreThanAverageServlet extends HttpServlet {
    private WeatherForecastService weatherForecastService = new WeatherForecastService();

    public void init() {
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        response.setContentType("text/html");

        int temperatureWhenMoreThanAverage = weatherForecastService.getTemperatureWhenMoreThanAverage();

        request.setAttribute("temperatureWhenMoreThanAverage", temperatureWhenMoreThanAverage);

        getServletContext().getRequestDispatcher("/temperatureWhenMoreThanAverage.jsp").forward(request, response);
    }

    public void destroy() {
    }
}
