Feature: ManageEnergyOrders

  Scenario: Verify that a candidate is able to login and receive a token
    Given that a POST call is made to ENSEK/login resource with a username "test" and a password "testing"
    Then the candidate should get a status code 200
    And a token should be generated
    And a success message should be displayed

  Scenario: Verify that a candidate is able to reset test data
    Given that a POST call is made to ENSEK/reset resource
    Then the candidate should get a status code 200
    And a success message should be displayed

  Scenario: Verify that a candidate is able to buy a quantity of Gas
    Given that a PUT call is made on ENSEK/buy/1/1000 resource
    Then the candidate should get a status code 200
    And a message "You have purchased 2000 m³ at a cost of 340.0 there are 1000 units remaining. Your order id is 31a688a2-dd46-4092-a2da-72a33b924ba4" should be displayed

  Scenario: Verify that a candidate is able to buy a quantity of Electricity
    Given that a PUT call is made on ENSEK/buy/3/1500 resource
    Then the candidate should get a status code 200
    And a message "You have purchased 1500 kWh at a cost of 705.0 there are 2822 units remaining. Your order id is 7755f299-eba2-4807-a60e-85edf7cb9165" should be displayed

  Scenario: Verify that a candidate is able to buy a quantity of Oil
    Given that a PUT call is made on ENSEK/buy/4/10 resource
    Then the candidate should get a status code 200
    And a message "You have purchased 10 Litres at a cost of 6.0 there are 10 units remaining. Your order id is c2d9ef31-a0ab-445f-9367-682c8691f1fb" should be displayed

  Scenario: Verify that a candidate is able to view details of Gas recently purchased
    Given that a GET call is made on ENSEK/orders/1 resource
    Then the candidate should get a status code 500
    And a message "Internal Service Error" should be displayed

  Scenario: Verify that a candidate is able to view details of Electricity recently purchased
    Given that a GET call is made on ENSEK/orders/3 resource
    Then the candidate should get a status code 500
    And a message "Internal Service Error" should be displayed

  Scenario: Verify that a candidate is able to view details of Oil recently purchased
    Given that a GET call is made on ENSEK/orders/4 resource
    Then the candidate should get a status code 500
    And a message "Internal Service Error" should be displayed

  