Imports HarryPotter
Imports NUnit.Framework

<TestFixture()>
  Public Class BookTests

    <Test()>
    Public Sub NumberIsAssignedToBookFromConstructor()
      Dim book As New HarryPotterBook(2)
      Assert.AreEqual(2, book.BookNumber)
    End Sub

  End Class