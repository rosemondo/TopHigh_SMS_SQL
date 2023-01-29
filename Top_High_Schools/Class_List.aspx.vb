Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Class_List
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then

            Dim YearTrial = Year(Now)
            txtdateyear.Value = YearTrial
            txtdays.Value = DateTime.Now.Day
            txtmonths.Value = DateTime.Now.Month
            txtseconds.Value = DateTime.Now.Second

            GetPagefont()
            GetClasses()
            GetClassTeacher()

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


    Protected Sub GetClassTeacher()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetClassType")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetClassType")

                    ' BIND DATABASE TO SELECT.
                    ddlTarcher.DataSource = ds
                    ddlTarcher.DataTextField = "class_type"
                    ddlTarcher.DataValueField = "class_type"
                    ddlTarcher.DataBind()
                    ddlTarcher.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetClasses()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("GetClass", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.StoredProcedure
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptClasses.DataSource = dt
                        rptClasses.DataBind()
                    End Using
                End Using
            End Using

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetValue(ByVal sender As Object, ByVal e As EventArgs)

        Try

            'Reference the Repeater Item using Button.
            Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)

            'Reference the Label and TextBox.
            Dim message As String = (TryCast(item.FindControl("lblID"), Label)).Text

            txtID.Text = message

            Session("ClassID") = txtID.Text
            Response.Redirect("Edit_Class.aspx")

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub GetDelete(ByVal sender As Object, ByVal e As EventArgs)

        Try

            'Reference the Repeater Item using Button.
            Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)

            'Reference the Label and TextBox.
            Dim message As String = (TryCast(item.FindControl("lblID"), Label)).Text

            txtID.Text = message

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "DeleteClassData"}
            cmd.Parameters.Add("@class_id", SqlDbType.VarChar).Value = txtID.Text

            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub ddlTarcher_SelectedIndexChanged(sender As Object, e As EventArgs)
        GetClassID()
    End Sub

    Protected Sub GetClassID()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetClassTypeID"}
            'insert product
            cmd.Parameters.Add("@class_type", SqlDbType.VarChar).Value = ddlTarcher.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtteacherID.Text = dr.Item("id")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertClasses"}
            cmd.Parameters.Add("@class_id", SqlDbType.VarChar).Value = "TC" + txtdays.Value + txtmonths.Value + txtdateyear.Value + txtseconds.Value
            cmd.Parameters.Add("@class_name", SqlDbType.VarChar).Value = txtClass.Text
            cmd.Parameters.Add("@section_name", SqlDbType.VarChar).Value = ddlSection.Text
            cmd.Parameters.Add("@class_type", SqlDbType.VarChar).Value = txtteacherID.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        txtClass.Text = String.Empty
        txtteacherID.Text = String.Empty
        ddlSection.Text = String.Empty
        ddlTarcher.ClearSelection()

        Dim YearTrial = Year(Now)
        txtdateyear.Value = YearTrial
        txtdays.Value = DateTime.Now.Day
        txtmonths.Value = DateTime.Now.Month
        txtseconds.Value = DateTime.Now.Second

        GetClasses()

        'Response.Redirect("Class_List.aspx")

    End Sub

    Protected Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

        txtClass.Text = String.Empty
        txtteacherID.Text = String.Empty

    End Sub
End Class