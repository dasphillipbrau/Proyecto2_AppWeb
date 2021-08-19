using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto2_AppWeb.Models
{
    public class Client
    {
        [Key]
        [Column("ID", TypeName = "varchar(12)")]
        [DisplayName("Cèdula")]
        [Required(ErrorMessage = "Cédula no puede estar vacía.")]
        [RegularExpression(@"^(0\d-\d{4}-\d{4})|(\d-\d{3}-\d{6})$", ErrorMessage = "Formato de cédula es incorrecto.")]
        [StringLength(12, ErrorMessage = "Se requieren 12 carácteres.", MinimumLength = 12)]
        public string Id { get; set; }

        [Column("FULL_NAME", TypeName = "varchar(60)")]
        [DisplayName("Nombre Completo")]
        [Required(ErrorMessage = "El nombre no puede estar vacío.")]
        [StringLength(60, ErrorMessage = "Se requieren entre 10 y 60 carácteres.", MinimumLength = 10)]
        public string FullName { get; set; }

        [Column("PHONE_NUMBER", TypeName = "varchar(9)")]
        [DisplayName("Nùmero de Telefóno")]
        [Required(ErrorMessage = "El telefóno no puede estar vacío.")]
        [StringLength(9, ErrorMessage = "Se requieren 9 carácteres.", MinimumLength = 9)]
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Formato de telefóno es incorrecto.")]
        public string PhoneNumber { get; set; }


        [Column("DISCOUNT")]
        [Required(ErrorMessage = "Escoja una opción de descuento.")]
        [DisplayName("Aplica para Descuento")]
        public bool Discount { get; set; }

        [Column("RECENT_PURCHASES_AMOUNT", TypeName = "decimal(18,2)")]
        [DisplayName("Monto de Compras Recientes")]
        [Required(ErrorMessage = "Ingrese un monto válido.")]
        [RegularExpression(@"^\d+[,\.]?\d*$", ErrorMessage = "Ingrese un valor númerico.")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0.")]
        public decimal RecentPurchasesAmount { get; set; }

        [Column("LAST_YEAR_PURCHASES", TypeName = "decimal(18,2)")]
        [DisplayName("Monto de Compras para el año pasado")]
        [Required(ErrorMessage = "Ingrese un monto válido.")]
        [RegularExpression(@"^\d+[,\.]?\d*$", ErrorMessage = "Ingrese un valor númerico.")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0.")]
        public decimal LastYearPurchases { get; set; }

        [Column("AC_UNITS_PURCHASED", TypeName = "int")]
        [DisplayName("Unidades de A/C Compradas")]
        [Required(ErrorMessage = "Escoja una cantidad válida.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Ingrese un valor númerico.")]
        [Range(1, int.MaxValue, ErrorMessage = "Ingrese un número mayor a 0.")]
        public int AcUnitsPurchased { get; set; }

        public Client() { }


    }
}