using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repositories;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.BloodStockCommand.UpdateBloodStock
{
    public class UpdateBloodStockHandler : IRequestHandler<UpdateBloodStockCommand, ResultViewModel>
    {
        public UpdateBloodStockHandler(IBloodStockRespository respository)
        {
            _respository = respository;
        }

        private readonly IBloodStockRespository _respository;
        public async Task<ResultViewModel> Handle(UpdateBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStock = await _respository.GetById(request.Id);

            if (bloodStock is null) return ResultViewModel.Error("Estoque não encontrado");

            bloodStock.Update(request.BloodType,request.RhFactor,request.QuantityML);

            await _respository.Update(bloodStock);
            return ResultViewModel.Success();
        }
    }
}
