Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient

Public Class Staff_Form
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            txtfirstname.Focus()

            Dim YearTrial = Year(Now)
            txtdateyear.Value = YearTrial
            txtdays.Value = DateTime.Now.Day
            txtmonths.Value = DateTime.Now.Month

            txtentdate.Value = DateTime.Now.Date.ToString("yyyy-MM-dd")

            GetPagefont()
            GetEmpID()
            GetCountries()
            GetEntLevel()
            GetSsnit5()
            GetSsnit13()
            GetSsnittier1()
            GetTrustee()
            GetPF()
            GetGRAVaues1()

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


    Protected Sub GetEmpID()

        Try

            Dim conString As New SqlConnection
            Dim cmd As New SqlCommand
            conString.ConnectionString = sCon
            cmd.Connection = conString
            conString.Open()

            Dim number As Integer
            cmd.CommandText = "select MAX(id)from emp_info_t"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 1
                txtmyID.Value = number
            Else
                number = cmd.ExecuteScalar + 1
                txtmyID.Value = number
            End If
            cmd.Dispose()
            conString.Close()
            conString.Dispose()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

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
                    dplcountries.DataSource = ds
                    dplcountries.DataTextField = "country"
                    dplcountries.DataValueField = "country"
                    dplcountries.DataBind()
                    dplcountries.Items.Insert(0, "")

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

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

    <WebMethod>
    Public Shared Function SaveEmpDetails(ByVal myid As String, ByVal mydays As String, ByVal mymonth As String, ByVal myyear As String, ByVal firstname As String, ByVal midname As String, ByVal lastname As String, ByVal dob As String, ByVal Gender As String, ByVal idtype As String, ByVal idnum As String, ByVal qualification As String, ByVal Ssnit As String, ByVal entdate As Date) As Boolean

        Dim status As Boolean

        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
            Using cmd As New SqlCommand("insert into emp_info_t (emp_id,fname,mname,lname,dob,gender,id_type,id_no,qualification,ssnit_number) values(@emp_id,@fname,@mname,@lname,@dob,@gender,@id_type,@id_no,@qualification,@ssnit_number)", con)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@emp_id", "EMP" + myid + mydays + mymonth + myyear)
                cmd.Parameters.AddWithValue("@fname", firstname)
                cmd.Parameters.AddWithValue("@mname", midname)
                cmd.Parameters.AddWithValue("@lname", lastname)
                cmd.Parameters.AddWithValue("@dob", dob)
                cmd.Parameters.AddWithValue("@gender", Gender)
                cmd.Parameters.AddWithValue("@id_type", idtype)
                cmd.Parameters.AddWithValue("@id_no", idnum)
                cmd.Parameters.AddWithValue("@qualification", qualification)
                cmd.Parameters.AddWithValue("@ssnit_number", Ssnit)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                Dim retVal As Int32 = cmd.ExecuteNonQuery()
                If retVal > 0 Then
                    status = True
                Else
                    status = False
                End If
                Return status
                con.Close()
            End Using
        End Using

    End Function



    <WebMethod>
    Public Shared Function SaveAddressDetails(ByVal myid As String, ByVal mydays As String, ByVal mymonth As String, ByVal myyear As String, ByVal houseaddress As String, ByVal city As String, ByVal countries As String, ByVal mobile As String, ByVal email As String, ByVal nextofkin As String, ByVal entdate As Date) As Boolean

        Dim status As Boolean

        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
            Using cmd As New SqlCommand("insert into emp_address_t (emp_id,add_1,city,country,mobile,email,next_of_kin) values(@emp_id,@add_1,@city,@country,@mobile,@email,@next_of_kin)", con)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@emp_id", "EMP" + myid + mydays + mymonth + myyear)
                cmd.Parameters.AddWithValue("@add_1", houseaddress)
                cmd.Parameters.AddWithValue("@city", city)
                cmd.Parameters.AddWithValue("@country", countries)
                cmd.Parameters.AddWithValue("@mobile", mobile)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@next_of_kin", nextofkin)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                Dim retVal As Int32 = cmd.ExecuteNonQuery()
                If retVal > 0 Then
                    status = True
                Else
                    status = False
                End If
                Return status
                con.Close()
            End Using
        End Using

    End Function


    <WebMethod>
    Public Shared Function SaveSalaryDetails(ByVal myid As String, ByVal mydays As String, ByVal mymonth As String, ByVal myyear As String, ByVal salary As Double, ByVal allowance As Double, ByVal netsalary As Double, ByVal entid As Integer, ByVal bank As String, ByVal acname As String, ByVal acnum As String, ByVal entdate As Date) As Boolean

        Dim status As Boolean

        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
            Using cmd As New SqlCommand("insert into emp_sal_t(emp_id,bisac_sal,allowances,net_sal,ent_level,bank_name,account_name,account_num) values(@emp_id,@bisac_sal,@allowances,@net_sal,@ent_level,@bank_name,@account_name,@account_num)", con)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@emp_id", "EMP" + myid + mydays + mymonth + myyear)
                cmd.Parameters.AddWithValue("@bisac_sal", salary)
                cmd.Parameters.AddWithValue("@allowances", allowance)
                cmd.Parameters.AddWithValue("@net_sal", netsalary)
                cmd.Parameters.AddWithValue("@ent_level", entid)
                cmd.Parameters.AddWithValue("@bank_name", bank)
                cmd.Parameters.AddWithValue("@account_name", acname)
                cmd.Parameters.AddWithValue("@account_num", acnum)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                Dim retVal As Int32 = cmd.ExecuteNonQuery()
                If retVal > 0 Then
                    status = True
                Else
                    status = False
                End If
                Return status
                con.Close()
            End Using
        End Using

    End Function


    <WebMethod()>
    Public Shared Function SaveCapturedImage(ByVal data As String, ByVal myid As String, ByVal mydays As String, ByVal mymonth As String, ByVal myyear As String) As Boolean
        Dim fileName As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim imageBytes As Byte() = Convert.FromBase64String(data.Split(","c)(1))
        Dim filePath As String = HttpContext.Current.Server.MapPath(String.Format("~/Captures/{0}.jpg", fileName))
        File.WriteAllBytes(filePath, imageBytes)

        Dim constr As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString

        Dim mystudid As String = "EMP" + myid + mydays + mymonth + myyear

        Using con As New SqlConnection(constr)
            Dim query As String = "INSERT INTO emp_photo_t(emp_id,photo) VALUES (@emp_id,@photo)"
            Using cmd As New SqlCommand(query)
                cmd.Connection = con
                cmd.Parameters.Add("@emp_id", SqlDbType.VarChar).Value = mystudid
                cmd.Parameters.Add("@photo", SqlDbType.VarBinary).Value = imageBytes
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        Return True
    End Function


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

    Protected Sub btncancel_Click(sender As Object, e As EventArgs)

        GetEmpID()
        Dim YearTrial = Year(Now)
        txtdateyear.Value = YearTrial
        txtdays.Value = DateTime.Now.Day
        txtmonths.Value = DateTime.Now.Month

    End Sub

End Class