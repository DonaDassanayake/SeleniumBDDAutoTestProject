Feature: CartCheckout
	Add items into the shopping cart and checkout

@items @shoppingcart
Scenario Outline: Add single item to shopping cart and checkout
	Given I login with valid credentials
	And I add an item - '<itemNumber>' in the '<menuName>' menu to shopping cart
	When I proceed to checkout
	Then the product should be listed in the final checkout
	And the total price of the cart should be displayed

	Examples:
		| menuName | itemNumber |
		| Dresses  | 1          |
		| T-shirts | 1          |

@items @shoppingcart
Scenario Outline: Add multiple items to shopping cart and checkout
	Given I login with valid credentials
	And I add an item - '<itemNumber1>' in the '<menuName1>' menu to shopping cart
	* I click on Continue shopping button
	* I add an item - '<itemNumber2>' in the '<menuName2>' menu to shopping cart
	When I proceed to checkout
	Then products should be listed in the final checkout
	And the total price of the cart should be displayed

	Examples:
		| menuName1 | itemNumber1 | menuName2 | itemNumber2 |
		| Dresses   | 1           | T-shirts  | 1           |