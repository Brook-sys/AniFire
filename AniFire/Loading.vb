Public NotInheritable Class Loading

    Private Sub Loading_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With My.Application.Info.Version
            Version.Text = "Versão " & .Major & "." & .Minor & " (Build " & .Build & "." & .Revision & ")"
        End With
        Copyright.Text = My.Application.Info.Copyright
    End Sub

End Class
