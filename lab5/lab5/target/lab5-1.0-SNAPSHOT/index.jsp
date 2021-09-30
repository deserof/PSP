<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <title>lab5</title>
</head>
<body>
<h1><%= "Main page with choice images by fitres" %>
</h1>
<br/>

<form method="get" name="frm" action="images">
<h3>Search images by category name</h3>
<input  type="search" placeholder="Enter category name" name="text">
<input  type="submit" value="Search">
</form>

</body>
</html>