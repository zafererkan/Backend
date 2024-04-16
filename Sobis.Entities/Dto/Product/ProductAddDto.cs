﻿using Sobis.Core.Entities.Concrete;

namespace Sobis.Entities.Dto.Product
{
    public class ProductAddDto : DtoAddBase
    {
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public string Description { get; set; }
        public int? MinBudget { get; set; }
        public int? MaxBudget { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? ProductTypeId { get; set; }
    }
}