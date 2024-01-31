using System.ComponentModel.DataAnnotations;

namespace IMS.database.entity;
public class IdolGroupLinkMember {
    [Key]
    public int IdolGroupId {get;set;}
    [Key]
    public int MemberId {get;set;}
}