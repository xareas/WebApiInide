namespace Inide.WebServices.Application.RequestModels
{
    public class UrlQueryParameters
    {
        /// <summary>
        /// Maximo elementos permitidos
        /// </summary>
        const int maxPageSize = 50;
        private int _pageSize = 10;
        
        /// <summary>
        /// Numero de Pagina
        /// </summary>
        public int PageNumber { get; set; } = 1;
        
        /// <summary>
        /// Tamaño de registro a obtener por pagina
        /// </summary>
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        /// <summary>
        /// Incluir el total de registros
        /// </summary>
        public bool IncludeCount { get; set; } = true;
        
        /// <summary>
        /// Registros a saltar
        /// </summary>
        public int Skip => (PageNumber * PageSize) - PageSize;
    }
}
