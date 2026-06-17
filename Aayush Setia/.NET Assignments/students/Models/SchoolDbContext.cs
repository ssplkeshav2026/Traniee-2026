//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using students.Models;

//namespace students.Models;

//public partial class SchoolDbContext : DbContext
//{
//    public SchoolDbContext()
//    {
//    }

//    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Classroom> Classrooms { get; set; }

//    public virtual DbSet<Course> Courses { get; set; }

//    public virtual DbSet<Exam> Exams { get; set; }

//    public virtual DbSet<ExamResults> ExamResults { get; set; }

//    public virtual DbSet<Parent> Parents { get; set; }

//    public virtual DbSet<Student> Students { get; set; }

//    public virtual DbSet<Teacher> Teachers { get; set; }


//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-KKVEEQV\\SQLEXPRESS;Database=SCHOOL;Trusted_Connection=True;TrustServerCertificate=True;");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<ExamResults>(entity =>
//        {
//            entity.HasKey(e => new
//            {
//                e.ExamId,
//                e.StudentId,
//                e.CourseId
//            });

//            entity.HasOne(d => d.Student)
//                .WithMany()
//                .HasForeignKey(d => d.StudentId);

//            entity.HasOne(d => d.Course)
//                .WithMany()
//                .HasForeignKey(d => d.CourseId);

//            entity.HasOne(d => d.Exam)
//                .WithMany()
//                .HasForeignKey(d => d.ExamId);
//        });
//        modelBuilder.Entity<Classroom>(entity =>
//        {
//            entity.HasKey(e => e.ClassroomId).HasName("PK__Classroo__11618EAA1920BF5C");

//            entity.ToTable("Classroom");

//            entity.Property(e => e.Remarks)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.Section)
//                .HasMaxLength(2)
//                .IsUnicode(false)
//                .IsFixedLength();

//            entity.HasOne(d => d.Teacher).WithMany(p => p.Classrooms)
//                .HasForeignKey(d => d.TeacherId)
//                .HasConstraintName("FK__Classroom__Teach__1BFD2C07");
//        });

//        modelBuilder.Entity<Course>(entity =>
//        {
//            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71A707F6335A");

//            entity.ToTable("Course");

//            entity.Property(e => e.Description)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.Name)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//        });

//        modelBuilder.Entity<Exam>(entity =>
//        {
//            entity.HasKey(e => e.ExamId).HasName("PK__Exam__297521C7276EDEB3");

//            entity.ToTable("Exam");

//            entity.Property(e => e.Name)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//        });



//        modelBuilder.Entity<ExamResults>(entity =>
//        {
//            entity.HasKey(e => new { e.StudentId, e.CourseId, e.ExamId });

//            entity.ToTable("exam_result");

//            entity.Property(e => e.StudentId).HasColumnName("StudentId");
//            entity.Property(e => e.CourseId).HasColumnName("CourseId");
//            entity.Property(e => e.ExamId).HasColumnName("ExamId");
//            entity.Property(e => e.Marks)
//                .HasMaxLength(45)
//                .IsUnicode(false)
//                .HasColumnName("marks");
//            entity.Property(e => e.StudentId).HasColumnName("student_id");

//            entity.HasOne(d => d.Course).WithMany()
//                .HasForeignKey(d => d.CourseId)
//                .HasConstraintName("fk_exam_result_course_id");

//            entity.HasOne(d => d.Exam).WithMany()
//                .HasForeignKey(d => d.ExamId)
//                .HasConstraintName("fk_exam_result_exam_id");

//            entity.HasOne(d => d.Student).WithMany()
//                .HasForeignKey(d => d.StudentId)
//                .HasConstraintName("fk_exam_result_student_id");
//        });


//        modelBuilder.Entity<Parent>(entity =>
//        {
//            entity.HasKey(e => e.ParentId).HasName("PK__Parent__D339516F0CBAE877");

//            entity.ToTable("Parent");

//            entity.Property(e => e.Email)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.FName)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.LName)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.LastLoginIP)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.Mobile)
//                .HasMaxLength(15)
//                .IsUnicode(false);
//            entity.Property(e => e.Password)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.Phone)
//                .HasMaxLength(15)
//                .IsUnicode(false);
//        });

//        modelBuilder.Entity<Student>(entity =>
//        {
//            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B99108B795B");

//            entity.ToTable("Student");

//            entity.Property(e => e.Email)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.FName)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.LName)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.LastLoginIP)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.Mobile)
//                .HasMaxLength(15)
//                .IsUnicode(false);
//            entity.Property(e => e.Password)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.Phone)
//                .HasMaxLength(15)
//                .IsUnicode(false);

//            entity.HasOne(d => d.Parent).WithMany(p => p.Students)
//                .HasForeignKey(d => d.ParentId)
//                .HasConstraintName("FK__Student__ParentI__1273C1CD");
//        });

//        modelBuilder.Entity<Teacher>(entity =>
//        {
//            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF2596415502E78");

//            entity.ToTable("Teacher");

//            entity.Property(e => e.Email)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.FName)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.LName)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.LastLoginIP)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.Mobile)
//                .HasMaxLength(15)
//                .IsUnicode(false);
//            entity.Property(e => e.Password)
//                .HasMaxLength(45)
//                .IsUnicode(false);
//            entity.Property(e => e.Phone)
//                .HasMaxLength(15)
//                .IsUnicode(false);
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder); }









using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace students.Models;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext()
    {
    }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamResults> ExamResults { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-KKVEEQV\\SQLEXPRESS;Database=SCHOOL;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
        modelBuilder.Entity<ExamResults>(entity =>
        {
            entity.ToTable("Exam_Result");

            entity.HasKey(e => new
            {
                e.ExamId,
                e.StudentId,
                e.CourseId
            });

            entity.Property(e => e.ExamId)
                .HasColumnName("ExamId");

            entity.Property(e => e.StudentId)
                .HasColumnName("StudentId");

            entity.Property(e => e.CourseId)
                .HasColumnName("CourseId");

            entity.Property(e => e.Marks)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("Marks");

            entity.HasOne(d => d.Student)
                .WithMany()
                .HasForeignKey(d => d.StudentId);

            entity.HasOne(d => d.Course)
                .WithMany()
                .HasForeignKey(d => d.CourseId);

            entity.HasOne(d => d.Exam)
                .WithMany()
                .HasForeignKey(d => d.ExamId);
        });

        
        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.ClassroomId)
                .HasName("PK__Classroo__11618EAA1920BF5C");

            entity.ToTable("Classroom");

            entity.Property(e => e.Remarks)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.Section)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Teacher)
                .WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__Classroom__Teach__1BFD2C07");
        });

      
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId)
                .HasName("PK__Course__C92D71A707F6335A");

            entity.ToTable("Course");

            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        
        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId)
                .HasName("PK__Exam__297521C7276EDEB3");

            entity.ToTable("Exam");

            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        
        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.ParentId)
                .HasName("PK__Parent__D339516F0CBAE877");

            entity.ToTable("Parent");

            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.FName)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.LName)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.LastLoginIP)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.Mobile)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId)
                .HasName("PK__Student__32C52B99108B795B");

            entity.ToTable("Student");

            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.FName)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.LName)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.LastLoginIP)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.Mobile)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Parent)
                .WithMany(p => p.Students)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__Student__ParentI__1273C1CD");
        });

       
        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId)
                .HasName("PK__Teacher__EDF2596415502E78");

            entity.ToTable("Teacher");

            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.FName)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.LName)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.LastLoginIP)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.Mobile)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}