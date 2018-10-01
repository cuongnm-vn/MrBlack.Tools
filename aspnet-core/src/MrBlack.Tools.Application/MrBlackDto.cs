using System;
using Abp.Application.Services.Dto;

namespace MrBlack.Tools
{
    namespace Abp.Application.Services.Dto
    {
        /// <summary>
        /// Simply implements <see cref="IPagedAndSortedResultRequest"/>.
        /// </summary>
        [Serializable]
        public class PagedFilterAndSortedResultRequestDto : PagedAndSortedResultRequestDto
        {
            public virtual string Filter { get; set; }
        }
    }
}
