using Dominio.Entidades;
using Newtonsoft.Json;
using Integracao;

namespace FinancasFacil;

public partial class NewPage1 : ContentPage
{
    private readonly BaseClient _client = new BaseClient();
    private string _simboloAcao;
    public NewPage1(string simboloAcao)
    {
        InitializeComponent();
        _simboloAcao = simboloAcao;
        TelaAcao();
    }

    private async Task TelaAcao()
    {

        HttpResponseMessage respostaAPI = await _client.GetShare(_simboloAcao);
        string conteudo = await respostaAPI.Content.ReadAsStringAsync();
        Acao acao = JsonConvert.DeserializeObject<Acao>(conteudo);

        MainThread.BeginInvokeOnMainThread(() =>
        {
            NomeAcaoLabel.Text = acao!.ShortName;
            ValorAcaoLabel.Text = acao.RegularMarketPrice.ToString();
            VolumeMercado.Text=acao.RegularMarketVolume.ToString();
            PrecoMercado.Text = acao.RegularMarketPrice.ToString();
            Moeda.Text = acao.Currency;
            NomeCompleto.Text = acao.LongName;
        });

    }


}

