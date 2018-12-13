using Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Repository {
    class NotaRepository : CrudRepository<KeyValuePair<string, string>, Nota> {
        Dictionary<KeyValuePair<string, string>, Nota> Note = new Dictionary<KeyValuePair<string, string>, Nota>();

        public Nota FindOne(KeyValuePair<string, string> id) {
            if (id.Key is null || id.Value is null) {
                throw new ArgumentException("Id can't be null.");
            }

            return Note[id];
        }

        public Dictionary<KeyValuePair<string, string>, Nota> FindAll() {
            return Note;
        }

        public Nota Save(Nota entity) {
            if (entity is null) {
                throw new ArgumentException("Entity can't be null.");
            }

            //if (Note[entity.Id] != null) {
            //    return entity;
            //}

            Note.Add(entity.Id, entity);

            return null;
        }

        public Nota Delete(KeyValuePair<string, string> id) {
            if (id.Key is null || id.Value is null) {
                throw new ArgumentException("Id can't be null.");
            }

            Nota nota = FindOne(id);

            if (nota is null) {
                return null;
            }

            Note.Remove(id);

            return nota;
        }
    }
}
