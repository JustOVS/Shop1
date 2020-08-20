using AutoMapper;
using Shop.API.Models.OutputModels;
using Shop.Data.Dto;
using System.Collections.Generic;
using System.Linq;


namespace Shop.API.Configuration
{
    public class ProductToCategoryMapper
    {
        private IMapper _mapper;
        public ProductToCategoryMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
        public BaseProductOutputModel MapToCategory(ProductDto p)
        {
            if (p.NoiseLevel != null && p.Power != null && p.NumberOfNozzles != null)
                return _mapper.Map<VacuumCleanerOutputModel>(p);

            if (p.NoiseLevel != null && p.DryingMode != null && p.Volume != null)
                return _mapper.Map<WashingMachineOutputModel>(p);

            if (p.NumberOfRecipes != null && p.Power != null && p.NumberOfModes != null)
                return _mapper.Map<MicrowaveOutputModel>(p);

            if (p.NumberOfRecipes != null && p.DescalingProtection != null && p.NumberOfCompartments != null)
                return _mapper.Map<KitchenStoveOutputModel>(p);

            if (p.Volume != null && p.Power != null && p.DescalingProtection != null)
                return _mapper.Map<KettleOutputModel>(p);

            if (p.NumberOfRecipes != null && p.Volume != null && p.NumberOfModes != null)
                return _mapper.Map<CoffeeMakerOutputModel>(p);

            if (p.NoiseLevel != null && p.DryingMode != null && p.NumberOfCompartments != null)
                return _mapper.Map<DishwasherOutputModel>(p);

            if (p.NumberOfRecipes != null && p.Volume != null && p.DescalingProtection != null)
                return _mapper.Map<MulticookerOutputModel>(p);

            if (p.NumberOfRecipes != null && p.NumberOfCompartments != null && p.NumberOfModes != null)
                return _mapper.Map<ToasterOutputModel>(p);

            if (p.DryingMode != null && p.DescalingProtection != null && p.NumberOfModes != null)
                return _mapper.Map<IronOutputModel>(p);

            if (p.DescalingProtection != null && p.Power != null && p.NumberOfNozzles != null)
                return _mapper.Map<MixerOutputModel>(p);

            if (p.DryingMode != null && p.AirSpeed != null && p.NumberOfNozzles != null)
                return _mapper.Map<HairdryerOutputModel>(p);

            if (p.NoiseLevel != null && p.Power != null && p.AirSpeed != null)
                return _mapper.Map<FanOutputModel>(p);

            return null;
        }
        public dynamic MapToCategory(List<ProductDto> products)
        {
            var result = new List<dynamic>();
            foreach (var p in products)
            {
                result.Add(MapToCategory(p));
            }
            return result;
        }

        public dynamic SelectOfDesiredCategory(List<ProductDto> products, int categoryId)
        {
            switch (categoryId)
            {
                case 1:
                    {
                        var selectedProducts = products.Where(p => p.NoiseLevel != null && p.Power != null && p.NumberOfNozzles != null).ToList();
                        return _mapper.Map<List<VacuumCleanerOutputModel>>(selectedProducts);
                    }
                case 2:
                    {
                        var selectedProducts = products.Where(p => p.NoiseLevel != null && p.DryingMode != null && p.Volume != null).ToList();
                        return _mapper.Map<List<WashingMachineOutputModel>>(selectedProducts);
                    }
                case 3:
                    {
                        var selectedProducts = products.Where(p => p.NumberOfRecipes != null && p.Power != null && p.NumberOfModes != null).ToList();
                        return _mapper.Map<List<MicrowaveOutputModel>>(selectedProducts);
                    }
                case 4:
                    {
                        var selectedProducts = products.Where(p => p.NumberOfRecipes != null && p.DescalingProtection != null && p.NumberOfCompartments != null).ToList();
                        return _mapper.Map<List<KitchenStoveOutputModel>>(selectedProducts);
                    }
                case 5:
                    {
                        var selectedProducts = products.Where(p => p.Volume != null && p.Power != null && p.DescalingProtection != null).ToList();
                        return _mapper.Map<List<KettleOutputModel>>(selectedProducts);
                    }
                case 6:
                    {
                        var selectedProducts = products.Where(p => p.NumberOfRecipes != null && p.Volume != null && p.NumberOfModes != null).ToList();
                        return _mapper.Map<List<CoffeeMakerOutputModel>>(selectedProducts);
                    }
                case 7:
                    {
                        var selectedProducts = products.Where(p => p.NoiseLevel != null && p.DryingMode != null && p.NumberOfCompartments != null).ToList();
                        return _mapper.Map<List<DishwasherOutputModel>>(selectedProducts);
                    }
                case 8:
                    {
                        var selectedProducts = products.Where(p => p.NumberOfRecipes != null && p.Volume != null && p.DescalingProtection != null).ToList();
                        return _mapper.Map<List<MulticookerOutputModel>>(selectedProducts);
                    }
                case 9:
                    {
                        var selectedProducts = products.Where(p => p.NumberOfRecipes != null && p.NumberOfCompartments != null && p.NumberOfModes != null).ToList();
                        return _mapper.Map<List<ToasterOutputModel>>(selectedProducts);
                    }
                case 10:
                    {
                        var selectedProducts = products.Where(p => p.DryingMode != null && p.DescalingProtection != null && p.NumberOfModes != null).ToList();
                        return _mapper.Map<List<IronOutputModel>>(selectedProducts);
                    }
                case 11:
                    {
                        var selectedProducts = products.Where(p => p.DescalingProtection != null && p.Power != null && p.NumberOfNozzles != null).ToList();
                        return _mapper.Map<List<MixerOutputModel>>(selectedProducts);
                    }
                case 12:
                    {
                        var selectedProducts = products.Where(p => p.DryingMode != null && p.AirSpeed != null && p.NumberOfNozzles != null).ToList();
                        return _mapper.Map<List<HairdryerOutputModel>>(selectedProducts);
                    }
                case 13:
                    {
                        var selectedProducts = products.Where(p => p.NoiseLevel != null && p.Power != null && p.AirSpeed != null).ToList();
                        return _mapper.Map<List<FanOutputModel>>(selectedProducts);
                    }


                default: return null;
            }
        }
    }
}
