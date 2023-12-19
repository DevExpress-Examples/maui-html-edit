Imports DevExpress.Maui.Controls
Imports DevExpress.Maui.HtmlEditor

Namespace HtmlEditToolbarCustomization

    Public Partial Class MainPage
        Inherits ContentPage

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Property TextFormatView As TextFormatView?

        Private Property AddImageView As EmbedImageSettingsView

        Private Property FontFamilyView As FontFamilySettingsView

        Private Async Sub OnButtonClicked(ByVal sender As Object, ByVal e As EventArgs)
            While True
                If Me.toolbar.SelectedPageName Is Nothing Then
                    Me.toolbar.SelectedPageName = "TextSettings"
                Else
                    Me.toolbar.SelectedPageName = Nothing
                End If

                Await Task.Delay(1000)
            End While
        End Sub

        Protected Overrides Function OnBackButtonPressed() As Boolean
            If Me.root.IsOpened Then
                __ = ResetToolbar()
                Return True
            End If

            Return MyBase.OnBackButtonPressed()
        End Function

        Private Sub OnShowFontFamilySettingsClicked(ByVal sender As Object, ByVal e As EventArgs)
            Dim vm As FontFamilySettingsViewModel = New(_, _)()
            Me.edit
            AddressOf NavigateToEditPage
            FontFamilyView = If(FontFamilyView, New FontFamilySettingsView())
            FontFamilyView.BindingContext = vm
            Dim page As ContentPage = New(_, _) With {.Content = FontFamilyView, .Title = HtmlEditLocalizer.GetString(HtmlEditStringId.SelectFontFamily)}
            page.ToolbarItems.Add(New ToolbarItem() With {.IconImageSource = "dxre_check", .Command = vm.ApplyCommand})
            Navigation.PushAsync(page).ContinueWith(Function(t) HideKeyboardOnAndroid())
        End Sub

        Private Sub OnShowEmbedImageSettingsClicked(ByVal sender As Object, ByVal e As EventArgs)
            Dim vm As EmbedImageSettingsViewModel = New(_, _)()
            Me.edit
            Function() CSharpImpl.__Assign(Me.root.IsOpened, False)
            AddImageView = If(AddImageView, New EmbedImageSettingsView())
            AddImageView.BindingContext = vm
            Me.root.KeyboardAreaContent = AddImageView
            Me.root.IsOpened = True
        End Sub

        Private Sub OnShowEmbedHyperlinkSettingsClicked(ByVal sender As Object, ByVal e As EventArgs)
            Dim vm As HyperlinkSettingViewModel = New(_, _)()
            Me.edit
            Function() Navigation.PopAsync()
            Dim view As HyperlinkSettingsView = New(_, _) With {.BindingContext = vm}
            Dim page As ContentPage = New(_, _) With {.Content = view, .Title = HtmlEditLocalizer.GetString(HtmlEditStringId.InsertHyperlink_Title)}
            page.ToolbarItems.Add(New ToolbarItem() With {.IconImageSource = "dxre_check", .Command = vm.ApplyCommand})
            Navigation.PushAsync(page)
        End Sub

        Private Sub OnShowTextSettingsClicked(ByVal sender As Object, ByVal e As EventArgs)
            Me.edit.AllowUserInput = False
            Me.toolbar.SelectedPageName = "TextSettings"
            TextFormatView = If(TextFormatView, New TextFormatView())
            Me.root.KeyboardAreaContent = TextFormatView
            TextFormatView.BindingContext = New TextFormatViewModel(Me.edit)
            Me.root.IsOpened = True
        End Sub

        Private Async Function NavigateToEditPage() As Task
            Await Navigation.PopAsync()
            Me.edit.Focus()
            Await Task.Delay(1000)
        End Function

        Private Sub OnSafeKeyboardAreaViewClosed(ByVal sender As Object, ByVal e As EventArgs)
            Me.toolbar.SelectedPageName = Nothing
            ClearKeyboardArea()
        End Sub

        Private Sub OnResetToolbarClicked(ByVal sender As Object, ByVal e As EventArgs)
            __ = ResetToolbar()
        End Sub

        Private Async Function ResetToolbar() As Task
            Me.edit.AllowUserInput = True
            Me.edit.Focus()
            Me.toolbar.SelectedPageName = Nothing
            If Me.root.KeyboardAreaContent IsNot Nothing Then
                Await Me.root.CloseAsync()
                ClearKeyboardArea()
            End If
        End Function

        Private Sub ClearKeyboardArea()
            If Me.root.KeyboardAreaContent Is Nothing Then Return
            Dim view As View = Nothing, htmlOwner As IHtmlOwner = Nothing
            If CSharpImpl.__Assign(view, TryCast(Me.root.KeyboardAreaContent, View)) IsNot Nothing Then
                If CSharpImpl.__Assign(htmlOwner, TryCast(view.BindingContext, IHtmlOwner)) IsNot Nothing Then htmlOwner.Owner = Nothing
                view.BindingContext = Nothing
            End If

            Me.root.KeyboardAreaContent = Nothing
            Me.edit.Focus()
        End Sub

        Private Class CSharpImpl

            <System.Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
