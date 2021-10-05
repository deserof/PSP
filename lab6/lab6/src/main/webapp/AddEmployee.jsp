<%--
  Created by IntelliJ IDEA.
  User: Artem
  Date: 04-Oct-21
  Time: 9:36 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Add</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet"
          integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous">
</head>
<body>
<h1>Add employee</h1>
<form action="add" method="post">
    <div class="form-group">
    <div class="col-md-4 mb-3">
        <label for="firstname">FirstName</label>
        <input class="form-control mb" id="firstname" name="firstName" placeholder="Enter firstname">
    </div>
    </div>
    <div class="form-group">
        <div class="col-md-4 mb-3">
            <label for="lastName">LastName</label>
            <input class="form-control mb" id="lastName" name="lastName" placeholder="Enter lastName">
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-4 mb-3">
            <label for="phoneNumber">Phone number</label>
            <input class="form-control mb" id="phoneNumber" name="phoneNumber" placeholder="Enter phone number">
        </div>
    </div>
    <button type="submit" class="btn btn-primary">Save</button>
</form>
</body>
</html>
