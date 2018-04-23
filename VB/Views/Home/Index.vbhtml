@Code
	ViewBag.Title = "How to perform GridView batch updating using different editors in the DataItem template "
End Code
<h2>@ViewBag.Message</h2>
<div style="width: 400px">
	@Html.Action("GridViewPartial")
	@Html.DevExpress().Button(Sub(s)
							   s.Name = "customButton"
							   s.UseSubmitBehavior = False
							   s.ClientSideEvents.Click = String.Format("function (s, e) {{ OnClick('{0}'); }}", Url.Action("UpdateValue", "Home", Nothing))
						   End Sub).GetHtml()
	<div class="status">
		AJAX status
	</div>
</div>
