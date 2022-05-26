Imports System.IO
Imports Newtonsoft.Json


Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim outDir As String = "D:\work\VisualStudio2022\VB_practice\outputs\"
        Dim emp As Employee
        emp = New Employee
        With emp
            .FirstName = "Kevin"
            .LastName = "Drumm"
            .Gender = "Male"
            .JobRole = "Teacher"
            .Salary = 55000
        End With

        ReDim emp.SBinfo(1, 1)
        emp.SBinfo = {{1, 2}, {3, 4}}


        '' Serialize 
        Dim myString As String
        myString = JsonConvert.SerializeObject(emp, Formatting.Indented)
        'MsgBox(myString)

        '' Serialize and write to file
        File.WriteAllText(outDir & "\person.json", JsonConvert.SerializeObject(emp, Formatting.Indented))

        '' other way : streamwriter, serializer
        'Dim swPerson As StreamWriter
        'swPerson = New StreamWriter(outDir & "\person.json", True)
        'Dim myPersonserializer As New JsonSerializer()
        'myPersonserializer.Serialize(swPerson, emp)
        'swPerson.Close()

        '' make new object , deserialize
        'Dim emp2 As New Employee
        'emp2 = JsonConvert.DeserializeObject(myString, emp2.GetType)
        'emp2 = JsonConvert.DeserializeObject(Of Employee)(myString)

        'MsgBox(emp2.FirstName & " " & emp2.LastName & " " & emp2.Gender & " " & emp2.JobRole & " " & emp2.Salary)

        ' get json from file, deserialize, designate to new object

        Dim emp3 As New Employee
        Dim srperson As New StreamReader(outDir & "person.json")
        Dim myPersonserializer As New JsonSerializer()

        emp3 = myPersonserializer.Deserialize(srperson, emp3.GetType)
        MsgBox(emp3.FirstName & " " & emp3.LastName & " " & emp3.Gender & " " & emp3.JobRole & " " & emp3.Salary)
        MsgBox(emp3.SBinfo(0, 0) & " " & emp3.SBinfo(0, 1) & " " & emp3.SBinfo(1, 0) & " " & emp3.SBinfo(1, 1))

    End Sub
End Class

Public Class Person
    Public FirstName As String
    Public LastName As String
    Public Gender As String
End Class
Public Class Employee
    Inherits Person
    Public JobRole As String
    Public Salary As Decimal
    Public nSB As Integer
    Public SBinfo(,) As Integer

End Class
