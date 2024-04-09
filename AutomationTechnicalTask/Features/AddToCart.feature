Feature: AddToCart
  As an unregistered user, I want to add a AC1200 Gigabit WiFi to my cart and validate it

Scenario: Add a AC1200 Gigabit WiFi Router to the cart and validate
  Given I navigate to "https://www.amazon.com/"
  When I search for "AC1200 Gigabit WiFi Router (Archer A6) - Dual Band MU-MIMO Wireless Internet Router, 4 x Antennas, OneMesh and AP mode, Long Range Coverage"
  And I add the item to the cart
  Then The cart should contain "1" AC1200 Gigabit WiFi with correct details
 


