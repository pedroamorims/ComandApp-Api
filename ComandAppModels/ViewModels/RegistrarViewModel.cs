using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandApp.Domain.ViewModels
{
    public class RegistrarViewModel
    {
        [Required(ErrorMessage="O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "O E-mail é inválido")]
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
