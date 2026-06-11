using System.ComponentModel.DataAnnotations;


namespace LP3.BlazorServer.Shared.DTOs
{
    public class CursoDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "El código es obligatorio.")]
        public string Codigo { get; set; } = string.Empty;
        
        [Range(1, 10, ErrorMessage = "Los créditos deben ser entre 1 y 10.")]
        public int Creditos { get; set; }
        
        public bool Activo { get; set; }
    }
}