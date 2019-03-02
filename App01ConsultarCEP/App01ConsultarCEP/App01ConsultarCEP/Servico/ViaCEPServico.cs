using System;
using System.Collections.Generic;
using System.Text;
using App01ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;
using System.Net;

namespace App01ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json";

        public static Endereco BuscarEnderecoViaCEP(string CEP)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, CEP);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;

            return end;
        }
    }
}
