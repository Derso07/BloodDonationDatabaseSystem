using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Application.Validators;
using BloodDonationDatabase.Core.Repositories;
using BloodDonationDatabase.Core.Repository;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonationCommand.InsertDonation
{
    public class InsertDonationHandler : IRequestHandler<InsertDonationCommand, ResultViewModel<int>>
    {
        public InsertDonationHandler(IDonationRepository donationRepository, 
            IDonorRepository donorRepository, 
            IBloodStockRespository bloodStockRespository)
        {
            _donationRepository = donationRepository;
            _donorRepository = donorRepository;
            _bloodStockRespository = bloodStockRespository;
        }

        private readonly IDonationRepository _donationRepository;
        private readonly IDonorRepository _donorRepository;
        private readonly IBloodStockRespository _bloodStockRespository;
        public async Task<ResultViewModel<int>> Handle(InsertDonationCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetById(request.DonorId);
            var donationByDonor = await _donationRepository.GetByDonorId(donor.Id);

            var model = new DonorDonationViewModel
            {
                Gender = donor.Gender,
                BornAt = donor.BornAt,
                DonationAt = donationByDonor == null ? request.DonationAt : donationByDonor.DonationAt

            };
            request.Donor = model;

            var donorDonationValidator = new DonorDonationValidator();
            var validationResult = await donorDonationValidator.ValidateAsync(request.Donor);

            if (!validationResult.IsValid)
            {
                string allErrors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));

                return ResultViewModel<int>.Error(allErrors);
            }

            var donation = request.ToEntity();
            await _donationRepository.Insert(donation);
            await _bloodStockRespository.UpdateByType(donor.BloodType, donor.RhFactor, donation.QuantityML);

            return ResultViewModel<int>.Success(donation.Id);
        }
    }
}
