Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient

Public Class Pay_roll
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Public Class EmpsalList
        Public Property Employee As String
        Public Property bisac_sal As Double
        Public Property allowances As Double
        Public Property paye As Double

    End Class

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetPagefont()
            GetSsnit5()
            GetSsnit13()
            GetSsnittier1()
            GetTrustee()
            GetPF()
            GetAcaYear()
            GetGRAVaues1()

            rptPayRoll.DataSource = Me.GetEmpsal
            rptPayRoll.DataBind()

            Sumpayments()

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


    Protected Sub GetAcaYear()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetAcademicYear")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetAcademicYear")

                    ' BIND DATABASE TO SELECT.
                    ddlacayear.DataSource = ds
                    ddlacayear.DataTextField = "aca_year"
                    ddlacayear.DataValueField = "aca_year"
                    ddlacayear.DataBind()
                    ddlacayear.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

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

    Private Function GetEmpsal() As List(Of EmpsalList)

        Dim constring As String = sCon
        Using con As New SqlConnection(constring)
            Using cmd As New SqlCommand("select * from emp_sal_v", con)
                Dim empsallist As New List(Of EmpsalList)
                cmd.CommandType = CommandType.Text
                con.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    While sdr.Read()
                        empsallist.Add(New EmpsalList With {
                                      .Employee = sdr("Employee").ToString(),
                                      .bisac_sal = Convert.ToDouble(sdr("bisac_sal")),
                                      .allowances = Convert.ToDouble(sdr("allowances")),
                                      .paye = Convert.ToDouble(sdr("paye"))
                                    })
                    End While
                End Using
                con.Close()
                Return empsallist
            End Using
        End Using
    End Function

    '<WebMethod>
    'Public Shared Function SavePayRoll(ByVal staff As String, ByVal basicsal As Double, ByVal allowance As Double, ByVal gross As Double, ByVal Srate As Double, ByVal Semp As Double, ByVal Stier1 As Double, ByVal Stier2 As Double, ByVal PFtier3 As Double, ByVal paye As Double, ByVal loan As Double, ByVal Pmonth As String) As Boolean

    '    Dim status As Boolean

    '    Dim YearTrial = Year(Now)

    '    Dim ssnit As Double = (basicsal * Srate) / 100
    '    Dim ssnitemp As Double = (basicsal * Semp) / 100
    '    Dim ssnittier1 As Double = (basicsal * Stier1) / 100
    '    Dim trusteetier2 As Double = (basicsal * Stier2) / 100
    '    Dim pfcont As Double = (basicsal * PFtier3) / 100

    '    Dim totdeduct As Double = ssnit + pfcont + paye + loan
    '    Dim netsal As Double = gross - totdeduct

    '    Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
    '        Using cmd As New SqlCommand("insert into pay_roll_t (staff,basic_salary,allowance,gross_salary,snnit_tier_5,ssnit_emp,ssnit_t1,rusteetier2,pfcont,paye,loan,tot_deduct,net_salary,months,pay_year) values(@staff,@basic_salary,@allowance,@gross_salary,@snnit_tier_5,@ssnit_emp,@ssnit_t1,@rusteetier2,@pfcont,@paye,@loan,@tot_deduct,@net_salary,@months,@pay_year)", con)
    '            cmd.CommandType = CommandType.Text
    '            cmd.Parameters.AddWithValue("@staff", staff)
    '            cmd.Parameters.AddWithValue("@basic_salary", basicsal)
    '            cmd.Parameters.AddWithValue("@allowance", allowance)
    '            cmd.Parameters.AddWithValue("@gross_salary", gross)
    '            cmd.Parameters.AddWithValue("@snnit_tier_5", ssnit)
    '            cmd.Parameters.AddWithValue("@ssnit_emp", ssnitemp)
    '            cmd.Parameters.AddWithValue("@ssnit_t1", ssnittier1)
    '            cmd.Parameters.AddWithValue("@rusteetier2", trusteetier2)
    '            cmd.Parameters.AddWithValue("@pfcont", pfcont)
    '            cmd.Parameters.AddWithValue("@paye", paye)
    '            cmd.Parameters.AddWithValue("@loan", loan)
    '            cmd.Parameters.AddWithValue("@tot_deduct", totdeduct)
    '            cmd.Parameters.AddWithValue("@net_salary", netsal)
    '            cmd.Parameters.AddWithValue("@months", Pmonth)
    '            cmd.Parameters.AddWithValue("@pay_year", YearTrial)
    '            If con.State = ConnectionState.Closed Then
    '                con.Open()
    '            End If
    '            Dim retVal As Int32 = cmd.ExecuteNonQuery()
    '            If retVal > 0 Then
    '                status = True
    '            Else
    '                status = False
    '            End If
    '            Return status
    '            con.Close()
    '        End Using
    '    End Using

    'End Function

    Protected Sub Sumpayments()

        Try

            Dim Srate As Double = txtSnRate5.Value
            Dim Semp As Double = txsntempyer.Value
            Dim Stier1 As Double = txtsnttier1.Value
            Dim Stier2 As Double = txttteetier2.Value
            Dim PFtier3 As Double = txtpftier3.Value

            Dim freeval As Double = txt365.Value
            Dim rate0 As Double = txt0.Value
            Dim GRA110 As Double = txt110.Value
            Dim rate5 As Double = txt5.Value
            Dim GRA130 As Double = txt130.Value
            Dim rate10 As Double = txt10.Value
            Dim GRA3000 As Double = txt3000.Value
            Dim rate17 As Double = txt17.Value
            Dim GRA16395 As Double = txt16395.Value
            Dim rate25 As Double = txt25.Value
            Dim GRA20000 As Double = txt20000.Value
            Dim rate30 As Double = txt30.Value

            For Each item As RepeaterItem In rptPayRoll.Items

                Dim staff As Label = TryCast(item.FindControl("lblstaff"), Label)
                Dim basicsalary As TextBox = TryCast(item.FindControl("txtbasicsal"), TextBox)
                Dim allowance As TextBox = TryCast(item.FindControl("txtallowance"), TextBox)
                Dim gross As Label = TryCast(item.FindControl("lblgross"), Label)
                Dim ssnit As Label = TryCast(item.FindControl("lblssnit"), Label)
                Dim ssnitemp As Label = TryCast(item.FindControl("lblssnitemp"), Label)
                Dim ssnittier1 As Label = TryCast(item.FindControl("lblssnittier1"), Label)
                Dim rusteetier2 As Label = TryCast(item.FindControl("lbltrusteetier2"), Label)
                Dim pfcont As Label = TryCast(item.FindControl("lblpfcont"), Label)
                Dim paye As Label = TryCast(item.FindControl("txtpaye"), Label)
                Dim loan As TextBox = TryCast(item.FindControl("txtloan"), TextBox)
                Dim netsalary As Label = TryCast(item.FindControl("lblnet"), Label)
                Dim salarysub As Label = TryCast(item.FindControl("lblsalsub"), Label)
                Dim gra5psub As Label = TryCast(item.FindControl("lbl5p"), Label)
                Dim secondsub As Label = TryCast(item.FindControl("lblsalsecsub"), Label)
                Dim gra10psub As Label = TryCast(item.FindControl("lbl10p"), Label)
                Dim thirdsub As Label = TryCast(item.FindControl("lblthirdsub"), Label)
                Dim gra17psub As Label = TryCast(item.FindControl("lbl17p"), Label)
                Dim forthsub As Label = TryCast(item.FindControl("lblfourthdsub"), Label)
                Dim gra25psub As Label = TryCast(item.FindControl("lbl25p"), Label)
                Dim fifthsub As Label = TryCast(item.FindControl("lblfifthdsub"), Label)
                Dim gra30psub As Label = TryCast(item.FindControl("lbl30p"), Label)
                Dim sixthsub As Label = TryCast(item.FindControl("lblsixthdsub"), Label)

                Dim tot1 As Double = basicsalary.Text
                Dim tot2 As Double = allowance.Text
                Dim tot3 As Double = gross.Text
                Dim tot4 As Double = ssnit.Text
                Dim tot5 As Double = ssnitemp.Text
                Dim tot6 As Double = ssnittier1.Text
                Dim tot7 As Double = rusteetier2.Text
                Dim tot8 As Double = pfcont.Text
                Dim tot9 As Double = paye.Text
                Dim tot10 As Double = loan.Text

                gross.Text = tot1 + tot2
                ssnit.Text = (tot1 * Srate) / 100
                ssnitemp.Text = (tot1 * Semp) / 100
                ssnittier1.Text = (tot1 * Stier1) / 100
                rusteetier2.Text = (tot1 * Stier2) / 100
                pfcont.Text = (tot1 * PFtier3) / 100


                Dim basal As Double = basicsalary.Text
                Dim sn As Double = ssnit.Text

                salarysub.Text = basal - sn - freeval
                secondsub.Text = basal - sn - freeval - GRA110
                thirdsub.Text = basal - sn - freeval - GRA110 - GRA130
                forthsub.Text = basal - sn - freeval - GRA110 - GRA130 - GRA3000
                fifthsub.Text = basal - sn - freeval - GRA110 - GRA130 - GRA3000 - GRA16395
                sixthsub.Text = basal - sn - freeval - GRA110 - GRA130 - GRA3000 - GRA16395 - GRA20000

                Dim mysalarysub As Double = salarysub.Text
                Dim mysecondsub As Double = secondsub.Text
                Dim mythirdsub As Double = thirdsub.Text
                Dim myforthsub As Double = forthsub.Text
                Dim myfifthsub As Double = fifthsub.Text
                Dim mysixthsub As Double = sixthsub.Text

                If mysalarysub > GRA110 = True Then

                    gra5psub.Text = (GRA110 * rate5) / 100

                Else
                    Dim sllsub As Double = salarysub.Text
                    gra5psub.Text = (sllsub * rate5) / 100

                End If

                If mysecondsub > GRA130 = True Then

                    gra10psub.Text = (GRA130 * rate10) / 100

                Else
                    Dim sllsub As Double = secondsub.Text
                    gra10psub.Text = (sllsub * rate10) / 100

                End If

                If mythirdsub > GRA3000 = True Then

                    gra17psub.Text = (GRA3000 * rate17) / 100

                Else
                    Dim sllsub As Double = thirdsub.Text
                    gra17psub.Text = (sllsub * rate17) / 100

                End If

                If myforthsub > GRA16395 = True Then

                    gra25psub.Text = (GRA16395 * rate25) / 100

                Else
                    Dim sllsub As Double = forthsub.Text
                    gra25psub.Text = (sllsub * rate25) / 100

                End If

                If myfifthsub > GRA20000 = True Then

                    gra30psub.Text = (GRA20000 * rate30) / 100

                Else
                    Dim sllsub As Double = fifthsub.Text
                    gra30psub.Text = (sllsub * rate30) / 100

                End If

                If gra5psub.Text < 0 Then

                    gra5psub.Text = 0

                End If

                If gra10psub.Text < 0 Then

                    gra10psub.Text = 0

                End If

                If gra17psub.Text < 0 Then

                    gra17psub.Text = 0

                End If

                If gra25psub.Text < 0 Then

                    gra25psub.Text = 0

                End If

                If gra30psub.Text < 0 = True Then


                    gra30psub.Text = 0

                End If


                Dim lbl5val As Double = gra5psub.Text
                Dim lbl10p As Double = gra10psub.Text
                Dim lbl17p As Double = gra17psub.Text
                Dim lbl25p As Double = gra25psub.Text
                Dim lbl30p As Double = gra30psub.Text

                paye.Text = lbl5val + lbl10p + lbl17p + lbl25p + lbl30p

                paye.Text = Format(paye.Text, "Standard")


                If ssnit.Text = 0 Then

                    ssnit.Text = "0.00"

                    If loan.Text = 0 Then

                        loan.Text = "0.00"

                        If pfcont.Text = 0 Then

                            pfcont.Text = "0.00"

                            If ssnitemp.Text = 0 Then

                                ssnitemp.Text = "0.00"

                                If ssnittier1.Text = 0 Then

                                    ssnittier1.Text = "0.00"

                                    If rusteetier2.Text = 0 Then

                                        rusteetier2.Text = "0.00"

                                        netsalary.Text = tot3 - tot9

                                    Else

                                        netsalary.Text = tot3 - tot4 - tot8 - tot9 - tot10

                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                gross.Text = Format(gross.Text, "Standard")
                ssnit.Text = Format(ssnit.Text, "Standard")
                ssnitemp.Text = Format(ssnitemp.Text, "Standard")
                ssnittier1.Text = Format(ssnittier1.Text, "Standard")
                rusteetier2.Text = Format(rusteetier2.Text, "Standard")
                pfcont.Text = Format(pfcont.Text, "Standard")
                netsalary.Text = Format(netsalary.Text, "Standard")

            Next

            ProcessPayRoll2()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Protected Sub ProcessPayRoll2()

        Try

            Dim Srate As Double = txtSnRate5.Value
            Dim Semp As Double = txsntempyer.Value
            Dim Stier1 As Double = txtsnttier1.Value
            Dim Stier2 As Double = txttteetier2.Value
            Dim PFtier3 As Double = txtpftier3.Value

            Dim freeval As Double = txt365.Value
            Dim rate0 As Double = txt0.Value
            Dim GRA110 As Double = txt110.Value
            Dim rate5 As Double = txt5.Value
            Dim GRA130 As Double = txt130.Value
            Dim rate10 As Double = txt10.Value
            Dim GRA3000 As Double = txt3000.Value
            Dim rate17 As Double = txt17.Value
            Dim GRA16395 As Double = txt16395.Value
            Dim rate25 As Double = txt25.Value
            Dim GRA20000 As Double = txt20000.Value
            Dim rate30 As Double = txt30.Value

            For Each item As RepeaterItem In rptPayRoll.Items

                Dim staff As Label = TryCast(item.FindControl("lblstaff"), Label)
                Dim basicsalary As TextBox = TryCast(item.FindControl("txtbasicsal"), TextBox)
                Dim allowance As TextBox = TryCast(item.FindControl("txtallowance"), TextBox)
                Dim gross As Label = TryCast(item.FindControl("lblgross"), Label)
                Dim ssnit As Label = TryCast(item.FindControl("lblssnit"), Label)
                Dim ssnitemp As Label = TryCast(item.FindControl("lblssnitemp"), Label)
                Dim ssnittier1 As Label = TryCast(item.FindControl("lblssnittier1"), Label)
                Dim rusteetier2 As Label = TryCast(item.FindControl("lbltrusteetier2"), Label)
                Dim pfcont As Label = TryCast(item.FindControl("lblpfcont"), Label)
                Dim paye As Label = TryCast(item.FindControl("txtpaye"), Label)
                Dim loan As TextBox = TryCast(item.FindControl("txtloan"), TextBox)
                Dim netsalary As Label = TryCast(item.FindControl("lblnet"), Label)
                Dim salarysub As Label = TryCast(item.FindControl("lblsalsub"), Label)
                Dim gra5psub As Label = TryCast(item.FindControl("lbl5p"), Label)
                Dim secondsub As Label = TryCast(item.FindControl("lblsalsecsub"), Label)
                Dim gra10psub As Label = TryCast(item.FindControl("lbl10p"), Label)
                Dim thirdsub As Label = TryCast(item.FindControl("lblthirdsub"), Label)
                Dim gra17psub As Label = TryCast(item.FindControl("lbl17p"), Label)
                Dim forthsub As Label = TryCast(item.FindControl("lblfourthdsub"), Label)
                Dim gra25psub As Label = TryCast(item.FindControl("lbl25p"), Label)
                Dim fifthsub As Label = TryCast(item.FindControl("lblfifthdsub"), Label)
                Dim gra30psub As Label = TryCast(item.FindControl("lbl30p"), Label)
                Dim sixthsub As Label = TryCast(item.FindControl("lblsixthdsub"), Label)

                Dim tot1 As Double = basicsalary.Text
                Dim tot2 As Double = allowance.Text
                Dim tot3 As Double = gross.Text
                Dim tot4 As Double = ssnit.Text
                Dim tot5 As Double = ssnitemp.Text
                Dim tot6 As Double = ssnittier1.Text
                Dim tot7 As Double = rusteetier2.Text
                Dim tot8 As Double = pfcont.Text
                Dim tot9 As Double = paye.Text
                Dim tot10 As Double = loan.Text

                gross.Text = tot1 + tot2
                ssnit.Text = (tot1 * Srate) / 100
                ssnitemp.Text = (tot1 * Semp) / 100
                ssnittier1.Text = (tot1 * Stier1) / 100
                rusteetier2.Text = (tot1 * Stier2) / 100
                pfcont.Text = (tot1 * PFtier3) / 100


                Dim basal As Double = basicsalary.Text
                Dim sn As Double = ssnit.Text

                salarysub.Text = basal - sn - freeval
                secondsub.Text = basal - sn - freeval - GRA110
                thirdsub.Text = basal - sn - freeval - GRA110 - GRA130
                forthsub.Text = basal - sn - freeval - GRA110 - GRA130 - GRA3000
                fifthsub.Text = basal - sn - freeval - GRA110 - GRA130 - GRA3000 - GRA16395
                sixthsub.Text = basal - sn - freeval - GRA110 - GRA130 - GRA3000 - GRA16395 - GRA20000

                Dim mysalarysub As Double = salarysub.Text
                Dim mysecondsub As Double = secondsub.Text
                Dim mythirdsub As Double = thirdsub.Text
                Dim myforthsub As Double = forthsub.Text
                Dim myfifthsub As Double = fifthsub.Text
                Dim mysixthsub As Double = sixthsub.Text

                If mysalarysub > GRA110 = True Then

                    gra5psub.Text = (GRA110 * rate5) / 100

                Else
                    Dim sllsub As Double = salarysub.Text
                    gra5psub.Text = (sllsub * rate5) / 100

                End If

                If mysecondsub > GRA130 = True Then

                    gra10psub.Text = (GRA130 * rate10) / 100

                Else
                    Dim sllsub As Double = secondsub.Text
                    gra10psub.Text = (sllsub * rate10) / 100

                End If

                If mythirdsub > GRA3000 = True Then

                    gra17psub.Text = (GRA3000 * rate17) / 100

                Else
                    Dim sllsub As Double = thirdsub.Text
                    gra17psub.Text = (sllsub * rate17) / 100

                End If

                If myforthsub > GRA16395 = True Then

                    gra25psub.Text = (GRA16395 * rate25) / 100

                Else
                    Dim sllsub As Double = forthsub.Text
                    gra25psub.Text = (sllsub * rate25) / 100

                End If

                If myfifthsub > GRA20000 = True Then

                    gra30psub.Text = (GRA20000 * rate30) / 100

                Else
                    Dim sllsub As Double = fifthsub.Text
                    gra30psub.Text = (sllsub * rate30) / 100

                End If

                If gra5psub.Text < 0 Then

                    gra5psub.Text = 0

                End If

                If gra10psub.Text < 0 Then

                    gra10psub.Text = 0

                End If

                If gra17psub.Text < 0 Then

                    gra17psub.Text = 0

                End If

                If gra25psub.Text < 0 Then

                    gra25psub.Text = 0

                End If

                If gra30psub.Text < 0 = True Then


                    gra30psub.Text = 0

                End If


                Dim lbl5val As Double = gra5psub.Text
                Dim lbl10p As Double = gra10psub.Text
                Dim lbl17p As Double = gra17psub.Text
                Dim lbl25p As Double = gra25psub.Text
                Dim lbl30p As Double = gra30psub.Text

                paye.Text = lbl5val + lbl10p + lbl17p + lbl25p + lbl30p

                paye.Text = Format(paye.Text, "Standard")


                netsalary.Text = tot3 - tot4 - tot8 - tot9 - tot10

                gross.Text = Format(gross.Text, "Standard")
                ssnit.Text = Format(ssnit.Text, "Standard")
                ssnitemp.Text = Format(ssnitemp.Text, "Standard")
                ssnittier1.Text = Format(ssnittier1.Text, "Standard")
                rusteetier2.Text = Format(rusteetier2.Text, "Standard")
                pfcont.Text = Format(pfcont.Text, "Standard")
                netsalary.Text = Format(netsalary.Text, "Standard")

            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try


    End Sub


    Protected Sub InsertPayRoll(ByVal sender As Object, ByVal e As EventArgs)

        Try

            Dim YearTrial = Year(Now)

            For Each item As RepeaterItem In rptPayRoll.Items

                Dim staff As Label = TryCast(item.FindControl("lblstaff"), Label)
                Dim basicsalary As TextBox = TryCast(item.FindControl("txtbasicsal"), TextBox)
                Dim allowance As TextBox = TryCast(item.FindControl("txtallowance"), TextBox)
                Dim gross As Label = TryCast(item.FindControl("lblgross"), Label)
                Dim ssnit As Label = TryCast(item.FindControl("lblssnit"), Label)
                Dim ssnitemp As Label = TryCast(item.FindControl("lblssnitemp"), Label)
                Dim ssnittier1 As Label = TryCast(item.FindControl("lblssnittier1"), Label)
                Dim rusteetier2 As Label = TryCast(item.FindControl("lbltrusteetier2"), Label)
                Dim pfcont As Label = TryCast(item.FindControl("lblpfcont"), Label)
                Dim paye As TextBox = TryCast(item.FindControl("txtpaye"), TextBox)
                Dim loan As TextBox = TryCast(item.FindControl("txtloan"), TextBox)
                Dim netsalary As Label = TryCast(item.FindControl("lblnet"), Label)

                Dim tot1 As Double = basicsalary.Text
                Dim tot2 As Double = allowance.Text
                Dim tot3 As Double = gross.Text
                Dim tot4 As Double = ssnit.Text
                Dim tot5 As Double = ssnitemp.Text
                Dim tot6 As Double = ssnittier1.Text
                Dim tot7 As Double = rusteetier2.Text
                Dim tot8 As Double = pfcont.Text
                Dim tot9 As Double = paye.Text
                Dim tot10 As Double = loan.Text

                Dim totdeduct As Double = tot4 + tot8 + tot9 + tot10

                Dim conString As String = sCon
                Using con As SqlConnection = New SqlConnection(conString)
                    Using cmd As SqlCommand = New SqlCommand("insert into pay_roll_t (staff, basic_salary, allowance, gross_salary, snnit_tier_5, ssnit_emp, ssnit_t1, rusteetier2, pfcont, paye, loan, tot_deduct, net_salary,months,pay_year) values(@staff, @basic_salary, @allowance, @gross_salary, @snnit_tier_5, @ssnit_emp, @ssnit_t1, @rusteetier2, @pfcont, @paye, @loan, @tot_deduct, @net_salary, @months, @pay_year)", con)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.Add("@staff", SqlDbType.VarChar).Value = staff.Text
                        cmd.Parameters.Add("@basic_salary", SqlDbType.Float).Value = basicsalary.Text
                        cmd.Parameters.Add("@allowance", SqlDbType.Float).Value = allowance.Text
                        cmd.Parameters.Add("@gross_salary", SqlDbType.Float).Value = gross.Text
                        cmd.Parameters.Add("@snnit_tier_5", SqlDbType.Float).Value = ssnit.Text
                        cmd.Parameters.Add("@ssnit_emp", SqlDbType.Float).Value = ssnitemp.Text
                        cmd.Parameters.Add("@ssnit_t1", SqlDbType.Float).Value = ssnittier1.Text
                        cmd.Parameters.Add("@rusteetier2", SqlDbType.Float).Value = rusteetier2.Text
                        cmd.Parameters.Add("@pfcont", SqlDbType.Float).Value = pfcont.Text
                        cmd.Parameters.Add("@paye", SqlDbType.Float).Value = paye.Text
                        cmd.Parameters.Add("@loan", SqlDbType.Float).Value = loan.Text
                        cmd.Parameters.Add("@tot_deduct", SqlDbType.Float).Value = totdeduct
                        cmd.Parameters.Add("@net_salary", SqlDbType.Float).Value = netsalary.Text
                        cmd.Parameters.Add("@months", SqlDbType.VarChar).Value = dplmonths.Text
                        cmd.Parameters.Add("@pay_year", SqlDbType.Int).Value = ddlacayear.Text
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using

            Next

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Session("months") = dplmonths.Text
        Session("years") = ddlacayear.Text

        Response.Redirect("Pay_roll.aspx")

    End Sub


End Class