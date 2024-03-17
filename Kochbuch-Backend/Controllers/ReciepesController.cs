using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kochbuch_Backend.Data;
using Kochbuch_Backend.Models.Reciepe;
using AutoMapper;
using Kochbuch_Backend.Contracts;
using Microsoft.AspNetCore.Authorization;


namespace Kochbuch_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReciepesController : ControllerBase
    {
        private readonly IReciepesRepository _reciepesRepository;
        private readonly IMapper _mapper;

        public ReciepesController(IMapper mapper, IReciepesRepository reciepesRepository)
        {
            this._mapper = mapper;
            this._reciepesRepository = reciepesRepository;   
        }

        // GET: api/Reciepes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetReciepeDto>>> GetReciepes()
        {
            var reciepes = await _reciepesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetReciepeDto>>(reciepes);
            return Ok(records);
 
        }

        // GET: api/Reciepes/5
        [HttpGet("{id}")]
        public  async Task<ActionResult<ReciepeDetailsDto>> GetReciepe(int id)
        {
            var reciepe = await _reciepesRepository.GetDetails(id);

            if (reciepe == null)
            {
                return NotFound();
            }

            var reciepeDetailDto = _mapper.Map<ReciepeDetailsDto>(reciepe);

            return Ok(reciepeDetailDto);
        }

        // PUT: api/Reciepes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754 -- erledigt
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReciepe(int id, UpdateReciepeDto updateReciepeDto)
        {
            if (id != updateReciepeDto.Id)
            {
                return BadRequest("Invalid Reciepe Id");
            }

           /// _context.Entry(reciepe).State = EntityState.Modified;
           var reciepe = await _reciepesRepository.GetAsync(id);  


            if(reciepe == null) 
            { 
                return NotFound(); 
            }

           _mapper.Map(updateReciepeDto, reciepe);

            try
            {
                
                await _reciepesRepository.UpdateAsync(reciepe);
                
            }
            catch (DbUpdateConcurrencyException)
            {
                bool awaitBool = await ReciepeExists(id);
                if (!awaitBool)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reciepes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reciepe>> PostReciepe(CreateReciepeDto reciepeDto)
        {
           
            var reciepe = _mapper.Map<Reciepe>(reciepeDto);

            await _reciepesRepository.AddAsync(reciepe);
            return CreatedAtAction("GetReciepe", new { id = reciepe.Id }, reciepe);
        }

        // DELETE: api/Reciepes/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteReciepe(int id)
        {
            var reciepe = await _reciepesRepository.GetAsync(id);
            if (reciepe == null)
            {
                return NotFound();
            }

            await _reciepesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> ReciepeExists(int id)
        {
            return await _reciepesRepository.Exisits(id);
        }
    }
}
