using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01ConsultarCEP.Servico;
using App01ConsultarCEP.Servico.Modelo;

namespace App01ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnBuscarCEP.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = FormatarCEP(txtBuscarCEP.Text);

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        lblResultado.Text = string.Format("Endereço: {0}, {1}, {2}, {3}",
                            end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("Erro", "Vish mano! Esse o cep " + cep + " não foi encontrado", "OK");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("Erro", "Deu reuim da seguinte forma: " + e.Message, "OK");
                }                
            }                       
        }

        private string FormatarCEP(string CEP)
        {
            return CEP.Replace(".", "").Replace("-", "").Replace("/", "").Trim();
        }

        private bool isValidCEP(string CEP)
        {
            int NovoCEP = 0;
            if (CEP.Length != 8)
            {
                DisplayAlert("Erro", "O CEP deve conter 8 caracteres, blz?", "Blz");
                return false;
            }
            if (!int.TryParse(CEP, out NovoCEP))
            {
                DisplayAlert("Erro", "O CEP deve conter apenas números, as letras estão ai pra sacanear.", "OK");
                return false;
            }
            return true;
        }
    }
}
