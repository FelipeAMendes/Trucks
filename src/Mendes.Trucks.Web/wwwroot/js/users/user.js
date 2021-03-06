$(function () {
	user.configure();
});

var User = (function () {
	function User() { };

	User.prototype.configure = function () {
		addConfigs();
	}

	function addConfigs() {
		$("#Email,#Email,#Confirmation,#Password,#PasswordConfirmation").on("cut copy paste",
			function (event) {
				event.preventDefault();
			});

		$.validator.addMethod("minPasswordScore",
			function (value, _, params) {
				return (zxcvbn(value).score + 1) * 20 >= params;
			});

		$("#Cpf").mask("000.000.000-00", { placeholder: "___.___.___-__" });
		$("#progress").passwordStrong({
			passwordInput: "#Password"
		});
	}

	return User;
}());

var user = new User();