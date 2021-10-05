<%--
  Created by IntelliJ IDEA.
  User: Artem
  Date: 04-Oct-21
  Time: 9:36 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Edit</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet"
          integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous">
</head>
<body>
<h1>Edit employee</h1>
<form action="edit" method="post">
    <div class="form-group">
        <div class="col-md-4 mb-3">
            <label for="firstname">FirstName</label>
            <input class="form-control mb" id="firstname" name="firstName" placeholder="Enter firstname" value="${employee.firstName}">
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-4 mb-3">
            <label for="lastName">LastName</label>
            <input class="form-control mb" id="lastName" name="lastName" placeholder="Enter lastName" value="${employee.lastName}">
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-4 mb-3">
            <label for="phoneNumber">Phone number</label>
            <input class="form-control mb" id="phoneNumber" name="phoneNumber" placeholder="Enter phone number"
                   value="${employee.phoneNumber}">
        </div>
    </div>
    <button type="submit" class="btn btn-primary">Save</button>
</form>
</body>
</html>
