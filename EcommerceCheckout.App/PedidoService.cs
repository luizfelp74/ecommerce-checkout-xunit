namespace EcommerceCheckout.App;

public class PedidoService
{
    // Retorno string: região em maiúsculas + número do pedido com 4 dígitos.
    // Ex.: ("sudeste", 42) -> "SUDESTE-0042"
    public string GerarCodigoRastreio(string regiao, int numeroPedido)
    {
        return $"{regiao.ToUpper()}-{numeroPedido:D4}";
    }

    // Retorno int: a cada R$ 10 em compras, o cliente ganha 2 pontos.
    // Ex.: 150 -> (150 / 10) * 2 = 30
    public int CalcularPontosFidelidade(int valorTotal)
    {
        return (valorTotal / 10) * 2;
    }

    // Retorno bool: frete grátis se valor >= 200 OU cliente VIP.
    public bool TemDireitoAFreteGratis(int valorTotal, bool eClienteVIP)
    {
        return valorTotal >= 200 || eClienteVIP;
    }
}
