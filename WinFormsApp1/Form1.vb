Public Class Form1

    'Para cada problema, explicar el algoritmo que usaría para resolverlo en el lenguaje de programación de  su preferencia o en pseudocódigo.
    'Sintaxis perfecta no es importante, siempre y cuando se logre entender  el procedimiento y no se recurran a funciones sin explicar que estén directamente
    'relacionadas con el  problema que se pide resolver. 
    'Para aquellos problemas con entrada/salida se puede asumir el formato de entrada que se desee y elegir el  formato de salida también. 
    '1) Explique cómo encontrar el mayor elemento de un array de enteros. 
    'Ej: para el siguiente array (5 8 0 -10 44 89 1 3 7 77 12 -3 4) el programa debería devolver: 89 

    Public Function MayorEnLista(array As Array) As Integer
        Try
            Dim mayor As Integer = array(0) 'Me quedo con el primer elemento del Array
            For Each numero In array
                If numero > mayor Then
                    mayor = numero
                End If
            Next

            Return mayor
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim array = New Integer() {5, 8, 0, -10, 44, 89, 1, 3, 7, 77, 12, -3, 4}
        Dim mayor = MayorEnLista(array)
        Console.WriteLine(mayor)
    End Sub

    '2) Dado un array de enteros, hacer una función que indique que rangos de números consecutivos dan  como resultado la cantidad que se le pasa como parámetro: 
    'Ej: array=(6,7,5,4,3,1,2,3,5,6,7,9,0,0,1,2,4,1,2,3,5,1,2) 
    ' sumar(13)
    'Los elementos entre (0,1) suman 13
    'Los elementos entre (2,5) suman 13
    'Los elementos entre (3,7) suman 13
    'Los elementos entre (9,10) suman 13
    'Los elementos entre (12,19) suman 13
    'Los elementos entre (13,19) suman 13
    'Los elementos entre (14,19) suman 13
    'Los elementos entre (18,22) suman 13

    Public Sub BuscarNumeroConSumatoriaEnArray(array As Array, numeroResultado As Integer)
        Try
            Dim indiceHasta As Integer
            For i = 0 To array.Length - 1
                indiceHasta = SumatoriaIgual(array, i, numeroResultado)
                If indiceHasta <> -1 Then
                    Console.WriteLine($"Los elementos entre ({i},{indiceHasta}) suman {numeroResultado}")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function SumatoriaIgual(array As Array, indiceDesde As Integer, numeroResultado As Integer) As Integer 'Devuelve el indice final en donde la sumatoria es igual al numeroResultado pasado como parametro
        Try
            Dim sumatoria = 0
            Dim indiceInvalido = -1
            For i = indiceDesde To array.Length - 1
                sumatoria += array(i)
                If sumatoria = numeroResultado Then
                    Return i 'Devuelvo el indice final, donde se cumple la condicion
                ElseIf sumatoria > numeroResultado Then
                    Return indiceInvalido 'Si la sumatoria supera al numeroResultado devuelvo un indice negativo inexistente (-1)
                End If
            Next
            Return indiceInvalido 'Si la sumatoria no supera al numeroResultado devuelvo un indice negativo inexistente (-1)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim array = New Integer() {6, 7, 5, 4, 3, 1, 2, 3, 5, 6, 7, 9, 0, 0, 1, 2, 4, 1, 2, 3, 5, 1, 2}
        BuscarNumeroConSumatoriaEnArray(array, 13)
    End Sub

    '3) Dada una lista sencillamente enlazada, explicar cómo obtener el elemento del medio. En caso de tener  una cantidad de elementos par, puede ser cualquiera
    'de los dos. Si usa un método que devuelve el  tamaño de la lista debe definirlo. 
    'Ej: Arbol -> Casa -> Ruta Resultado: Casa 
    ' Pedro -> Juan -> Jose -> Marcos
    ' Resultado: Juan o Jose, ambos válidos. 

    Public Function DevolverElementoDelMedio(listaEnlazada As LinkedList(Of String)) As String
        Try
            Dim largo = listaEnlazada.Count
            Dim medio = CalcularIndiceDelMedio(largo)
            Dim ret = listaEnlazada(medio).ToString
            Return ret
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function CalcularIndiceDelMedio(numero As Integer) As Object
        Try
            Return numero \ 2 'Si el numero es PAR devuelvo la mitad
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ll As New LinkedList(Of String)
        ll.AddLast("Marcos")
        ll.AddLast("Jose")
        ll.AddLast("martin")
        ll.AddLast("leonel")
        ll.AddLast("Juan")
        ll.AddLast("Pedro")
        '(tail - ultimo) Pedro -> Juan -> Jose -> Marcos (header - primero)
        Dim resultado As String = DevolverElementoDelMedio(ll)

        Console.WriteLine(resultado)
    End Sub

    '4) Un palíndromo es una palabra o frase que se lee igual al derecho que al revés. Hacer una función que  determine si una palabra o frase es un palíndromo. 
    'Ej: es_palindromo("NEUQUEN") => TRUE 
    'es_palindromo("SANTA FE") => FALSE

    Public Function EsPalindromo(palabra As String) As Boolean
        Dim palabraInvertida = InvertirPalabra(palabra)
        For i = 0 To palabra.Length - 1
            If palabra(i) <> palabraInvertida(i) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function InvertirPalabra(palabra As String) As String
        Dim ret = String.Empty
        For i = 0 To palabra.Length - 1
            ret = palabra(i) + ret
        Next
        Return ret
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim verdadero = EsPalindromo("NEUQUEN")
        Dim falso = EsPalindromo("PALINDROMO")
    End Sub

    '5) Explique cómo mostrar todos los elementos, ordenados de menor a mayor, de un árbol binario  ordenado de enteros. 
    'Ej:
    '17 
    '9 19  
    '6 
    '1 7 
    'Resultado: 1 6 7 9 17 19 21 
    '21 

    Public Sub Ejercicio5()
        'CREO EL ARBOL BINARIO DEL EJERCICIO 5
        Dim arbol As New ArbolBinario(17)
        arbol.Agregar(9)
        arbol.Agregar(19)
        arbol.Agregar(6)
        arbol.Agregar(21)
        arbol.Agregar(1)
        arbol.Agregar(7)

        Dim lista = arbol.OrdenarArbolBinario()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Ejercicio5()
    End Sub

    '6) Hay dos archivos de texto donde cada línea tiene solo dos elementos: número de contrato y fecha.  Ambos archivos están ordenados por contrato y fecha.. 
    'El primer archivo puede considerarse el estado actual, y el segundo los cambios requeridos. Explique cómo hacer un programa que escriba un nuevo archivo combinando ambos, dando  precedencia a las fechas que se encuentran en el segundo archivo si el contrato está en ambos. 
    'Ej: 
    'Actual Cambios Resultado 

    'Contrato 	Fecha
    '100100  20140301 
    '100100  20140401 
    '100100  20140501 
    '100200  20130110 
    '100200  20130410 
    '100200  20130710 
    '100300  20140615 
    '100300  20140915 
    '100300  20141215 


    'Contrato 	Fecha
    '100150  20130301 
    '100150  20140301 
    '100150  20150301 
    '100200  20130112 
    '100200  20130412 
    '100200  20130712 


    'Contrato 	Fecha
    '100100  20140301
    '100100  20140401
    '100100  20140501
    '100150  20130301
    '100150  20140301
    '100150  20150301
    '100200  20130112
    '100200  20130412
    '100200  20130712
    '100300  20140615
    '100300  20140915
    '100300  20141215


    '7) Dado un archivo con líneas de tres campos, vendedor, fecha y cantidad vendida, explique cómo haría  un programa que genere un archivo de salida con los mismos primeros tres campos y agregando un  campo más con la cantidad total vendida correspondiente al vendedor. 
    'Ej: 
    'Entrada Salida  

    'Vendedor 	Fecha 	Cantidad 
    'Juan 	20140102 	10 
    'Juan 	20140105 	20 
    'Juan 	20140205 	12 
    'Juan 	20140207 	6 
    'Juan 	20140306 	9 
    'Pedro 	20140112 	11 
    'Pedro 	20140203 	16 
    'Pedro 	20140221 	20 
    'Pedro 	20140310 	18 
    'Jose 	20140210 	30 


    'Vendedor 	Fecha 	Cantidad 	TotalMes
    'Juan 	20140102 	10 	57
    'Juan 	20140105 	20 	57
    'Juan 	20140205 	12 	57
    'Juan 	20140207 	6 	57
    'Juan 	20140306 	9 	57
    'Pedro 	20140112 	11 	65
    'Pedro 	20140203 	16 	65
    'Pedro 	20140221 	20 	65
    'Pedro 	20140310 	18 	65
    'Jose 	20140210 	30 	30


    'El archivo de entrada se encuentra ya ordenado por vendedor y fecha, pero debe considerarse que es  demasiado extenso para ser leído a una estructura de memoria en su totalidad por haber una gran  cantidad de vendedores distintos. Sin embargo, las ventas de un vendedor dado son de cantidad  acotada.
    '8) Una matriz de caracteres de N x M representa un mapa donde el valor ' ‘ (espacio) indica terreno libre  y el valor ‘x’ indica un obstáculo. Explique cómo haría un programa que indique las coordenadas de un  camino que va desde la posición (0,0) hasta cualquier casillero en la última fila. 
    'Ej:

    '0   1 	2 	3 
    '0               
    '1   x 	x 		x 
    '2               
    '3           x	
    '4               

    'Resultado valido :  (0,0) (0,1) (0,2) (1,2) (2, 2) (2, 3) (3, 3) (4, 3) Resultado valido: (0,0) (0,1) (0,2) (1,2) (2, 2) (2, 1) (3, 1) (4, 1) 

End Class