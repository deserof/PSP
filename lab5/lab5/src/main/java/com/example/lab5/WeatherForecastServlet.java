package com.example.lab5;

        import java.io.*;
        import java.util.ArrayList;
        import javax.servlet.ServletException;
        import javax.servlet.http.*;
        import javax.servlet.annotation.*;

@WebServlet("/weatherForecast")
public class WeatherForecastServlet extends HttpServlet {
    private WeatherForecastService weatherForecastService = new WeatherForecastService();

    public void init() {
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        response.setContentType("text/html");

        ArrayList<WeatherForecast> weather = weatherForecastService.getWeatherForecast();

        request.setAttribute("weatherForecast", weather);

        getServletContext().getRequestDispatcher("/weatherForecast.jsp").forward(request, response);
    }

    public void destroy() {
    }
}

