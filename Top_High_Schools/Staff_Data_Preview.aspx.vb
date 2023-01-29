Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Staff_Data_Preview
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Public Function convertQuotes(ByVal str As String) As String
        convertQuotes = str.Replace("'", "''")
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then


            txtemp.Value = Request.QueryString("myEmp")
            txtids.Value = Request.QueryString("myid")
            txtdays.Value = Request.QueryString("mydays")
            txtmonths.Value = Request.QueryString("mymonth")
            txtyears.Value = Request.QueryString("myyear")


            txtid.Value = txtemp.Value + txtids.Value + txtdays.Value + txtmonths.Value + txtyears.Value

            GetCompInfo()
            ShowEmpInfoData()

        End If


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



    Protected Sub ShowEmpInfoData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM emp_info_t WHERE  emp_id='{0}'", txtid.Value), cnn)
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtmyid.Value = dr.Item("id")
                txtfirstname.Text = dr.Item("fname")
                txtmidname.Text = dr.Item("mname")
                txtlastname.Text = dr.Item("lname")
                txtdob.Text = dr.Item("dob")
                ddlGender.Text = dr.Item("gender")
                ddlidtype.Text = dr.Item("id_type")
                txtidnum.Text = dr.Item("id_no")
                txtqualification.Text = dr.Item("qualification")
                txtSsnit.Text = dr.Item("ssnit_number")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        ShowEmpAddressData()

    End Sub

    Protected Sub ShowEmpAddressData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM emp_address_t WHERE  emp_id='{0}'", txtid.Value), cnn)
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txthouseaddress.Text = dr.Item("add_1")
                txtcity.Text = dr.Item("city")
                ddlcountries.Text = dr.Item("country")
                txtmobile.Text = dr.Item("mobile")
                txtemail.Text = dr.Item("email")
                txtnextofkin.Text = dr.Item("next_of_kin")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        ShowEmpSalData()

    End Sub

    Protected Sub ShowEmpSalData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM emp_sal_v WHERE  emp_id='{0}'", txtid.Value), cnn)
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtsalary.Text = dr.Item("bisac_sal")
                txtallowance.Text = dr.Item("allowances")
                txtnet.Text = dr.Item("net_sal")
                ddlentlevel.Text = dr.Item("entry_name")
                'hfentid.Value = dr.Item("ent_level")
                txtbank.Text = dr.Item("bank_name")
                txtacname.Text = dr.Item("account_name")
                txtacnum.Text = dr.Item("account_num")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        ShowEmpDataID()

    End Sub

    Protected Sub ShowEmpDataID()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM emp_photo_t WHERE  emp_id='{0}'", txtid.Value), cnn)
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtmyid.Value = dr.Item("id")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        ShowStudentPhoto()

    End Sub

    Protected Sub ShowStudentPhoto()

        Try


            Dim id As String = txtmyid.Value
            imgstudpic.Visible = id <> "0"
            If id <> "0" Then
                Dim bytes As Byte() = DirectCast(GetData(Convert.ToString("SELECT photo FROM emp_photo_t WHERE id =") & id).Rows(0)("photo"), Byte())
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                imgstudpic.ImageUrl = Convert.ToString("data:image/png;base64,") & base64String
            End If


        Catch ex As Exception


        End Try


    End Sub

    Private Function GetData(query As String) As DataTable
        Dim dt As New DataTable()
        Dim constr As String = sCon
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query)
                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    sda.Fill(dt)
                End Using
            End Using
            Return dt
        End Using
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("Staff_List.aspx")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Session("EmpID") = txtid.Value
        Response.Redirect("Edit_Employees.aspx")
    End Sub

End Class