using Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Repository {
    class TemaRepository : CrudRepository<string, Tema> {
        Dictionary<String, Tema> Teme = new Dictionary<string, Tema>();

        public Tema FindOne(string id) {
            if (id is null) {
                throw new ArgumentException("Id can't be null.");
            }

            return Teme[id];
        }

        public Dictionary<string, Tema> FindAll() {
            return Teme;
        }

        public Tema Save(Tema entity) {
            if (entity is null) {
                throw new ArgumentException("Entity can't be null.");
            }

            //if (Teme[entity.Id] != null) {
            //    return entity;
            //}

            Teme.Add(entity.Id, entity);

            return null;
        }

        public Tema Delete(string id) {
            if (id is null) {
                throw new ArgumentException("Id can't be null.");
            }

            Tema tema = FindOne(id);

            if (tema is null) {
                return null;
            }

            Teme.Remove(id);

            return tema;
        }
    }
}
