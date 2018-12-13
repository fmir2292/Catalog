using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain {
    class Student : HasId<string> {
        public string Id { get; set; }
        public string Nume { get; set; }
        public int Grupa { get; set; }
        public string Email { get; set; }
        public string CadruIndrumator { get; set; }
        

        public Student(string id, string nume, int grupa, string email, string cadruIndrumator) {
            this.Id = id;
            this.Nume = nume;
            this.Grupa = grupa;
            this.Email = email;
            this.CadruIndrumator = cadruIndrumator;
        }

        public override bool Equals(object obj) {
            var student = obj as Student;
            return student != null &&
                   Id == student.Id &&
                   Nume == student.Nume &&
                   Grupa == student.Grupa &&
                   Email == student.Email &&
                   CadruIndrumator == student.CadruIndrumator;
        }

        public override string ToString() {
            return Id + "," + Nume + "," + Grupa + "," + Email + "," + CadruIndrumator + "\n";
        }

        public override int GetHashCode() {
            var hashCode = 850444802;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nume);
            hashCode = hashCode * -1521134295 + Grupa.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CadruIndrumator);
            return hashCode;
        }
    }
}
