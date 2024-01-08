Feature: Shopping Cart
As a Customer I want to add an item to the shopping cart to be able to collect all items before I finalize the shopping.

    Background:
        Given I'm at Swag Labs login page
        And I fill in the login fields
        And I click the login button
        And I'm at Swag Labs landing page

    Scenario: Add item to the shopping cart
        When I click to add the Backpack to the cart
        Then The Backpack is added to the shopping cart
    
    Scenario: Update quantity of item in the shopping cart
        When I click to add the Backpack to the cart
        And I click to add the Bike Light to the cart
        And I click to remove the Backpack from the cart
        Then The items in the shopping cart are updated
        
    Scenario: Jump to item details
        When I click the Backpack name at the products page
        Then I am redirected to the Backpack details page
       
    Scenario: Complete checkout process
        Given I added an item to the cart
        And I clicked to see my shopping cart
        When I click the Checkout button
        And I fill in the checkout form with my info: 'Lorem', 'Ipsum', '1111111'
        And I click the Continue button
        And I click the Finish button on Checkout overview page
        Then I have finished my shopping
        