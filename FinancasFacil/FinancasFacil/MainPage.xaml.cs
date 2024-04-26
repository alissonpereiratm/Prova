﻿using Dominio.Entidades;
using Integracao;
using Newtonsoft.Json;
namespace FinancasFacil
{
    public partial class MainPage : ContentPage
    {
    
 
        public MainPage()
        {
            InitializeComponent();
        }
        private async void MostraPaginaDetalhes(object sender, EventArgs e)
        {
            string simboloAcao = campoSimbolo.Text;
            NewPage1 newPage = new NewPage1(simboloAcao);
            await Navigation.PushAsync(newPage);
        }
    }

}
