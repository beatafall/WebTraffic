var MainModel = function () {
    var self = this;
    self.garage = ko.observableArray();
    self.driver = ko.observableArray();
    self.allDriver = ko.observableArray();
    self.buses = ko.observableArray();
    self.lines = ko.observableArray();
    self.lineStations = ko.observableArray();
    self.error = ko.observable();

    var garageUri = '/api/garage/';

    var driverUri = '/api/busdriver/';

    var allDriverUri = '/api/driver/';

    var linesUri = '/api/line/';

    var lineStationUri = '/api/LineStation/';

    var allBusUri = '/api/AllBus/';

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

    function ajaxHelperForLines(uri, method, data) {
        self.error('');
        return $.ajax({
            type: method,
            url: uri + self.lineStations.lineId(),
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getBusInTheGarage() {
        ajaxHelper(garageUri, 'GET').done(function (data) {
            self.garage(data);
        });
    }

    function getFreeDrivers() {
        ajaxHelper(driverUri, 'GET').done(function (data) {
            self.driver(data);
        });
    }

    function getAllDrivers() {
        ajaxHelper(allDriverUri, 'GET').done(function (data) {
            self.allDriver(data);
        });
    }

    function getAllLines() {
        ajaxHelper(linesUri, 'GET').done(function (data) {
            self.lines(data);
        });
    }

    function getLineStation() {
        ajaxHelper(lineStationUri, 'GET').done(function (data) {
            self.lineStations(data);
        });
    }

    function getAllBus() {
        ajaxHelper(allBusUri, 'GET').done(function (data) {
            self.buses(data);
        });
    }

    // osszes busz ami a garazsban van
    getBusInTheGarage();

    getAllBus();

    getFreeDrivers();

    getAllDrivers();

    getAllLines();

};

ko.applyBindings(new MainModel());

