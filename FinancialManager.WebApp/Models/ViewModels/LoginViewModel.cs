using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinancialManager.WebApp.Models.ViewModels
{
    public class LoginViewModel
    {
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(5, ErrorMessage = "O campo {0} deve possuir ao menos {1} caracteres.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O campo {0} deve ser um e-mail válido.")]
        public string Username { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(8, ErrorMessage = "O campo {0} deve possuir ao menos {1} caracteres.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
