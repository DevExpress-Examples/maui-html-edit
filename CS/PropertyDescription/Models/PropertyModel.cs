using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DevExpress.Maui.Core;

namespace PropertyDescriptionHTMLEdit.Models;


public class Property : BindableBase
{

    [JsonPropertyName("ID")] public int Id { get; set; }
    [JsonPropertyName("Address")] public string Address { get; set; }
    [JsonPropertyName("Beds")] public byte Beds { get; set; }
    [JsonPropertyName("Baths")] public byte Baths { get; set; }
    [JsonPropertyName("HouseSize")] public int HouseSize { get; set; }
    [JsonPropertyName("LotSize")] public double LotSize { get; set; }
    [JsonPropertyName("Price")] public int Price { get; set; }

    private string features;
    [JsonPropertyName("Features")]
    public string Features
    {
        get => GetValue<string>();
        set
        {
            SetValue(value);
        }
    }
    [JsonPropertyName("YearBuilt")] public int YearBuilt { get; set; }
    [JsonPropertyName("Type")] public byte Type { get; set; }
    [JsonPropertyName("Status")] public byte Status { get; set; }
    public string PropertyStatus { get { if (Status == 1) return "Available"; else return "Not available"; } }
    [JsonPropertyName("Photo")] public string Photo { get; set; }
    [JsonPropertyName("Date")] public string DateJson { get; set; }
    public DateTime DisplayDate { get => DateTime.Parse(DateJson); }
}
