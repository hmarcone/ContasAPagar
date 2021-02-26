using Entities.Notifications;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("tblConta")]
    public class Conta : Notifies
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Column("ValorOriginal")]
        [Display(Name = "Valor Original")]
        public decimal ValorOriginal { get; set; }

        [Column("ValorCorrigido")]
        [Display(Name = "Valor Corrigido")]
        public decimal ValorCorrigido { get; set; }

        [Column("QuantidadeDiasAtraso")]
        [Display(Name = "Quantidades de dias de atraso")]
        public int QuantidadeDiasAtraso { get; set; }

        [Column("DataVencimento")]
        [Display(Name = "Data do vencimento")]
        public DateTime DataVencimento { get; set; }

        [Column("DataPagamento")]
        [Display(Name = "Data do pagamento")]
        public DateTime DataPagamento { get; set; }

        public int Multa { get; set; }

        public decimal Juros { get; set; }
    }
}
