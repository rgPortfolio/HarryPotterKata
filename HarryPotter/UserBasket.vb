Public Class UserBasket
  Public Property Books As New List(Of HarryPotterBook)

  Public Sub New(userOrder As  List(Of HarryPotterBook))
    Books.AddRange(userOrder)
  End Sub

  Public Sub New(userOrder As  Integer)
    For i As Integer = 0 To userOrder - 1
      Books.Add(New HarryPotterBook(2))
    Next
  End Sub

  Public Function GetPrice() As Double
    Dim bookSets = GetBookGroupings()
    Dim setRemainder As Integer
    Dim salesTotal As Double = 0
    Dim bookListCount As List(Of Integer) = GetInitialBookListCount(bookSets)

    GetRemainingSets(setRemainder, bookListCount)

    While setRemainder > 1
      AddSetPriceToTotal(setRemainder, salesTotal)
      setRemainder = 0
      UpdateBookCount(bookListCount)
      GetRemainingSets(setRemainder, bookListCount)
    End While

    GetFinalBookSale(bookListCount, salesTotal)
    Return salesTotal
  End Function

  Private Sub UpdateBookCount(bookList As List(Of Integer))
    For count As Integer = 0 To bookList.Count - 1
      If bookList(count) > 0 Then
        bookList(count) -= 1
      End If
    Next
  End Sub

  Private Sub GetFinalBookSale(bookList As List(Of Integer), ByRef salesTotal As Double)
    For count As Integer = 0 To bookList.Count - 1
      If bookList(count) > 0 Then
        salesTotal += (bookList(count) * 8.0)
      End If
    Next
  End Sub

  Private Sub GetRemainingSets(ByRef setRemainder As Integer, bookListCount As List(Of Integer))
    For Each bookCount As Integer In bookListCount
      If bookCount > 0 Then
        setRemainder += 1
      End If
    Next
  End Sub

  Private Function GetInitialBookListCount(bookSets As List(Of IGrouping(Of Integer, HarryPotterBook))) As List(Of Integer)
    Dim bookListCount As New List(Of Integer)
    For Each harryPotterBooks As IGrouping(Of Integer, HarryPotterBook) In bookSets
      bookListCount.Add(harryPotterBooks.Count())
    Next
    Return bookListCount
  End Function
  Private Function GetCurrentBookListCount(bookSets As List(Of IGrouping(Of Integer, HarryPotterBook))) As List(Of Integer)
    Dim bookListCount As New List(Of Integer)
    For Each harryPotterBooks As IGrouping(Of Integer, HarryPotterBook) In bookSets
      bookListCount.Add(harryPotterBooks.Count() - 1)
    Next
    Return bookListCount
  End Function

  Private Sub AddSetPriceToTotal(setRemainder As Integer, ByRef salesTotal As Double)
    If setRemainder = 1 Then
      salesTotal += 8.0
    ElseIf setRemainder = 2 Then
      salesTotal += 15.2
    ElseIf setRemainder = 3 Then
      salesTotal += 21.6
    ElseIf setRemainder = 4 Then
      salesTotal += 25.6
    ElseIf setRemainder = 5 Then
      salesTotal += 30.0
    End If
  End Sub

  Private Function GetBookGroupings() As List(Of IGrouping(Of Integer, HarryPotterBook))
    Return Books.GroupBy(Function(b) b.BookNumber).ToList()
  End Function

End Class

