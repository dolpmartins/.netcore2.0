using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace C6Consulting.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Título livro")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Autor")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Editora")]
        public string Editora { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Ano de publicação")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe um valor numérico válido.")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Digite o ano com 4 digitos")]
        public int AnoPublicacao { get; set; }
    }
}
