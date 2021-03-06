<h1>Controle de Caminhões</h2>

Projeto desenvolvido em <i>.NetCore, versão 3.1</i> e persistência de dados com <i>SQLite</i> para o controle de caminhões - crud básico.

Além disso, possui um cadastro de usuários e autenticação usando <i>JWT</i>.

As funcionalidades de cadastro, edição e exclusão podem ser usadas apenas para usuários previamente logados no sistema, desde que seja setada como true a propriedade <i>UseAuth</i> no arquivo <i>appsettings.Development.json</i>

<h2>Executar o Projeto</h1>
Para conseguir executar o projeto, basta primeiramente possuir o <i>SDK .NetCore na versão 3.1</i> ou superior e o <i>Visual Studio ou VSCode</i>.

Após abrir o projeto, é necessário no <i>Package Manager Console</i> selecionar o Default Project Trucks.Infra.Data e rodar o comando <i>Update-Database</i> para criar a base de dados do <i>SQLite</i>.

Finalmente, basta executar o projeto no navegador.
