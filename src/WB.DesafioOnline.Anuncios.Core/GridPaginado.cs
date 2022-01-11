using System.Collections.Generic;

namespace WB.DesafioOnline.Anuncios.Core
{
    public class GridPaginado<T> where T : class
    {
        public IEnumerable<T> Lista { get; set; }
        public int TotalRegistros { get; set; }
        public int Pagina { get; set; }
        public int Tamano { get; set; }
    }
}
