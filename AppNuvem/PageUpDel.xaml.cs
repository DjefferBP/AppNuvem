using AppNuvem.Controller;
using AppNuvem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppNuvem
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageUpDel : ContentPage
	{
		public Pessoa cliente;

		
		public PageUpDel(Pessoa pessoa)
		{
			InitializeComponent();
			cliente = pessoa;
			
		}

		private void btnAtualizar_Clicked(object sender, EventArgs e)
		{
			DateTime datanasc = dpDataNasc.Date;
			string genero = txtGenero.SelectedItem.ToString();
			if (genero == "Masculino")
			{
				genero = "M";
			}
			else if (genero == "Feminino")
			{
				genero = "F";
			}
			else
			{
				genero = "O";
			}
			MySQLCon.AtualizarPessoa(new Models.Pessoa
			{
				id = cliente.id,
				nome = txtNome.Text,
				celular = txtTelefone.Text,
				genero = genero,
				datanasc = datanasc
				
			});
			Navigation.PopAsync();
        }

		private void btnExcluir_Clicked(object sender, EventArgs e)
		{
			if (cliente.id > 0)
			{
				MySQLCon.ExcluirCliente(cliente);
			}
			Navigation.PopAsync();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			BindingContext = this.cliente;
			txtNome.Text = cliente.nome;
			txtTelefone.Text = cliente.celular;

			if (cliente.genero == "M") txtGenero.SelectedIndex = 0;
			else if (cliente.genero == "F") txtGenero.SelectedIndex = 1;
			else txtGenero.SelectedIndex = 2;
			dpDataNasc.Date = cliente.datanasc;
		}
	}
}