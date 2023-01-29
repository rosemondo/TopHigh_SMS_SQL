Public Class DbConnectionClass

    Public Function GetConnectionString() As String
        Dim constring As String = "Data Source=DESKTOP-K36KC6P\SQLEXPRESS;Initial Catalog=tophigh_sms_db;Persist Security Info=True;User ID=sa;Password=ben10@@;"
        Return constring
    End Function

End Class
