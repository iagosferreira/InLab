// Importa namespaces necessários para testes de integração com EF Core
using System;
using System.Linq;
using InLab.Data;
using InLab.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

// Agrupa testes relacionados ao acesso a dados (Data)
namespace InLab.Tests.Data
{
    // Classe contendo testes que validam operações do AppDbContext
    public class DbContextTests
    {
        // Método auxiliar que cria um AppDbContext usando um provedor
        // em memória. Cada chamada gera um banco separado (Guid) para
        // evitar interferência entre testes.
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        // Teste que insere entidades relacionadas e verifica se conseguem
        // ser recuperadas com Include (navegação) corretamente.
        [Fact]
        public void DeveInserirERecuperarDetectorComAreaECalibracao()
        {
            // Arrange
            // using garante que o contexto será descartado ao final do bloco
            using var context = GetInMemoryDbContext();

            // Cria e persiste uma área
            var area = new Area { NomeAre = "Área de Processo GEO-I" };
            context.Areas.Add(area);
            context.SaveChanges();

            // Cria e persiste um detector associado à área
            var detector = new Detector
            {
                IdAre = area.IdAre,
                CadastroDet = "DET-100",
                SerialDet = "SN-998877",
                FabricanteDet = "Honeywell",
                ModeloDet = "Sensepoint XCD",
                StatusUsoDet = "Ativo"
            };
            context.Detectores.Add(detector);
            context.SaveChanges();

            // Cria e persiste uma calibração vinculada ao detector
            var calibracao = new Calibracao
            {
                IdDet = detector.IdAde,
                DataCal = DateTime.Now
            };
            context.Calibracoes.Add(calibracao);
            context.SaveChanges();

            // Act
            // Recupera o detector incluindo as coleções de navegação
            var resultado = context.Detectores
                .Include(d => d.Area)
                .Include(d => d.Calibracoes)
                .FirstOrDefault(d => d.IdAde == detector.IdAde);

            // Assert
            // Valida que a entidade foi recuperada com seus relacionamentos
            Assert.NotNull(resultado);
            Assert.Equal("DET-100", resultado.CadastroDet);
            Assert.Equal("Área de Processo GEO-I", resultado.Area?.NomeAre);
            Assert.Single(resultado.Calibracoes);
        }

        // Teste que confirma a remoção de um detector do contexto
        [Fact]
        public void DeveRemoverDetectorComSucesso()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            var detector = new Detector { CadastroDet = "DET-TEMP", FabricanteDet = "Teste" };
            context.Detectores.Add(detector);
            context.SaveChanges();

            // Act
            context.Detectores.Remove(detector);
            context.SaveChanges();

            // Verifica se não existe mais registro com o cadastro temporário
            var existe = context.Detectores.Any(d => d.CadastroDet == "DET-TEMP");

            // Assert
            Assert.False(existe);
        }
    }
}
