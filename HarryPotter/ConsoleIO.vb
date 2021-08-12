Imports HarryPotter.Contracts

Public Class ConsoleIO
  Implements UserIO
  Public Sub WriteLine(message As String) Implements UserIO.WriteLine
    Console.WriteLine(message) 
  End Sub

  Public Function ReadLine() As String Implements UserIO.ReadLine
    Return Console.ReadLine()
  End Function

End Class