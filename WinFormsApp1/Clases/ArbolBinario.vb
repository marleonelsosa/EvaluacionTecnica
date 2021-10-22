Public Class ArbolBinario
    Protected Property Raiz As NodoArbolBinario

    Public Sub New(raiz As NodoArbolBinario)
        Me.Raiz = raiz
    End Sub

    Public Sub New(valor As Integer)
        Me.Raiz = New NodoArbolBinario(valor)
    End Sub

    Public Sub New()
        Me.Raiz = Nothing
    End Sub

    Public Sub Agregar(valor As Integer)
        If valor = Me.Raiz.GetValor Then
            Exit Sub
        ElseIf valor < Me.Raiz.GetValor Then 'lado izquierdo, menor que el nodo padre
            AgregarRecursivo(Me.Raiz.GetNodoIzquierdo, valor)
        ElseIf valor > Me.Raiz.GetValor Then 'lado derecho, mayor que el nodo padre
            AgregarRecursivo(Me.Raiz.GetNodoDerecho, valor)
        End If
    End Sub

    Private Function AgregarRecursivo(nodo As NodoArbolBinario, valor As Integer) As Boolean
        If nodo = Nothing Then
            nodo.SetValor(valor)
        ElseIf nodo.GetValor = valor Then 'Caso Base: ya existe ese valor en el arbol binario
            Return False
        ElseIf nodo.GetValor > valor Then 'lado izquierdo, menor que el nodo padre
            Return AgregarRecursivo(Me.Raiz.GetNodoIzquierdo, valor)
        ElseIf nodo.GetValor > valor Then 'lado derecho, mayor que el nodo padre
            Return AgregarRecursivo(Me.Raiz.GetNodoDerecho, valor)
        End If
    End Function

    Public Function OrdenarArbolBinario() As List(Of Integer)
        Throw New NotImplementedException
    End Function

#Region "GETTERS & SETTERS"
    Public Function GetRaiz() As NodoArbolBinario
        Return Me.Raiz
    End Function

    Public Sub SetRaiz(valor As Integer)
        Me.Raiz.SetValor(valor)
    End Sub
#End Region
End Class
