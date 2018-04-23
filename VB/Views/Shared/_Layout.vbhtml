<!DOCTYPE HTML>
<html>
<head>
    <title>@ViewBag.Title</title>
    @Html.DevExpress().GetStyleSheets(New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout}, _
                                      New StyleSheet With {.ExtensionSuite = ExtensionSuite.GridView}, _
                                      New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors} _
                                     )
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
    @Html.DevExpress().GetScripts(New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout}, _
                                  New Script With {.ExtensionSuite = ExtensionSuite.GridView}, _
                                  New Script With {.ExtensionSuite = ExtensionSuite.Editors} _
                                 )
    <script src="@Url.Content("~/Scripts/Script.js")" type="text/javascript"></script>								 
    <style type="text/css">
        .status
        {
            border: 1px solid #008080;
            background-color: #99FF99;
            text-align: center;
            padding: 5px 10px;
        }
    </style>
</head>
<body>
    @RenderBody()
</body>
</html>
