
using mvalencia_S6_T1.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;

namespace mvalencia_S6_T1.Views;

public partial class vEstudiante : ContentPage
{
    private const string Url = " http://192.168.56.1/moviles/post.php";
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

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.vAgregar());
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objetoEstudiante = (Estudiante)e.SelectedItem;
        Navigation.PushAsync(new vEliminar(objetoEstudiante));
    }
}