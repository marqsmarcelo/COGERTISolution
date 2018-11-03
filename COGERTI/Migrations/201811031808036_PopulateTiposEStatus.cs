namespace COGERTI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTiposEStatus : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT LocalSites ON");
            Sql("INSERT INTO LocalSites(Id, Nome, Sigla, UF) VALUES (1, 'Rio de Janeiro', 'BR004_RJO', 'RJ')");
            Sql("INSERT INTO LocalSites(Id, Nome, Sigla, UF) VALUES (2, 'São Paulo', 'BR004_SPO', 'SP')");
            Sql("INSERT INTO LocalSites(Id, Nome, Sigla, UF) VALUES (3, 'Americana', 'BR004_AMR', 'SP')");
            Sql("SET IDENTITY_INSERT LocalSites OFF");

            Sql("SET IDENTITY_INSERT StatusFuncionarios ON");
            Sql("INSERT INTO StatusFuncionarios(Id, Descricao) VALUES (1, 'Pendente')");
            Sql("INSERT INTO StatusFuncionarios(Id, Descricao) VALUES (2, 'Ativo')");
            Sql("INSERT INTO StatusFuncionarios(Id, Descricao) VALUES (3, 'Excluir')");
            Sql("INSERT INTO StatusFuncionarios(Id, Descricao) VALUES (4, 'Inativo')");
            Sql("SET IDENTITY_INSERT StatusFuncionarios OFF");

            Sql("SET IDENTITY_INSERT CentrosDeCustos ON");
            Sql("INSERT INTO CentrosDeCustos(Id, Nome) VALUES (7202001, 'Tecnologia da Informação RJO')");
            Sql("INSERT INTO CentrosDeCustos(Id, Nome) VALUES (7302001, 'Tecnologia da Informação SPO')");
            Sql("INSERT INTO CentrosDeCustos(Id, Nome) VALUES (7402001, 'Tecnologia da Informação AMR')");
            Sql("SET IDENTITY_INSERT CentrosDeCustos OFF");

            Sql("SET IDENTITY_INSERT Funcionarios ON");
            Sql("INSERT INTO Funcionarios(UPI, Nome, Sobrenome, UsuarioGad, PlantaId, StatusFuncionarioId, CentroDeCustoId) VALUES (13224, 'Marcelo', 'Marques', 'mmarques', 1, 2, 7202001)");
            Sql("INSERT INTO Funcionarios(UPI, Nome, Sobrenome, UsuarioGad, PlantaId, StatusFuncionarioId, CentroDeCustoId) VALUES (13221, 'Caio', 'Dias', 'cdias', 3, 2, 7402001)");
            Sql("INSERT INTO Funcionarios(UPI, Nome, Sobrenome, UsuarioGad, PlantaId, StatusFuncionarioId, CentroDeCustoId) VALUES (13220, 'Bruno', 'Dolgoff', 'bdolgoff', 2, 2, 7302001)");
            Sql("INSERT INTO Funcionarios(UPI, Nome, Sobrenome, UsuarioGad, PlantaId, StatusFuncionarioId, CentroDeCustoId) VALUES (13222, 'Vitor', 'Reis', 'vreis', 2, 2, 7302001)");
            Sql("SET IDENTITY_INSERT Funcionarios OFF");

            Sql("UPDATE CentrosDeCustos SET GestorUPI=13220, CoordenadorUPI=13224 WHERE Id=7202001");
            Sql("UPDATE CentrosDeCustos SET GestorUPI=13220, CoordenadorUPI=13222 WHERE Id=7302001");
            Sql("UPDATE CentrosDeCustos SET GestorUPI=13220, CoordenadorUPI=13221 WHERE Id=7402001");

            Sql("SET IDENTITY_INSERT CodigosDdd ON");
            Sql("INSERT INTO CodigosDdd(Id, DddCodigo, UF, Regiao) VALUES (1, '21', 'RJ', 'Região Metropolitana')");
            Sql("INSERT INTO CodigosDdd(Id, DddCodigo, UF, Regiao) VALUES (2, '11', 'SP', 'Região Metropolitana')");
            Sql("INSERT INTO CodigosDdd(Id, DddCodigo, UF, Regiao) VALUES (3, '19', 'SP', 'Americana')");
            Sql("SET IDENTITY_INSERT CodigosDdd OFF");

            Sql("SET IDENTITY_INSERT StatusEquipamentos ON");
            Sql("INSERT INTO StatusEquipamentos(Id, Descricao) VALUES (1, 'Funcional')");
            Sql("INSERT INTO StatusEquipamentos(Id, Descricao) VALUES (2, 'Em conserto')");
            Sql("INSERT INTO StatusEquipamentos(Id, Descricao) VALUES (3, 'Para descarte')");
            Sql("SET IDENTITY_INSERT StatusEquipamentos OFF");

            Sql("SET IDENTITY_INSERT TiposAparelhosCelulares ON");
            Sql("INSERT INTO TiposAparelhosCelulares(Id, Descricao) VALUES (1, 'Smartphone')");
            Sql("INSERT INTO TiposAparelhosCelulares(Id, Descricao) VALUES (2, 'Dumbphone')");
            Sql("INSERT INTO TiposAparelhosCelulares(Id, Descricao) VALUES (3, 'Industrial')");
            Sql("SET IDENTITY_INSERT TiposAparelhosCelulares OFF");

            Sql("SET IDENTITY_INSERT TiposComputadores ON");
            Sql("INSERT INTO TiposComputadores(Id, Descricao) VALUES (1, 'Desktop')");
            Sql("INSERT INTO TiposComputadores(Id, Descricao) VALUES (2, 'Notebook')");
            Sql("INSERT INTO TiposComputadores(Id, Descricao) VALUES (3, 'Tablet')");
            Sql("SET IDENTITY_INSERT TiposComputadores OFF");

            Sql("SET IDENTITY_INSERT TiposLinhas ON");
            Sql("INSERT INTO TiposLinhas(Id, Descricao) VALUES (1, 'Voz')");
            Sql("INSERT INTO TiposLinhas(Id, Descricao) VALUES (2, 'Rádio')");
            Sql("INSERT INTO TiposLinhas(Id, Descricao) VALUES (3, 'Dados')");
            Sql("SET IDENTITY_INSERT TiposLinhas OFF");

            Sql("SET IDENTITY_INSERT TiposPlanosMoveis ON");
            Sql("INSERT INTO TiposPlanosMoveis(Id, Descricao) VALUES (1, 'Rádio')");
            Sql("INSERT INTO TiposPlanosMoveis(Id, Descricao) VALUES (2, '50min')");
            Sql("INSERT INTO TiposPlanosMoveis(Id, Descricao) VALUES (3, '150min')");
            Sql("INSERT INTO TiposPlanosMoveis(Id, Descricao) VALUES (4, '300min')");
            Sql("INSERT INTO TiposPlanosMoveis(Id, Descricao) VALUES (5, '600min')");
            Sql("INSERT INTO TiposPlanosMoveis(Id, Descricao) VALUES (6, 'Ilimitado')");
            Sql("SET IDENTITY_INSERT TiposPlanosMoveis OFF");
        }
        
        public override void Down()
        {
        }
    }
}
