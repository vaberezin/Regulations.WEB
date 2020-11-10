using System;
using System.ComponentModel.DataAnnotations;

namespace Regulations.BLL.DTO
{

    public class RegulationDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указан шифр нормы")]
        public string ShortName { get; set; }
        [Required(ErrorMessage = "Не указано наименование нормы")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 25 символов")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Не указана ссылка на норму")]
        [Url(ErrorMessage = "Это не ссылка!")]
        public string Link { get; set; }
        [Required]
        public DateTime? Added { get; set; }
        public int UserId { get; set; } //foreign key
    }
}
