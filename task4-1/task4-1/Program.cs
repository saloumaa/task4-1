namespace task4_1
{
    class IdChecker
    {
        public static bool StudentIdExists(List<Student> students, int id)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].StudentId == id)
                    return true;
            }
            return false;
        }

        public static bool CourseIdExists(List<Course> courses, int id)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].CourseId == id)
                    return true;
            }
            return false;
        }

        public static bool InstructorIdExists(List<Instructor> instructors, int id)
        {
            for (int i = 0; i < instructors.Count; i++)
            {
                if (instructors[i].InstructorId == id)
                    return true;
            }
            return false;
        }
    }
    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; }
        public Student(int studentId, string name, int age)
        {
            StudentId = studentId;
            Name = name;
            Age = age;
            Courses = new List<Course>();
        }
        public bool Enroll(Course course)
        {
            if (course == null)
            {
                return false;
            }
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == course.CourseId)
                    return false;
            }
            Courses.Add(course);
            return true;
        }
        public string PrintDetails()
        {
            string courseList = "";

            if (Courses.Count > 0)
            {
                for (int i = 0; i < Courses.Count; i++)
                {
                    courseList += Courses[i].Title;

                    if (i < Courses.Count - 1)
                        courseList += ", ";
                }
            }
            else
            {
                courseList = "None";
            }
            return $"Student id : {StudentId} , Student name: {Name} , Student age: {Age} , courses : {courseList} ";
        }
    }
    class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public Instructor(int instructorId, string name, string specialization)
        {
            InstructorId = instructorId;
            Name = name;
            Specialization = specialization;
        }
        public string PrintDetails() => $"Instructor id: {InstructorId}, Instructor Name: {Name}, Instructor Specialization: {Specialization}";
    }
    class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }
        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            Instructor = instructor;
        }
        public string PrintDetails() => $" Course Id : {CourseId} , Course Title : {Title} , Course Instructor  {Instructor.Name}";
    }
    class StudentManager
    {
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public List<Instructor> Instructors { get; set; }
        public StudentManager()
        {
            Students = new List<Student>();
            Courses = new List<Course>();
            Instructors = new List<Instructor>();
        }
        public bool AddStudent(Student student)
        {
            if (IdChecker.StudentIdExists(Students, student.StudentId))
            {
                return false;
            }

            Students.Add(student);
            return true;
        }
        public bool AddCourse(Course course)
        {
            if (IdChecker.CourseIdExists(Courses, course.CourseId))
            {
                return false;
            }
            Courses.Add(course);
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            if (IdChecker.InstructorIdExists(Instructors, instructor.InstructorId))
            {
                return false;
            }
            Instructors.Add(instructor);
            return true;
        }
        public Student FindStudent(int studentId)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == studentId)
                {
                    return Students[i];
                }
            }
            return null;
        }
        public Course FindCourse(int courseId)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == courseId)
                {
                    return Courses[i];
                }
            }
            return null;
        }
        public Instructor FindInstructor(int instructorId)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructorId)
                {
                    return Instructors[i];
                }
            }
            return null;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            if (student == null || course == null)
                return false;
            for (int i = 0; i < student.Courses.Count; i++)
            {
                if (student.Courses[i].CourseId == course.CourseId)
                {
                    return false;
                }
            }
            student.Courses.Add(course);
            return true;

        }
        public bool IsStudentEnrolledInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            if (student == null || course == null)
                return false;
            for (int i = 0; i < student.Courses.Count; i++)
            {
                if (student.Courses[i].CourseId == course.CourseId)
                {
                    return true;
                }
            }
            return false;
        }
        public string GetInstructorNameByCourseTitle(string courseTitle)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].Title == courseTitle)
                    return Courses[i].Instructor.Name;
            }
            return "Course not found";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            string choice;
            do
            {
                Console.WriteLine("\n--- Student Management System ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Find Student by ID");
                Console.WriteLine("9. Find Course by ID");
                Console.WriteLine("10. Check if Student is Enrolled in Course");
                Console.WriteLine("11. Get Instructor Name by Course Title");
                Console.WriteLine("12. Exit");
                Console.WriteLine("==========================================");
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter student ID: ");
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter student name: ");
                        string studentName = Console.ReadLine();
                        Console.Write("Enter student age: ");
                        int studentAge = Convert.ToInt32(Console.ReadLine());

                        Student newStudent = new Student(studentId, studentName, studentAge);
                        if (manager.AddStudent(newStudent))
                            Console.WriteLine("Student added successfully!");
                        else
                            Console.WriteLine("This student ID already exists!");
                        break;

                    case "2":
                        Console.Write("Enter instructor ID: ");
                        int instId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter instructor name: ");
                        string instName = Console.ReadLine();
                        Console.Write("Enter instructor specialization: ");
                        string instSpec = Console.ReadLine();

                        Instructor newInstructor = new Instructor(instId, instName, instSpec);
                        if (manager.AddInstructor(newInstructor))
                            Console.WriteLine("Instructor added successfully!");
                        else
                            Console.WriteLine("This Instructor ID already exists!");
                        break;

                    case "3":
                        Console.Write("Enter course ID: ");
                        int courseId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter course title: ");
                        string courseTitle = Console.ReadLine();
                        Console.Write("Enter the ID of the instructor for this course: ");
                        int instructorIdForCourse = Convert.ToInt32(Console.ReadLine());

                        Instructor courseInstructor = manager.FindInstructor(instructorIdForCourse);
                        if (courseInstructor != null)
                        {
                            Course newCourse = new Course(courseId, courseTitle, courseInstructor);

                            if (manager.AddCourse(newCourse))
                                Console.WriteLine("Course added successfully!");
                            else
                                Console.WriteLine("This course ID already exists!");
                        }
                        else
                        {
                            Console.WriteLine("Error: Instructor with this ID was not found. Please add the instructor first.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter student ID: ");
                        int sId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter course ID: ");
                        int cId = Convert.ToInt32(Console.ReadLine());

                        bool success = manager.EnrollStudentInCourse(sId, cId);
                        if (success)
                        {
                            Console.WriteLine("Student enrolled in the course successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Error: Could not enroll. Check if Student ID and Course ID are correct.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("\n--- List of All Students ---");
                        for (int i = 0; i < manager.Students.Count; i++)
                        {
                            Console.WriteLine(manager.Students[i].PrintDetails());
                        }
                        break;

                    case "6":
                        Console.WriteLine("\n--- List of All Courses ---");

                        for (int i = 0; i < manager.Courses.Count; i++)
                        {
                            Console.WriteLine(manager.Courses[i].PrintDetails());
                        }
                        break;
                    case "7":
                        Console.WriteLine("\n--- List of All Instructors ---");
                        for (int i = 0; i < manager.Instructors.Count; i++)
                        {
                            Console.WriteLine(manager.Instructors[i].PrintDetails());
                        }
                        break;

                    case "8":
                        Console.Write("Enter student ID to find: ");
                        int idsToFind = Convert.ToInt32(Console.ReadLine());
                        Student foundStudent = manager.FindStudent(idsToFind);
                        if (foundStudent != null)
                        {
                            Console.WriteLine("Student Found: " + foundStudent.PrintDetails());
                        }
                        else
                        {
                            Console.WriteLine("Student with this ID was not found.");
                        }
                        break;
                    case "9":
                        Console.Write("Enter course ID to find: ");
                        int idcToFind = Convert.ToInt32(Console.ReadLine());
                        Course foundcourse = manager.FindCourse(idcToFind);
                        if (foundcourse != null)
                        {
                            Console.WriteLine("course Found: " + foundcourse.PrintDetails());
                        }
                        else
                        {
                            Console.WriteLine("course with this ID was not found.");
                        }
                        break;
                    case "10":
                        Console.Write("Enter Student ID: ");
                        int ssId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Course ID: ");
                        int ccId = Convert.ToInt32(Console.ReadLine());

                        if (manager.IsStudentEnrolledInCourse(ssId, ccId))
                            Console.WriteLine("✅ The student is enrolled in this course.");
                        else
                            Console.WriteLine("❌ The student is NOT enrolled in this course.");
                        break;

                    case "11":
                        Console.Write("Enter Course Title: ");
                        string title = Console.ReadLine();
                        string instructorName = manager.GetInstructorNameByCourseTitle(title);
                        if (instructorName == "Course not found")
                            Console.WriteLine("❌ Course not found. Please check the title and try again.");
                        else
                            Console.WriteLine("✅ Instructor: " + instructorName); 
                        break;
                    case "12":
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            } while (choice != "12");
        }
    }

}




