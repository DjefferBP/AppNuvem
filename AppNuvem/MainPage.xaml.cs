using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppNuvem
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void btnSair_Clicked(object sender, EventArgs e)
		{
			try
			{
				System.Diagnostics.Process.GetCurrentProcess().Kill();
			}
			catch (Exception ex)
			{
				DisplayAlert("Erro", $"Erro ao fechar o programa: {ex.Message}", "OK");
			}
        }

		private async void btnCadastrar_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync (new PageCadastrar());
		}

		private async void btnListar_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync (new PageListar());
		}
	}
}
