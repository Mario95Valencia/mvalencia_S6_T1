using AudioUnit;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;

namespace mvalencia_S6_T1.Views;

public partial class vEstudiante : ContentPage
{
    private const string Url = " 10.2.13.212";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Models.Estudiante> est;
    public vEstudiante()
    {
        InitializeComponent();
        mostrar();
    }

    public async void mostrar()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Models.Estudiante> mostrar = JsonConvert.DeserializeObject<List<Models.Estudiante>>(content);
        est = new ObservableCollection<Models.Estudiante>(mostrar);
        listaEstudiantes.ItemsSource = est;

    }
}