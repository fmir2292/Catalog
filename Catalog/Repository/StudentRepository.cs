using Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Repository {
    class StudentRepository : CrudRepository<string, Student> {
        Dictionary<String, Student> Students = new Dictionary<String, Student>();

        public Student FindOne(string id) {
            if (id is null) {
                throw new ArgumentException("Id can't be null.");
            }
            return Students[id];
        }

        public Dictionary<String, Student> FindAll() {
            return Students;
        }

        public Student Save(Student entity) {
            if (entity is null) {
                throw new ArgumentException("Entity can't be null.");
            }

            //if (Students[entity.Id] != null) {
            //    return entity;
            //}

            Students.Add(entity.Id, entity);

            return null;
        }

        public Student Delete(string id) {
            if (id is null) {
                throw new ArgumentException("Id can't be null.");
            }

            Student student = FindOne(id);
            if (student is null) {
                return null;
            }

            Students.Remove(student.Id);

            return student;
        }
    }
}
