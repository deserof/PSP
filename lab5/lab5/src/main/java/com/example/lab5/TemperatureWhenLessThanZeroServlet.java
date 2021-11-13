package com.example.lab5;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet("/temperatureWhenLessThanZero")
public class TemperatureWhenLessThanZeroServlet extends HttpServlet {
    private WeatherForecastService weatherForecastService = new WeatherForecastService();

    public void init() {
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        response.setContentType("text/html");

        int tempLessThanZero = weatherForecastService.getTemperatureWhenLessThanZero();

        request.setAttribute("tempLessThanZero", tempLessThanZero);

        getServletContext().getRequestDispatcher("/temperatureWhenLessThanZero.jsp").forward(request, response);
    }

    public void destroy() {
    }
}
