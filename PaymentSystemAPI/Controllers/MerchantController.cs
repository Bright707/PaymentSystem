using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentSystemAPI.Interfaces.IServices;
using PaymentSystemAPI.Models.DTOs;

namespace PaymentSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantService _merchantService;
        private readonly ILogger<MerchantController> _logger;

        public MerchantController(IMerchantService merchantService, ILogger<MerchantController> logger)
        {
            _merchantService = merchantService;
            _logger = logger;
        }

        [HttpGet("{MerchantId}")]
        public async Task<IActionResult> GetMerchantById(int merchantId)
        {
            try
            {
                var merchant = await _merchantService.GetMerchantByIdAsync(merchantId);

                if (merchantId == null)
                    return NotFound($"Customer with ID {merchantId} not found.");

                return Ok(merchantId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting Merchant with ID {merchantId}: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMerchants()
        {
            try
            {
                var merchants = await _merchantService.GetAllMerchantsAsync();
                return Ok(merchants);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting all Merchants: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMerchant([FromBody] MerchantDTO merchantDTO)
        {
            try
            {
                if (merchantDTO == null)
                    return BadRequest("Invalid Merchant data");

                await _merchantService.AddMerchantAsync(merchantDTO);
                return Ok("Merchant added successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding Merchant: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{MerchantId}")]
        public async Task<IActionResult> UpdateMerchant(int merchantId, [FromBody] MerchantDTO merchantDTO)
        {
            try
            {
                await _merchantService.UpdateMerchantAsync(merchantId, merchantDTO);
                return Ok("Merchant updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating Merchant with ID {merchantId}: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{merchantId}")]
        public async Task<IActionResult> DeleteMerchant(int merchantId)
        {
            try
            {
                await _merchantService.DeleteMerchantAsync(merchantId);
                return Ok("Merchant deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting merchant with ID {merchantId}: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }

}

