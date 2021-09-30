<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<html>
<head>
    <title>Searched Images</title>
</head>
<body>
<h1>${name}</h1>

<c:forEach var="img" items="${imgs}">
    <tr>
        <img src="data:image/jpg;base64, ${img}" alt="image not found" />
    </tr>
</c:forEach>

</br>
<a href="index">Back to main page</a>

</body>
</html>
