Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Admission_Receipt
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetCompInfo()

            lbltuition.Text = Request.QueryString("tuit")
            lbltuition.Text = Format(lbltuition.Text, "Standard")


            lbladmission.Text = Request.QueryString("admi")
            lbladmission.Text = Format(lbladmission.Text, "Standard")

            lbltotbill.Text = Request.QueryString("tot")
            lbltotbill.Text = Format(lbltotbill.Text, "Standard")

            lblfeepay.Text = Request.QueryString("schfe")
            lblfeepay.Text = Format(lblfeepay.Text, "Standard")

            lbladmpay.Text = Request.QueryString("admife")
            lbladmpay.Text = Format(lbladmpay.Text, "Standard")


            lblbaldue.Text = Request.QueryString("baldu")
            lblbaldue.Text = Format(lblbaldue.Text, "Standard")

            lblstudents.Text = Request.QueryString("stu")

            lblclass.Text = Request.QueryString("cls")

            Dim IpassAstringfrompage8 As String = Convert.ToString(Session("usertest"))

            lbluser.Text = IpassAstringfrompage8

            lblnumber.Text = Request.QueryString("num")

            lbldate.Text = Request.QueryString("dtes")

        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Response.Redirect("Admission.aspx")

    End Sub

    Protected Sub GetCompInfo()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_Com@info"}
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

End Class