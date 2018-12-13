using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain {
    class Tema : HasId<string> {
        public string Id { get; set; }
        public string Description { get; set; }
        public int Deadline { get; set; }
        public int DateReceived { get; set; }

        public Tema(string id, string description, int deadline, int dateReceived) {
            this.Id = id;
            this.Description = description;
            this.Deadline = deadline;
            this.DateReceived = dateReceived;
        }

        public override bool Equals(object obj) {
            var tema = obj as Tema;
            return tema != null &&
                   Id == tema.Id &&
                   Description == tema.Description &&
                   Deadline == tema.Deadline &&
                   DateReceived == tema.DateReceived;
        }

        public override int GetHashCode() {
            var hashCode = -544210588;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + Deadline.GetHashCode();
            hashCode = hashCode * -1521134295 + DateReceived.GetHashCode();
            return hashCode;
        }

        public override string ToString() {
            return Id + "," + Description + "," + Deadline + "," + DateReceived + "\n";
        }
    }
}
