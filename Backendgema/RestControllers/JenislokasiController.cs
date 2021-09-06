using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backendgema.Base;
using Backendgema.Models;
using Backendgema.Services;
using Microsoft.EntityFrameworkCore;

namespace Backendgema.RestControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JenislokasiController : ControllerBase
    {
        private readonly JenisLokasiService _service = new JenisLokasiService();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.get());
        }

        [HttpGet("page")]
        public async Task<IActionResult> getAll([FromQuery] PaginationFilter filter)
        {
            Koneksi k = new Koneksi();
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await k.JenisLokasis
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();

            var totalRecords = await k.JenisLokasis.CountAsync();

            return Ok(new PagedResponse<List<JenisLokasi>>(pagedData, validFilter.PageNumber, validFilter.PageSize));
        }

        [HttpGet("detail/{jenis}")]
        public IActionResult Detail(String jenis)
        {
            var x = _service.detail(jenis);
            if (x.status.Equals(false))
            {
                return NotFound(x);
            }
            else
            {
                return Ok(x);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] JenisLokasi jenis)
        {
            var x = _service.add(jenis);
            if (x.status.Equals(true))
            {
                return Ok(x);
            }
            else
            {
                return BadRequest(x);
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody] JenisLokasi jenis)
        {
            var x = _service.edit(jenis);
            if (x.status.Equals(true))
            {
                return Ok(x);
            }
            else
            {
                return NotFound(x);
            }
        }

        [HttpDelete("{jenis}")]
        public IActionResult Hapus(String jenis)
        {
            var x = _service.hapus(jenis);
            if (x.status.Equals(true))
            {
                return Ok(x);
            }
            else
            {
                return NotFound(x);
            }
        }
    }
}
