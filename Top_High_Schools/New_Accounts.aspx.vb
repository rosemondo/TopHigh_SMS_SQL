Imports System.Web.Script.Serialization
Imports System.Data.SqlClient
Imports System.Web.Services

Public Class New_Accounts
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetPagefont()

        End If

    End Sub

    Protected Sub GetPagefont()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_page_settings"}
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


    Protected Sub Get_CheckChanged(ByVal sender As Object, ByVal e As EventArgs)

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

                txtAcSubGroup.Value = dr.Item("coa_sub_group")
                txtAcCate.Value = dr.Item("coa_cate")

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


    <WebMethod()>
    Public Shared Function InsertChartAcct(ByVal txtAcCode As String, ByVal txtAcName As String, ByVal txtAcagroup As String, ByVal txtAcSubGroup As String, ByVal txtAcCate As String, ByVal ddlcashflow As String, ByVal txtocbfy As String, ByVal txtcogm As String) As Boolean

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertChart"}
            cmd.Parameters.Add("@coa_code", SqlDbType.VarChar).Value = txtAcCode
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = txtAcName
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = txtAcagroup
            cmd.Parameters.Add("@coa_sub_group", SqlDbType.VarChar).Value = txtAcSubGroup
            cmd.Parameters.Add("@coa_cate", SqlDbType.VarChar).Value = txtAcCate
            cmd.Parameters.Add("@coa_cf", SqlDbType.VarChar).Value = ddlcashflow
            cmd.Parameters.Add("@coa_ocbfy", SqlDbType.VarChar).Value = txtocbfy
            cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = txtcogm
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)

        End Try

        Return True
    End Function

End Class