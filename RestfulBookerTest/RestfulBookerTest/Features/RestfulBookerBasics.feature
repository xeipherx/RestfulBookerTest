Feature: RestfulBookerBasics
	Feature for restfulbooker basic tests

Scenario: Healthcheck
	Given I ping the restful booker healthcheck service
	Then I expect a '201' response

Scenario: Get token
	Given I login with the default user
	Then I expect a '200' response
