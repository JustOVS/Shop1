using AutoMapper;
using Shop.API.Models.InputModels;
using Shop.API.Models.OutputModels;
using Shop.Data.Dto;

namespace Shop.API.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderInputModel, OrderDto>()
                 .ForPath(dest => dest.OrderItems, o => o.MapFrom(src => src.OrderItems));

            CreateMap<ProductOrderInputModel, ProductOrderDto>()
                 .ForPath(dest => dest.Product.Id, o => o.MapFrom(src => src.ProductId));

            CreateMap<OrderDto, OrderOutputModel>()
                 .ForPath(dest => dest.Time, o => o.MapFrom(src => src.Time.Value.ToString("dd.MM.yyyy HH:mm:ss")))
                 .ForPath(dest => dest.OrderItems, o => o.MapFrom(src => src.OrderItems));

            CreateMap<ProductOrderDto, ProductOrderOutputModel>()
                 .ForPath(dest => dest.Product, o => o.MapFrom(src => src.Product));

            CreateMap<ProductDto, ProductOutputModel>();
            
            CreateMap<ProductInputModel, ProductDto>();

            CreateMap<ProductDto, VacuumCleanerOutputModel>();
            CreateMap<ProductDto, WashingMachineOutputModel>();
            CreateMap<ProductDto, MicrowaveOutputModel>();
            CreateMap<ProductDto, KitchenStoveOutputModel>();
            CreateMap<ProductDto, KettleOutputModel>();
            CreateMap<ProductDto, CoffeeMakerOutputModel>();
            CreateMap<ProductDto, DishwasherOutputModel>();
            CreateMap<ProductDto, MulticookerOutputModel>();
            CreateMap<ProductDto, ToasterOutputModel>();
            CreateMap<ProductDto, IronOutputModel>();
            CreateMap<ProductDto, MixerOutputModel>();
            CreateMap<ProductDto, HairdryerOutputModel>();
            CreateMap<ProductDto, FanOutputModel>();
        }
    }
}
