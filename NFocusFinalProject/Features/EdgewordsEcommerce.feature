Feature: EdgewordsEcommerce

Background: 
    Given I am logged in as a registered user
    And I add an item to the cart

    
@Coupon

Scenario: Apply coupon to items in my basket
	Given I have applied a coupon 'edgewords'
	When I apply it I should recieve the correct amount of discount of '15'%
	Then The total price will include the discount product plus shipping

@ConfirmationOfOrder

Scenario: Confrim my order has been place with the correct order number
	Given I am on the checkout page
	When I use the checkout with vaild details
    Then My order is visble in my orders with the correct number



   