using System.ComponentModel.DataAnnotations;


namespace LP3.BlazorServer.Shared.DTOs
{
    public class CursoFormDto
    {
        // int? permite que sea nulo cuando el curso es nuevo
        public int? Id { get; set; } 

        [Required(ErrorMessage = "El nombre del curso es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El código es requerido")]
        [StringLength(10, ErrorMessage = "El código no puede exceder los 10 caracteres")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los créditos son requeridos")]
        [Range(1, 20, ErrorMessage = "Los créditos deben estar entre 1 y 20")]
        public int Creditos { get; set; }

        public bool Activo { get; set; } = true; // Por defecto activo al crear
    }
}