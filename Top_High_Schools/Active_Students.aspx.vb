Imports System.Web.Script.Serialization
Imports DevExpress.Web
Imports System.Data.SqlClient

Public Class Active_Students
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("usertest"))

            txtusers.Text = IpassAstringfrompage1

            Dim IpassAstringfrompage2 As String = Convert.ToString(Session("locationtest"))

            txtlocation.Text = IpassAstringfrompage2

            txtdate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd")

            GetPagefont()
            BindRepeater()
            GetClass()

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


    Protected Sub BindRepeater()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("Get_Active_Students", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@class_name", SqlDbType.VarChar).Value = ddlClass.Text
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        RepeaterDB.DataSource = dt
                        RepeaterDB.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub OnSave(ByVal sender As Object, ByVal e As EventArgs)
        For Each item As RepeaterItem In RepeaterDB.Items
            Dim id As Label = TryCast(item.FindControl("studcode"), Label)
            Dim acti As DropDownList = TryCast(item.FindControl("ddlactive"), DropDownList)
            If (TryCast(item.FindControl("checkboxId"), CheckBox)).Checked = True Then
                Dim conString As String = sCon
                Using con As SqlConnection = New SqlConnection(conString)
                    Using cmd As SqlCommand = New SqlCommand("Update_Active_Student", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@active_status", SqlDbType.VarChar).Value = acti.Text
                        cmd.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = id.Text
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using
            End If
        Next

        ddlClass.ClearSelection()
        txtclassid.Text = String.Empty
        BindRepeater()

    End Sub

    Protected Sub GetClass()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetClass")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetClass")

                    ' BIND DATABASE TO SELECT.
                    ddlClass.DataSource = ds
                    ddlClass.DataTextField = "ClassName"
                    ddlClass.DataValueField = "ClassName"
                    ddlClass.DataBind()
                    ddlClass.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetClassID()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetClassID"}
            'insert product
            cmd.Parameters.Add("@ClassName", SqlDbType.VarChar).Value = ddlClass.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtclassid.Text = dr.Item("ID")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub Check_UnCheckAll(ByVal sender As Object, ByVal e As EventArgs)
        For Each item As RepeaterItem In RepeaterDB.Items
            TryCast(item.FindControl("checkboxId"), CheckBox).Checked = chkAll.Checked
        Next
    End Sub

    Protected Sub OnRowCheckedUnchecked(ByVal sender As Object, ByVal e As EventArgs)
        Dim isAllChecked As Boolean = True
        For Each item As RepeaterItem In RepeaterDB.Items
            If Not (TryCast(item.FindControl("checkboxId"), CheckBox)).Checked Then
                isAllChecked = False
                Exit For
            End If
        Next
        chkAll.Checked = isAllChecked
    End Sub

    Protected Sub ddlClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        BindRepeater()
    End Sub

End Class