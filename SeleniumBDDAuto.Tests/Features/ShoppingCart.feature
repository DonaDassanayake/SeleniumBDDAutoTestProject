Feature: ShoppingCart
	This contains tests related to add items to the shopping cart and checkout

@shoppingCart @AddItems
Scenario: Add a single item to cart and checkout
	Given I open the website
	And then the homepage should be displayed
	When I add item to cart and proceed to checkout
	Then the item should be added to the cart
	And the item total should be displayed as '$16.51'