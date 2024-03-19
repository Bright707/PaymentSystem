using AutoMapper;
using PaymentSystemAPI.Interfaces.IRepositories;
using PaymentSystemAPI.Interfaces.IServices;
using PaymentSystemAPI.Models.DTOs;
using PaymentSystemAPI.Models;

namespace PaymentSystemAPI.Services
{
    public class MerchantService :  IMerchantService
    {
        private readonly IBaseRepository<Merchant> _merchantRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MerchantService> _logger;

        public MerchantService(IBaseRepository<Merchant> merchantRepository, IMapper mapper, ILogger<MerchantService> logger)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MerchantDTO> GetMerchantByIdAsync(int merchantId)
        {
            var merchant = await _merchantRepository.GetByIdAsync(merchantId);

            if (merchant == null)
            {
                _logger.LogWarning($"Customer with ID {merchantId} not found.");
                return null;
            }

            return _mapper.Map<MerchantDTO>(merchant);
        }

        public async Task<IEnumerable<MerchantDTO>> GetAllMerchantsAsync()
        {
            var merchants = await _merchantRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MerchantDTO>>(merchants);
        }

        public async Task<bool> AddMerchantAsync(MerchantDTO merchantDTO)
        {
            var merchant = _mapper.Map<Merchant>(merchantDTO);
            if (merchant == null)
            {
                return false;

            }
            var Merchant = new Merchant
            {
                BusinessIdNumber = merchantDTO.BusinessIdNumber,
                BusinessName = merchantDTO.BusinessName,
                FirstName = merchantDTO.BusinessName,
                SurName = merchantDTO.SurName,
                DateOfEstablishment = merchantDTO.DateOfEstablishment,
                PhoneNumber = merchantDTO.PhoneNumber,
                AverageTransactionVolume = merchantDTO.AverageTransactionVolume
            };

            await _merchantRepository.AddAsync(merchant);

            return true;
        }

        public async Task UpdateMerchantAsync(int merchantId, MerchantDTO merchantDTO)
        {
            var existingMerchant = await _merchantRepository.GetByIdAsync(merchantId);

            if (existingMerchant == null)
            {
                _logger.LogWarning($"Customer with ID {merchantId} not found.");
                return;
            }

            _mapper.Map(merchantDTO, existingMerchant);
            await _merchantRepository.UpdateAsync(existingMerchant);
        }

        public async Task DeleteMerchantAsync(int merchantId)
        {
            var merchant = await _merchantRepository.GetByIdAsync(merchantId);

            if (merchant == null)
            {
                _logger.LogWarning($"Merchant with ID {merchantId} not found.");
                return;
            }

            await _merchantRepository.DeleteAsync(merchant);
        }
    }
}
