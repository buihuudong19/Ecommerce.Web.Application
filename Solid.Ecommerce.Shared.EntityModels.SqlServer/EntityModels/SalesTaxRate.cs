﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Solid.Ecommerce.Shared;

/// <summary>
/// Tax rate lookup table.
/// </summary>
[Table("SalesTaxRate", Schema = "Sales")]
[Index("Rowguid", Name = "AK_SalesTaxRate_rowguid", IsUnique = true)]
public partial class SalesTaxRate
{
    /// <summary>
    /// Primary key for SalesTaxRate records.
    /// </summary>
    [Key]
    [Column("SalesTaxRateID")]
    public int SalesTaxRateId { get; set; }

    /// <summary>
    /// 1 = Tax applied to retail transactions, 2 = Tax applied to wholesale transactions, 3 = Tax applied to all sales (retail and wholesale) transactions.
    /// </summary>
    public byte TaxType { get; set; }

    /// <summary>
    /// Tax rate amount.
    /// </summary>
    [Column(TypeName = "smallmoney")]
    public decimal TaxRate { get; set; }

    /// <summary>
    /// Tax rate description.
    /// </summary>
    [StringLength(50)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
