using System.ComponentModel.DataAnnotations;

namespace IMS.database.entity;
public class Member 
{
    [Key]
    public int MemberId {get;set;}
    public required string MemberName {get;set;}
    public DateTime CreateDateTime {get;set;} = DateTime.Now;
    public ICollection<IdolGroup> IdolGroups { get; set; }
}