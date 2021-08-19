using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto2_AppWeb.Models
{
    public class Prospect
    {
        
        [DisplayName("Tipo de Cédula")]
        [Column("CLIENT_TYPE", TypeName = "varchar(10)")]
        public string ClientType { get; set; }
        [Key]
        [DisplayName("Cédula")]
        [Column("ID", TypeName = "varchar(12)")]
        public string Id { get; set; }

        [DisplayName("Nombre")]
        [Column("FULL_NAME", TypeName = "varchar(60)")]
        public string FullName { get; set; }

        [DisplayName("Monto de Compras Recientes")]
        [Column("RECENT_PURCHASES_AMOUNT", TypeName = "decimal(18,2)")]
        public decimal RecentPurchasesAmount { get; set; }

        [DisplayName("Unidades de A/C Compradas")]
        [Column("AC_UNITS_PURCHASED", TypeName = "int")]
        public int AcUnitsPurchased { get; set; }

        public Prospect(Client client)
        {
            Id = client.Id;
            FullName = client.FullName;
            RecentPurchasesAmount = client.RecentPurchasesAmount;
            AcUnitsPurchased = client.AcUnitsPurchased;
            if (Id.StartsWith("0"))
                ClientType = "Fìsico";
            else
                ClientType = "Jurídico";
        }

        public Prospect() { }
    }
}