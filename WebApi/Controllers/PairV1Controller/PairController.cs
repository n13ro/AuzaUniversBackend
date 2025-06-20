﻿using BusinessLogic.DTOs.DTOPair;
using BusinessLogic.Services.PairService;
using CustomMemoryCache;
using Microsoft.AspNetCore.Mvc;
using Redis;

namespace WebApi.Controllers.PairV1Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PairController : ControllerBase
    {
        //private readonly RedisCacheService _cacheService;
        private readonly InMemoryCacheService _cacheService;
        private readonly IPairService _pairService;

        public PairController(IPairService pairService, InMemoryCacheService memoryCacheService)
        {
            this._cacheService = memoryCacheService;
            this._pairService = pairService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var pairs = await _cacheService.GetOrCreateCacheAsync("all_pairs",
                async () => await _pairService.GetAllPairServiceAsync(cancellationToken));

            return Ok(new { success = true, data = pairs });
            
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var onePair = await _cacheService.GetOrCreateCacheAsync($"get_by_{id}", 
                    async () => await _pairService.GetByIdPairServiceAsync(id, cancellationToken));

                if (onePair == null)
                {
                    return NotFound(new { success = false, message = "Pair not found" });
                }
                return Ok(new { success = true, data = onePair });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(DTOCreatePairService DTOPairService, CancellationToken cancellationToken)
        {
            try
            {
                await _pairService.AddPairServiceAsync(DTOPairService, cancellationToken);
                await _cacheService.RemoveCacheAsync("all_pairs");
                return Ok(new { message = "Pair is created" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(DTOUpdatePairService DTOPairService, CancellationToken cancellationToken)
        {
            try
            {
                await _pairService.UpdatePairServiceAsync(DTOPairService, cancellationToken);
                await _cacheService.RemoveCacheAsync("all_pairs");
                return Ok(new { success = true, data = "Pair updated" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _pairService.DeletePairServiceAsync(id, cancellationToken);
                await _cacheService.RemoveCacheAsync("all_pairs");
                return Ok(new { success = true, data = "Pair deleted" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetPagination(int page, int size, CancellationToken cancellationToken)
        {
            var pairs = await _cacheService.GetOrCreateCacheAsync($"page_{page}_size_{size}",
                async () => await _pairService.GetByPagePaginationServiceAsync(page, size, cancellationToken));
            return Ok(new { success = true, data = pairs });
        }

        [HttpPost("AssignPairToStudent")]
        public async Task<IActionResult> AssignPairToStudentServiceAsync(int studentId, int pairId, CancellationToken cancellationToken)
        {
            try
            {
                await _pairService.AssignPairToStudentServiceAsync(studentId, pairId, cancellationToken);
                return Ok(new { success = true, message = "Pair assigned to student successfully" });
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("AssignPairToMentor")]
        public async Task<IActionResult> AssignPairToMentorServiceAsync(int mentorId, int pairId, CancellationToken cancellationToken)
        {
            try
            {
                await _pairService.AssignPairToMentorServiceAsync(mentorId, pairId, cancellationToken);
                return Ok(new { success = true, message = "Pair assigned to mentor successfully" });
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
