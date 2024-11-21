using GestAca.Entities;
using GestAca.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace GestAcaPersistenceTests
{
    [TestClass]
    public class BaseTest
    {
        protected private EntityFrameworkDAL dal;

        private static bool HasRequiredAnnotation(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(false);
            Attribute[] attrs = System.Attribute.GetCustomAttributes(property);
            return attrs.Any((attr) =>
            {
                return attr is RequiredAttribute;
            });

        }

        private static bool HasKeyAnnotation(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(false);
            Attribute[] attrs = System.Attribute.GetCustomAttributes(property);
            return attrs.Any((attr) =>
            {
                return attr is KeyAttribute;
            });

        }

        private static bool HasDatabaseGeneratedOptionNone(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(false);
            Attribute[] attrs = System.Attribute.GetCustomAttributes(property);
            return attrs.Any((attr) =>
            {
                if (attr is DatabaseGeneratedAttribute)
                {
                    DatabaseGeneratedAttribute dbGenAtt = attr as DatabaseGeneratedAttribute;
                    return dbGenAtt.DatabaseGeneratedOption == DatabaseGeneratedOption.None;
                }
                else return false;
                    
        
            });

        }

        [TestInitialize]
        public void IniTests()
        {
            // Si no hacemos este test aquí da otra excepción que no es trivial
            // para los alumnos saber qué está ocurriendo
            // Con estos assert sabrán que han de añadir los Required
            // Required en Enrollment: TaughtCourse y Student
            // Required en TaughtCourse: Course
            
            Assert.IsTrue(HasRequiredAnnotation(typeof(Enrollment).GetProperty("TaughtCourse")), "Property named \"TaughtCourse\" in \"Enrollment\" class should have Data Annotation [Required]");
            Assert.IsTrue(HasRequiredAnnotation(typeof(Enrollment).GetProperty("Student")), "Property named \"Student\" in \"Enrollment\" class should have Data Annotation [Required]");
            Assert.IsTrue(HasRequiredAnnotation(typeof(TaughtCourse).GetProperty("Course")), "Property named \"Course\" in \"TaughtCourse\" class should have Data Annotation [Required]");
           
            //Key Annotations
            Assert.IsTrue(HasKeyAnnotation(typeof(Classroom).GetProperty("Name")), "Property named \"Name\" in \"Classroom\" class should have Data Annotation [Key]");
            Assert.IsTrue(HasKeyAnnotation(typeof(Course).GetProperty("Name")), "Property named \"Name\" in \"Course\" class should have Data Annotation [Key]");

            //DatabaseGeneratedOption
            Assert.IsTrue(HasDatabaseGeneratedOptionNone(typeof(TaughtCourse).GetProperty("Id")), "Property named \"Id\" in \"TaughtCourse\" class should have Data Annotation [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]");
           
            dal = new EntityFrameworkDAL(new GestAcaDbContext());
            dal.RemoveAllData();
        }
        [TestCleanup]
        public void CleanTests()
        {
            dal.RemoveAllData();
        }
    }
}
