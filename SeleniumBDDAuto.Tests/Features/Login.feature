Feature: Login
	Login Tests

@login
Scenario: Successfull Login with valid credentials
	Given I navigate to the Login Page
	And I enter username 'test_dona@gmail.com' and password 'Test1234'
	When I click on the Login button with valid credentials
	Then 'My account' should be seen on the page

@login
Scenario Outline: Unsuccessful Login
	Given I navigate to the Login Page
	And I enter username '<username>' and password '<password>'
	When I click on the Login button with Invalid credentials
	Then I should see an error message '<error>' on the Login page

	Examples:
	| scenario name    | username            | password | error                      |
	| Blank username   |                     | Test1234 | An email address required. |
	| Blank password   | test_dona@gmail.com |          | Password is required.      |
	| Invalid username | invalid_username    | Test1234 | Invalid email address.     |
	| Invalid password | test_dona@gmail.com | invalid  | Authentication failed.     |