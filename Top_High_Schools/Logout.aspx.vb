Public Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1))
        Response.Cache.SetNoStore()


        If TextBox1.Text = String.Empty Then

            Response.Write("<script type=""text/javascript"">alert(""Session time out.!!! Login."");</script")

            Response.Redirect("~/index2.aspx")

        End If


    End Sub

End Class