Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Bank_Statement
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetPagefont()
            GetBankStatement()
            GetAccounts()

            ASPxDatefrom.Text = DateTime.Now.Date.ToString("yyyy-MM-dd")
            ASPxDateto.Text = DateTime.Now.Date.ToString("yyyy-MM-dd")

        End If

    End Sub

    Protected Sub GetPagefont()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_page_settings"}
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


    Protected Sub GetAccounts()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetAcName")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetAcName")

                    ' BIND DATABASE TO SELECT.
                    dplacname.DataSource = ds
                    dplacname.DataTextField = "accname"
                    dplacname.DataValueField = "accname"
                    dplacname.DataBind()
                    dplacname.Items.Insert(0, New ListItem("", "0"))

                    ' SET THE DEFAULT VALUE.
                    dplacname.Items.Insert(0, "- SELECT -")

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetBankStatement()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_My_Bank_Statement", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptstudent.DataSource = dt
                        rptstudent.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub


    Protected Sub GetBankStatementByAcc()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_My_Bank_Statement_Acc", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = dplacname.Text
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptstudent.DataSource = dt
                        rptstudent.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetBankStatementByAccDate()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_My_Bank_Statement_date", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = dplacname.Text
                        cmd.Parameters.Add("@datefrom", SqlDbType.Date).Value = txtLastDatefrom.Text
                        cmd.Parameters.Add("@dateto", SqlDbType.Date).Value = txtLastDateto.Text
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptstudent.DataSource = dt
                        rptstudent.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click


        If dplacname.Text = "- SELECT -" = True Then
            Response.Write("<script type=""text/javascript"">alert(""Please select Account name."");</script")
            Exit Sub
        End If

        If ASPxDatefrom.Text = "" = True Then
            Response.Write("<script type=""text/javascript"">alert(""Please select Date."");</script")
            Exit Sub
        End If

        If ASPxDateto.Text = "" = True Then
            Response.Write("<script type=""text/javascript"">alert(""Please select Date."");</script")
            Exit Sub
        End If


        Dim todays As Date = ASPxDatefrom.Text
        Dim mydateday As Date = ASPxDateto.Text

        Dim mydaysdate = todays
        Dim Myanswers = mydateday

        txtLastDatefrom.Text = mydaysdate.ToString("yyyy-MM-dd")
        txtLastDateto.Text = Myanswers.ToString("yyyy-MM-dd")

        If chkbydate.Checked = True Then

            GetBankStatementByAccDate()

        Else

            GetBankStatementByAcc()

        End If

    End Sub
End Class