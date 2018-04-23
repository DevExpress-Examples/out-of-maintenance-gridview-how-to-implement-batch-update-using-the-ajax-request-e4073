@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "grid"
                                settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}

                                settings.KeyFieldName = "Id"
                                settings.Width = 400

                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "Id"
                                                     End Sub)

                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "Text"
                                                         column.SetDataItemTemplateContent(Sub(c)
                                                                                               Html.DevExpress().TextBox(Sub(txtSettings)
                                                                                                                             txtSettings.Name = "txt" + c.KeyValue.ToString()
                                                                                                                             
                                                                                                                             txtSettings.Width = System.Web.UI.WebControls.Unit.Percentage(100)

                                                                                                                             txtSettings.Properties.ClientSideEvents.ValueChanged = String.Format("function (s, e) {{ OnValueChanged(s, '{0}', {1}, '{2}'); }}", c.Column.FieldName, c.KeyValue, Url.Action("UpdateValue", "Home", Nothing))
                                                                                                                         End Sub).Bind(DataBinder.Eval(c.DataItem, c.Column.FieldName)).Render()
                                                                                           End Sub)
                                                     End Sub)

                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "Item"
     
                                                         column.SetDataItemTemplateContent(Sub(c)
                                                                                               Html.DevExpress().ComboBox(Sub(cmbSettings)
                                                                                                                              cmbSettings.Name = "cmb" + c.KeyValue.ToString()
                                                                                                                              cmbSettings.Width = System.Web.UI.WebControls.Unit.Percentage(100)

                                                                                                                              cmbSettings.Properties.ValueType = GetType(Int32)
                                                                                                                              cmbSettings.Properties.Items.Add("Yes", 1)
                                                                                                                              cmbSettings.Properties.Items.Add("No", 2)

                                                                                                                              cmbSettings.Properties.ClientSideEvents.ValueChanged = String.Format("function (s, e) {{ OnValueChanged(s, '{0}', {1}, '{2}'); }}", c.Column.FieldName, c.KeyValue, Url.Action("UpdateValue", "Home", Nothing))
                                                                                                                          End Sub).Bind(DataBinder.Eval(c.DataItem, c.Column.FieldName)).Render()
                                                                                           End Sub)
                                                     End Sub)
                            End Sub).Bind(Model).GetHtml()
