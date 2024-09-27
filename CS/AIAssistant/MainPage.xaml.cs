using DevExpress.Maui.HtmlEditor;
using OpenAI.Chat;
using Microsoft.Maui.Storage;
using Microsoft.Maui.ApplicationModel.Communication;
using static System.Net.Mime.MediaTypeNames;

namespace HtmlEditTextAssistant
{
    public partial class MainPage : ContentPage
    {
        ChatClient aiClient = new(model: "gpt-3.5-turbo", "your-openai-api-key");

        public MainPage()
        {
            InitializeComponent();
        }
        async void OnPageAppearing(object sender, EventArgs e)
        {
            using Stream stream = await FileSystem.Current.OpenAppPackageFileAsync("mail.html");
            using StreamReader reader = new StreamReader(stream);
            await htmledit.SetHtmlSourceAsync(await reader.ReadToEndAsync());
        }
        async void OnFixGrammarClick(System.Object sender, System.EventArgs e)
        {
            await ExecuteChatRequest($"Fix grammar errors:{await htmledit.GetHtmlAsync()}");
        }
        async void OnEnhanceClick(System.Object sender, System.EventArgs e)
        {
            await ExecuteChatRequest($"Make the text sound more polite:{await htmledit.GetHtmlAsync()}");
        }
        async Task ExecuteChatRequest(string prompt)
        {
            try
            {
                ChatCompletion completion = await aiClient.CompleteChatAsync(new List<ChatMessage> {
                    new SystemChatMessage($"You are an assistant correcting HTML text. Use only those tag types that you can find in the source document"),
                    new UserChatMessage(prompt)

                });
                await htmledit.SetHtmlSourceAsync(completion.Content[0].Text);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}