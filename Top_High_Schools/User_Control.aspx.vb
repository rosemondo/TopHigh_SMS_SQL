Imports System.Web.Script.Serialization
Imports System.Data.SqlClient

Public Class User_Control
    Inherits System.Web.UI.Page

    Private DbCon As New DbConnectionClass()

    Dim sCon As String = DbCon.GetConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            GetPagefont()
            GetStsff()
            GetClass()

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

    Protected Sub GetStsff()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetEmpList")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetEmpList")

                    ' BIND DATABASE TO SELECT.
                    ddlstaff.DataSource = ds
                    ddlstaff.DataTextField = "emp"
                    ddlstaff.DataValueField = "emp"
                    ddlstaff.DataBind()
                    ddlstaff.Items.Insert(0, "")

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetClass()

        ' SET THE CONNECTION STRING.

        Using con As SqlConnection = New SqlConnection(sCon)
            Using cmd As SqlCommand = New SqlCommand("GetClass")

                Dim sda As SqlDataAdapter = New SqlDataAdapter
                Try
                    cmd.Connection = con : con.Open()
                    sda.SelectCommand = cmd

                    Dim ds As DataSet = New DataSet
                    sda.Fill(ds, "GetClass")

                    ' BIND DATABASE TO SELECT.
                    ddlclass.DataSource = ds
                    ddlclass.DataTextField = "ClassName"
                    ddlclass.DataValueField = "ClassName"
                    ddlclass.DataBind()
                    ddlclass.Items.Insert(0, "All Class")

                    cmd.Connection = con : con.Close()

                Catch ex As Exception

                    Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                    Dim script = String.Format("alert({0});", message)
                    ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

                End Try

            End Using
        End Using

    End Sub

    Protected Sub GetStaffID()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "user_control"}
            'insert product
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = ddlstaff.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                txtid.Value = dr.Item("id")
                chkregs.Checked = dr.Item("regform")
                chknewadmi.Checked = dr.Item("newpay")
                chkstudlist.Checked = dr.Item("stulist")
                chkstudlistbyclass.Checked = dr.Item("listbyclass")
                chkadmianayr.Checked = dr.Item("listbyyyear")
                chkadmibyterm.Checked = dr.Item("listbyterm")
                chkadmilistbyyr.Checked = dr.Item("listbyyrs")
                chkeditphoto.Checked = dr.Item("editphoto")
                chkattendance.Checked = dr.Item("attendance")
                chkclsass.Checked = dr.Item("clsass")
                chkcltst.Checked = dr.Item("cltst")
                chkhmwrk.Checked = dr.Item("hmwrk")
                chkexmhet.Checked = dr.Item("exmhet")
                chkcontsheet.Checked = dr.Item("contsheet")
                chkindrep.Checked = dr.Item("indrep")
                chkrepbycls.Checked = dr.Item("repbycls")
                chkuploa.Checked = dr.Item("chkuploa")
                chkcmtent.Checked = dr.Item("cmtent")
                chkstfform.Checked = dr.Item("stfform")
                chkstflist.Checked = dr.Item("stflist")
                chksnit.Checked = dr.Item("snit")
                chkincome.Checked = dr.Item("income")
                chkprlpros.Checked = dr.Item("prlpros")
                chkpayroll.Checked = dr.Item("payroll")
                chkslip.Checked = dr.Item("slip")
                chkchtacc.Checked = dr.Item("chtacc")
                chkcntlist.Checked = dr.Item("cntlist")
                chkschfeestam.Checked = dr.Item("schfeestam")
                chkincome.Checked = dr.Item("income")
                chkjrnent.Checked = dr.Item("jrnent")
                chkrecschpay.Checked = dr.Item("recschpay")
                chkrecadmpay.Checked = dr.Item("recadmpay")
                chkschfeelst.Checked = dr.Item("schfeelst")
                chkdeblst.Checked = dr.Item("deblst")
                chkpaybills.Checked = dr.Item("paybills")
                chkeditschfee.Checked = dr.Item("editschfee")
                chksetup.Checked = dr.Item("setup")
                chkdepsit.Checked = dr.Item("depsit")
                chkwtdrw.Checked = dr.Item("wtdrw")
                chktrnsf.Checked = dr.Item("trnsf")
                chkbnkstam.Checked = dr.Item("bnkstam")
                chktb.Checked = dr.Item("tb")
                chkpl.Checked = dr.Item("pl")
                chkbls.Checked = dr.Item("bls")
                chkchflw.Checked = dr.Item("chflw")
                chkchngequ.Checked = dr.Item("chngequ")
                chkschinfo.Checked = dr.Item("schinfo")
                chkmsgcnt.Checked = dr.Item("msgcnt")
                chkacadar.Checked = dr.Item("acadar")
                chkadfeesbill.Checked = dr.Item("adfeesbill")
                chklnrares.Checked = dr.Item("lnrares")
                chkadclas.Checked = dr.Item("adclas")
                chkedtcurclass.Checked = dr.Item("edtcurclass")
                chkadsubjt.Checked = dr.Item("adsubjt")
                chkuserlst.Checked = dr.Item("userlst")
                chkacscontrl.Checked = dr.Item("acscontrl")
                chkpromo.Checked = dr.Item("promo")
                chkactive.Checked = dr.Item("active")
                chkpage.Checked = dr.Item("pages")
                ddlclass.Text = dr.Item("class")
            End If

            cnn.Close()

        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "", script, True)

        End Try

    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        'Administration
        If chkregs.Checked = True Then
            txtregs.Text = "1"
        Else
            txtregs.Text = "0"
        End If


        If chknewadmi.Checked = True Then
            txtnewadmi.Text = "1"
        Else
            txtnewadmi.Text = "0"
        End If

        If chkstudlist.Checked = True Then
            txtstudlist.Text = "1"
        Else
            txtstudlist.Text = "0"
        End If

        If chkstudlistbyclass.Checked = True Then
            txtstudlistbyclass.Text = "1"
        Else
            txtstudlistbyclass.Text = "0"
        End If

        If chkadmianayr.Checked = True Then
            txtadmianayr.Text = "1"
        Else
            txtadmianayr.Text = "0"
        End If

        If chkadmibyterm.Checked = True Then
            txtadmibyterm.Text = "1"
        Else
            txtadmibyterm.Text = "0"
        End If

        If chkadmilistbyyr.Checked = True Then
            txtadmilistbyyr.Text = "1"
        Else
            txtadmilistbyyr.Text = "0"
        End If

        If chkeditphoto.Checked = True Then
            txtphoto.Text = "1"
        Else
            txtphoto.Text = "0"
        End If


        'Academics
        If chkattendance.Checked = True Then
            txtattendance.Text = "1"
        Else
            txtattendance.Text = "0"
        End If

        If chkclsass.Checked = True Then
            txtclsass.Text = "1"
        Else
            txtclsass.Text = "0"
        End If

        If chkcltst.Checked = True Then
            txtcltst.Text = "1"
        Else
            txtcltst.Text = "0"
        End If

        If chkhmwrk.Checked = True Then
            txthmwrk.Text = "1"
        Else
            txthmwrk.Text = "0"
        End If

        If chkexmhet.Checked = True Then
            txtexmhet.Text = "1"
        Else
            txtexmhet.Text = "0"
        End If

        If chkcontsheet.Checked = True Then
            txtcontsheet.Text = "1"
        Else
            txtcontsheet.Text = "0"
        End If

        If chkindrep.Checked = True Then
            txtindrep.Text = "1"
        Else
            txtindrep.Text = "0"
        End If

        If chkrepbycls.Checked = True Then
            txtrepbycls.Text = "1"
        Else
            txtrepbycls.Text = "0"
        End If

        If chkuploa.Checked = True Then
            txtuploa.Text = "1"
        Else
            txtuploa.Text = "0"
        End If

        If chkcmtent.Checked = True Then
            txtcmtent.Text = "1"
        Else
            txtcmtent.Text = "0"
        End If


        'Staff Management
        If chkstfform.Checked = True Then
            txtstfform.Text = "1"
        Else
            txtstfform.Text = "0"
        End If

        If chkstflist.Checked = True Then
            txtstflist.Text = "1"
        Else
            txtstflist.Text = "0"
        End If

        If chksnit.Checked = True Then
            txtssnit.Text = "1"
        Else
            txtssnit.Text = "0"
        End If

        If chkincome.Checked = True Then
            txtincome.Text = "1"
        Else
            txtincome.Text = "0"
        End If

        If chkprlpros.Checked = True Then
            txtprlpros.Text = "1"
        Else
            txtprlpros.Text = "0"
        End If

        If chkpayroll.Checked = True Then
            txtpayroll.Text = "1"
        Else
            txtpayroll.Text = "0"
        End If

        If chkslip.Checked = True Then
            txtslip.Text = "1"
        Else
            txtslip.Text = "0"
        End If

        'Accounting
        If chkchtacc.Checked = True Then
            txtchtacc.Text = "1"
        Else
            txtchtacc.Text = "0"
        End If

        If chkcntlist.Checked = True Then
            txtcntlist.Text = "1"
        Else
            txtcntlist.Text = "0"
        End If

        If chkschfeestam.Checked = True Then
            txtschfeestam.Text = "1"
        Else
            txtschfeestam.Text = "0"
        End If

        If chkincome.Checked = True Then
            txtincome.Text = "1"
        Else
            txtincome.Text = "0"
        End If

        If chkjrnent.Checked = True Then
            txtjrnent.Text = "1"
        Else
            txtjrnent.Text = "0"
        End If

        If chkrecschpay.Checked = True Then
            txtrecschpay.Text = "1"
        Else
            txtrecschpay.Text = "0"
        End If

        If chkrecadmpay.Checked = True Then
            txtrecadmpay.Text = "1"
        Else
            txtrecadmpay.Text = "0"
        End If


        If chkschfeelst.Checked = True Then
            txtschfeelst.Text = "1"
        Else
            txtschfeelst.Text = "0"
        End If

        If chkdeblst.Checked = True Then
            txtdeblst.Text = "1"
        Else
            txtdeblst.Text = "0"
        End If

        If chkpaybills.Checked = True Then
            txtpaybills.Text = "1"
        Else
            txtpaybills.Text = "0"
        End If

        If chkeditschfee.Checked = True Then
            txteditschfee.Text = "1"
        Else
            txteditschfee.Text = "0"
        End If

        'Banking
        If chksetup.Checked = True Then
            txtsetup.Text = "1"
        Else
            txtsetup.Text = "0"
        End If

        If chkdepsit.Checked = True Then
            txtdepsit.Text = "1"
        Else
            txtdepsit.Text = "0"
        End If

        If chkwtdrw.Checked = True Then
            txtwtdrw.Text = "1"
        Else
            txtwtdrw.Text = "0"
        End If

        If chktrnsf.Checked = True Then
            txttrnsf.Text = "1"
        Else
            txttrnsf.Text = "0"
        End If

        If chkbnkstam.Checked = True Then
            txtbnkstam.Text = "1"
        Else
            txtbnkstam.Text = "0"
        End If

        'Financial Report
        If chktb.Checked = True Then
            txttb.Text = "1"
        Else
            txttb.Text = "0"
        End If

        If chkpl.Checked = True Then
            txtpl.Text = "1"
        Else
            txtpl.Text = "0"
        End If

        If chkbls.Checked = True Then
            txtbls.Text = "1"
        Else
            txtbls.Text = "0"
        End If

        If chkchflw.Checked = True Then
            txtchflw.Text = "1"
        Else
            txtchflw.Text = "0"
        End If

        If chkchngequ.Checked = True Then
            txtchngequ.Text = "1"
        Else
            txtchngequ.Text = "0"
        End If


        'School Settings
        If chkschinfo.Checked = True Then
            txtschinfo.Text = "1"
        Else
            txtschinfo.Text = "0"
        End If

        If chkmsgcnt.Checked = True Then
            txtmsgcnt.Text = "1"
        Else
            txtmsgcnt.Text = "0"
        End If

        If chkacadar.Checked = True Then
            txtacadar.Text = "1"
        Else
            txtacadar.Text = "0"
        End If

        If chkadfeesbill.Checked = True Then
            txtadfeesbill.Text = "1"
        Else
            txtadfeesbill.Text = "0"
        End If

        If chklnrares.Checked = True Then
            txtlnrares.Text = "1"
        Else
            txtlnrares.Text = "0"
        End If

        If chkadclas.Checked = True Then
            txtadclas.Text = "1"
        Else
            txtadclas.Text = "0"
        End If

        If chkedtcurclass.Checked = True Then
            txtedtcurclass.Text = "1"
        Else
            txtedtcurclass.Text = "0"
        End If

        If chkadsubjt.Checked = True Then
            txtadsubjt.Text = "1"
        Else
            txtadsubjt.Text = "0"
        End If

        If chkuserlst.Checked = True Then
            txtuserlst.Text = "1"
        Else
            txtuserlst.Text = "0"
        End If

        If chkacscontrl.Checked = True Then
            txtacscontrl.Text = "1"
        Else
            txtacscontrl.Text = "0"
        End If

        If chkpromo.Checked = True Then
            txtpromo.Text = "1"
        Else
            txtpromo.Text = "0"
        End If

        If chkactive.Checked = True Then
            txtactive.Text = "1"
        Else
            txtactive.Text = "0"
        End If

        If chkpage.Checked = True Then
            txtpage.Text = "1"
        Else
            txtpage.Text = "0"
        End If

        If txtid.Value = "0" = False Then

            UpdatetUserContrl()

        Else

            InsertUserContrl()

        End If

    End Sub

    Protected Sub InsertUserContrl()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertUserContrl"}
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = ddlstaff.Text
            cmd.Parameters.Add("@regform", SqlDbType.Int).Value = txtregs.Text
            cmd.Parameters.Add("@newpay", SqlDbType.Int).Value = txtnewadmi.Text
            cmd.Parameters.Add("@stulist", SqlDbType.Int).Value = txtstudlist.Text
            cmd.Parameters.Add("@listbyclass", SqlDbType.Int).Value = txtstudlistbyclass.Text
            cmd.Parameters.Add("@listbyyyear", SqlDbType.Int).Value = txtadmianayr.Text
            cmd.Parameters.Add("@listbyterm", SqlDbType.Int).Value = txtadmibyterm.Text
            cmd.Parameters.Add("@listbyyrs", SqlDbType.Int).Value = txtadmilistbyyr.Text
            cmd.Parameters.Add("@editphoto", SqlDbType.Int).Value = txtphoto.Text

            cmd.Parameters.Add("@attendance", SqlDbType.VarChar).Value = txtattendance.Text
            cmd.Parameters.Add("@clsass", SqlDbType.Int).Value = txtclsass.Text
            cmd.Parameters.Add("@cltst", SqlDbType.Int).Value = txtcltst.Text
            cmd.Parameters.Add("@hmwrk", SqlDbType.Int).Value = txthmwrk.Text
            cmd.Parameters.Add("@exmhet", SqlDbType.Int).Value = txtexmhet.Text
            cmd.Parameters.Add("@contsheet", SqlDbType.Int).Value = txtcontsheet.Text
            cmd.Parameters.Add("@indrep", SqlDbType.Int).Value = txtindrep.Text
            cmd.Parameters.Add("@repbycls", SqlDbType.Int).Value = txtrepbycls.Text
            cmd.Parameters.Add("@chkuploa", SqlDbType.Int).Value = txtuploa.Text
            cmd.Parameters.Add("@cmtent", SqlDbType.Int).Value = txtcmtent.Text

            cmd.Parameters.Add("@stfform", SqlDbType.Int).Value = txtstfform.Text
            cmd.Parameters.Add("@stflist", SqlDbType.Int).Value = txtstflist.Text
            cmd.Parameters.Add("@snit", SqlDbType.Int).Value = txtssnit.Text
            cmd.Parameters.Add("@income", SqlDbType.Int).Value = txtincome.Text
            cmd.Parameters.Add("@prlpros", SqlDbType.Int).Value = txtprlpros.Text
            cmd.Parameters.Add("@payroll", SqlDbType.Int).Value = txtpayroll.Text
            cmd.Parameters.Add("@slip", SqlDbType.Int).Value = txtslip.Text

            cmd.Parameters.Add("@chtacc", SqlDbType.Int).Value = txtchtacc.Text
            cmd.Parameters.Add("@cntlist", SqlDbType.Int).Value = txtcntlist.Text
            cmd.Parameters.Add("@schfeestam", SqlDbType.Int).Value = txtschfeestam.Text
            cmd.Parameters.Add("@jrnent", SqlDbType.Int).Value = txtjrnent.Text
            cmd.Parameters.Add("@recschpay", SqlDbType.Int).Value = txtrecschpay.Text
            cmd.Parameters.Add("@recadmpay", SqlDbType.Int).Value = txtrecadmpay.Text
            cmd.Parameters.Add("@schfeelst", SqlDbType.Int).Value = txtschfeelst.Text
            cmd.Parameters.Add("@deblst", SqlDbType.Int).Value = txtdeblst.Text
            cmd.Parameters.Add("@paybills", SqlDbType.Int).Value = txtpaybills.Text
            cmd.Parameters.Add("@editschfee", SqlDbType.Int).Value = txteditschfee.Text

            cmd.Parameters.Add("@setup", SqlDbType.Int).Value = txtsetup.Text
            cmd.Parameters.Add("@depsit", SqlDbType.Int).Value = txtdepsit.Text
            cmd.Parameters.Add("@wtdrw", SqlDbType.Int).Value = txtwtdrw.Text
            cmd.Parameters.Add("@trnsf", SqlDbType.Int).Value = txttrnsf.Text
            cmd.Parameters.Add("@bnkstam", SqlDbType.Int).Value = txtbnkstam.Text

            cmd.Parameters.Add("@tb", SqlDbType.Int).Value = txttb.Text
            cmd.Parameters.Add("@pl", SqlDbType.Int).Value = txtpl.Text
            cmd.Parameters.Add("@bls", SqlDbType.Int).Value = txtbls.Text
            cmd.Parameters.Add("@chflw", SqlDbType.Int).Value = txtchflw.Text
            cmd.Parameters.Add("@chngequ", SqlDbType.Int).Value = txtchngequ.Text

            cmd.Parameters.Add("@schinfo", SqlDbType.Int).Value = txtschinfo.Text
            cmd.Parameters.Add("@msgcnt", SqlDbType.Int).Value = txtmsgcnt.Text
            cmd.Parameters.Add("@acadar", SqlDbType.Int).Value = txtacadar.Text
            cmd.Parameters.Add("@adfeesbill", SqlDbType.Int).Value = txtadfeesbill.Text
            cmd.Parameters.Add("@lnrares", SqlDbType.Int).Value = txtlnrares.Text

            cmd.Parameters.Add("@adclas", SqlDbType.Int).Value = txtadclas.Text
            cmd.Parameters.Add("@edtcurclass", SqlDbType.Int).Value = txtedtcurclass.Text
            cmd.Parameters.Add("@adsubjt", SqlDbType.Int).Value = txtadsubjt.Text
            cmd.Parameters.Add("@userlst", SqlDbType.Int).Value = txtuserlst.Text
            cmd.Parameters.Add("@acscontrl", SqlDbType.Int).Value = txtacscontrl.Text

            cmd.Parameters.Add("@promo", SqlDbType.Int).Value = txtpromo.Text
            cmd.Parameters.Add("@active", SqlDbType.Int).Value = txtactive.Text
            cmd.Parameters.Add("@class", SqlDbType.VarChar).Value = ddlclass.Text
            cmd.Parameters.Add("@pages", SqlDbType.VarChar).Value = txtpage.Text

            cmd.Connection = cnn
            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

                Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                Dim script = String.Format("alert({0});", message)
                ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "Record did not insert error has occur", script, True)

            Finally
                cnn.Close()
                cnn.Dispose()
            End Try


        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "Error", script, True)

        End Try

        Response.Redirect("User_Control.aspx")

    End Sub

    Protected Sub UpdatetUserContrl()

        Try

            Dim connetionString As String = sCon
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdatetUserContrl"}
            cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = ddlstaff.Text
            cmd.Parameters.Add("@regform", SqlDbType.Int).Value = txtregs.Text
            cmd.Parameters.Add("@newpay", SqlDbType.Int).Value = txtnewadmi.Text
            cmd.Parameters.Add("@stulist", SqlDbType.Int).Value = txtstudlist.Text
            cmd.Parameters.Add("@listbyclass", SqlDbType.Int).Value = txtstudlistbyclass.Text
            cmd.Parameters.Add("@listbyyyear", SqlDbType.Int).Value = txtadmianayr.Text
            cmd.Parameters.Add("@listbyterm", SqlDbType.Int).Value = txtadmibyterm.Text
            cmd.Parameters.Add("@listbyyrs", SqlDbType.Int).Value = txtadmilistbyyr.Text
            cmd.Parameters.Add("@editphoto", SqlDbType.Int).Value = txtphoto.Text

            cmd.Parameters.Add("@attendance", SqlDbType.VarChar).Value = txtattendance.Text
            cmd.Parameters.Add("@clsass", SqlDbType.Int).Value = txtclsass.Text
            cmd.Parameters.Add("@cltst", SqlDbType.Int).Value = txtcltst.Text
            cmd.Parameters.Add("@hmwrk", SqlDbType.Int).Value = txthmwrk.Text
            cmd.Parameters.Add("@exmhet", SqlDbType.Int).Value = txtexmhet.Text
            cmd.Parameters.Add("@contsheet", SqlDbType.Int).Value = txtcontsheet.Text
            cmd.Parameters.Add("@indrep", SqlDbType.Int).Value = txtindrep.Text
            cmd.Parameters.Add("@repbycls", SqlDbType.Int).Value = txtrepbycls.Text
            cmd.Parameters.Add("@chkuploa", SqlDbType.Int).Value = txtuploa.Text
            cmd.Parameters.Add("@cmtent", SqlDbType.Int).Value = txtcmtent.Text

            cmd.Parameters.Add("@stfform", SqlDbType.Int).Value = txtstfform.Text
            cmd.Parameters.Add("@stflist", SqlDbType.Int).Value = txtstflist.Text
            cmd.Parameters.Add("@snit", SqlDbType.Int).Value = txtssnit.Text
            cmd.Parameters.Add("@income", SqlDbType.Int).Value = txtincome.Text
            cmd.Parameters.Add("@prlpros", SqlDbType.Int).Value = txtprlpros.Text
            cmd.Parameters.Add("@payroll", SqlDbType.Int).Value = txtpayroll.Text
            cmd.Parameters.Add("@slip", SqlDbType.Int).Value = txtslip.Text

            cmd.Parameters.Add("@chtacc", SqlDbType.Int).Value = txtchtacc.Text
            cmd.Parameters.Add("@cntlist", SqlDbType.Int).Value = txtcntlist.Text
            cmd.Parameters.Add("@schfeestam", SqlDbType.Int).Value = txtschfeestam.Text
            cmd.Parameters.Add("@jrnent", SqlDbType.Int).Value = txtjrnent.Text
            cmd.Parameters.Add("@recschpay", SqlDbType.Int).Value = txtrecschpay.Text
            cmd.Parameters.Add("@recadmpay", SqlDbType.Int).Value = txtrecadmpay.Text
            cmd.Parameters.Add("@schfeelst", SqlDbType.Int).Value = txtschfeelst.Text
            cmd.Parameters.Add("@deblst", SqlDbType.Int).Value = txtdeblst.Text
            cmd.Parameters.Add("@paybills", SqlDbType.Int).Value = txtpaybills.Text
            cmd.Parameters.Add("@editschfee", SqlDbType.Int).Value = txteditschfee.Text

            cmd.Parameters.Add("@setup", SqlDbType.Int).Value = txtsetup.Text
            cmd.Parameters.Add("@depsit", SqlDbType.Int).Value = txtdepsit.Text
            cmd.Parameters.Add("@wtdrw", SqlDbType.Int).Value = txtwtdrw.Text
            cmd.Parameters.Add("@trnsf", SqlDbType.Int).Value = txttrnsf.Text
            cmd.Parameters.Add("@bnkstam", SqlDbType.Int).Value = txtbnkstam.Text

            cmd.Parameters.Add("@tb", SqlDbType.Int).Value = txttb.Text
            cmd.Parameters.Add("@pl", SqlDbType.Int).Value = txtpl.Text
            cmd.Parameters.Add("@bls", SqlDbType.Int).Value = txtbls.Text
            cmd.Parameters.Add("@chflw", SqlDbType.Int).Value = txtchflw.Text
            cmd.Parameters.Add("@chngequ", SqlDbType.Int).Value = txtchngequ.Text

            cmd.Parameters.Add("@schinfo", SqlDbType.Int).Value = txtschinfo.Text
            cmd.Parameters.Add("@msgcnt", SqlDbType.Int).Value = txtmsgcnt.Text
            cmd.Parameters.Add("@acadar", SqlDbType.Int).Value = txtacadar.Text
            cmd.Parameters.Add("@adfeesbill", SqlDbType.Int).Value = txtadfeesbill.Text
            cmd.Parameters.Add("@lnrares", SqlDbType.Int).Value = txtlnrares.Text

            cmd.Parameters.Add("@adclas", SqlDbType.Int).Value = txtadclas.Text
            cmd.Parameters.Add("@edtcurclass", SqlDbType.Int).Value = txtedtcurclass.Text
            cmd.Parameters.Add("@adsubjt", SqlDbType.Int).Value = txtadsubjt.Text
            cmd.Parameters.Add("@userlst", SqlDbType.Int).Value = txtuserlst.Text
            cmd.Parameters.Add("@acscontrl", SqlDbType.Int).Value = txtacscontrl.Text

            cmd.Parameters.Add("@promo", SqlDbType.Int).Value = txtpromo.Text
            cmd.Parameters.Add("@active", SqlDbType.Int).Value = txtactive.Text
            cmd.Parameters.Add("@class", SqlDbType.VarChar).Value = ddlclass.Text
            cmd.Parameters.Add("@pages", SqlDbType.VarChar).Value = txtpage.Text
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = txtid.Value

            cmd.Connection = cnn
            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

                Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
                Dim script = String.Format("alert({0});", message)
                ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "Record did not insert error has occur", script, True)

            Finally
                cnn.Close()
                cnn.Dispose()
            End Try


        Catch ex As Exception

            Dim message = New JavaScriptSerializer().Serialize(ex.Message.ToString())
            Dim script = String.Format("alert({0});", message)
            ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), "Error", script, True)

        End Try

        Response.Redirect("User_Control.aspx")

    End Sub



    Protected Sub ddlstaff_SelectedIndexChanged(sender As Object, e As EventArgs)
        GetStaffID()
    End Sub

End Class