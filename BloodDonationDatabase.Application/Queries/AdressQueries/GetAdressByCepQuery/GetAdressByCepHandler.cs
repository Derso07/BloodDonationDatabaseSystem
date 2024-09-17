using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repositories;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.AdressQueries.GetAdressByCepQuery
{
    public class GetAdressByCepHandler : IRequestHandler<GetAdressByCepQuery, ResultViewModel<AdressViewModel>>
    {
        public GetAdressByCepHandler(ICepRepository repository)
        {
            _repository = repository;
        }

        private readonly ICepRepository _repository;

        public async Task<ResultViewModel<AdressViewModel>> Handle(GetAdressByCepQuery request, CancellationToken cancellationToken)
        {
            var adress = await _repository.CheckAddress(request.Cep);

            if (adress is null)
            {
                return ResultViewModel<AdressViewModel>.Error("CEP não encontrado!");
            }

            var model = AdressViewModel.FromEntity(adress);

            return ResultViewModel<AdressViewModel>.Success(model);

        }
    }
}
