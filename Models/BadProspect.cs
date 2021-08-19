using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto2_AppWeb.Models
{
    public class BadProspect
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

        [DisplayName("Número Telefónico")]
        [Column("PHONE_NUMBER", TypeName = "varchar(9)")]
        public string PhoneNumber { get; set; }

        [DisplayName("Monto de Compras Recientes")]
        [Column("RECENT_PURCHASES_AMOUNT", TypeName = "decimal(18,2)")]
        public decimal RecentPurchasesAmount { get; set; }

        [DisplayName("Monto de Compras del Año pasado")]
        [Column("LAST_YEAR_PURCHASES", TypeName = ("decimal(18,2)"))]
        public decimal LastYearPurchases { get; set; }


        public BadProspect(Client client)
        {
            Id = client.Id;
            FullName = client.FullName;
            RecentPurchasesAmount = client.RecentPurchasesAmount;
            if (Id.StartsWith("0"))
                ClientType = "Fìsico";
            else
                ClientType = "Jurídico";
            PhoneNumber = client.PhoneNumber;
            LastYearPurchases = client.LastYearPurchases;
        }

        public BadProspect() { }
    }
}