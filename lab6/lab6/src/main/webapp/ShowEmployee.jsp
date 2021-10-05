<%--
  Created by IntelliJ IDEA.
  User: Artem
  Date: 04-Oct-21
  Time: 9:35 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@page import="lab6.lab6.ShowEmployeeServlet"%>
<html>
<head>
    <title>Employees</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet"
          integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous">
</head>
<body>

<h1>Employees</h1>

<table class="table">
    <thead>
    <tr>
        <th>
            <h3>FirstName</h3>
        </th>
        <th>
            <h3>LastName</h3>
        </th>
        <th>
            <h3>PhoneNumber</h3>
        </th>
        <th></th>
    </tr>
    </thead>
    <tbody>
    <c:forEach var="employee" items="${employees}">
    <tr>
        <td>
            <c:out value="${employee.firstName}"/>
        </td>
        <td>
            <p><c:out value="${employee.lastName}"/></p>
        </td>
        <td>
            <p><c:out value="${employee.phoneNumber}"/></p>
        </td>
        <td>
            <a href="edit?id=${employee.id}">Edit</a>
        </td>
        <td>
            <a href="delete?id=${employee.id}">Delete</a>
        </td>
        </c:forEach>
    </tbody>
</table>

</body>
</html>