using AutoMapper;
using ProjectDD.MVC.ViewModels;
using ProjectDDD.Domain.Entities;

namespace ProjectDD.MVC.Automapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainTo ViewModelMapping"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<Produto, ProdutoViewModel>();
        }
    }
}