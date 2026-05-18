create database school_erp;
use school_erp;

--Grade Table--
create table grade (
    grade_id int primary key, name varchar (45), [desc] varchar(45));

--Teacher Table--
create table teacher (
     teacher_id int primary key, email varchar(45), password varchar(45), fname varchar(45), lname varchar(45), dob date, phone varchar(15), mobile varchar(15), status bit, last_login_date date, last_login_ip varchar(45)
);

--Classroom Table--
drop table classroom;
create table classroom (
		classroom_id INT primary key, year int, grade_id INT, section CHAR(2), status BIT, remarks varchar(45), teacher_id INT, 
        constraint FK_classroom_grade foreign key (grade_id) references grade(grade_id),
        constraint FK_classroom_teacher foreign key (teacher_id) references teacher(teacher_id)
);

--Parent Table--
create table parent (
      parent_id int primary key, email varchar(45), password varchar(45), fname varchar(45), lname varchar(45), dob date, phone varchar(15), mobile varchar(15), status bit, last_login_date date, last_login_ip varchar(45)
);

--Student Table--
create table student (
    student_id int primary key, email varchar(45), password varchar(45), fname varchar(45), lname varchar(45), dob date, phone varchar(15), mobile varchar(15), parent_id int, date_of_join date, status bit, last_login_date date, last_login_ip varchar(45),
    constraint FK_student_parent
    foreign key (parent_id) references parent(parent_id)
);

--Course Table--
create table course (
    course_id int primary key, name varchar(45), description varchar(45), grade_id int,
    constraint FK_course_grade
    foreign key (grade_id) references grade(grade_id)
);

--Classroom-Student--
create table classroom_student (
    classroom_id int, student_id int, primary key (classroom_id, student_id),
    constraint FK_cs_classroom
    foreign key (classroom_id) references classroom(classroom_id),
    CONSTRAINT FK_cs_student
    foreign key (student_id) references student(student_id)
);

--Attendence--
create table attendance (
    [date] date, student_id int, status bit, remark text, primary key ([date], student_id), 
    constraint FK_attendance_student
    foreign key (student_id) references student(student_id)
);

--Exam-Result--
create table exam_type (
    exam_type_id int primary key, name varchar(45), [desc] varchar(45)
);

--exam--
create table exam (
    exam_id int primary key, exam_type_id int, name varchar(45), start_date date,
    constraint FK_exam_examtype
    foreign key (exam_type_id) references exam_type(exam_type_id)
);

--exam_result--
create table exam_result (
    exam_id int, student_id int, course_id int, marks varchar(45), primary key (exam_id, student_id, course_id),
    constraint FK_er_exam
    foreign key (exam_id) references exam(exam_id),
    constraint FK_er_student
    foreign key (student_id) references student(student_id),
    constraint FK_er_course
    foreign key (course_id) references course(course_id)
);