namespace COGERTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTipos : DbMigration
    {
        public override void Up()
        {
            /*Sql("INSERT INTO LocalSites(Id, Nome, Sigla, UF) VALUES (1, Rio de Janeiro, BR004_RJO, RJ)");
            Sql("INSERT INTO LocalSites(Id, Nome, Sigla, UF) VALUES (2, São Paulo, BR004_SPO, SP)");
            Sql("INSERT INTO LocalSites(Id, Nome, Sigla, UF) VALUES (3, Americana, BR004_AMR, SP)");

            Sql("INSERT INTO StatusFuncionarios(Id, Descricao) VALUES (1, Pendente)");
            Sql("INSERT INTO StatusFuncionarios(Id, Descricao) VALUES (2, Ativo)");
            Sql("INSERT INTO StatusFuncionarios(Id, Descricao) VALUES (3, Excluir)");
            Sql("INSERT INTO StatusFuncionarios(Id, Descricao) VALUES (4, Inativo)");

            Sql("INSERT INTO Funcionarios(UPI, Nome, Sobrenome, UsuarioGad, PlantaId, StatusFuncionarioId, CentroDeCustoId) VALUES (13224, Marcelo, Marques, mmarques, 1, 2, 7202001)");
            Sql("INSERT INTO Funcionarios(UPI, Nome, Sobrenome, UsuarioGad, PlantaId, StatusFuncionarioId, CentroDeCustoId) VALUES (13221, Caio, Dias, cdias, 3, 2, 7402001)");
            Sql("INSERT INTO Funcionarios(UPI, Nome, Sobrenome, UsuarioGad, PlantaId, StatusFuncionarioId, CentroDeCustoId) VALUES (13220, Bruno, Dolgoff, bdolgoff, 2, 2, 7302001)");
            Sql("INSERT INTO Funcionarios(UPI, Nome, Sobrenome, UsuarioGad, PlantaId, StatusFuncionarioId, CentroDeCustoId) VALUES (13222, Vitor, Reis, vreis, 2, 2, 7302001)");

            Sql("INSERT INTO CentrosDeCustos(Id, Nome, GestorUPI, CoordenadorUPI) VALUES (7202001, Tecnologia da Informação RJO, 13220, 13224)");
            Sql("INSERT INTO CentrosDeCustos(Id, Nome, GestorUPI, CoordenadorUPI) VALUES (7302001, Tecnologia da Informação SPO, 13220, 13222)");
            Sql("INSERT INTO CentrosDeCustos(Id, Nome, GestorUPI, CoordenadorUPI) VALUES (7402001, Tecnologia da Informação AMR, 13220, 13221)");

            Sql("INSERT INTO CodigosDdd(Id, DddCodigo, Estado, Regiao) VALUES (1, 21, RJ, Região Metropolitana)");
            Sql("INSERT INTO CodigosDdd(Id, DddCodigo, Estado, Regiao) VALUES (1, 11, SP, Região Metropolitana)");
            Sql("INSERT INTO CodigosDdd(Id, DddCodigo, Estado, Regiao) VALUES (1, 19, SP, Americana)");

            Sql("INSERT INTO StatusEquipamentos(Id, Descricao) VALUES (1, Funcional)");
            Sql("INSERT INTO StatusEquipamentos(Id, Descricao) VALUES (2, Em conserto)");
            Sql("INSERT INTO StatusEquipamentos(Id, Descricao) VALUES (3, Para descarte)");

            Sql("INSERT INTO TiposAparelhosCelulares(Id, Descricao) VALUES (1, Smartphone)");
            Sql("INSERT INTO TiposAparelhosCelulares(Id, Descricao) VALUES (2, Dumbphone)");
            Sql("INSERT INTO TiposAparelhosCelulares(Id, Descricao) VALUES (3, Industrial)");

            Sql("INSERT INTO TiposComputadores(Id, Descricao) VALUES (1, Desktop)");
            Sql("INSERT INTO TiposComputadores(Id, Descricao) VALUES (2, Notebook)");
            Sql("INSERT INTO TiposComputadores(Id, Descricao) VALUES (3, Tablet)");

            Sql("INSERT INTO TiposLinhas(Id, Descricao) VALUES (1, Voz)");
            Sql("INSERT INTO TiposLinhas(Id, Descricao) VALUES (2, Rádio)");
            Sql("INSERT INTO TiposLinhas(Id, Descricao) VALUES (3, Dados)");

            Sql("INSERT INTO TiposPlanosMoveis(Id, Descricao) VALUES (1, Rádio)");
            Sql("INSERT INTO TiposPlanosMoveis(Id, Descricao) VALUES (2, 50min)");
            Sql("INSERT INTO TiposPlanosMoveis(Id, Descricao) VALUES (3, 150min)");
            Sql("INSERT INTO TiposPlanosMoveis(Id, Descricao) VALUES (4, 300min)");
            Sql("INSERT INTO TiposPlanosMoveis(Id, Descricao) VALUES (5, 600min)");
            Sql("INSERT INTO TiposPlanosMoveis(Id, Descricao) VALUES (6, Ilimitado)");*/
        }
        
        public override void Down()
        {
        }
    }
}
