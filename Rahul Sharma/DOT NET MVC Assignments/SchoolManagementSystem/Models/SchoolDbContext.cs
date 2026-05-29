using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.Models;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext()
    {
    }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<ClassroomStudent> ClassroomStudents { get; set; }

    public virtual DbSet<Cource> Cources { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamResult> ExamResults { get; set; }

    public virtual DbSet<ExamType> ExamTypes { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-RH7UGV2\\SQLEXPRESS;Database=ER;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("attendance");

            entity.Property(e => e.Datee).HasColumnName("datee");
            entity.Property(e => e.Remark)
                .HasColumnType("text")
                .HasColumnName("remark");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("fk_attendance_student_id");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.ClassroomId).HasName("PK__classroo__448E90B887832555");

            entity.ToTable("classroom");

            entity.Property(e => e.ClassroomId)
                .ValueGeneratedNever()
                .HasColumnName("classroom_id");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.Remark)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("remark");
            entity.Property(e => e.Selection)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("selection");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.Yearr).HasColumnName("yearr");

            entity.HasOne(d => d.Grade).WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("fk_classroom_grade");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("fk_classroom_teacher");
        });

        modelBuilder.Entity<ClassroomStudent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("classroom_student");

            entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");
            entity.Property(e => e.StudentId).HasColumnName("Student_id");

            entity.HasOne(d => d.Classroom).WithMany()
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("fk_classroom_studdent_classsrooom_id");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("fk_classroom_student_student_id");
        });

        modelBuilder.Entity<Cource>(entity =>
        {
            entity.HasKey(e => e.CourceId).HasName("PK__Cource__34A71F0B46A43D8A");

            entity.ToTable("Cource");

            entity.Property(e => e.CourceId)
                .ValueGeneratedNever()
                .HasColumnName("Cource_id");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Grade).WithMany(p => p.Cources)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK__Cource__grade_id__04E4BC85");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__exam__9C8C7BE99F3C98E1");

            entity.ToTable("exam");

            entity.Property(e => e.ExamId)
                .ValueGeneratedNever()
                .HasColumnName("exam_id");
            entity.Property(e => e.ExamTypeId).HasColumnName("exam_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.ExamType).WithMany(p => p.Exams)
                .HasForeignKey(d => d.ExamTypeId)
                .HasConstraintName("fk_exam_exam_type_id");
        });

        modelBuilder.Entity<ExamResult>(entity =>
        {entity.HasKey(e => new { e.StudentId, e.CourceId, e.ExamId });

                entity.ToTable("exam_result");

            entity.Property(e => e.StudentId).HasColumnName("Student_id");
            entity.Property(e => e.CourceId).HasColumnName("course_id");
            entity.Property(e => e.ExamId).HasColumnName("exam_id");
            entity.Property(e => e.Marks)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("marks");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Cource).WithMany()
                .HasForeignKey(d => d.CourceId)
                .HasConstraintName("fk_exam_result_course_id");

            entity.HasOne(d => d.Exam).WithMany()
                .HasForeignKey(d => d.ExamId)
                .HasConstraintName("fk_exam_result_exam_id");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("fk_exam_result_student_id");
        });

        modelBuilder.Entity<ExamType>(entity =>
        {
            entity.ToTable("exam_type");

            entity.Property(e => e.ExamTypeId)
                .ValueGeneratedNever()
                .HasColumnName("exam_type_id");
            entity.Property(e => e.Descc)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("descc");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__grade__D44275EB87389B04");

            entity.ToTable("grade");

            entity.Property(e => e.GradeId)
                .ValueGeneratedNever()
                .HasColumnName("Grade_id");
            entity.Property(e => e.Descc)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("descc");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.ParentId).HasName("PK__parent__F2A608196CF0DDE2");

            entity.ToTable("parent");

            entity.Property(e => e.ParentId)
                .ValueGeneratedNever()
                .HasColumnName("parent_id");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Fname)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("fname");
            entity.Property(e => e.LastLoginDate).HasColumnName("last_login_date");
            entity.Property(e => e.LastLoginIp)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("last_login_ip");
            entity.Property(e => e.Lname)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("lname");
            entity.Property(e => e.Mobile)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("mobile");
            entity.Property(e => e.Passwordd)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("passwordd");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__student__2A33069AFA4711F5");

            entity.ToTable("student");

            entity.Property(e => e.StudentId)
                //.ValueGeneratedNever()
                .HasColumnName("student_id");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Fname)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("fname");
            entity.Property(e => e.LastLoginDate).HasColumnName("last_login_date");
            entity.Property(e => e.LastLoginIp)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("last_login_ip");
            entity.Property(e => e.Lname)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("lname");
            entity.Property(e => e.Mobile)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("mobile");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Passwordd)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("passwordd");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Parent).WithMany(p => p.Students)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("fk_student_parent_id");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__teacher__03AE777EE042AD4B");

            entity.ToTable("teacher");

            entity.Property(e => e.TeacherId)
                .ValueGeneratedNever()
                .HasColumnName("teacher_id");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fname");
            entity.Property(e => e.Laname)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("laname");
            entity.Property(e => e.LastLoginDate).HasColumnName("last_login_date");
            entity.Property(e => e.LastLoginIp)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("last_login_ip");
            entity.Property(e => e.Mobile)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("mobile");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Passwordd)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("passwordd");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
