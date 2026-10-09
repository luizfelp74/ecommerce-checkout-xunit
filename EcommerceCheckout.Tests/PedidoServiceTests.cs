using EcommerceCheckout.App;

namespace EcommerceCheckout.Tests;

public class PedidoServiceTests
{
    private readonly PedidoService _service = new PedidoService();

    // Teste 1 (string)
    [Fact]
    public void GerarCodigoRastreio_RegiaoEPedido_RetornaMascaraCorreta()
    {
        string resultado = _service.GerarCodigoRastreio("sudeste", 42);

        Assert.Equal("SUDESTE-0042", resultado);
    }

    // Teste 2 (int)
    [Fact]
    public void CalcularPontosFidelidade_Valor150_Retorna30Pontos()
    {
        int resultado = _service.CalcularPontosFidelidade(150);

        Assert.Equal(30, resultado);
    }

    // Teste 3 (bool) - cliente VIP abaixo de R$ 200
    [Fact]
    public void TemDireitoAFreteGratis_ClienteVipAbaixoDe200_RetornaTrue()
    {
        bool resultado = _service.TemDireitoAFreteGratis(150, true);

        Assert.True(resultado);
    }

    // Teste 3 (bool) - cliente não VIP abaixo de R$ 200
    [Fact]
    public void TemDireitoAFreteGratis_ClienteNaoVipAbaixoDe200_RetornaFalse()
    {
        bool resultado = _service.TemDireitoAFreteGratis(150, false);

        Assert.False(resultado);
    }
}
