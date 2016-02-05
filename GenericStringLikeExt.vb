'Author: Cameron Block
'GenericStringLikeExt.vb
'Purpose: To create a generic helper class for getting 'String Like' functionality from other sources, for example StringBuilder's, Stream's, etc. 

Option Strict Off

Imports System.IO
Imports System.Runtime.CompilerServices 'Compiler Services required for extension methods
Imports System.Text

Module GenericStringOpsExt
    ''' <summary>
    ''' Determines the index of the string 'value' in the collection 'str'. 'str' can be any object which supports either the length parameter, or count method formats. 
    ''' </summary>
    ''' <param name="collection">The collection to be searched. </param>
    ''' <param name="str">The string value to search for. </param>
    ''' <returns></returns>
    ''' <exception cref="ArgumentException">Argument str must be a string type. </exception>
    <Extension()>
    Public Function IndexOf(ByVal collection As Object, ByVal str As String) As Integer
        'sanity checks
        If (String.IsNullOrEmpty(str)) Then
            Throw New ArgumentNullException("Argument 'str' has been provided an empty string.")
        End If

        Dim i, j, startOfWord As Integer
        startOfWord = 0

        'don't specify type option strict off is essentially for dynamics in vb
        For i = 0 To GetCount(collection) - 1
            startOfWord = i
            For j = 0 To str.Length
                If (CharAt(collection, i) = str(j)) Then
                    i = i + 1
                    If (j = (str.Length - 1)) Then
                        Return startOfWord
                    End If
                Else
                    Exit For
                End If
            Next
        Next

        'return a default value
        Return -1
    End Function

    ''' <summary>
    ''' Finds the index of a string in the collection/stream/etc after a particular start value. 
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="str"></param>
    ''' <param name="start"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function IndexOf(ByVal collection As Object, ByVal str As String, ByVal start As Integer) As Integer
        'sanity checks
        If (String.IsNullOrEmpty(str)) Then
            Throw New ArgumentNullException("Argument 'str' has been provided an empty string.")
        End If

        If (Not (start >= 0 And start < GetCount(collection))) Then
            Throw New ArgumentOutOfRangeException("Argument 'start' must be within the bounds of the specified collection type.")
        End If

        Dim i, j, startOfWord As Integer
        startOfWord = 0

        'don't specify type option strict off is essentially for dynamics in vb
        For i = start To GetCount(collection) - 1
            startOfWord = i
            For j = 0 To str.Length
                Dim varOne As Char = CharAt(collection, i)
                Dim varTwo As Char = str(j)
                If (CharAt(collection, i) = str(j)) Then
                    i = i + 1
                    If (j = (str.Length - 1)) Then
                        Return startOfWord
                    End If
                Else
                    Exit For
                End If
            Next
        Next

        'return a default value
        Return -1
    End Function

    ''' <summary>
    ''' Determines whether the collection/Stream/etc contains a particular string value. 
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="str"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Contains(ByVal collection As Object, ByVal str As String) As Boolean
        If (String.IsNullOrEmpty(str)) Then
            Throw New ArgumentNullException("Argument 'str' has been provided an empty string.")
        End If

        Dim i, j As Integer

        For i = i To GetCount(collection) - 1
            For j = j To str.Length
                If (CharAt(collection, i) = str(j)) Then
                    If (j = str.Length - 1) Then
                        Return True
                    End If
                Else
                    Exit For
                End If
            Next
        Next

        Return False
    End Function

    ''' <summary>
    ''' Returns a sub string element of the specified collection/stream/etc starting at the specified index. 
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="start"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Substring(ByVal collection As Object, ByVal start As Integer) As String
        'sanity checks
        If (Not (start >= 0 And start < GetCount(collection))) Then
            Throw New ArgumentOutOfRangeException("Argument 'start' must be within the bounds of the specified collection type.")
        End If

        Dim str As New StringBuilder()

        'copy all specified characters to a string builder
        For i = start To GetCount(collection) - 1
            str.Append(CharAt(collection, i))
        Next

        Return str.ToString()

    End Function

    ''' <summary>
    ''' Returns a substring of the collection instance starting at the 'start' value, and ending after the value specified by 'length'. 
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="start"></param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Substring(ByVal collection As Object, ByVal start As Integer, ByVal length As Integer) As String
        'sanity checks
        If (Not (start >= 0 And start < GetCount(collection))) Then
            Throw New ArgumentOutOfRangeException("Argument 'start' must be within the bounds of the specified collection type.")
        End If

        If (Not (length > 0 And length < GetCount(collection)) And length + start > GetCount(collection)) Then
            Throw New ArgumentOutOfRangeException("Argument 'length' must be within the bounds of the specified collection type, and length added to start cannot land outside the bounds of the collection.")
        End If

        Dim str As New StringBuilder()

        'copy all specified characters to a string builder
        For i = start To length
            str.Append(CharAt(collection, i))
        Next

        Return str.ToString()
    End Function

    ''' <summary>
    ''' Gets the index of closest character in the character array 'any' contained in the collection. 
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="any"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function IndexOfAny(ByVal collection As Object, ByVal any As Char()) As Integer
        If (any.Length < 0) Then
            Throw New ArgumentException("Argument 'any' must have some delimiting elements.")
        End If

        Dim i, j As Integer

        'don't specify type option strict off is essentially for dynamics in vb
        For i = 0 To GetCount(collection) - 1
            For j = 0 To any.Length - 1
                If (CharAt(collection, i) = any(j)) Then
                    Return i
                End If
            Next
        Next

        'return a default value
        Return -1
    End Function

    ''' <summary>
    ''' Gets the next index of any of the specified characters of the collection object. 
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="any"></param>
    ''' <param name="startIndex"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function IndexOfAny(ByVal collection As Object, ByVal any As Char(), ByVal startIndex As Integer) As Integer
        'sanity checks
        If (any.Length < 0) Then
            Throw New ArgumentException("Argument 'any' must have some delimiting elements.")
        End If

        If (Not (startIndex >= 0 And startIndex < GetCount(collection))) Then
            Throw New ArgumentOutOfRangeException("Argument 'start' must be within the bounds of the specified collection type.")
        End If

        Dim i, j As Integer

        'don't specify type option strict off is essentially for dynamics in vb
        For i = startIndex To GetCount(collection) - 1
            For j = 0 To any.Length - 1
                If (CharAt(collection, i) = any(j)) Then
                    Return i
                End If
            Next
        Next

        'return a default value
        Return -1
    End Function

    ''' <summary>
    ''' A better split method, only has one token in memory at any given time. 
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="delims"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function NextSplit(ByVal collection As Object, ByVal delims As Char()) As IEnumerable(Of String)
        'sanity checks
        If (Not (delims.Length <= 0)) Then
            Throw New ArgumentException("Argument 'delims' was provided an empty array of characters.")
        End If

        Dim nextIndex As Integer = 0
        Dim lastIndex As Integer = 0

        'vb operator not equal is funny
        While (nextIndex <> -1)
            nextIndex = IndexOfAny(collection, delims, lastIndex)
            If (nextIndex <> -1) Then
                Yield Substring(collection, lastIndex, nextIndex - lastIndex)
                lastIndex = nextIndex + 1
            Else
                Yield Substring(collection, lastIndex)
            End If
        End While

    End Function

    ''' <summary>
    ''' A better split method, only has one token in memory at any given time. 
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="delims"></param>
    ''' <param name="startIndex"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function NextSplit(ByVal collection As Object, ByVal delims As Char(), ByVal startIndex As Integer) As IEnumerable(Of String)
        'sanity checks
        If (TypeOf delims IsNot Char()) Then
            Throw New ArgumentException("Argument 'delims' is supposed to be an array of characters.")
        End If

        If (Not (delims.Length <= 0)) Then
            Throw New ArgumentException("Argument 'delims' was provided an empty array of characters.")
        End If

        If (Not (startIndex >= 0 And startIndex < GetCount(collection))) Then
            Throw New ArgumentOutOfRangeException("Argument 'start' must be within the bounds of the specified collection type.")
        End If

        Dim nextIndex As Integer = 0
        Dim lastIndex As Integer = startIndex

        'vb operator not equal is funny
        While (nextIndex <> -1)
            nextIndex = IndexOfAny(collection, delims, lastIndex)
            If (nextIndex <> -1) Then
                Yield Substring(collection, lastIndex, nextIndex - lastIndex)
                lastIndex = nextIndex + 1
            Else
                Yield Substring(collection, lastIndex)
            End If
        End While

    End Function

    ''' <summary>
    ''' A split function which takes into account searches through a certain length of characters past start. 
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="delims"></param>
    ''' <param name="start"></param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function NextSplit(ByVal collection As Object, ByVal delims As Char(), ByVal start As Integer, ByVal length As Integer) As IEnumerable(Of String)
        'sanity checks
        If (Not (delims.Length <= 0)) Then
            Throw New ArgumentException("Argument 'delims' was provided an empty array of characters.")
        End If

        If (Not (start >= 0 And start < GetCount(collection))) Then
            Throw New ArgumentOutOfRangeException("Argument 'start' must be within the bounds of the specified collection type.")
        End If

        If (Not (length > 0 And length < GetCount(collection)) And length + start > GetCount(collection)) Then
            Throw New ArgumentOutOfRangeException("Argument 'length' must be within the bounds of the specified collection type, and cannot land outside the bounds of the collection.")
        End If

        Dim nextIndex As Integer = 0
        Dim lastIndex As Integer = start
        Dim limit As Integer = start + length

        'vb operator not equal is funny
        While (nextIndex <> -1)
            nextIndex = IndexOfAny(collection, delims, lastIndex)
            If (nextIndex <> -1) Then
                If (nextIndex < limit) Then
                    If (nextIndex <> -1) Then
                        Yield Substring(collection, lastIndex, nextIndex - lastIndex)
                        lastIndex = nextIndex + 1
                    Else
                        Yield Substring(collection, lastIndex)
                    End If
                End If
            Else
                Yield Substring(collection, lastIndex, limit - lastIndex)
                Exit While
            End If
        End While

    End Function

    ''' <summary>
    ''' Determines whether the collection ends with a given string of characters. 
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="str"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function EndsWith(ByVal collection As Object, ByVal str As String) As Boolean
        'sanity checks
        If (String.IsNullOrEmpty(str)) Then
            Throw New ArgumentNullException("Argument 'str' has been provided an empty string.")
        End If

        Dim i As Integer = GetCount(collection) - 1

        'the string str, smaller list of characters is used for counting
        For j = str.Length - 1 To 0 Step -1
            If (CharAt(collection, i) <> str(j)) Then
                Return False
            End If
            i = i - 1
        Next

        Return True

    End Function

    ''' <summary>
    ''' Returns the last index of a string in the collection. 
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="str"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function LastIndexOf(ByVal collection As Object, ByVal str As String) As Integer
        'sanity checks
        If (String.IsNullOrEmpty(str)) Then
            Throw New ArgumentNullException("Argument 'str' has been provided an empty string.")
        End If

        If (TypeOf str IsNot String) Then
            Throw New ArgumentException("Argument str must be a string type. ")
        End If

        Dim j As Integer = str.Length - 1

        For i = GetCount(collection) - 1 To 0 Step -1
            For j = str.Length - 1 To 0 Step -1
                If (CharAt(collection, i) = str(j)) Then
                    i = i - 1
                    If (j = 0) Then
                        Return i + 1
                    End If
                Else
                    Exit For
                End If
            Next
        Next

        'string not found
        Return -1
    End Function

    ''' <summary>
    ''' Returns the last index of a particular string 'str' in the given collection starting the search at 'startIndex' and moving twoard the beginning of the collection. 
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="str"></param>
    ''' <param name="startIndex"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function LastIndexOf(ByVal collection As Object, ByVal str As String, ByVal startIndex As Integer) As Integer
        'sanity checks
        If (String.IsNullOrEmpty(str)) Then
            Throw New ArgumentNullException("Argument 'str' has been provided an empty string.")
        End If

        If (Not (startIndex >= 0 And startIndex < GetCount(collection))) Then
            Throw New ArgumentOutOfRangeException("Argument 'start' must be within the bounds of the specified collection type.")
        End If

        Dim j As Integer = str.Length - 1

        For i = startIndex To 0 Step -1
            For j = str.Length - 1 To 0 Step -1
                If (CharAt(collection, i) = str(j)) Then
                    i = i - 1
                    If (j = 0) Then
                        Return i + 1
                    End If
                Else
                    Exit For
                End If
            Next
        Next

        'string not found
        Return -1
    End Function

    ''' <summary>
    ''' Split function for collection types. Splits according to the character array specified by delims. 
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="delims"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Split(ByVal collection As Object, ByVal delims As Char()) As String()
        NextSplit(collection, delims).ToArray()
    End Function

    ''' <summary>
    ''' Split function for collection types. Splits according to the character array specified by delims, has a start value, so preceding string can be skipped. 
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="delims"></param>
    ''' <param name="start"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Split(ByVal collection As Object, ByVal delims As Char(), ByVal start As Integer) As String()
        NextSplit(collection, delims, start).ToArray()
    End Function

    ''' <summary>
    ''' Split function for collection types. Splits according to the character array specified by delims, has a start value, so preceding string can be skipped. Also has a length cut off ability. 
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="delims"></param>
    ''' <param name="start"></param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Split(ByVal collection As Object, ByVal delims As Char(), ByVal start As Integer, ByVal length As Integer) As String()
        NextSplit(collection, delims, start, length).ToArray()
    End Function

    ''' <summary>
    ''' A layer of abstraction, for this module, allows us to get the 'count' of a few different class types
    ''' </summary>
    ''' <param name="collection">The collection, or StringBuilder, or List, etc.</param>
    ''' <returns></returns>
    Private Function GetCount(ByVal collection As Object) As Integer
        Dim ret As Integer
        Try
            ret = collection.Length
        Catch ex As MemberAccessException
            Try
                ret = collection.Count()
            Catch ex2 As Exception
                Throw
            End Try
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' Gets the character at a specified index. Has a custom implementation for Streams, needs updated if you want to add a custom class. 
    ''' </summary>
    ''' <param name="collection">The collection, or Stream, etc. Is essentially a dynamic. </param>
    ''' <param name="index">The index, must be an integer object</param>
    ''' <returns></returns>
    ''' <exception cref="ArgumentOutOfRangeException">Index was out of bounds. </exception>
    <Extension()>
    Public Function CharAt(ByVal collection As Object, ByVal index As Integer) As Char
        'sanity checks
        If (Not (index >= 0 And index < GetCount(collection))) Then
            Throw New ArgumentOutOfRangeException(String.Format("Index {0} was out of bounds. ", index))
        End If

        If (TypeOf (collection) Is Stream) Then
            Return StreamCharAt(CType(collection, Stream), index)
        Else
            Return collection.CharAt(index)
        End If

    End Function

    ''' <summary>
    ''' The implementation of the Stream CharAt function. 
    ''' </summary>
    ''' <param name="stream">The Stream to get the character from. </param>
    ''' <param name="index">The index in the stream to retrieve the character. </param>
    ''' <returns></returns>
    Private Function StreamCharAt(ByVal stream As Stream, ByVal index As Integer) As Char
        'sanity checks
        If (Not (index >= 0 And index < GetCount(stream))) Then
            Throw New ArgumentOutOfRangeException(String.Format("Index {0} was out of bounds. ", index))
        End If

        Dim tempPos As Integer = stream.Position

        stream.Position = index

        Dim ret As Char = ChrW(stream.ReadByte())

        'reset the stream position
        stream.Position = tempPos

        Return ret

    End Function

End Module