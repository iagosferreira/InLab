// Importa as classes do projeto que serão testadas
using InLab.Models;
// Importa o xUnit, framework de testes usado neste projeto
using Xunit;

// Agrupa os testes relacionados ao namespace InLab.Models
namespace InLab.Tests.Models
{
    // Classe que contém testes unitários para a entidade Area
    public class AreaTests
    {
        // [Fact] indica um caso de teste sem parâmetros (teste simples)
        [Fact]
        public void Area_DeveInicializarListaDeDetectoresVazia()
        {
            // Arrange & Act:
            // Cria uma instância de Area usando o construtor padrão.
            // Aqui estamos testando o comportamento de inicialização padrão.
            var area = new Area();

            // Assert:
            // Verifica que a propriedade Detectores não é nula
            // e que a lista está vazia logo após a criação do objeto.
            Assert.NotNull(area.Detectores);
            Assert.Empty(area.Detectores);
        }

        // Segundo caso de teste: verifica atribuição de propriedades simples
        [Fact]
        public void Area_DeveAtribuirNomeELocalizacaoCorretamente()
        {
            // Arrange & Act:
            // Inicializa uma Area definindo explicitamente valores para
            // as propriedades IdAre e NomeAre para validar sua atribuição.
            var area = new Area
            {
                IdAre = 1,
                NomeAre = "Laboratório Principal",
            };

            // Assert:
            // Confirma que as propriedades recebiam os valores esperados.
            Assert.Equal(1, area.IdAre);
            Assert.Equal("Laboratório Principal", area.NomeAre);
        }
    }
}
