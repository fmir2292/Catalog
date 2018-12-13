using Catalog.Domain;
using Catalog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Service {
    class Service {
        StudentRepository StudentRepository = new StudentRepository();
        TemaRepository TemaRepository = new TemaRepository();
        NotaRepository NotaRepository = new NotaRepository();

        public Dictionary<string, Student> GetStudents() {
            return StudentRepository.FindAll();
        }

        public Dictionary<string, Tema> GetTeme() {
            return TemaRepository.FindAll();
        }

        public Dictionary<KeyValuePair<string, string>, Nota> GetNote() {
            return NotaRepository.FindAll();
        }

        public Tema AddTema(string id, string description, int deadline, int dateReceied) {
            Tema tema = new Tema(id, description, deadline, dateReceied);

            return TemaRepository.Save(tema);
        }

        public void PrelungireTermen(string id, int newDeadline) {
            Tema tema = TemaRepository.FindOne(id);
            if (tema == null) {
                throw new KeyNotFoundException("Tema not found.");
            }

            TemaRepository.Delete(id);
            tema.Deadline = newDeadline;
            TemaRepository.Save(tema);
        }

        public void AddNota(string idStudent, string idTema, int valoare, string feedback) {
            //if (NotaRepository.FindOne(new KeyValuePair<string, string>(idStudent, idTema)) != null) {
            //    throw new KeyNotFoundException("Nota not found.");
            //}

            Student student = StudentRepository.FindOne(idStudent);

            if (student is null) {
                throw new KeyNotFoundException("Student not found.");
            }

            Tema tema = TemaRepository.FindOne(idTema);

            if (tema is null) {
                throw new KeyNotFoundException("Tema not found.");
            }

            int currentWeek = (DateTime.Today.DayOfYear - 1) / 7 + 1 - 39;

            if (currentWeek > tema.Deadline) {
                valoare = valoare - (currentWeek - tema.Deadline) * 2;
            }

            if (valoare < 1) {
                valoare = 1;
            }

            Nota nota = new Nota(new KeyValuePair<string, string>(idStudent, idTema), student, tema, valoare, currentWeek, feedback);
            NotaRepository.Save(nota);
        }

        public void AddValues(int nrOfValues) {
            Random random = new Random();
            Student Student;
            Tema tema;

            for (int i = 0; i < nrOfValues; i++) {
                Student = new Student(i.ToString(), "Nume Prenume " + i, 220 + i % 8, "email" + i + "@domeniu.com", "Profesor" + i);
                StudentRepository.Save(Student);

                tema = new Tema(i.ToString(), "Descriere tema " + i, i % 12 + 2, i % 12 + 2 - random.Next() % 3);
                TemaRepository.Save(tema);
            }
        }
    }
}
