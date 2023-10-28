using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
// ...
[DefaultClassOptions]
public class OrderInHeader : BaseObject
{
    public virtual DateTime OrderDate { get; set; }
    public virtual String OrderNumber { get; set; }

    [Column(TypeName = "varchar(255)")]
    public virtual String Customer { get; set; }
    public virtual String NoteHeader { get; set; }
    public virtual String NoteFooter { get; set; }

    [Column(TypeName = "varchar(255)")]
    public virtual String Supplier { get; set; }
}
    