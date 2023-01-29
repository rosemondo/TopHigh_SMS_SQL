Public Class index2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1))
            Response.Cache.SetNoStore()


            If TextBox1.Text = String.Empty Then

                Response.Write("<script type=""text/javascript"">alert(""Session time out.!!! Login."");</script")

                Response.Redirect("~/index.aspx")

            End If

        End If


    End Sub

End Class