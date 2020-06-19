using ProjetoAgendaAPI.Models;

namespace ProjetoAgenda.IntegrationTest.v1.ContatoTeste
{
    public static class ContatoInformacaoTeste
    {
        public static Contato CriandoInformacoesContato(bool nome)
        {
            Contato contato = new Contato()
            {
                Email = "teste@contato.com.br",
                Sobrenome = "Contato",
                Telefone = "(17) 3654-7821"
            };

            if (nome)
                contato.Nome = "Teste";

            return contato;
        }
    }
}
