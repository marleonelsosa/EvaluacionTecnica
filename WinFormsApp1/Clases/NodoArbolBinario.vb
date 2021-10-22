Public Class NodoArbolBinario
    Protected Property Valor As Integer
    'Protected Property NodoPadre As NodoArbolBinario
    Protected Property NodoIzquierdo As NodoArbolBinario
    Protected Property NodoDerecho As NodoArbolBinario

#Region "Constructores"
    Public Sub New(valor As Integer)
        SetValor(valor)
    End Sub

    Public Sub New()
        Me.Valor = Nothing
    End Sub
#End Region

    Public Function EsHoja() As Boolean
        Return (Me.NodoIzquierdo Is Nothing And Me.NodoDerecho Is Nothing)
    End Function

#Region "GETTERS & SETTERS"
    Public Function GetNodoIzquierdo() As NodoArbolBinario
        Return Me.NodoIzquierdo
    End Function

    Public Function GetNodoDerecho() As NodoArbolBinario
        Return Me.NodoDerecho
    End Function

    Public Function GetPadre() As NodoArbolBinario
        Return Me.NodoIzquierdo
    End Function

    Public Function GetValor() As Integer
        Try
            Return Me.Valor
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub SetValor(valor As Integer)
        Try
            Me.Valor = valor
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetValorNodoIzquierdo(valor As Integer)
        Me.NodoIzquierdo.SetValor(valor)
    End Sub

    Public Sub SetValorNodoDerecho(valor As Integer)
        Me.NodoDerecho.SetValor(valor)
    End Sub

    Public Sub SetNodoIzquierdo(nodo As NodoArbolBinario)
        Me.NodoIzquierdo = nodo
    End Sub

    Public Sub SetNodoDerecho(nodo As NodoArbolBinario)
        Me.NodoDerecho = nodo
    End Sub

#End Region
End Class
