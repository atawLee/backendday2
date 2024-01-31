using System.ComponentModel.DataAnnotations;

namespace IMS.database.entity;

public class IdolGroup 
{
    [Key]
    public int IdolGroupId {get;set;}

    public required string GroupName {get;set;}

    public required DateTime CreateDateTime {get;set;} = DateTime.Now;

    public ICollection<Member> Members { get; set; }
}

