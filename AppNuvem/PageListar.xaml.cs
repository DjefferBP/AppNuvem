using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppNuvem.Controller;
using AppNuvem.Models;

namespace AppNuvem
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageListar : ContentPage
	{
		public PageListar()
		{
			InitializeComponent();
		}

		private void lsvPessoas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null)
			{
				NavegarPessoa(e.SelectedItem as Pessoa);
			}
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
			lsvPessoas.ItemsSource = MySQLCon.ListaClientes();
		}

		void NavegarPessoa(Pessoa pessoa)
		{
			PageUpDel updel = new PageUpDel(pessoa);
			Navigation.PushAsync(updel);
		}

		private void btnNovo_Clicked(object sender, EventArgs e)
		{

        }
    }
}