using AutoMapper;
using PersonalFinance.Dtos;
using PersonalFinance.Models;

namespace PersonalFinance.Mapping_Profiles;

public class TransactionProfile : Profile
{
    public TransactionProfile()
    {
        CreateMap<TransactionDto, Transaction>();
        CreateMap<TransactionCreateDto, Transaction>().ReverseMap();
        CreateMap<TransactionUpdateDto, Transaction>();

    }
    
}