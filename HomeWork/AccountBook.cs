namespace HomeWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountBook")]
    public partial class AccountBook : IValidatableObject
    {
        public Guid Id { get; set; }
        [Required]
        public int Categoryyy { get; set; }
        [Required]
        [RegularExpression(@"^\+?[1-9][0-9]*$",ErrorMessage = "請輸入大於零的數")]
        public int Amounttt { get; set; }
        [Required]
       
        public DateTime Dateee { get; set; }

        [Required]
        [StringLength(100)]
        public string Remarkkk { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
   
            if (Dateee < DateTime.Now)
            {
                yield return new ValidationResult("日期必須大於今天", new[] { "Dateee" });
            }
        }
    }

}
