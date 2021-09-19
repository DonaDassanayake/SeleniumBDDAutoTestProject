Feature: CartCheckout
	Add items into the shopping cart and checkout

@items @shoppingcart
Scenario Outline: Add single item to shopping cart and checkout
	Given I login with valid credentials
	And I add an item - '<itemName>' in the '<menuName>' menu to shopping cart	
	When I proceed to checkout
	Then the product should be listed in the final checkout
	And the total price of the cart should be displayed

	Examples: 
	| menuName | itemName |
	| Dresses  | item1    |
	| T-shirts | item2     |
	
@items @shoppingcart
Scenario Outline: Add multiple items to shopping cart and checkout
	Given I login with valid credentials
	And I add an item - '<itemName1>' in the '<menuName1>' menu to shopping cart	
	* I click on Continue shopping button
	* I add an item - '<itemName2>' in the '<menuName2>' menu to shopping cart	
	When I proceed to checkout
	Then products should be listed in the final checkout
	And the total price of the cart should be displayed
	
	Examples: 
	| menuName1 | itemName1 | menuName2 | itemName2 |
	| Dresses   | item1     | T-shirts  | item2     |
	