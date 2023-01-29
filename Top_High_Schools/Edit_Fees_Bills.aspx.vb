Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Edit_Fees_Bills
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("BillID"))

            txtID.Text = IpassAstringfrompage1

            GetPagefont()
            GetFeeBills()
            GetClass()

            ShowFeeBillData()

        End If

    End Sub

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



    Protected Sub GetClass()

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
                    ddlClass.DataSource = ds
                    ddlClass.DataTextField = "class_type"
                    ddlClass.DataValueField = "class_type"
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

    Protected Sub GetFeeBills()

        Try

            Dim constr As String = sCon

            Using con As SqlConnection = New SqlConnection(constr)

                Using cmd As SqlCommand = New SqlCommand("SELECT * FROM fees_bills_v", con)

                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        cmd.CommandType = CommandType.Text
                        Dim dt As DataTable = New DataTable()
                        sda.Fill(dt)
                        rptFeeBill.DataSource = dt
                        rptFeeBill.DataBind()
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

        'Reference the Repeater Item using Button.
        Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)

        'Reference the Label and TextBox.
        Dim message As String = (TryCast(item.FindControl("lblID"), Label)).Text

        txtID.Text = message

        'Session("StudID") = txtID.Text
        'Response.Redirect("EditStudent.aspx")

    End Sub

    Protected Sub GetDelete(ByVal sender As Object, ByVal e As EventArgs)

        'Reference the Repeater Item using Button.
        Dim item As RepeaterItem = TryCast((TryCast(sender, ImageButton)).NamingContainer, RepeaterItem)

        'Reference the Label and TextBox.
        Dim message As String = (TryCast(item.FindControl("lblID"), Label)).Text

        txtID.Text = message

        Dim connetionString As String = sCon
        Dim cnn As SqlConnection = New SqlConnection(connetionString)
        Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "DeleteFeeBillData"}
        cmd.Parameters.Add("@bill_id", SqlDbType.BigInt).Value = txtID.Text

        cmd.Connection = cnn

        cnn.Open()
        cmd.ExecuteNonQuery()

        cnn.Close()

    End Sub

    Protected Sub GetClassID()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetClassTypeID"}
            'insert product
            cmd.Parameters.Add("@class_type", SqlDbType.VarChar).Value = ddlClass.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtclasid.Text = dr.Item("id")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub


    Protected Sub ShowFeeBillData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM fees_bill_t WHERE  bill_id='{0}'", txtID.Text), cnn)
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txttuition.Text = dr.Item("tuition_fee")
                txtadmission.Text = dr.Item("admission_fee")
                txtcanteen.Text = dr.Item("canteen_fee")
                txtbusfee.Text = dr.Item("bus_fee")
                txtfirstaid.Text = dr.Item("first_aid")
                txtpta.Text = dr.Item("pta")
                txtothers.Text = dr.Item("others")
                txtclassid.Text = dr.Item("class_type_id")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub ShowClassName()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM class_v_1 WHERE  ID='{0}'", txtclasid.Text), cnn)
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                ddlClass.DataTextField = dr.Item("ClassName")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub ddlClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlClass.SelectedIndexChanged

        GetClassID()

    End Sub

    Protected Sub ddlClass_TextChanged(sender As Object, e As EventArgs) Handles ddlClass.TextChanged

        GetClassID()

    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateFeeBills"}
            cmd.Parameters.Add("@tuition_fee", SqlDbType.Float).Value = txttuition.Text
            cmd.Parameters.Add("@admission_fee", SqlDbType.Float).Value = txtadmission.Text
            cmd.Parameters.Add("@canteen_fee", SqlDbType.Float).Value = txtcanteen.Text
            cmd.Parameters.Add("@bus_fee", SqlDbType.Float).Value = txtbusfee.Text
            cmd.Parameters.Add("@first_aid", SqlDbType.Float).Value = txtfirstaid.Text
            cmd.Parameters.Add("@pta", SqlDbType.Float).Value = txtpta.Text
            cmd.Parameters.Add("@others", SqlDbType.Float).Value = txtothers.Text
            cmd.Parameters.Add("@class_type_id", SqlDbType.VarChar).Value = txtclassid.Text
            cmd.Parameters.Add("@bill_id", SqlDbType.Int).Value = txtID.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        txttuition.Text = String.Empty
        txtadmission.Text = String.Empty
        txtcanteen.Text = String.Empty
        txtbusfee.Text = String.Empty
        txtfirstaid.Text = String.Empty
        txtpta.Text = String.Empty
        txtothers.Text = String.Empty
        txtclassid.Text = String.Empty

        Response.Redirect("Fees_Bills_List.aspx")

    End Sub

    Protected Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

        txttuition.Text = String.Empty
        txtadmission.Text = String.Empty
        txtcanteen.Text = String.Empty
        txtbusfee.Text = String.Empty
        txtfirstaid.Text = String.Empty
        txtpta.Text = String.Empty
        txtothers.Text = String.Empty
        txtclassid.Text = String.Empty

        GetFeeBills()

    End Sub

    Protected Sub txtclasid_TextChanged(sender As Object, e As EventArgs) Handles txtclasid.TextChanged

        ShowClassName()

    End Sub
End Class