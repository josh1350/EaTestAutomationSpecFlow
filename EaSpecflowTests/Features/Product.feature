Feature: Prodcut
    Create a new product

    Scenario: Create a product and verify the details
        Given I click the Product menu
        And I click the "Create" link
        And I create product with the following details

        When I click the Details link of the newly created product
        Then I see all the product details are created as expected