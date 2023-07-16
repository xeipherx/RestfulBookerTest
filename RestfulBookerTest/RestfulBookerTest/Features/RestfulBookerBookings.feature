Feature: RestfulBookerBookings
	Feature for creating tests on booking 

Scenario: Create a new booking
	Given I create a new booking with these data
	| firstname | lastname   | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
	| Salty     | Mcsaltface | 100        | true        | 2013-02-23 | 2013-02-24 | salt            |
	Then I expect a '200' response
	And The response has a booking id

Scenario: Check getbooking model
	Given I request for booking ID '2532'
	Then The response model should match the model