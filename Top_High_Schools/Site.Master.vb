Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class Site
    Inherits System.Web.UI.MasterPage

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim IpassAstringfrompage1 As String = Convert.ToString(Session("usertest"))

            lbluse.Text = IpassAstringfrompage1
            GetPagefont()
            GetID()
            GetControlls()
            GetMyTime()
            LoadCompany()

        End If

    End Sub

    Protected Sub LoadCompany()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand("Get_Comp_info")
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtcompid.Value = dr.Item("comp_id")

            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

        Showcomplogo()

    End Sub

    Protected Sub Showcomplogo()

        Try
            Dim id As String = txtcompid.Value
            logo.Visible = id <> "0"
            If id <> "0" Then
                Dim bytes As Byte() = DirectCast(GetData(Convert.ToString("SELECT comp_logo FROM company_t WHERE comp_id =") & id).Rows(0)("comp_logo"), Byte())
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                logo.ImageUrl = Convert.ToString("data:image/png;base64,") & base64String
            End If

        Catch ex As Exception


        End Try

    End Sub

    Protected Sub GetID()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Get_user_control"}
            'insert product
            cmd.Parameters.Add("@Employee", SqlDbType.VarChar).Value = lbluse.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtid.Value = dr.Item("id")

            End If

            cnn.Close()

        Catch ex As Exception


        End Try

        ShowStudentPhoto()

    End Sub

    Protected Sub ShowStudentPhoto()

        Try

            Dim id As String = txtid.Value
            imgstudpic.Visible = id <> "0"
            If id <> "0" Then
                Dim bytes As Byte() = DirectCast(GetData(Convert.ToString("SELECT photo FROM employee_details_v WHERE id =") & id).Rows(0)("photo"), Byte())
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                imgstudpic.ImageUrl = Convert.ToString("data:image/png;base64,") & base64String
            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GetMyTime()

        If lbluse.Text = String.Empty Then

            Response.Redirect("~/Logout.aspx")

        End If

    End Sub

    Protected Sub GetPagefont()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from page_settings_t"}
            'insert product
            'cmd.Parameters.Add("p_coa_cogm", SqlDbType.VarChar).Value = "pc"
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

    Protected Sub GetControlls()

        Try


            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from user_control_t where `users` = @users"}
            'insert product
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = lbluse.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                'Administration
                txtregs.Value = dr.Item("regform")
                If txtregs.Value = "1" Then
                    hypmyreg.Visible = True
                    HyperLink3.Visible = True
                Else
                    hypmyreg.Visible = False
                    HyperLink3.Visible = False
                End If

                txtnewadmi.Value = dr.Item("newpay")
                If txtnewadmi.Value = "1" Then
                    hyadmiform.Visible = True
                Else
                    hyadmiform.Visible = False
                End If

                txtstudlist.Value = dr.Item("stulist")
                If txtstudlist.Value = "1" Then
                    hystudlist.Visible = True
                    HyperLink4.Visible = True
                Else
                    hystudlist.Visible = False
                    HyperLink4.Visible = False
                End If

                txtstudlistbyclass.Value = dr.Item("listbyclass")
                If txtstudlistbyclass.Value = "1" Then
                    hystudlistbyclass.Visible = True
                Else
                    hystudlistbyclass.Visible = False
                End If

                txtadmianayr.Value = dr.Item("listbyyyear")
                If txtadmianayr.Value = "1" Then
                    hyadmanabyyr.Visible = True
                Else
                    hyadmanabyyr.Visible = False
                End If

                txtadmibyterm.Value = dr.Item("listbyterm")
                If txtadmibyterm.Value = "1" Then
                    hyadmbyterm.Visible = True
                Else
                    hyadmbyterm.Visible = False
                End If

                txtadmilistbyyr.Value = dr.Item("listbyyrs")
                If txtadmilistbyyr.Value = "1" Then
                    hyadmilistbyyr.Visible = True
                Else
                    hyadmilistbyyr.Visible = False
                End If

                txteditphoto.Value = dr.Item("editphoto")
                If txteditphoto.Value = "1" Then
                    hyeitphtot.Visible = True
                Else
                    hyeitphtot.Visible = False
                End If

                'Academics

                txtattendance.Value = dr.Item("attendance")
                If txtattendance.Value = "1" Then
                    hymrkatten.Visible = True
                Else
                    hymrkatten.Visible = False
                End If

                txtclsasssheet.Value = dr.Item("clsass")
                If txtclsasssheet.Value = "1" Then
                    hyclsass.Visible = True
                Else
                    hyclsass.Visible = False
                End If

                txtclstext.Value = dr.Item("cltst")
                If txtclstext.Value = "1" Then
                    hypclstest.Visible = True
                Else
                    hypclstest.Visible = False
                End If

                txthmwrk.Value = dr.Item("hmwrk")
                If txthmwrk.Value = "1" Then
                    hyphomewrk.Visible = True
                Else
                    hyphomewrk.Visible = False
                End If


                txtexms.Value = dr.Item("exmhet")
                If txtexms.Value = "1" Then
                    hypeams.Visible = True
                Else
                    hypeams.Visible = False
                End If

                txtcont.Value = dr.Item("contsheet")
                If txtcont.Value = "1" Then
                    hypcont.Visible = True
                Else
                    hypcont.Visible = False
                End If

                txtind.Value = dr.Item("indrep")
                If txtind.Value = "1" Then
                    hypindivi.Visible = True
                Else
                    hypindivi.Visible = False
                End If


                txtgroprep.Value = dr.Item("repbycls")
                If txtgroprep.Value = "1" Then
                    'hypgrprep.Visible = True
                Else
                    'hypgrprep.Visible = False
                End If

                txtclsactivity.Value = dr.Item("chkuploa")
                If txtclsactivity.Value = "1" Then
                    hypupload.Visible = True
                Else
                    hypupload.Visible = False
                End If

                txtcontent.Value = dr.Item("cmtent")
                If txtcontent.Value = "1" Then
                    hypcontent.Visible = True
                Else
                    hypcontent.Visible = False
                End If

                'Staff Management
                txtstfform.Value = dr.Item("stfform")
                If txtstfform.Value = "1" Then
                    hystfform.Visible = True
                Else
                    hystfform.Visible = False
                End If

                txtstflist.Value = dr.Item("stflist")
                If txtstflist.Value = "1" Then
                    hystflst.Visible = True
                Else
                    hystflst.Visible = False
                End If

                txtsnit.Value = dr.Item("snit")
                If txtsnit.Value = "1" Then
                    hypssnit.Visible = True
                Else
                    hypssnit.Visible = False
                End If

                txtincome.Value = dr.Item("income")
                If txtincome.Value = "1" Then
                    hypincome.Visible = True
                Else
                    hypincome.Visible = False
                End If

                txtprlpros.Value = dr.Item("prlpros")
                If txtprlpros.Value = "1" Then
                    hypyrlproc.Visible = True
                    HyperLink1.Visible = True
                    HyperLink2.Visible = True
                Else
                    hypyrlproc.Visible = False
                    HyperLink1.Visible = False
                    HyperLink2.Visible = False
                End If

                txtpayroll.Value = dr.Item("payroll")
                If txtpayroll.Value = "1" Then
                    hypyroll.Visible = True
                Else
                    hypyroll.Visible = False
                End If


                txtslip.Value = dr.Item("slip")
                If txtslip.Value = "1" Then
                    hyppayslip.Visible = True
                Else
                    hyppayslip.Visible = False
                End If

                'Accounting
                txtchtacc.Value = dr.Item("chtacc")
                If txtchtacc.Value = "1" Then
                    hychtofacc.Visible = True
                Else
                    hychtofacc.Visible = False
                End If

                txtcntlist.Value = dr.Item("cntlist")
                If txtcntlist.Value = "1" Then
                    hycntlst.Visible = True
                Else
                    hycntlst.Visible = False
                End If

                txtschfeestam.Value = dr.Item("schfeestam")
                If txtschfeestam.Value = "1" Then
                    hyschstm.Visible = True
                Else
                    hyschstm.Visible = False
                End If

                txtjrnent.Value = dr.Item("jrnent")
                If txtjrnent.Value = "1" Then
                    hyjurent.Visible = True
                Else
                    hyjurent.Visible = False
                End If

                txtrecschpay.Value = dr.Item("recschpay")
                If txtrecschpay.Value = "1" Then
                    hyrecschfe.Visible = True
                Else
                    hyrecschfe.Visible = False
                End If

                txtrecadmpay.Value = dr.Item("recadmpay")
                If txtrecadmpay.Value = "1" Then
                    'hyrecadmi.Visible = True
                Else
                    'hyrecadmi.Visible = False
                End If

                txtschfeelst.Value = dr.Item("schfeelst")
                If txtschfeelst.Value = "1" Then
                    hyschslst.Visible = True
                Else
                    hyschslst.Visible = False
                End If

                txtdeblst.Value = dr.Item("deblst")
                If txtdeblst.Value = "1" Then
                    hydeblist.Visible = True
                Else
                    hydeblist.Visible = False
                End If

                txtpaybills.Value = dr.Item("paybills")
                If txtpaybills.Value = "1" Then
                    'hypaybils.Visible = True
                Else
                    'hypaybils.Visible = False
                End If

                txteditschfee.Value = dr.Item("editschfee")
                If txteditschfee.Value = "1" Then
                    hyedschstm.Visible = True
                Else
                    hyedschstm.Visible = False
                End If

                'Bank
                txtsetup.Value = dr.Item("setup")
                If txtsetup.Value = "1" Then
                    hytrns.Visible = True
                Else
                    hytrns.Visible = False
                End If

                txtdepsit.Value = dr.Item("depsit")
                If txtdepsit.Value = "1" Then
                    hydpst.Visible = True
                Else
                    hydpst.Visible = False
                End If

                txtwtdrw.Value = dr.Item("wtdrw")
                If txtwtdrw.Value = "1" Then
                    hywthd.Visible = True
                Else
                    hywthd.Visible = False
                End If

                txttrnsf.Value = dr.Item("trnsf")
                If txttrnsf.Value = "1" Then
                    hytrnsf.Visible = True
                Else
                    hytrnsf.Visible = False
                End If

                txtbnkstam.Value = dr.Item("bnkstam")
                If txtbnkstam.Value = "1" Then
                    hybnkstm.Visible = True
                Else
                    hybnkstm.Visible = False
                End If

                txttb.Value = dr.Item("tb")
                If txttb.Value = "1" Then
                    hytbl.Visible = True
                Else
                    hytbl.Visible = False
                End If

                txtpl.Value = dr.Item("pl")
                If txtpl.Value = "1" Then
                    hypls.Visible = True
                Else
                    hypls.Visible = False
                End If

                txtbls.Value = dr.Item("bls")
                If txtbls.Value = "1" Then
                    hybalsht.Visible = True
                Else
                    hybalsht.Visible = False
                End If

                txtchflw.Value = dr.Item("chflw")
                If txtchflw.Value = "1" Then
                    hychsflw.Visible = True
                Else
                    hychsflw.Visible = False
                End If

                txtchngequ.Value = dr.Item("chngequ")
                If txtchngequ.Value = "1" Then
                    hychgequ.Visible = True
                Else
                    hychgequ.Visible = False
                End If

                'School

                txtschinfo.Value = dr.Item("schinfo")
                If txtschinfo.Value = "1" Then
                    hyschinfo.Visible = True
                Else
                    hyschinfo.Visible = False
                End If

                txtmsgcnt.Value = dr.Item("msgcnt")
                If txtmsgcnt.Value = "1" Then
                    hymsgcnt.Visible = True
                Else
                    hymsgcnt.Visible = False
                End If

                txtacadar.Value = dr.Item("acadar")
                If txtacadar.Value = "1" Then
                    hyacadar.Visible = True
                Else
                    hyacadar.Visible = False
                End If

                txtadfeesbill.Value = dr.Item("adfeesbill")
                If txtadfeesbill.Value = "1" Then
                    hyadfebils.Visible = True
                Else
                    hyadfebils.Visible = False
                End If

                txtlnrares.Value = dr.Item("lnrares")
                If txtlnrares.Value = "1" Then
                    hylrnatres.Visible = True
                    'hyrmvfearsdups.Visible = True
                    hyrmvclsdup.Visible = True
                Else
                    hylrnatres.Visible = False
                    'hyrmvfearsdups.Visible = False
                    hyrmvclsdup.Visible = False
                End If

                txtadclas.Value = dr.Item("adclas")
                If txtadclas.Value = "1" Then
                    hyadcls.Visible = True
                Else
                    hyadcls.Visible = False
                End If

                txtedtcurclass.Value = dr.Item("edtcurclass")
                If txtedtcurclass.Value = "1" Then
                    hyedcurcls.Visible = True
                Else
                    hyedcurcls.Visible = False
                End If

                txtadsubjt.Value = dr.Item("adsubjt")
                If txtadsubjt.Value = "1" Then
                    adsubjt.Visible = True
                Else
                    adsubjt.Visible = False
                End If

                txtuserlst.Value = dr.Item("userlst")
                If txtuserlst.Value = "1" Then
                    hyuslst.Visible = True
                Else
                    hyuslst.Visible = False
                End If

                txtacscontrl.Value = dr.Item("acscontrl")
                If txtacscontrl.Value = "1" Then
                    hyuscntrl.Visible = True
                Else
                    hyuscntrl.Visible = False
                End If

                txtpromo.Value = dr.Item("promo")
                If txtpromo.Value = "1" Then
                    hypromo.Visible = True
                Else
                    hypromo.Visible = False
                End If

                txtactive.Value = dr.Item("active")
                If txtactive.Value = "1" Then
                    hystuacti.Visible = True
                Else
                    hystuacti.Visible = False
                End If

                txtpagsett.Value = dr.Item("pages")
                If txtpagsett.Value = "1" Then
                    hypagesett.Visible = True
                Else
                    hypagesett.Visible = False
                End If

            End If

            cnn.Close()

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

End Class