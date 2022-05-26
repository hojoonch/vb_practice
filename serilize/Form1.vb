' BinaryFormatter를 이용하는 방법은 보안에 문제가 있다고 한다.
' 사용하지 말라고 하며 대신 JSON. 또는 XML 사용이 권장되고 있다.
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

' use Newtonsoft Json
'Imports Newtonsoft.Json


Imports System.IO

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim outDir = "d:\work\VisualStudio2022\VB_practice\outputs\"
        Dim emp As New Employee
        emp.FirstName = "Kevin"
        emp.LastName = "Drumm"
        emp.Gender = "Male"
        emp.JobRole = "Teacher"
        emp.Salary = 55000

        MsgBox(emp.FirstName & " " & emp.LastName & " " & emp.Gender & " " & emp.JobRole & " " & emp.Salary)

        ''BinaryFormatter를 이용한 serization
        Dim s1 As New FileStream(outDir & "\binarydata.txt", FileMode.Create)
        Dim fm1 As New BinaryFormatter
        fm1.Serialize(s1, emp)
        s1.Close()

        ' BinaryFormatter를 이용한 
        Dim emp2 As Employee
        Dim s2 As New FileStream(outDir & "\binarydata.txt", FileMode.Open)
        Dim fm2 As New BinaryFormatter
        emp2 = fm2.Deserialize(s2)
        s2.Close()
        MsgBox(emp2.FirstName & " " & emp2.LastName & " " & emp2.Gender & " " & emp2.JobRole & " " & emp2.Salary)
    End Sub
End Class
<Serializable> Public Class Person
    Public FirstName As String
    Public LastName As String
    Public Gender As String

    Public Function sayHi() As String
        Return "hi"
    End Function
End Class

<Serializable> Public Class Employee
    Inherits Person
    Public JobRole As String
    Public Salary As Decimal
End Class