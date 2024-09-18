using AutoMapper;
using MyApi.Models.Domain; 
using MyApi.Models.DTO; 

namespace MyApi.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
         CreateMap<Product,ProductDto>().ReverseMap();
         CreateMap<AddProductRequestDto,Product>().ReverseMap();
         CreateMap<UpdateProductRequestDto,Product>().ReverseMap();
         CreateMap<AddOrderRequestDto,Order>().ReverseMap();
          CreateMap<UpdateOrderRequestDto,Order>().ReverseMap();
         CreateMap<Order,OrderDto>().ReverseMap();
         CreateMap<Customer,CustomerDto>().ReverseMap();
        //  CreateMap<UpdateOrderRequestDto,Order>().ReverseMap();
        }
    }
}