using IMS.database.entity;
using Microsoft.EntityFrameworkCore;

namespace IMS.database.context;

public class ImsContext :DbContext
{
    private ILogger<ImsContext> _logger;

    public DbSet<IdolGroup> IdolGroup { get; set; }
    public DbSet<Member> Member { get; set; }

    public ImsContext(DbContextOptions<ImsContext> options, ILogger<ImsContext> logger)
        : base(options)
    {
        _logger = logger;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "ims.db");

        // SQLite 데이터베이스 연결을 설정합니다.
        optionsBuilder.UseSqlite($"Data Source={dbPath}");

        // optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;password=dlwhdgns;database=Ims",
        //         new MySqlServerVersion(new Version(8, 0, 33)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdolGroup>()
                    .HasMany(ig => ig.Members)
                    .WithMany(m => m.IdolGroups)
                    .UsingEntity<IdolGroupLinkMember>(
                    j => j
                    .HasOne<Member>()
                    .WithMany()
                    .HasForeignKey(iglm => iglm.MemberId),
                    j => j
                    .HasOne<IdolGroup>()
                    .WithMany()
                    .HasForeignKey(iglm => iglm.IdolGroupId),
                j =>
                {
                    j.HasKey(iglm => new { iglm.IdolGroupId, iglm.MemberId }); // 복합 키 설정
                });
    }
}
