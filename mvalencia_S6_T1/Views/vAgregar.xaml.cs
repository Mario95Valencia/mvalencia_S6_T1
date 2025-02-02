using System.Net;

namespace mvalencia_S6_T1.Views;

public partial class vAgregar : ContentPage
{
    public vAgregar()
    {
        InitializeComponent();
    }

    private void btnagregar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            cliente.UploadValues("http://192.168.56.1/moviles/post.php", "POST", parametros);
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "Ok");
        }
    }
}