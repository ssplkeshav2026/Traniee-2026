using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace First.netAssigmnet.Models;

public partial class SchooErpContext : DbContext
{
    public SchooErpContext()
    {
    }

    public SchooErpContext(DbContextOptions<SchooErpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<ClassroomStudent> ClassroomStudent { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamResult> ExamResults { get; set; }

    public virtual DbSet<ExamType> ExamTypes { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Grade1> Grade1s { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("attendence");

            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Remark)
                .HasColumnType("text")
                .HasColumnName("remark");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__attendenc__remar__6FE99F9F");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.ClassroomId).HasName("PK__classroo__448E90B80BBEFE3F");

            entity.ToTable("classroom");

            entity.Property(e => e.ClassroomId)
                .ValueGeneratedOnAdd()
                .HasColumnName("classroom_id");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.Remarks)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("remarks");
            entity.Property(e => e.Section)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("section");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Grade).WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK__classroom__teach__60A75C0F");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__classroom__teach__619B8048");
        });

        modelBuilder.Entity<ClassroomStudent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("classroom_student");

            entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Classroom).WithMany()
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("FK__classroom__stude__71D1E811");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__classroom__stude__72C60C4A");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__course__8F1EF7AEC0C149D1");

            entity.ToTable("course");

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("course_id");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Grade).WithMany(p => p.Courses)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK__course__grade_id__693CA210");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__exam__9C8C7BE974152CBA");

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
                .HasForeignKey(d => d.ExamTypeId);
                //.HasConstraintName("FK__exam__start_date__66603565");
        });


        modelBuilder.Entity<ExamResult>(entity =>
        {
            entity.HasKey(e => new
            {
                e.StudentId,
                e.CourseId,
                e.ExamId
            });
            entity.ToTable("exam_result");

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.ExamId).HasColumnName("exam_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.Property(e => e.Marks)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("marks");

            entity.HasOne(d => d.Course)
                .WithMany()
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__exam_resu__cours__76969D2E");

            entity.HasOne(d => d.Exam)
                .WithMany()
                .HasForeignKey(d => d.ExamId)
                .HasConstraintName("FK__exam_resu__marks__74AE54BC");

            entity.HasOne(d => d.Student)
                .WithMany()
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__exam_resu__stude__75A278F5");
        });

        modelBuilder.Entity<ExamType>(entity =>
        {
            entity.HasKey(e => e.ExamTypeId).HasName("PK__exam_typ__FAB1396D706C4F50");

            entity.ToTable("exam_type");

            entity.Property(e => e.ExamTypeId)
                .ValueGeneratedNever()
                .HasColumnName("exam_type_id");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__grade__3A8F732CA66C867C");

            entity.ToTable("grade");

            entity.Property(e => e.GradeId)
                .ValueGeneratedNever()
                .HasColumnName("grade_id");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Grade1>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__grade1__3A8F732C99D991F7");

            entity.ToTable("grade1");

            entity.Property(e => e.GradeId)
                .ValueGeneratedNever()
                .HasColumnName("grade_id");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.ParentId).HasName("PK__parent__F2A6081951814686");

            entity.ToTable("parent");

            entity.Property(e => e.ParentId)
                .ValueGeneratedNever()
                .HasColumnName("parent_id");
            entity.Property(e => e.DateOfJoin).HasColumnName("date_of_join");
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
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__student__2A33069AEAF94691");

            entity.ToTable("student");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("student_id");
            entity.Property(e => e.DateOfJoin).HasColumnName("date_of_join");
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
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Parent).WithMany(p => p.Students)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__student__last_lo__6E01572D");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__teacher__03AE777E2E87B2BA");

            entity.ToTable("teacher");

            entity.Property(e => e.TeacherId)
                .ValueGeneratedNever()
                .HasColumnName("teacher_id");
            entity.Property(e => e.DateOfJoin).HasColumnName("date_of_join");
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
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("password");
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
