using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain {
    class Nota {
        public KeyValuePair<string, string> Id { get; set; }
        public Student Student { get; set; }
        public Tema Tema { get; set; }
        public int Valoare { get; set; }
        public int Data { get; set; }
        public string Feedback { get; set; }

        public Nota(KeyValuePair<string, string> id, Student student, Tema tema, int valoare, int data, string feedback) {
            Id = id;
            Student = student;
            Tema = tema;
            Valoare = valoare;
            Data = data;
            Feedback = feedback;
        }

        public override bool Equals(object obj) {
            var nota = obj as Nota;
            return nota != null &&
                   EqualityComparer<KeyValuePair<string, string>>.Default.Equals(Id, nota.Id) &&
                   EqualityComparer<Student>.Default.Equals(Student, nota.Student) &&
                   EqualityComparer<Tema>.Default.Equals(Tema, nota.Tema) &&
                   Valoare == nota.Valoare &&
                   Data == nota.Data &&
                   Feedback == nota.Feedback;
        }

        public override int GetHashCode() {
            var hashCode = 2146038276;
            hashCode = hashCode * -1521134295 + EqualityComparer<KeyValuePair<string, string>>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<Student>.Default.GetHashCode(Student);
            hashCode = hashCode * -1521134295 + EqualityComparer<Tema>.Default.GetHashCode(Tema);
            hashCode = hashCode * -1521134295 + Valoare.GetHashCode();
            hashCode = hashCode * -1521134295 + Data.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Feedback);
            return hashCode;
        }

        public override string ToString() {
            return Id.Key + "," + Id.Value + "," + Valoare + "," + Data + "," + Feedback + "\n";
        }
    }
}
