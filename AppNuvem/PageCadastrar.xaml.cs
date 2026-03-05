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
			if (!MySQLCon.DataEValida(datanasc))
			{
				DisplayAlert("Erro", "A data selecionada deve ser menor que a data atual!", "OK");
				LimparCampos();
				return;
			}
			string gen = "";
			if (txtGenero.SelectedItem != null)
			{
				gen = txtGenero.SelectedItem.ToString();
			}
			if (MySQLCon.CampoEstaVazio(txtNome.Text, txtTelefone.Text, dpDataNasc.Date, gen))
			{
				DisplayAlert("Erro", "Insira os campos corretamente!", "OK");
				LimparCampos();
				return;
			}
			if (txtTelefone.Text.Length < 11 || txtTelefone.Text.Length > 11)
			{
				DisplayAlert("Erro", "O telefone deve conter 10-11 digitos!", "OK");
				LimparCampos();
				return;
			}
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
		private void LimparCampos()
		{
			txtGenero.SelectedItem = null;
			txtNome.Text = string.Empty;
			txtTelefone.Text = string.Empty;

		}
	}
}