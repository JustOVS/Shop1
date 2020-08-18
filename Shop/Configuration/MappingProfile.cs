using AutoMapper;
using Shop.API.Models.InputModels;
using Shop.API.Models.OutputModels;
using Shop.Core;
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

            CreateMap<ProductDto, VacuumCleanerOutputModel>()
            .ForMember(dest => dest.CategoryName, o => o.MapFrom(src => ProductCategories.VacuumCleaner));

            CreateMap<ProductDto, WashingMachineOutputModel>()
            .ForMember(dest => dest.CategoryName, o => o.MapFrom(src => ProductCategories.WashingMachine));

            CreateMap<ProductDto, MicrowaveOutputModel>()
            .ForMember(dest => dest.CategoryName, o => o.MapFrom(src => ProductCategories.Microwave));

            CreateMap<ProductDto, KitchenStoveOutputModel>()
            .ForMember(dest => dest.CategoryName, o => o.MapFrom(src => ProductCategories.KitchenStove));

            CreateMap<ProductDto, KettleOutputModel>()
            .ForMember(dest => dest.CategoryName, o => o.MapFrom(src => ProductCategories.Kettle));

            CreateMap<ProductDto, CoffeeMakerOutputModel>()
            .ForMember(dest => dest.CategoryName, o => o.MapFrom(src => ProductCategories.CoffeeMaker));

            CreateMap<ProductDto, DishwasherOutputModel>()
            .ForMember(dest => dest.CategoryName, o => o.MapFrom(src => ProductCategories.Dishwasher));

            CreateMap<ProductDto, MulticookerOutputModel>()
            .ForMember(dest => dest.CategoryName, o => o.MapFrom(src => ProductCategories.Multicooker));

            CreateMap<ProductDto, ToasterOutputModel>()
            .ForMember(dest => dest.CategoryName, o => o.MapFrom(src => ProductCategories.Toaster));

            CreateMap<ProductDto, IronOutputModel>()
            .ForMember(dest => dest.CategoryName, o => o.MapFrom(src => ProductCategories.Iron));

            CreateMap<ProductDto, MixerOutputModel>()
            .ForMember(dest => dest.CategoryName, o => o.MapFrom(src => ProductCategories.Mixer));

            CreateMap<ProductDto, HairdryerOutputModel>()
            .ForMember(dest => dest.CategoryName, o => o.MapFrom(src => ProductCategories.Hairdryer));

            CreateMap<ProductDto, FanOutputModel>()
            .ForMember(dest => dest.CategoryName, o => o.MapFrom(src => ProductCategories.Fan));


        }   
    }
}
