Imports System.ComponentModel
Imports DevExpress.Maui.Core
Imports DevExpress.Maui.HtmlEditor
Imports FontSize = DevExpress.Maui.HtmlEditor.HtmlFontSize

Namespace HtmlEditToolbarCustomization

    Public Class TextFormatViewModel
        Inherits BindableBase
        Implements IHtmlOwner

        Private Shared ReadOnly Property PredefinedDefaultColors As Color() = New Color() {Color.FromRgb(&HfF, &HfF, &HfF), Color.FromRgb(&H00, &H00, &H00), Color.FromRgb(&H61, &H61, &H61), Color.FromRgb(&HC6, &H28, &H28), Color.FromRgb(&H6A, &H1B, &H9A), Color.FromRgb(&H15, &H65, &HC0), Color.FromRgb(&H17, &HC8, &HB3), Color.FromRgb(&H2E, &H7D, &H32), Color.FromRgb(&HF9, &HA8, &H25), Color.FromRgb(&H4E, &H34, &H2E)}

        Private Shared ReadOnly Property PredefinedColorTargets As List(Of ColorTarget) = New List(Of ColorTarget)() From {New ColorTarget() With {.DisplayName = HtmlEditLocalizer.GetString(HtmlEditStringId.TextSettings_FontColor), .ColorTargetType = ColorTargetType.Foreground}, New ColorTarget() With {.DisplayName = HtmlEditLocalizer.GetString(HtmlEditStringId.TextSettings_BackgroundColor), .ColorTargetType = ColorTargetType.Background}}

        Public Sub New(ByVal owner As HtmlEdit)
            SelectedColorTarget = Me.ColorTargets(0)
            Me.Owner = owner
            SetColorCommand = New Command(Of Color)(SetColor)
            SetFontSizeCommand = New Command(Of String)(SetFontSize)
        End Sub

        Public ReadOnly Property DefaultColors As Color()
            Get
                Return PredefinedDefaultColors
            End Get
        End Property

        Public ReadOnly Property ColorTargets As List(Of ColorTarget)
            Get
                Return PredefinedColorTargets
            End Get
        End Property

        Public Property Owner As HtmlEdit? Implements IHtmlOwner.Owner
            Get
                Return GetValue(Of HtmlEdit)()
            End Get

            Set(ByVal value As HtmlEdit?)
                SetValue(value, Function(ov, nv)
                    If ov IsNot Nothing Then OnDetachHtmlEdit(ov)
                    If nv IsNot Nothing Then OnAttachHtmlEdit(nv)
                End Function)
            End Set
        End Property

         ''' Cannot convert PropertyDeclarationSyntax, System.NotSupportedException: Specified method is not supported.
'''    at ICSharpCode.CodeConverter.VB.CommonConversions.ConvertAccessor(AccessorDeclarationSyntax node, Boolean& isIterator, Boolean isAutoImplementedProperty)
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.ConvertPropertyBlock(BasePropertyDeclarationSyntax node, SyntaxToken id, SyntaxTokenList modifiers, ParameterListSyntax parameterListSyntax, ArrowExpressionClauseSyntax arrowExpressionClauseSyntax, EqualsValueSyntax initializerOrNull)
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitPropertyDeclaration(PropertyDeclarationSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
''' 
'''     public int? FontSize {
'''         get => GetValue<int?>();
'''         set => SetValue(value, () => {
'''             if (this.Owner is not null)
'''                 Owner.SelectedTextFontSize = value == null ? HtmlFontSize.Empty : 
'''  Private Overloads Sub New(ByVal _ As value, ByVal _ As HtmlSizeUnit.Points)
        End Sub
    End Class ' TODO: Error SkippedTokensTrivia ')' ' TODO: Error SkippedTokensTrivia ';'
End Namespace

 ''' Cannot convert PropertyDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member)
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitPropertyDeclaration(PropertyDeclarationSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
''' 
'''     public Color Color {
'''         get => GetValue<Color>();
'''         set => SetValue(value, () => SetColor(value));
'''     }
''' 
'''   ''' Cannot convert PropertyDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member)
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitPropertyDeclaration(PropertyDeclarationSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
''' 
'''     public ColorTarget SelectedColorTarget {
'''         get => GetValue<ColorTarget>();
'''         set => SetValue(value, () => {
'''             UpdateColor();
'''         });
'''     }
''' 
'''   ''' Cannot convert PropertyDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member)
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitPropertyDeclaration(PropertyDeclarationSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
''' 
'''     public Command SetColorCommand { get; }
''' 
'''   ''' Cannot convert PropertyDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member)
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitPropertyDeclaration(PropertyDeclarationSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''     public Command SetFontSizeCommand { get; }
''' 
'''   ''' Cannot convert MethodDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member)
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitMethodDeclaration(MethodDeclarationSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
''' 
'''     void OnAttachHtmlEdit(HtmlEdit htmlEdit) {
'''         htmlEdit.PropertyChanged += OnHtmlEditPropertyChanged;
'''         if (!htmlEdit.SelectedTextFontSize.IsEmpty && htmlEdit.SelectedTextFontSize.Unit == HtmlSizeUnit.Points)
'''             DevExpress.Maui.HtmlEditor.HtmlFontSize = (int)htmlEdit.SelectedTextFontSize.Value;
'''         UpdateColor();
'''     }
''' 
'''   ''' Cannot convert MethodDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member)
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitMethodDeclaration(MethodDeclarationSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
''' 
'''     void OnDetachHtmlEdit(HtmlEdit htmlEdit) {
'''         htmlEdit.PropertyChanged -= OnHtmlEditPropertyChanged;
'''     }
''' 
'''   ''' Cannot convert MethodDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member)
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitMethodDeclaration(MethodDeclarationSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
''' 
'''     void UpdateColor() {
'''         if (Owner == null || SelectedColorTarget == null)
'''             return;
'''         Color = SelectedColorTarget.ColorTargetType == ColorTargetType.Background ? Owner.SelectedTextBackground : Owner.SelectedTextForeground;
'''     }
''' 
'''   ''' Cannot convert MethodDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member)
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitMethodDeclaration(MethodDeclarationSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
''' 
'''     void SetColor(Color color) {
'''         Color = color;
'''         if (Owner is null || SelectedColorTarget == null)
'''             return;
'''         if (SelectedColorTarget.ColorTargetType == ColorTargetType.Background) {
'''             Owner.SelectedTextBackground = color;
'''         } else {
'''             Owner.SelectedTextForeground = color;
'''         }
'''     }
''' 
'''   ''' Cannot convert MethodDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member)
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitMethodDeclaration(MethodDeclarationSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
''' 
'''     void SetFontSize(string fontSize) {
'''         DevExpress.Maui.HtmlEditor.HtmlFontSize = int.Parse(fontSize);
'''     }
''' 
'''   ''' Cannot convert MethodDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member)
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitMethodDeclaration(MethodDeclarationSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
''' 
'''     void OnHtmlEditPropertyChanged(object? sender, PropertyChangedEventArgs? e) {
'''         if (Owner is null)
'''             return;
'''         if (e?.PropertyName == nameof(HtmlEdit.SelectedTextFontSize)) {
'''             if (Owner != null && !Owner.SelectedTextFontSize.IsEmpty && Owner.SelectedTextFontSize.Unit == HtmlSizeUnit.Points)
'''                 DevExpress.Maui.HtmlEditor.HtmlFontSize = (int)(Owner?.SelectedTextFontSize.Value ?? 8);
'''         }
'''     }
''' 
'''  Public Class ColorTarget

    Public Property DisplayName As String?

    Public Property ColorTargetType As ColorTargetType
End Class

Public Enum ColorTargetType
    Background
    Foreground
End Enum ' TODO: Error SkippedTokensTrivia '}'

Public Interface IHtmlOwner

    Property Owner As HtmlEdit?

End Interface
