// Importa as entidades a serem testadas
using InLab.Models;
// Importa o xUnit, framework de testes usado no projeto
using Xunit;

// Agrupa os testes relacionados à entidade Detector
namespace InLab.Tests.Models
{
    // Classe que contém testes unitários para Detector
    public class DetectorTests
    {
        // Teste simples que verifica que a lista de calibrações
        // é inicializada (não nula) e começa vazia.
        [Fact]
        public void Detector_DeveInicializarListaDeCalibracoesVazia()
        {
            // Arrange & Act:
            // Cria uma nova instância usando o construtor padrão.
            var detector = new Detector();

            // Assert:
            // Garante que a propriedade Calibracoes foi inicializada
            // e não contém itens imediatamente após a criação.
            Assert.NotNull(detector.Calibracoes);
            Assert.Empty(detector.Calibracoes);
        }

        // [Theory] permite executar o mesmo teste com vários conjuntos
        // de dados. [InlineData] fornece cada conjunto de parâmetros.
        [Theory]
        [InlineData("DET-001", "Honeywell", "XNX", "Ativo")]
        [InlineData("DET-002", "MSA", "Altair 4XR", "Inativo")]
        public void Detector_DeveAtribuirPropriedadesCorretamente(string cadastro, string fabricante, string modelo, string status)
        {
            // Arrange & Act:
            // Inicializa um Detector usando os valores recebidos pelo Theory.
            var detector = new Detector
            {
                CadastroDet = cadastro,
                FabricanteDet = fabricante,
                ModeloDet = modelo,
                StatusUsoDet = status
            };

            // Assert:
            // Verifica se as propriedades foram atribuídas corretamente.
            Assert.Equal(cadastro, detector.CadastroDet);
            Assert.Equal(fabricante, detector.FabricanteDet);
            Assert.Equal(modelo, detector.ModeloDet);
            Assert.Equal(status, detector.StatusUsoDet);
        }
    }
}
