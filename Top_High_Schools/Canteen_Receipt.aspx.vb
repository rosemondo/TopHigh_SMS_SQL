Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Canteen_Receipt
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetCompInfo()

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("Pstartdate"))
            lblstart.Text = IpassAstringfrompage1
            lblrecdate.Text = IpassAstringfrompage1

            Dim IpassAstringfrompage2 As String = Convert.ToString(Session("Penddate"))
            lblend.Text = IpassAstringfrompage2

            Dim IpassAstringfrompage3 As String = Convert.ToString(Session("Pamount"))
            lblamount.Text = IpassAstringfrompage3
            lblamount.Text = Format(lblamount.Text, "Standard")

            Dim IpassAstringfrompage10 As String = Convert.ToString(Session("Pchange"))
            lblchange.Text = IpassAstringfrompage10
            lblchange.Text = Format(lblchange.Text, "Standard")

            Dim IpassAstringfrompage11 As String = Convert.ToString(Session("Pdays"))
            lbldays.Text = IpassAstringfrompage11

            Dim IpassAstringfrompage4 As String = Convert.ToString(Session("Pcantfees"))
            lblcanteen.Text = IpassAstringfrompage4
            lblcanteen.Text = Format(lblcanteen.Text, "Standard")

            Dim IpassAstringfrompage5 As String = Convert.ToString(Session("Pstatus"))
            lblstatus.Text = IpassAstringfrompage5

            Dim IpassAstringfrompage6 As String = Convert.ToString(Session("Pstudtest"))
            lblstudents.Text = IpassAstringfrompage6

            Dim IpassAstringfrompage7 As String = Convert.ToString(Session("Pclasstest"))
            lblclass.Text = IpassAstringfrompage7

            Dim IpassAstringfrompage8 As String = Convert.ToString(Session("Pusertest"))
            lbluser.Text = IpassAstringfrompage8

            Dim IpassAstringfrompage9 As String = Convert.ToString(Session("Pnumtest"))
            lblnumber.Text = IpassAstringfrompage9


        End If

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Response.Redirect("Canteen_List.aspx")

    End Sub
End Class