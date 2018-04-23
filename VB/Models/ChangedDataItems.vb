Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace Q329588.Models
	Public Class ChangedDataItems
		Private privatekey As Int32
		Public Property key() As Int32
			Get
				Return privatekey
			End Get
			Set(ByVal value As Int32)
				privatekey = value
			End Set
		End Property
		Private privatefield As String
		Public Property field() As String
			Get
				Return privatefield
			End Get
			Set(ByVal value As String)
				privatefield = value
			End Set
		End Property
		Private privatevalue As String
		Public Property value() As String
			Get
				Return privatevalue
			End Get
			Set(ByVal value As String)
				privatevalue = value
			End Set
		End Property
	End Class
End Namespace