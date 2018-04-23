Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports Example.Models
Imports System.Reflection
Imports System.ComponentModel
Imports Q329588.Models

Namespace Example.Controllers
	Public Class HomeController
		Inherits Controller
		Private SessionKey As String = "Some key"

		Public Function Index() As ActionResult
			ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!"

			Return View()
		End Function

		Public Function GridViewPartial() As ActionResult
			Return PartialView("GridViewPartial", GetList)
		End Function

		Public Function UpdateValue(ByVal changedValues() As ChangedDataItems) As ActionResult
			' some delay 
			System.Threading.Thread.Sleep(1000)

			Dim status As String = Nothing
			For Each dataItem As ChangedDataItems In changedValues
				Dim item As MyItem = GetList.First(Function(i) i.Id = dataItem.key)

				' some way to set a propery 
				Dim info As PropertyInfo = item.GetType().GetProperty(dataItem.field, BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.SetProperty)


				If info.CanWrite Then
					info.SetValue(item, TypeDescriptor.GetConverter(info.PropertyType).ConvertFromString(dataItem.value), Nothing)
				Else
					status = "Updating cannot be performed over a readonly field"
					Exit For
				End If


			Next dataItem
			If status Is Nothing Then
				status = "All fields successfully updated"
			End If
			Return Content(status)
		End Function

		Public Property GetList() As IList(Of MyItem)
			Get
				Dim itemList As List(Of MyItem) = Nothing

				If Session(SessionKey) Is Nothing Then
					itemList = New List(Of MyItem)(New MyItem() {New MyItem With {.Id = 1, .Text = "Text1", .Item = 1}, New MyItem With {.Id = 2, .Text = "Text2", .Item = 2}, New MyItem With {.Id = 3, .Text = "Text3", .Item = 1}, New MyItem With {.Id = 4, .Text = "Text4", .Item = 2}})

					Session(SessionKey) = itemList
				End If

				Return CType(Session(SessionKey), IList(Of MyItem))
			End Get
			Set(ByVal value As IList(Of MyItem))
				Session(SessionKey) = value
			End Set
		End Property
	End Class
End Namespace
