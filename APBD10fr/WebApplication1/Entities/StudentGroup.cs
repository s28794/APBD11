namespace WebApplication1.Entities;

public class StudentGroup
{
    public int IdGroup { get; set; }

    public int IdStudent { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Group Group { get; set; }
    
    public virtual Student Student { get; set; }

    public virtual ICollection<StudentGroup> StudentGroups { get; set; } = new List<StudentGroup>();
}