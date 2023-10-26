using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
// ...
[DefaultClassOptions]
public class OrderInRows : BaseObject
{
    public virtual OrderInHeader OrderInHeader { get; set; }
    public virtual int RowIndex { get; set; }

    [Column(TypeName = "varchar(100)")]
    public virtual String PartNumber { get; set; }

    [Column(TypeName = "varchar(200)")]
    public virtual String PartName { get; set; }
    public virtual String PartDescription { get; set; }
    public virtual double PartPrice { get; set; }
    public virtual double QTT { get; set; }

    public virtual int PartPriceDiscount { get; set; }
}
