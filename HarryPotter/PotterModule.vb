Public Module PotterModule
  Sub Main()
    Dim shop As New Shop(New ConsoleIO())
    shop.Greeting()
    shop.GetCustomerOrder()
  End Sub
End Module