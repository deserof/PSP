<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<html>
<head>
    <title>Most hottest days</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet"
          integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous">
</head>
<body>

<div>
    <h3>Days when the temperature was more than average is ${temperatureWhenMoreThanAverage}</h3>
</div>

<form method="get" name="frm" action="index">
    <div class="row g-3">
        <div class="col-auto">
            <label><h5>Back</h5></label>
        </div>
        <div class="col-auto">
            <input class="btn btn-primary" type="submit" value="Back">
        </div>
    </div>
</form>

</table>
</body>
</html>


