Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient

Public Class Edit_Employees
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("EmpID"))

            txtid.Text = IpassAstringfrompage1

            GetPagefont()
            GetCountries()
            GetEntLevel()
            GetSsnit5()
            GetSsnit13()
            GetSsnittier1()
            GetTrustee()
            GetPF()
            GetGRAVaues1()

            ShowEmpInfoData()
            ShowEmpForoIDData()

            txtfirstname.Focus()

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

    Private Sub GetGRAVaues1()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from income_tax_list_t where entry_name = @entry_name"}
            'insert product
            cmd.Parameters.Add("@entry_name", SqlDbType.VarChar).Value = "First Entry"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txt365.Value = dr.Item("lower_lim_val")
                txt0.Value = dr.Item("inc_tax_rate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try
        GetGRAVaues2()
    End Sub

    Private Sub GetGRAVaues2()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from income_tax_list_t where entry_name = @entry_name"}
            'insert product
            cmd.Parameters.Add("@entry_name", SqlDbType.VarChar).Value = "SECOND LEVEL"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txt110.Value = dr.Item("lower_lim_val")
                txt5.Value = dr.Item("inc_tax_rate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try
        GetGRAVaues3()
    End Sub


    Private Sub GetGRAVaues3()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from income_tax_list_t where entry_name = @entry_name"}
            'insert product
            cmd.Parameters.Add("@entry_name", SqlDbType.VarChar).Value = "THIRD LEVEL"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txt130.Value = dr.Item("lower_lim_val")
                txt10.Value = dr.Item("inc_tax_rate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try
        GetGRAVaues4()
    End Sub

    Private Sub GetGRAVaues4()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from income_tax_list_t where entry_name = @entry_name"}
            'insert product
            cmd.Parameters.Add("@entry_name", SqlDbType.VarChar).Value = "FOURTH LEVEL"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txt3000.Value = dr.Item("lower_lim_val")
                txt17.Value = dr.Item("inc_tax_rate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try
        GetGRAVaues5()
    End Sub

    Private Sub GetGRAVaues5()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from income_tax_list_t where entry_name = @entry_name"}
            'insert product
            cmd.Parameters.Add("@entry_name", SqlDbType.VarChar).Value = "FIFTH  LEVEL"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txt16395.Value = dr.Item("lower_lim_val")
                txt25.Value = dr.Item("inc_tax_rate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try
        GetGRAVaues6()
    End Sub

    Private Sub GetGRAVaues6()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from income_tax_list_t where entry_name = @entry_name"}
            'insert product
            cmd.Parameters.Add("@entry_name", SqlDbType.VarChar).Value = "LAST STEP"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txt20000.Value = dr.Item("lower_lim_val")
                txt30.Value = dr.Item("inc_tax_rate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GetSsnit5()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from ssnit_deduction_t where dedu_items = @dedu_items"}
            'insert product
            cmd.Parameters.Add("@dedu_items", SqlDbType.VarChar).Value = "SSNIT EMPLOYEE'S CONTRIBUTION"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtSnRate5.Value = dr.Item("ssnit_rate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GetSsnit13()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from ssnit_deduction_t where dedu_items = @dedu_items"}
            'insert product
            cmd.Parameters.Add("@dedu_items", SqlDbType.VarChar).Value = "SSNIT EMPLOYER'S CONTRIBUTION"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txsntempyer.Value = dr.Item("ssnit_rate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GetSsnittier1()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from ssnit_deduction_t where dedu_items = @dedu_items"}
            'insert product
            cmd.Parameters.Add("@dedu_items", SqlDbType.VarChar).Value = "SSNIT (1st Tier)"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtsnttier1.Value = dr.Item("ssnit_rate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GetTrustee()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from ssnit_deduction_t where dedu_items = @dedu_items"}
            'insert product
            cmd.Parameters.Add("@dedu_items", SqlDbType.VarChar).Value = "Trustee (2nd Tier)"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txttteetier2.Value = dr.Item("ssnit_rate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GetPF()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from ssnit_deduction_t where dedu_items = @dedu_items"}
            'insert product
            cmd.Parameters.Add("@dedu_items", SqlDbType.VarChar).Value = "PF EMPLOYEE'S CONTRIBUTION"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtpftier3.Value = dr.Item("ssnit_rate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GetEntLevel()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("select * from income_tax_list_t")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "income_tax_list_t")

                    ' BIND DATABASE TO SELECT.
                    ddlentlevel.DataSource = ds
                    ddlentlevel.DataTextField = "entry_name"
                    ddlentlevel.DataValueField = "entry_name"
                    ddlentlevel.DataBind()
                    ddlentlevel.Items.Insert(0, "")

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetCountries()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetCountries")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetCountries")

                    ' BIND DATABASE TO SELECT.
                    ddlcountries.DataSource = ds
                    ddlcountries.DataTextField = "country"
                    ddlcountries.DataValueField = "country"
                    ddlcountries.DataBind()
                    ddlcountries.Items.Insert(0, New ListItem("", "0"))


                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub ShowEmpForoIDData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM emp_photo_t WHERE  emp_id='{0}'", txtid.Text), cnn)
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtfotoid.Value = dr.Item("id")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        ShowStudentPhoto()

    End Sub

    Protected Sub ShowEmpInfoData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM emp_info_t WHERE  emp_id='{0}'", txtid.Text), cnn)
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                lblid.Text = dr.Item("id")
                txtfirstname.Text = dr.Item("fname")
                txtmidname.Text = dr.Item("mname")
                txtlastname.Text = dr.Item("lname")
                txtdob.Text = DateTime.Parse(dr.Item("dob")).ToString("yyyy-MM-dd")
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
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM emp_address_t WHERE  emp_id='{0}'", txtid.Text), cnn)
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
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM emp_sal_v WHERE  emp_id='{0}'", txtid.Text), cnn)
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtsalary.Text = dr.Item("bisac_sal")
                txtallowance.Text = dr.Item("allowances")
                ddlentlevel.Text = dr.Item("entry_name")
                txtnet.Text = dr.Item("net_sal")
                hfentid.Value = dr.Item("ent_level")
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

    End Sub


    Protected Function GetData(query As String) As DataTable
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

    Protected Sub UpdateEmpInfo()

        Try

            Dim myid As String = txtmyID.Text

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Update_Emp_Info"}
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = txtfirstname.Text
            cmd.Parameters.Add("@mname", SqlDbType.VarChar).Value = txtmidname.Text
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = txtlastname.Text
            cmd.Parameters.Add("@dob", SqlDbType.Date).Value = txtdob.Text
            cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = ddlGender.Text
            cmd.Parameters.Add("@id_type", SqlDbType.VarChar).Value = ddlidtype.Text
            cmd.Parameters.Add("@id_no", SqlDbType.VarChar).Value = txtidnum.Text
            cmd.Parameters.Add("@qualification", SqlDbType.VarChar).Value = txtqualification.Text
            cmd.Parameters.Add("@ssnit_number", SqlDbType.VarChar).Value = txtSsnit.Text
            cmd.Parameters.Add("@emp_id", SqlDbType.VarChar).Value = txtid.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Update_Emp_Add_Info()

    End Sub

    Protected Sub Update_Emp_Add_Info()

        Try


            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Update_Emp_Address"}
            cmd.Parameters.Add("@add_1", SqlDbType.VarChar).Value = txthouseaddress.Text
            cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = txtcity.Text
            cmd.Parameters.Add("@country", SqlDbType.VarChar).Value = ddlcountries.Text
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = txtmobile.Text
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtemail.Text
            cmd.Parameters.Add("@next_of_kin", SqlDbType.VarChar).Value = txtnextofkin.Text
            cmd.Parameters.Add("@emp_id", SqlDbType.VarChar).Value = txtid.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Update_Emp_Sal()

    End Sub

    Protected Sub Update_Emp_Sal()

        Try

            Dim bsal As Double = txtsalary.Text
            Dim allowa As Double = txtallowance.Text
            Dim snnit As Double = txtdeuct.Value
            Dim my5 As Double = lbl5p.Value
            Dim my10 As Double = lbl10p.Value
            Dim my17 As Double = lbl17p.Value
            Dim my25 As Double = lbl25p.Value
            Dim my30 As Double = lbl30p.Value

            Dim Nnet As Double = bsal + allowa - snnit - my5 - my10 - my17 - my25 - my30

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Update_Emp_Sal"}
            cmd.Parameters.Add("@bisac_sal", SqlDbType.Float).Value = txtsalary.Text
            cmd.Parameters.Add("@allowances", SqlDbType.Float).Value = txtallowance.Text
            cmd.Parameters.Add("@net_sal", SqlDbType.Float).Value = Nnet
            cmd.Parameters.Add("@ent_level", SqlDbType.Int).Value = hfentid.Value
            cmd.Parameters.Add("@bank_name", SqlDbType.VarChar).Value = txtbank.Text
            cmd.Parameters.Add("@account_name", SqlDbType.VarChar).Value = txtacname.Text
            cmd.Parameters.Add("@account_num", SqlDbType.VarChar).Value = txtacnum.Text
            cmd.Parameters.Add("@emp_id", SqlDbType.VarChar).Value = txtid.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try


        Response.Redirect("Staff_List.aspx")

    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        UpdateEmpInfo()

    End Sub

    Protected Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

        txtmyID.Text = String.Empty
        txtfirstname.Text = String.Empty
        txtmidname.Text = String.Empty
        txtlastname.Text = String.Empty
        ddlidtype.Text = "- Select -"
        txtidnum.Text = String.Empty
        txthouseaddress.Text = String.Empty
        txtcity.Text = String.Empty
        ddlcountries.Text = "- Select - "
        txtmobile.Text = String.Empty
        txtemail.Text = String.Empty
        txtnextofkin.Text = String.Empty
        txtsalary.Text = "0.00"
        txtallowance.Text = "0.00"

        Dim YearTrial = Year(Now)
        txtdateyear.Text = YearTrial
        txtdays.Text = DateTime.Now.Day
        txtmonths.Text = DateTime.Now.Month

    End Sub

    Private Sub ddlentlevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlentlevel.SelectedIndexChanged
        GetEntID()
    End Sub

    Private Sub ddlentlevel_TextChanged(sender As Object, e As EventArgs) Handles ddlentlevel.TextChanged
        GetEntID()
    End Sub

    Protected Sub GetEntID()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM income_tax_list_t WHERE  entry_name='{0}'", ddlentlevel.Text), cnn)
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                hfentid.Value = dr.Item("id")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub ShowStudentPhoto()

        Try


            Dim id As String = txtfotoid.Value
            imgstudpic.Visible = id <> "0"
            If id <> "0" Then
                Dim bytes As Byte() = DirectCast(GetData(Convert.ToString("SELECT photo FROM emp_photo_t WHERE id =") & id).Rows(0)("photo"), Byte())
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                imgstudpic.ImageUrl = Convert.ToString("data:image/png;base64,") & base64String
            End If


        Catch ex As Exception


        End Try

    End Sub


    <WebMethod>
    Public Shared Function GetEntID(ByVal studname As String) As Object

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "SELECT * FROM income_tax_list_t WHERE entry_name = @entry_name"}
            'insert product
            cmd.Parameters.Add("@entry_name", SqlDbType.VarChar).Value = studname
            cmd.Connection = cnn
            cnn.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If sdr.Read() Then
                Return New With {
                    .EntryID = sdr("id"),
                    .MyRate = sdr("inc_tax_rate")
                }
            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)

        End Try

        Return Nothing

    End Function


End Class