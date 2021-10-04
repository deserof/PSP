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
        <h1>Main page with choice images by filters</h1>
        </div>
        <form method="get" name="frm" action="images">
            <div class="row g-3">
                <div class="col-auto">
                    <label><h5>Search images by category name</h5></label>
                </div>
                <div class="col-auto">
                    <input class="form-control" type="search" placeholder="Enter category name" name="text">
                </div>
                <div class="col-auto">
                    <input class="btn btn-primary" type="submit" value="Search">
                </div>
            </div>
        </form>
    </div>
</div>
</body>
</html>