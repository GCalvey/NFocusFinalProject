Feature: Edgewords_eCommerce

@Coupon

Scenario: Apply coupon to items in my basket
	Given I am logged into a registered account
	When I add an item to my cart
	Then I can apply a coupon to get the correct discount

@ConfirmationOfOrder

Scenario: Confrim my order has been place with the correct order number
	Given I have an item within my cart
	When I use the checkout with vaild details
	Then My order is visble in my orders with the correct number
