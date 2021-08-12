Imports HarryPotter
Imports NUnit.Framework

  <TestFixture()>
  Public Class ShopTests

    <Test()>
    Public Sub ChargesEightDollarsForOneBook()
      Dim shop As New Shop(New ConsoleIO())
      shop.CreateBasketWithIntegers(1)
      Assert.AreEqual(8.00, shop.Checkout())
    End Sub

    <Test()>
    Public Sub AppliesFivePercentDiscountForTwoBooks()
      Dim shop As New Shop(New ConsoleIO())
      shop.CreateBasketWithIntegers(2)
      shop.Basket.Books(0).BookNumber = 1
      shop.Basket.Books(1).BookNumber = 2
      Assert.AreEqual(15.20, shop.Checkout())
    End Sub

    <Test()>
    Public Sub AppliesTenPercentDiscountForThreeBooks()
      Dim shop As New Shop(New ConsoleIO())
      shop.CreateBasketWithIntegers(3)
      shop.Basket.Books(0).BookNumber = 1
      shop.Basket.Books(1).BookNumber = 2
      shop.Basket.Books(2).BookNumber = 3
      Assert.AreEqual(21.60, shop.Checkout())
    End Sub

    <Test()>
    Public Sub AppliesTwentPercentDiscountWithFourBooks()
      Dim shop As New Shop(New ConsoleIO())
      shop.CreateBasketWithIntegers(4)
      shop.Basket.Books(0).BookNumber = 1
      shop.Basket.Books(1).BookNumber = 2
      shop.Basket.Books(2).BookNumber = 3
      shop.Basket.Books(3).BookNumber = 4
      Assert.AreEqual(25.60, shop.Checkout())
    End Sub

    <Test()>
    Public Sub ApplieesTwentyFivePercentDiscountForFiveBooks()
      Dim shop As New Shop(New ConsoleIO())
      shop.CreateBasketWithIntegers(5)
      shop.Basket.Books(0).BookNumber = 1
      shop.Basket.Books(1).BookNumber = 2
      shop.Basket.Books(2).BookNumber = 3
      shop.Basket.Books(3).BookNumber = 4
      shop.Basket.Books(4).BookNumber = 5
      Assert.AreEqual(30.00, shop.Checkout())
    End Sub 

End Class
