var ViewModel = function () {
    var self = this;
    self.students = ko.observableArray();
    self.details = ko.observableArray();
    self.error = ko.observable();
    self.newStudent = {
        Name: ko.observable(),
        LastName: ko.observable(),
        BirthDate: ko.observable(),
        SID: ko.observable(),
        Course: ko.observable(),
        GroupName: ko.observable(),
        Specialty: ko.observable()
    };

    var studentsUri = '/api/students/';

    //funkcja pomocnicza AJAX()
    function ajaxHelper(uri, method, data) {
        self.error('');
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }
    //metoda zwrócenia wszystkich studentów
    function getAllStudents() {
        ajaxHelper(studentsUri, 'GET').done(function (data) {
            self.students(data);
        });
    }
    //metoda zwrócenia szczegółowych danych o obiekcie/studencie
    self.getStudentDetails = function (item) {
        ajaxHelper(studentsUri + item.ID, 'GET').done(function (data) {
            self.details(data);
        });
    };
    //metoda dodania nowego studenta
    self.addNewStudent = function (formElement) {
        var student = {
            Name: self.newStudent.Name(),
            LastName: self.newStudent.LastName(),
            BirthDate: self.newStudent.BirthDate(),
            SID: self.newStudent.SID(),
            Course: self.newStudent.Course(),
            GroupName: self.newStudent.GroupName(),
            Specialty: self.newStudent.Specialty()
        };

        ajaxHelper(studentsUri, 'POST', student).done(function (item) {
            self.students.push(item);
            alert("Success!");
        });
    };
    //metoda usunięcia studenta
    self.deleteStudent = function (item) {
        var caution = confirm("Are you sure you want to remove this object?");
        if (caution === true) {
            ajaxHelper(studentsUri + item.ID, 'DELETE').done(function (item) {
                alert("Object has been successfully removed.");
                self.students.remove(item);
                location.reload(true);
            });
        }
        else {
            alert("Deletion process interrupted.");
        }
    };

    getAllStudents();
};

ko.applyBindings(new ViewModel());