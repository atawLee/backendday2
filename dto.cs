public class IdolGroupDto
{
    public int IdolGroupId { get; set; }
    public string GroupName { get; set; }
    public List<MemberDto> Members { get; set; }
}

public class MemberDto
{
    public int MemberId { get; set; }
    public string MemberName { get; set; }
}
