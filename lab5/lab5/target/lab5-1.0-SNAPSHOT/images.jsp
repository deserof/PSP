<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<html>
<head>
    <title>Searched Images</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet"
          integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous">
</head>
<body>
<div class="h-100 d-flex justify-content-center align-items-center">
    <div class="grid">
        <div class="d-flex justify-content-center mb-3">
            <div class="row">
                <h3>${name}</h3>
            </div>
        </div>
        <div class="row">
            <c:forEach var="img" items="${imgs}">
                <div class="col-auto">
                    <tr>
                        <img src="data:image/jpg;base64, ${img}" alt="image not found"/>
                    </tr>
                </div>
            </c:forEach>
        </div>
        <div class="d-flex justify-content-center">
            <div class="row">
                <a href="index" class="btn btn-primary mt-3">Back to main page</a>
            </div>
        </div>
    </div>
</div>
</body>
</html>
