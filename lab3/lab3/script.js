var buttonShowUsers = document.getElementById('userbut');
var buttonClear = document.getElementById('clear');
var container = document.getElementById('container');

buttonShowUsers.onclick = function() {
    person1 = { name: "Tom", age: 37 };
    person2 = { name: "John", age: 18 };
    person3 = { name: "Bob", age: 25 };

    const users = new Array();
    users.push(person1);
    users.push(person2);
    users.push(person3);

    for (let i = 0; i < users.length; i++) {
        container.append(document.createElement('hr'), 'Name: ' + users[i].name + ' Age: ' + users[i].age)
    }
};

buttonClear.onclick = function () {
    container.innerHTML = '';
}