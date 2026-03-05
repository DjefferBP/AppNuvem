using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppNuvem.Models;
using AppNuvem.Controller;
namespace AppNuvem
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageCadastrar : ContentPage
	{
		public PageCadastrar()
		{
			InitializeComponent();
		}

		private void btnCadastar_Clicked(object sender, EventArgs e)
		{
			DateTime datanasc = dpDataNasc.Date;
			string genero = txtGenero.SelectedItem.ToString();
			if (genero == "Masculino")
			{
				genero = "M";
			}
			else if(genero == "Feminino")
			{
				genero = "F";
			}
			else
			{
				genero = "O";
			}
			MySQLCon.CriarCliente(new Models.Pessoa
			{
				nome = txtNome.Text,
				celular = txtTelefone.Text,
				datanasc = datanasc,
				genero = genero
			});
			Navigation.PopAsync();
        }
    }
}