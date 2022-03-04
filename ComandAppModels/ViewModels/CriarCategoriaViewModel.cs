using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandApp.Domain.ViewModels
{
    public class CriarCategoriaViewModel
    {
        [Required(ErrorMessage = "Descrição é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "o campo Ativo é obrigatório")]
        public bool Ativo { get; set; }
        public string iconURL { get; set; }
    }
}
