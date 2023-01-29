Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Pay_roll1
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Public Class EmpsalList
        Public Property Employee As String
        Public Property basic_salary As Double
        Public Property allowance As Double
        Public Property gross_salary As Double
        Public Property snnit_tier_5 As Double
        Public Property ssnit_emp As Double
        Public Property ssnit_t1 As Double
        Public Property rusteetier2 As Double
        Public Property paye As Double
        Public Property pfcont As Double
        Public Property loan As Double
        Public Property net_salary As Double

    End Class

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("months"))

            dplmonths.Text = IpassAstringfrompage1

            Dim IpassAstringfrompage2 As String = Convert.ToString(Session("years"))

            dplyear.Text = IpassAstringfrompage2

            GetPagefont()
            GetStsff()

            RepeaterDB.DataSource = Me.GetEmpsal
            RepeaterDB.DataBind()

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


    Protected Sub GetStsff()

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
                    dplyear.DataSource = ds
                    dplyear.DataTextField = "aca_year"
                    dplyear.DataValueField = "aca_year"
                    dplyear.DataBind()
                    dplyear.Items.Insert(0, New ListItem("", "0"))

                    cmd.Connection = con : con.Close()

                Catch ex As Exception



                End Try

            End Using
        End Using

    End Sub

    Private Function GetEmpsal() As List(Of EmpsalList)

        Dim constring As String = sCon
        Using con As New SqlConnection(constring)
            Using cmd As New SqlCommand("select * from pay_roll_v where months = @months and pay_year = @pay_year", con)
                Dim empsallist As New List(Of EmpsalList)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@months", SqlDbType.VarChar).Value = dplmonths.Text
                cmd.Parameters.Add("@pay_year", SqlDbType.Int).Value = dplyear.Text
                con.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    While sdr.Read()
                        empsallist.Add(New EmpsalList With {
                                      .Employee = sdr("Employee").ToString(),
                                      .basic_salary = Convert.ToDouble(sdr("basic_salary")),
                                      .allowance = Convert.ToDouble(sdr("allowance")),
                                      .gross_salary = Convert.ToDouble(sdr("gross_salary")),
                                      .snnit_tier_5 = Convert.ToDouble(sdr("snnit_tier_5")),
                                      .ssnit_emp = Convert.ToDouble(sdr("ssnit_emp")),
                                      .ssnit_t1 = Convert.ToDouble(sdr("ssnit_t1")),
                                      .rusteetier2 = Convert.ToDouble(sdr("rusteetier2")),
                                      .pfcont = Convert.ToDouble(sdr("pfcont")),
                                      .paye = Convert.ToDouble(sdr("paye")),
                                      .loan = Convert.ToDouble(sdr("loan")),
                                      .net_salary = Convert.ToDouble(sdr("net_salary"))
                                    })
                    End While
                End Using
                con.Close()
                Return empsallist
            End Using
        End Using
    End Function

    Private Sub dplmonths_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dplmonths.SelectedIndexChanged
        RepeaterDB.DataSource = Me.GetEmpsal
        RepeaterDB.DataBind()
    End Sub

    Private Sub dplmonths_TextChanged(sender As Object, e As EventArgs) Handles dplmonths.TextChanged
        RepeaterDB.DataSource = Me.GetEmpsal
        RepeaterDB.DataBind()
    End Sub

    Private Sub dplyear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dplyear.SelectedIndexChanged
        RepeaterDB.DataSource = Me.GetEmpsal
        RepeaterDB.DataBind()
    End Sub

    Private Sub dplyear_TextChanged(sender As Object, e As EventArgs) Handles dplyear.TextChanged
        RepeaterDB.DataSource = Me.GetEmpsal
        RepeaterDB.DataBind()
    End Sub
End Class