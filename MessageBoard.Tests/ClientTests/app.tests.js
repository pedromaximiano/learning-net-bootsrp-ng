/// <reference path="../scripts/jasmine.js" />
/// <reference path="../../messageboard/js/myapp.js" />

// app.tests.js
describe("myapp tests", function() {
    it("isDebug", function() {
        expect(app.isDebug).toEqual(true);
    });

    it("log", function() {
        expect(app.log).toBeDefined();
        app.log("testing");
    });
})