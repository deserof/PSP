<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <title>lab5</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet"
          integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous">
    <link rel="stylesheet" href="style.css">
</head>
<body>
<div class="h-100 d-flex justify-content-center align-items-center">
    <div class="grid">
        <div class="row">
        </div>
        <form method="get" name="frm" action="weatherForecast">
            <div class="row g-3">
                <div class="col-auto">
                    <label><h5>Weather forecast</h5></label>
                </div>
                <div class="col-auto">
                    <input class="btn btn-primary" type="submit" value="Show">
                </div>
            </div>
        </form>

        <form method="get" name="frm" action="temperatureWhenLessThanZero">
            <div class="row g-3">
                <div class="col-auto">
                    <label><h5>Temperature When Less Than Zero</h5></label>
                </div>
                <div class="col-auto">
                    <input class="btn btn-primary" type="submit" value="Show">
                </div>
            </div>
        </form>

        <form method="get" name="frm" action="mostHottestDays">
            <div class="row g-3">
                <div class="col-auto">
                    <label><h5>Most Hottest Days</h5></label>
                </div>
                <div class="col-auto">
                    <input class="btn btn-primary" type="submit" value="Show">
                </div>
            </div>
        </form>

        <form method="get" name="frm" action="averageTemperature">
            <div class="row g-3">
                <div class="col-auto">
                    <label><h5>Average Temperature</h5></label>
                </div>
                <div class="col-auto">
                    <input class="btn btn-primary" type="submit" value="Show">
                </div>
            </div>
        </form>

        <form method="get" name="frm" action="temperatureWhenMoreThanAverage">
            <div class="row g-3">
                <div class="col-auto">
                    <label><h5>Temperature When More Than Average</h5></label>
                </div>
                <div class="col-auto">
                    <input class="btn btn-primary" type="submit" value="Show">
                </div>
            </div>
        </form>
    </div>
</div>
</body>
</html>