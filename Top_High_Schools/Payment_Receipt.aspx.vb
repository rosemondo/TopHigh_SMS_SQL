Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Payment_Receipt
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetCompInfo()

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("Ptuitest"))

            lbltuition.Text = IpassAstringfrompage1
            lbltuition.Text = Format(lbltuition.Text, "Standard")

            Dim IpassAstringfrompage3 As String = Convert.ToString(Session("Ptottest"))

            lblfeebill.Text = IpassAstringfrompage3
            lblfeebill.Text = Format(lblfeebill.Text, "Standard")

            Dim IpassAstringfrompage4 As String = Convert.ToString(Session("Ppmttest"))

            lblpayments.Text = IpassAstringfrompage4
            lblpayments.Text = Format(lblpayments.Text, "Standard")

            Dim IpassAstringfrompage5 As String = Convert.ToString(Session("Pbaltest"))

            lblbaldue.Text = IpassAstringfrompage5
            lblbaldue.Text = Format(lblbaldue.Text, "Standard")

            Dim IpassAstringfrompage6 As String = Convert.ToString(Session("Pstudtest"))

            lblstudents.Text = IpassAstringfrompage6

            Dim IpassAstringfrompage7 As String = Convert.ToString(Session("Pclasstest"))

            lblclass.Text = IpassAstringfrompage7

            Dim IpassAstringfrompage8 As String = Convert.ToString(Session("Pusertest"))

            lbluser.Text = IpassAstringfrompage8

            Dim IpassAstringfrompage9 As String = Convert.ToString(Session("Pnumtest"))

            lblnumber.Text = IpassAstringfrompage9

            Dim IpassAstringfrompage10 As String = Convert.ToString(Session("Pdatetest"))

            lbldate.Text = IpassAstringfrompage10

        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Response.Redirect("Receive_Payment.aspx")

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

End Class