using System.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
using DevExpress.Maui.Core;
using System.Text.Json;

using PropertyDescriptionHTMLEdit.Models;
namespace PropertyDescriptionHTMLEdit.ViewModels;

public class PropertyViewModel : BindableBase
{

    private bool isDataLoading;
    private ObservableCollection<Property> items;
    private Property selectedProperty;

    public Property SelectedProperty
    {
        get => selectedProperty;
        set
        {
            selectedProperty = value;
            RaisePropertiesChanged(nameof(SelectedProperty));
        }
    }
    public bool IsDataLoading
    {
        get => isDataLoading;
        set
        {
            isDataLoading = value;
            RaisePropertyChanged(nameof(IsDataLoading));
        }
    }
    public ObservableCollection<Property> Items
    {
        get => items;
        set
        {
            items = value;
            RaisePropertyChanged(nameof(Items));
        }
    }


    public PropertyViewModel()
    {
        LoadDataFromJson();
    }

    public Task LoadDataAsync()
    {
        return Task.Run(() => LoadDataFromJson());
    }

    private async void LoadDataFromJson()
    {
        IsDataLoading = true;

        var json = await FileSystem.OpenAppPackageFileAsync("Homes.json");
        // StreamReader reader = new StreamReader(json);
        // string line = "";
        // while ((line = reader.ReadLine()) != null)
        // {
        //     Console.WriteLine(line);
        // }
        Items = await JsonSerializer.DeserializeAsync<ObservableCollection<Property>>(json, Options);
        IsDataLoading = false;

    }

    private static readonly JsonSerializerOptions Options = new JsonSerializerOptions();

}