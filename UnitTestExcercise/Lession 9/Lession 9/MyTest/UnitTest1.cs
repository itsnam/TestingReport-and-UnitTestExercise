using StudentServiceLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Score8_Should_ReturnA()
        {
            Student s = new Student();
            s.Id = 1;
            s.Name = "Toan";
            s.Age = 30;
            s.Score = 8;

            char letter = s.getLetterScore();
            Assert.AreEqual('A', letter);
        }

        [TestMethod]
        public void Score7_Should_ReturnB()
        {
            Student s = new Student();
            s.Id = 1;
            s.Name = "Toan";
            s.Age = 30;
            s.Score = 7;

            char letter = s.getLetterScore();
            Assert.AreEqual('B', letter);
        }

        [TestMethod]
        public void Score5_Should_ReturnC()
        {
            Student s = new Student();
            s.Id = 1;
            s.Name = "Toan";
            s.Age = 30;
            s.Score = 5;

            char letter = s.getLetterScore();
            Assert.AreEqual('C', letter);
        }

        [TestMethod]
        public void Score3Half_Should_ReturnD()
        {
            Student s = new Student();
            s.Id = 1;
            s.Name = "Toan";
            s.Age = 30;
            s.Score = 3.5;

            char letter = s.getLetterScore();
            Assert.AreEqual('D', letter);
        }

        [TestMethod]
        public void addFirst_ShouldSuccess_AndReturnTrue()
        {
            StudentService sv = new StudentService();
            Student s = new Student() { Id = 1, Name = "Toan", Age = 20, Score = 9 };

            bool status = sv.addStudent(s);
            Assert.IsTrue(status);

            int size = sv.size();
            Assert.AreEqual(1, size);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AddStudentnotnull()
        {
            StudentService sv = new StudentService();
            Student s = new Student() {};

            sv.addStudent(s);
        }

        [TestMethod]
        public void AddStudentnoteuqalidbefore()
        {
            StudentService sv = new StudentService();
            Student s = new Student() { Id = 1, Name = "Toan", Age = 20, Score = 9 };
            sv.addStudent(s);
            Student a = new Student() { Id = 1, Name = "Toan", Age = 20, Score = 9 };
            bool status = sv.addStudent(a);
            Assert.IsFalse(status);

        }
        [TestMethod]
        [ExpectedException(typeof(SystemException), "Score must not exeed 10.0")]
        public void ScoreGreaterThan10()
        {
            Student s = new Student() { Id = 1, Name = "Toan", Age = 20, Score = 11 };
        }

        [TestMethod]
        public void TestGetStudentAt()
        {
            StudentService studentService = new StudentService();
            Student student1 = new Student { Id = 1, Name = "Alice", Age = 20, Score = 90 };
            studentService.addStudent(student1);

            Student result = studentService.getStudentAt(0);

            Assert.AreEqual(student1, result);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Index 0 is not available in this array")]
        public void TestGetStudentAt_InvalidIndex()
        {
            StudentService studentService = new StudentService();

            Student result = studentService.getStudentAt(0);
        }

        [TestMethod]
        public void FindStudentByAge()
        {
            StudentService studentService = new StudentService();
            Student student1 = new Student { Id = 1, Name = "Alice", Age = 20, Score = 90 };
            Student student2 = new Student { Id = 2, Name = "Bob", Age = 21, Score = 85 };
            studentService.addStudent(student1);
            studentService.addStudent(student2);

            Student result = studentService.findStudentByAge(21);

            Assert.AreEqual(student2, result);
        }

        [TestMethod]
        public void FindStudentByAge_NotFound()
        {
            StudentService studentService = new StudentService();
            Student student1 = new Student { Id = 1, Name = "Alice", Age = 20, Score = 90 };
            studentService.addStudent(student1);

            Student result = studentService.findStudentByAge(22);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAverageScore()
        {
            StudentService studentService = new StudentService();
            Student student1 = new Student { Id = 1, Name = "Alice", Age = 20, Score = 90 };
            Student student2 = new Student { Id = 2, Name = "Bob", Age = 21, Score = 85 };
            studentService.addStudent(student1);
            studentService.addStudent(student2);

            double result = studentService.getAverageScore();

            Assert.AreEqual(87.5, result);
        }

        [TestMethod]
        [ExpectedException(typeof(SystemException), "Student list is empty")]
        public void GetAverageScore_EmptyList()
        {
            StudentService studentService = new StudentService();

            double result = studentService.getAverageScore();
        }

        [TestMethod]
        public void FindStudentWithMinScore()
        {
            StudentService studentService = new StudentService();
            Student student1 = new Student { Id = 1, Name = "Alice", Age = 20, Score = 90 };
            Student student2 = new Student { Id = 2, Name = "Bob", Age = 21, Score = 85 };
            studentService.addStudent(student1);
            studentService.addStudent(student2);

            Student result = studentService.findStudentWithMinScore();

            Assert.AreEqual(student2, result);
        }

        [TestMethod]
        public void FindStudentWithMinScore_EmptyList()
        {
            StudentService studentService = new StudentService();

            Student result = studentService.findStudentWithMinScore();

            Assert.IsNull(result);
        }
    }
}