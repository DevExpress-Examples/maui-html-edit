Imports System.Globalization
Imports DevExpress.Maui.HtmlEditor

Namespace HtmlEditToolbarCustomization

    Public Class EnumToBoolConverter
        Inherits IMarkupExtension
        Implements IValueConverter

        Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object
            Dim [Enum] As [not] = Nothing
            If CSharpImpl.__Assign([Enum], TryCast(value, [not])) IsNot Nothing Then valueEnum
            If True Then
                Return False
            End If

            Dim parameterString As String = Nothing
            If CSharpImpl.__Assign(parameterString, TryCast(parameter, String)) IsNot Nothing Then
                Dim enumType As Type = value.[GetType]()
                Dim enumValue As [Enum] = CType([Enum].Parse(enumType, parameterString), [Enum])
                Return If([Enum].IsDefined(enumType, value), enumValue.Equals(value), valueEnum.HasFlag(enumValue))
            End If

            Dim parameterEnum As [Enum] = Nothing
            Return If(CSharpImpl.__Assign(parameterEnum, TryCast(parameter, [Enum])) IsNot Nothing, parameterEnum.Equals(valueEnum), False)
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object
            Return Binding.DoNothing
        End Function

        Public Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
            Return Me
        End Function

        Private Class CSharpImpl

            <System.Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class

    Public Class ColorToBoolConverter
        Inherits IMarkupExtension
        Implements IValueConverter

        Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object
            Dim color As Color = CType(parameter, Color)
            Dim valueColor As Color = CType(value, Color)
            Return [Object].Equals(color, valueColor)
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object
            Throw New NotSupportedException()
        End Function

        Public Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
            Return Me
        End Function
    End Class

    Public Class IntToBoolConverter
        Inherits IValueConverter

        Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object
            Dim intValue As Integer = Nothing, parameterString As String = Nothing
            If CSharpImpl.__Assign(parameterString, TryCast(parameter, String)) IsNot Nothing Then
                If Integer.TryParse(parameterString, intValue) Then
                    Return [Object].Equals(intValue, value)
                End If

                Return False
            Else
                Dim intValue As Integer = CInt(parameter)
                Dim valueInt As Integer = CInt(value)
                Return [Object].Equals(intValue, valueInt)
            End If
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object
            Return Nothing
        End Function

        Public Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
            Return Me
        End Function

        Private Class CSharpImpl

            <System.Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class

    Public Class LineHeightToBoolConverter
        Inherits IValueConverter

        Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object
            Dim intValue As Double = Nothing, parameterString As String = Nothing
            If CSharpImpl.__Assign(parameterString, TryCast(parameter, String)) IsNot Nothing Then
                Dim lineHeight As HtmlLineHeight = CType(value, HtmlLineHeight)
                If Double.TryParse(parameterString, intValue) Then
                    Return [Object].Equals(intValue, lineHeight.Value)
                End If

                Return False
            Else
                Dim parameterValue As Double = CDbl(parameter)
                Dim lineHeight As HtmlLineHeight = CType(value, HtmlLineHeight)
                Return [Object].Equals(parameterValue, lineHeight.Value)
            End If
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object
            Return Nothing
        End Function

        Public Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
            Return Me
        End Function

        Private Class CSharpImpl

            <System.Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
