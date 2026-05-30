using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Models;

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

    public virtual DbSet<ClassroomStudent> ClassroomStudents { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamResult> ExamResults { get; set; }

    public virtual DbSet<ExamType> ExamTypes { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<UserDatum> UserData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("attendance");

            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Remark)
                .HasColumnType("text")
                .HasColumnName("remark");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__attendanc__stude__02084FDA");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.ClassroomId).HasName("PK__classroo__448E90B8F861296B");

            entity.ToTable("classroom");

            entity.Property(e => e.ClassroomId)
                .ValueGeneratedNever()
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

            entity.HasOne(d => d.Grade).WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK__classroom__grade__70DDC3D8");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__classroom__teach__71D1E811");
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
                .HasConstraintName("FK__classroom__class__76969D2E");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__classroom__stude__778AC167");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__course__8F1EF7AE6974867F");

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
                .HasConstraintName("FK__course__grade_id__74AE54BC");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__exam__9C8C7BE9016FFE43");

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
                .HasConstraintName("FK__exam__exam_type___7C4F7684");
        });

        modelBuilder.Entity<ExamResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK_ExamResult");

            entity.ToTable("exam_result");

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.ExamId).HasColumnName("exam_id");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Course).WithMany(p => p.ExamResults)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__exam_resu__cours__00200768");

            entity.HasOne(d => d.Exam).WithMany(p => p.ExamResults)
                .HasForeignKey(d => d.ExamId)
                .HasConstraintName("FK__exam_resu__exam___7E37BEF6");

            entity.HasOne(d => d.Student).WithMany(p => p.ExamResults)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__exam_resu__stude__7F2BE32F");
        });

        modelBuilder.Entity<ExamType>(entity =>
        {
            entity.HasKey(e => e.ExamTypeId).HasName("PK__exam_typ__FAB1396D1DFF317D");

            entity.ToTable("exam_type");

            entity.Property(e => e.ExamTypeId)
                .ValueGeneratedNever()
                .HasColumnName("exam_type_id");
            entity.Property(e => e.Desc)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("desc");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__grade__3A8F732C3034349D");

            entity.ToTable("grade");

            entity.Property(e => e.GradeId)
                .ValueGeneratedNever()
                .HasColumnName("grade_id");
            entity.Property(e => e.Desc)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("desc");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.ParentId).HasName("PK__parent__F2A60819B46904D3");

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
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("mobile");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__student__2A33069A9FCB4F4B");

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
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false);
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
                .HasConstraintName("FK__student__parent___6E01572D");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__teacher__03AE777EB6EF57E5");

            entity.ToTable("teacher");

            entity.Property(e => e.TeacherId)
                .ValueGeneratedNever()
                .HasColumnName("teacher_id");
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
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("mobile");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("status");
        });

        modelBuilder.Entity<UserDatum>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
