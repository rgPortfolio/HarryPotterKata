Imports System.Security.Cryptography.X509Certificates
Imports HarryPotter.Contracts

Public Class Shop
  Public Property Basket
  Private ReadOnly _userIO As UserIO
  Private ReadOnly _orderDecorder As New Dictionary(Of String, Integer) From {{"first", 1}, {"second", 2}, {"third", 3}, {"fourth", 4}, {"fifth", 5}}

  Public Sub New(userIo As UserIO)
    _userIO = userIo
  End Sub

  'The integer methods and tests exist because I tested base functionality with them and did not want to removed them from my solution, good reminder to myself to start small
  'And that classes while they add value, can make the problem at hand more complex then it really is(in my head)
  Public Sub CreateBasketWithIntegers(numberOfBooks As Integer)
    Basket = New UserBasket(numberOfBooks)
  End Sub

  Public Sub CreateBasketWithBookList(userOrder As List(Of HarryPotterBook))
    Basket = New UserBasket(userOrder)
  End Sub

  Public Function Checkout() As Double
    Return Basket.GetPrice()
  End Function

  Public Sub Greeting()
    _userIO.WriteLine("Welcome to my shop! I don't always give the best prices, but I have unlimited stock.")
    _userIO.WriteLine("However, I only have the books 1-5 from HP.")
    _userIO.WriteLine("Please enter in your order as such, 2 copies of the fourth book")
  End Sub

  Public Sub GetCustomerOrder()
    _userIO.WriteLine("Enter in quit to stop entering books.")
    Dim bookList As New List(Of HarryPotterBook)
    
    Dim order As String = _userIO.ReadLine()
    While Not order.Equals("quit")
      Dim lowerOrder = order.ToLower()
      Dim splitOrder As String() = lowerOrder.Split()

      For books As Integer = 0 To splitOrder(0) - 1
        bookList.Add(New HarryPotterBook(_orderDecorder(splitOrder(4))))
      Next

      order = _userIO.ReadLine()
    End While

    If bookList.Count = 0 Then Return
    CreateBasketWithBookList(bookList)
    _userIO.WriteLine(Checkout())


  End Sub
End Class