using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repositories;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.BloodStockQueries.GetBloodStockById
{
    public class GetBloodStockByIdHandler : IRequestHandler<GetBloodStockByIdCommand, ResultViewModel<BloodStockViewModel>>
    {
        public GetBloodStockByIdHandler(IBloodStockRespository respository)
        {
            _respository = respository;
        }

        private readonly IBloodStockRespository _respository;
        public async Task<ResultViewModel<BloodStockViewModel>> Handle(GetBloodStockByIdCommand request, CancellationToken cancellationToken)
        {
            var bloodStock = await _respository.GetById(request.Id);

            if (bloodStock is null) return ResultViewModel<BloodStockViewModel>.Error("Estoque não encontrado");

            var model = BloodStockViewModel.FromEntity(bloodStock);

            return ResultViewModel<BloodStockViewModel>.Success(model);
        }
    }
}
