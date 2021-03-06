namespace Mendes.Trucks.Domain.Catalog.Messages
{
	public static class UserMessages
	{
		public const string RegisterSuccess = "Cadastro efetuado com sucesso.";
		public const string EditSuccess = "Cadastro alterado com sucesso.";
		public const string DeleteSuccess = "Cadastro removido com sucesso.";

		public const string ErrorNameNotProvided = "Nome Completo é obrigatório.";
		public const string ErrorCpfNotProvided = "CPF é obrigatório.";
		public const string ErrorCpfInvalid = "CPF informado é inválido.";
		public const string ErrorExistingCpf = "CPF já cadastrado.";
		public const string ErrorEmailNotProvided = "E-mail é obrigatório.";
		public const string ErrorEmailInvalid = "E-mail informado é inválido.";
		public const string ErrorExistingEmail = "E-mail já cadastrado.";
		public const string ErrorPasswordNotProvided = "Senha é obrigatória.";

		public const string ErrorLogin = "Usuário ou senha inválidos.";
	}
}
