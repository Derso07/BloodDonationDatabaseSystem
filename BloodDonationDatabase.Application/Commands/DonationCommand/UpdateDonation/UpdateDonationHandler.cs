using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repositories;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonationCommand.UpdateDonation
{
    public class UpdateDonationHandler : IRequestHandler<UpdateDonationCommand, ResultViewModel>
    {
        public UpdateDonationHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        private readonly IDonationRepository _repository;

        public async Task<ResultViewModel> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetById(request.Id);
            if (donation is null)
            {
                return ResultViewModel.Error("Doação não encontrada");
            }

            donation.Update(request.DonationAt,request.QuantityML,request.DonorId);
            return ResultViewModel.Success();
        }
    }
}
