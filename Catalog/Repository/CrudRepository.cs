using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Repository {
    interface CrudRepository<ID, E> {
        E FindOne(ID id);
        Dictionary<ID, E> FindAll();
        E Save(E entity);
        E Delete(ID id);
    }
}
