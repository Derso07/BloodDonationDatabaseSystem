using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repositories;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonationCommand.DeleteDonation
{
    public class DeleteDonationHandler : IRequestHandler<DeleteDonationCommand, ResultViewModel>
    {
        public DeleteDonationHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        private readonly IDonationRepository _repository;

        public async Task<ResultViewModel> Handle(DeleteDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetById(request.Id);
            if (donation is null)
            {
                return ResultViewModel.Error("Doação não encontrada");
            }

            donation.SetAsDeleted();
            return ResultViewModel.Success();
        }
    }
}
