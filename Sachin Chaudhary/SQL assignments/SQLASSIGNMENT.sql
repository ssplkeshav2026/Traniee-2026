
CREATE TABLE parent(
    parent_id INT PRIMARY KEY,
      email varchar(45),
    [password] varchar(45),
    fname varchar(45),
      lname varchar(45),   
    dob DATE,
    phone varchar(45),
      mobile varchar(45),
    [status] BIT,
    last_login_date DATE,
      last_login_ip varchar(45))
);


CREATE TABLE teacher(
    teacher_id INT PRIMARY KEY,
       email varchar(45),
    password varchar(45),
    fname varchar(45),
    lname varchar(45),
       dob DATE,
    phone varchar(45),
    mobile varchar(45),
      [status] varchar(45),
      last_login_date DATE,
    last_login_ip varchar(45)
);

CREATE TABLE grade(
    grade_id INT PRIMARY KEY,
     [ name] varchar(45),
    [desc] varchar(45)
);


CREATE TABLE student(
    student_id INT PRIMARY KEY,
      email VARCHAR(45),
    password VARCHAR(45),
      fname VARCHAR(45),
    lname VARCHAR(45),
      dob DATE,
    phone VARCHAR(15),
    mobile VARCHAR(15),
      parent_id INT,
      date_of_join DATE,
      [status] BIT,
    last_login_date DATE,
      last_login_ip varchar(45),
    FOREIGN KEY (parent_id) REFERENCES parent(parent_id)
);


CREATE TABLE classroom(
      classroom_id INT PRIMARY KEY,
    [Year] DATE,
      section CHAR(2),
    status BIT,
      remarks varchar(45),
    teacher_id INT,
      grade_id INT,
    FOREIGN KEY (grade_id) REFERENCES grade(grade_id),
      FOREIGN KEY (teacher_id) REFERENCES teacher(teacher_id)
);


CREATE TABLE course(
    course_id INT PRIMARY KEY,
      name varchar(45),
      description varchar(45),
      grade_id INT,
    FOREIGN KEY (grade_id) REFERENCES grade(grade_id)
);


CREATE TABLE classroom_student(
    classroom_id INT,
      student_id INT,
    FOREIGN KEY (classroom_id) REFERENCES classroom(classroom_id),
      FOREIGN KEY (student_id) REFERENCES student(student_id)
);


CREATE TABLE exam_type(
    exam_type_id INT PRIMARY KEY,
      [name] varchar(45),
    [desc] varchar(45)
);


CREATE TABLE exam(
    exam_id INT PRIMARY KEY,
    exam_type_id INT,
     [name] varchar(45),
    start_date DATE,
    FOREIGN KEY (exam_type_id) REFERENCES exam_type(exam_type_id)
);


CREATE TABLE exam_result(
    exam_id INT,
    student_id INT,
      course_id INT,
    marks INT,
      FOREIGN KEY (exam_id) REFERENCES exam(exam_id),
     FOREIGN KEY (student_id) REFERENCES student(student_id),
    FOREIGN KEY (course_id) REFERENCES course(course_id)
);


CREATE TABLE attendance(
    [date] DATE,
    student_id INT,
      [status] BIT,
    remark TEXT,
    FOREIGN KEY (student_id) REFERENCES student(student_id)
);
