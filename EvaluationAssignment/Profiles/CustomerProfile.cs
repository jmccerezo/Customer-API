using AutoMapper;
using EvaluationAssignment.DTO.Customer;
using EvaluationAssignment.Models;

namespace EvaluationAssignment.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Customer>();
        }
    }
}
