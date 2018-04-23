Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace Example.Models
	Public Class MyItem
		Private privateId As Int32
		Public Property Id() As Int32
			Get
				Return privateId
			End Get
			Set(ByVal value As Int32)
				privateId = value
			End Set
		End Property
		Private privateText As String
		Public Property Text() As String
			Get
				Return privateText
			End Get
			Set(ByVal value As String)
				privateText = value
			End Set
		End Property
		Private privateItem As Int32
		Public Property Item() As Int32
			Get
				Return privateItem
			End Get
			Set(ByVal value As Int32)
				privateItem = value
			End Set
		End Property
	End Class
End Namespace