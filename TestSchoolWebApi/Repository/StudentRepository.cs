﻿using TestSchool.Models;

namespace TestSchool.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private SchoolDbContext _context;

        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }
        public int AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student.StudentId;
        }

        public Student GetStudent(int id)
        {
            return _context.Students.FirstOrDefault(u => u.StudentId == id);
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public void UpdateStudent(Student student)
        {
            var studentExist = GetStudent(student.StudentId);

            studentExist.StudentId = student.StudentId;
            studentExist.LastName = student.LastName;
            studentExist.FirstName = student.FirstName;
            studentExist.AddressId = student.AddressId;

            _context.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}
