package com.example.lab5;

import java.io.*;
import java.util.ArrayList;
import javax.servlet.ServletException;
import javax.servlet.http.*;
import javax.servlet.annotation.*;

@WebServlet("/images")
public class ImageServlet extends HttpServlet {
    private ImageService imageService = new ImageService();
    private String message;

    public void init() {
        message = "Results:";
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        response.setContentType("text/html");

        String categoryName = request.getParameter("text");

        ArrayList<String> imgs = imageService.getImagesByCategory(categoryName);

        request.setAttribute("imgs", imgs);
        request.setAttribute("name", message);

        getServletContext().getRequestDispatcher("/images.jsp").forward(request, response);
    }

    public void destroy() {
    }
}