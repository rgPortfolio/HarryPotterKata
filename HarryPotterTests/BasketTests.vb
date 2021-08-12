Imports NUnit.Framework
Imports HarryPotter


<TestFixture()>
Public Class BasketTests

  <Test()>
  Public Sub CanStartWithSetNumberOfBooks()
    Dim basket As New UserBasket(5)
    Assert.AreEqual(5, basket.Books.Count())
  End Sub

  <Test()>
  Public Sub CanTakeInBookListCorrectly()
    Dim list As New List(Of HarryPotterBook)
    list.Add(New HarryPotterBook(4))
    list.Add(New HarryPotterBook(2))
    list.Add(New HarryPotterBook(1))
    Dim shop As New Shop(New ConsoleIO())
    shop.CreateBasketWithBookList(list)
    Assert.AreEqual(shop.Basket.Books.Count, list.Count)
  End Sub

  <Test()>
  Public Sub DuplicateInThreeBooksCountsAsFivePercentDiscountAndOneFullPriceBook()
    Dim shop As New Shop(New ConsoleIO())
    shop.CreateBasketWithIntegers(3)
    shop.Basket.Books(0).BookNumber = 5
    Assert.AreEqual(23.2, shop.Checkout())
  End Sub

  <Test()>
  Public Sub MultipleSetsOfBooksArePricedCorrectly()
    Dim shop As New Shop(New ConsoleIO())
    shop.CreateBasketWithIntegers(22)
    shop.Basket.Books(0).BookNumber = 5
    shop.Basket.Books(2).BookNumber = 5
    shop.Basket.Books(13).BookNumber = 1
    shop.Basket.Books(8).BookNumber = 6
    shop.Basket.Books(4).BookNumber = 7
    Assert.AreEqual(165.2, shop.Checkout())
  End Sub
End Class

