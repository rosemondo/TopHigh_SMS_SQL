Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Edit_Chart_of_Account
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("code"))

            txtcode.Text = IpassAstringfrompage1

            GetPagefont()
            ShowData()

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


    Protected Sub OnCheckChanged(ByVal sender As Object, ByVal e As EventArgs)

        If chkcurass.Checked = True Then

            txtAcagroup.Text = chkcurass.Text

            GetCode()
            FillCurAssetBox()

        ElseIf chkrecevables.Checked = True Then

            txtAcagroup.Text = chkrecevables.Text

            GetCode()
            FillCurAssetBox()

        ElseIf chkinven.Checked = True Then

            txtAcagroup.Text = chkinven.Text

            GetCode()
            FillCurAssetBox()

        ElseIf chkprepaid.Checked = True Then

            txtAcagroup.Text = chkprepaid.Text

            GetCode()
            FillCurAssetBox()

        ElseIf chkfixass.Checked = True Then

            txtAcagroup.Text = chkfixass.Text

            GetCode()
            FillCurAssetBox()

        ElseIf chkpaya.Checked = True Then

            txtAcagroup.Text = chkpaya.Text

            GetCode()
            FillCurAssetBox()

        ElseIf chkbebt.Checked = True Then

            txtAcagroup.Text = chkbebt.Text

            GetCode()
            FillCurAssetBox()

        ElseIf chkequ.Checked = True Then

            txtAcagroup.Text = chkequ.Text

            GetCode()
            FillCurAssetBox()

        ElseIf chkrev.Checked = True Then

            txtAcagroup.Text = chkrev.Text

            GetCode()
            FillCurAssetBox()

        ElseIf chkcogs.Checked = True Then

            txtAcagroup.Text = chkcogs.Text

            GetCode()
            FillCurAssetBox()

        ElseIf chkopexp.Checked = True Then

            txtAcagroup.Text = chkopexp.Text

            GetCode()
            FillCurAssetBox()

        ElseIf chkotherexp.Checked = True Then

            txtAcagroup.Text = chkotherexp.Text

            GetCode()
            FillCurAssetBox()

        ElseIf chkaccum.Checked = True Then

            txtAcagroup.Text = chkaccum.Text

            GetCode()
            FillCurAssetBox()

        End If

    End Sub

    Protected Sub CurAssetsCode()

        Try

            Dim result As String
            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(Code) FROM coa_assest_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "1000"
                txtAcCode.Text = result
            Else

                result = result + 2
            End If

            txtAcCode.Text = result

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Receivables()

        Try

            Dim result As String
            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_assest_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "1200"
                txtAcCode.Text = result
            Else

                result = result + 2
            End If

            txtAcCode.Text = result

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Inventories()

        Try

            Dim result As String
            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_assest_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "1300"
                txtAcCode.Text = result
            Else

                result = result + 2
            End If

            txtAcCode.Text = result

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub PrepaidEx()

        Try

            Dim result As String
            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_assest_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "1400"
                txtAcCode.Text = result
            Else

                result = result + 2
            End If

            txtAcCode.Text = result

            cnn.Close()

        Catch ex As Exception

        End Try


    End Sub

    Public Sub FixedAss()

        Try

            Dim result As String
            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_assest_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "1500"
                txtAcCode.Text = result
            Else

                result = result + 2
            End If

            txtAcCode.Text = result

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub AccMu()

        Try

            Dim result As String
            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_assest_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "1600"
                txtAcCode.Text = result
            Else

                result = result + 2
            End If

            txtAcCode.Text = result

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CogsAc()

        Try

            Dim result As String
            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_expense_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "5000"
                txtAcCode.Text = result
            Else

                result = result + 2
            End If

            txtAcCode.Text = result

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Payables()

        Try

            Dim result As String
            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_liabit_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "2000"
                txtAcCode.Text = result
            Else

                result = result + 2
            End If

            txtAcCode.Text = result

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub DebtsAc()

        Try

            Dim result As String
            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_liabit_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "2700"
                txtAcCode.Text = result
            Else

                result = result + 2
            End If

            txtAcCode.Text = result

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub EquitiesAc()

        Try

            Dim result As String
            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_acc_equ_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "3000"
                txtAcCode.Text = result
            Else

                result = result + 2
            End If

            txtAcCode.Text = result

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub RevenuesAc()

        Try

            Dim result As String
            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_revenue_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "4000"
                txtAcCode.Text = result
            Else

                result = result + 2
            End If

            txtAcCode.Text = result

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub OperatinEX()

        Try

            Dim result As String
            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_expense_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "6000"
                txtAcCode.Text = result
            Else

                result = result + 2
            End If

            txtAcCode.Text = result

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub OtherOperatinEX()

        Try

            Dim result As String
            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_expense_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "7000"
                txtAcCode.Text = result
            Else

                result = result + 2
            End If

            txtAcCode.Text = result

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub FillCurAssetBox()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetChartGroupings"}
            'insert product
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = txtAcagroup.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtAcSubGroup.Text = dr.Item("coa_sub_group")
                txtAcCate.Text = dr.Item("coa_cate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GetCode()

        If txtAcagroup.Text = "CURRENT ASSETS" Then
            CurAssetsCode()
        End If

        If txtAcagroup.Text = "RECEIVABLES" Then
            Receivables()
        End If

        If txtAcagroup.Text = "INVENTORIES" Then
            Inventories()
        End If

        If txtAcagroup.Text = "PREPAID EXPENSES" Then
            PrepaidEx()
        End If

        If txtAcagroup.Text = "FIXED ASSETS" Then
            FixedAss()
        End If

        If txtAcagroup.Text = "ACCUMULATED DEPRECIATION and AMORTIZATION" Then
            AccMu()
        End If

        If txtAcagroup.Text = "PAYABLES" Then
            Payables()
        End If

        If txtAcagroup.Text = "DEBTS" Then
            DebtsAc()
        End If

        If txtAcagroup.Text = "EQUITIES" Then
            EquitiesAc()
        End If

        If txtAcagroup.Text = "REVENUE" Then
            RevenuesAc()
        End If

        If txtAcagroup.Text = "COST of GOODS SOLD" Then
            CogsAc()
        End If

        If txtAcagroup.Text = "OPERATING EXPENSES" Then
            OperatinEX()
        End If

        If txtAcagroup.Text = "OTHER EXPENSES" Then
            OtherOperatinEX()
        End If

    End Sub

    Protected Sub ShowData()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM chart_of_account_t WHERE  coa_id='{0}'", txtcode.Text), cnn)
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtAcCode.Text = dr.Item("coa_code")
                txtAcName.Text = dr.Item("coa_name")
                txtAcagroup.Text = dr.Item("coa_group")
                txtAcSubGroup.Text = dr.Item("coa_sub_group")
                txtAcCate.Text = dr.Item("coa_cate")
                ddlcashflow.Text = dr.Item("coa_cf")
                txtocbfy.Text = dr.Item("coa_ocbfy")
                txtcogm.Text = dr.Item("coa_cogm")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try


    End Sub


    Protected Sub InsertChartAcct()


        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "updateChart"}
            cmd.Parameters.Add("@coa_code", SqlDbType.VarChar).Value = txtAcCode.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = txtAcName.Text
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = txtAcagroup.Text
            cmd.Parameters.Add("@coa_sub_group", SqlDbType.VarChar).Value = txtAcSubGroup.Text.Trim()
            cmd.Parameters.Add("@coa_cate", SqlDbType.VarChar).Value = txtAcCate.Text.Trim()
            cmd.Parameters.Add("@coa_cf", SqlDbType.VarChar).Value = ddlcashflow.Text
            cmd.Parameters.Add("@coa_ocbfy", SqlDbType.VarChar).Value = txtocbfy.Text.Trim()
            cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = txtcogm.Text.Trim()
            cmd.Parameters.Add("@coa_id", SqlDbType.Int).Value = txtcode.Text
            cmd.Connection = cnn
            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch oex As Exception
                MsgBox(oex.Message, "Record did not update error has occur")
            Finally
                cnn.Close()
                cnn.Dispose()
            End Try

            txtAcCode.Text = String.Empty
            txtAcName.Text = String.Empty
            txtAcagroup.Text = String.Empty
            txtAcSubGroup.Text = String.Empty
            txtAcCate.Text = String.Empty
            ddlcashflow.ClearSelection()

        Catch oex As Exception

        End Try

        Response.Redirect("ChartofAccount.aspx")

    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        InsertChartAcct()

    End Sub

End Class