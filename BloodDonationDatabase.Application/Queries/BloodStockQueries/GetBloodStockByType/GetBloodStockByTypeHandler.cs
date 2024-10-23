using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repositories;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.BloodStockQueries.GetBloodStockByType
{
    public class GetBloodStockByTypeHandler : IRequestHandler<GetBloodStockByTypeQuery, ResultViewModel<BloodStockViewModel>>
    {
        public GetBloodStockByTypeHandler(IBloodStockRespository respository)
        {
            _respository = respository;
        }

        private readonly IBloodStockRespository _respository;
        public async Task<ResultViewModel<BloodStockViewModel>> Handle(GetBloodStockByTypeQuery request, CancellationToken cancellationToken)
        {
            var bloodStock = await _respository.GetByType(request.BloodType,request.RhFactor);

            if (bloodStock is null)
            {
                return ResultViewModel<BloodStockViewModel>.Error("Não há estoque de sangue com esses tipos!");
            }
            var model = BloodStockViewModel.FromEntity(bloodStock);

            return ResultViewModel<BloodStockViewModel>.Success(model);
        }
    }
}
