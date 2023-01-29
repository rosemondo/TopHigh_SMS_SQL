Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class PaySlip
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetPagefont()
            GetEmp()
            GetCompInfo()
            GetAcaYear()
            OnDistinctNumber()

        End If

    End Sub

    Protected Sub OnDistinctNumber()
        Dim result As List(Of String) = New List(Of String)()
        If Session("Numbers") IsNot Nothing Then
            result = CType(Session("Numbers"), List(Of String))
        End If
        Dim number As String = GetAutoNumber()
        If Not result.Contains(number) Then
            result.Add(number)
            Session("Numbers") = result
            lblpnum.Text = number
        End If
    End Sub

    Private Function GetAutoNumber() As String
        Dim numbers As String = "1234567890"
        Dim characters As String = numbers
        Dim length As Integer = 7
        Dim id As String = String.Empty
        For i As Integer = 0 To length - 1
            Dim character As String = String.Empty
            Do
                Dim index As Integer = New Random().Next(0, characters.Length)
                character = characters.ToCharArray()(index).ToString()
            Loop While id.IndexOf(character) <> -1
            id += character
        Next

        Return id
    End Function

    Protected Sub GetPagefont()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from page_settings_t"}
            'insert product
            'cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "pc"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtfont.Value = dr.Item("font_style")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub


    Protected Sub GetEmp()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetEmpList")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetEmpList")

                    ' BIND DATABASE TO SELECT.
                    dplstaff.DataSource = ds
                    dplstaff.DataTextField = "emp"
                    dplstaff.DataValueField = "emp"
                    dplstaff.DataBind()
                    dplstaff.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetCompInfo()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Comp_info"}
            'insert product
            'cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "sch"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lblcompname.Text = dr.Item("com_name")
                lbladress.Text = dr.Item("address")
                lblcontacts.Text = dr.Item("contact")
                lblonline.Text = dr.Item("online")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetEmpInfo()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from employee_details_v where Employee = @Employee"}
            'insert product
            cmd.Parameters.Add("@Employee", SqlDbType.VarChar).Value = dplstaff.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lblemp.Text = dr.Item("Employee")
                lblempadd.Text = dr.Item("Address")
                lblempcont.Text = dr.Item("Contact")
                lblbnkname.Text = dr.Item("bank_name")
                lblacname.Text = dr.Item("account_name")
                lblacnum.Text = dr.Item("account_num")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetAcaYear()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetAcademicYear")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetAcademicYear")

                    ' BIND DATABASE TO SELECT.
                    dplyear.DataSource = ds
                    dplyear.DataTextField = "aca_year"
                    dplyear.DataValueField = "aca_year"
                    dplyear.DataBind()
                    dplyear.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetPayRollData(ByVal sender As Object, ByVal e As EventArgs)

        GetEmpInfo()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from pay_roll_v where Employee = @Employee and months = @months and pay_year = @pay_year"}
            'insert product
            cmd.Parameters.Add("@Employee", SqlDbType.VarChar).Value = dplstaff.Text
            cmd.Parameters.Add("@months", SqlDbType.VarChar).Value = dplmonths.Text
            cmd.Parameters.Add("@pay_year", SqlDbType.Int).Value = dplyear.Text

            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtbcurrent.Text = dr.Item("basic_salary")
                txtacurrent.Text = dr.Item("allowance")
                txtgross.Text = dr.Item("gross_salary")
                txtpaye.Text = dr.Item("paye")
                txtsnnit.Text = dr.Item("snnit_tier_5")
                txtloan.Text = dr.Item("loan")
                txttotdeduct.Text = dr.Item("tot_deduct")
                txtnet.Text = dr.Item("net_salary")

                txtbcurrent.Text = Format(txtbcurrent.Text, "Standard")
                txtacurrent.Text = Format(txtacurrent.Text, "Standard")
                txtgross.Text = Format(txtgross.Text, "Standard")
                txtpaye.Text = Format(txtpaye.Text, "Standard")
                txtsnnit.Text = Format(txtsnnit.Text, "Standard")
                txtloan.Text = Format(txtloan.Text, "Standard")
                txttotdeduct.Text = Format(txttotdeduct.Text, "Standard")
                txtnet.Text = Format(txtnet.Text, "Standard")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

End Class