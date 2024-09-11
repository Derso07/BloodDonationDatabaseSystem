using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repositories;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.BloodStockQueries.GetAllBloodStock
{
    public class GetAllBloodStockHandler : IRequestHandler<GetAllBloodStockCommand, ResultViewModel<List<BloodStockViewModel>>>
    {
        public GetAllBloodStockHandler(IBloodStockRespository respository)
        {
            _respository = respository;
        }

        private readonly IBloodStockRespository _respository;

        public async Task<ResultViewModel<List<BloodStockViewModel>>> Handle(GetAllBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStocks = await _respository.GetAll();

            var model = bloodStocks.Select(BloodStockViewModel.FromEntity).ToList();

            return ResultViewModel<List<BloodStockViewModel>>.Success(model);
        }
    }
}
